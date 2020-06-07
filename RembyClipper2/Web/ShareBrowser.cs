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
using RembyClipper2.Utils;

namespace RembyClipper2.Web
{
    public partial class ShareBrowser : Form
    {
        private bool _automatic;
        public ShareBrowser(bool automatic)
        {
            InitializeComponent();
            _automatic = automatic;
            this.Icon = global::RembyClipper2.NewDesign.clipper32x32;
        }

        public string URL { get; set; }
        public string HTML { get; set; }

        public bool clearCookies = false;

        private void ShareBrowser_Load(object sender, EventArgs e)
        {
            if (URL != "")
            {
                if (clearCookies)
                    ClearCookies();
                webBrowser1.Navigate(URL);
            }
            if (HTML != "")
            {
                webBrowser1.Navigate("about:blank");
                webBrowser1.DocumentText = HTML;
                //webBrowser1.Document.
            }
        }

        public void ClearCookies()
        {

            //webBrowser1.Navigate(RembyConstants.RembyURL + @"/logout");

            //webBrowser1.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            if(_automatic)
            {
                if(webBrowser1.Document != null )
                {
                    HtmlElement login = webBrowser1.Document.GetElementById("edit-name-1");
                    HtmlElement password = webBrowser1.Document.GetElementById("edit-pass");
                    if (login != null && password != null)
                    {
                        login.SetAttribute("value", AppConfig.Instance.Username);
                        password.SetAttribute("value", AppConfig.Instance.Password);
                        HtmlElement button = webBrowser1.Document.GetElementById("edit-submit-1");
                        if (button != null)
                        {
                            button.InvokeMember("click");    
                        }
                    }
                }
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.AbsoluteUri == "http://www.remby.com/close")
            {
                this.Close();
                return;
            }
            pictureBox1.Visible = true;
            if (webBrowser1.Document != null)
            {
                HtmlElement login = webBrowser1.Document.GetElementById("edit-name-1");
                HtmlElement password = webBrowser1.Document.GetElementById("edit-pass");
                if (login != null && password != null)
                {
                    AppConfig.Instance.Username = login.GetAttribute("value");
                    //AppConfig.Instance.Password = password.GetAttribute("value");
                }
            }

        }

        private void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            int i = 0;
        }
    }
}
