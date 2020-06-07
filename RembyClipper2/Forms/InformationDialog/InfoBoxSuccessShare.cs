using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.Web;

namespace RembyClipper2.Forms.InformationDialog
{
    public partial class InfoBoxSuccessShare : InfoBoxSuccess
    {
        protected string _shareUrl;
        private string _encodedUrl;
        public InfoBoxSuccessShare()
        {
            InitializeComponent();
            _shareUrl = "";
            _encodedUrl = "";
        }

        public void Show(string caption, string message, string shareUrl, string encodedUrl, int seconds, bool showCountDown)
        {
            //captionLabel.Text = caption;
            _shareUrl = shareUrl;
            _encodedUrl = encodedUrl;
            Show(caption, message, seconds, showCountDown);
            //this.Invalidate();
        }

        private void googlePictureBox_Click(object sender, EventArgs e)
        {
            StopTimer();
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
                                                         {
                                                             Clipboard.SetDataObject(HttpUtility.UrlDecode(_encodedUrl), true, 5, 200);
                                                             //Clipboard.SetData(DataFormats.Text, HttpUtility.UrlDecode(_encodedUrl));

                                                             MessageBox.Show(
                                                                 LanguageMgr.LM.GetFormattedText(Labels.TopNav_ShortenUrlCopiedToClipBoardWithParam,
                                                                                                 HttpUtility.UrlDecode(_encodedUrl)),
                                                                 LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                         }));
            

        }

        private void facebookPictureBox_Click(object sender, EventArgs e)
        {

            StopTimer();
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            {
                var sf = new ShareFacebook(_encodedUrl);
            }));

            
        }

        private void twitterPictureBox_Click(object sender, EventArgs e)
        {
            StopTimer();
            AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            {
                var st = new ShareTwitter(_encodedUrl);
            }));

            
        }

    }
}
