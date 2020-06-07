#define h264
#define mp4
using System;
using System.Collections.Generic;

using System.Text;
using StreamCoders;
using System.Drawing;
using StreamCoders.Encoder;
using StreamCoders.MP4Toolkit;
using StreamCoders.Wave;
using StreamCoders.Writer;
using System.Drawing.Imaging;
using System.Windows.Forms;
using RembyClipper.Helpers;
using System.ComponentModel;
using System.Runtime.InteropServices;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.VideoEngine;
using SmartAssembly.Attributes;
using System.Threading;

namespace RembyClipper.VideoEngine
{
    [DoNotObfuscate]
    [DoNotObfuscateControlFlow]
    [DoNotEncodeStrings]
    public class ScreenCapture2 : IDisposable
    {
        public string Filename { get; set; }
        public int FPS { get; set; }
        public bool IsRunning { get; private set; }

        private Rectangle _upscaledBounds = new Rectangle();

        private System.Drawing.Rectangle _Bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        public System.Drawing.Rectangle Bounds
        {
            get { return _Bounds; }
            set { _Bounds = value; }
        }

        private bool muteMic = false;

        public bool MuteMic
        {
            get { return muteMic; }
            set { muteMic = value; }
        }

        public CameraControl cc { get; set; }

        int audioChannels = AppConfig.GetInstance().audioChannels;
        int audioSampleFreq = AppConfig.GetInstance().audioSampleFreq;
        int audioBitrate = AppConfig.GetInstance().audioBitrate;
        int audioBitsPerSample = AppConfig.GetInstance().audioBitsPerSample;

        public int AudioChannels { get { return audioChannels; } set { audioChannels = value; } }
        public int AudioSampleFreq { get { return audioSampleFreq; } set { audioSampleFreq = value; } }
        public int AudioBitrate { get { return audioBitrate; } set { audioBitrate = value; } }
        public int AudioBitsPerSample { get { return audioBitsPerSample; } set { audioBitsPerSample = value; } }

        public bool SaveFirstFrame { get; set; }

        public delegate void RecordingFinishedDelegate();
        public event RecordingFinishedDelegate RecordingFinished;

        public DateTime StartedAt { get; private set; }

        private string tempDir = System.IO.Path.GetTempPath() + "\\snapshot\\";
        private System.Threading.Thread snap;

#if h264
        H264Encoder venc;
#endif
#if h263
        H263Encoder venc;
#endif

#if !mp4
        MP3Encoder aenc;
#else
        AACEncoder aenc;
#endif

        WaveInput win;
#if avi
        AVIWriter writer;
#endif
#if mp4
        MP4Writer writer;
#endif
        TrackInfo vtrack;
        TrackInfo atrack;

        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }
        
