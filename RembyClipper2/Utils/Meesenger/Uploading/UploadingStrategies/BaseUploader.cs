using System.IO;
using System.Net;

namespace RembyClipper2.Utils.Uploading.UploadingStrategies
{
    public class BaseUploader
    {
        public string SendPostRequest(string url)
        {
            return "";
        }

        public string SendGetRequest(string url)
        {
            return "";
        }


        void writeToURL(WebRequest request, string data)
        {

            byte[] bytes = null;
            // Get the data that is being posted (or sent) to the server
            bytes = System.Text.Encoding.ASCII.GetBytes(data);
            request.ContentLength = bytes.Length;
            // 1. Get an output stream from the request object
            Stream outputStream = request.GetRequestStream();

            // 2. Get the data out to the stream
            outputStream.Write(bytes, 0, bytes.Length);

            // 3. Close the output stream and send the data out to the web server
            outputStream.Close();

            // end writeToURL method
        }

        string retrieveFromURL(WebRequest request)
        {
            // 1. Get the Web Response Object from the request
            WebResponse response = request.GetResponse();
            // 2. Get the Stream Object from the response
            Stream responseStream = response.GetResponseStream();

            // 3. Create a stream reader and associate it with the stream object
            StreamReader reader = new StreamReader(responseStream);

            // 4. read the entire stream 
            return reader.ReadToEnd();
        }// end retrieveFromURL method

        private string postToURL(string url, string data)
        {

            // Create the Web Request Object 
            WebRequest request = WebRequest.Create(url);
            // Specify that you want to POST data
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (data != null)
            {
                // write out the data to the web server
                writeToURL(request, data);
            }
            else
            {
                request.ContentLength = 0;
            }
            // read the response from the Web Server
            // Display the content on the web page

            return retrieveFromURL(request);
            // end postToURL method

        } 
    }
}