using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Base;

namespace RembyClipper2.Config
{
    public partial class TabButton : BaseControl
    {
        public TabButton()
        {
            InitializeComponent();

            GraphicsPath clipPath = new GraphicsPath();
            int r = 10;
            int w = Width;
            int h = Height;
            clipPath.StartFigure();
            clipPath.AddArc(-1, -1, r, r, 180, 90);
            clipPath.AddLine(r, -1, w - r, -1);
            clipPath.AddArc(w - r, -1, r, r, 270, 90);
            clipPath.AddLine(w, r, w, h);
            clipPath.AddLine(w, h, 0, h);
            //            clipPath.AddLine(w, r, w, h - r - 1);
            //            clipPath.AddArc(w - r - 1, h - r - 1, r + 1, r + 1, 0, 90);
            //            clipPath.AddLine(w - r - 1, h, r, h);
            clipPath.CloseFigure();


            //set the rounding
            this.Region = new Region(clipPath);

        }

        bool _selected = false;

       [Browsable(true)]
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                if (_selected)
                    this.BackColor = SystemColors.Control;
                else
                {
                    this.BackColor = SystemColors.ControlDark;
                    this.BorderStyle = BorderStyle.None;
                }
            }
        }
        [Browsable(true)]
        public new string Text
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
                int X = 41 - (label1.Width / 2);
                int Y = 15 - (label1.Height / 2);
                label1.Location = new Point(X, Y);
            }

        }

        public Panel PanelToShow { get; set; }

        private void TabButton_MouseEnter(object sender, EventArgs e)
        {
            if (Selected)
                return;
            //this.BackgroundImage = global::RembyClipper2.Properties.Resources.TabControl_Hover;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void TabButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
                return;
            if (Selected)
                return;
            this.BorderStyle = BorderStyle.None;
        }

        private void TabButton_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
            if (sender is Label)
                OnClick(e);
        }

    }
}