        ~ScreenCapture2()
        {
            Dispose(false);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (win != null)
                    win.Dispose();
                if (venc != null)
                    venc.Dispose();
                if (aenc != null)
                    aenc.Dispose();
                if (vtrack != null)
                    vtrack.Dispose();
                if (atrack != null)
                    atrack.Dispose();
                writer = null;
                //GC.Collect();
            }
            // do unmanaged cleanup here,
            // using P/Invokes as necessary
        }

        bool _cancel = false;

        public void Abort()
        {
            Thread.CurrentThread.Abort();
        }

        public void Stop()
        {
            Thread.Sleep(500);
            _cancel = true;
        }

        public void Capture()
        {
            /*
            CamCapture cam = new CamCapture();
            System.Collections.Generic.List<string> devices = cam.GetDeviceList();
            cam.SelectDevice(devices[0]);
            CamMetrics cm = new CamMetrics();
            cm.Fps = framerate;
            cm.Height = 640;
            cm.Width = 480;
            cam.SelectMetrics(cm);
            cam.Start();*/
            StartedAt = DateTime.Now;
            Init();
            snap = new System.Threading.Thread(Snapshot);
            snap.SetApartmentState(System.Threading.ApartmentState.MTA);
            snap.Name = "Snap";
            snap.Start();
        }


        private void Snapshot()
        {

            DebugHelper.AddKnownThreadIDs(Thread.CurrentThread.ManagedThreadId, "SnapThread");
            win.ClearBuffers();

            int startTicker = System.Environment.TickCount;
            double frameduration = 1000.0 / (double)FPS;
            int absoluteTicker = System.Environment.TickCount;
            int videoEncoded = 0;

            IsRunning = true;

            while (_cancel == false)
            {
                int delta = System.Environment.TickCount - startTicker;

                if (delta > frameduration)
                {
                    //DebugHelper.Log(System.Environment.TickCount + " " + startTicker + " " + delta.ToString() + " " + frameduration);

                    int deltaError = delta - (int)frameduration;
                    startTicker = System.Environment.TickCount - deltaError;
                    int absDelta = System.Environment.TickCount - absoluteTicker;

                    System.Drawing.Bitmap X = (Bitmap)GrabScreen.Snap(this.Bounds, true, cc,GrabScreenSource.Screenvideo);

                    Bitmap tmp = new Bitmap(_upscaledBounds.Width, _upscaledBounds.Height, X.PixelFormat);
                    using (Graphics g = Graphics.FromImage(tmp))
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), 0, 0, tmp.Width, tmp.Height);
                        int x = 0 + tmp.Width / 2 - (X.Size.Width / 2);
                        int y = 0 + tmp.Height / 2 - (X.Size.Height / 2);
                        g.DrawImage(X, x, y);
                    }
                    X.Dispose();
                    X = tmp;

                    if (SaveFirstFrame)
                    {
                        X.Save(this.Filename + ".png", ImageFormat.Png);
                        SaveFirstFrame = false;
                    }

                    byte[] pic = ConvertImageToByteArray(X);
                    if (pic != null)
                    {
                        videoEncoded = EncodeVideo(videoEncoded, X);
                    }
                    X.Dispose();

                }
                if (win.SamplesAvailable)
                {
                    byte[] samples = win.GetAllData();
                    if (muteMic && samples != null)
                    {
                        for (int i = 0; i < samples.Length; i++)
                            samples[i] = 0;
                    }
                    while (true)
                    {
                        byte[] csamples = aenc.Encode(samples);
                        samples = null;
                        if (csamples != null)
                        {
                            MediaPackage mp = new MediaPackage();
                            mp.Buffer = csamples;
                            try
                            {
                                bool writeres = writer.WriteTrack(atrack, mp, false);
                            }
                            catch (Exception ee)
                            {
                                DebugHelper.Error(ee.ToString());
                            }
                            mp.Dispose();

                        }
                        else
                            break;
                    }
                }
                DebugHelper.LogCPU();
            }

            try
            {
                if (writer != null)
                {
                    if (vtrack != null)
                    {
                        writer.EndTrack(vtrack);
                    }
                    if (atrack != null)
                    {
                        writer.EndTrack(atrack);
                    }
                
                    writer.Dispose();
                }

            }
            catch (Exception exc)
            {

                DebugHelper.Log(exc.ToString());
            }


            if (RecordingFinished != null)
                RecordingFinished();

            DebugHelper.Log("Video thread killed");
            //snap.Join();
        }

        private delegate int encodeVideoDelegate(int v, Bitmap b);


        double videoCurrent = 0.0;
        private int EncodeVideo(int videoEncoded, Bitmap bitmap)
        {
            BitmapData raw = null;  //used to get attributes of the image
            byte[] rawImage = null; //the image as a byte[]

            try
            {
                

                //GC.Collect();
                //Freeze the image in memory
                raw = bitmap.LockBits(
                    new Rectangle(0, 0, (int)bitmap.Width, (int)bitmap.Height),
                    ImageLockMode.ReadOnly,
                    bitmap.PixelFormat
                );

                int size = raw.Height * Math.Abs(raw.Stride);
                rawImage = new byte[size];



                //Copy the image into the byte[]
                System.Runtime.InteropServices.Marshal.Copy(raw.Scan0, rawImage, 0, size);
                //GC.Collect();
                byte[] cpic = venc.EncodeToArray(rawImage);
                MediaPackage mp = new MediaPackage();
                mp.Buffer = cpic;
                mp.startTime = videoCurrent;
                mp.endTime = 1.0 / FPS;

                bool writeres = writer.WriteTrack(vtrack, mp);
                //DebugHelper.Log("An error occured in attepmt to write video track");
                videoCurrent += (1.0 / FPS);

                videoEncoded++;
                mp.Dispose();

            }

            finally
            {
                if (raw != null)
                {
                    //Unfreeze the memory for the image
                    bitmap.UnlockBits(raw);
                }
            }


            return videoEncoded;
        }     

