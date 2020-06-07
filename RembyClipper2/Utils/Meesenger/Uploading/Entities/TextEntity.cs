using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Web;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Forms;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.UploadingStrategies;

namespace RembyClipper2.Utils.Uploading.Entities
{
    public class TextEntity : UploadEntityBase
    {

        public string Text { get; set; }

        public TextEntity()
        {
            Name = LanguageMgr.LM.GetText(Labels.InfoBox_Text);
        }

        public override void Upload()
        {
            Init();
            UploadStatus.Status = Status.InProgress;
            UploadStatus.PercentUploaded = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc["description"] = Text;
            nvc["text"] = Text;
            nvc["tags"] = Tags;
            MediaStoreResponse result;
//            result = RembyServices.uploadToMediaStore(nvc, RembyServices.MediaStoreTypes.text);
            result = Uploader.UploadText(Text, Text, Tags, Context);

            if(!result.Status)
            {
                UploadStatus.Status = Status.Error;
                InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                DebugHelper.Log("An error occurred in attempt to upload text entity");
                FailUploadingAction();
            }
            else
            {
                UploadStatus.Status = Status.Uploaded;
                string u = result.short_url;
                ShortUrl = u;
                InfoBoxDispatcher.ShowSuccessShare(result.FileType + " " + Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploaded), RembyConstants.RembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(u), HttpUtility.UrlEncode(u));
                SuccessUploadingAction();
                
            }
                
        }

        public override UploadEntityBase Init()
        {
            string s = Name + " - " + Text;
            Caption = s.Length > 35 ? (s).Substring(0, 35) + "..." : s;
            return this;
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

                var form = new FormQuicktext()
                               {
                                   EnteredTags = Tags,
                                   EnteredText = Text
                               };
                AppConfig.topnav.BeginInvoke((MethodInvoker)form.Show);
            }
        }

    }
}