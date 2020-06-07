using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RembyClipper.Helpers;
using System.Threading;
using RembyClipper.VideoEngine;
using RembyClipper2.Base;
using RembyClipper2.Forms;
using RembyClipper2.Config;
using RembyClipper2.VideoEngine;

namespace RembyClipper.Forms
{
    public partial class ScreenCaptureForm : CaptureForm
    {

        private ScreenCapture sc = new ScreenCapture();
        private CameraControl cc = new CameraControl();


        public string FileName { get; private set; }

        public ScreenCaptureForm()
        {
            InitializeComponent();
            this.TransparencyKey = Color.FromArgb(237, 85, 00);
            sc.FPS = AppConfig.GetInstance().VideoFPS;
            sc.Filename = RandomString(8, true) + ".avi";
            sc.SaveFirstFrame = true;
            sc.RecordingFinished += new ScreenCapture.RecordingFinishedDelegate(ScreenCaptureHelper_RecordingFinished);
            videoRecorder1.OnOrangeClicked += new CustomButtonClicked(videoRecorder1_OnOrangeClicked);
            videoRecorder1.OnBlackClicked += new CustomButtonClicked(videoRecorder1_OnBlackClicked);
            videoRecorder1.OnMuteClicked += new CustomButtonClicked(videoRecorder1_OnMuteClicked);
            videoRecorder1.OnWebcamClicked += new CustomButtonClicked(videoRecorder1_OnWebcamClicked);
            webcamSurface1.OnCloseClicked += new CustomButtonClicked(webcamSurface1_OnCloseClicked);
            this.FormClosed += new FormClosedEventHandler(ScreenCaptureForm_FormClosed);
#if DEBUG
            this.TopMost = false;
#endif
        }

 



        void videoRecorder1_OnMuteClicked()
        {
            sc.MuteMic = !sc.MuteMic;
        }

        void ScreenCaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sc.Dispose();
            foreach (var c in this.Controls)
                if (c is IDisposable)
                    ((IDisposable)c).Dispose();
        }

        void videoRecorder1_OnBlackClicked()
        {
            this.Close();
        }

        void videoRecorder1_OnOrangeClicked()
        {
            button1_Click(null, null);
        }

        internal int SecondLimit = 300; // second limit
        bool started = false;


        private void button1_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                int X = CaptureRect.Left + CaptureRect.Width / 2 - (pictureBox321.Size.Width / 2);
                int Y = CaptureRect.Top + CaptureRect.Height / 2 - (pictureBox321.Size.Height / 2);
                pictureBox321.Location = new Point(X, Y);
                pictureBox321.Visible = true;
                timer2.Enabled = true;
                return;
            }
            else
            {
                sc.Stop();
                stopped = true;
            }
        }


        private void ScreenCaptureForm_Load(object sender, EventArgs e)
        {
            timerTicker = new System.Windows.Forms.Timer();
            timerTicker.Enabled = false;
            timerTicker.Interval = 100;
            timerTicker.Tick += new EventHandler(timer1_Tick);

        }

        bool stopped = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now.Subtract(sc.StartedAt);
            if (stopped == false)
                videoRecorder1.Duration = ts.Minutes + ":" + ts.Seconds + "." + ts.Milliseconds;

            if (ts.TotalSeconds >= SecondLimit && stopped == false)
            {
                sc.Stop();
                stopped = true;
            }
            if (finished)
            {
                cc.StopCam();
                cc.Dispose();

                timerTicker.Enabled = false;
                FileName = sc.Filename;
                GetSource();
                this.Close();
            }

        }

        internal string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private void StartRecording()
        {
           
            timerTicker.Enabled = true;
            
            sc.Bounds = this.CaptureRect;
            sc.FPS = 15;
            sc.Filename = RandomString(8, true) + ".avi";
            sc.Capture();

            return;

        }

        bool finished = false;

        delegate void threadSyncDelegate();

        void ScreenCaptureHelper_RecordingFinished()
        {
            finished = true;
        }

        protected override void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseDown = false;
                cursorPos.X = 0;
                cursorPos.Y = 0;
                this.videoRecorder1.BoundSize = CaptureRect.Width.ToString() + "x" + CaptureRect.Height + "px";
                this.videoRecorder1.Location = new Point(this.CaptureRect.Left, this.CaptureRect.Bottom);
                this.videoRecorder1.Size = new Size(this.CaptureRect.Width, this.videoRecorder1.Size.Height);
                this.videoRecorder1.Visible = true;
                base.hideCrosshairs = true;

                StartWebcam();
            }
        }

        private void StartWebcam()
        {
            this.webcamSurface1.CaptureRect = CaptureRect;
            this.webcamSurface1.Location = new Point(CaptureRect.X + 5, CaptureRect.Y + 5);
            this.webcamSurface1.Visible = true;
            this.webcamSurface1.ShowLoading();

            if (cc.InitCam(webcamSurface1))
            {
                using (Graphics g = this.CreateGraphics())
                    g.FillRectangle(new SolidBrush(this.TransparencyKey), this.CaptureRect);

            }
            else
            {
                DebugHelper.Log("Webcam not started");
                this.webcamSurface1.HideLoading();
                this.webcamSurface1.Visible = false;
            }
        }

        private void StopWebcam()
        {
            this.webcamSurface1.Visible = false;
            cc.StopCam();
            cc.Dispose();
        }


        int p321 = 3;

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (p321 == 3)
            {
                pictureBox321.Image = global::RembyClipper2.Properties.Resources.C2;
                p321 = 2;
                return;
            }
            if (p321 == 2)
            {
                pictureBox321.Image = global::RembyClipper2.Properties.Resources.C1;
                p321 = 1;
                return;
            }
            if (p321 == 1)
            {
                timer2.Enabled = false;
                pictureBox321.Visible = false;
                StartRecording();
                started = true;
                
            }
        }

        private void webcamSurface1_MouseEnter(object sender, EventArgs e)
        {
            webcamSurface1.SetControlsVisible();
            cc.DrawFrame();
        }

        private void webcamSurface1_MouseLeave(object sender, EventArgs e)
        {
            webcamSurface1.SetControlsInVisible();
            cc.DrawFrame();
        }

        void videoRecorder1_OnWebcamClicked()
        {
            if (webcamSurface1.Visible)
                StopWebcam();
            else
                StartWebcam();
        }

        void webcamSurface1_OnCloseClicked()
        {
            videoRecorder1.ClickWebcamButton();
        }

    }
}
