using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.DragAndDrop
{
    public class ChromeDragAndDropSubProcessor : BaseDragAndDropSubProcessor
    {
        public override bool CouldDataBeProcessed(string data)
        {
            return data.ToLower().Contains("chrome");
        }

        public override string GetBrowserUrl()
        {
            string result = "";
            try
            {
                IntPtr chrome = AppConfig.topnav.LastAppHandle;
                if(chrome != IntPtr.Zero)
                {
                    result = BrowserSourceHelper.GetChromeSource(chrome);
                }
            }
            catch (Exception e)
            {
                DebugHelper.Log("[ChromeDragAndDropSubProcessor] GetBrowserUrl: an error occurred in attempt to get browser url. " + e.ToString());
            }

            return result;
        }
    }
} 