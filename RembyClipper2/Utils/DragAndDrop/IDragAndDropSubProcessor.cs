using System.Collections.Generic;
using System.Windows.Forms;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.DragAndDrop
{
    public interface IDragAndDropSubProcessor
    {
        List<UploadEntityBase> ExtractData(DragEventArgs e, string tags);
        string GetBrowserUrl();
        bool CouldDataBeProcessed(string data);
        bool IsDataSupported(DragEventArgs e);
        
    }
}