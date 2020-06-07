#define endDecidedByAudio
#define LogCPU
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
//using RembyClipper2.Player;
using RembyClipper.Forms;

/*
 * This is a very simple GDI Media Player able to read AVI and MP4 files.
 * Supported File Containers: AVI, DIVX, MP4 and FLV
 * Supported Video Codecs: H.263, MPEG4.2 and MPEG4.10/AVC/H.264   
 * Supported Audio Codecs: AAC, AC3 and MP3
 * 
 * Features:
 *  Seeking, AV Sync
 * 
 */

namespace FilePlayer
{
    [SmartAssembly.Attributes.DoNotObfuscateControlFlow]
    [SmartAssembly.Attributes.DoNotObfuscate]
    public partial class PlayerForm : Form
    {
        private double audioBase;
        private int audioBufferThreshold;
        private AudioDecoderBase audioDecoder;
        private Thread audioThread;
        private uint audioTrack;
        //private bool closeApplication;
        private Bitmap dImage;
        private Rectangle dImageRect;
        private Mutex displayMutex;
        private bool isRunning;
        //private bool isURL;
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
        private bool paused = false;


        public String filename;
        public Control Surface;
        public Form parent;
        public RembyClipper2.Base.ExtendedProgressBar progressBar;
        public Label progressLabel;

        private double _progress = 0;
        public double Progress { get { return _progress; } set { _progress = value; setProgress(); } }
        public double Length { get { return trackBar1.Maximum; } }

        public enum VideoState { Playing, Paused, Stopped };
        public VideoState PlayerState { get; private set; }

        public delegate void endReachedDelegate();
        public event endReachedDelegate endReached;

        public delegate void videoErrorDelegate(string text);
        public event videoErrorDelegate onVideoError;

        public PlayerForm()
        {
            InitializeComponent();


            isRunning = false;
            openFileDialog1.Filter = "AVI/MP4/FLV/DIVX Files|*.avi;*.mp4;*.3gp;*.3g2;*.flv;*.f4v;*.divx;*.mov";
            //closeApplication = false;
            //isURL = false;
            PlayerState = VideoState.Stopped;
        }

        private void setProgress()
        {
            if (isRunning == false)
            {
                return;
            }
            lock (reader)
            {
                bool selfStopped = false;
                if(PlayerState == VideoState.Playing)
                {
                    selfStopped = true;
                    Pause();
                }
                reader.Position = _progress;

                if(selfStopped)
                {
                    Start();
                }
            }
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

        // Opens file, reads codec informations and initializes decoders
        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }

        public void Start()
        {

            progressBar.Value = 0;
            Thread startThread = new Thread(StartTS);
            startThread.Name = "StartThread";
            startThread.Start();
        }

