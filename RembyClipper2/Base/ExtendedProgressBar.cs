using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class ExtendedProgressBar : UserControl
    {
        public event EventHandler progresValueChanged;
        public bool DrawText { get; set; }
        private bool leftButtonPressed = false;
        private bool valueChanged = false;
        private bool moving = false;

        public bool AllowEventFiring { get; set; }

        public ExtendedProgressBar()
        {
            InitializeComponent();
            RoundingRadius = 10;
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            DrawText = true;
            redrawTimer.Interval = 1;
            redrawTimer.Tick += new EventHandler(redrawTimer_Tick);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            {
                GraphicsPath clipPath = new GraphicsPath();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int percents = PercentValue;
                Rectangle rect = new Rectangle(0, 0, percents * ClientRectangle.Width/100, ClientRectangle.Height);
                //draw back color
                using (
                    LinearGradientBrush br = new LinearGradientBrush(ClientRectangle,
                        Color.FromArgb(228, 228, 228),
                        Color.FromArgb(250, 250, 250),
                                                                     LinearGradientMode.Vertical))
                {

                    e.Graphics.FillRectangle(br, ClientRectangle);
                }

                if (rect.Width > 0)
                {
                    //draw progress
                    using (
                        LinearGradientBrush br = new LinearGradientBrush(rect,
                            Color.FromArgb(192,192,192),
                            Color.FromArgb(183,183,183),
                                                                         LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillRectangle(br, rect);
                    }

                }

                int r = RoundingRadius;
                int w = Width;
                int h = Height;
                clipPath.StartFigure();
                clipPath.AddArc(-1, -1, r, r, 180, 90);
                clipPath.AddLine(r, -1, w - r, -1);
                clipPath.AddArc(w - r, -1, r, r, 270, 90);
                clipPath.AddLine(w, r, w, h - r);
                clipPath.AddArc(w - r, h - r, r, r, 0, 90);
                clipPath.AddLine(w - r, h, r, h);
                //            clipPath.AddLine(w, r, w, h - r - 1);
                //            clipPath.AddArc(w - r - 1, h - r - 1, r + 1, r + 1, 0, 90);
                //            clipPath.AddLine(w - r - 1, h, r, h);
                clipPath.AddArc(-1, h - r, r, r, 90, 90);
                clipPath.CloseFigure();

                Region = new Region(clipPath);
                //draw border
                using (Pen p = new Pen(Color.FromArgb(132, 132, 132), 3))
                {
                    //set the rounding

                    e.Graphics.DrawPath(p, clipPath);
                }
                if (DrawText)
                {
                    using (Pen p = new Pen(Color.GhostWhite))
                    {
                        string str = string.Format("{0}%", percents);
                        var measureString = e.Graphics.MeasureString(str, this.Font);
                        int x = (int) ((Width - measureString.Width)/2);
                        int y = (int) ((Height - measureString.Height)/2);
                        e.Graphics.DrawString(str, Font, Brushes.GhostWhite, x, y);
                    }
                }

            }
        }

        protected int RoundingRadius { get; set; }

        public int Value
        {
            get { return _value; }
            set 
            {
                if(value >= MinValue && value <= MaxValue)
                {
                    _value = value;    
                } else if(value < MinValue)
                {
                    _value = MinValue;
                } else if(value > MaxValue)
                {
                    _value = MaxValue;
                }

                Invalidate();
            }
        }
        private int _value = 0;

        public int MinValue 
        { 
            get { return _minValue; }
            set { _minValue = value > MaxValue ? 0 : value; }
        }
        private int _minValue = 0;


        public int MaxValue 
        { 
            get { return _maxValue; }
            set
            {
                _maxValue = value< MinValue ? 100 : value;
                if(_maxValue == 0)
                {
                    _maxValue = 100;
                }
            }
        }
        private int _maxValue = 100;

        public int PercentValue
        {
            get
            {
                return (int)((decimal)_value/_maxValue*100);
            }
            set
            {
                Value = (int)((decimal)value*_maxValue/100);
                Invalidate();
            }
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        private void ExtendedProgressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (!AllowEventFiring) 
            {
                return;
            }
            if(e.Button == MouseButtons.Left)
            {
                leftButtonPressed = true;
                SetCapture(this.Handle);
                Tag = PercentValue;
            }
        }

        private void ExtendedProgressBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (!AllowEventFiring)
            {
                return;
            }
            if(e.Button == MouseButtons.Left)
            {
                leftButtonPressed = false;
                SetCapture(IntPtr.Zero);
                int oldValue = (int) Tag;
                valueChanged = oldValue != PercentValue;
                OnValueChanged();
                
            }

        }

        Timer redrawTimer = new Timer();
        private void TimeredMoving(int moveToPercent)
        {
            redrawTimer.Tag = moveToPercent;
            redrawTimer.Start();
                

        }

        private void ExtendedProgressBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!AllowEventFiring)
            {
                return;
            }
            if (leftButtonPressed)
            {
                moving = true;
                int percent = (int)(((decimal)e.X)/Width*100);
                if(percent > 100)
                {
                    percent = 100;
                } else if (percent < 0)
                {
                    percent = 0;
                }

                PercentValue = percent;
            }
        }

        void redrawTimer_Tick(object sender, EventArgs e)
        {
            int percent = (int)redrawTimer.Tag;
            if(PercentValue < percent)
            {
                PercentValue++;
                valueChanged = true;
            }
            else if(PercentValue > percent)
            {
                PercentValue--;
                valueChanged = true;
            }
            else
            {
                
                redrawTimer.Stop();
                OnValueChanged();
            }
        }
        protected virtual void OnValueChanged()
        {
            if (valueChanged)
            {
                if (progresValueChanged != null)
                {
                    progresValueChanged(this, EventArgs.Empty);
                }
            }

            valueChanged = false;
            moving = false;
        }

        private void ExtendedProgressBar_Click(object sender, EventArgs e)
        {
            if (!AllowEventFiring)
            {
                return;
            }
            if (moving)
            {
                moving = false;
                return;
            }
            int percent = (int)(((decimal)PointToClient(new Point(MousePosition.X, MousePosition.Y)).X) / Width * 100);
            if (percent > 100)
            {
                percent = 100;
            }
            else if (percent < 0)
            {
                percent = 0;
            }

            TimeredMoving(percent);
        }



    }
}
