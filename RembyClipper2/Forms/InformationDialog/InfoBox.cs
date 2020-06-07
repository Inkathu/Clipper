using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Forms.InformationDialog
{
    [Flags]
    public enum AnimateWindowFlags
    {
        AW_HOR_POSITIVE = 0x00000001,
        AW_HOR_NEGATIVE = 0x00000002,
        AW_VER_POSITIVE = 0x00000004,
        AW_VER_NEGATIVE = 0x00000008,
        AW_CENTER = 0x00000010,
        AW_HIDE = 0x00010000,
        AW_ACTIVATE = 0x00020000,
        AW_SLIDE = 0x00040000,
        AW_BLEND = 0x00080000
    }
    public partial class InfoBox : Form
    {
        [DllImport("user32.dll")]
        static  extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);


        public static AnimateWindowFlags ShowAnimation { get; set; }
        public static AnimateWindowFlags HideAnimation { get; set; }

        protected event EventHandler WindowHiding;

        public override string Text
        {
            get { return base.Text; }
            set 
            {
                base.Text = value;
                captionLabel.Text = value;
            }
        }
        private readonly Timer _boxTimer;
        private int _shownTime = 0;

        public InfoBox()
        {
            InitializeComponent();
            _boxTimer = new Timer();
            _boxTimer.Tick += new EventHandler(BoxTimerTick);
            _boxTimer.Interval = 1000;
            VisibleChanged += new EventHandler(InfoBox_VisibleChanged);
            ShowAnimation = AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_ACTIVATE;
            HideAnimation = AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE;

        }

        void InfoBox_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible == true)
            {
                this.Refresh();
            }
        }

        private void CrossButtonClick(object sender, EventArgs e)
        {
            _boxTimer.Stop();
            countDownLabel.Visible = false;
            Hide(true);
        }


        internal void SetRegion()
        {
            int r = 10;
            int w = Width;
            int h = Height;
            var clipPath = new GraphicsPath();
            clipPath.StartFigure();
            clipPath.AddArc(-1, -1, r, r, 180, 90);
            clipPath.AddLine(r, -1, w - r, -1);
            clipPath.AddArc(w - r, -1, r, r, 270, 90);
            clipPath.AddLine(w, r, w, h - r);
            clipPath.AddArc(w - r, h - r, r, r, 0, 90);
            clipPath.AddLine(w - r, h, r, h);

            clipPath.AddArc(-1, h - r, r, r, 90, 90);
            clipPath.CloseFigure();
            Region = new Region(clipPath);
        }
        
        public void Show(string caption, int seconds = 0, bool showCountDown = false, bool animated = true)
        {
            SetRegion();
            Invalidate();
            if(animated)
            {
                AnimateWindow(this.Handle, 100, ShowAnimation);
            }
            //BoxTimer.Interval = seconds;
            _shownTime = seconds * 1000;
            Text = caption;
            if(seconds > 0 )
            {
                if (showCountDown)
                {
                    countDownLabel.Text = seconds.ToString();
                    countDownLabel.Tag = seconds;
                    countDownLabel.Visible = true;
                }

                _boxTimer.Start();
                
            }

            Show();
        }
        private void BoxTimerTick(object sender, EventArgs e)
        {
            _shownTime -= 1000;
            if (countDownLabel.Visible)
            {
                int i = (int)countDownLabel.Tag;
                countDownLabel.Text = (--i).ToString();
                countDownLabel.Tag = i;
            }
            if (_shownTime <= 0)
            {
                if (!IsDisposed)
                {
                    _shownTime = 0;
                    Hide(true);

                    _boxTimer.Stop();
                    countDownLabel.Visible = false;
                    if(WindowHiding != null)
                    {
                        WindowHiding(this, EventArgs.Empty);
                    }
                }

            }
        }

        public void Hide(bool animated)
        {
            AnimateWindow(this.Handle, 100, HideAnimation);
            Hide();
        }

        private int startDragX = 0;
        private int startDragY = 0;

        protected void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                //do only when left mouse button is pressed
                int dx = Cursor.Position.X - startDragX;
                int dy = Cursor.Position.Y - startDragY;
                startDragX = Cursor.Position.X;
                startDragY = Cursor.Position.Y;
                Left += dx;
                Top += dy;
            }

        }

        protected void Window_MouseDown(object sender, MouseEventArgs e)
        {
            startDragX = Cursor.Position.X;
            startDragY = Cursor.Position.Y;
            StopTimer();
        }

        protected void StopTimer()
        {
            countDownLabel.Visible = false;
            _boxTimer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            
            grayPanel1.Invalidate();
            ResumeLayout();
            SetRegion();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            //grayPanel2.Width = panel1.Width;
        }

    }
}
