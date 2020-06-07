using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Helpers;
using RembyClipper2.Config;
using System.Runtime.InteropServices;
using RembyClipper2.Utils;

namespace RembyClipper2.Base
{
    public partial class CaptureForm : BaseCaptureForm
    {

        
        private int mX;
        private int mY;
        protected Point cursorPos = new Point(0, 0);

        protected bool mouseDown;
        protected bool hideCrosshairs = false;
        private Rectangle captureRect;
        private string _markArea = "";
        public Rectangle CaptureRect
        {
            get { return captureRect; }
            protected set { captureRect = value; }
        }
        public string Source { get; private set; }

        public bool CaptureCanceled { get; private set; }

        //ED5400 237 84 00
        private Pen OverlayPen = new Pen(Color.FromArgb(237, 84, 00));

        List<int> _w320 = new List<int>();
        List<int> _w640 = new List<int>();
        List<int> _w800 = new List<int>();
        List<int> _w1024 = new List<int>();

        List<int> _h240 = new List<int>();
        List<int> _h480 = new List<int>();
        List<int> _h600 = new List<int>();
        List<int> _h768 = new List<int>();

        public bool Fixed43 { get; set; }

        public Size MinimumCaptureSize { get; set; }

        protected bool areaSelected = false;

        protected bool grayBG = true;

        public CaptureForm()
        {
            InitializeComponent();
        }

        public CaptureForm(Image img) : this()
        {
            
            BackgroundImage = img;
            bg = img;
            bg.Tag = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "." + DateTime.Now.Millisecond.ToString();
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            DoubleBuffered = true;
            //MinimumCaptureSize = new Size(10,10);
            if (!this.DesignMode)
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.DoubleBuffer, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.UserPaint, true);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.FormClosed += new FormClosedEventHandler(CaptureForm_FormClosed);
                CaptureCanceled = false;


#if DEBUG
            this.TopMost = false;
#else
                this.TopMost = true;
                this.BringToFront();
#endif
                Fixed43 = false;
                grayBG = false;
            }

