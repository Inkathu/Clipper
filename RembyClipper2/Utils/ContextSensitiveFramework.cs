using System;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.Forms.InformationDialog;

namespace RembyClipper2.Utils
{
    public class ContextSensitiveFramework
    {
        public const string YouTube       = "youtube";
        public const string FileUploading = "file uploading";
        public const string VideoUploading = "video uploading";
        Random rnd = new Random();
        public static ContextSensitiveFramework Instance
        {
            get { return _instance; }
        }

        private static ContextSensitiveFramework _instance = new ContextSensitiveFramework();

        static ContextSensitiveFramework()
        {
        }

        public ContextSensitiveFramework()
        {
        }

        public void ShowRandomMessages()
        {
            if (!AppConfig.Instance.ShowRandomMessage)
            {
                return;
            }
            int r = rnd.Next(20);
            if(r == 10)//just rundom value
            {
                InfoBoxDispatcher.ShowNotificationWithDonShowAgain(LanguageMgr.LM.GetText(Labels.ContextMessageRandom), (showAgain =>
                {
                    AppConfig.Instance.ShowRandomMessage = !showAgain;
                    AppConfig.Instance.Store();
                }));
                
            }
        }

        public void CheckContext(string context)
        {
            if(!context.HasValue())
            {
                return;
            }

            if (context.ToLower().Contains(YouTube) && AppConfig.Instance.ShowYouTubeMessage)
            {
                InfoBoxDispatcher.ShowNotificationWithDonShowAgain(LanguageMgr.LM.GetText(Labels.ContextMessageYouTubeRecording), (showAgain =>
                                                                                      {
                                                                                          AppConfig.Instance.ShowYouTubeMessage = !showAgain;
                                                                                          AppConfig.Instance.Store();
                                                                                      }));
            }
            else if (context.ToLower().Contains(FileUploading) && AppConfig.Instance.ShowFileUploadingMessage)
            {
                InfoBoxDispatcher.ShowNotificationWithDonShowAgain(LanguageMgr.LM.GetText(Labels.ContextMessageFileDragging), (showAgain =>
                {
                    AppConfig.Instance.ShowFileUploadingMessage = !showAgain;
                    AppConfig.Instance.Store();
                }));                
            }
            else if (context.ToLower().Contains(VideoUploading) && AppConfig.Instance.ShowVideoUploadingMessage)
            {
                InfoBoxDispatcher.ShowNotificationWithDonShowAgain(LanguageMgr.LM.GetText(Labels.ContextMessageUploadVideoFile), (showAgain =>
                {
                    AppConfig.Instance.ShowVideoUploadingMessage = !showAgain;
                    AppConfig.Instance.Store();
                }));                
            }
        }

    }
}