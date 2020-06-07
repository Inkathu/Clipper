using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Utils.Uploading.Entities;
using System.Linq;

namespace RembyClipper2.Utils.DragAndDrop
{
    public static class DragAndDropProcessor
    {
        private static List<IDragAndDropSubProcessor> _dragItemsSubprocessors;
        static DragAndDropProcessor()
        {
            _dragItemsSubprocessors = new List<IDragAndDropSubProcessor>()
                                          {
                                              new ChromeDragAndDropSubProcessor(),
                                              new FireFoxDragAndDropSubProcessor(),
                                              new SafariDragAndDropSubProcessor(),
                                              new IEDragAndDropSubProcessor(),
                                              new CommonDragAndDropSubProcessor(),
                                          };

        }


        public static List<UploadEntityBase> ProcessDraggedItem(string appName, DragEventArgs e, string tags)
        {
            DebugHelper.PropertyDump(e);
            string[] formats = e.Data.GetFormats();
            foreach (string s in formats)
            {
                DebugHelper.Log(s);
            }

            List<UploadEntityBase> result = null;
            IDragAndDropSubProcessor dragAndDropSubProcessor = _dragItemsSubprocessors.FirstOrDefault(processor => processor.CouldDataBeProcessed(appName));
            if(dragAndDropSubProcessor != null)
            {
                result = dragAndDropSubProcessor.ExtractData(e, tags);
            }else
            {
                DebugHelper.Log("[DragAndDropProcessor] : appropriate drag and drop processor could not be found");
            }
            return result;
        }

        
       
    }
}