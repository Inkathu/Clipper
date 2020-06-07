using System;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Utils.Uploading.UploadingStrategies;
using RembyClipper2.Utils.Uploading.UploadingStrategies.Drupal;

namespace RembyClipper2.Utils.Uploading.Entities
{
    public delegate void UploadStatusChanged(UploadStatus status);
    public abstract class UploadEntityBase : EventArgs
    {
        event UploadStatusChanged UploadStatusChanged;
        private static object _locker = new object();
        public static IUploader Uploader
        {
            get
            {
                if(_uploader == null)
                {
                    lock (_locker)
                    {
                        if(_uploader == null)
                        {
                            _uploader = new DrupalUploader(RembyServices.uID, RembyServices.securityID, AppConfig.Instance.LoginResponse.session);
                        }
                    }
                }

                return _uploader;
            }
        }
        private static IUploader _uploader;


        public UploadStatus UploadStatus 
        { 
            get { return _uploadStatus; }
            set
            {
                _uploadStatus = value;
                if(UploadStatusChanged != null)
                {
                    UploadStatusChanged(value);
                }
            }
        }
        private UploadStatus _uploadStatus;



        public string CustomMessage { get; set; }
        public string Tags { get; set; }

        public string Caption { get; set; }
        public string Name { get; set; }

        public Form CallerForm { get; set; }
        public string ShortUrl { get; set; }
        public Guid Guid;
        public string Context { get; set; }
        protected UploadEntityBase()
        {
            UploadStatus = new UploadStatus() {PercentUploaded = 0, Status = Status.Pending};
            Guid = Guid.NewGuid();

        }

        public void SuccessUploadingAction()
        {
            if(CallerForm != null && !CallerForm.IsDisposed)
            {
                CallerForm.BeginInvoke((MethodInvoker)(() => CallerForm.Close()));
            }
        }

        public void FailUploadingAction()
        {
            if(CallerForm != null && !CallerForm.IsDisposed)
            {
                CallerForm.BeginInvoke((MethodInvoker)(() =>
                                                           {
                                                               CallerForm.Show();
                                                               CallerForm.Activate();
                                                           }));
                
            }

            if (CallerForm == null || CallerForm.IsDisposed)
            {
                AppConfig.topnav.BeginInvoke((MethodInvoker)(Open));
                
            }
        }

        public abstract void  Upload();
        public abstract void Open();
        public abstract UploadEntityBase Init();
    }

    public enum Status
    {
        Pending,
        InProgress,
        Uploaded,
        Canceled,
        Error,
    }

    public class UploadStatus
    {
        public string Error;
        public int PercentUploaded { get; set; }
        public Status Status { get; set; }

    }
}
