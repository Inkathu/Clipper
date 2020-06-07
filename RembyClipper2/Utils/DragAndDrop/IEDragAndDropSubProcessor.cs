using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.DragAndDrop
{
    public class IEDragAndDropSubProcessor : BaseDragAndDropSubProcessor
    {
        public override bool CouldDataBeProcessed(string data)
        {
            return data.ToLower().Contains("iexplore");
        }


        public override List<UploadEntityBase> ExtractData(DragEventArgs e, string tags)
        {
            return new List<UploadEntityBase>();
        }

        public override List<string> GetImgUrl(DragEventArgs dataObject, Encoding enc = null)
        {
            var result = new List<string>();
            try
            {
                StreamReader reader = null;
                var theStream = (Stream)dataObject.Data.GetData(@"UniformResourceLocator");
                if(theStream == null)
                {
                    theStream = (Stream)dataObject.Data.GetData(@"UniformResourceLocatorW");
                    if(theStream != null)
                    {
                        reader = new StreamReader(theStream, Encoding.Unicode);
                    }
                }
                else
                {
                    reader = new StreamReader(theStream, Encoding.UTF8);
                }
                if (reader != null)
                {
                    string html = reader.ReadToEnd();
                    html = html.Replace("\0", "");
                    if (html.HasValue())
                    {
                        result.Add(html);
                    }
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log(e.ToString());
            }
            if(result.Count == 0)
            {
                result = base.GetImgUrl(dataObject);
            }
            return result;
        }

        public override string GetBrowserUrl()
        {
            string result = "";
            try
            {
                IntPtr ie = AppConfig.topnav.LastAppHandle;
                if (ie != IntPtr.Zero)
                {
                    result = BrowserSourceHelper.GetIESource();
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log("[IEDragAndDropSubProcessor] GetBrowserUrl: an error occurred in attempt to get browser url. " + e.ToString());
            }

            return result;
        }
    }
}