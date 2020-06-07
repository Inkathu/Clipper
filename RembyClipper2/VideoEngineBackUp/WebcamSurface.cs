using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Base;

namespace RembyClipper2.VideoEngine
{
    public partial class WebcamSurface : UserControl, IWebCamSurface
    {
        public Rectangle CaptureRect { get; set; }
        public event CustomButtonClicked OnCloseClicked;
        
        public WebcamSurface()
        {
            InitializeComponent();
        }

        public void SetControlsVisible()
        {
            if (pictureBox1.Visible)
                return;
            pictureBoxClose.Visible = true;
            pictureBoxMinMax.Visible = true;
        }

        public void SetControlsInVisible()
        {
            if (this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
                return;
            pictureBoxClose.Visible = false;
            pictureBoxMinMax.Visible = false;
        }


        private int _mX = -1;
        private int _mY = -1;
        private Cursor _current;


        private void panelPIP_MouseUp(object sender, MouseEventArgs e)
        {
            _mX = -1;
            _mY = -1;
            Cursor.Current = _current;
        }

        private void panelPIP_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mX != -1 && _mY != -1)
            {
                this.Location = new Point(Cursor.Position.X - _mX, Cursor.Position.Y - _mY);
            }
        }

        private void panelPIP_MouseDown(object sender, MouseEventArgs e)
        {
            _mX = e.X;
            _mY = e.Y;
            _current = Cursor.Current;
            Cursor.Current = Cursors.SizeAll;
        }

        private bool blownUp = false;
        private Point pipLocaltion;


        private void pictureBoxMinMax_Click(object sender, EventArgs e)
        {
            if (!blownUp)
            {
                int blowUpW = 160, blowUpH = 120;
                pictureBoxMinMax.Image = global::RembyClipper2.Properties.Resources.WebcamZoomOut;
                if (CaptureRect.Width > 320 && CaptureRect.Height > 240)
                {
                    blowUpW = 320;
                    blowUpH = 240;
                }

                if (CaptureRect.Width > 640 && CaptureRect.Height > 480)
                {
                    blowUpW = 640;
                    blowUpH = 480;
                }

                if (CaptureRect.Width > 800 && CaptureRect.Height > 600)
                {
                    blowUpW = 800;
                    blowUpW = 600;
                }

                this.SuspendLayout();

                pipLocaltion = this.Location;


                int X = CaptureRect.Left + CaptureRect.Width / 2 - (blowUpW / 2);
                int Y = CaptureRect.Top + CaptureRect.Height / 2 - (blowUpH / 2);
                this.Location = new Point(X, Y);
                this.Size = new Size(blowUpW, blowUpH);

                this.ResumeLayout();

                blownUp = true;
            }
            else
            {
                this.Size = new Size(160, 120);
                this.Location = pipLocaltion;
                pictureBoxMinMax.Image = global::RembyClipper2.Properties.Resources.WebcamZoomIn;
                blownUp = false;
            }
        }

        private void pictureBoxMinMax_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void pictureBoxMinMax_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (OnCloseClicked != null)
                OnCloseClicked();
        }

        #region IWebCamSurface Members

        public void ShowLoading()
        {
            pictureBox1.Visible = true;
        }

        public void HideLoading()
        {
            pictureBox1.Visible = false;
        }

        #endregion
    }

    public interface IWebCamSurface
    {
        void ShowLoading();
        void HideLoading();
    }
}
