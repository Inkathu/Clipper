using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;

namespace RembyClipper2.Base
{
    public partial class FirstUserExperience : BaseForm
    {
        public FirstUserExperience()
        {
            InitializeComponent();
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            //Localization.LanguageMgr.LM.GetText(Labels.)
            buttonBlack1.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Cancel);
            buttonOrange1.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Continue);
            this.Text = Localization.LanguageMgr.LM.GetText(Labels.FirstUserExperience_FormTitle);
            titleLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.FirstUserExperience_title);
            title2Label.Text = Localization.LanguageMgr.LM.GetText(Labels.FirstUserExperience_body1);
            title3label.Text = Localization.LanguageMgr.LM.GetText(Labels.FirstUserExperience_body2);
            termsLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyVideo_YouTubeLegal);
            dontShowCheckBox.Text = Localization.LanguageMgr.LM.GetText(Labels.FirstUserExperence_dontshow);
        }

        public bool thisCancel = false;

        private void buttonOrange1_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.VideoFirstTimeExperienceShown = dontShowCheckBox.Checked;
            AppConfig.Instance.Store();
            this.Close();
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            this.thisCancel = true;
            this.Close();
        }

        private void FirstUserExperience_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
        }
    }
}
