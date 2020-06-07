using System;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using JsonExSerializer;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Meesenger.Uploading.UploadingStrategies;

namespace RembyClipper2.Utils.Uploading.UploadingStrategies.Drupal
{
    public class DrupalUploader : IUploader
    {
        private string _userId;
        private string _userToken;
        private string _sessionId;

        //private string UploadUrl = "http://store.remby.com/";
//        private string UploadUrlText = "http://store.remby.com/_s/stuff/mine/resource/create";
//        private string UploadUrlUrl  = "http://store.remby.com/_s/stuff/mine/resource/import";
//        private string UploadUrlInfo = "http://store.remby.com/_s/stuff/mine/resource/upload";

        private string UploadUrlText = "http://www.remby.com/_s/item/";
        private string UploadUrlUrl = "http://www.remby.com/_s/item/import/";
        private string UploadUrlInfo = "http://www.remby.com/_s/item/upload/";
        
        public DrupalUploader(string userId, string userToken, string sessionId)
        {
            _userId = userId;
            _userToken = userToken;
            _sessionId = sessionId;
//            _sessionId = @"hn+mqGj3Rz9AO0VPzVso6qPu+B0=?_csrf_token=Uyc4NzU3NzIzZi0xYTdiLTRmNDQtOTgxYS02YzZkNGI3NWVlYWQnCnAxCi4=&_fresh=STAxCi4=&_id=UydceDExXHg5MVx4ZTZceDAxXHhjYVx4ODlceDE1XHhmZjN8XHRzXHgxZlx4ODJceDAwXHhlYicKcDEKLg==&user_id=VmFndHpmbkpsYldKNUxXeGhZbklNQ3hJRVZYTmxjaGktX3djTQpwMQou";
        }


//        public FileUploadingResponse UploadFileStream()
//        {
//            
//        }

