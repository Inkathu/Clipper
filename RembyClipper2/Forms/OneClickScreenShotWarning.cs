using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;

namespace RembyClipper2.Forms
{
    public partial class OneClickScreenShotWarning : RembyClipper2.Base.BaseForm
    {
        public OneClickScreenShotWarning()
        {
            InitializeComponent();
            ApplyLanguage();
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            titleLabel.Text = LanguageMgr.LM.GetText(Labels.OneClickScreenShot_Title);
            textLabel.Text = LanguageMgr.LM.GetText(Labels.OneClickScreenShot_Text);
            dontShowAgainCB.Text = LanguageMgr.LM.GetText(Labels.NotificationDontShowAgain);
            reselectButton.Text = LanguageMgr.LM.GetText(Labels.Button_Reselect);
            closeButton.Text = LanguageMgr.LM.GetText(Labels.Button_Close);
            Text = LanguageMgr.LM.GetText(Labels.Attention);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            AppConfig.Instance.OneClickScreenShotShown = dontShowAgainCB.Checked;
            AppConfig.Instance.Store();
            this.Close();
        }

        private void reselectButton_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.OneClickScreenShotShown = dontShowAgainCB.Checked;
            AppConfig.Instance.Store();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
