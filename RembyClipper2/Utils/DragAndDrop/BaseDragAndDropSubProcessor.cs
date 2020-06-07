using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.DragAndDrop
{
    public abstract class BaseDragAndDropSubProcessor : IDragAndDropSubProcessor
    {
        public virtual List<UploadEntityBase> ExtractData(DragEventArgs e, string tags)
        {
            List<UploadEntityBase> result = new List<UploadEntityBase>();
            List<string> imgUrls = GetImgUrl(e);
            bool containsVideoProvider = false;
            UploadEntityBase textEntity = null;
            UploadEntityBase imageEntity = null;
            UploadEntityBase fileEntity = null;
            string browserUrl = GetBrowserUrl();
            if (e.Data.GetDataPresent(DataFormats.UnicodeText))
            {
                var data = (string)e.Data.GetData(DataFormats.UnicodeText);
                if(imgUrls.Count > 0 && imgUrls[0].Contains("base64"))
                {
                    data = imgUrls[0];
                }
                if (data.HasValue())
                {
                    if (data.Contains(";base64,"))
                    {
                        string imageFile = GetFileFromBase64String(data);
                        imageEntity = new FileEntity()
                        {
                            CallerForm = null,
                            Tags = tags,
                            Context = browserUrl,
                            File = imageFile
                        }.Init();
                        imgUrls.Clear();
                    }
                    else
                    {
                        if (data.Contains("googleads"))
                        {
                            data = data.Substring(data.LastIndexOf("http://"));
                        }
                        containsVideoProvider = AppConfig.VideoProviders.Any(provider => data.Contains(provider));
                        textEntity = ExtractText(data, tags, browserUrl);
                        if (textEntity != null)
                        {
                            textEntity.Context = "";
                        }
                    }
                }
            }
            
            if (imgUrls.Count > 0)
            {
                imageEntity =
                    new ImageLinkEntity()
                        {
                            CallerForm = null,
                            Link = imgUrls[0],
                            Tags = tags,
                            Context = browserUrl,
                            DrupalName = AppConfig.topnav.LastAppTitle,
                        }.Init();
            }
            if(textEntity is ImageLinkEntity && imageEntity == null)
            {
                imageEntity = textEntity;
                textEntity = null;
            }
            if(imageEntity != null)
            {
                result.Add(imageEntity);
            }
            else if(textEntity != null)
            {
                result.Add(textEntity);
            }

            if(textEntity != null && containsVideoProvider)
            {
                if(imageEntity != null)
                {
                    result.Remove(imageEntity);
                    result.Add(textEntity);
                }
                
            }
            AppConfig.Instance.LastUsedTags = tags;
            AppConfig.Instance.Store();
            return result;
        }

        public virtual bool CouldDataBeProcessed(string data)
        {
            return false;
        }

        public virtual bool IsDataSupported(DragEventArgs e)
        {
            bool result = false;
            string[] formats = e.Data.GetFormats();
            var strFormats = new List<string>(formats);
            //List<string> imgUrls = GetImgUrl(e);
            bool folder = IsFolder(e);
            result = (formats.Any(f => f == DataFormats.FileDrop || f == DataFormats.Text /*|| imgUrls.Count > 0*/) &&
                        !folder
                            ? true
                            : false);
          
            return result;
        }

        public bool IsFolder(DragEventArgs dragEventArgs)
        {
            bool result = false;
            try
            {
                var files = (string[])dragEventArgs.Data.GetData("FileDrop");
                foreach (string file in files)
                {
                    if (Directory.Exists(file))
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log("An error occurred in folder check method : " + e);
            }
            return result;
        }

        public virtual List<string> GetImgUrl(DragEventArgs dataObject, Encoding readEnc = null)
        {
            Encoding enc = readEnc ?? Encoding.UTF8;
            var result = new List<string>();
            try
            {
                var theStream = (Stream)dataObject.Data.GetData(@"application/x-moz-file-promise-url");
                if (theStream == null)
                {
                    theStream = (Stream)dataObject.Data.GetData(@"text/html");
                }
                if (theStream != null)
                {
                    var reader = new StreamReader(theStream, enc);
                    string html = reader.ReadToEnd();
                    string imgUrl = html.GetImgUrl();
                    if(imgUrl.HasValue())
                    {
                        result.Add(imgUrl);
                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log(e.ToString());
            }

            return result;
        }

        public abstract string GetBrowserUrl();

        protected UploadEntityBase ExtractText(string data, string tags, string browserUrl)
        {
            DebugHelper.Log("Dragged text (length: " + data.Length + ")");
            DebugHelper.Log(data);
            UploadEntityBase result = null;
            var urlRegEx =
                new Regex(
                    @"^(ht|f)tp(s?)\:\/\/(([a-zA-Z0-9\-\._]+(\.[a-zA-Z0-9\-\._]+)+)|localhost)(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_\*]*)?([\d\w\.\/\%\+\-\=\&amp;\*\?\:\\\&quot;!#\'\,\|\~\;]*)$");

            if (urlRegEx.IsMatch(data))
            {
                if (containsImageUrl(data))
                {
                    //process image here
                   result= new ImageLinkEntity
                    {
                        Link = data,
                        Tags = tags,
                        CallerForm = null,
                        DrupalName = AppConfig.topnav.LastAppTitle,
                        Context = browserUrl
                    }.Init();
                }
                else
                {
                    //process link here
                    result =new LinkEntity
                    {
                        Link = data,
                        Tags = tags,
                        CallerForm = null,
                        Context = browserUrl,
                        DrupalName =  AppConfig.topnav.LastAppTitle
                    }.Init();
                }
            }
            else
            {
                result = new TextEntity
                {
                    CallerForm = null,
                    Tags = tags,
                    Text = data,
                    Context = ""
                }.Init();
            }

            AppConfig.Instance.LastUsedTags = tags;
            AppConfig.Instance.Store();
            return result;
        }

        

        protected bool containsImageUrl(string data)
        {
            var imgRegex = new Regex(@"^https?://(?:[a-z\-]+\.)+[a-z]{2,6}(?:/[^/#?]+)+\.(?:jpg|gif|png)$");
            return imgRegex.IsMatch(data);
        }

        protected string GetFileFromBase64String(string str)
        {
            //data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAACAAAAAAYCAYAAABuzR2hAAAABGdBTUEAALGPC/xhBQAAAgVJREFUeJzt2tFugzAQBEDT//9n9yGJaEhCDaXoWM1IlbkE2RfLVDzs1Fvr7WFajO8+2/uducz1n3NdsWdzZcw1us7yevS+CtdV+tCrXpP7rtJHwV77/br/+FMfV1fq5ep1pV7S6kq9XL2ei6nN/2An9RF1pV7S6kq9XL2u1EtK/XhxXZR/Go+cq/pYoYezxgo9nDVW6OGssUIPZ42nrNVb6/Pl2jj129vtdH/J/Ty+3vd+3j647q14WmdwzvVe++r38zyje/R635Y9er/+eo+ffst6r+v7vqXH5fp79uhp3Y1n4zHnnj1a36vRs7n/mfh8Rsbn3LJHY2dzbC/Hn4n2cob3nI39Z3O+75hn4vc9+moAAAAAAAAAwOUJAAAAAAAAAABAAAEAAAAAAAAAAAggAAAAAAAAAAAAAQQAAAAAAAAAACCAAAAAAAAAAAAABBAAAAAAAAAAAIAAAgAAAAAAAAAAEEAAAAAAAAAAAAACCAAAAAAAAAAAQAABAAAAAAAAAAAIIAAAAAAAAAAAAAEEAAAAAAAAAAAggAAAAAAAAAAAAAQQAAAAAAAAAACAAAIAAAAAAAAAABBAAAAAAAAAAAAAAggAAAAAAAAAAEAAAQAAAAAAAAAACCAAAAAAAAAAAAABBAAAAAAAAAAAIIAAAAAAAAAAAAAEEAAAAAAAAAAAgADfHlPO4IPpKTwAAAAASUVORK5CYII=
            string result = string.Empty;
            try
            {
                if (str.HasValue() && str.Contains(":"))
                {
                
                    string[] strings = str.Split(',');
                    string part1 = strings[0];
                    string content = strings[1];
                    strings = part1.Split(':', '/', ';');
                    if(strings.Length == 4)
                    {
                        string tag          = strings[0];
                        string imgType      = strings[1];
                        string extension    = strings[2];
                        string encoding     = strings[3];
                    
                        if(imgType.ToLower() == "image" && encoding.ToLower() == "base64")
                        {
                            string fileName = String.Format("decoded_{0}.{1}", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"),extension);
                            string path = Path.Combine(Path.GetTempPath(), fileName);
                            using(FileStream file = new FileStream(path, FileMode.Create))
                            {
                                try
                                {
                                    byte[] decodedData = Convert.FromBase64String(content);
                                    if(decodedData != null)
                                    {
                                        file.Write(decodedData, 0, decodedData.Length);
                                        result = path;
                                    }
                                }
                                catch (Exception e)
                                {
                                    DebugHelper.Log("[BaseDragAndDropSubProcessor] : GetFileFromBase64String - An error occurred in attempt to decode base64 image." + e.ToString());
                                }                            
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log("[BaseDragAndDropSubProcessor] : GetFileFromBase64String - error :( " + e.ToString());
            }            
            return result;
        }


        #region Nested type: DraggedContent

        [Flags]
        public enum DraggedContent : byte
        {
            None = 0,
            Text = 1,
            Image = 2,
            VideoLink = 4,
            Files = 8,
        }

        #endregion
    }
}