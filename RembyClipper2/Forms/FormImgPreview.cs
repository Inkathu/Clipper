using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RembyClipper.Helpers;
using System.IO;
using RembyClipper2.Config;
using System.Web;
using RembyClipper2.Helpers;

namespace RembyClipper2.Forms
{
    public partial class FormImgPreview : RembyClipper2.Base.BaseForm
    {
        public FormImgPreview()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.Text = AppConfig.Lang.GetValue("Remby_ImgView_Title");
            }
            this.rembyScreenshot1.OnAddToRembyClicked += new Base.CustomButtonClicked(rembyScreenshot1_OnOrangeClicked);
            this.rembyLoginControl1.OnLoginButtonClicked += new Base.CustomButtonClicked(rembyLoginControl1_OnOrangeClicked);

            this.rembyDone1.OnBlackClicked += new Base.CustomButtonClicked(rembyDone1_OnBlackClicked);
            this.rembyLoginControl1.OnCloseButtonClicked += new Base.CustomButtonClicked(rembyDone1_OnBlackClicked);
            this.rembyScreenshot1.OnCloseClicked += new Base.CustomButtonClicked(rembyDone1_OnBlackClicked);
            this.rembyLoginControl1.OnCloseButtonClicked += new Base.CustomButtonClicked(rembyDone1_OnBlackClicked);
           
            this.FormClosing += new FormClosingEventHandler(FormImgPreview_FormClosing);

        }

        void FormImgPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rembyScreenshot1.IsOCRFinished == false)
            {
                e.Cancel = true;
                return;
            }
            AppConfig.topnav.RegisterCloseWindow(this);
        }

        void rembyDone1_OnBlackClicked()
        {
            this.Close();
        }

        private new enum WindowState { view, login, uploading, done }
//        private WindowState _currentState = WindowState.view;
        private WindowState _currentState = WindowState.login;

        private WindowState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; SetState(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetState();
        }

        private void SetState()
        {
            rembyScreenshot1.Visible = false;
            rembyLoginControl1.Visible = false;
            rembyUploading1.Visible = false;
            rembyDone1.Visible = false;

            if (_currentState == WindowState.view)
            {
                if (!this.Visible)
                    this.Show();
                rembyLoginControl1.Visible = true;
                _currentState = WindowState.login;
                return;
            }
            if (_currentState == WindowState.login)
            {
                this.Hide();
                AppConfig.topnav.OpenStatus(AppConfig.Lang.GetValue("TopNav_Uploading"),false);
                //rembyUploading1.Visible = true;
                _currentState = WindowState.uploading;
                return;
            }
            if (_currentState == WindowState.uploading)
            {
                //
                //"  'url': 'http://remby.commondatastorage.googleapis.com/tmp/tamashenning/media/screenshot/image/png/2011/01/000109414_1280_800_ahFyZW1ieS1tZWRpYS1zdG9yZXIMCxIERmlsZRiB-SsM.png'"

                string u = RembyServices.shortenURL();
                AppConfig.topnav.OpenStatus(msr.FileType+" "+AppConfig.Lang.GetValue("TopNav_Uploaded"), true, AppConfig.Instance.rembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(u), true, HttpUtility.UrlEncode(u));
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
                rembyScreenshot1.Visible = true;
                _currentState = WindowState.view;
                return;
            }
        }

        void rembyScreenshot1_OnOrangeClicked()
        {
            if (AppConfig.GetInstance().Password != "")
                rembyLoginControl1_OnOrangeClicked();
            else
                CurrentState = WindowState.view;
        }

        void rembyLoginControl1_OnOrangeClicked()
        {
            CurrentState = WindowState.login;
            BackgroundWorker bw = new BackgroundWorker();
            tag = rembyScreenshot1.Tag;
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
                CurrentState = WindowState.view;

            }
            else
                CurrentState = WindowState.uploading;
        }
        string tag = "";
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            rembyScreenshot1.Screenshot.Save("tmp.png");
            e.Result = RembyServices.uploadScreenShot("tmp.png", rembyScreenshot1.OCR, rembyScreenshot1.Source, tag);
        }

        private void FormImgPreview_Load(object sender, EventArgs e)
        {
            rembyScreenshot1.StartOCR();
            AppConfig.topnav.RegisterOpenWindow(this);
        }


    }
}
