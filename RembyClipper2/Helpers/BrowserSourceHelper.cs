using System;
using System.Text;
using RembyClipper2.Utils;

namespace RembyClipper2.Helpers
{
    public class BrowserSourceHelper
    {
        public static string GetFireFoxSource()
        {
            string res = "";
            NDde.Client.DdeClient dde = new NDde.Client.DdeClient("Firefox", "WWW_GetWindowInfo");
            dde.Connect();
            string url = dde.Request("URL", int.MaxValue);
            string[] urls = url.Split(new char[] { ',' });
            dde.Disconnect();
            res = urls[0].Replace("\"", "");
            res = AddProtocolIfRequired(res);
            return res;

        }

        public static string GetIESource()
        {
            string res = "";
            NDde.Client.DdeClient dde = new NDde.Client.DdeClient("iexplore", "WWW_GetWindowInfo");
            dde.Connect();
            string url = dde.Request("1", int.MaxValue);
            string[] urls = url.Split(new char[] { ',' });
            dde.Disconnect();
            res = urls[0].Replace("\"", "");
            res = AddProtocolIfRequired(res);
            return res;
        }    
        
        public static string GetChromeSource(IntPtr chromeHandle)
        {
            string res = "";
            const int maxPath = 255;

            IntPtr hAddressBox = WIN32_API.FindWindowEx(chromeHandle, IntPtr.Zero,
                                                        "Chrome_OmniboxView", String.Empty);

            StringBuilder sb = new StringBuilder(maxPath);

            WIN32_API.SendMessage(hAddressBox, WIN32_API.WM_GETTEXT, (IntPtr)maxPath, sb);

            res = sb.ToString().Trim(new Char[] { ' ', '\0', '\n' });
            res = AddProtocolIfRequired(res);
            return res;
        }
 
        public static string GetSafariSource(IntPtr safari)
        {
            string res = "";
            const int maxPath = 255;

            IntPtr hAddressBox = WIN32_API.FindWindowEx(safari, IntPtr.Zero,
//                                                        "WebViewWindowClass", String.Empty);
                                                        "WebKit2WebViewWindowClass", String.Empty);
            hAddressBox = new IntPtr(0x7c1428);
            StringBuilder sb = new StringBuilder(maxPath);

            WIN32_API.SendMessage(hAddressBox, WIN32_API.WM_GETTEXT, (IntPtr)maxPath, sb);

            res = sb.ToString().Trim(new Char[] { ' ', '\0', '\n' });
            res = AddProtocolIfRequired(res);
            return res;
        }

        private static string AddProtocolIfRequired(string res)
        {
            if (res.HasValue() && !res.Contains("://"))
            {
                res = "http://" + res;
            }
            return res;
        }
    }
}