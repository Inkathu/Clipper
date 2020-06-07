using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.Icon = global::RembyClipper2.NewDesign.clipper32x32;
            if (Environment.OSVersion.Version.CompareTo(new Version("6.1.7600.0")) < 0) // older than win7
            {
                disableAntiFlicker = true;
            }
            if (DisableAntiFlicker)
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.DoubleBuffer, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                
            }
        }

        private bool disableAntiFlicker = false;

        public bool DisableAntiFlicker
        {
            get { return disableAntiFlicker; }
            set
            {
                disableAntiFlicker = value; 
                if (Environment.OSVersion.Version.CompareTo(new Version("6.1.7600.0")) < 0)
                {
                    disableAntiFlicker = true;
                }
            }
        }

#if antiflicker

        protected override CreateParams CreateParams
        {
            get
            {
                if (!this.DesignMode && !this.DisableAntiFlicker)
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                    cp.ExStyle |= 0x00080000; //WS_EX_LAYERED. Transparency key
                    return cp;
                }
                else return base.CreateParams;
            }
        }

#endif
    }
}
