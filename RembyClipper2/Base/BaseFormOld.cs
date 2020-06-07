using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace RembyClipper2.Base
{
    public partial class BaseFormOld : Form
    {
        private bool disableAntiFlicker = false;

        public bool DisableAntiFlicker
        {
            get { return disableAntiFlicker; }
            set { disableAntiFlicker = value; }
        }

        
        
        public BaseFormOld()
        {
            InitializeComponent();
            this.Icon = global::RembyClipper2.NewDesign.clipper32x32;
            SetRegion();

            this.FormClosed += new FormClosedEventHandler(BaseForm_FormClosed);

            if (DisableAntiFlicker)
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.DoubleBuffer, true);
            }

        }



        void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var c in this.Controls)
            {
                if (c is IDisposable)
                    ((IDisposable)c).Dispose();
            }
            this.Dispose(true);
            //GC.Collect();
        }

        protected void SetRegion()
        {
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height, 10, 10));
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                labelTitle.Text = value;
                base.Text = value;
            }
        }

        public enum RembyFormIcons { photo, video, settings }
        private RembyFormIcons _rembyFormIcon = RembyFormIcons.photo;
        public RembyFormIcons RembyFormIcon
        {
            get
            {
                return _rembyFormIcon;
            }
            set
            {
                _rembyFormIcon = value;
                if (value == RembyFormIcons.photo)
                    pictureBoxIcon.Image = global::RembyClipper2.Properties.Resources.Icon_photo;
                if (value == RembyFormIcons.video)
                    pictureBoxIcon.Image = global::RembyClipper2.Properties.Resources.Icon_video;
                if (value == RembyFormIcons.settings)
                    pictureBoxIcon.Image = global::RembyClipper2.Properties.Resources.Icon_settings;
            }

        }

        #region Form close
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxClose.Image = global::RembyClipper2.Properties.Resources.Close_simple;
        }

        private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxClose.Image = global::RembyClipper2.Properties.Resources.Close_hover;
        }
        #endregion

        #region Form Drag'n'Drop
        private int _mX = -1;
        private int _mY = -1;
        private void panelDrag_MouseDown(object sender, MouseEventArgs e)
        {
            _mX = e.X;
            _mY = e.Y;
        }

        private void panelDrag_MouseUp(object sender, MouseEventArgs e)
        {
            _mX = -1;
            _mY = -1;
        }

        private void panelDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mX != -1 && _mY != -1)
            {
                this.Location = new Point(Cursor.Position.X - _mX, Cursor.Position.Y - _mY);
            }
        }
        #endregion

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height, 10, 10)); 
        }

#if antiflicker

        protected override CreateParams CreateParams
        {
            get
            {
                if (!DisableAntiFlicker)
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                    cp.ExStyle |= 0x00080000; //WS_EX_LAYERED. Transparency key
                    return cp;
                }
                else
                    return base.CreateParams;
            }
        }

#endif

        protected CreateParams GetBaseCreateParams { get { return base.CreateParams; } }

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
    }
}
