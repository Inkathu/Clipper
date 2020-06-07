using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using System.Diagnostics;
using RembyClipper2.Utils;

namespace RembyClipper2.Base
{
    public partial class RembyYouTubeControl : RembyClipper2.Base.RembyLoginControl
    {
        public RembyYouTubeControl()
        {
            InitializeComponent();
            ApplyLanguage();
        }

        public new void ApplyLanguage()
        {
            this.label1.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyYouTubeLogin_Title);
            label6.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyYouTubeLogin_KeepLoggedIn);
            label4.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyYouTubeLogin_DontHaveAccount);
            label5.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyYouTubeLogin_FreeUserTitle);
            signupLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyYouTubeLogin_CreateAccount);
        }

        public bool ValidateYouTube()
        {
            if (!CheckCredentials())
                return true;

            if (textBoxUsername.Text == "")
            {
                textBoxUsername.Focus();
                return false;
            }
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Focus();
                return false;
            }
            return true;
        }

        internal bool CheckCredentials()
        {
            return YouTubeHelper.CheckCredentials(textBoxUsername.Text, textBoxPassword.Text);
        }

        internal void InitYouTube()
        {
            if (YouTubeHelper.CheckCredentials(textBoxUsername.Text, textBoxPassword.Text))
                YouTubeHelper.Init(textBoxUsername.Text, textBoxPassword.Text);
            else
                YouTubeHelper.Init();
        }

        protected override void SignUpLabelClick(object sender, EventArgs e)
        {
            Process t = new Process();
            t.StartInfo.FileName = RembyConstants.YouTubeSignUpLink;
            t.Start();
        }
    }
}
