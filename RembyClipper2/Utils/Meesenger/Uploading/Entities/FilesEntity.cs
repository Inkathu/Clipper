using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper2.Forms;
using RembyClipper2.Forms.InformationDialog;

namespace RembyClipper2.Utils.Uploading.Entities
{
    public class FilesEntity : UploadEntityBase
    {
        public List<string> Files;
        public List<string> UploadedFiles;
        public List<string> NotUpoloadedFiles;
        public  List<FileEntity> UploadingResult;
        
        public FilesEntity()
        {
            Name = LanguageMgr.LM.GetText(Labels.InfoBox_Files);
        }

        public override void Upload()
        {
            Init();
            UploadedFiles = new List<string>();
            NotUpoloadedFiles = new List<string>();
            UploadingResult = new List<FileEntity>();
            int processingFileNo = 1;
            
            foreach (var file in Files)
            {
                try
                {
                    InfoBoxDispatcher.ShowInProcess(LanguageMgr.LM.GetText(Labels.TopNav_Uploading) + " " + processingFileNo + "/" + Files.Count);
                    TopNav.UploadFilesResult result = FileEntity.UploadFile(file, Tags, Context);
                    if(!result.response.Status)
                    {
                        NotUpoloadedFiles.Add(file);
                        UploadingResult.Add((FileEntity)
                            new FileEntity()
                                {
                                    File = file, 
                                    UploadStatus = new UploadStatus(){PercentUploaded = 0, Status = Status.Error},
                                    Tags = Tags
                                }.Init());
                    }
                    else
                    {
                        UploadedFiles.Add(file);
                        string u = result.response.short_url;
                        UploadingResult.Add((FileEntity)
                                    new FileEntity()
                                        {
                                            File = file,
                                            UploadStatus =
                                                new UploadStatus() {PercentUploaded = 100, Status = Status.Uploaded},
                                            Tags = Tags,
                                            ShortUrl = u
                                        }.Init());
                    }
                }
                catch (Exception exc)
                {
                    DebugHelper.Log("An exception occured in attempt to process batch file(" + file + ") uploading:\r\n" + exc);
                    UploadingResult.Add((FileEntity)
                            new FileEntity()
                            {
                                File = file,
                                UploadStatus = new UploadStatus() { PercentUploaded = 0, Status = Status.Error },
                                Tags = Tags
                            }.Init());
                    if(!NotUpoloadedFiles.Contains(file))
                    {
                        NotUpoloadedFiles.Add(file);
                    }
                }
                processingFileNo++;
            }

            if(UploadedFiles.Count != Files.Count)
            {
                InfoBoxDispatcher.ShowError(UploadedFiles.Count + "/" + Files.Count + " " + LanguageMgr.LM.GetText(Labels.TopNav_WereUploaded));
            }
            else if(UploadedFiles.Count == Files.Count)
            {
                InfoBoxDispatcher.ShowSuccess(LanguageMgr.LM.GetText(Labels.TopNav_Uploaded));
            }
            
            if (UploadedFiles.Count > 0)
            {
                UploadStatus.Status = Status.Uploaded;
                SuccessUploadingAction();
            }
            else
            {
                UploadStatus.Status = Status.Error;
                InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                DebugHelper.Log("An error occurred in attempt to upload files.");
                FailUploadingAction();
            }

        }

        public override UploadEntityBase Init()
        {
            string s = Name + " - " + Files.Count + "(pc)";
            Caption = s.Length > 35 ? (s).Substring(0, 35) + "..." : s;
            return this;
        }

        public override void Open()
        {
            if(UploadStatus.Status == Status.Uploaded)
            {
                var t = new Process();
                t.StartInfo.FileName = RembyConstants.RembyURL + "/mystuff";
                t.Start();
            }else
            {
                FormFileUpload frm = new FormFileUpload(NotUpoloadedFiles);
                frm.Show(AppConfig.topnav);
            }

        }
    }
}