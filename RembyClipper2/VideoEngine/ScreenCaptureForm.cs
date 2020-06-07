using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper.VideoEngine;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper2.Properties;
using RembyClipper2.VideoEngine;
using Timer = System.Timers.Timer;

namespace RembyClipper.Forms
{
    public partial class ScreenCaptureForm : CaptureForm
    {
        public static double LastVideoTotalSeconds;
        private readonly CameraControl cc = new CameraControl();
        private readonly ScreenCapture2 sc = new ScreenCapture2();
        

        private readonly Timer _tsMouse = new Timer();
        private readonly W32Api _w32 = new W32Api();
        internal int SecondLimit = int.MaxValue; // second limit
        private Cursor _current;
        private int _mX = -1;
        private int _mY = -1;
        private int _vX = -1;
        private int _vY = -1;
        private int _wX = -1;
        private int _wY = -1;
//        private bool bgFilled;
        private bool _drawBorder;
        private bool _finished;
        private bool _isFormTransparent;
        private int _p321 = 3;
        private bool _started;
        private bool _stopped;
        private bool _closingByStopButton;

        public ScreenCaptureForm(Image img) : base(img)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                //this.TransparencyKey = Color.FromArgb(237, 85, 00);
                sc.FPS = AppConfig.GetInstance().VideoFPS;
                sc.Filename = RandomString(8, true) + ".mp4";
                sc.SaveFirstFrame = true;
                sc.RecordingFinished += ScreenCaptureHelper_RecordingFinished;
                videoRecorder1.OnOrangeClicked += videoRecorder1_OnOrangeClicked;
                videoRecorder1.OnBlackClicked += videoRecorder1_OnBlackClicked;
                videoRecorder1.OnMuteClicked += videoRecorder1_OnMuteClicked;
                videoRecorder1.OnWebcamClicked += videoRecorder1_OnWebcamClicked;
                //webcamSurface1.OnCloseClicked += new CustomButtonClicked(webcamSurface1_OnCloseClicked);
                webcamSurface1.OnMove += webcamSurface1_OnMove;
                FormClosed += ScreenCaptureForm_FormClosed;

                //this.SetTopLevel(true);
                sc.cc = cc;
                //ScreenCaptureForm_Paint(null, null);
#if DEBUG
                TopMost = false;
#else
                this.TopMost = true;
#endif
                Fixed43 = false;
                _tsMouse.Enabled = false;
                _tsMouse.Interval = 100;
                _tsMouse.Elapsed += tsMouse_Tick;

                grayBG = false;
                MinimumCaptureSize = new Size(320, 240);