        private void StartTS()
        {
            DebugHelper.AddKnownThreadIDs(Thread.CurrentThread.ManagedThreadId, "StartThread");

            if (paused)
            {
                paused = false;
                return;
            }
            if (isRunning)
            {
                Stop();
            }



            String extension;
            int pos = filename.LastIndexOf(".");
            extension = filename.Substring(pos + 1).ToUpper();


            if (extension == "AVI" || extension == "DIVX")
            {
                //reader = new AVIReaderWrapper();
            }
            else if (extension == "MP4")
            {
                reader = new MP4Reader();
            }
            else if (extension == "FLV"){
               // reader = new FLVReader();
            }
            else
            {
                MessageBox.Show("File Extension not supported");
                return;
            }

            DebugHelper.GetLoadedModules();

            reader.FileName = filename;
            bool initRes = reader.Init();
            if (initRes == false)
            {
                FileInfo fi = new FileInfo(filename);
                DebugHelper.PropertyDump(fi);

                if(onVideoError!=null)
                    onVideoError(string.Format("Unable to load {0}", reader.FileName));

                MessageBox.Show("Avi reader failed to init.");

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

                    //if (ti.TrackType == TrackTypes.MP3) audioDecoder = new MP3Decoder();
                    if (ti.TrackType == TrackTypes.AAC) audioDecoder = new AACDecoder();

                    if (audioDecoder == null)
                    {
                        MessageBox.Show(string.Format("No fitting audio decoder initialized. ({0})", ti.TrackType));
                        continue;
                    }

                    audioDecoder.BitsPerSample = ti.Audio.BitsPerSample;
                    audioDecoder.Channels = ti.Audio.Channels;
                    audioDecoder.SampleRate = ti.Audio.SampleFrequency;
                    bool audioInitResult = false;

                    /*if (ti.TrackType == TrackTypes.MP3 && ti.Audio.DecoderData != null)
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
                    else*/ audioInitResult = audioDecoder.Init();

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

                    trackBar1.Maximum = (int)Math.Floor(ti.Audio.Duration);
                   

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
                    if (ti.TrackType == TrackTypes.MPEG4V) videoDecoder = new MPEG4Decoder();

                    if (extension == "MP4" || extension == "MOV" || extension == "3GP") videoDecoder.VideoSource = StreamSources.FILE_MP4;
                    if (extension == "FLV" || extension == "F4V") videoDecoder.VideoSource = StreamSources.FILE_FLV;


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

            if (trackBar1.Maximum == 0)
                trackBar1.Maximum = (int)Math.Floor(reader.GetTrack(videoTrack).Video.Duration);

            if (trackBar1.Maximum == 0)
                trackBar1.Maximum = (int)Math.Floor(ScreenCaptureForm.LastVideoTotalSeconds); //If all hope fails then load time from recorder.

            Text = openFileDialog1.FileName;
            if (videoDecoder != null)
                Text += " - " + videoCodecString + "/" + videoDecoder.InputWidth + "x" + videoDecoder.InputHeight + "@" +
                        videoDecoder.InputFramerate.ToString("F");
            if (audioDecoder != null) Text += " " + audioCodecString + "/" + audioDecoder.BitsPerSample + "x" + audioDecoder.Channels + "@" + audioDecoder.SampleRate;

            dImage = new Bitmap(videoDecoder.InputWidth, videoDecoder.InputHeight, PixelFormat.Format24bppRgb);
            dImageRect = new Rectangle(0, 0, videoDecoder.InputWidth, videoDecoder.InputHeight);
            if (Surface == null)
            {
                pictureGraphics = panel1.CreateGraphics();
                Surface = panel1;
            }
            else
                pictureGraphics = Surface.CreateGraphics();

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

            PlayerState = VideoState.Playing;
        }

        // Reads Video track and buffers the decoded frames in "videoFrames" list. SyncThread will do the rest.
        private void VideoStart()
        {
            //DebugHelper.Log("Video thread ID: " + AppDomain.GetCurrentThreadId());
            DebugHelper.AddKnownThreadIDs(Thread.CurrentThread.ManagedThreadId, "VideoThread");
            bool firstRun = true;
            bool lastDecodeResult = true;
            while (isRunning)
            {
                while (paused)
                    Thread.Sleep(50);

                videoSemaphore.WaitOne();
                ThisThread.Sleep(0);
                MediaPackage mp = null;
                bool pending = reader.GetTrackStatus(videoTrack) != TrackStatus.TRACK_STREAM_END;
                uint undecoded = videoDecoder.GetUnDecodedBytes();
                pending &= undecoded <= 4 || lastDecodeResult == false;

#if endDecidedByVideo
                if (reader.GetTrackStatus(videoTrack) == TrackStatus.TRACK_STREAM_END)
                {
                    this.Stop();
                    if (endReached != null)
                        endReached();

                    return;
                }
#endif

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

        // Reads Audio Track and writes them directly to the audio device
        private void AudioStart()
        {
            DebugHelper.AddKnownThreadIDs(Thread.CurrentThread.ManagedThreadId, "AudioThread");
            MediaPackage mp = null;
            bool firstRun = true;
            while (isRunning)
            {
                while (paused)
                    Thread.Sleep(50);

                lock (waveout)
                {
                    waveout.UnprepareBuffers();
                }
                if (waveout.QueuedBytes > audioBufferThreshold)
                {
                    ThisThread.Sleep(5);
                    continue;
                }

#if endDecidedByAudio
                if (reader.GetTrackStatus(audioTrack) == TrackStatus.TRACK_STREAM_END)
                {
                    this.Stop();
                    if (endReached != null)
                        endReached();

                    return;
                }
#endif


                lock (reader)
                {
                    mp = reader.GetNextFrame(audioTrack);
                }

                if (GetAudioClock() > 0 && isRunning)
                {
                    if (parent.IsDisposed)
                    {
                        this.Stop();
                        return;
                    }
                    if (!parent.IsDisposed)
                    {
                        try
                        {
                            parent.Invoke((MethodInvoker)delegate
                                                       {
                                                           //vidLength ... 100
                                                           //curPosition ... x
                                                           _progress = GetAudioClock();
                                                           var progress = (int)Math.Floor(_progress);
                                                           if (progress <= trackBar1.Maximum && progress >= 0 && trackBar1.Maximum != 0) progressBar.Value = 100 * progress / trackBar1.Maximum;
                                                           TimeSpan ts = TimeSpan.FromSeconds(progress);
                                                           progressLabel.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);
                                                       });
                        }
                        catch (Exception exc)
                        {
                            DebugHelper.Log(exc.ToString());
                        }

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
                    GC.Collect();
                }
            }
        }

        public void Pause()
        {
            paused = true;
            PlayerState = VideoState.Paused;
        }

        // Synchronizes audio and video according to their timestamps provided by both decoders and reference clock provided by the audio device.
        private void SyncStart()
        {
            DebugHelper.AddKnownThreadIDs(Thread.CurrentThread.ManagedThreadId, "SyncThread");
            MediaPackage vFrame = null;
            while (isRunning)
            {
                while (paused)
                    Thread.Sleep(50);

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

#if LogCPU
                DebugHelper.LogCPU();
#endif
                GC.Collect();
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
            //dImage.Save(mp.startTime.ToString() + ".png");
            try
            {
                parent.Invoke((MethodInvoker)delegate
                                           {
                                               //if (checkBox1.Checked)
                                               pictureGraphics.DrawImage(dImage, 0, 0, Surface.Width, Surface.Height);
                                               // else
                                               //    pictureGraphics.DrawImageUnscaled(dImage, (Surface.Width - dImage.Width) / 2,
                                               //                                        (Surface.Height - dImage.Height) / 2);
                                           });
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
            }

                mp.Dispose();
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
            PlayerState = VideoState.Stopped;
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

                reader.Dispose();
                if (!parent.IsDisposed)
                {
                    try
                    {
                        parent.Invoke((MethodInvoker)delegate
                        {
                            progressBar.Value = 100;
                        });
                    }
                    catch (Exception exc)
                    {
                        DebugHelper.Log(exc.ToString());
                    }

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (isRunning == false) return;
            lock (reader)
            {
                reader.Position = trackBar1.Value;
            }
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isRunning == false) return;
            lock (reader)
            {
                reader.Position = (double) e.X * trackBar1.Maximum / trackBar1.Width;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (pictureGraphics != null) pictureGraphics.Dispose();
            pictureGraphics = panel1.CreateGraphics();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //isURL = true;
            button1_Click(sender, e);
            //isURL = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Stream stream;
            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            webclient.UseDefaultCredentials = true;
            webclient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1;)");
            try
            {
                stream = webclient.OpenRead(toolStripTextBox2.Text);
            }
            catch (Exception)
            {
                return;
            }

            var reader = new BinaryReader(stream);
            string httpTxt = "";
            var buffer = new byte[1024];
            while (true)
            {
                int read = reader.Read(buffer, 0, 1024);

                if (read == 0) break;

                httpTxt += Encoding.ASCII.GetString(buffer, 0, read);
            }

            if (string.IsNullOrEmpty(httpTxt)) return;
            string par = "watch_fullscreen?";
            int fullscrPos = httpTxt.IndexOf(par);
            if (fullscrPos == -1) return;

            int endQuote = httpTxt.Substring(fullscrPos + par.Length).IndexOf("';");

            if (endQuote == -1) return;

            int startpos = fullscrPos + par.Length;
            string newurl = string.Format("http://www.youtube.com/get_video.php?{0}", httpTxt.Substring(startpos, endQuote + 1));

            toolStripTextBox2.Text = newurl;
            toolStripButton2_Click(sender, e);
        }
    }
}