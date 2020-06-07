using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.IO;
using Localization;
using RembyClipper2.Config;
using Google.GData.YouTube;
using RembyClipper2.Utils;

namespace RembyClipper2.Base
{
    public partial class RembyVideo : BaseControl
    {

        public event CustomButtonClicked OnOrangeClicked;
        public event CustomButtonClicked OnBlackClicked;
        private ToolTip toolTipHelp = new ToolTip();

        public RembyVideo()
        {
            InitializeComponent();
            this.videoPlayer1.OnVideoError += new CustomError(videoPlayer1_OnVideoError);
            ApplyLanguage();
            tagEditControl.SetTagsCollection(AppConfig.SupportedTags);
        }

        public void ApplyLanguage()
        {
            //Localization.LanguageMgr.LM.GetText(Labels.
            this.btnAddToRemby.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_AddRemby);
            this.btnCancel.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Cancel);
            this.textBoxTitle.Text += DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            label1.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.RembyVideo_Title);
            label2.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Tags);
            label3.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.RembyVideo_Description);
            label4.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.RembyVideo_Category);
            labelYT.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyVideo_YouTubeLegal);
            textBoxDescription.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyVideo_TitleText);

            toolTipHelp.SetToolTip(buttonSave1,Localization.LanguageMgr.LM.GetText(Labels.ToolTip_Save));
        }

        void videoPlayer1_OnVideoError()
        {
            ShowError(Localization.LanguageMgr.LM.GetText(Labels.Error_LoadingVideo));
        }

        private void buttonOrange1_Click(object sender, EventArgs e)
        {
            if (OnOrangeClicked != null)
                OnOrangeClicked();
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            if (OnBlackClicked != null)
                OnBlackClicked();
        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy(this.videoPlayer1.Filename, saveFileDialog1.FileName);
            }
        }

        public string Title { get { return textBoxTitle.Text; } set { textBoxTitle.Text = value; } }
        public string Tags
        {
            get { return tagEditControl.GetTagsString(); }
            set { tagEditControl.AddTags(value); }
        }

        public string Description 
        {
 
            get { return textBoxDescription.Text; } 
            set 
            { 
                textBoxDescription.Text = value; 
            }
        }
        public string Category { get { return getCategory(); } }

        private delegate string getCategoryDelegate();

        private string getCategory()
        {
            if (this.InvokeRequired)
            {
                getCategoryDelegate d = new getCategoryDelegate(getCategory);
                return (string)this.Invoke(d);
            }
            else
            {
                return AppConfig.Instance.Terms[comboBoxCategories.SelectedIndex];
            }
       }

        public bool ValidateYouTube()
        {
            if (textBoxDescription.Text == "")
            {
                textBoxDescription.Focus();
                ShowError(Localization.LanguageMgr.LM.GetText(Labels.RembyVideo_CompleteDescription));
                return false;
            }
            if (!tagEditControl.GetTagsString().HasValue())
            {
                ShowError(Localization.LanguageMgr.LM.GetText(Labels.RembyVideo_CompeteTags));
                return false;
            }
            if (textBoxTitle.Text == "")
            {
                textBoxTitle.Focus();
                ShowError(Localization.LanguageMgr.LM.GetText(Labels.RembyVideo_CompleteTitle));
                return false;
            }
            return true;
        }

        public void ShowError(string text)
        {
            labelError.Text = text;
            labelError.Visible = true;
            pictureBoxError.Visible = true;
        }
        
        public void HideError()
        {
            labelError.Visible = false;
            pictureBoxError.Visible = false;
        }

        private void tagEditControl_TagsCollectionChanged(object sender, EventArgs e)
        {
            if (ValidateYouTube())
            {
                HideError();
            }
        }
    }
}
