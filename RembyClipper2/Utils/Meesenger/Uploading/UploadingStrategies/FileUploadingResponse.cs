using System.Collections.Generic;

namespace RembyClipper2.Utils.Meesenger.Uploading.UploadingStrategies
{
    public class FileUploadingResponse
    {

        public string status { get; set; }
        public Result result { get; set; }
        public string now { get; set; }
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
            public string content_type { get; set; }
            public string created_ago { get; set; }
            public List<object> tags { get; set; }
            public string blob_key { get; set; }
            public string created { get; set; }
            public string created_utc { get; set; }
            public int image_width { get; set; }
            public string serve_url { get; set; }
            public string name { get; set; }
            public string canonical_url { get; set; }
            public string thumbnail_url { get; set; }
            public string image_url { get; set; }
            public string md5_checksum { get; set; }
            public string key { get; set; }
            public int image_height { get; set; }
            public string name_slugified { get; set; }
            public int id { get; set; }
            public int size { get; set; }
        }


    }
  

    public class FileUploadingUrlResponse
    {
        public class Result
        {
            public string upload_url { get; set; }
        }
        public string status { get; set; }
        public Result result { get; set; }
    }


    public class FailResponse
    {
        public string status { get; set; }
        public int status_code { get; set; }
        public string error_message { get; set; }
        public string error_code { get; set; }
    }
}