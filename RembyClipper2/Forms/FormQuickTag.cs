using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Base;
using RembyClipper2.Config;

namespace RembyClipper2.Forms
{
    public partial class FormQuickTag : BaseForm
    {
        public FormQuickTag()
        {
            InitializeComponent();
            ApplyLanguage();
            autoCompleteTextBox1.Values = AppConfig.SupportedTags;

            //GrowDownwards = true;
            autoCompleteTextBox1.Text = AppConfig.Instance.LastUsedTags;
            autoCompleteTextBox1.SelectAll();
            this.FormClosing += new FormClosingEventHandler(FormQuickTag_FormClosing);
            //AppConfig.topnav.SetRegion(this, true);
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            btnUpload.Text = Localization.LanguageMgr.LM.GetText(Labels.Upload);
            btnClose.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Close);
            tagsLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.Tags);
        }

        void FormQuickTag_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Instance.LastUsedTags = Tags;
        }

        public string Tags { get { return autoCompleteTextBox1.Text; } }

        
        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormQuickTag_Load(object sender, EventArgs e)
        {
            if (this.Width + AppConfig.topnav.Location.X > CaptureForm.GetScreenBounds().Width)
                this.Location = new Point(AppConfig.topnav.Location.X - this.Width, AppConfig.topnav.Location.Y);
            else
                this.Location = new Point(AppConfig.topnav.Location.X + 32, AppConfig.topnav.Location.Y);
        }

        private void grayPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
