using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;
using RembyClipper.VideoEngine;

namespace RembyClipper2.Base
{
    public partial class ButtonMute : ButtonBlack
    {
        private ToolTip toolTipHelp = new ToolTip();
        public ButtonMute()
        {
            InitializeComponent();

            this.ImageHover = this.BackgroundImage;
            this.ImageNormal = this.BackgroundImage;
            if (!this.DesignMode)
            {
                toolTipHelp.SetToolTip(this, AppConfig.Lang.GetValue("ToolTip_Mute"));
            }
        }

        public ScreenCapture2 sc { get; set; }

        bool state = false;
        private void ButtonMute_Click(object sender, EventArgs e)
        {
            if (!state)
            {
                this.BackgroundImage = global::RembyClipper2.Properties.Resources.mute_off;
                this.ImageHover = this.BackgroundImage;
                this.ImageNormal = this.BackgroundImage;
                toolTipHelp.SetToolTip(this, AppConfig.Lang.GetValue("ToolTip_Mute"));
                state = true;
            }
            else
            {
                this.BackgroundImage = global::RembyClipper2.Properties.Resources.mute;
                this.ImageHover = this.BackgroundImage;
                this.ImageNormal = this.BackgroundImage;
                toolTipHelp.SetToolTip(this, AppConfig.Lang.GetValue("ToolTip_UnMute"));
                state = false;
            }

            if (sc != null)
                sc.MuteMic = !sc.MuteMic;
        }
    }
}
