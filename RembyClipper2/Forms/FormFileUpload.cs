using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper2.Utils;
using RembyClipper2.Utils.Meesenger.Uploading;
using RembyClipper2.Utils.Uploading;
using RembyClipper2.Utils.Uploading.Entities;

namespace RembyClipper2.Forms
{
    public partial class FormFileUpload : Form
    {
        public static FormFileUpload Instance { get; set; }

        public FormFileUpload(List<string> files=null)
        {
            InitializeComponent();
            ApplyLanguage();
            tagEditControl.SetTagsCollection(AppConfig.SupportedTags);
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
            customList1.ItemsCountChanged +=    ItemsCountChanged;
            if (files != null)
            {
                var items = new List<CustomListItem>();
                files.ForEach(file => items.Add(new CustomListItem()
                                                    {
                                                        Text = file,
                                                        Image = GetFileIco(file),
                                                        Item = file
                                                    }));
                customList1.AddItemsRange(items);
                uploadButton.Enabled = customList1.ItemsCount > 0;
                helpLabel.Visible = !uploadButton.Enabled;
            }


        }

        private void ItemsCountChanged(object sender, EventArgs eventArgs)
        {
            uploadButton.Enabled = customList1.ItemsCount > 0;
        }

        private void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            Text              = Localization.LanguageMgr.LM.GetText(Labels.FileUpload_Title);
            tagsLabel.Text    = Localization.LanguageMgr.LM.GetLabelText(Labels.Tags);
            uploadButton.Text = Localization.LanguageMgr.LM.GetText(Labels.Upload);
            cancelButton.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Cancel);
            browseButton.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Browse);
            helpLabel.Text    = Localization.LanguageMgr.LM.GetText(Labels.FileUpload_HelpLabel);
            clearBtn.Text     = Localization.LanguageMgr.LM.GetText(Labels.Clear);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
//            uploadButton.Enabled = false;
//            helpLabel.Visible = !uploadButton.Enabled;
            using(OpenFileDialog dlg = new OpenFileDialog())
            {
                
                dlg.Multiselect = true;
                if(dlg.ShowDialog(this) == DialogResult.OK && dlg.FileNames.Length > 0)
                {
                    //filesCheckedListBox.Items.Clear();
                    List<CustomListItem> items = (from fileName in dlg.FileNames
                                                  where !customList1.ContainsText(fileName)
                                                  select new CustomListItem()
                                                             {
                                                                 Text = fileName, Image = GetFileIco(fileName), Odd = customList1.ItemsCount%2 == 0 ? false : true
                                                             }).ToList();
                    customList1.AddItemsRange(items);
                    var videoFilePresent = false;
                    foreach (var supportedVideoFile in AppConfig.Instance.SupportedVideoFiles)
                    {
                        var files = dlg.FileNames.Where(fileName => fileName.Contains("." + supportedVideoFile));
                        if (files.ToList().Count > 0)
                        {
                            videoFilePresent = true;
                            break;
                        }
                    }


                    ContextSensitiveFramework.Instance.CheckContext(ContextSensitiveFramework.FileUploading);
                    if (videoFilePresent)
                    {
                        ContextSensitiveFramework.Instance.CheckContext(ContextSensitiveFramework.VideoUploading);
                    }
                    

                }
                 
                uploadButton.Enabled = customList1.ItemsCount > 0;
                helpLabel.Visible = !uploadButton.Enabled;

            }

            



        }
        public static Image GetFileIco(string path)
        {
            FileInfo fi = new FileInfo(path);
            string resName = string.Format("file_extension_{0}", fi.Extension.Replace(".", ""));

            Image img = (Image)Properties.Resources.ResourceManager.GetObject(resName) ??
                        Properties.Resources.page_gear;
            return img;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            var tagsString = tagEditControl.GetTagsString();
            if (!string.IsNullOrEmpty(tagsString))
            {
                AppConfig.Instance.LastUsedTags = tagsString;
            }

            List<string> files = new List<string>();
            customList1.Items.ForEach(item => files.Add(item.Text));

            AppConfig.Instance.LastUsedTags = tagsString;
            
            var fileEntities = (from file in files
                                select new FileEntity()
                                {
                                    CallerForm = this,
                                    Tags = tagsString,
                                    File = file,
                                    Context = ""

                                }.Init()
                   ).ToList();
            UploadDispatcher.Instance.Upload(fileEntities);
            this.Hide();

            
        }

        public new void Show()
        {
            Instance = this;
            base.Show();
        }

        public static void AddFileToList(string path)
        {
            if(Instance != null && !Instance.IsDisposed && Instance.Visible)
            {
                if (!Instance.customList1.ContainsText(path))
                {
                    Instance.customList1.AddItem(new CustomListItem() { Text = path, Image = GetFileIco(path)});    
                }
                
            } else
            {
                FormFileUpload form = new FormFileUpload(new List<string>(){path});
                form.Show();
                FormFileUpload.Instance = form;

            }
            Instance.Activate();
        }
        private void FormFileUpload_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(AppConfig.Instance.LastUsedTags))
            {
                tagEditControl.AddTags(AppConfig.Instance.LastUsedTags);
            }
            AppConfig.topnav.RegisterOpenWindow(this);
            
        }

        private void FormFileUpload_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppConfig.topnav.RegisterCloseWindow(this);
        }



        //private void filesCheckedListBox_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if(filesCheckedListBox.SelectedIndex >= 0 )
        //    {
        //        var item = filesCheckedListBox.Items[filesCheckedListBox.SelectedIndex];
        //        if(!filesCheckedListBox.CheckedItems.Contains(item))
        //        {
        //            filesCheckedListBox.Items.Remove(item);
        //            uploadButton.Enabled = filesCheckedListBox.CheckedItems.Count > 0;
        //            helpLabel.Visible = !uploadButton.Enabled;                    
        //        } 
        //    }
        //}

        private void clearBtn_Click(object sender, EventArgs e)
        {
            customList1.ClearItems();
            uploadButton.Enabled = customList1.ItemsCount > 0;
            helpLabel.Visible = !uploadButton.Enabled;
        }

        //private void filesCheckedListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    filesCheckedListBox_SelectedValueChanged(sender, EventArgs.Empty);
        //}

        
    }
}
