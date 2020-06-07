using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Forms;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Utils.Uploading.UploadingStrategies;

namespace RembyClipper2.Utils.Uploading.Entities
{
    public class YouTubeVideoEntity : UploadEntityBase
    {
        public Image Image { get; set; }
        public string SRC { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description{ get; set; }
        public string File{ get; set; }
        public string DrupalName { get; set; }
        public YouTubeVideoEntity()
        {
            Name = LanguageMgr.LM.GetText(Labels.InfoBox_Video);
            DrupalName = "";
        }

        public override void Upload()
        {
            UploadStatus.Status = Status.InProgress;
            UploadStatus.PercentUploaded = 0;

            #region
            //rembyYouTubeControl1.InitYouTube();
            YouTubeHelper.YouTubeCategory = Category;
            YouTubeHelper.YouTubeDescription = Description;
            YouTubeHelper.YouTubeTags = Tags;
            YouTubeHelper.YouTubeTitle = Title;
            bool result = YouTubeHelper.UploadVideo(File);
            
            DebugHelper.Log("Youtube uploaded");
            string shUrl = "";
            if (result)
            {
                NameValueCollection c = new NameValueCollection();
                string source_url = "http://www.youtube.com/watch?v=" + YouTubeHelper.VideoID;
                c["source_url"] = source_url;
                c["description"] = Description;
                c["tags"] = Tags;
//                var response = RembyServices.uploadToMediaStore(File + ".png", c, RembyServices.MediaStoreTypes.video_thumb);
                //var response = Uploader.UploadFile(File + ".png", Description, "", Tags, source_url, UploadEntityRole.unknown);
                var response = Uploader.UploadUrl(source_url, Description, Tags, Context, DrupalName);
                result = response.Status;
                shUrl = response.short_url;
                DebugHelper.Log("Mediastore uploaded");
            }

            #endregion

            if (!result)
            {
                UploadStatus.Status = Status.Error;
                switch (YouTubeHelper.UploadError)
                {
                    case YouTubeHelper.YouTubeErrors.InvalidCredentials:
                        InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.YouTube_InvalidCredentials));
                        break;
                    case YouTubeHelper.YouTubeErrors.ValidationError:
                        InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.YouTube_ValidationError));
                        break;
                    case YouTubeHelper.YouTubeErrors.InternalServerError:
                        InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                        DebugHelper.Log("An error occurred in attempt to upload youtube entity. Internal server error");
                        break;
                    case YouTubeHelper.YouTubeErrors.None:
                        break;
                    default:
                        InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                        DebugHelper.Log("An error occurred in attempt to upload youtube entity. The reason is unknown.");
                        break;
                }
                CallerForm.Tag = "credentials";
                FailUploadingAction();
            }
            else
            {

                UploadStatus.PercentUploaded = 100;
                UploadStatus.Status = Status.Uploaded;
                string u = shUrl;
                ShortUrl = u;
                
                InfoBoxDispatcher.ShowSuccessShare(LanguageMgr.LM.GetText(Labels.InfoBox_Video) + " " + Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploaded), u, HttpUtility.UrlEncode(u));

                SuccessUploadingAction();


            }
            
        }

        public override void Open()
        {
            if (UploadStatus.Status == Status.Uploaded)
            {
                var t = new Process();
                t.StartInfo.FileName = ShortUrl;
                t.Start();

            }
            else
            {

                var fvp = new FormVideoPlayer();
                GC.KeepAlive(fvp);

                fvp.rembyVideo1.videoPlayer1.Filename = File;
                fvp.rembyVideo1.videoPlayer1.ParentForm = fvp;
                fvp.rembyVideo1.videoPlayer1.Init();
                fvp.rembyVideo1.Title = Title;

                fvp.rembyVideo1.comboBoxCategories.Items.AddRange(AppConfig.Instance.Categories);
                fvp.rembyVideo1.comboBoxCategories.SelectedIndex = 6;

                fvp.Show();
            }
        }

        public override UploadEntityBase Init()
        {
            var s = (Name + " - " + Title);
            Caption = s.Length > 35 ? s.Substring(0, 35) + "..." : s;
            return this;
        }
    }
}