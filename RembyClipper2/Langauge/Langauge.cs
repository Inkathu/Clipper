using System;
using System.Collections.Generic;
using System.Text;
using RembyClipper2.Helpers;
using System.IO;
using System.Collections.Specialized;
using RembyClipper2.Config;

namespace RembyClipper2.Langauge
{
    [Serializable]
    public class Langauge
    {
        private NameValueCollection languageSet = new NameValueCollection();
        private NameValueCollection currentLanguage = new NameValueCollection();
        public enum SupportedLanguages { English, Swedish };

        public Langauge()
        {
            LoadDefault();
            //LoadLang(AppConfig.Instance.CurrentLanguage);
        }

        public void LoadDefault()
        {
            languageSet.Add("Button_Cancel","Cancel");
            languageSet.Add("Button_Continue","Continue");
            languageSet.Add("Button_Close","Close");
            languageSet.Add("Button_CloseThisWindow", "Close this window.");
            languageSet.Add("Button_Login","Login");
            languageSet.Add("Button_AddRemby","Add to Remby");
            languageSet.Add("Button_Save","Save");
            languageSet.Add("Button_SaveChanges", "Save changes");
            
            languageSet.Add("FirstUserExperience_FormTitle","Remby screen video");
            languageSet.Add("FirstUserExperience_title", @"To add your video to Remby, 
You need to upload it to YouTube");
            languageSet.Add("FirstUserExperience_body1",@"In the next step, we will ask you to log in 
to your existing YouTube account or to 
create a new one.");
            languageSet.Add("FirstUserExperience_body2",@"After uploading your video, you can use 
it in Remby by choosing ”Video” from 
the toolbar.");
            languageSet.Add("FirstUserExperence_dontshow",@"Don't show this screen again");
            languageSet.Add("YouTube_legal",@"By uploading your video, you certify that you own all rights to the content or that you are authorized by the 
owner to make the content publicly available on YouTube, and that it otherwise complies with the 
YouTube Terms of Service");

            languageSet.Add("RembyDone_YouTubeDone","Your video has been uploaded to YouTube.");
            languageSet.Add("RembyDone_RembyDone","Your screenshot has been uploaded to Remby");
            languageSet.Add("RembyDone_OpenRemby","Open screenshot in Remby.");
            languageSet.Add("RembyDone_OpenYouTube","Open video in YouTube");


            languageSet.Add("RembyLogin_Title","Please log into your Remby account");
            languageSet.Add("RembyLogin_Username","Username or email address");
            languageSet.Add("RembyLogin_Password","Password");
            languageSet.Add("RembyLogin_RememberMe","Remember me?");
            languageSet.Add("RembyLogin_DontHaveAccount","Don't have a Remby account?");
            languageSet.Add("RembyLogin_CreateAccount","Go to Remby to create an account");

            languageSet.Add("RembyScreenshot_Source","Source");
            languageSet.Add("RembyScreenshot_CopiedToClipboard","Image has been copied to your clipboard");

            languageSet.Add("RembyUpload_UploadingToRemby","We are uploading your screenshot to Remby");
            languageSet.Add("RembyUpload_UploadingToYouTube","We're uploading your video to YouTube");

            languageSet.Add("RembyVideo_Title","Title");
            languageSet.Add("RembyVideo_Tags","Tags");
            languageSet.Add("RembyVideo_Description","Description");
            languageSet.Add("RembyVideo_Category","Category");
            languageSet.Add("RembyVideo_TitleText","Remby screen video - ");
            languageSet.Add("RembyVideo_TagsText","Remby, Screen video");
            languageSet.Add("RembyVideo_YouTubeLegal", @"By uploading your video, you certify that you own all rights to the content or that you are authorized by the 
owner to make the content publicly available on YouTube, and that it otherwise complies with the 
YouTube Terms of Service");

            languageSet.Add("RembyYouTubeLogin_Title","Your video will be stored on YouTube.\nPlease log into your YouTube account");
            languageSet.Add("RembyYouTubeLogin_KeepLoggedIn",@"We will keep you logged in until you quit Remby clipper.
And we will not store your password. Promised.");
            languageSet.Add("RembyYouTubeLogin_DontHaveAccount","Don't have a YouTube account?");
            languageSet.Add("RembyYouTubeLogin_CreateAccount","Go to YouTube to create an account");

            languageSet.Add("Options_Title","Settings");
            languageSet.Add("Options_General","General");
            languageSet.Add("Options_Video","Screen video");
            languageSet.Add("Options_LogOut","Log out");
            languageSet.Add("Options_Video_Title","Video");
            languageSet.Add("Options_Video_FrameRate","Framerate");
            languageSet.Add("Options_Video_YouTubePrivate","Mark video as private on YouTube?");
            languageSet.Add("Options_Audio_Title","Audio");
            languageSet.Add("Options_Audio_Channels","Channels");
            languageSet.Add("Options_Audio_Sample","Sample frequency (Hz)");
            languageSet.Add("Options_Audio_Bitrate","Bitrate (Bits)");
            languageSet.Add("Options_Audio_Bitspersample","Bit per sample");
            languageSet.Add("Options_Webcam_Title","Webcam");
            languageSet.Add("Options_Webcam_Device","Device");
            languageSet.Add("Options_RembyAccount","Remby account");
            languageSet.Add("Options_LoggedIn","Logged in as:");
            languageSet.Add("Options_StartWithWindows","Start automatically with Windows?");
            languageSet.Add("Options_Language_Title", "Language");
            languageSet.Add("Options_Language_UseIn", "Use RembyClipper in");

            languageSet.Add("Remby_ImgView_Title", "Remby screenshot");
            languageSet.Add("Remby_VideoView_Title", "Remby screen video");
            languageSet.Add("Remby_Login_Title", "Login");

            languageSet.Add("OCR_FormTitle", "Remby screenshot OCR");
            languageSet.Add("OCR_Title1", "Extracted text");
            languageSet.Add("OCR_Title2", " (we’ll use this text to index the screenshot on Remby)");
            languageSet.Add("OCR_Quality", "OCR Quality:");
            languageSet.Add("OCR_HowToImprove", "How to improve OCR quality");
            languageSet.Add("OCR_TextCopied", "Text has been copied to your clipboard");
            languageSet.Add("OCR_Tips", @"Optical Character Recognition, OCR, works best with black text on a white background and where the text is 12p or larger.
Common, simple fonts will read better than elaborate hand-writing-style fonts.

Pictures within the screenshot will sometimes be interpreted as text and will create nonsense characters.

For best results try the following: 
-Make sure you copy only one column at a time
-Copy from pages with 12p or larger fonts
-Copy from pages with simple fonts. Avoid handwriting style fonts. 
-Copy only text and avoid pictures in the selection
");

            languageSet.Add("Error_VideoUpload", "There was an error during video upload.");

            languageSet.Add("Error_LoadingVideo", "There was an error loading your video.");
            languageSet.Add("Tray_About", "About");
            languageSet.Add("Tray_Options", "Settings");
            languageSet.Add("Tray_Exit", "Exit");

            languageSet.Add("ToolTip_Copy", "Copy to clipboard");
            languageSet.Add("ToolTip_OCR", "Show OCR");
            languageSet.Add("ToolTip_Save", "Save to file");
            languageSet.Add("ToolTip_Mute", "Mute");
            languageSet.Add("ToolTip_UnMute", "Unmute");
            languageSet.Add("ToolTip_WebcamOFF", "Turn webcam off");
            languageSet.Add("ToolTip_WebcamON", "Turn webcam on");
            languageSet.Add("ToolTip_WebcamDisabled", "You don't have a webcam attached.");

            languageSet.Add("TopNav_Capture", "Screen capture");
            languageSet.Add("TopNav_Video", "Screen video");
            languageSet.Add("TopNav_History", "History (refreshing)");
            languageSet.Add("TopNav_Close", "Exit");

            languageSet.Add("TopNav_Uploading", "Uploading");
            languageSet.Add("TopNav_Uploaded", "Uploaded");
            languageSet.Add("TopNav_Error", "Server issue, try again later.");
                                             
            languageSet.Add("TopNav_Hi", "Hi");
            languageSet.Add("TopNav_Exit", "Are you sure you want to exit the RembyClipper?");

            languageSet.Add("History_Title", "History");
            languageSet.Add("History_ListTitle", "History");
            languageSet.Add("History_Screenshot", "Screenshot");
            languageSet.Add("History_Screenvideo", "Screen video");

            languageSet.Add("Windows_Open", "Open Windows");
            languageSet.Add("Windows_Screenshot", "Screenshot");
            languageSet.Add("Windows_Screenvideo", "Screen video");

            languageSet.Add("Error_InvalidCredentials", "Invalid credentials");


        }

        public string GetValue(string key)
        {
            try
            {
                string r = currentLanguage[key];
                if (r == "" || r == null)
                    return languageSet[key];
                else
                    return r;
            }
            catch
            {
                return languageSet[key];
            }
        }

        public void ExportDefault()
        {
            var x = new XmlSerialisation();
            ExtendedNVC nvc = new ExtendedNVC(this.languageSet);
            string xml = x.SerializeObject(nvc, typeof(ExtendedNVC));
            using (StreamWriter sw = new StreamWriter("english.xml",false))
                sw.WriteLine(xml);
        }

       

        public void LoadLang(SupportedLanguages lang)
        {
            var x = new XmlSerialisation();
            object p = languageSet;
            if (lang == SupportedLanguages.English)
            {
                currentLanguage = languageSet;
                return;
            }
            if (lang == SupportedLanguages.Swedish)
                p = x.DeserializeObject(Swedish.XML, typeof(ExtendedNVC));

            currentLanguage = ((ExtendedNVC)p).Properties;
        }
    }
}
