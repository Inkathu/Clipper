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

namespace RembyClipper2.VideoEngine
{
    public class VideoDecoder2 : IDisposable
    {
        public string Filename { get; set; }
        public Control Surface { get; set; }
        public bool Stretched { get; set; }
        public Form ParentForm { get; set; }
        public RembyClipper2.Base.RembyProgressBar progressBar { get; set; }


        private bool isRunning = false, lastDecodeResult = true, paused = false;
        private AVIReader reader;
        private H264Decoder vdecoder;
        private MP3Decoder adecoder;
        private WaveOutput waveout;
        private uint vTrack, aTrack;
        private int startTicker;
        private int vidMaximum;

        private BitmapData picData;
        private Graphics pictureGraphics;
        private Bitmap dImage;
        private Rectangle dImageRect;
        private Thread bgThread;

        public void Init()
        {
            reader = new AVIReader();
            reader.FileName = Filename;
            reader.Init();

            for (uint i = 0; i < reader.TrackCount; i++)
            {
                var track = reader.GetTrack(i);
                if (track.TrackCategory == TrackCategories.AUDIO)
                {
                    aTrack = i;
                    adecoder = new MP3Decoder();

                    adecoder.BitsPerSample = track.Audio.BitsPerSample;
                    adecoder.Channels = track.Audio.Channels;
                    adecoder.SampleRate = track.Audio.SampleFrequency;
                    adecoder.Init();
                    adecoder.Decode(track.Audio.DecoderData);
                    track.Audio.Channels = adecoder.Channels;
                    track.Audio.SampleFrequency = adecoder.SampleRate;

                    vidMaximum = (int)Math.Floor(track.Audio.Duration);

                    waveout = new WaveOutput();
                    waveout.BitsPerSample = adecoder.BitsPerSample;
                    waveout.Channels = adecoder.Channels;
                    if (waveout.Channels > 2) waveout.Channels = 2;
                    waveout.SampleRate = adecoder.SampleRate;
                    waveout.Init();
                    waveout.OpenDevice();
                }
                if (track.TrackCategory == TrackCategories.VIDEO)
                {
                    vTrack = i;
                    vdecoder = new H264Decoder();


                    vdecoder.VideoSource = StreamSources.FILE_AVI;


                    vdecoder.InputWidth = track.Video.Width;
                    vdecoder.InputHeight = track.Video.Height;
                    vdecoder.SetInputFrameRate(track.Video.Framerate);

                    if (track.Video.DecoderData != null)
                        vdecoder.Init(track.Video.DecoderData);
                    else
                    {
                        var sf = reader.GetNextFrame(track.TrackNumber);
                        vdecoder.Init(sf.Buffer).ToString();
                    }
                    if (track.Video.Framerate == 0.0)
                    {
                        track.Video.Framerate = vdecoder.InputFramerate;
                    }
                }
            }


        }

        public void Start()
        {
            isRunning = true;
            if (!paused)
            {
                dImage = new Bitmap(vdecoder.InputWidth, vdecoder.InputHeight, PixelFormat.Format24bppRgb);
                dImageRect = new Rectangle(0, 0, vdecoder.InputWidth, vdecoder.InputHeight);
                pictureGraphics = Surface.CreateGraphics();
                startTicker = Environment.TickCount;
            }
            bgThread = new Thread(getAndPlay);
            bgThread.Start();
        }

        public void Pause()
        {
            isRunning = false;
            paused = true;
            bgThread.Join();
        }

        public void Stop()
        {
            isRunning = false;
            paused = false;
            bgThread.Join();
            reader.Position = 0;
        }

        private void getAndPlay()
        {
            lastDecodeResult = true;
            while (isRunning)
            {
                MediaPackage mpv = null, mpa = null;
                bool pending = reader.GetTrackStatus(vTrack) != TrackStatus.TRACK_STREAM_END;
                uint undecoded = vdecoder.GetUnDecodedBytes();
                pending &= undecoded <= 4 || lastDecodeResult == false;

                if (pending)
                {
                    lock (reader)
                    {
                        mpv = reader.GetNextFrame(vTrack);
                        mpa = reader.GetNextFrame(aTrack);
                    }
                    mpv = vdecoder.Decode(mpv);
                    mpa = adecoder.Decode(mpa);
                    if (mpv != null)
                    {
                        if (vdecoder.GetLastFrameInfo().IsError == false)
                            DisplayPicture(mpv);
                        else
                            lastDecodeResult = false;
                    }
                    if (mpa != null)
                    {
                        lock (waveout)
                        {
                            waveout.UnprepareBuffers();
                        }
                        if (GetAudioClock() > 0 && isRunning)
                            ParentForm.Invoke((MethodInvoker)delegate
                            {
                                var progress = (int)Math.Floor(GetAudioClock());
                                //if (progress <= trackBar1.Maximum && progress >= trackBar1.Minimum) trackBar1.Value = progress;
                                if (progress >= 0 && progress <= 100)
                                    progressBar.Value = (int)((progress * 100) / vidMaximum);
                            });
                        lock (waveout)
                            waveout.Enqueue(mpa);
                    }
                }
            }
        }

        private void DisplayPicture(MediaPackage mp)
        {
            if (isRunning == false) return;
            
            picData = dImage.LockBits(dImageRect, ImageLockMode.ReadWrite, dImage.PixelFormat);
            Marshal.Copy(mp.Buffer, 0, picData.Scan0, mp.Buffer.Length);
            dImage.UnlockBits(picData);

            if (!Stretched) pictureGraphics.DrawImage(dImage, 0, 0, Surface.Width, Surface.Height);
            else
                pictureGraphics.DrawImageUnscaled(dImage, (Surface.Width - dImage.Width) / 2,
                                                  (Surface.Height - dImage.Height) / 2); ;
        }

        private double GetAudioClock()
        {
            if (adecoder == null) return (Environment.TickCount - startTicker) / 1000.0;
            double avNormal = 0;
            double aclock = waveout.CurrentTimeOffset - avNormal;
            return aclock;
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
