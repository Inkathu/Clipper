using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlsTest.CustomList
{
    public partial class ListItemBase : UserControl
    {
        public Color BorderColor { get; set; }
        public Color HoverColor  { get; set; }
        public bool  DrawBorder  { get; set; }
        public int   BorderSize  { get; set; }


        public override string Text { get; set; }
        public virtual string Tags { get; set; }
        public virtual string TimeStamp
        {
            get { return timeStampLabel.Text; }
            set { timeStampLabel.Text = value; }
        }

        public ListItemBase()
        {
            InitializeComponent();
            BorderColor = Color.DarkGray;
            DrawBorder = false;
            HoverColor = Color.Orange;
            BorderSize = 2;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            //Point p = this.PointToClient(Cursor.Position);
            Color c = hover ? HoverColor : BackColor;
            using (Brush b = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(b, this.ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            
            base.OnPaint(e);

            if(DrawBorder)
            {
                using(Pen p = new Pen(BorderColor, BorderSize))
                {
                    e.Graphics.DrawRectangle(p, 0,0, Width - Margin.Right, Height - Margin.Bottom);
                }
                
            }
        }

        private bool hover = false;
        private void ListItemBase_MouseEnter(object sender, EventArgs e)
        {
            hover = true;
            Invalidate();
        }

        private void ListItemBase_MouseLeave(object sender, EventArgs e)
        {
            if(!ClientRectangle.Contains(PointToClient(Cursor.Position)))
            {
                hover = false;
                Invalidate();
            }
        }


    }
}
