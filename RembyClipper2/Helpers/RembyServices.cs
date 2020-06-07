using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using JsonExSerializer;
using RembyClipper2;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.Utils;

namespace RembyClipper.Helpers
{
    internal class RembyServices
    {
        #region MediaStoreTypes enum

        public enum MediaStoreTypes
        {
            screenshot,
            image,
            audio,
            file,
            clipart,
            video_thumb,
            text,
            link,
            bookmark
        } ;

        #endregion

        public const int OBJECT_TYPE_TEXT = 1;
        public const int OBJECT_TYPE_IMAGE = 2;
        public const int OBJECT_TYPE_FILE = 3;
        public const int OBJECT_TYPE_AUDIO = 4;
        public const int OBJECT_TYPE_SHAPE = 5;
        public const int OBJECT_TYPE_VIDEO_URL = 6;
        public const int OBJECT_TYPE_URL = 8;

        public static string securityID
        {
            get { return _securityID; }
            set { _securityID = value; }
        }
        private  static string _securityID = "";
        public static string setID = "";
        public static string slideID = "";

        public static string uID = "";
        public static string username = "";

        public const string tempSecurityToken = "52671eba928970cc495d528ba19a3d97";
        public const string tempUID = "597";

        public static string lastResult = "";

        public static CookieContainer LoginCookieContainer;
        public static string  CookieString;

//        public static bool DONT_DISPLAY_LOGIN_ERROR;
        public static bool DISPLAY_LOGIN_ERROR = true;

        //login function
        /*
             1. alt/login - login user from external app

            Input:

                   l - login name

                   p - password

            Output:

                   XML with security ID string

         */
        public static bool newLogin(string uname, string password)
        {
            bool result = false;
            string address = @"http://remby.com/collector-login";
            Dictionary<string,string> data = new Dictionary<string, string>();
            data.Add("name", uname);
            data.Add("pass", password);
            data.Add("form_id", "user_login");
            data.Add("op", "Sign+in");
            string strResult = "";
            if (Post(address, data, ref strResult))
            {
                string str = strResult;
            }

            return result;
        }

        public static bool login(string uname, string password, bool bDisplayError, bool hash)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate(
                    object sender,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                    {
                        /*{[Subject]
  E=webmaster@remby .com, CN=staging.remby .com, OU=Staging, O=Remby, L=Lake, S=CA, C=US

[Issuer]
  E=webmaster@remby .com, CN=remby .com, OU=remby.com, O=Remby, L=Lake, S=CA, C=US

[Serial Number]
  01

[Not Before]
  9/3/2010 3:41:41 PM

[Not After]
  9/3/2011 3:41:41 PM

[Thumbprint]
  6D528089044DDB47BCCB9E9274FA4DE1E42C7456
}*/
                        // "CN=*.googleapis.com, O=Google Inc, L=Mountain View, S=California, C=US"
                        if (certificate.Subject.Contains("google.com") || certificate.Subject.Contains("googleapis.com"))
                            return true;
                        DateTime subExp = DateTime.Parse(certificate.GetExpirationDateString());
                        if (subExp.Subtract(DateTime.Now).TotalMilliseconds < 0)
                            return false;

                        if (!certificate.Issuer.Contains("remby.com"))
                            return false;

                        if (certificate.GetPublicKeyString() !=
                            "30818902818100CFA12E7024740C1FF7B19652A5E7C7DC4B90B4F054450698080FA4717800A1CC8F155B67B2E4D14EF6096411E02B7B5C8A520863F40ABF3FFA1898063C28F660F7C2EFDD8A6791F6D5928F660AB89571C917AFF30A52C87CB26764673ABEC86A8B24A662754650D3B3F7B4C1B6A1897FEC65D75666260F90B5FF91BDE5B7B7C90203010001")
                            return false;


                        return true;
                    };

            string url = RembyConstants.RembySignUpLink + "/book/alt/login";
//            string url = RembyConstants.RembySignUpLink + "/collector-login";
                // RAK: !!!!! use https to secure the username & password
            var data = new Dictionary<string, string>();
            data.Add("l", uname);

            if (hash)
                data.Add("p", password);
            else
                data.Add("p", HashString(password));

            data.Add("s", "1");
            username = uname;


            AppConfig.Instance.Username = uname;
            if (hash)
                AppConfig.Instance.Password = password;
            else
                AppConfig.Instance.Password = HashString(password);

            AppConfig.Instance.Store();

            var xDoc = new XmlDocument();
            string result = null;

            if (!Get(url, data, ref result))
            {
                Trace.TraceError(result);
                return false;
            }

            try
            {
                xDoc.LoadXml(result);
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
                return false;
            }

            XmlNodeList errors = xDoc.GetElementsByTagName("error");
            if (errors.Count > 0)
            {
                if (bDisplayError)
                {
                    string strErrorCode = errors[0].InnerText.Trim();
                    //Language.ShowFormattedMessage("error_login_failed", strErrorCode);
                    Trace.TraceError(strErrorCode);
                }
                return false;
            }
            try
            {
                uID = xDoc.GetElementsByTagName("result")[0].Attributes[0].Value;
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
                return false;
            }


            DebugHelper.Log("Input:" + url + "?" + data);
            DebugHelper.Log("Output:" + result);

            XmlNodeList messages = xDoc.GetElementsByTagName("message");

            if (messages != null && messages.Count > 0)
            {
                string msg = messages[0].InnerText.Trim();
                if (msg.StartsWith("Invalid"))
                {
                    return false;
                }
                else
                {
                    //AppConfig.subscriptions = new Subscription();
                    //AppConfig.subscriptions.loadXML();

                    securityID = msg;
                    return true; //  RAK: msg // earlier version returned msg to loadallbooks but it was being ignored
                }
            }
            return false;
        }

