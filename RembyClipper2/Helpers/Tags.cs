using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using RembyClipper2.Config;
using System.Xml;
using RembyClipper.Helpers;
using RembyClipper2.Utils;

namespace RembyClipper2.Helpers
{
    public static class Tags
    {
        private static List<string> tags;

        public static void GetTags()
        {
            tags = new List<string>();
            GetMediaStoreBookTags();
            GetMediaStoreTags();

            AppConfig.Instance.Tags = tags.ToArray();
            AppConfig.Instance.Store();

            return;
        }

        private static void GetMediaStoreBookTags()
        {
            try
            {
                 CookieAwareWebClient wc = new CookieAwareWebClient(RembyServices.LoginCookieContainer);
                wc.Encoding = Encoding.UTF8;
                
                
                var addresses = Dns.GetHostAddresses(RembyConstants.MediaRembyURLWithOutHTTP);
                var url = string.Format("http://remby.com/profile/tags?uid={0}", RembyServices.uID);
                string json = wc.DownloadString(url);
                JsonExSerializer.Serializer serial = new JsonExSerializer.Serializer(typeof(BookTagResult));

                var tags = (BookTagResult)serial.Deserialize(json);
                if (tags.tags != null)
                {
                    foreach (BookTag t in tags.tags)
                        if (!Tags.tags.Contains(t.name))
                            Tags.tags.Add(t.name);
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log("Could not download book tags: \r\n" + e.ToString());
            }
        }

        private static void GetMediaStoreTags()
        {
            try
            {
                CookieAwareWebClient wc = new CookieAwareWebClient(RembyServices.LoginCookieContainer);
                wc.Encoding = Encoding.UTF8;
                //http://store.remby.com/_s/content/tag/?x-remby-drupal-user_id=693&limit=1000
                var addresses = Dns.GetHostAddresses(RembyConstants.MediaRembyURLWithOutHTTP);
                var url = string.Format("http://store.remby.com/_s/content/tag/?x-remby-drupal-user_id={0}&limit=1000", RembyServices.uID);
                string json = wc.DownloadString(url);
                JsonExSerializer.Serializer serial = new JsonExSerializer.Serializer(typeof(MediaTagsBody));

                var tags = (MediaTagsBody)serial.Deserialize(json);
                if (tags.result != null)
                {
                    foreach (MediaTagsValues t in tags.result)
                        if (!Tags.tags.Contains(t.name))
                            Tags.tags.Add(t.name);
                }
            }
            catch(Exception e)
            {
                DebugHelper.Log("Could not download media tags: \r\n" + e.ToString());
            }
        }

        [SmartAssembly.Attributes.DoNotObfuscate]
        [SmartAssembly.Attributes.DoNotObfuscateType]
        [SmartAssembly.Attributes.DoNotObfuscateControlFlow]
        public class MediaTagsBody
        {
            public string status { get; set; }
            public int count { get; set; }
            public List<MediaTagsValues> result { get; set; }
        }

        [SmartAssembly.Attributes.DoNotObfuscate]
        [SmartAssembly.Attributes.DoNotObfuscateType]
        [SmartAssembly.Attributes.DoNotObfuscateControlFlow]
        public class MediaTagsValues
        {
            public int count { get; set; }
            public string name { get; set; }
        }

       

        public class BookTagResult
        {
            public List<BookTag> tags { get; set; }
            public int count { get; set; }
            public int page { get; set; }
            public int page_size { get; set; }
        }

        public class BookTag
        {
            public int tid { get; set; }
            public string name { get; set; }
        }
    }
}
