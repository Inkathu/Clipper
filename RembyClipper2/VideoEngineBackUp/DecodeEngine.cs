using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using StreamCoders;
using StreamCoders.Decoder;
using StreamCoders.Reader;
using StreamCoders.Timing;
using StreamCoders.Wave;
using RembyClipper.Helpers;


namespace RembyClipper2.VideoEngine
{
    public class DecodeEngine: IDisposable
    {
        private double audioBase;
        private int audioBufferThreshold;
        private AudioDecoderBase audioDecoder;
        private Thread audioThread;
        private uint audioTrack;
        private Bitmap dImage;
        private Rectangle dImageRect;
        private Mutex displayMutex;
        private bool isRunning;
        private BitmapData picData;
        private Graphics pictureGraphics;
        private StreamCoders.Reader.Reader reader;
        private int startTicker;
        private Thread syncThread;
        private double videoBase;
        private VideoDecoderBase videoDecoder;
        private double videoFramerate;
        private List<MediaPackage> videoFrames;
        private Semaphore videoSemaphore;
        private Semaphore videoSyncSemaphore;
        private Thread videoThread;
        private uint videoTrack;
        private WaveOutput waveout;

        public string Filename { get; set; }
        public Control Surface { get; set; }
        public RembyClipper2.Base.RembyProgressBar progressBar { get; set; }
        public bool Streched { get; set; }
        public Form ParentForm { get; set; }

        public double Progress { get; private set; }
        public double Duration { get; private set; }

        private int vidMaximum = 0;
        private double oProgress = -10;

        public delegate void onStopDelegate();
        public event onStopDelegate onStop; 

        public void Init()
        {
            isRunning = false;
        }

