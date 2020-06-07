using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
    public class ScreenShootEntity : UploadEntityBase
    {
        public string Description { get; set; }
        public Image Image { get; set; }
        public string OCR { get; set; }
        public string SRC { get; set; }
        public string FileName { get; set; }
        public bool IsScreenShot { get; set; }
        public ScreenShootEntity()
        {
            Name = LanguageMgr.LM.GetText(Labels.InfoBox_ScreenShoot);
        }

        public override void Upload()
        {
            FileInfo finfo = null;
            try
            {
                FileName = FileName.Replace(":", "_");
                finfo = new FileInfo(FileName);
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());   
            }
            string file = "screenShot" + (finfo == null ? ".png" : finfo.Extension);
            Image.Save(file);

            UploadStatus.Status = Status.InProgress;
            UploadStatus.PercentUploaded = 0;
            var response = Uploader.UploadFile(file.ToLower(), FileName, Description.HasValue() ? Description : OCR, OCR, Tags, Context, "", IsScreenShot ? UploadEntityRole.screenshot : UploadEntityRole.unknown);
            if(!response.Status)
            {
                UploadStatus.Status = Status.Error;
                InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                DebugHelper.Log("An error occurred in attempt to upload screenshot entity. \r\n" + UploadStatus.Error);
                FailUploadingAction();
            }else
            {
                UploadStatus.PercentUploaded = 100;
                UploadStatus.Status = Status.Uploaded;
                string u = response.short_url;
                ShortUrl = u;
                //AppConfig.topnav.OpenStatus(msr.FileType + " " + Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploaded), true, AppConfig.Instance.rembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(u), true, HttpUtility.UrlEncode(u));

                InfoBoxDispatcher.ShowSuccessShare(response.FileType + " " + Localization.LanguageMgr.LM.GetText(Labels.TopNav_Uploaded), RembyConstants.RembyURL + "/go/newpage?secu=" + RembyClipper.Helpers.RembyServices.securityID + "&url=" + HttpUtility.UrlEncode(u), HttpUtility.UrlEncode(u));
                SuccessUploadingAction();

            }

            
        }

        public override UploadEntityBase Init()
        {
            var s = (Name + " - " + SRC);
            Caption = s.Length > 35 ? s.Substring(0, 35) + "..." : s;
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

                RembyScreenshotNew form = new RembyScreenshotNew();
                form.Image = Image;
                form.Tag = Tags;
                form.Source = SRC;
                AppConfig.topnav.BeginInvoke((MethodInvoker)form.Show);
            }
        }
    }
}