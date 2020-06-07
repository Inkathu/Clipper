using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using RembyClipper2.Config;
using RembyClipper.Helpers;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using RembyClipper2.Utils;

namespace RembyClipper2.Helpers
{
    public class History : IDisposable
    {
        ///?uid=steller&max_results=10&start_index=1
        private const string HistoryURL = RembyConstants.MediaRembyURL +  "/_s/files/?uid={0}&max_results={1}&start_index={2}";

        private const int DOWNLOAD_ITEMS_COUNT = 25;
        private static int itemsToDownload = DOWNLOAD_ITEMS_COUNT;

        public static int TotalCount { get; private set; }

        public static int DownloadCount
        {
            get { return itemsToDownload; }
        }


        public History(bool incraseListSize)
        {
            if(incraseListSize)
            {
                IncraseListSize();
            }
            il.ImageSize = new System.Drawing.Size(128, 128);
            il.ColorDepth = ColorDepth.Depth32Bit;
            RefreshHistory();
            
            /*Timer t = new Timer();
            t.Interval = AppConfig.Instance.HistoryPollInterval;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;*/
        }


        public static void ResetListSize()
        {
            itemsToDownload = DOWNLOAD_ITEMS_COUNT;
        }
        public static void IncraseListSize()
        {
            if (itemsToDownload + DOWNLOAD_ITEMS_COUNT > TotalCount)
            {
                itemsToDownload = TotalCount;
            } else
            {
                itemsToDownload += DOWNLOAD_ITEMS_COUNT;    
            }
            
        }

        void t_Tick(object sender, EventArgs e)
        {
            PeriodicHistoryCheck();
        }
        
        private bool disposed = false;
        private string historyHash = "";
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public delegate void disposeTSDelegate(bool disposing);

        protected virtual void Dispose(bool disposing)
        {
            if (AppConfig.topnav.InvokeRequired)
            {
                disposeTSDelegate d = new disposeTSDelegate(Dispose);
                AppConfig.topnav.Invoke(d, disposing);
            }
            else
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        foreach (Image i in il.Images)
                            i.Dispose();
                        il.Dispose();
                    }
                    // non managed stuff
                    disposed = true;
                }
            }
        }

        private string md5(string content)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(content);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }

        private void PeriodicHistoryCheck()
        {
            WebClient wc = new WebClient();
            string json = wc.DownloadString(string.Format(HistoryURL, AppConfig.Instance.Username, 20, 1));

            string tmp = md5(json);
            DebugHelper.Log("Periodic History hash: " + tmp + " current is " + historyHash);
            if (tmp != historyHash)
                RefreshHistory();
        }

        private void RefreshHistory()
        {
            DateTime t = DateTime.Now;

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString(string.Format(HistoryURL, AppConfig.Instance.Username, itemsToDownload, 1));

            historyHash = md5(json);
            DebugHelper.Log("History hash: " + historyHash);

            if (json.EndsWith("},\n  ]\n}\n"))
            {
                json = json.Replace("},\n  ]\n}\n", "}\n  ]\n}\n").Replace(",\n    }", "\n    }");
            }
            JsonExSerializer.Serializer serial = new JsonExSerializer.Serializer(typeof(HistoryResult));
            Data = (HistoryResult)serial.Deserialize(json);
            if (Data == null)
            {
                DebugHelper.Log("Returned data is empty. It is possible that user logged out in attempt to download history");
                return;
            }

            TotalCount = Data.total_results;
            wc.Dispose();

            if(itemsToDownload > Data.total_results)
            {
                itemsToDownload = Data.total_results;
            }

            DebugHelper.Log("History element count: " + Data.files.Count);
            processHistory();

            TimeSpan ts = DateTime.Now.Subtract(t);
            DebugHelper.Log("Total spent time: " + ts.TotalMilliseconds.ToString());

            Tags.GetTags();
        }

        System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item 1"}, 0, System.Drawing.Color.Black, SystemColors.Control, new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));

        private ImageList il = new ImageList();
        private List<ListViewItem> lv = new List<ListViewItem>();

        public ImageList historyImages { get { return il; } }
        public ListViewItem[] historyItems { get { return lv.ToArray(); } }

        private void processHistory()
        {
            Image img;
            MemoryStream ms;
            ListViewItem lvi;
            WebClient wc = new WebClient();
            foreach (Content c in Data.files)
            {
                if (c.tb_url != "")
                {
                    ms = new MemoryStream(wc.DownloadData(c.tb_url));
                    img = Image.FromStream(ms);
                    ms.Close();

                    lvi = (ListViewItem)listViewItem1.Clone();
                    /*if (c.description != "")
                        lvi.Text = c.description;
                    else
                        lvi.Text = c.source_url;
                    */
                    lvi.Text = c.tags;
                    il.Images.Add(c.url, img);
                    lvi.ImageKey = c.url;
                    lvi.Tag = c;
                    lv.Add(lvi);
                }

                if (c.tb_url == "" && (c.file_role == "text" || c.file_role  == "bookmark"))
                {
                    lvi = (ListViewItem)listViewItem1.Clone();
                    
                    if (c.description != "")
                        lvi.Text = c.description;
                    else
                        lvi.Text = c.source_url;

                    img = new Bitmap(il.ImageSize.Width*4, il.ImageSize.Height*4);
                    Font drawFont = new Font("Arial", 32);
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.FillRectangle(new SolidBrush(Color.White), 0, 0, img.Width, img.Height);
                        g.DrawString(lvi.Text, drawFont, new SolidBrush(Color.Black), new RectangleF(0,0,img.Width,img.Height));
                        
                    }

                    il.Images.Add(c.url, img);
                    lvi.ImageKey = c.url;

                    lvi.Tag = c;
                    lv.Add(lvi);
                }
            }
        }

        public HistoryResult Data { get; private set; }

        [SmartAssembly.Attributes.DoNotObfuscate]
        [SmartAssembly.Attributes.DoNotObfuscateType]
        [SmartAssembly.Attributes.DoNotObfuscateControlFlow]
        public class Content
        {
            public string key = "";
            public string url = "";
            public string tb_url = "";
            public string tb_svg_url = "";
            public string file_role = "";
            public string content_type = "";
            public int size = 0;
            public string tags = "";
            public string handle_id = "";
            public string file_name = "";
            public string source_url = "";
            public string description = "";
            public int image_width = 0;
            public int image_height = 0;
            public string video_id = "";
            public string share_url = "";
        }

        [SmartAssembly.Attributes.DoNotObfuscate]
        [SmartAssembly.Attributes.DoNotObfuscateType]
        [SmartAssembly.Attributes.DoNotObfuscateControlFlow]
        public class HistoryResult
        {
            public string status = "";
            public int total_results = 0;
            public int start_index = 0;
            public int items_per_page = 0;
            public List<Content> files = new List<Content>();
        }
    }

    
}
