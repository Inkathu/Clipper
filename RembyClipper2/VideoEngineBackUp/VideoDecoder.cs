using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreamCoders.Reader;
using System.Windows.Forms;
using StreamCoders.Decoder;
using StreamCoders;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using RembyClipper.Helpers;
using System.Threading;
using StreamCoders.Wave;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using StreamCoders.Timing;
using RembyClipper.VideoEngine;

namespace RembyClipper2.VideoEngine
{
    public class VideoDecoder : IDisposable
    {
        private double audioBase;
        private int audioBufferThreshold;
        private AudioDecoderBase audioDecoder;
        private Thread audioThread;
        private uint audioTrack;
        private bool closeApplication;
        private Bitmap dImage;
        private Rectangle dImageRect;
        private Mutex displayMutex;
        private bool isRunning;
        private bool isURL;
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

        private int vidMaximum;
        private int aI = 0;
        private int vI = 0;

        public void Init()
        {
            isRunning = false;
            closeApplication = false;
            isURL = false;
            Streched = false;
        }

        public string CalculateMD5Hash(byte[] input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();

            byte[] hash = md5.ComputeHash(input);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public void Open()
        {
            if (isRunning)
            {
                Stop();
            }

            String extension;
            String filename = Filename;

            reader = new AVIReader();
            reader.FileName = filename;
            bool initRes = reader.Init();

            if (initRes == false)
            {
                throw new Exception("Unable to load file");
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
                        throw new Exception("Invalid audio");
                        return;
                    }

                    if (ti.TrackType == TrackTypes.MP3) audioDecoder = new MP3Decoder();

                    if (audioDecoder == null)
                    {
                        throw new Exception("Invalid audio");
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
                    //audioBufferThreshold = 0;
                    if (audioInitResult == false)
                    {
                        throw new Exception("Invalid audio");
                        return;
                    }

                    if ((ti.TrackType == TrackTypes.AAC || ti.TrackType == TrackTypes.AMR) && ti.Audio.DecoderData != null)
                    {
                        audioDecoder.Decode(ti.Audio.DecoderData);
                    }

                    this.vidMaximum = (int)Math.Floor(ti.Audio.Duration);

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

                    videoDecoder.VideoSource = StreamSources.FILE_AVI;


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
                        throw new Exception("Invalid video");
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


            Start();
            
        }

        public void Start()
        {
            dImage = new Bitmap(videoDecoder.InputWidth, videoDecoder.InputHeight, PixelFormat.Format24bppRgb);
            dImageRect = new Rectangle(0, 0, videoDecoder.InputWidth, videoDecoder.InputHeight);
            Surface.BackgroundImage = dImage;
            pictureGraphics = Graphics.FromImage(Surface.BackgroundImage);

            aI = 0;
            vI = 0;

            startTicker = Environment.TickCount;

            videoFrames = new List<MediaPackage>();
            
            isRunning = true;
            if (videoDecoder != null)
            {
                videoThread = new Thread(VideoStart);
                videoThread.TrySetApartmentState(ApartmentState.MTA);
                videoThread.Name = "VideoThread";
            }

            if (audioDecoder != null)
            {
                audioThread = new Thread(AudioStart);
                audioThread.TrySetApartmentState(ApartmentState.MTA);
                audioThread.Name = "AudioThread";
            }
            syncThread = new Thread(SyncStart);
            syncThread.SetApartmentState(ApartmentState.MTA);
            syncThread.Name = "SyncThread";

            syncThread.Start();

            if (videoDecoder != null) videoThread.Start();
            if (audioDecoder != null) audioThread.Start();
        }

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
                        //this.DisplayPicture(mp);
                        videoSyncSemaphore.Release();
                    }
                    else
                    {
                        videoSemaphore.Release();
                        lastDecodeResult = false;
                    }
            }
        }

        // Reads Audio Track and writes them directly to the audio device
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
                        ParentForm.Invoke((MethodInvoker)delegate
                        {

                            var progress = (int)Math.Floor(GetAudioClock());
                            //if (progress <= trackBar1.Maximum && progress >= trackBar1.Minimum) trackBar1.Value = progress;
                            if (progress >= 0 && progress <= 100)
                                progressBar.Value = (int)((progress * 100) / vidMaximum);
                        });
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
                DisplayPicture(vFrame);
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
            lock (dImage)
            {
                Bitmap tmp = (Bitmap)dImage.Clone();
                picData = tmp.LockBits(dImageRect, ImageLockMode.ReadWrite, tmp.PixelFormat);
                Marshal.Copy(mp.Buffer, 0, picData.Scan0, mp.Buffer.Length);
                tmp.UnlockBits(picData);
                DrawImage(tmp);
            }
            
        }


        private delegate void DrawImageDelegate();
        private void DrawImage(Bitmap tmp)
        {

           // if (!Streched) pictureGraphics.DrawImage(dImage, 0, 0, Surface.Width, Surface.Height);
           // else
           //     pictureGraphics.DrawImageUnscaled(dImage, (Surface.Width - dImage.Width) / 2,
            //                                      (Surface.Height - dImage.Height) / 2);
            pictureGraphics.DrawImage(tmp, 0, 0);
            pictureGraphics.DrawLine(new Pen(Color.Magenta), 0, 0, 100, 100);
            pictureGraphics.Flush();
            tmp.Dispose();
        }

        private double GetAudioClock()
        {
            if (audioDecoder == null) return (Environment.TickCount - startTicker) / 1000.0;
            double avNormal = 0;
            double aclock = waveout.CurrentTimeOffset - avNormal;
            return aclock;
        }

        public void Stop()
        {
            var cThread = new Thread(CloseThread);
            cThread.Name = "CloseThread";
            cThread.Start();
        }

        bool paused = false;
        public void Pause()
        {
            paused = true;
            Stop();
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

                syncThread.Join();
                if (audioThread != null) audioThread.Join();
                if (videoThread != null) videoThread.Join();

                if (audioThread != null) waveout.CloseDevice();

                if (!paused)
                    reader.Dispose();
                else
                {
                    reader.Position = 0;
                }
            }
        }



        #region IDisposable Members

        public void Dispose()
        {
            this.Stop();
        }

        #endregion
    }
}
