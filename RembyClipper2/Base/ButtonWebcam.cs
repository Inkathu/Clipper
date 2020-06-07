using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;

namespace RembyClipper2.Base
{
    public partial class ButtonWebcam : RembyClipper2.Base.ButtonBlack
    {
        private ToolTip toolTipHelp = new ToolTip();

        public ButtonWebcam()
        {
            InitializeComponent();
            this.ImageHover = this.BackgroundImage;
            this.ImageNormal = this.BackgroundImage;
            if (!this.DesignMode)
            {
                toolTipHelp.SetToolTip(this, AppConfig.Lang.GetValue("ToolTip_WebcamOFF"));
            }
        }

        bool state = false;
        bool disabled = false;

        public bool Disabled
        {
            get { return disabled; }
            set
            {
                disabled = value;
                if (disabled)
                {
                    this.BackgroundImage = global::RembyClipper2.Properties.Resources.Webcam_off;
                    this.ImageHover = this.BackgroundImage;
                    this.ImageNormal = this.BackgroundImage;
                    toolTipHelp.SetToolTip(this, AppConfig.Lang.GetValue("ToolTip_WebcamDisabled"));
                }
            }
        }

        private void ButtonWebcam_Click(object sender, EventArgs e)
        {
            if(disabled)
                return;
            if (!state)
            {
                this.BackgroundImage = global::RembyClipper2.Properties.Resources.Webcam_off;
                this.ImageHover = this.BackgroundImage;
                this.ImageNormal = this.BackgroundImage;
                toolTipHelp.SetToolTip(this, AppConfig.Lang.GetValue("ToolTip_WebcamON"));
                state = true;
            }
            else
            {
                this.BackgroundImage = global::RembyClipper2.Properties.Resources.Webcam;
                this.ImageHover = this.BackgroundImage;
                this.ImageNormal = this.BackgroundImage;
                toolTipHelp.SetToolTip(this, AppConfig.Lang.GetValue("ToolTip_WebcamOFF"));
                state = false;
            }
        }
    }
}
