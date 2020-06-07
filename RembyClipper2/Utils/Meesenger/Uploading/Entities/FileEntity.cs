using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper2.Forms;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.UploadingStrategies;

namespace RembyClipper2.Utils.Uploading.Entities
{
    public class FileEntity : UploadEntityBase
    {
        public string File { get; set; }



        public FileEntity()
        {
            Name = LanguageMgr.LM.GetText(Labels.InfoBox_File);

        }

        public override void Upload()
        {
            Init();

            TopNav.UploadFilesResult result = UploadFile(File, Tags, Context);
            if (result.response.Status)
            {
                string u = result.response.short_url;
                ShortUrl = u;
                InfoBoxDispatcher.ShowSuccessShare(result.response.FileType + " " + Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploaded), RembyConstants.RembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(u), HttpUtility.UrlEncode(u));
                UploadStatus.Status = Status.Uploaded;
                SuccessUploadingAction();
            }
            else
            {
                UploadStatus.Status = Status.Error;
                if (result.ErrorMessage.HasValue())
                {
                    InfoBoxDispatcher.ShowError(result.ErrorMessage);
                    DebugHelper.Log("An error occurred in attempt to upload file entity. The reason - " + result.ErrorMessage);
                }
                else
                {
                    InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                    DebugHelper.Log("An error occurred in attempt to upload file entity. The reason is unknown.");
                }
                
                FailUploadingAction();
            }
           
        }

        public override UploadEntityBase Init()
        {
            FileInfo fi = new FileInfo(File);
            string s = Name +" - " + fi.Name;
            Caption = s.Length > 35 ? (s).Substring(0, 35) + "..." : s;
            return this;
        }

        public override void Open()
        {
            if(UploadStatus.Status ==Status.Uploaded)
            {
                var t = new Process();
                t.StartInfo.FileName = ShortUrl;
                t.Start();

            }
            else
            {

                AppConfig.topnav.BeginInvoke((MethodInvoker)(() => FormFileUpload.AddFileToList(File)));

//                FormFileUpload frm = new FormFileUpload(new List<string>() { File });
//                frm.Show(AppConfig.topnav);
            }
        }


        public static TopNav.UploadFilesResult UploadFile(string file, string tags, string context, bool uploadingToYoutube = true, FileEntity entity = null)
        {
            if(file == null)
            {
                throw new Exception("file can't be empty");
            }
            string youtubeLinks = "";
           
            
            var ufr = new TopNav.UploadFilesResult();
            ufr.response = new MediaStoreResponse();
            var badFileTypes = new List<string>();
            badFileTypes.AddRange(AppConfig.Instance.BannedFileTypes);

            var videoFiles = new List<string>();
            videoFiles.AddRange(AppConfig.Instance.SupportedVideoFiles);


            if (!string.IsNullOrEmpty(file) && System.IO.Path.GetExtension(file) != null && badFileTypes.Contains(System.IO.Path.GetExtension(file).Replace(".", "")))
            {
                ufr.ErrorMessage = LanguageMgr.LM.GetFormattedText(Labels.TopNav_UnsupportedExtension, System.IO.Path.GetExtension(file), System.IO.Path.GetFileName(file));
                DebugHelper.Log(file + " has been flagged");
                ufr.Errors++;
                ufr.response.status = "error";
                return ufr;
            }

            if (!string.IsNullOrEmpty(file) && System.IO.Path.GetExtension(file) != null && videoFiles.Contains(System.IO.Path.GetExtension(file).Replace(".", "").ToLower()))
            {
                if (uploadingToYoutube)
                {
                    YouTubeHelper.YouTubeCategory = AppConfig.Instance.Categories[0];
                    YouTubeHelper.YouTubeDescription = LanguageMgr.LM.GetText(Labels.TopNav_YouTubeDescription);
                    YouTubeHelper.YouTubeTags = tags;
                    YouTubeHelper.YouTubeTitle = LanguageMgr.LM.GetText(Labels.TopNav_YouTubeTitle);
                    bool res = YouTubeHelper.UploadVideo(file);
                    if (!res)
                    {
                        ufr.Errors++;
                        ufr.response.status = "error";
                        return ufr;
                    }
                    youtubeLinks += "http://www.youtube.com/watch?v=" + YouTubeHelper.VideoID + "\n";
                }
                else
                {
                    //uploading to legacy storage
                    //not implemented yet
                    ufr.Errors++;
                    ufr.response.status = "error";
                    return ufr;

                }
                ufr.Uploaded++;
                ufr.response.status = "success";
                return ufr;

            }
            FileInfo info = new FileInfo(file);
            try
            {
                //is file an image?
                using(Image i = ImageHelper.LoadFromFile(file))
                {
                    ufr.response = Uploader.UploadFile(file.ToLower(), info.Name, "", "", tags, context);
                }
            }
            catch(Exception exc)
			{
                DebugHelper.Log(exc.ToString());
			

                ufr.response = Uploader.UploadFile(file.ToLower(), info.Name, "", "", tags, context);
            }
            return ufr;
        }
    }
}
