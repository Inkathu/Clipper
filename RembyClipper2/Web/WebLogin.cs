using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RembyClipper2.Config;
using RembyClipper.Helpers;
using RembyClipper2.Utils;
using SmartAssembly.Attributes;

namespace RembyClipper2.Web
{
    [DoNotObfuscate]
    [DoNotObfuscateControlFlow]
    [DoNotEncodeStrings]
    [DoNotSealType]
    [DoNotPrune]
    [ComVisibleAttribute(true)]
    public class WebLogin
    {
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        public WebLogin(bool automatic)
        {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            ShareBrowser sb = new ShareBrowser(automatic);
            sb.HTML = "";
            sb.URL = "http://www.remby.com/collector-login";//RembyConstants.RembySignUpLink + @"/collector-login ";
            //sb.URL = RembyConstants.RembySignUpLink + @"/collector-login ";
            sb.webBrowser1.ObjectForScripting = new WebLoginMethods(sb);
            
            ((WebLoginMethods)(sb.webBrowser1.ObjectForScripting)).loginResult(""); // prevent dead code removal in obfuscator.
            sb.clearCookies = true; 
            //
            sb.ShowDialog();
            if (sb.webBrowser1.Document != null)
            {
                string cookies = sb.webBrowser1.Document.Cookie;
                if(cookies.HasValue())
                {
                    RembyServices.CookieString = cookies;
                }
            }            
            
        }
    }

    [DoNotObfuscate]
    [DoNotObfuscateControlFlow]
    [DoNotEncodeStrings]
    [DoNotSealType]
    [DoNotPrune]
    [ComVisibleAttribute(true)]
    public class WebLoginMethods
    {
        ShareBrowser s;

        [DoNotObfuscateControlFlow]
        [DoNotEncodeStrings]
        public WebLoginMethods(ShareBrowser sb)
        {
            s = sb;
        }

        [DoNotObfuscate]
        [DoNotObfuscateControlFlow]
        [ComVisibleAttribute(true)]
        public void loginResult(string json)
        {
            int i = 1;
            if(json.HasValue())
            {
                LoginResponse response = JsonHelper.Translate<LoginResponse>(json);
                if(response.session.HasValue())
                {
                    AppConfig.Instance.SessionID = response.session;
                    AppConfig.Instance.Username = response.name;
                    AppConfig.Instance.LoginResponse = response;
                    s.DialogResult = DialogResult.OK;
                    s.Close();
                }
            }
//            if (result.ToLower() == "true")
//            {
//                AppConfig.Instance.SessionID = sessionID;
//                AppConfig.Instance.Username = user;
//                AppConfig.Instance.Password = passwordHash;
                //AppConfig.Instance.PasswordHash = passwordHash;
//                AppConfig.Instance.Store();
//                RembyServices.securityID = sessionID;
//                RembyServices.uID = uid;
//
                //RembyServices.login(AppConfig.Instance.Username, AppConfig.Instance.Password, false, true);
//                s.Close();
//            }
        }
    }
}