        public MediaStoreResponse UploadFile(string path, string filename, string description, string text, string tags, string originalContextUrl = "", string source_url = "", UploadEntityRole role = UploadEntityRole.unknown)
        {
            string url = Upload.RequestUrlByGet(UploadUrlInfo);
            Serializer serializer = new Serializer(typeof(FileUploadingUrlResponse));
//            FileUploadingUrlResponse res = (FileUploadingUrlResponse)serializer.Deserialize(result);
           
            NameValueCollection query = new NameValueCollection();
            query["session"] = _sessionId;
            //query["x-remby-drupal-user_id"] = _userId;//rfr,sabhvf
            //query["x-remby-drupal-user_token"] = _userToken;
            query["name"] = filename;
            query["file"] = filename;
            if (role == UploadEntityRole.screenshot)
            {
                query["role"] = role.ToString();
                query["original_context_url"] = originalContextUrl.HasValue() && originalContextUrl.ToLower().Contains("http") ? originalContextUrl : "";
            }
            //query["description"] = description;
            //query["text"] = text;
            
            
            
            //query["source_url"] = source_url;

            query["tags"] = tags;


            string resp = "";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)Upload.PostFile(new Uri(url), query, path, null, "file", null, null))
                {
                    Stream strm;
                    switch (response.ContentEncoding.ToUpperInvariant())
                    {
                        case "GZIP":
                            strm = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                            break;
                        case "DEFLATE":
                            strm = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
                            break;

                        default:
                            strm = response.GetResponseStream();
                            //strm.ReadTimeout = 1000;
                            break;
                    }
                
                

                    using (var stream = new StreamReader(strm))
                    {
                        
                        resp = stream.ReadToEnd();
                        bool fail = resp.Contains("error");
                        if(fail)
                        {
                            DebugHelper.Log("[DrupalUploader] UploadFile - Response with error received : " + resp);
                        }
                        serializer = new Serializer(fail ? typeof(FailResponse) : typeof(FileUploadingResponse));
                        FileUploadingResponse uploadingResponse = fail ? null : (FileUploadingResponse)serializer.Deserialize(resp);
                        FailResponse failResponse = fail ? (FailResponse)serializer.Deserialize(resp) : null;
                        return fail ? new MediaStoreResponse()
                                          {
                                              error_code = failResponse.error_code,
                                              status = failResponse.status,
                                          }
                            : new MediaStoreResponse()
                                   {
                                       content_type = uploadingResponse.result.content_type,
                                       error_code = "",
                                       file_role = uploadingResponse.result.category,
                                       share_url = uploadingResponse.result.canonical_url,
                                       short_url = uploadingResponse.result.canonical_url,
                                       source_url = uploadingResponse.result.canonical_url,
                                       status = uploadingResponse.status,
                                       url = uploadingResponse.result.canonical_url
                                   };
                    }
                }
            }
            catch(Exception exc)
            {
                DebugHelper.Log("[DrupalUploader] - file upload problem :\r\n" + exc.ToString());
                return new MediaStoreResponse(){ status = "fail"};
            }
            
        }

        public MediaStoreResponse UploadText(string text, string description, string tags, string originalContextUrl, UploadEntityRole role)
        {
            
            NameValueCollection query = new NameValueCollection();
            query["session"] = _sessionId;
            //query["x-remby-drupal-user_id"] = _userId;
            //query["x-remby-drupal-user_token"] = _userToken;
            query["name"] = "";
            query["text"] = text;
            query["original_context_url"] = originalContextUrl;
            query["tags"] = tags;
            string resp = "";
            try
            {
                using (var response = Upload.PostContent(new Uri(UploadUrlText), query, null, null))
                {
                    using (var stream = new StreamReader(response.GetResponseStream()))
                    {
                        resp = stream.ReadToEnd();
                        bool fail = resp.Contains("error");
                        if (fail)
                        {
                            DebugHelper.Log("[DrupalUploader] UploadText - Response with error received : " + resp);
                        }
                        Serializer serializer = new Serializer(typeof(TextUploadingResponse));
                        TextUploadingResponse textUploadingResponse = (TextUploadingResponse)serializer.Deserialize(resp);
                        return new MediaStoreResponse()
                        {
                            content_type = textUploadingResponse.result.content_type,
                            error_code = "",
                            file_role = textUploadingResponse.result.category,
                            share_url = textUploadingResponse.result.canonical_url,
                            short_url = textUploadingResponse.result.canonical_url,
                            source_url = textUploadingResponse.result.canonical_url,
                            status = textUploadingResponse.status,
                            url = textUploadingResponse.result.canonical_url
                        };
                    }
                }
            }
            catch(Exception exc)
            {
                DebugHelper.Log("[DrupalUploader] - text upload problem :\r\n" + exc.ToString());
                return new MediaStoreResponse() { status = "fail" };
            }
        }

        public MediaStoreResponse UploadUrl(string url, string description, string tags, string originalContextUrl, string name, UploadEntityRole role)
        {
            NameValueCollection query = new NameValueCollection();
            query["session"] = _sessionId;
            query["name"] = name;
            //query["x-remby-drupal-user_id"] = _userId;
            //query["x-remby-drupal-user_token"] = _userToken;
            //query["description"] = description;
            query["source_url"] = url;


            if (originalContextUrl.HasValue())
            {
                query["original_context_url"] = originalContextUrl.HasValue() ? originalContextUrl : "";    
            } 
            else
            {
                //Uri uri = new Uri(url);
                query["original_context_url"] = "";
            }
            query["tags"] = tags;
            string resp = "";
            try
            {
                using (var response = Upload.PostContent(new Uri(UploadUrlUrl), query, null, null))
                {
                    if (response != null)
                    {
                        using (var stream = new StreamReader(response.GetResponseStream()))
                        {
                            resp = stream.ReadToEnd();
                            bool fail = resp.Contains("error");
                            if (fail)
                            {
                                DebugHelper.Log("[DrupalUploader] UploadUrl - Response with error received : " + resp);
                            }
                            Serializer serializer = fail ? new Serializer(typeof(FailResponse)): new Serializer(typeof(LinkUploadingResponse));
                            LinkUploadingResponse linkUploadingResponse = fail ? null : (LinkUploadingResponse)serializer.Deserialize(resp);
                            FailResponse fResponse = fail ? (FailResponse)serializer.Deserialize(resp):null;
                            return fail ?
                                new MediaStoreResponse()
                                    {
                                        error_code = fResponse.error_code,
                                        status = fResponse.status
                                    }
                                : new MediaStoreResponse()
                                       {
                                           content_type = linkUploadingResponse.result.content_type,
                                           error_code = "",
                                           file_role = linkUploadingResponse.result.category,
                                           share_url = linkUploadingResponse.result.canonical_url,
                                           short_url = linkUploadingResponse.result.canonical_url,
                                           source_url = linkUploadingResponse.result.source_url,
                                           status = linkUploadingResponse.status,
                                           url = linkUploadingResponse.result.canonical_url
                                       };
                        }
                    }
                }
            }
            catch(Exception exc)
            {
                DebugHelper.Log("[DrupalUploader] - url upload problem :\r\n" + exc.ToString());
            }
            
            return new MediaStoreResponse(){status = "fail"};
        }
    }
}