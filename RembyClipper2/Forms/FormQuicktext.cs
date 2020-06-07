using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.Base;
using System.Collections.Specialized;
using RembyClipper.Helpers;
using System.Runtime.InteropServices;
using System.Web;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Meesenger.Uploading;
using RembyClipper2.Utils.Uploading;
using RembyClipper2.Utils.Uploading.Entities;
using System.Linq;

namespace RembyClipper2.Forms
{
    public partial class FormQuicktext : BaseForm
    {


        public FormQuicktext()
        {
            InitializeComponent();
            //autoCompleteTextBox1.Values = AppConfig.SupportedTags;
            tagEditControl1.SetTagsCollection(new List<string>(AppConfig.SupportedTags));
            //AppConfig.topnav.SetRegion(this, this.Size);
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(richTextBox1_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
            ApplyLanguage();
            FormClosing += new FormClosingEventHandler(FormQuicktext_FormClosing);
            btnUpload.Enabled = richTextBox1.Text.Length > 0;
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
            if (!string.IsNullOrEmpty(AppConfig.Instance.LastUsedTags))
            {
                tagEditControl1.AddTags(AppConfig.Instance.LastUsedTags);
            }
        }


        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        void FormQuicktext_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.topnav.RegisterCloseWindow(this);
        }

        private void ApplyLanguage()
        {
            btnUpload.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_AddRemby);
            btnClose.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Close);
            Text = Localization.LanguageMgr.LM.GetText(Labels.RembyText_WindowTitle);
            label1.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Tags);
        }

        void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + e.Data.GetData(DataFormats.Text).ToString();
        }

        void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        protected FormQuicktext(bool ignore)
        {
            InitializeComponent();
            tagEditControl1.SetTagsCollection(new List<string>(AppConfig.SupportedTags));
        }

        public bool GrowDownwards = false;

        private void FormQuicktext_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Focus();
                richTextBox1.Focus();
                //SetForegroundWindow(this.Handle);
                AppConfig.topnav.RegisterOpenWindow(this);
                
            }
        }


        //void autoCompleteTextBox1_onWordAdded()
        //{
        //    wordadded = true;
        //}

        private void richTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            //richTextBox1.Height = e.NewRectangle.Height + 8;
            //if (GrowDownwards)
            //    this.Height = e.NewRectangle.Height + autoCompleteTextBox1.Height + 64;
            //else
            //    this.Height = e.NewRectangle.Height + autoCompleteTextBox1.Height + 24;
            //if (this.Height < 56)
            //    this.Height = 56;
            //if (GrowDownwards)
            //    autoCompleteTextBox1.CustomPosition = new Point(autoCompleteTextBox1.Location.X, autoCompleteTextBox1.Location.Y + 32);
            //else
            //    autoCompleteTextBox1.CustomPosition = new Point(autoCompleteTextBox1.Location.X, autoCompleteTextBox1.Location.Y - 32);
        }

        protected virtual void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string EnteredText
        {
            get { return richTextBox1.Text; }
            set
            {
                richTextBox1.Text = value;
                btnUpload.Enabled = richTextBox1.Text.Length > 0;
            }
        }

        public string EnteredTags
        {
            get { return tagEditControl1.GetTagsString(); }
            set { tagEditControl1.AddTags(value); }
        }

        protected virtual void UploadButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            var lastUsedTags = tagEditControl1.GetTagsString();
            AppConfig.Instance.LastUsedTags = lastUsedTags;
            AppConfig.Instance.Store();

            Regex urlRegEx = new Regex(@"^(ht|f)tp(s?)\:\/\/(([a-zA-Z0-9\-\._]+(\.[a-zA-Z0-9\-\._]+)+)|localhost)(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?([\d\w\.\/\%\+\-\=\&amp;\?\:\\\&quot;\'\,\|\~\;]*)$");

            if (urlRegEx.IsMatch(richTextBox1.Text))
            {
                UploadDispatcher.Instance.Upload(new LinkEntity()
                {
                    CallerForm = this,
                    Link= richTextBox1.Text,
                    Tags = lastUsedTags,
                    Context = "",
                    DrupalName = ""
                }.Init());
            }
            else
            {
                UploadDispatcher.Instance.Upload(new TextEntity()
                {
                    CallerForm = this,
                    Text = richTextBox1.Text,
                    Tags = lastUsedTags,
                    Context = ""
                }.Init());
            }


        }

        private void RichTextBox1KeyUp(object sender, KeyEventArgs e)
        {
            if(!string.IsNullOrEmpty(richTextBox1.Text) && e.KeyCode == Keys.Enter && e.Modifiers == Keys.Shift)
            {
                btnUpload.PerformClick();
            }
        }



        private void FormQuicktext_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            btnUpload.Enabled = richTextBox1.Text.Length > 0;
        }

        private void FormQuicktext_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppConfig.topnav.RegisterCloseWindow(this);
        }
    }
}
