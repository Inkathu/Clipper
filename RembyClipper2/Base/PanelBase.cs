using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class PanelBase : Panel
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color HighLightedColor { get; set; }
        public Color TopGlowLineColor { get; set; }
        public Color ColorOfBorder { get; set; }
        public bool ShowBorder{get;set;}
        public bool DrawRoundedBorder { get; set; }
        public int RoundingRadius { get; set; }


        public PanelBase()
        {
            InitializeComponent();
            Color1 = SystemColors.Control;
            Color2 = SystemColors.ControlDark;
            HighLightedColor = SystemColors.ControlLight;
            ColorOfBorder = Color.Black;
            ShowBorder = false;
            DrawRoundedBorder = false;
            RoundingRadius = 10;
            TopGlowLineColor = Color.White;
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.UpdateStyles();
            SizeChanged += new EventHandler(PanelBase_SizeChanged);
            PanelBase_SizeChanged(this, EventArgs.Empty);
            //Resize += new EventHandler(PanelBase_Resize);




        }

        void PanelBase_SizeChanged(object sender, EventArgs e)
        {
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
            Region = new Region(clipPath);
        }
//
//        void PanelBase_Resize(object sender, EventArgs e)
//        {
//            Refresh();
//        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            if (Width != 0 && Height != 0)
            {
                using (Brush brush = new LinearGradientBrush(rect, Color1, Color2, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else
            {
               Invalidate();
            }

            using (Pen p = new Pen(TopGlowLineColor))
            {
                e.Graphics.DrawLine(p, 0, 1, Width, 1 );    
            }

            if (ShowBorder)
            {
                using (Pen p = new Pen(ColorOfBorder, DrawRoundedBorder ? 3: 2))
                {

                    if (DrawRoundedBorder)
                    {
                        //Create the rounded region
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
                        e.Graphics.DrawPath(p, clipPath);
                    }
                    else
                    {
                        rect = this.ClientRectangle;
                        e.Graphics.DrawRectangle(p, rect);
                    }
                }

            }
            
        }
    }
}
