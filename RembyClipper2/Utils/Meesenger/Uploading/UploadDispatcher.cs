using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Utils.Uploading;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.Meesenger.Uploading
{
    public class UploadDispatcher : IUploadDispatcher, IDisposable
    {
        private static IUploadDispatcher _instance;
        private static readonly object Locker = new object();
        private readonly List<UploadEntityBase> _entitiesList;
        private readonly List<UploadEntityBase> _historyItems;
//        public event UploadStatusChanged UploadStatusChanged;

        private readonly BackgroundWorker _uploader;
        private readonly BackgroundWorker _worker;
        private bool _canUpload = true;
        private UploadEntityBase _currentEntity;
        private Thread _thread;

        public UploadDispatcher()
        {
            _entitiesList = new List<UploadEntityBase>();
            _historyItems = new List<UploadEntityBase>();
            _worker = new BackgroundWorker {WorkerSupportsCancellation = true};
            _worker.DoWork += WorkerDoWork;
            _worker.RunWorkerCompleted += WorkerRunWorkerCompleted;

            _worker.RunWorkerAsync();

            _uploader = new BackgroundWorker {WorkerSupportsCancellation = true};
            _uploader.RunWorkerCompleted += UploaderRunWorkerCompleted;
            _uploader.DoWork += UploaderDoWork;
        }

        public static IUploadDispatcher Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new UploadDispatcher();
                        }
                    }
                }

                return _instance;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Stop();
        }

        #endregion

        #region IUploadDispatcher Members

        public event EventHandler ItemProcessingBefore;
        public event EventHandler ItemProcessingAfter;
        public event EventHandler ItemProcessingCanceled;
        public event EventHandler ItemProcessingAdded;

        public void Upload(UploadEntityBase entity)
        {
            DebugHelper.Log("[UploadDispatcher] : Upload - Adding item for uploading");
            lock (Locker)
            {
                entity.UploadStatus.Status = Status.Pending;

                _entitiesList.Add(entity);
                DebugHelper.Log("[UploadDispatcher] : Upload - entity added to the uploading queue");
            }
            if (ItemProcessingAdded != null)
            {
                DebugHelper.Log("[UploadDispatcher] : Upload - try to call ItemProcessingAdded event ");
                ItemProcessingAdded(this, entity);
                DebugHelper.Log("[UploadDispatcher] : Upload - ItemProcessingAdded event called");
            }
        }

        public void Upload(List<UploadEntityBase> entities)
        {
            lock (Locker)
            {
                entities.ForEach(entity =>
                                     {
                                         entity.UploadStatus.Status = Status.Pending;
                                         _entitiesList.Add(entity);
                                         if (ItemProcessingAdded != null)
                                         {
                                             ItemProcessingAdded(this, entity);
                                         }
                                     });
            }
        }

        public void Stop()
        {
            lock (Locker)
            {
                _worker.CancelAsync();
                if (_uploader.IsBusy)
                {
                    _uploader.CancelAsync();
                }
            }
        }

        public void CancelItem()
        {
            CancelCurrentUploading();
        }

        public void CancelItem(UploadEntityBase entity)
        {
            if (_uploader.IsBusy && _currentEntity == entity)
            {
                _uploader.CancelAsync();
                if (_thread != null)
                {
                    _thread.Abort();
                }
            }
            else
            {
                lock (Locker)
                {
                    if (_entitiesList.Contains(entity))
                    {
                        _entitiesList.Remove(entity);
                        entity.UploadStatus.Status = Status.Canceled;
                        _historyItems.Add(entity);
                        if (ItemProcessingCanceled != null)
                        {
                            ItemProcessingCanceled(this, entity);
                        }
                    }
                }
            }
        }

        public void Cancel()
        {
            //call cancel method
            lock (Locker)
            {
                CancelCurrentUploading();
                while (_entitiesList.Count > 0)
                {
                    UploadEntityBase entity = _entitiesList[0];
                    if (entity != null)
                    {
                        _entitiesList.RemoveAt(0);
                        entity.UploadStatus.Status = Status.Canceled;
                        entity.UploadStatus.PercentUploaded = 0;
                        _historyItems.Add(entity);
                        if (ItemProcessingCanceled != null)
                        {
                            ItemProcessingCanceled(this, entity);
                        }
                    }
                }
                _entitiesList.Clear();
            }
        }


        public void ClearHistory()
        {
            _historyItems.Clear();
        }

        #endregion

        private void UploaderDoWork(object sender, DoWorkEventArgs e)
        {
            DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Uploading starting");
            _canUpload = false;
//            _uploadingInProgress = true;
            _thread = Thread.CurrentThread;

            #region uploading block

            DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - trying to get entity from arguments");
            var entity = e.Argument as UploadEntityBase;
            if (entity != null)
            {
                try
                {
                    DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Show info about entity");
                    InfoBoxDispatcher.ShowInProcess(LanguageMgr.LM.GetFormattedText(Labels.InfoBox_Uploading,
                                                                                    entity.Name));
                    DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - info about entity shown.");
                    //firing event before item processing
                    if (ItemProcessingBefore != null)
                    {
                        DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Call itemProcessingBefore event");
                        ItemProcessingBefore(this, entity);
                        DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - ItemProcessingBefore event call finished");
                    }

                    // Item Uploading
                    DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Entity uploading");
                    entity.Upload();
                    DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Entity uploading is finished");

                    //firing event after processing
                    if (ItemProcessingAfter != null)
                    {
                        DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Call ItemProcessingAfter event");
                        ItemProcessingAfter(this, entity);
                        DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - ItemProcessingAfter event call finished");
                    }
                }
                catch (ThreadAbortException exc)
                {
                    DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - trying to catch thread abort : \r\n" + exc);
                    //firing event after processing
                    Thread.ResetAbort();
                    entity.UploadStatus.Status = Status.Canceled;
                    if (ItemProcessingCanceled != null)
                    {
                        DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Call ItemProcessingCanceled event");
                        ItemProcessingCanceled(this, entity);
                        DebugHelper.Log(
                            "[UploadDispatcher] : UploaderDoWork - ItemProcessingCanceled event call finished");
                    }
                }
                catch (Exception exception)
                {
                    entity.UploadStatus.Status = Status.Error;
                    entity.UploadStatus.Error = exception.ToString();
                    InfoBoxDispatcher.ShowError(LanguageMgr.LM.GetText(Labels.TopNav_Error));
                    DebugHelper.Log("An error occurred in attempt to send " + entity.Name + " to remby store\r\n" +
                                    exception);
                }
                finally
                {
//                    _uploadingInProgress = false;
                    _canUpload = true;
                    lock (Locker)
                    {
                        DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Updating history items");
                        UploadEntityBase ent = _historyItems.Find(item => item.Guid == entity.Guid);
                        if (ent == null)
                        {
                            if (entity is FilesEntity)
                            {
                                ((FilesEntity) entity).UploadingResult.ForEach(file => _historyItems.Add(file));
                            }
                            else
                            {
                                DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Add item to the history list");
                                _historyItems.Add(entity);
                                DebugHelper.Log(
                                    "[UploadDispatcher] : UploaderDoWork - Item adding to the history list is finished");
                            }
                        }
                    }
                }
            }
            else
            {
                DebugHelper.Log("[UploadDispatcher] : UploaderDoWork - Can't get entity from args.");
            }

            #endregion
        }

        private void UploaderRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled && ItemProcessingCanceled != null)
            {
                ItemProcessingCanceled(this, _currentEntity);
            }
        }

        private static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            DebugHelper.Log("[UploadDispatcher] : WorkerDoWork - Dispatched work starting");
            while (/*true && */!_worker.CancellationPending)
            {
                if (_entitiesList.Count > 0 && _canUpload)
                {
                    lock (Locker)
                    {
                        DebugHelper.Log("[UploadDispatcher] : WorkerDoWork - Entity list is not empty, trying to upload");
                        UploadEntityBase entity = _entitiesList.Count > 0 ? _entitiesList[0] : null;

                        if (entity != null)
                        {
                            _canUpload = false;
                            _entitiesList.RemoveAt(0);
                            DebugHelper.Log("[UploadDispatcher] : WorkerDoWork - Remove entity from list");
                            _currentEntity = entity;
                            DebugHelper.Log("[UploadDispatcher] : WorkerDoWork - Sending entity for async processing");
                            _uploader.RunWorkerAsync(entity);
                            DebugHelper.Log("[UploadDispatcher] : WorkerDoWork - Item sended");
                        }
                        else
                        {
                            DebugHelper.Log("[UploadDispatcher] : WorkerDoWork - By some reason taken entity is null");
                        }
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public void CancelCurrentUploading()
        {
            if (_uploader.IsBusy)
            {
                _uploader.CancelAsync();
                if (_thread != null)
                {
                    _thread.Abort();
                }
            }
        }

        public List<UploadEntityBase> GetHistoryItems()
        {
            return _historyItems;
        }
    }
}