        public void Open()
        {
            if (isRunning)
            {
                StopPlaying();
            }

            String extension;
            String filename = Filename;

            reader = new AVIReader();
            reader.FileName = filename;
            bool initRes = reader.Init();
            if (initRes == false)
            {
                MessageBox.Show(string.Format("Unable to load {0}", reader.FileName));
                return;
            }

            String audioCodecString = "";
            String videoCodecString = "";

            for (uint i = 0; i < reader.TrackCount; i++)
            {
                TrackInfo ti = reader.GetTrack(i);
                if (ti == null) // A corrupt/invalid/unsupported track?
                    continue;
                if (ti.TrackCategory == TrackCategories.AUDIO)
                {
                    audioTrack = i;
                    audioCodecString = ti.TrackType.ToString();
                    if (ti.TrackType != TrackTypes.MP3 && ti.TrackType != TrackTypes.AAC && ti.TrackType != TrackTypes.AC3 &&
                        ti.TrackType != TrackTypes.AMR)
                    {
                        MessageBox.Show("Player currently supports MP3, AC3 and AAC audio codecs only");
                        return;
                    }

                    if (ti.TrackType == TrackTypes.MP3) audioDecoder = new MP3Decoder();

                    if (audioDecoder == null)
                    {
                        MessageBox.Show(string.Format("No fitting audio decoder initialized. ({0})", ti.TrackType));
                        continue;
                    }

                    audioDecoder.BitsPerSample = ti.Audio.BitsPerSample;
                    audioDecoder.Channels = ti.Audio.Channels;
                    audioDecoder.SampleRate = ti.Audio.SampleFrequency;
                    bool audioInitResult = false;

                    if (ti.TrackType == TrackTypes.MP3 && ti.Audio.DecoderData != null)
                    {
                        audioInitResult = ((MP3Decoder)audioDecoder).Init();
                        audioDecoder.Decode(ti.Audio.DecoderData);

                        audioInitResult = true;
                        if (audioInitResult)
                        {
                            ti.Audio.Channels = audioDecoder.Channels;
                            ti.Audio.SampleFrequency = audioDecoder.SampleRate;
                        }
                    }
                    else audioInitResult = audioDecoder.Init();

                    audioBufferThreshold = (ti.Audio.BitsPerSample >> 3) * ti.Audio.Channels * ti.Audio.SampleFrequency / 2;

                    if (audioInitResult == false)
                    {
                        MessageBox.Show("Unable to initialize audio decoder");
                        return;
                    }

                    if ((ti.TrackType == TrackTypes.AAC || ti.TrackType == TrackTypes.AMR) && ti.Audio.DecoderData != null)
                    {
                        audioDecoder.Decode(ti.Audio.DecoderData);
                    }

                    vidMaximum = (int)Math.Floor(ti.Audio.Duration);
                    Duration = ti.Audio.Duration;

                    waveout = new WaveOutput();
                    waveout.BitsPerSample = audioDecoder.BitsPerSample;
                    waveout.Channels = audioDecoder.Channels;
                    if (waveout.Channels > 2) waveout.Channels = 2;
                    waveout.SampleRate = audioDecoder.SampleRate;
                    waveout.Init();
                    waveout.OpenDevice();
                }

                if (ti.TrackCategory == TrackCategories.VIDEO)
                {
                    videoTrack = i;
                    if (ti.TrackType == TrackTypes.TRACK_UNKNOWN)
                        ti.TrackType = TrackTypes.H264;

                    videoCodecString = ti.TrackType.ToString();
                    if (ti.TrackType != TrackTypes.MPEG4V && ti.TrackType != TrackTypes.H264 && ti.TrackType != TrackTypes.H263)
                    {
                        MessageBox.Show(String.Format("Player currently supports H.263, MPEG4 and H.264 video codec only (Requested Codec: {0})",
                                                      ti.TrackType));
                        return;
                    }
                    if (ti.TrackType == TrackTypes.H264) videoDecoder = new H264Decoder();



                    videoDecoder.InputWidth = ti.Video.Width;
                    videoDecoder.InputHeight = ti.Video.Height;
                    videoDecoder.SetInputFrameRate(ti.Video.Framerate);


                    switch (ti.TrackType)
                    {
                        case TrackTypes.H264:
                            {
                                if (ti.Video.DecoderData != null)
                                    ((H264Decoder)videoDecoder).Init(ti.Video.DecoderData);
                                else
                                {
                                    var sf = reader.GetNextFrame(ti.TrackNumber);
                                    (videoDecoder as H264Decoder).Init(sf.Buffer).ToString();
                                }
                                if (ti.Video.Framerate == 0.0)
                                {
                                    ti.Video.Framerate = videoDecoder.InputFramerate;
                                }
                            }
                            break;
                        default:
                            videoDecoder.Init();
                            videoDecoder.Decode(ti.Video.DecoderData);
                            break;
                    }

                    videoFramerate = ti.Video.Framerate;

                    if (videoFramerate == 0.0)
                    {
                        MessageBox.Show("No valid Framerate available.");
                        return;
                    }

                    videoSemaphore = new Semaphore((int)videoFramerate, (int)videoFramerate);
                    videoSyncSemaphore = new Semaphore(0, 30200);
                    displayMutex = new Mutex();
                }
            }

            if (videoDecoder != null)
                DebugHelper.Log(" - " + videoCodecString + "/" + videoDecoder.InputWidth + "x" + videoDecoder.InputHeight + "@" +
                        videoDecoder.InputFramerate.ToString("F"));
            if (audioDecoder != null) DebugHelper.Log(" " + audioCodecString + "/" + audioDecoder.BitsPerSample + "x" + audioDecoder.Channels + "@" + audioDecoder.SampleRate);

            dImage = new Bitmap(videoDecoder.InputWidth, videoDecoder.InputHeight, PixelFormat.Format24bppRgb);
            dImageRect = new Rectangle(0, 0, videoDecoder.InputWidth, videoDecoder.InputHeight);
            pictureGraphics = Graphics.FromImage(Surface.BackgroundImage);

            startTicker = Environment.TickCount;

            videoFrames = new List<MediaPackage>();

            isRunning = true;
            if (videoDecoder != null)
            {
                videoThread = new Thread(VideoStart);
                videoThread.Name = "VideoThread";
            }

            if (audioDecoder != null)
            {
                audioThread = new Thread(AudioStart);
                audioThread.Name = "AudioThread";
            }
            syncThread = new Thread(SyncStart);
            syncThread.Name = "SyncThread";

            syncThread.Start();

            if (videoDecoder != null) videoThread.Start();
            if (audioDecoder != null) audioThread.Start();
        }