//        private System.Drawing.Bitmap Snap()
//        {
//            System.Drawing.Bitmap X = new System.Drawing.Bitmap(_Bounds.Width, _Bounds.Height, PixelFormat.Format24bppRgb);
//            using (System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(X))
//            {
//                G.CopyFromScreen(_Bounds.Location, new System.Drawing.Point(), _Bounds.Size);
//                Point p = new Point(Cursor.Position.X - _Bounds.Location.X, Cursor.Position.Y - _Bounds.Location.Y);
//                System.Drawing.Rectangle CurBounds = new System.Drawing.Rectangle(p, System.Windows.Forms.Cursor.Current.Size);
//                Cursors.Default.Draw(G, CurBounds);
//
//            }
//            return X;
//        }

        private void Init()
        {
            FPS = AppConfig.Instance.CaptureFPS;

            _cancel = false;
            IsRunning = false;

            upscaleBounds();

            venc = new H264Encoder();
            venc.SetInputResolution((uint)this._upscaledBounds.Width, (uint)this._upscaledBounds.Height);
            venc.Framerate = FPS;
            venc.IFrameFrequency = 10;
            bool a = venc.Init();
 
            int audioChannels = 1;
            int audioSampleFreq = 44100;
            int audioBitrate = 128000;
            int audioBitsPerSample = 16;
 
            aenc = new AACEncoder();
            aenc.InputBitsPerSample = audioBitsPerSample;
            aenc.OutputBitrate = audioBitrate;
            aenc.InputChannels = audioChannels;
            aenc.InputSampleFrequency = audioSampleFreq;
 
            a= aenc.Init();
 
         
 
            win = new WaveInput();
            win.BitsPerSample = audioBitsPerSample;
            win.Channels = audioChannels;
            win.SampleRate = audioSampleFreq;
 
            win.OpenDevice();
            win.Start();
 
           
 
            writer = new MP4Writer();
            writer.Filename = Filename;
            string fname = writer.Filename;
 
            vtrack = new TrackInfo();
            vtrack.TrackCategory = TrackCategories.VIDEO;
            vtrack.TrackType = TrackTypes.H264;
            vtrack.Video = new VideoTrack();
            vtrack.Video.Framerate = FPS;
            vtrack.Video.Width = _upscaledBounds.Width;
            vtrack.Video.Height = _upscaledBounds.Height;
 
            vtrack = writer.AddTrack(vtrack);
 
            atrack = new TrackInfo();
            atrack.TrackCategory = TrackCategories.AUDIO;
            atrack.TrackType = TrackTypes.AAC;
            atrack.Audio = new AudioTrack();
            atrack.Audio.Bitrate = 0;
            atrack.Audio.BitsPerSample = audioBitsPerSample;
            atrack.Audio.SampleFrequency = audioSampleFreq;
            atrack.Audio.BitsPerSample = audioBitsPerSample;
            atrack.Audio.Channels = audioChannels;
 
            atrack = writer.AddTrack(atrack);
            writer.CompatibilityMode = true;
            a = writer.Init();
            
 
            win.ClearBuffers();

        }

        private void upscaleBounds()
        {
            Size[] supportedSizes = new Size[] { new Size(320, 240), new Size(640, 480), new Size(800, 600), new Size(1024, 768), new Size(1280, 1024), new Size(1600, 1200), new Size(1920, 1440) };

            foreach (Size s in supportedSizes)
            {
                Rectangle r = new Rectangle(Bounds.Location, s);
                if(r.Contains(Bounds))
                {
                    _upscaledBounds = r;
                    break;
                }
            }
            
        }


        private delegate byte[] convertOnMain(Bitmap bitmap);

        private byte[] ConvertImageToByteArray(System.Drawing.Bitmap bitmap)
        {
            //Code excerpted from Microsoft Robotics Studio v1.5
            BitmapData raw = null;  //used to get attributes of the image
            byte[] rawImage = null; //the image as a byte[]

            try
            {
                
                //Freeze the image in memory
                lock (bitmap)
                {
                    raw = bitmap.LockBits(
                        new Rectangle(0, 0, (int)bitmap.Width, (int)bitmap.Height),
                        ImageLockMode.ReadWrite,
                        bitmap.PixelFormat
                    );

                    int size = raw.Height * Math.Abs(raw.Stride);
                    rawImage = new byte[size];
                    


                    //Copy the image into the byte[]
                    System.Runtime.InteropServices.Marshal.Copy(raw.Scan0, rawImage, 0, size);
                }
            }
            finally
            {
                if (raw != null)
                {
                    //Unfreeze the memory for the image
                    bitmap.UnlockBits(raw);
                }
            }
            return rawImage;
        }
    }
}
