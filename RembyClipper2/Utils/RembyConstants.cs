//#define STAGING
#define LIVE

using RembyClipper2.Config;
using RembyClipper2.Properties;


namespace RembyClipper2.Utils
{
    public static class RembyConstants
    {

#if STAGING
        public const string RembyURL = "https://staging.remby.com";
        public const string MediaStoreURL = "http://tomcat-staging.remby.com"; //storing media at the storage
        public const string RembyFlashCookieName = "staging.remby.com";
        public const string MediaRembyURL = "http://media.remby.com";
        public const string YouTubeSignUpLink = "http://www.youtube.com";

        public static string MediaRembyURLWithOutHTTP
        {
           get
           {
               string url = MediaRembyURL;
               if(url.Contains("http://"))
               {
                   url = url.Replace("http://", "");
               }
               return url;
           } 
        }//= "media.remby.com";
        public static string RembySignUpLink
        {
            get
            {
                string url = RembyURL;
                if(url.Contains("https"))
                {
                    url = url.Replace("https", "http");
                }
                return url;
            }
        }
        
#endif
#if LIVE
        public static string RembyURL
        {
            get
            {
                return Settings.Default.ServiceUrl;
            }
        }

        public static string MediaStoreURL
        {
            get
            {
                return Settings.Default.UploadUrl;
            }
        }
        public const string RembyFlashCookieName = "remby.com";
        public const string MediaRembyURL = "http://media.remby.com";
        public const string YouTubeSignUpLink = "http://www.youtube.com";


        public static string MediaRembyURLWithOutHTTP
        {
           get
           {
               string url = MediaRembyURL;
               if(url.Contains("http://"))
               {
                   url = url.Replace("http://", "");
               }
               return url;
           } 
        }//= "media.remby.com";
        public static string RembySignUpLink
        {
            get
            {
                string url = RembyURL;
                if(url.Contains("https"))
                {url
                     = url.Replace("https", "http");
                }
                return url;
            }
        }

#endif
    }
}