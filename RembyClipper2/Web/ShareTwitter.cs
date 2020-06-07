using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using RembyClipper2.Utils;

namespace RembyClipper2.Web
{
    public class ShareTwitter
    {
        private string fbHTML = RembyConstants.RembyURL +  @"/twitter?text=Check%20out:%20{#ReplaceMacro}%20%23remby";

        public ShareTwitter(string text)
        {
            fbHTML = fbHTML.Replace("{#ReplaceMacro}", text);
            ShareBrowser sb = new ShareBrowser(false);
            sb.HTML = "";
            sb.URL = RembyConstants.RembyURL + @"/twitter?text=Check%20out:%20"+text+"%20%23remby"; ;
            sb.Show();
        }
    }
}