        // Reads Video track and buffers the decoded frames in "videoFrames" list. SyncThread will do the rest.
        private void VideoStart()
        {
            bool firstRun = true;
            bool lastDecodeResult = true;
            while (isRunning)
            {
                videoSemaphore.WaitOne();
                ThisThread.Sleep(0);
                MediaPackage mp = null;
                bool pending = reader.GetTrackStatus(videoTrack) != TrackStatus.TRACK_STREAM_END;
                uint undecoded = videoDecoder.GetUnDecodedBytes();
                pending &= undecoded <= 4 || lastDecodeResult == false;

                if (pending)
                {
                    lock (reader)
                    {
                        mp = reader.GetNextFrame(videoTrack);
                    }
                    if (mp == null)
                    {
                        ThisThread.Sleep(0); // Give the other tracks some time to catch up
                        try
                        {
                            videoSemaphore.Release();
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        continue;
                    }

                    if (mp.Buffer.Length <= 8)
                    {
                        try
                        {
                            videoSemaphore.Release();
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        continue;
                    }
                }

                mp = videoDecoder.Decode(mp);
                if (mp != null)
                    if (videoDecoder.GetLastFrameInfo().IsError == false && mp != null)
                    {
                        lastDecodeResult = true;
                        if (firstRun)
                        {
                            firstRun = false;
                            videoBase = mp.startTime;
                        }
                        AddPicture(mp);
                        videoSyncSemaphore.Release();
                    }
                    else
                    {
                        videoSemaphore.Release();
                        lastDecodeResult = false;
                    }
            }
        }

        private void AudioStart()
        {
            MediaPackage mp = null;
            bool firstRun = true;
            while (isRunning)
            {
                lock (waveout)
                {
                    waveout.UnprepareBuffers();
                }
                if (waveout.QueuedBytes > audioBufferThreshold)
                {
                    ThisThread.Sleep(5);
                    continue;
                }
                lock (reader)
                {
                    mp = reader.GetNextFrame(audioTrack);
                }

                if (GetAudioClock() > 0 && isRunning)
                {
                    if (!ParentForm.IsDisposed)
                    //ParentForm.Invoke((MethodInvoker)delegate
                    {


                        var progress = GetAudioClock();
                        this.Progress = progress;
                        if (progress >= 0 && progress <= reader.GetTrack(videoTrack).Video.Duration)
                            progressBar.Value = (int)Math.Round(((Math.Round(progress) * 100) / Math.Floor(reader.GetTrack(videoTrack).Video.Duration)));

                        if (progress == oProgress)
                        {
                            progressBar.Value = 0;
                            CloseThread();
                        }
                        else
                            oProgress = progress;
                        

                    }
                }
                
                if (mp == null)
                {
                    ThisThread.Sleep(0); // Give the other tracks some time to catch up
                    continue;
                }

                mp = audioDecoder.Decode(mp);

                if (mp != null)
                {
                    if (firstRun)
                    {
                        firstRun = false;
                        audioBase = mp.startTime;
                    }
                    lock (waveout)
                    {
                        waveout.Enqueue(mp);
                    }
                }
            }
        }

        // Synchronizes audio and video according to their timestamps provided by both decoders and reference clock provided by the audio device.
        private void SyncStart()
        {
            MediaPackage vFrame = null;
            while (isRunning)
            {
                vFrame = GetNextPicture();
                if (vFrame == null)
                {
                    ThisThread.Sleep(1); // Give up timeshare to get more frames
                    continue;
                }

                // Pretty straight forward, simply check for the delta between the two streams and act accordingly. 
                double headDelta = vFrame.startTime - GetAudioClock(); // Audio provides clocking
                if (headDelta > 0.05)
                {
                    while (headDelta > 0.05)
                    {
                        if (headDelta > 10.0) break;
                        headDelta = vFrame.startTime - GetAudioClock();
                        ThisThread.Sleep(2);
                    }
                    DisplayPicture(vFrame);
                    //System.Threading.Thread.Sleep(5);
                }
                else if (headDelta > -0.05)
                {
                    DisplayPicture(vFrame);
                }
            }
        }

        private void AddPicture(MediaPackage mp)
        {
            lock (videoFrames)
            {
                videoFrames.Add(mp);
            }
        }

        private MediaPackage GetNextPicture()
        {
            if (isRunning == false) return null;
            videoSyncSemaphore.WaitOne();
            MediaPackage mp = null;
            lock (videoFrames)
            {
                if (videoFrames.Count > 0)
                {
                    mp = videoFrames[0];
                    videoFrames.RemoveAt(0);
                }
                else return null;
            }

            videoSemaphore.Release();
            return mp;
        }

        private void DisplayPicture(MediaPackage mp)
        {
            if (isRunning == false) return;
            picData = dImage.LockBits(dImageRect, ImageLockMode.ReadWrite, dImage.PixelFormat);
            Marshal.Copy(mp.Buffer, 0, picData.Scan0, mp.Buffer.Length);
            dImage.UnlockBits(picData);
            dImage.Save(mp.startTime.ToString() + ".png");
            ParentForm.Invoke((MethodInvoker)delegate
            {
                using (Graphics g = Surface.CreateGraphics())
                    g.DrawImage(dImage, 0, 0, Surface.Width,Surface.Height);
            });
        }

        private double GetAudioClock()
        {
            if (audioDecoder == null) return (Environment.TickCount - startTicker) / 1000.0;
            double avNormal = 0;
            double aclock = waveout.CurrentTimeOffset - avNormal;
            return aclock;
        }

        private void StopPlaying()
        {
            var cThread = new Thread(CloseThread);
            cThread.Name = "CloseThread";
            cThread.Start();
        }

        private void CloseThread()
        {
            if (isRunning)
            {
                isRunning = false;
                try
                {
                    videoSemaphore.Release();
                    videoSyncSemaphore.Release();
                }
                catch (Exception)
                {
                }

                if (onStop != null)
                    onStop();



                syncThread.Join();
                if (audioThread != null) audioThread.Join();
                if (videoThread != null) videoThread.Join();

                if (audioThread != null) waveout.CloseDevice();

                reader.Dispose();
                Dispose();
            }

        }

        #region IDisposable Members

        public void Dispose()
        {
              audioDecoder.Dispose();
              dImage.Dispose();
              displayMutex.Dispose();
              pictureGraphics.Dispose();
              videoDecoder.Dispose();
              videoSemaphore.Dispose();
              videoSyncSemaphore.Dispose();
              waveout.Dispose();
        }

        #endregion
    }
}
