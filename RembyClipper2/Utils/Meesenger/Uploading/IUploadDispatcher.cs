using System;
using System.Collections.Generic;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.Uploading
{
    
    public interface IUploadDispatcher
    {
        event EventHandler ItemProcessingBefore;
        event EventHandler ItemProcessingAfter;
        event EventHandler ItemProcessingCanceled;
        event EventHandler ItemProcessingAdded;

        /// <summary>
        /// This methos performs to Upload entity to the store
        /// </summary>
        /// <param name="entity"></param>
        void Upload(UploadEntityBase entity);

        /// <summary>
        /// This methos performs to upload passed entities to the store
        /// </summary>
        /// <param name="entities"></param>
        void Upload(List<UploadEntityBase> entities);

        /// <summary>
        /// This methos performs to cancel all uploading tasks
        /// </summary>
        void Cancel();
        
        /// <summary>
        /// This methos performs to cancel current item uploading
        /// </summary>
        void CancelItem();

        /// <summary>
        /// This methos performs to cancel uploading for the passed entity
        /// </summary>
        /// <param name="entity"></param>
        void CancelItem(UploadEntityBase entity);

        /// <summary>
        /// This method performs to clear history list of items
        /// </summary>
        void ClearHistory();

        /// <summary>
        /// This methos performs to stop dispatcher work
        /// </summary>
        void Stop();
    }
}