        /*
             2. alt/save - create/save set

            Input:

                   secu - security id

                   name - name of the set

            Output:

                   XML with success (set id for new slide) or error message
         */

        public static string createSet(int bookid)
        {
            //string url = "http://staging.Remby .com/book/alt/config";
            //string data = "secu=" + securityID;// +"&name=" + title;
            //XmlDocument xDoc = new XmlDocument();
            //string result = Get(url, data);
            //StreamWriter rtr = new StreamWriter("xmllog.txt", true);
            //rtr.WriteLine("Input:" + url + data);
            //rtr.WriteLine("Output:" + result);
            //rtr.Close();

            //xDoc.LoadXml(result);

            //XmlNodeList messages = xDoc.GetElementsByTagName("inbox");

            //if (messages != null && messages.Count > 0)
            //{
            //    string msg = messages[0].InnerText.Trim();
            //    if (msg.StartsWith("Invalid"))
            //    {
            //        return "Error";
            //    }
            //    else
            //    {
            //        RembyServices.setID = msg;
            //        return msg;
            //    }
            //}
            //else
            //{
            //    return "Error";
            //}

            setID = bookid.ToString();
            return setID;
        }

        /*
             3. alt/slide/save - create/save slide info 

            Input:

                   secu - security id

                   xml - slide(s) descriptive xml (new slide can be just one, slide id='0')

            Output:

                   XML with success (slide id for new slide) or error message
         */

        public static string createSlide(string xml)
        {
            string url = string.Format("{0}/book/alt/page/save", RembyConstants.RembyURL);
            var data = new Dictionary<string, string>();
            data.Add("secu", securityID);
            data.Add("xml", xml);
            var xDoc = new XmlDocument();

            string result = null;

            if (!Get(url, data, ref result))
            {
                return "Error";
            }
            //-----------------------------------------------------------------
            // Get was successfull.  Check the return string for errors
            //-----------------------------------------------------------------
            var rtr = new StreamWriter("xmllog.txt", true);
            rtr.WriteLine("Input:" + url + "?" + data);
            rtr.WriteLine("Output:" + result);
            rtr.Close();
            xDoc.LoadXml(result);

            XmlNodeList messages = xDoc.GetElementsByTagName("result");

            if (messages != null && messages.Count > 0)
            {
                string msg = messages[0].Attributes[0].InnerText.Trim();
                if (msg.StartsWith("Invalid"))
                {
                    return "Error";
                }
                else
                {
                    slideID = msg;
                    return msg;
                }
            }
            else
            {
                return "Error";
            }
        }

        /*
            4. alt/slide/save/thumb - Save slide thumbnail

            Input:

                   secu - security id

                   set_id - set id

                   slide_id - slide id

                   Filedata - data file with image

            Output:

                   XML with success or error
         */