            _markArea = Localization.LanguageMgr.LM.GetText(Labels.Capture_MarkArea);
        }

        void CaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bg.Dispose();
            OverlayPen.Dispose();
        }



        private void CaptureForm_Load(object sender, EventArgs e)
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            this.Location = new Point(0, 0);
            Rectangle b = CaptureForm.GetScreenBounds();
            this.Size = new Size(b.Width, b.Height);


            //int[] w320 = new int[] { 310, 311, 312, 313, 314, 315, 316, 317, 318, 319, 320, 321, 322, 323, 324, 325, 326, 327, 328, 329, 330 };
            //int[] w640 = new int[] { 630, 631, 632, 633, 634, 635, 636, 637, 638, 639, 640, 641, 642, 643, 644, 645, 646, 647, 648, 649, 650 };
            //int[] w800 = new int[] { 790, 791, 792, 793, 794, 795, 796, 797, 798, 799, 800, 801, 802, 803, 804, 805, 806, 807, 808, 809, 810 };
            //int[] w1024 = new int[] { 1014, 1015, 1016, 1017, 1018, 1019, 1020, 1021, 1022, 1023, 1024, 1025, 1026, 1027, 1028, 1029, 1030, 1031, 1032, 1033, 1034 };

            for (int i = 0; i < 15; i++)
            {
                _w320.Add(320 - i); _h240.Add(240 - i);
                _w320.Add(320 + i); _h240.Add(240 - i);

                _w640.Add(640 - i); _h480.Add(480 - i);
                _w640.Add(640 + i); _h480.Add(480 + i);

                _w800.Add(800 - i); _h600.Add(600 - i);
                _w800.Add(800 + i); _h600.Add(600 + i);

                _w1024.Add(1024 - i); _h768.Add(768 - i);
                _w1024.Add(1024 + i); _h768.Add(768 + i);

            }

            

            //bg = GrabScreen.Snap(GetScreenBounds(),false,GrabScreenSource.Screenshot);
            //bg.Tag = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "." + DateTime.Now.Millisecond.ToString();

            if (grayBG)
            {
                AForge.Imaging.Filters.GrayscaleBT709 gsfilter = new AForge.Imaging.Filters.GrayscaleBT709();
                bg = (Image)gsfilter.Apply((Bitmap)bg);
            }

            this.Activate();
            

        }

        public static Rectangle GetScreenBounds()
        {
            Point topLeft = new Point(0, 0);
            Point bottomRight = new Point(0, 0);
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Bounds.X < topLeft.X) topLeft.X = screen.Bounds.X;
                if (screen.Bounds.Y < topLeft.Y) topLeft.Y = screen.Bounds.Y;
                if ((screen.Bounds.X + screen.Bounds.Width) > bottomRight.X) bottomRight.X = screen.Bounds.X + screen.Bounds.Width;
                if ((screen.Bounds.Y + screen.Bounds.Height) > bottomRight.Y) bottomRight.Y = screen.Bounds.Y + screen.Bounds.Height;
            }
            return new Rectangle(topLeft.X, topLeft.Y, (bottomRight.X + Math.Abs(topLeft.X)), (bottomRight.Y + Math.Abs(topLeft.Y)));
        }

        private void CaptureForm_DoubleClick(object sender, EventArgs e)
        {
            //this.Close();
        }

        void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (areaSelected)
                return;
            if (e.Button == MouseButtons.Left)
            {
                mX = e.X;
                mY = e.Y;
                mouseDown = true;
                captureRect.Size = MinimumCaptureSize;
                PictureBoxMouseMove(this, e);
            }
        }

        protected virtual void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (areaSelected)
                return;
            //if (this.MinimumCaptureSize.Width > captureRect.Width || this.MinimumCaptureSize.Height > captureRect.Height)
            if (this.MinimumCaptureSize != null)
            {//&& this.captureRect.Width < this.MinimumCaptureSize.Width && this.captureRect.Height < this.MinimumCaptureSize.Height)
                Rectangle r = new Rectangle(this.captureRect.Location, this.MinimumCaptureSize);
                if (!captureRect.Contains(r))
                    return;
            }

            if (mouseDown)
            {
                mouseDown = false;
                cursorPos.X = 0;
                cursorPos.Y = 0;
                GetSource(false);
                this.Close();
            }
        }

        void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (areaSelected)
                return;
            if (!hideCrosshairs)
            {
                cursorPos.X = e.X;
                cursorPos.Y = e.Y;


                RectangleF rct = GetGuiRectangle(e.X + this.Left, e.Y + this.Top, mX - e.X, mY - e.Y);
                Rectangle r = new Rectangle((int)rct.Left, (int)rct.Top, (int)rct.Width, (int)rct.Height);
                if (mouseDown)
                {
                    rct = GetGuiRectangle(e.X + this.Left, e.Y + this.Top, mX - e.X, mY - e.Y);
                    int w;
                    if(Fixed43)
                        w = (int)(rct.Height * 1.333333F);
                    else
                        w = (int)rct.Width;
                    
                    int h = (int)rct.Height;

                    bool moveCursor = false;

                    if(w < MinimumCaptureSize.Width)
                    {
                        w = MinimumCaptureSize.Width;
                        moveCursor = true;
                    } 
                    if(h < MinimumCaptureSize.Height)
                    {
                        h = MinimumCaptureSize.Height;
                        moveCursor = true;
                    } 
                    if (_w320.Contains(w) && _h240.Contains(h))
                        r = new Rectangle((int)rct.Left, (int)rct.Top, 320, 240);
                    else if (_w640.Contains(w) && _h480.Contains(h))
                        r = new Rectangle((int)rct.Left, (int)rct.Top, 640, 480);
                    else if (_w800.Contains(w) && _h600.Contains(h))
                        r = new Rectangle((int)rct.Left, (int)rct.Top, 800, 600);
                    else if (_w1024.Contains(w) && _h768.Contains(h))
                        r = new Rectangle((int)rct.Left, (int)rct.Top, 1024, 768);
                    else
                        r = new Rectangle((int)rct.Left, (int)rct.Top, w, h);

                    
                    captureRect = r;

                    if(moveCursor)
                    {
                        Cursor.Position = new Point(r.X + r.Width, r.Y + r.Height);
                    }
                }

                this.Invalidate();
            }
        }

