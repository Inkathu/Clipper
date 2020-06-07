using System;
using System.Collections.Generic;
using System.Text;
using RembyClipper2.Config;
using RembyClipper2.Properties;
using RembyClipper2.Utils;

namespace RembyClipper2.Web
{
    public class WebLogout
    {
        ShareBrowser sb = new ShareBrowser(false);
        public WebLogout()
        {
            sb.HTML = "";
            //sb.URL = RembyConstants.RembyURL + "/logout";
            sb.URL = Settings.Default.CurrentUsedServiceUrl + "/logout";
            if (sb.URL.Contains("https"))
            {
                sb.URL = sb.URL.Replace("https", "http");    
            }
            
            //sb.URL = @"http://staging.remby .com/apps/tamas/test.html";
            // sb.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            sb.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            sb.ShowDialog();
        }

        void webBrowser1_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        {
            object o = sb.webBrowser1.Document;
            //sb.webBrowser1.Document.
            sb.Close();
        }

        void webBrowser1_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            object o = sb.webBrowser1.Document;
            sb.Close();
        }
    }
}
