using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RembyClipper2.Utils.Meesenger.Uploading.UploadingStrategies
{
    public class LinkUploadingResponse
    {
        public string status { get; set; }
        public Result result { get; set; }


        public bool Success
        {
            get
            {
                if (status.Equals("success"))
                {
                    return true;
                }

                return false;
            }
        }

        public class Result
        {
            public string category { get; set; }
            public string canvas_url { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            public List<string> tags { get; set; }
            public string blob_key { get; set; }
            public string created { get; set; }
            public string created_ago { get; set; }
            public string created_utc { get; set; }
            public string serve_url { get; set; }
            public string source_url { get; set; }
            public string canonical_url { get; set; }
            public string thumbnail_url { get; set; }
            public string md5_checksum { get; set; }
            public string content_type { get; set; }
            public string name_slugified { get; set; }
            public int id { get; set; }
            public int size { get; set; }
        }


    }

 


}
