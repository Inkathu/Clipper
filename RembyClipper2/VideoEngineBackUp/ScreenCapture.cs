using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreamCoders;
using System.Drawing;
using StreamCoders.Encoder;
using StreamCoders.Wave;
using StreamCoders.Writer;
using System.Drawing.Imaging;
using System.Windows.Forms;
using RembyClipper.Helpers;
using System.ComponentModel;
using System.Runtime.InteropServices;
using RembyClipper2.Config;
using RembyClipper2.Helpers;

namespace RembyClipper.VideoEngine
{
    public class ScreenCapture : IDisposable
    {
        public string Filename { get; set; }
        public int FPS { get; set; }
        public bool IsRunning { get; private set; }

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

        H264Encoder venc;
        MP3Encoder aenc;
        WaveInput win;
        AVIWriter writer;
        TrackInfo vtrack;
        TrackInfo atrack;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        ~ScreenCapture()
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
                GC.Collect();
            }
            // do unmanaged cleanup here,
            // using P/Invokes as necessary
        }

        bool _cancel = false;

        public void Stop()
        {
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
                    int deltaError = delta - (int)frameduration;
                    startTicker = System.Environment.TickCount - deltaError;
                    int absDelta = System.Environment.TickCount - absoluteTicker;

                    System.Drawing.Bitmap X = (Bitmap)GrabScreen.Snap(this.Bounds, true);

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
                    if (muteMic)
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
                            bool writeres = writer.WriteTrack(atrack, mp, false);
                            if (writeres == false)
                            {
                                
                            }
                            mp.Dispose();

                        }
                        else
                            break;
                    }
                }

            }


            writer.EndTrack(vtrack);
            writer.EndTrack(atrack);
            
            writer.Dispose();


            if (RecordingFinished != null)
                RecordingFinished();

            DebugHelper.Log("Video thread killed");
            snap.Abort();
        }

        private delegate int encodeVideoDelegate(int v, Bitmap b);



        private int EncodeVideo(int videoEncoded, Bitmap bitmap)
        {
            BitmapData raw = null;  //used to get attributes of the image
            byte[] rawImage = null; //the image as a byte[]

            try
            {
                GC.Collect();
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
                GC.Collect();
                byte[] cpic = venc.EncodeToArray(rawImage);
                MediaPackage mp = new MediaPackage();
                mp.Buffer = cpic;
                bool writeres = writer.WriteTrack(vtrack, mp, venc.LastEncodedFrameType == FrameTypes.I_FRAME ? true : false);
                if (writeres == false)
                {

                }
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

        private System.Drawing.Bitmap Snap()
        {
            System.Drawing.Bitmap X = new System.Drawing.Bitmap(_Bounds.Width, _Bounds.Height, PixelFormat.Format24bppRgb);
            using (System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(X))
            {
                G.CopyFromScreen(_Bounds.Location, new System.Drawing.Point(), _Bounds.Size);
                Point p = new Point(Cursor.Position.X - _Bounds.Location.X, Cursor.Position.Y - _Bounds.Location.Y);
                System.Drawing.Rectangle CurBounds = new System.Drawing.Rectangle(p, System.Windows.Forms.Cursor.Current.Size);
                Cursors.Default.Draw(G, CurBounds);

            }
            return X;
        }

        private void Init()
        {
            _cancel = false;
            IsRunning = false;

            venc = new H264Encoder();
            venc.SetInputResolution((uint)Bounds.Width, (uint)Bounds.Height);
            venc.Framerate = FPS;
            venc.IFrameFrequency = 10;
            //venc.Profile = H264Profile.HIGH444;
            //venc.Speed = H264Speed.HIGH_SPEED;
            venc.Init();



            aenc = new MP3Encoder();
            aenc.InputBitsPerSample = audioBitsPerSample;
            aenc.BitrateMode = BitrateModes.CONSTANT_BITRATE;
            aenc.OutputBitrate = audioBitrate;
            aenc.InputChannels = audioChannels;
            aenc.InputSampleFrequency = audioSampleFreq;
            aenc.AdvancedNoiseShaping = false;
            aenc.LowPassFilter = false;
            aenc.MPEG1Upsample = true;
            aenc.StereoMode = StereoModes.MONO;
            aenc.Init();

            win = new WaveInput();
            win.BitsPerSample = audioBitsPerSample;
            win.Channels = audioChannels;
            win.SampleRate = audioSampleFreq;

            win.OpenDevice();
            win.Start();


            writer = new AVIWriter();
            writer.Filename = Filename;
            string fname = writer.Filename;
            writer.Init();

            

            vtrack = new TrackInfo();
            vtrack.TrackCategory = TrackCategories.VIDEO;
            vtrack.TrackType = TrackTypes.H264;
            vtrack.Video = new VideoTrack();
            vtrack.Video.Framerate = FPS;
            vtrack.Video.Width = Bounds.Width;
            vtrack.Video.Height = Bounds.Height;


            vtrack = writer.AddTrack(vtrack);
            
            //writer.WriteTrack(vtrack, venc.GetDecoderConfigurationInfo());

            atrack = new TrackInfo();
            atrack.TrackCategory = TrackCategories.AUDIO;
            atrack.TrackType = TrackTypes.MP3;
            atrack.Audio = new AudioTrack();
            atrack.Audio.Bitrate = audioBitrate;
            atrack.Audio.BitsPerSample = audioBitsPerSample;
            atrack.Audio.SampleFrequency = audioSampleFreq;
            atrack.Audio.BitsPerSample = audioBitsPerSample;
            atrack.Audio.Channels = audioChannels;

            atrack = writer.AddTrack(atrack);
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
