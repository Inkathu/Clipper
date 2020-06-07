using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    /// <summary>
    /// Base Class for the Gradient Rounded button
    /// </summary>
    public partial class BaseButton : System.Windows.Forms.ButtonBase, IButtonControl
    {
        /// <summary>
        /// Space between the button caption and image
        /// </summary>
        private const int GAP = 5;

        /// <summary>
        /// Button Rounding radius
        /// </summary>
        public int RoundingRadius { get; set; }

        /// <summary>
        /// Start Gradient Color
        /// </summary>
        public Color Color1 { get; set; }

        /// <summary>
        /// End Gradient color
        /// </summary>
        public  Color Color2 { get; set; }

        /// <summary>
        /// Color of Caption
        /// </summary>
        public Color FontColor { get; set; }

        /// <summary>
        /// Color of the button border
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// Color of the top glow line
        /// </summary>
        public Color TopGlowLineColor { get; set; }
        
        /// <summary>
        /// Button Image
        /// </summary>
        public new Image Image 
        {
            get
            {
                return base.Image;
            }
            set 
            {
                base.Image = value;
                Invalidate();
            }
        }
        

        /// <summary>
        /// Default size of the image
        /// </summary>
        public Size ImageSize { get; set; }

        /// <summary>
        /// Caption of the button
        /// </summary>
        public string ButtonCaption { get; set; }

        /// <summary>
        /// Click button flag.
        /// True if button has been clicked, itherwise false
        /// </summary>
        private bool clicked = false;

        public override string Text
        {
            get { return ButtonCaption; }
            set
            {
                ButtonCaption = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.StandardDoubleClick, false);
            SetStyle(ControlStyles.Selectable, true);

            RoundingRadius = 10;
//            Color1 = Color.FromArgb(0x20, 0x99, 0xE5);
//            Color2 = Color.FromArgb(0x0, 0x74, 0xBD);
            Color1 = SystemColors.Control;
            Color2 = SystemColors.Control;
            FontColor = Color.Black;
            BorderColor = SystemColors.ControlDark;
            TopGlowLineColor = Color.White;
            Font = new Font("Arial", 10,FontStyle.Bold);
            //pictureBox1.BackColor = Color.Transparent;
            ImageSize = new Size(20, 20);
            Image = null;
            ButtonCaption = "Button";
            MouseEnter += new EventHandler(ButtonBase_MouseEnter);
            MouseLeave += new EventHandler(ButtonBase_MouseLeave);
            KeyDown += new KeyEventHandler(ButtonBase_KeyDown);
            KeyUp += new KeyEventHandler(ButtonBase_KeyUp);
            SizeChanged += new EventHandler(BaseButton_SizeChanged);
            SetButtonRegion();
        }

        void BaseButton_SizeChanged(object sender, EventArgs e)
        {
            SetButtonRegion();
        }

        private void SetButtonRegion()
        {
            //Create the rounding region
            GraphicsPath clipPath = new GraphicsPath();
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
            clipPath.AddArc(-1, h - r, r, r, 90, 90);
            clipPath.CloseFigure();
            //set the rounding
            this.Region = new Region(clipPath);            
        }

        void ButtonBase_KeyUp(object sender, KeyEventArgs e)
        {
            if(clicked)
            {
                clicked = false;
                Invalidate();
            }
        }

        void ButtonBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space && !e.Shift && !e.Control && !e.Alt)
            {
                clicked = true;
                Invalidate();
            }
        }

        void ButtonBase_MouseLeave(object sender, EventArgs e)
        {
            Color tmp = Color2;
            Color2 = Color1;
            Color1 = tmp;
            
        }

        void ButtonBase_MouseEnter(object sender, EventArgs e)
        {
            Color tmp = Color1;
            Color1 = Color2;
            Color2 = tmp;
        }

        /// <summary>
        /// Mouse down event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clicked = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Mouse Up event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clicked = false;
                Invalidate();
            }
        }

        private Color GrayScale(Color col)
        {
            int color = (col.R + col.G + col.B)/3;
            return Color.FromArgb(color, color, color);
        }

        /// <summary>
        /// Paint event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            
            SmoothingMode oldSmoothingMode = e.Graphics.SmoothingMode;
            byte alpha = 255;
            
            //create rectangle with the current button size
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            //create brush
            Color color1 = Utils.Minus(alpha, Color1, 20);
            Color color2 = Utils.Minus(alpha, Color2, 20);
            Color color3 = Color.FromArgb(alpha, Color1.R, Color1.G, Color1.B);
            Color color4 = Color.FromArgb(alpha, Color2.R , Color2.G , Color2.B);
            if(!Enabled)
            {
                color1 = GrayScale(color1);
                color2 = GrayScale(color2);
                color3 = GrayScale(color3);
                color4 = GrayScale(color4);
            }
            using (Brush brush = clicked ? new LinearGradientBrush(rectangle, color1, color2, LinearGradientMode.Vertical)
                                         : new LinearGradientBrush(rectangle, color3, color4, LinearGradientMode.Vertical))
            {
                //set smothing mode
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //fill rectangle with the gradient brush
                e.Graphics.FillRectangle(brush, rectangle);

                //calculate string size
                SizeF measureString = e.Graphics.MeasureString(ButtonCaption, Font);

                //calculate space for the image
                float imgWidthWithGap = Image == null ? 0 : (ImageSize.Width + (measureString.Width > 0 ? GAP : 0));
                float startX = (Width  - (imgWidthWithGap + measureString.Width))/2;
                float startY = 0;
                //draw image if it is settled
                if(Image != null)
                {
                    
                    startY = (Height - Image.Height) / 2;
                    //pictureBox1.Left = (int)startX;
                    //pictureBox1.Top = (int)startY;
                    //pictureBox1.Padding = new System.Windows.Forms.Padding(0);
                    //pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    //pictureBox1.Size = ImageSize;
                    
                    //pictureBox1.Image = Image;
                    //startX += imgWidthWithGap;
                    //pictureBox1.Visible = true;
                    //pictureBox1.Enabled = Enabled;
                    e.Graphics.DrawImage(Image, new Rectangle(new Point((int)startX, (int)startY), ImageSize));
                    startX += imgWidthWithGap;
                } 

                //draw string
                startY = (Height - measureString.Height)/2;

                using (Brush fontBrush = new SolidBrush(Color.FromArgb(alpha, FontColor.R, FontColor.G, FontColor.B)))
                {
                    if(Enabled)
                    {
                        e.Graphics.DrawString(ButtonCaption, Font, fontBrush, new PointF(startX, startY));
                    } else
                    {
                        e.Graphics.TranslateTransform(-1, -1);
                        e.Graphics.DrawString(Text, Font, Brushes.White,new PointF(startX, startY));
                        e.Graphics.ResetTransform();
                        e.Graphics.DrawString(Text, Font, Brushes.DarkGray, new PointF(startX, startY));
                    }
                }

                if(Focused)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(2, 2, Width - 2 * 2, Height - 2* 2), Color.Black,
                                                                                      BackColor);                    
                }
                
            }

            //Create the rounding region
            GraphicsPath clipPath = new GraphicsPath();
            int r = RoundingRadius;
            int w = Width;
            int h = Height;
            clipPath.StartFigure();
            clipPath.AddArc(-1, -1, r, r, 180, 90);
            clipPath.AddLine(r, -1, w - r, -1);
            clipPath.AddArc(w - r, -1, r, r, 270, 90);
            clipPath.AddLine(w, r, w, h - r);
            clipPath.AddArc(w - r, h - r, r , r , 0, 90);
            clipPath.AddLine(w - r, h, r, h);
//            clipPath.AddLine(w, r, w, h - r - 1);
//            clipPath.AddArc(w - r - 1, h - r - 1, r + 1, r + 1, 0, 90);
//            clipPath.AddLine(w - r - 1, h, r, h);
            clipPath.AddArc(-1, h - r, r, r, 90, 90); 
            clipPath.CloseFigure();


            e.Graphics.DrawLine(new Pen(Color.FromArgb(alpha, TopGlowLineColor.R, TopGlowLineColor.G, TopGlowLineColor.B)), 0, 1, w, 1);
            //set the rounding
            //this.Region = new Region(clipPath);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(alpha, BorderColor.R, BorderColor.G, BorderColor.B), 3), clipPath);
        }


        new protected bool IsDefault { get; set; }
        public void NotifyDefault(bool value)
        {
            if (this.IsDefault != value)
            {
                this.IsDefault = value;
            }
        }

        public void PerformClick()
        {
            if (this.CanSelect)
            {
                this.OnClick(EventArgs.Empty);
            }
        }

        public DialogResult DialogResult 
        {
            get 
            { 
                return dialogResult; 
            }
            set 
            { 
                dialogResult = value; 
            }
        }
        private DialogResult dialogResult;
        
    }
}
