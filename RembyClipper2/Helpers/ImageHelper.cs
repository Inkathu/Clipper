using System;
using System.Drawing;
using RembyClipper.Helpers;

namespace RembyClipper2.Helpers
{
    public class ImageHelper
    {
        public static Image LoadFromFile(string path)
        {
            Image img = null;
            try
            {
                using (var bmpTemp = new Bitmap(path))
                {
                    img = new Bitmap(bmpTemp);
                }
            }
            catch (Exception exc)
            {
                DebugHelper.Log("[ImageHelper] - An error occurred in attempt to load image" + exc.ToString());
            }
            return img;
        }
    }
}