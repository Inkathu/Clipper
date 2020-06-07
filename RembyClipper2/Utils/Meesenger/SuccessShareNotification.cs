using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Web;

namespace RembyClipper2.Utils.Meesenger
{
    public partial class SuccessShareNotification : NotificationBase
    {
        public string ShareUrl { get; set; }
        public string EncodedUrl { get; set; }

        public SuccessShareNotification(string encodedUrl)
        {
            InitializeComponent();
            EncodedUrl = encodedUrl;

            link.Text = HttpUtility.UrlDecode(EncodedUrl);
            shareToLabel.Text = LanguageMgr.LM.GetLabelText(Labels.ShareTo);
            copyButton.Text = LanguageMgr.LM.GetText(Labels.Copy);
            availableAtLabel.Text = LanguageMgr.LM.GetText(Labels.SuccessShare_AvailableAt);
        }


        private void googlePictureBox_Click(object sender, EventArgs e)
        {
            //CanBeRemoved = false;
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            {
                Clipboard.SetDataObject(HttpUtility.UrlDecode(EncodedUrl), true, 5, 200);
                //Clipboard.SetData(DataFormats.Text, HttpUtility.UrlDecode(_encodedUrl));
                InfoBoxDispatcher.ShowSimple(LanguageMgr.LM.GetFormattedText(Labels.TopNav_ShortenUrlCopiedToClipBoardWithParam,
                                                    HttpUtility.UrlDecode(EncodedUrl)));
                //MessageBox.Show(
                //    LanguageMgr.LM.GetFormattedText(Labels.TopNav_ShortenUrlCopiedToClipBoardWithParam,
                //                                    HttpUtility.UrlDecode(EncodedUrl)),
                //    LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));


        }

        private void facebookPictureBox_Click(object sender, EventArgs e)
        {

            //CanBeRemoved = false;
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            {
                var sf = new ShareFacebook(EncodedUrl);
            }));


        }

        private void twitterPictureBox_Click(object sender, EventArgs e)
        {
            //CanBeRemoved = false;
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            {
                var st = new ShareTwitter(EncodedUrl);
            }));


        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            {
                Process t = new Process();
                t.StartInfo.FileName = HttpUtility.UrlDecode(EncodedUrl);
                t.Start();
            }));
        }

        private void grayButton1_Click(object sender, EventArgs e)
        {
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            {
                Clipboard.SetDataObject(HttpUtility.UrlDecode(EncodedUrl), true, 5, 200);
                InfoBoxDispatcher.ShowSimple(LanguageMgr.LM.GetFormattedText(Labels.TopNav_ShortenUrlCopiedToClipBoardWithParam,
                                                    HttpUtility.UrlDecode(EncodedUrl)));
            }));
        }

    }
}
