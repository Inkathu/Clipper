using System.Collections.Generic;

namespace RembyClipper2.Utils.Uploading.UploadingStrategies
{

    public class TextUploadingResponse
    {
        public string status { get; set; }
        public Result result { get; set; }
        public string now { get; set; }

        public bool Success
        {
            get
            {
                if(status.Equals("success"))
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
            public string content_type { get; set; }
            public string created_ago { get; set; }
            public List<string> tags { get; set; }
            public string text { get; set; }
            public string created { get; set; }
            public string created_utc { get; set; }
            public string name { get; set; }
            public string canonical_url { get; set; }
            public string thumbnail_url { get; set; }
            public string key { get; set; }
            public string name_slugified { get; set; }
            public int id { get; set; }
            public int size { get; set; }
        }


    }
   
   

}