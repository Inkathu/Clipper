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
    public partial class ToolStripBase : ToolStrip
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color TopGlowLineColor { get; set; }

        public ToolStripBase()
        {
            InitializeComponent();
            Color1 = SystemColors.Control;
            Color2 = SystemColors.ControlDark;
            TopGlowLineColor = Color.White;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            using (Brush brush = new LinearGradientBrush(rect, Color1, Color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            using (Pen p = new Pen(TopGlowLineColor))
            {
                e.Graphics.DrawLine(p, 0, 1, Width, 1);
            }
            
        }
    }
}
