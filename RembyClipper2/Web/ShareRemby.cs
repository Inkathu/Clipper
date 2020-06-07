using System;
using System.Collections.Generic;
using System.Text;

namespace RembyClipper2.Web
{
    public class ShareRemby
    {
        public ShareRemby(string URL)
        {
            ShareBrowser sb = new ShareBrowser(false);
            sb.HTML = "";
            sb.URL = URL;
            sb.Size = new System.Drawing.Size(1024, 768);
            sb.ShowDialog();
        }
    }
}
