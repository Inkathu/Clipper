using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper2.Drawing;
using RembyClipper2.Helpers;

namespace RembyClipper2.Forms
{
    public partial class RembyEditingForm : EditingForm
    {
        public bool saved = false;

        OCRForm ocr = new OCRForm();

        public string Source { get { return textBoxSource.Text; } set { textBoxSource.Text = value; } }
        private string src { get; set; }
        public new string Tag { get { return textBoxTags.Text; } }
        public string OCR { get { return ocr.OCRText; } }

        public RembyEditingForm()
        {
            InitializeComponent();
            ApplyLanguage();
            textBoxTags.Values = AppConfig.SupportedTags;
            
            this.rembyLoginControl1.OnLoginButtonClicked += new Base.CustomButtonClicked(processDataUpoloading);
            this.rembyDone1.OnBlackClicked += new Base.CustomButtonClicked(rembyDone1_OnBlackClicked);
            this.rembyLoginControl1.OnCloseButtonClicked += new Base.CustomButtonClicked(rembyDone1_OnBlackClicked);
            //this.rembyLoginControl1.OnCloseButtonClicked += new Base.CustomButtonClicked(rembyDone1_OnBlackClicked);
            this.FormClosing += new FormClosingEventHandler(FormImgPreview_FormClosing);
            this.Load += new EventHandler(RembyEditingForm_Load);
            if (AppConfig.topnav != null)
            {
                AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
            }


        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            Text = Localization.LanguageMgr.LM.GetText(Labels.RembyScrennshot_WindowTitle);
            btnAddToRemby.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_AddRemby);
            buttonBlack1.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Close);
            buttonOCR1.Text = Localization.LanguageMgr.LM.GetText(Labels.OCR);
            label2.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Tags);
            label1.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Source);
            tooltipHelp.SetToolTip(this.buttonCopy1, Localization.LanguageMgr.LM.GetText(Labels.ToolTip_Copy));
            tooltipHelp.SetToolTip(this.buttonOCR1, Localization.LanguageMgr.LM.GetText(Labels.ToolTip_OCR));
            tooltipHelp.SetToolTip(this.buttonSave1, Localization.LanguageMgr.LM.GetText(Labels.ToolTip_Save));
        }

        void RembyEditingForm_Load(object sender, EventArgs e)
        {
            StartOCR();
            AppConfig.topnav.RegisterOpenWindow(this);
        }

        void FormImgPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsOCRFinished == false)
            {
                ocr.CancelRecognition();
            }
            AppConfig.topnav.RegisterCloseWindow(this);
        }
        void rembyDone1_OnBlackClicked()
        {
            this.Close();
        }

        private new enum WindowState { view, login, uploading, done }
        private WindowState _currentState = WindowState.view;

        private WindowState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; SetState(); }
        }

        private void SetState()
        {
            //rembyScreenshot1.Visible = false;
            rembyLoginControl1.Visible = false;
            rembyUploading1.Visible = false;
            rembyDone1.Visible = false;

            if (_currentState == WindowState.view)
            {
                if (!this.Visible)
                    this.Show();
//                rembyLoginControl1.Visible = true;
                _currentState = WindowState.login;
                return;
            }
            if (_currentState == WindowState.login)
            {
                this.Hide();
                AppConfig.topnav.OpenStatus(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploading), false);
                //rembyUploading1.Visible = true;
                _currentState = WindowState.uploading;
                return;
            }
            if (_currentState == WindowState.uploading)
            {
                //
                //"  'url': 'http://remby.commondatastorage.googleapis.com/tmp/tamashenning/media/screenshot/image/png/2011/01/000109414_1280_800_ahFyZW1ieS1tZWRpYS1zdG9yZXIMCxIERmlsZRiB-SsM.png'"

                string u = RembyServices.shortenURL();
                AppConfig.topnav.OpenStatus(msr.FileType + " " + Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploaded), true, AppConfig.Instance.rembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(u), true, HttpUtility.UrlEncode(u));
                AppConfig.Instance.Store();
                rembyDone1.SetToRemby();
                rembyDone1.Visible = true;
                _currentState = WindowState.done;
                this.Close();
                AppConfig.topnav.RegisterCloseWindow(this);
                return;
            }
            if (_currentState == WindowState.done)
            {
                this.Close();
                //if (!this.Visible)
                //     this.Show();
                //rembyScreenshot1.Visible = true;
                _currentState = WindowState.view;
                return;
            }
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            this.saved = false;
            
            this.Close();
        }

        private void buttonOrange1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppConfig.GetInstance().Password))
            {
                processDataUpoloading();
            }
            else
            {
                if (TopNav.Login())
                {
                    processDataUpoloading();
                }
                else
                {
                    AppConfig.topnav.OpenStatus(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error), false);
                    if(!Visible && !IsDisposed)
                    {
                        Show();
                    }
                }

            }

        }

        void processDataUpoloading()
        {
            CurrentState = WindowState.login;
            BackgroundWorker bw = new BackgroundWorker();
            tag = Tag;
            src = Source;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }
        MediaStoreResponse msr;
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            msr = (MediaStoreResponse)e.Result;
            if (((MediaStoreResponse)e.Result).Status == false)
            {
                if(TopNav.Login())
                {
                    CurrentState = WindowState.login;
                }
                else
                {
                    AppConfig.topnav.OpenStatus(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error), false);
                    if(this.Visible == false && !this.IsDisposed)
                    {
                        this.Show();
                    }
                }
                

            }
            else
                CurrentState = WindowState.uploading;
        }
        string tag = "";
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Image.Save("tmp.png");
            e.Result = RembyServices.uploadScreenShot("tmp.png", OCR, src, tag);
        }

        public bool IsOCRFinished { get { return this.ocr.isOCRFinished; } }

        public void StartOCR()
        {
            this.ocr.DoOCR(Image);
        }

        public void ShowError(string text)
        {
            labelError.Text = text;
            labelError.Visible = true;
            pictureBoxError.Visible = true;
        }

        private void buttonOrange1_Load(object sender, EventArgs e)
        {

        }

        protected Image Image
        {
            get { return surface.GetImageForExport(); }
        }
        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                
                Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void buttonCopy1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(Image);
            //toolTip1.SetToolTip(buttonCopy1, "Image copied to your clipboard");
            toolTip1.ToolTipTitle = "Clipboard";
            toolTip1.ShowCustom(Localization.LanguageMgr.LM.GetText(Labels.RembyScreenshot_CopiedToClipboard), buttonCopy1);
            //AppConfig.Lang.GetValue

        }

        private void buttonOCR1_Click(object sender, EventArgs e)
        {
            if (ocr == null || ocr.IsDisposed)
                ocr = new OCRForm();
            ocr.ShowDialog(this);

        }

    }
}