//        protected void UpdateBG()
//        {
//            if (this.BackgroundImage == null)
//                this.BackgroundImage = new Bitmap(this.Bounds.Width, this.Bounds.Height);
//            using (Graphics g = Graphics.FromImage(this.BackgroundImage))
//            {
//                g.DrawImage(GrabScreen.GetDesktopImage(), 0, 0);
//            }
//        }
//

        Image bg;
        Font crossFont = new Font(FontFamily.GenericSansSerif, 8);
        Font textFont = new Font("Arial", 11, FontStyle.Regular);
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

            //__g.Clear(Color.White);

            //g.CopyFromScreen(screenbounds.Location, new System.Drawing.Point(0, 0), screenbounds.Size);
            //g.DrawImage(bg, new Point(0, 0));
            //g.ExcludeClip(this.CaptureRect);
            //if(mouseDown)
            {
                g.ExcludeClip(this.CaptureRect);
            }
            //need to avoid flickering at video capture window
            if (TransparencyKey.IsEmpty)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), this.Bounds);
            }

            g.DrawRectangle(new Pen(Brushes.AntiqueWhite) {DashStyle = DashStyle.Dash},
                            new Rectangle(CaptureRect.X - 1, CaptureRect.Y - 1, CaptureRect.Width + 1,
                                          CaptureRect.Height + 1));
            //g.DrawString(bg.Tag.ToString(), this.Font, new SolidBrush(Color.Magenta), new PointF(0, 0));
            //_g.Flush();