                videoRecorder1.MouseDown += barControl1_MouseDown;
                videoRecorder1.MouseMove += barControl1_MouseMove;
                videoRecorder1.MouseUp += barControl1_MouseUp;

//                barControl1.MouseDown += new MouseEventHandler(barControl1_MouseDown);
//                barControl1.MouseMove += new MouseEventHandler(barControl1_MouseMove);
//                barControl1.MouseUp   += new MouseEventHandler(barControl1_MouseUp);
                this.AcceptButton = videoRecorder1.startStopButton;
                this.CancelButton = videoRecorder1.cancelButton;
            }
        }

        public string FileName { get; private set; }

        private void webcamSurface1_OnMove()
        {
            //bgFilled = false;
            //Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_drawBorder)
            {
//                if (!bgFilled)
//                {
//                    e.Graphics.FillRectangle(new SolidBrush(this.TransparencyKey), this.Bounds);
//                    bgFilled = true;
//                }
                e.Graphics.DrawRectangle(new Pen(Color.Red, 2),
                                         new Rectangle(CaptureRect.X - 2, CaptureRect.Y - 2, CaptureRect.Width + 3,
                                                       CaptureRect.Height + 2));
            }
        }

        private void tsMouse_Tick(object sender, EventArgs e)
        {
            var checkControls = new Control[] {webcamSurface1, videoRecorder1}; //, this.barControl1 };
            bool found = checkControls.Any(c => c.Bounds.Contains(Cursor.Position));
            this.Invoke(() =>
                            {
                                if (_isFormTransparent && found)
                                {
                                    _w32.SetFormNormal(Handle);
                                    _isFormTransparent = false;
                                    return;
                                }

                                if (!_isFormTransparent && !found)
                                {
                                    _w32.SetFormTransparent(Handle);
                                    _isFormTransparent = true;
                                    return;
                                }
                                
                            });
        }


        private void ScreenCaptureForm_MouseDown(object sender, MouseEventArgs e)
        {
        }


        private void videoRecorder1_OnMuteClicked()
        {
            //sc.MuteMic = !sc.MuteMic;
        }

        private void ScreenCaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sc.Dispose();
            foreach (object c in Controls)
                if (c is IDisposable)
                    ((IDisposable) c).Dispose();
        }

        private void videoRecorder1_OnBlackClicked()
        {
            cc.StopCam();
            Close();
        }

        private void videoRecorder1_OnOrangeClicked()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint, false);
            SetStyle(ControlStyles.UserPaint, true);


            TransparencyKey = Color.FromArgb(237, 85, 00);
            BackgroundImage = null;
            BackColor = Color.FromArgb(237, 85, 00);


            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_stopped)
                return;
            if (!_started)
            {
                _drawBorder = true;
                int X = CaptureRect.Left + CaptureRect.Width/2 - (pictureBox321.Size.Width/2);
                int Y = CaptureRect.Top + CaptureRect.Height/2 - (pictureBox321.Size.Height/2);
                pictureBox321.Location = new Point(X, Y);
                pictureBox321.BringToFront();
                pictureBox321.Visible = true;
                timer2.Enabled = true;
                Invalidate();
                return;
            }
            else
            {
                _closingByStopButton = true;
                _drawBorder = false;
                _w32.SetFormNormal(Handle);
                _tsMouse.Enabled = false;
                sc.Stop();
                _stopped = true;
            }
        }


        private void ScreenCaptureForm_Load(object sender, EventArgs e)
        {
            timerTicker = new Timer();
            timerTicker.Enabled = false;
            timerTicker.Interval = 100;
            timerTicker.Elapsed += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now.Subtract(sc.StartedAt);
            if (_stopped == false)
                videoRecorder1.Duration = ts.Minutes + ":" + ts.Seconds + "." + ts.Milliseconds;

            LastVideoTotalSeconds = ts.TotalSeconds;

            if (ts.TotalSeconds >= SecondLimit && _stopped == false)
            {
                sc.Stop();
                _stopped = true;
            }
            if (_finished)
            {
                cc.StopCam();
                cc.Dispose();

                timerTicker.Enabled = false;
                FileName = sc.Filename;
                GetSource(true);
                this.Invoke(Close);
                
            }
        }

        internal static string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private void StartRecording()
        {
            videoRecorder1.Location = new Point(CaptureRect.Left, CaptureRect.Bottom);

            var s = new Size(CaptureRect.Width, videoRecorder1.Size.Height);
            if (s.Width < videoRecorder1.Size.Width)
            {
                s.Width = videoRecorder1.Size.Width;
            }
            videoRecorder1.Size = s;

            _w32.SetFormTransparent(Handle);
            _isFormTransparent = true;
            _tsMouse.Enabled = true;

            timerTicker.Enabled = true;

            sc.Bounds = CaptureRect;
            sc.FPS = 15;
            sc.Filename = RandomString(8, true) + ".mp4";
            //videoRecorder1.buttonMute1.sc = sc;

            DebugHelper.Log("Starting to record:");
            DebugHelper.PropertyDump(CaptureRect);
            sc.Capture();


            return;
        }

        private void ScreenCaptureHelper_RecordingFinished()
        {
            _finished = true;
        }

        protected override void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (areaSelected)
                return;
            if (MinimumCaptureSize != null)
            {
//&& this.captureRect.Width < this.MinimumCaptureSize.Width && this.captureRect.Height < this.MinimumCaptureSize.Height)
                var r = new Rectangle(CaptureRect.Location, MinimumCaptureSize);
                if (!CaptureRect.Contains(r))
                {
                    mouseDown = false;
                    return;
                }
            }
            if (mouseDown)
            {
                mouseDown = false;
                cursorPos.X = 0;
                cursorPos.Y = 0;

                //this.Location = new Point(CaptureRect.X, CaptureRect.Y);
                //this.Size = new System.Drawing.Size(CaptureRect.Width, CaptureRect.Height + videoRecorder1.Height);

                videoRecorder1.BoundSize = CaptureRect.Width + "x" + CaptureRect.Height + "px";
//                this.videoRecorder1.Location = new Point(this.CaptureRect.Left, this.CaptureRect.Bottom);
                //this.videoRecorder1.Location = new Point(0, this.CaptureRect.Bottom);
//                
//                this.videoRecorder1.Size = new Size(this.CaptureRect.Width, this.videoRecorder1.Size.Height);
//                this.videoRecorder1.Visible = true;

//                this.barControl1.Location = new Point(this.CaptureRect.Left - 2, this.CaptureRect.Top - this.barControl1.Height - 1);
//                this.barControl1.Size = new Size(this.CaptureRect.Width + 4, this.barControl1.Size.Height);
//                this.barControl1.Visible = true;

                videoRecorder1.Location = new Point(CaptureRect.Left, CaptureRect.Bottom /*- this.barControl1.Height */);
                var s = new Size(CaptureRect.Width, barControl1.Size.Height);
                if (s.Width < videoRecorder1.Size.Width)
                {
                    s.Width = videoRecorder1.Size.Width;
                }
                videoRecorder1.Size = s;
                videoRecorder1.Visible = true;
                base.hideCrosshairs = true;

                areaSelected = true;
                StartWebcam();


                Invalidate();
            }
        }

        private void StartWebcam()
        {
            webcamSurface1.CaptureRect = CaptureRect;
            webcamSurface1.Location = new Point(CaptureRect.X + 5, CaptureRect.Y + 5);
            webcamSurface1.Visible = true;
            webcamSurface1.ShowLoading();

            if (cc.InitCam(webcamSurface1))
            {
//                using (Graphics g = this.CreateGraphics())
//                    g.FillRectangle(new SolidBrush(this.TransparencyKey), this.CaptureRect);
            }
            else
            {
                DebugHelper.Log("Webcam not started");
                webcamSurface1.HideLoading();
                webcamSurface1.Visible = false;
            }
        }

        private void StopWebcam()
        {
            webcamSurface1.Visible = false;
            cc.StopCam();
            cc.Dispose();
            //bgFilled = false;
            //Invalidate();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox321.BringToFront();
            if (_p321 == 3)
            {
                pictureBox321.Image = Resources.C2;
                _p321 = 2;
                return;
            }
            if (_p321 == 2)
            {
                pictureBox321.Image = Resources.C1;
                _p321 = 1;
                return;
            }
            if (_p321 == 1)
            {
                timer2.Enabled = false;
                pictureBox321.Visible = false;
                StartRecording();
                _started = true;
            }
            Invalidate();
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

        private void videoRecorder1_OnWebcamClicked()
        {
            if (webcamSurface1.Visible)
            {
                StopWebcam();
            }
            else
            {
                StartWebcam();
            }
        }

        private void webcamSurface1_OnCloseClicked()
        {
            //videoRecorder1_OnWebcamClicked();
            videoRecorder1.WebCamStateChange();
        }

        private void ScreenCaptureForm_Paint(object sender, PaintEventArgs e)
        {
            /*if (Region == null)
                Region = new Region(GetScreenBounds());
            if (CaptureRect != null)
                Region.Exclude(CaptureRect);*/
        }

        private void barControl1_MouseUp(object sender, MouseEventArgs e)
        {
            _mX = -1;
            _mY = -1;
            Cursor.Current = _current;
        }

        private void barControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mX != -1 && _mY != -1)
            {
                bool moveVideoRecorded = false;
//                if (videoRecorder1.Location.X - CaptureRect.Left < 5 && videoRecorder1.Location.Y - CaptureRect.Bottom < 5)
//                    moveVideoRecorded = true;

                //barControl1.Location = new Point(Cursor.Position.X - _mX, Cursor.Position.Y - _mY);
                videoRecorder1.Location = new Point(Cursor.Position.X - _mX, Cursor.Position.Y - _mY);
                //CaptureRect = new Rectangle(videoRecorder1.Location.X+2, videoRecorder1.Location.Y - CaptureRect.Height, CaptureRect.Width, CaptureRect.Height);
                CaptureRect = new Rectangle(videoRecorder1.Location.X + 2,
                                            videoRecorder1.Location.Y - CaptureRect.Height,
                                            CaptureRect.Width,
                                            CaptureRect.Height);
//                CaptureRect = new Rectangle(barControl1.Location.X + 2, barControl1.Location.Y + barControl1.Height, CaptureRect.Width, CaptureRect.Height);

                webcamSurface1.Location = new Point(CaptureRect.X + _wX, CaptureRect.Y + _wY);
                webcamSurface1.CaptureRect = CaptureRect;

                if (moveVideoRecorded)
                    videoRecorder1.Location = new Point(CaptureRect.Left - 2, CaptureRect.Bottom + 2);

                //bgFilled = false;

//                using (Graphics g = this.CreateGraphics())
//                {
//                    g.FillRectangle(new SolidBrush(this.TransparencyKey), this.Bounds);
//                }
                sc.Bounds = CaptureRect;
                Invalidate();
            }
        }

        //Rectangle originalCaptureRect;
        private void barControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_tsMouse.Enabled)
                return;

            _mX = e.X;
            _mY = e.Y;
            _wX = webcamSurface1.Location.X - CaptureRect.X;
            _wY = webcamSurface1.Location.Y - CaptureRect.Y;
            _current = Cursor.Current;
            Cursor.Current = Cursors.SizeAll;
        }


        private void videoRecorder1_MouseUp(object sender, MouseEventArgs e)
        {
            _vX = -1;
            _vY = -1;
            Cursor.Current = _current;
        }

        private void videoRecorder1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_vX != -1 && _vY != -1)
            {
                videoRecorder1.Location = new Point(Cursor.Position.X - _vX, Cursor.Position.Y - _vY);
//                using (Graphics g = this.CreateGraphics())
//                {
//                    g.FillRectangle(new SolidBrush(this.TransparencyKey), this.Bounds);
//                }
            }
        }

        private void videoRecorder1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_tsMouse.Enabled)
                return;

            _vX = e.X;
            _vY = e.Y;
            _current = Cursor.Current;
            Cursor.Current = Cursors.SizeAll;
        }


        protected void SetRegion()
        {
            pictureBox321.Region =
                Region.FromHrgn(CreateRoundRectRgn(pictureBox321.Left, pictureBox321.Top, pictureBox321.Width,
                                                   pictureBox321.Height, 5, 5));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
            );

        private void ScreenCaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sc.IsRunning && !_closingByStopButton)
            {
                sc.Stop();
                if (timer1.Enabled)
                {
                    timer1.Stop();
                }
                if (timer2.Enabled)
                {
                    timer2.Stop();
                }
                if (timerStart.Enabled)
                {
                    timerStart.Stop();
                }
                if (timerTicker.Enabled)
                {
                    timerTicker.Stop();
                }
                if (_tsMouse.Enabled)
                {
                    _tsMouse.Stop();
                }
                if (cc.State == CameraControl.CamState.On)
                {
                    cc.StopCam();
                }
            }

        }

        private void pictureBox321_Click(object sender, EventArgs e)
        {
        }

        #region Nested type: threadSyncDelegate

        private delegate void threadSyncDelegate();

        #endregion

        private void ScreenCaptureForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                videoRecorder1.cancelButton.PerformClick();
                Close();
            }
        }
    }
}