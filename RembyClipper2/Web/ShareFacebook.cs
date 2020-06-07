using System;
using System.Collections.Generic;
using System.Text;
using RembyClipper2.Utils;

namespace RembyClipper2.Web
{
    public class ShareFacebook
    {

        private string fbHTML = @"http://www.facebook.com/dialog/feed?
  app_id=199701656708216&
  link=" + RembyConstants.RembyURL +@"/go?url={#ReplaceMacro}&
  message={#ReplaceMacro}&redirect_uri=http://www.remby.com/close&
display=popup";

        public ShareFacebook(string text)
        {
            fbHTML = fbHTML.Replace("{#ReplaceMacro}", text);
            ShareBrowser sb = new ShareBrowser(false);
            sb.HTML = "";
            sb.URL = fbHTML;
            sb.Show();
        }
    }
}
