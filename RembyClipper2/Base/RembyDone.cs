using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using System.Web;
using RembyClipper2.Utils;

namespace RembyClipper2.Base
{
    public partial class RembyDone : BaseControl
    {

        public event CustomButtonClicked OnBlackClicked;
        public RembyDone()
        {
            InitializeComponent();
#if !DEBUG
            //this.buttonBlack1.Text = AppConfig.Lang.GetValue("Button_CloseThisWindow");
            //TODO: Remove this component
            this.label5.ForeColor = Color.FromArgb(246, 124, 56);
            //label1.Text = AppConfig.Lang.GetValue("RembyDone_RembyDone");
            //label5.Text = AppConfig.Lang.GetValue("RembyDone_OpenYouTube");
#endif
        }

        bool remby = false;
        public void SetToVideo()
        {
            //this.label1.Text = AppConfig.Lang.GetValue("RembyDone_YouTubeDone");
            //TODO: Remove this component
            this.label5.Visible = true;
            remby = false;
        }

        public void SetToRemby()
        {
            //this.label5.Text = AppConfig.Lang.GetValue("RembyDone_OpenRemby");
            //TODO: Remove this component
            this.label5.Visible = true;
            remby = true;
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            if (OnBlackClicked != null)
                OnBlackClicked();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process t = new Process();
            if (remby)
                t.StartInfo.FileName = RembyConstants.RembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(RembyClipper.Helpers.RembyServices.lastResult);
            else
                t.StartInfo.FileName = "http://www.youtube.com/watch?v=" + YouTubeHelper.VideoID;
            t.Start();
        }
    }
}
