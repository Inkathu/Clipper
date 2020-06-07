using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.DragAndDrop
{
    public class SafariDragAndDropSubProcessor : BaseDragAndDropSubProcessor
    {
        public override bool CouldDataBeProcessed(string data)
        {
            return data.ToLower().Contains("safari");
        }
        public override List<string> GetImgUrl(DragEventArgs dataObject, Encoding enc = null)
        {
            var result = new List<string>();
            try
            {
                string html = dataObject.ReadFromStream("UniformResourceLocatorW", Encoding.Unicode);
                if (html.HasValue() && containsImageUrl(html))
                {
                    result.Add(html);
                } else
                {
                    html = dataObject.ReadFromStream("HTML Format", Encoding.Unicode);
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
            if(result.Count == 0)
            {
                result = base.GetImgUrl(dataObject);
            }
            return result;
        }

        public override string GetBrowserUrl()
        {
//            string result = "";
//            try
//            {
//                IntPtr safari = AppConfig.topnav.LastAppHandle;
//                if (safari != IntPtr.Zero)
//                {
//                    result = BrowserSourceHelper.GetSafariSource(safari);
//                }
//            }
//            catch (Exception e)
//            {
//                DebugHelper.Log("[SafariDragAndDropSubProcessor] GetBrowserUrl: an error occurred in attempt to get browser url. " + e.ToString());
//            }
//
//            return result;
            return "";
        }
    }
}