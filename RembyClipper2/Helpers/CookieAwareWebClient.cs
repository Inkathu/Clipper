using System;
using System.Net;
using System.Text.RegularExpressions;
using JsonExSerializer.Framework.Parsing;
using RembyClipper.Helpers;
using RembyClipper2.Utils;

namespace RembyClipper2.Helpers
{
   public class CookieAwareWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; set; }
        public Uri Uri { get; set; }
        public static string Cookies;

        public CookieAwareWebClient()
            : this(new CookieContainer())
        {
        }

        public CookieAwareWebClient(CookieContainer cookies)
        {
            if(Cookies.HasValue())
            {
                this.Headers.Add("Cookie", Cookies);
            }
            this.CookieContainer = cookies;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            HttpWebRequest httpWebRequest = (request as HttpWebRequest);
            if (httpWebRequest != null)
            {
                if(RembyServices.CookieString.HasValue())
                {
                    if(!httpWebRequest.Headers.Get("cookie").HasValue())
                    {
                        httpWebRequest.Headers.Add(HttpRequestHeader.Cookie, RembyServices.CookieString);
                    }
                }
            }
            return request;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebHeaderCollection webHeaderCollection = this.ResponseHeaders;
            WebResponse response = base.GetWebResponse(request);
            CookieCollection cookies = new CookieCollection();
            return response;
        }

        public static MatchCollection GetCookies(string cookiesstr)
        {
            string HeadersCookie = Regex.Replace(cookiesstr, @"\s?expires=(.*?)GMT;?", "",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx = new Regex(@"(?<name>[^=]+)=(?<value>[^;]*);([^,]*domain=(?<domain>[^;]+);)?[^,]*,?",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(HeadersCookie);

            return matches;
        }
    }
}