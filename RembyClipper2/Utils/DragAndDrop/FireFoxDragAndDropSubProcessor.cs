using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.DragAndDrop
{
    public class FireFoxDragAndDropSubProcessor : BaseDragAndDropSubProcessor
    {
        public override bool CouldDataBeProcessed(string data)
        {
            return data.ToLower().Contains("firefox");
        }

        public override List<string> GetImgUrl(DragEventArgs dataObject, Encoding enc = null)
        {
            var result = new List<string>();
            try
            {
                var theStream = (Stream)dataObject.Data.GetData(@"application/x-moz-file-promise-url");
                
                if (theStream != null)
                {
                    var reader = new StreamReader(theStream, Encoding.Unicode);
                    string html = reader.ReadToEnd();
                    html = html.Replace("\0", "");
                    if(html.HasValue())
                    {
                        result.Add(html);
                    }
                } else
                {
                    result.AddRange(base.GetImgUrl(dataObject, Encoding.Unicode));
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log(e.ToString());
            }

            return result;
        }

        public override string GetBrowserUrl()
        {
            string result = "";
            try
            {
                IntPtr ff = AppConfig.topnav.LastAppHandle;
                if (ff != IntPtr.Zero)
                {
                    result = BrowserSourceHelper.GetFireFoxSource();
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log("[FireFoxDragAndDropSubProcessor] GetBrowserUrl: an error occurred in attempt to get browser url. " + e.ToString());
            }

            return result;
        }
    }
}