        public static string slideThumbnail(string filename)
        {
            string url = string.Format("{0}/book/alt/page/save/thumb", RembyConstants.RembyURL);

            var cookies = new CookieContainer();
            var querystring = new NameValueCollection();

            querystring["secu"] = securityID;
            querystring["book_id"] = setID;
            querystring["page_id"] = slideID;
            string uploadfile = filename;


            //everything except upload file and url can be left blank if needed
            string result = UploadFileEx(uploadfile, url, "Filedata", "image/pjpeg", querystring, cookies);

            DebugHelper.Log("Input:" + url + "?" + filename);
            DebugHelper.Log("Output:" + result);

            return result;
        }

        public static string shortenURL(string URL = "")
        {
            try
            {
                string url =
                    "https://www.googleapis.com/urlshortener/v1/url?key=AIzaSyB2uiz6jOZ6vHpKIzeGsDOPKQpRClZG-tE";

                var querystring = new NameValueCollection();

                if (URL == "")
                {
                    /*if (lastResult.Contains("url"))
                    {
                        string[] parts = RembyClipper.Helpers.RembyServices.lastResult.Split(new char[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string p in parts)
                        {
                            string pt = p.Trim();
                            if (pt.StartsWith("'url':"))
                            {
                                URL = pt.Replace("'url':", "").Trim().Replace("'", "");
                                break;
                            }
                        }
                    }
                    else
                        return "error";*/
                    var msr = new MediaStoreResponse();
                    var serials = new Serializer(typeof (MediaStoreResponse));

                    msr = (MediaStoreResponse) serials.Deserialize(lastResult);
                    URL = msr.share_url;
                }

                querystring["longUrl"] = URL;
                string result = "";

                var request = (HttpWebRequest) WebRequest.Create(url);
                request.ContentType = "application/json; charset=utf-8";
                request.Accept = "application/json, text/javascript, */*";
                request.Method = "POST";
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write("{longUrl : '" + URL + "'}");
                }

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                string json = "";

                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        json += reader.ReadLine();
                    }
                }

                var serial = new Serializer(typeof (GoogleShortResponse));
                var gsr = (GoogleShortResponse) serial.Deserialize(json);

