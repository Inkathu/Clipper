using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Forms;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Utils.DragAndDrop
{
    public class CommonDragAndDropSubProcessor : BaseDragAndDropSubProcessor
    {
        public override List<UploadEntityBase> ExtractData(DragEventArgs e, string tags)
        {
            List<UploadEntityBase> result = new List<UploadEntityBase>();

            if (IsFolder(e))
            {
                return result;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData("FileDrop");
                DoesDraggedFilesContainVideo(files);
                foreach (var file in files)
                {
                    result.Add(new FileEntity()
                                   {
                                       CallerForm = null,
                                       File = file,
                                       Tags = tags,
                                       Context = ""
                                   }.Init());
                }
            }

            if (e.Data.GetDataPresent(DataFormats.UnicodeText))
            {
                var data = (string)e.Data.GetData(DataFormats.UnicodeText);
                if (data.HasValue())
                {
                    result.Add(new TextEntity
                                   {
                                       CallerForm = null,
                                       Tags = tags,
                                       Text = data,
                                       Context = ""
                                   }.Init());
                }
            }

           
            return result;
        }

        public override bool CouldDataBeProcessed(string data)
        {
            return true;
        }
        
        private bool DoesDraggedFilesContainVideo(string[] files)
        {
            bool foundVideo = false;
            var fList = new List<string>();
            fList.AddRange(AppConfig.Instance.SupportedVideoFiles);

            foreach (string file in files)
            {
                if (fList.Contains(Path.GetExtension(file).Replace(".", "").ToLower()))
                {
                    foundVideo = true;
                    break;
                }
            }

            if (foundVideo)
            {
                var yt = new FormYouTubeLogin();
                yt.StartPosition = FormStartPosition.CenterScreen;
                if (yt.ShowDialog(AppConfig.topnav) == DialogResult.OK)
                {
                    return true;
                }
            }
            return false;
        }

        public override string GetBrowserUrl()
        {
            return "";
        }
    }
}