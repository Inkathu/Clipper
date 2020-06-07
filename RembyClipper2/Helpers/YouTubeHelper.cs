using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using RembyClipper.Forms;
using Google.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.GData.YouTube;
using Google.GData.Extensions.Location;
using Google.GData.Client;
using System.Windows.Forms;
using System.Diagnostics;
using RembyClipper2.Config;
using System.Linq;

namespace RembyClipper.Helpers
{
    public class YouTubeHelper
    {
        private static string DevKey = "AI39si4Vxd_L-MRxSiQW2IzFA4o3rcRRSpb1YKEvaIPMDvVNdPB75iMLcFkZpmMqz0RxCu2MWzIV03EV76wQo0kC0-BHTngpbg";
        private static string AppName = "RembyCollector";

        private static YouTubeRequest request;

        public enum YouTubeErrors { InvalidCredentials, ValidationError, InternalServerError, GeneralError, None };

        public static void Init(string uname, string passw)
        {
            //if (request != null)
            //    return;
            AppConfig.YTUsername = uname;
            AppConfig.YTPassword = passw;
            Init();
        }

        public static void Init()
        {
            YouTubeRequestSettings settings = new YouTubeRequestSettings(AppName, DevKey, AppConfig.YTUsername, AppConfig.YTPassword);
            settings.Timeout = 100000;
            request = new YouTubeRequest(settings);
        }

        public static bool CheckCredentials(string uname, string pass)
        {
            if (AppConfig.YTUsername == null)
                return true;
            if (AppConfig.YTPassword == null)
                return true;

            if ((AppConfig.YTUsername != "" && AppConfig.YTPassword != ""))
            {
                if (uname == "" && pass == "")
                    return false;
                if (uname == AppConfig.YTUsername && pass == AppConfig.YTPassword)
                    return false;
                if (uname != AppConfig.YTUsername || pass != AppConfig.YTPassword)
                    return true;
                return true;
            }
            else
                return true;
        }

        public static string YouTubeTitle { get; set; }
        public static string YouTubeCategory { get; set; }
        public static string YouTubeTags { get; set; }
        public static string YouTubeDescription { get; set; }

        public static string VideoID { get; private set; }

        private static string VideoError { get; set; }

        public static YouTubeErrors UploadError { get { return _getError(); } }

        private static YouTubeErrors _getError()
        {
            if (VideoError == null)
                return YouTubeErrors.None;
            if (VideoError.Contains("400"))
                return YouTubeErrors.ValidationError;
            else if (VideoError.Contains("401") || VideoError.Contains("403"))
                return YouTubeErrors.InvalidCredentials;
            else if (VideoError.Contains("500"))
                return YouTubeErrors.InternalServerError;
            else if(VideoError.ToLower() == "forbidden")
            {
                return YouTubeErrors.InvalidCredentials;
            }
            else
                return YouTubeErrors.GeneralError;
        }

        public static bool UploadVideo(string Filename)
        {
            VideoError = null;
            Video newVideo = new Video();

            if (YouTubeTitle.Length > 60)
            {
                newVideo.Title = YouTubeTitle.Substring(0, 60);    
            }
            else
            {
                newVideo.Title = YouTubeTitle;
            }
            
            //newVideo.Tags.Add(new MediaCategory(YouTubeCategory, YouTubeNameTable.CategorySchema));
            newVideo.Tags.Add(new MediaCategory(YouTubeCategory, YouTubeNameTable.CategorySchema));
            IEnumerable<string > tags = YouTubeTags.Split(new char[] {' '});
            tags = tags.Where(tag => tag.Length > 1).Select(tag=>tag);
            if(tags.Count() > 1)
            {
                newVideo.Keywords = tags.Aggregate((tag1, tag2) => tag1 + "," + tag2);
            }
            else
            {
                newVideo.Keywords = YouTubeTags;    
            }

            if (newVideo.Keywords.Length <= 1)
            {
                newVideo.Keywords += " Video";
            }
            newVideo.Description = YouTubeDescription;
            newVideo.YouTubeEntry.Private = AppConfig.GetInstance().VideoPrivate;

            newVideo.YouTubeEntry.MediaSource = new MediaFileSource(Filename,
              "video/x-msvideo");

            if (request == null)
            {
                Init();
                if (request == null)
                {
                    VideoError = "500";
                    return false;
                }
            }

            try
            {
                
                Video createdVideo = request.Upload(newVideo);
                Process t = new Process();
                t.StartInfo.FileName = "http://www.youtube.com/watch?v=" + createdVideo.VideoId;
                VideoID = createdVideo.VideoId;
                //t.Start();
                AppConfig.YTValid = true;
                return true;
            }
            catch(WebException wExc)
            {
                var response = (HttpWebResponse) (wExc.Response);
                VideoError = response == null ? "": response.StatusCode.ToString();
                return false;
            }
            catch (Exception e)
            {
                DebugHelper.Error(e.ToString());
                VideoError = e.Message;
                return false;
            }
            
        }

    }
}
