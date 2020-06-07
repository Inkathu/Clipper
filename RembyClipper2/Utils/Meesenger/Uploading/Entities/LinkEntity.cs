using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
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
    class LinkEntity : UploadEntityBase
    {
        protected RembyServices.MediaStoreTypes _mediaStoreType;

        public string Link { get; set; }
        public string DrupalName { get; set; }
        public LinkEntity()
        {
            Name = LanguageMgr.LM.GetText(Labels.InfoBox_Link);
            _mediaStoreType = RembyServices.MediaStoreTypes.link;
            DrupalName = "";
        }

        public override void Upload()
        {
            Init();
            UploadStatus.Status = Status.InProgress;
            UploadStatus.PercentUploaded = 0;
            NameValueCollection nvc = new NameValueCollection();
            nvc["url"] = Link;
            nvc["description"] = Link;
            nvc["tags"] = Tags;
            MediaStoreResponse result;
            if(Link.Length >500)
            {
                UploadStatus.Status = Status.Error;
                InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.LinkTooIsToLong));
                FailUploadingAction();
                return;
            }
//            result = RembyServices.uploadToMediaStore(nvc, _mediaStoreType);
            result = Uploader.UploadUrl(Link, "", Tags, Context, DrupalName);

            if (!result.Status)
            {
                UploadStatus.Status = Status.Error;
                InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                DebugHelper.Log("An error occurred in attempt to upload link entity");
                FailUploadingAction();
            }
            else
            {
                string u = result.short_url;
                ShortUrl = u;
                InfoBoxDispatcher.ShowSuccessShare(result.FileType + " " + Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploaded), RembyConstants.RembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(u), HttpUtility.UrlEncode(u));
                UploadStatus.Status = Status.Uploaded;
                SuccessUploadingAction();

            }
            
        }

        public override UploadEntityBase Init()
        {
            string s = Name + " - " + Link;
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
                                   EnteredText = Link
                               };
                AppConfig.topnav.BeginInvoke((MethodInvoker)form.Show);
            }
        }
    }
}
