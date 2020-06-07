using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils
{
    public static class Extensions
    {
        public static ToolStripMenuItem FindMenuItemByEntity(this ToolStripItemCollection collection, UploadEntityBase entity)
        {
            return collection.Cast<object>().Where(item => item != null && item is ToolStripMenuItem && ((ToolStripMenuItem) item).Tag == entity).Cast<ToolStripMenuItem>().FirstOrDefault();
        }

        public static bool HasValue(this string str)
        {
            if(!string.IsNullOrEmpty(str))
            {
                return true;
            }
            return false;
        }

        public static ComboboxItem<T> FindItem<T>(this ComboBox cb, T itemTofind)
        {
            return cb.Items.Cast<ComboboxItem<T>>().FirstOrDefault(item => item.Value.Equals(itemTofind));
        }

        public static void RemoveAllProcessedItems(this ToolStripMenuItem menu)
        {
            List<ToolStripMenuItem> toRemove =
                menu.DropDownItems.Cast<object>().Where(item=> item != null && item is ToolStripMenuItem).Cast<ToolStripMenuItem>().Where(item => item.Tag != null)
                    .Where(item =>
                               {
                                   var ent = (UploadEntityBase) item.Tag;
                                   if ((ent.UploadStatus.Status == Status.Canceled) ||
                                       (ent.UploadStatus.Status == Status.Error) ||
                                       (ent.UploadStatus.Status == Status.Uploaded))
                                   {
                                       return true;
                                   }
                                   return false;
                               }
                    ).ToList();
            
            toRemove.ForEach(item => menu.DropDownItems.Remove(item));
        }

        public static string ReplaceIfExist(this string str, string oldValue, string newValue)
        {
            if (str.Contains(oldValue))
            {
                return str.Replace(oldValue, newValue);
            }
            return str;
        }

        public static PointF Offset(this PointF point, float dx, float dy)
        {
            return new PointF(point.X + dx, point.Y + dy);
        }

        public static string BaseAddr(this Uri uri)
        {
            string result = "";
            if(uri != null)
            {
                result = uri.AbsoluteUri.Replace(uri.AbsolutePath.ToString(),"");
            }

            return result;
        }

        /// <summary>
        /// Use the current thread's culture info for conversion
        /// </summary>
        public static string ToTitleCase(this string str)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }

        /// <summary>
        /// Overload which uses the culture info with the specified name
        /// </summary>
        public static string ToTitleCase(this string str, string cultureInfoName)
        {
            var cultureInfo = new CultureInfo(cultureInfoName);
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }

        /// <summary>
        /// Overload which uses the specified culture info
        /// </summary>
        public static string ToTitleCase(this string str, CultureInfo cultureInfo)
        {
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string  LogInfo(this object obj)
        {
            StackFrame sf = new StackTrace().GetFrame(1);
            string res = string.Format("{0} - {1} ln{2}", sf.GetFileName(), sf.GetMethod().Name, sf.GetFileLineNumber());
            
            return res;
        }

        public static string ReadFromStream(this DragEventArgs args, string name, Encoding enc)
        {
            string result = "";
            object data = args.Data.GetData(name);
            if(data is Stream)
            {
                var theStream = (Stream)data;
                if (theStream != null)
                {
                    var reader = new StreamReader(theStream, enc);
                    string html = reader.ReadToEnd();
                    string[] strings = html.Split(new char[] { '\n' });

                    result = (strings.Length > 0) ? strings[0] : html.Replace("\0", "");
                }
               
            } else if(data is string)
            {
                result = (string)data;
            }
 
            return result;
        }

        public static string GetImgUrl(this string text)
        {
            string result = "";
            var regex = new Regex(@"(?<=img+.+src\=[\x27\x22])(?<Url>[^\x27\x22]*)(?=[\x27\x22])");
            Match match = regex.Match(text);
            if (match.Success)
            {
                result = match.Value;
            } else
            {
                regex = new Regex(@"(?<=IMG+.+SRC\=[\x27\x22])(?<Url>[^\x27\x22]*)(?=[\x27\x22])");
                match = regex.Match(text);
                if (match.Success)
                {
                    result = match.Value;
                } 
                
            }

            return result;
        }
    

    }
}