                result = gsr.id;
                DebugHelper.Log(result);
                return result;
            }
            catch (Exception e)
            {
                DebugHelper.Error(e.ToString());
                return "error";
            }
        }

        public static MediaStoreResponse uploadScreenShot(string filename, string ocr, string source, string tag)
        {
            if (AppConfig.Instance.legacyStorage)
            {
                var msr = new MediaStoreResponse();
                if (uploadScreenShotLegacy(filename, ocr, source, tag))
                    msr.status = "success";
                else
                    msr.status = "error";
                return msr;
            }
            else
                return uploadToMediaStore(filename, ocr, source, tag, MediaStoreTypes.screenshot);
        }

        public static MediaStoreResponse ChangeTagsForAnElement(string itemKey, string newTags)
        {
            try
            {
                string url = string.Format("{0}/_s/file/update_tags/", RembyConstants.MediaRembyURL);

                var querystring = new NameValueCollection();

                querystring["uid"] = AppConfig.Instance.Username;
                querystring["auth_token"] = securityID;
                querystring["key"] = itemKey;
                querystring["tags"] = newTags;

                DebugHelper.NVCDump(querystring);

                var ps = new PostSubmitter();
                ps.PostItems.Add(querystring);
                ps.Url = url;
                ps.Type = PostSubmitter.PostTypeEnum.Post;

                string result = "";
                //string result = wc.UploadString(url, data);
                using (WebResponse resultRS = Upload.PostContent(new Uri(url), querystring, null, null))
                {
                    using (var sr = new StreamReader(resultRS.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }

                var msr = new MediaStoreResponse();
                var serial = new Serializer(typeof (MediaStoreResponse));

                msr = (MediaStoreResponse) serial.Deserialize(result);
                Tags.GetTags();
                lastResult = result;
                DebugHelper.Log(result);
                return msr;
            }
            catch (Exception e)
            {
                DebugHelper.Error(e.ToString());
                var msr = new MediaStoreResponse();
                msr.status = "error";
                return msr;
            }
        }

        public static MediaStoreResponse uploadToMediaStore(NameValueCollection nvc, MediaStoreTypes mst)
        {
            try
            {
                string url = RembyConstants.MediaStoreURL + "/mediahub/_s/import/";

                var querystring = new NameValueCollection();

                querystring["uid"] = AppConfig.Instance.Username;
                querystring["file_role"] = mst.ToString();
                querystring["auth_token"] = securityID;

                querystring.Add(nvc);

                DebugHelper.NVCDump(querystring);

                var ps = new PostSubmitter();
                ps.PostItems.Add(querystring);
                ps.Url = url;
                ps.Type = PostSubmitter.PostTypeEnum.Post;

                string result = "";
                //string result = wc.UploadString(url, data);
                using (WebResponse resultRS = Upload.PostContent(new Uri(url), querystring, null, null))
                {
                    using (var sr = new StreamReader(resultRS.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }

                var msr = new MediaStoreResponse();
                var serial = new Serializer(typeof (MediaStoreResponse));

                msr = (MediaStoreResponse) serial.Deserialize(result);
                Tags.GetTags();
                lastResult = result;
                DebugHelper.Log(result);
                return msr;
            }
            catch (Exception e)
            {
                DebugHelper.Error(e.ToString());
                var msr = new MediaStoreResponse();
                msr.status = "error";
                return msr;
            }
        }

        public static MediaStoreResponse uploadToMediaStore(string filename, NameValueCollection nvc,
                                                            MediaStoreTypes mst)
        {
            try
            {
                string url = RembyConstants.MediaStoreURL + "/mediahub/_s/import/";

                var cookies = new CookieContainer();
                var querystring = new NameValueCollection();

                querystring["uid"] = AppConfig.Instance.Username;
                querystring["file_role"] = mst.ToString();
                querystring["auth_token"] = securityID;
                querystring.Add(nvc);

                DebugHelper.NVCDump(querystring);
                string uploadfile = filename;

                var wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.QueryString = querystring;
                //string result = System.Text.ASCIIEncoding.ASCII.GetString(wc.UploadFile(url, filename));
                string result = "error";
                using (WebResponse wr = Upload.PostFile(new Uri(url), querystring, filename, null, "file", null, null))
                using (var sr = new StreamReader(wr.GetResponseStream()))
                    result = sr.ReadToEnd();

                DebugHelper.Log("Input:" + url + "?" + filename);
                DebugHelper.Log("Output:" + result);

                var msr = new MediaStoreResponse();
                var serial = new Serializer(typeof (MediaStoreResponse));

                msr = (MediaStoreResponse) serial.Deserialize(result);

                lastResult = result;

                Tags.GetTags();

                return msr;
            }
            catch (Exception e)
            {
                DebugHelper.Error(e.ToString());
                var msr = new MediaStoreResponse();
                msr.status = "error";
                return msr;
            }
        }

        public static MediaStoreResponse uploadToMediaStore(string filename, string ocr, string source, string tag,
                                                            MediaStoreTypes mst)
        {
            var querystring = new NameValueCollection();

            querystring["source_url"] = source;
            querystring["description"] = ocr;
            querystring["tags"] = tag;
            return uploadToMediaStore(filename, querystring, mst);
        }

        private static bool uploadScreenShotLegacy(string filename, string ocr, string source, string tag)
        {
            string url = RembyConstants.RembyURL + "/alt/screenshot/add";

            var cookies = new CookieContainer();
            var querystring = new NameValueCollection();

            querystring["secu"] = securityID;
            querystring["text"] = ocr;
            querystring["source"] = source;
            querystring["tag"] = tag;
            string uploadfile = filename;


            //everything except upload file and url can be left blank if needed
            string result = UploadFileEx(uploadfile, url, "Filedata", "image/pjpeg", querystring, cookies);
#if INTERNAL

            DebugHelper.Log("Input:" + url + "?" + filename);
            DebugHelper.Log("Output:" + result);
#endif

            if (result.ToLower().Contains("error"))
                return false;
            else
                return true;
        }

        /*
             5. alt/slide/addobject - add object to the slide

            Input:

                   secu - security id

                   set_id - set id

                   slide_id - slide id

                   object_type - 1 - text, 2 - image, 3 - video, 4 - audio

                   Filedata - data file or text (not file)

            Output:

                   XML with success or error message & with object ID if new

         */

        public static string slideAddobject(string fileData, int objectType)
        {
            string url = string.Format("{0}/book/alt/page/addobject", RembyConstants.RembyURL);
            string retvalue = "";
            StreamWriter rtr;
            var data = new Dictionary<string, string>();
            switch (objectType)
            {
                case OBJECT_TYPE_TEXT: // RAK: Always use named constants
                    data.Add("secu", securityID);
                    data.Add("book_id", setID);
                    data.Add("page_id", slideID);
                    data.Add("object_type", "1");
                    data.Add("Filedata", fileData);
                    if (Get(url, data, ref retvalue))
                    {
                        rtr = new StreamWriter("xmllog.txt", true);
                        rtr.WriteLine("Input:" + url + "?" + data);
                        rtr.WriteLine("Output:" + retvalue);
                        rtr.Close();
                    }
                    break;
                case OBJECT_TYPE_IMAGE:
                case OBJECT_TYPE_AUDIO:
                case OBJECT_TYPE_FILE:
                    var cookies = new CookieContainer();
                    var querystring = new NameValueCollection();

                    querystring["secu"] = securityID;
                    querystring["book_id"] = setID;
                    querystring["page_id"] = slideID;
                    querystring["object_type"] = objectType.ToString();

                    string uploadfile = fileData;

                    //everything except upload file and url can be left blank if needed

                    string strType = objectType == OBJECT_TYPE_IMAGE
                                         ? "image/pjpeg"
                                         : objectType == OBJECT_TYPE_AUDIO ? "audio" : null;

                    retvalue = UploadFileEx(uploadfile, url, "Filedata", strType, querystring, cookies);
                    rtr = new StreamWriter("xmllog.txt", true);
                    rtr.WriteLine("Input:" + url + "?" + fileData);
                    rtr.WriteLine("Output:" + retvalue);
                    rtr.Close();
                    break;

                case OBJECT_TYPE_SHAPE:
                    data.Add("secu", securityID);
                    data.Add("book_id", setID);
                    data.Add("page_id", slideID);
                    data.Add("object_type", "5");
                    data.Add("Filedata", fileData);
                    if (Get(url, data, ref retvalue))
                    {
                        rtr = new StreamWriter("xmllog.txt", true);
                        rtr.WriteLine("Input:" + url + "?" + data);
                        rtr.WriteLine("Output:" + retvalue);
                        rtr.Close();
                    }
                    break;
                case OBJECT_TYPE_VIDEO_URL: // 6
                    data.Add("secu", securityID);
                    data.Add("book_id", setID);
                    data.Add("page_id", slideID);
                    data.Add("object_type", "6");
                    data.Add("Filedata", fileData);
                    if (Get(url, data, ref retvalue))
                    {
                        rtr = new StreamWriter("xmllog.txt", true);
                        rtr.WriteLine("Input:" + url + "?" + data);
                        rtr.WriteLine("Output:" + retvalue);
                        rtr.Close();
                    }
                    break;
                case OBJECT_TYPE_URL: // 8:
                    data.Add("secu", securityID);
                    data.Add("book_id", setID);
                    data.Add("page_id", slideID);
                    data.Add("object_type", "8");
                    data.Add("Filedata", fileData);
                    if (Get(url, data, ref retvalue))
                    {
                        rtr = new StreamWriter("xmllog.txt", true);
                        rtr.WriteLine("Input:" + url + "?" + data);
                        rtr.WriteLine("Output:" + retvalue);
                        rtr.Close();
                    }
                    break;
            }

            return retvalue;
        }

        public static string slideSaveElements(string elementsXML)
        {
            string url = string.Format("{0}/book/alt/page/save", RembyConstants.RembyURL);
            var data = new Dictionary<string, string>();
            data.Add("secu", securityID);
            data.Add("xml", elementsXML);
            var xDoc = new XmlDocument();
            string result = null;

            if (!Get(url, data, ref result))
            {
                return "Error";
            }
            var rtr = new StreamWriter("xmllog.txt", true);
            rtr.WriteLine("Input:" + url + "?" + data);
            rtr.WriteLine("Output:" + result);
            rtr.Close();

            return result;
            //xDoc.LoadXml(Get(url, data));

            //XmlNodeList messages = xDoc.GetElementsByTagName("course");

            //if (messages != null && messages.Count > 0)
            //{
            //    string msg = messages[0].Attributes[0].InnerText.Trim();
            //    if (msg.StartsWith("Invalid"))
            //    {
            //        return "Error";
            //    }
            //    else
            //    {
            //        RembyServices.slideID = msg;
            //        return msg;
            //    }
            //}
            //else
            //{
            //    return "Error";
            //}
        }

        public static DataTable getAllBooks()
        {
            string url = string.Format("{0}/books/alt/getlist", RembyConstants.RembyURL);
            var data = new Dictionary<string, string>();
            data.Add("secu", securityID);
            var xDoc = new XmlDocument();

            string result = null;

            if (!Get(url, data, ref result))
            {
                //if (bDisplayError)
                //    Language.ShowFormattedMessage("error_login_failed", result);
                Trace.TraceError(result);
                return null;
            }
            xDoc.LoadXml(result);

            XmlNodeList error = xDoc.GetElementsByTagName("error");

            if (error.Count > 0)
            {
                string strErrorCode = error[0].InnerText.Trim();
                Trace.TraceError(strErrorCode);
                return null;
            }
            XmlNodeList messages = xDoc.GetElementsByTagName("item");

            var rtr = new StreamWriter("xmllog.txt", true);
            rtr.WriteLine("Input:" + url + "?" + data);
            rtr.WriteLine("Output:" + result);
            rtr.Close();

            var bmp = new Bitmap(1, 1);
            Image img = bmp;

            var tbl = new DataTable();
            tbl.Columns.Add("ID", int.MinValue.GetType());
            //tbl.Columns.Add("DateCreated", DateTime.Now.GetType());
            tbl.Columns.Add("Name", String.Empty.GetType());
            //tbl.Columns.Add("Image", img.GetType());
            tbl.Columns.Add("Access", String.Empty.GetType());


            int id = 0;
            string name = "";
            string access = "";
            DateTime datecreated = DateTime.Now;


            try
            {
                foreach (XmlNode node in messages)
                {
                    if (node.Attributes["specialType"].InnerText == "trash" ||
                        node.Attributes["specialType"].InnerText == "all")
                        continue;
                    XmlNode node2 = node.ChildNodes[0];
                    id = int.Parse(node.Attributes["id"].InnerText);
                    access = node.Attributes["access"].InnerText;

                    for (int i = 0; i < node2.ChildNodes.Count; i++)
                    {
                        if (node2.ChildNodes[i].Name == "name")
                        {
                            name = node2.ChildNodes[i].InnerText.Replace("<![CDATA[", "").Replace("]]", "");
                            continue;
                        }

                        //if (node2.ChildNodes[i].Name == "created")
                        //{
                        //    datecreated = DateTime.Parse(node2.ChildNodes[i].InnerText.Replace("Created", ""));
                        //    continue;
                        //}


                        //if (node2.ChildNodes[i].Name == "image")
                        //{
                        //    //load image
                        //    img = getImageForURL("http://staging.remby .com" + node2.ChildNodes[i].InnerText.Trim().Replace("<![CDATA[", "").Replace("]]", "").Replace("<img src=\"", "").Replace("\">", ""));
                        //    continue;
                        //}
                    }
                    DataRow dr = tbl.NewRow();

                    dr[0] = id;
                    //dr[1] = datecreated;
                    dr[1] = name;
                    //dr[3] = img;
                    dr[2] = access;

                    tbl.Rows.Add(dr);
                }
            }
            catch (Exception exp)
            {
                Trace.TraceError(exp.ToString());
                MessageBox.Show(@"Unable to retrieve the list of books");
                    // RAK: !!!!! Review the message.  Ok  to use MessageBox here?
                //tbl = null;
            }

            return tbl;
        }

        public static Dictionary<string, string> getAllBooks(bool s)
        {
            string url = RembyConstants.RembyURL + "/books/alt/getlist";
            var data = new Dictionary<string, string>();
            data.Add("secu", securityID);
            var xDoc = new XmlDocument();

            string result = null;

            if (!Get(url, data, ref result))
            {
                Trace.TraceError(result);
                return null;
            }
            xDoc.LoadXml(result);

            XmlNodeList error = xDoc.GetElementsByTagName("error");

            if (error.Count > 0)
            {
                string strErrorCode = error[0].InnerText.Trim();
                Trace.TraceError(strErrorCode);
                return null;
            }
            XmlNodeList messages = xDoc.GetElementsByTagName("item");


            DebugHelper.Log("Input:" + url + "?" + data);
            DebugHelper.Log("Output:" + result);


            int id = 0;
            string name = "";
            string access = "";
            var tmpList = new Dictionary<string, string>();

            try
            {
                foreach (XmlNode node in messages)
                {
                    if (node.Attributes["specialType"].InnerText == "trash" ||
                        node.Attributes["specialType"].InnerText == "all")
                        continue;
                    XmlNode node2 = node.ChildNodes[0];
                    id = int.Parse(node.Attributes["id"].InnerText);
                    access = node.Attributes["access"].InnerText;

                    for (int i = 0; i < node2.ChildNodes.Count; i++)
                    {
                        if (node2.ChildNodes[i].Name == "name")
                        {
                            name = node2.ChildNodes[i].InnerText.Replace("<![CDATA[", "").Replace("]]", "");
                            continue;
                        }
                    }

                    tmpList.Add(id.ToString(), name);
                }
            }
            catch (Exception exp)
            {
                Trace.TraceError(exp.ToString());
                MessageBox.Show(@"Unable to retrieve the list of books");
                    // RAK: !!!!! Review the message.  Ok  to use MessageBox here?
                //tbl = null;
            }

            return tmpList;
        }


        public static string UploadFileEx(string uploadfile, string url,
                                          string fileFormName, string contenttype, NameValueCollection querystring,
                                          CookieContainer cookies)
        {
            if (string.IsNullOrEmpty(fileFormName))
            {
                fileFormName = "file";
            }

            if (string.IsNullOrEmpty(contenttype))
            {
                contenttype = "application/octet-stream";
            }


            string postdata = "?";
            if (querystring != null)
            {
                foreach (string key in querystring.Keys)
                {
                    postdata += key + "=" + Uri.UnescapeDataString(querystring.Get(key)) + "&";
                }
            }
            var uri = new Uri(url + postdata);


            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            var webrequest = (HttpWebRequest) WebRequest.Create(uri);
            webrequest.CookieContainer = cookies;
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";


            // Build up the post message header
            var sb = new StringBuilder();
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append(fileFormName);
            sb.Append("\"; filename=\"");
            sb.Append(Path.GetFileName(uploadfile));
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append(contenttype);
            sb.Append("\r\n");
            sb.Append("\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

            // Build the trailing boundary string as a byte array
            // ensuring the boundary appears on a line by itself
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            var fileStream = new FileStream(uploadfile, FileMode.Open, FileAccess.Read);
            long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            webrequest.ContentLength = length;

            Stream requestStream = webrequest.GetRequestStream();

            // Write out our post header
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // Write out the file contents
            var buffer = new Byte[checked((uint) Math.Min(4096, (int) fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);

            // Write out the trailing boundary
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            WebResponse responce = webrequest.GetResponse();
            Stream s = responce.GetResponseStream();
            var sr = new StreamReader(s);

            return sr.ReadToEnd();
        }

        public static bool Get(string url, Dictionary<string, string> data, ref string returnString)
        {
            bool bReturn = false;
            try
            {
                var webClient = new CookieAwareWebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");

                foreach (string key in data.Keys)
                {
                    webClient.QueryString.Add(key, data[key]);
                }
                returnString = webClient.DownloadString(url);
                LoginCookieContainer = webClient.CookieContainer;
                bReturn = true;
            }
            catch (Exception ex)
            {
                //Trace.TraceError(ex.ToString());
                returnString = ex.Message;
            }
            returnString.Trim();
            return bReturn;
        }
        public static bool Post(string url, Dictionary<string, string> data, ref string returnString)
        {
            bool bReturn = false;
            try
            {
                var webClient = new CookieAwareWebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
                string prms = "";
                foreach (string key in data.Keys)
                {
                    if(prms.HasValue())
                    {
                        prms += "&";
                    }
                    prms += string.Format("{0}={1}", key, data[key]);
                }
                returnString = webClient.UploadString(url, prms);
                LoginCookieContainer = webClient.CookieContainer;
                bReturn = true;
            }
            catch (Exception ex)
            {
                //Trace.TraceError(ex.ToString());
                returnString = ex.Message;
            }
            returnString.Trim();
            return bReturn;
        }


        public static Image getImageForURL(string url)
        {
            Image img = null;
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();

                var length = (int) response.ContentLength;

                var bytes = new byte[length];

                stream.Read(bytes, 0, length);

                string ticks = DateTime.Now.Ticks.ToString();

                Stream output = File.Create("objtemp" + ticks + ".jpg");

                output.Write(bytes, 0, bytes.Length);

                output.Close();
                output.Dispose();
                img = ImageHelper.LoadFromFile("objtemp" + ticks + ".jpg");
            }
            catch (Exception exp)
            {
                Trace.TraceError(exp.Message);
                img = null;
            }

            return img;
        }

        private static string HashString(string Value)
        {
            var x = new MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }
    }
}