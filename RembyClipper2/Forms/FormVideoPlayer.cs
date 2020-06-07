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
using RembyClipper2.Base;
using System.IO;
using System.Collections.Specialized;
using System.Web;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Helpers;
using RembyClipper2.Utils;
using RembyClipper2.Utils.Meesenger.Uploading;
using RembyClipper2.Utils.Uploading;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Forms
{
    public partial class FormVideoPlayer : BaseForm
    {
        public FormVideoPlayer()
        {
            InitializeComponent();

            this.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyVideo_WindowTitle);
            this.Load += new EventHandler(FormVideoPlayer_Load);
            this.FormClosing += new FormClosingEventHandler(FormVideoPlayer_FormClosing);

            rembyVideo1.OnOrangeClicked += new Base.CustomButtonClicked(rembyVideo1_OnOrangeClicked);

            rembyVideo1.OnBlackClicked += new Base.CustomButtonClicked(rembyVideo1_OnBlackClicked);
            this.DisableAntiFlicker = true;
            rembyVideo1.BringToFront();
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
            this.AcceptButton = rembyVideo1.btnAddToRemby;
            this.CancelButton = rembyVideo1.btnCancel;
        }

        void ShowYoutube()
        {
            string tag = Tag as string;
            if(tag.HasValue() && tag == "credentials")
            {
                Tag = null;
                rembyVideo1_OnOrangeClicked();
            }
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            rembyVideo1.ApplyLanguage();
        }

        void FormVideoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.topnav.RegisterCloseWindow(this);
        }

        void FormVideoPlayer_Load(object sender, EventArgs e)
        {

            ContextSensitiveFramework.Instance.CheckContext(rembyVideo1.Title);
            if (!loginOnly)
            {
                rembyVideo1.videoPlayer1.Init();
                AppConfig.topnav.RegisterOpenWindow(this);
                if (!string.IsNullOrEmpty(AppConfig.Instance.LastUsedTags))
                {
                    rembyVideo1.Tags = AppConfig.Instance.LastUsedTags;
                }
            }
        }

        void rembyVideo1_OnBlackClicked()
        {
            this.Close();
        }


        public bool loginOnly = false;


       
        void rembyVideo1_OnOrangeClicked()
        {

            if (string.IsNullOrEmpty(AppConfig.GetInstance().Password))
            {
                DebugHelper.Log("It looks like user has not beeb logged in, tryingto fix this");
                if (!TopNav.Login())
                {

                    InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                    DebugHelper.Log("An error occurred in attempt to login the user");
                    if (!Visible && !IsDisposed)
                    {
                        Show();
                        
                    }
                    return;
                }
            }

            
            if (rembyVideo1.ValidateYouTube())
            {
                if (AppConfig.Instance.VideoFirstTimeExperienceShown == false)
                {
                    FirstUserExperience fue = new FirstUserExperience();
                    fue.TopMost = true;
                    fue.ShowDialog(this);
                    if (fue.thisCancel == true)
                        return;
                }

                Upload();

            }
        }

        private void Upload()
        {
            if(YouTubeHelper.UploadError == YouTubeHelper.YouTubeErrors.InvalidCredentials || !AppConfig.YTUsername.HasValue() || !AppConfig.YTPassword.HasValue())
            {
                if(YouTubeHelper.UploadError == YouTubeHelper.YouTubeErrors.InvalidCredentials)
                {
                    AppConfig.YTValid = false;
                    AppConfig.YTUsername = "";
                    AppConfig.YTPassword = "";
                }
                FormYouTubeLogin form = new FormYouTubeLogin();
                var res = form.ShowDialog(this);
                if(res == DialogResult.Cancel)
                {
                    
                    return;
                } 
            }

            //at this point we should have initialized youtube part
            var yt = new YouTubeVideoEntity()
                         {
                             Category = rembyVideo1.Category,
                             Description = rembyVideo1.Description,
                             Tags = rembyVideo1.Tags,
                             Title = rembyVideo1.Title, 
                             CallerForm = this,
                             File = rembyVideo1.videoPlayer1.Filename, 
                             Context = rembyVideo1.Description.Contains("://") ? rembyVideo1.Description : ""
                         }.Init();

            UploadDispatcher.Instance.Upload(yt);
            this.Hide();

        }

        private void FormVideoPlayer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FormVideoPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
    }
}