//   --         if (hideCrosshairs)
//   --         {
//   --             g.FillRectangle(new SolidBrush(this.TransparencyKey), this.CaptureRect);
//   --         });

            if (mouseDown)
            {
                
                Rectangle screenbounds = GetScreenBounds();
                captureRect.Intersect(screenbounds); // crop what is outside the screen
                Rectangle fixedRect = new Rectangle(captureRect.X, captureRect.Y, captureRect.Width, captureRect.Height);
                fixedRect.X += Math.Abs(screenbounds.X);
                fixedRect.Y += Math.Abs(screenbounds.Y);
                
                //g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Transparent)), fixedRect);
                //_Cursor.Position = new Point(captureRect.X + captureRect.Width, captureRect.Y + captureRect.Height);
                //_g.DrawRectangle(OverlayPen, fixedRect);

                // rulers
                int dist = 8;
                Pen rulerPen = new Pen(Color.Silver);
                Brush bgBrush = new SolidBrush(Color.FromArgb(237, 84, 00));
                Font f = new Font(FontFamily.GenericSansSerif, 8);
                int hSpace = TextRenderer.MeasureText(captureRect.Width.ToString(), f).Width + 3;
                int vSpace = TextRenderer.MeasureText(captureRect.Height.ToString(), f).Height + 3;

                // horizontal ruler
                if (fixedRect.Width > hSpace + 3)
                {
                    GraphicsPath p = RoundedRectangleCreate2(
                                    fixedRect.X + (fixedRect.Width / 2 - hSpace / 2) + 3,
                                    fixedRect.Y - dist - 7,
                                    TextRenderer.MeasureText(captureRect.Width.ToString(), f).Width - 3,
                                    TextRenderer.MeasureText(captureRect.Width.ToString(), f).Height,
                                    3);
                    g.FillPath(bgBrush, p);
                    g.DrawPath(rulerPen, p);
                    g.DrawString(captureRect.Width.ToString(), f, rulerPen.Brush, fixedRect.X + (fixedRect.Width / 2 - hSpace / 2) + 3, fixedRect.Y - dist - 7);
                    g.DrawLine(rulerPen, fixedRect.X, fixedRect.Y - dist, fixedRect.X + (fixedRect.Width / 2 - hSpace / 2), fixedRect.Y - dist);
                    g.DrawLine(rulerPen, fixedRect.X + (fixedRect.Width / 2 + hSpace / 2), fixedRect.Y - dist, fixedRect.X + fixedRect.Width, fixedRect.Y - dist);
                    g.DrawLine(rulerPen, fixedRect.X, fixedRect.Y - dist - 3, fixedRect.X, fixedRect.Y - dist + 3);
                    g.DrawLine(rulerPen, fixedRect.X + fixedRect.Width, fixedRect.Y - dist - 3, fixedRect.X + fixedRect.Width, fixedRect.Y - dist + 3);
                }

                // vertical ruler
                if (fixedRect.Height > vSpace + 3)
                {
                    GraphicsPath p = RoundedRectangleCreate2(
                                    fixedRect.X - (TextRenderer.MeasureText(captureRect.Height.ToString(), f).Width) + 1,
                                    fixedRect.Y + (fixedRect.Height / 2 - vSpace / 2) + 2,
                                    TextRenderer.MeasureText(captureRect.Height.ToString(), f).Width - 3,
                                    TextRenderer.MeasureText(captureRect.Height.ToString(), f).Height - 1,
                                    3);
                    g.FillPath(bgBrush, p);
                    g.DrawPath(rulerPen, p);
                    g.DrawString(captureRect.Height.ToString(), f, rulerPen.Brush, fixedRect.X - (TextRenderer.MeasureText(captureRect.Height.ToString(), f).Width) + 1, fixedRect.Y + (fixedRect.Height / 2 - vSpace / 2) + 2);
                    g.DrawLine(rulerPen, fixedRect.X - dist, fixedRect.Y, fixedRect.X - dist, fixedRect.Y + (fixedRect.Height / 2 - vSpace / 2));
                    g.DrawLine(rulerPen, fixedRect.X - dist, fixedRect.Y + (fixedRect.Height / 2 + vSpace / 2), fixedRect.X - dist, fixedRect.Y + fixedRect.Height);
                    g.DrawLine(rulerPen, fixedRect.X - dist - 3, fixedRect.Y, fixedRect.X - dist + 3, fixedRect.Y);
                    g.DrawLine(rulerPen, fixedRect.X - dist - 3, fixedRect.Y + fixedRect.Height, fixedRect.X - dist + 3, fixedRect.Y + fixedRect.Height);
                }

              /*  // Display size of selected rectangle
                // Prepare the font and text.
                f = new Font(FontFamily.GenericSansSerif, 12);
                string t = captureRect.Width + " x " + captureRect.Height;

                // Calculate the scaled font size.
                SizeF extent = g.MeasureString(t, f);
                float hRatio = captureRect.Height / (extent.Height * 2);
                float wRatio = captureRect.Width / (extent.Width * 2);
                float ratio = (hRatio < wRatio ? hRatio : wRatio);
                float newSize = f.Size * ratio;

                if (newSize >= 4) // Only show if 4pt or larger.
                {
                    if (newSize > 20) newSize = 20;
                    // Draw the size.
                    f = new Font(FontFamily.GenericSansSerif, newSize, FontStyle.Bold);
                    Brush c = new SolidBrush(Color.FromArgb(237, 84, 00));
                    if (this.MinimumCaptureSize != null)
                    {
                        Rectangle r = new Rectangle(this.captureRect.Location, this.MinimumCaptureSize);
                        if(!captureRect.Contains(r))
                            c = new SolidBrush(Color.Red);
                    }

                    g.DrawString(t, f, c, new PointF(fixedRect.X + (
                        captureRect.Width / 2) - (TextRenderer.MeasureText(t, f).Width / 2),
                        fixedRect.Y + (captureRect.Height / 2) - (f.GetHeight() / 2)));
                }*/
            }
            else
            {
                if (cursorPos.X > 0 || cursorPos.Y > 0)
                {
                    Pen p = new Pen(Color.Silver);
                    p.DashStyle = DashStyle.Dot;
                    Rectangle b = CaptureForm.GetScreenBounds();
                    g.DrawLine(p, cursorPos.X, b.Y, cursorPos.X, b.Height);
                    g.DrawLine(p, b.X, cursorPos.Y, b.Width, cursorPos.Y);

                    
                    string xy = cursorPos.X.ToString() + " x " + cursorPos.Y.ToString();
                    Brush bgBrush = new SolidBrush(Color.FromArgb(200, 217, 240, 227));
                    GraphicsPath gp = RoundedRectangleCreate2(
                        cursorPos.X + 5,
                        cursorPos.Y + 5,
                        TextRenderer.MeasureText(xy, crossFont).Width - 3,
                        TextRenderer.MeasureText(xy, crossFont).Height,
                        3);
                    g.FillPath(bgBrush, gp);
                    g.DrawPath(new Pen(Color.FromArgb(237, 84, 00)), gp);
                    using(Brush brush = new Pen(Color.FromArgb(237, 84, 00)).Brush)
                    {
                        g.DrawString(xy, crossFont, brush, cursorPos.X + 5, cursorPos.Y + 5);
                    }
                    using (Brush br = new Pen(Color.AntiqueWhite).Brush)
                    {
                        SizeF strSize = g.MeasureString(_markArea, textFont);
                        g.DrawString(_markArea, textFont, br, cursorPos.X + 5, cursorPos.Y - 5 - strSize.Height);

                    }
                }
            }
        }


        private RectangleF GetGuiRectangle(float x, float y, float w, float h)
        {
            if (w < 0)
            {
                x = x + w;
                w = -w;
            }
            if (h < 0)
            {
                y = y + h;
                h = -h;
            }
            return new RectangleF(x, y, w, h);
        }

        private GraphicsPath RoundedRectangleCreate2(int x, int y, int width, int height, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();

            return gp;
        }



        public void GetSource(bool bringToTop)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(() => GetSource(bringToTop));
                return;
            }
            Source = GetSource(this, captureRect, bringToTop);
        }

        public static string GetSource(Form form, Rectangle captureRect, bool bringToTop)
        {
            if (form.Visible)
            {
                form.Hide();
            }

            ManagedWinapi.Windows.SystemWindow win;
            string tag = "";
            string uurl = "";
            try
            {
                int x = captureRect.X + captureRect.Width / 2;
                int y = captureRect.Y + captureRect.Height / 2;
                //win = ManagedWinapi.Windows.SystemWindow.FromPointEx(MousePosition.X, MousePosition.Y, true, false);
                win = ManagedWinapi.Windows.SystemWindow.FromPointEx(x, y, true, false);
                tag = win.Title;// +" - " + win.Process.MainModule.ModuleName;//

                if (win.Process.ProcessName.ToLower().Contains("firefox"))
                {
                    uurl = BrowserSourceHelper.GetFireFoxSource();
                }

                else if (win.Process.ProcessName.ToLower().Contains("iexplore"))
                {
                    uurl = BrowserSourceHelper.GetIESource();
                }
                else if (win.Process.ProcessName.ToLower().Contains("chrome"))
                {
                    uurl = BrowserSourceHelper.GetChromeSource(win.HWnd);
                } 


                return uurl.HasValue() ? uurl : tag;
            }
            catch (Exception e)
            {
                DebugHelper.Log("[CaptureForm] : an error occurred in attempt to get source. " + e.ToString());
                throw e;
            }
            
        }

        private void CaptureForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CaptureForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (mouseDown)
                {
                    mouseDown = false;
                    CaptureRect = Rectangle.Empty;
                    this.Invalidate();
                }
                else
                {
                    CaptureCanceled = true;
                    this.Close();
                }
            }
        }

    }
}
