using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using System.Diagnostics;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Utils;
using RembyClipper2.Web;
using RembyClipper2.Helpers;
using RembyClipper.Helpers;
using RembyClipper2.Base;

namespace RembyClipper2.Forms
{
    public partial class FormHistory : RembyClipper2.Base.BaseForm
    {
        const int TOOL_TIP_DURATION = 6000;
        public FormHistory()
        {
            InitializeComponent();
            this.DisableAntiFlicker = true;
            AppConfig.topnav.SetRegion(panelNewTags, false);
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            RefreshCount();
            if (string.IsNullOrEmpty(AppConfig.GetInstance().Password))
            {
                if (!TopNav.Login())
                {
                    //AppConfig.topnav.OpenStatus(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error), false);
                    InfoBoxDispatcher.ShowError(Localization.LanguageMgr.LM.GetText(Labels.TopNav_Error));
                    if (!Visible && !IsDisposed)
                    {
                        Show();

                    }
                    Close();
                    return;
                }
                else
                {
                    refreshTSPButton_Click(null, EventArgs.Empty);
                }
            }
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            ApplyLanguage();

            listView1.Items.Clear();
            listView1.LargeImageList = AppConfig.WebHistory.historyImages;
            listView1.SmallImageList = AppConfig.WebHistory.historyImages;

            foreach (ListViewItem lvi in AppConfig.WebHistory.historyItems)
                listView1.Items.Add((ListViewItem)lvi.Clone());

            if (listView1.Items.Count > 0)
                listView1.Items[0].Selected = true;

            listView1.Select();


            /*if (AppConfig.Instance.History.Count == 0)
            {
                listView1.Items.Clear();
                return;
            }

            int i = 0;
            foreach (string item in AppConfig.Instance.History)
            {
                if (i == 0)
                {
                    var it = listView1.Items[0];
                    string[] sparts = item.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                    if (sparts[0] == "p")
                        it.ImageIndex = 0;
                    if (sparts[0] == "v")
                        it.ImageIndex = 1;
                    it.Text = sparts[1];
                    it.Tag = sparts[2];
                    
                }
                else
                {
                    var it = (ListViewItem)listView1.Items[0].Clone();
                    string[] sparts = item.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                    if (sparts[0] == "p")
                        it.ImageIndex = 0;
                    if (sparts[0] == "v")
                        it.ImageIndex = 1;
                    it.Text = sparts[1];
                    it.Tag = sparts[2];
                    listView1.Items.Add(it);
                    
                }
                i++;
            }*/
        }

        private void ApplyLanguage()
        {
            if(IsDisposed)
            {
                return;
            }
            Text = Localization.LanguageMgr.LM.GetText(Labels.History_Title);
            listView1.Groups[0].Header = Localization.LanguageMgr.LM.GetText(Labels.History_ListTitle);
            buttonBlack1.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Close);
            buttonOrangeTagSave.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Save);
            buttonBlackTagCancel.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Cancel);
            autoCompleteTextBox1.Values = AppConfig.SupportedTags;
            changeTagsButton.Text = Localization.LanguageMgr.LM.GetText(Labels.ChangeTags);
            labelLoggedIn.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Tags);
            shareThisLabel.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.ShareThis);

//            this.toolStripButton6.Text = Localization.LanguageMgr.LM.GetText(Labels.History_All);
//            this.toolStripButton6.ToolTipText = Localization.LanguageMgr.LM.GetText(Labels.History_ShowAll);
//            this.toolStripButton2.Text        = Localization.LanguageMgr.LM.GetText(Labels.History_Images);
//            this.toolStripButton2.ToolTipText = Localization.LanguageMgr.LM.GetText(Labels.History_ShowImages);
//            this.toolStripButton5.Text = Localization.LanguageMgr.LM.GetText(Labels.History_Videos);
//            this.toolStripButton5.ToolTipText = Localization.LanguageMgr.LM.GetText(Labels.History_ShowVideos);
//            this.toolStripButton4.Text = Localization.LanguageMgr.LM.GetText(Labels.History_Texts);
//            this.toolStripButton4.ToolTipText = Localization.LanguageMgr.LM.GetText(Labels.History_ShowTexts);
//            this.toolStripButton3.Text = Localization.LanguageMgr.LM.GetText(Labels.History_Files);
//            this.toolStripButton3.ToolTipText = Localization.LanguageMgr.LM.GetText(Labels.History_ShowFiles);
//            this.toolStripButton1.Text = Localization.LanguageMgr.LM.GetText(Labels.History_Screenshots);
//            this.toolStripButton1.ToolTipText = Localization.LanguageMgr.LM.GetText(Labels.History_ShowScreenShots);

            this.toolStripTextBox1.Text = Localization.LanguageMgr.LM.GetText(Labels.History_FilterOnTags);
            this.toolStripButton7.Text = Localization.LanguageMgr.LM.GetText(Labels.History_Refresh);
            this.expandListButton.Text = Localization.LanguageMgr.LM.GetText(Labels.History_Expand_List_Button);
            RefreshCount();

            showLabel.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Show);
            
            toolStripComboBox1.Items.Clear();
            toolStripComboBox1.Items.Add(new ComboboxItem<string>("all", Localization.LanguageMgr.LM.GetText(Labels.History_All)));
            toolStripComboBox1.Items.Add(new ComboboxItem<string>("image", Localization.LanguageMgr.LM.GetText(Labels.History_Images)));
            toolStripComboBox1.Items.Add(new ComboboxItem<string>("video_thumb", Localization.LanguageMgr.LM.GetText(Labels.History_Videos)));
            toolStripComboBox1.Items.Add(new ComboboxItem<string>("text", Localization.LanguageMgr.LM.GetText(Labels.History_Texts)));
            toolStripComboBox1.Items.Add(new ComboboxItem<string>("file", Localization.LanguageMgr.LM.GetText(Labels.History_Files)));
            toolStripComboBox1.Items.Add(new ComboboxItem<string>("screenshot", Localization.LanguageMgr.LM.GetText(Labels.History_Screenshots)));
            toolStripComboBox1.SelectedIndex = 0;



        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            /*if (listView1.SelectedItems != null)
            {
                Process t = new Process();
                t.StartInfo.FileName = listView1.SelectedItems[0].Tag.ToString();
                t.Start();
            }*/
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var tsi = (ToolStripButton)sender;
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ListViewItem lvi in AppConfig.WebHistory.historyItems)
            {
                if (tsi.CheckState == CheckState.Unchecked)
                {
                    if (((RembyClipper2.Helpers.History.Content)lvi.Tag).file_role.ToString() == tsi.Tag.ToString())
                        listView1.Items.Add((ListViewItem)lvi.Clone());
                }
                else
                    listView1.Items.Add((ListViewItem)lvi.Clone());
            }
            bool b = tsi.Checked;
//            toolStripButton1.Checked = false;
//            toolStripButton2.Checked = false;
//            toolStripButton3.Checked = false;
//            toolStripButton4.Checked = false;
//            toolStripButton5.Checked = false;
            tsi.Checked = !b;

            listView1.EndUpdate();
        }

        private void postOnFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                toolTip1.ShowCustom(Localization.LanguageMgr.LM.GetText(Labels.History_SelectElementToShare), listView1, TOOL_TIP_DURATION);
                return;
            }
            var ts = (Control)sender;
            string url = RembyClipper.Helpers.RembyServices.shortenURL(((RembyClipper2.Helpers.History.Content)listView1.SelectedItems[0].Tag).share_url);
            if (ts.Tag.ToString() == "fb")
            {
                ShareFacebook sf = new ShareFacebook(url);
            }
            if (ts.Tag.ToString() == "twitter")
            {
                ShareTwitter st = new ShareTwitter(url);
            }
            if (ts.Tag.ToString() == "google")
            {
                Clipboard.SetData(DataFormats.Text,url);

                MessageBox.Show(Localization.LanguageMgr.LM.GetFormattedText(Labels.TopNav_ShortenUrlCopiedToClipBoardWithParam, url), 
                    Localization.LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ListViewItem lvi in AppConfig.WebHistory.historyItems)
                    listView1.Items.Add((ListViewItem)lvi.Clone());

            if(toolStripComboBox1.Items.Count > 0)
            {
                toolStripComboBox1.SelectedIndex = 0;
            }
//            toolStripButton1.Checked = false;
//            toolStripButton2.Checked = false;
//            toolStripButton3.Checked = false;
//            toolStripButton4.Checked = false;
//            toolStripButton5.Checked = false;

            listView1.EndUpdate();

        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            if (this.toolStripTextBox1.Text.Equals(Localization.LanguageMgr.LM.GetText(Labels.History_FilterOnTags)))
            {
                this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.toolStripTextBox1.Text = "";
            }
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            if (this.toolStripTextBox1.Text == "")
            {
                this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.toolStripTextBox1.Text = Localization.LanguageMgr.LM.GetText(Labels.History_FilterOnTags);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.toolStripTextBox1.Text == "" || this.toolStripTextBox1.Text.Equals(Localization.LanguageMgr.LM.GetText(Labels.History_FilterOnTags)))
            {
                toolStripButton6_Click(sender, e);
            }
            else
            {
                listView1.BeginUpdate();
                listView1.Items.Clear();

                foreach (ListViewItem lvi in AppConfig.WebHistory.historyItems)
                        if (((RembyClipper2.Helpers.History.Content)lvi.Tag).tags.ToLower().Contains(this.toolStripTextBox1.Text.ToLower()))
                            listView1.Items.Add((ListViewItem)lvi.Clone());
                
//                toolStripButton1.Checked = false;
//                toolStripButton2.Checked = false;
//                toolStripButton3.Checked = false;
//                toolStripButton4.Checked = false;
//                toolStripButton5.Checked = false;
                if(toolStripComboBox1.Items.Count > 0)
                {
                    toolStripComboBox1.SelectedIndex = 0;
                }
                
                listView1.EndUpdate();
            }
        }

        private void refreshTSPButton_Click(object sender, EventArgs e)
        {
            History.ResetListSize();
            RefreshHistory();
        }

        private void RefreshHistory()
        {
            Cursor = Cursors.WaitCursor;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.Text = Localization.LanguageMgr.LM.GetText(Labels.History_FilterOnTags);

            refreshPictureBox.Visible = true;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            listView1.Visible = false;
            bw.RunWorkerAsync();
        }

        private void RefreshCount()
        {
            itemsCountLabel.Text = string.Format(Localization.LanguageMgr.LM.GetText(Labels.History_Items_Count), History.DownloadCount, History.TotalCount);
            if(History.DownloadCount >= History.TotalCount)
            {
                expandListButton.Enabled = false;
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refreshPictureBox.Visible = false;
            listView1.BeginUpdate();
            FormHistory_Load(null, null);
            listView1.EndUpdate();
            listView1.Visible = true;
            RefreshCount();
            Cursor = Cursors.Arrow;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            AppConfig.WebHistory.Dispose();
            AppConfig.WebHistory = new History(false);
            //listView1.Items.Clear();
            Tags.GetTags();
        }

        private void listView1_Scroll(object sender, EventArgs e)
        {
            /*this.SuspendLayout();
            this.Invalidate();
            this.ResumeLayout();*/
        }

        private ListViewItem selectedItem;
        private void changeTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count != 0)
            {
                autoCompleteTextBox1.Text = listView1.SelectedItems[0].Text;
                selectedItem = listView1.SelectedItems[0];
                panelNewTags.Visible = true;
                panelNewTags.BringToFront();

                autoCompleteTextBox1.Focus();
                autoCompleteTextBox1.SelectAll();
            } else
            {

                toolTip1.ShowCustom(Localization.LanguageMgr.LM.GetText(Labels.History_Select_To_Change_Tags), listView1, TOOL_TIP_DURATION);
            }
        }

        private void buttonBlackTagCancel_Click(object sender, EventArgs e)
        {
            panelNewTags.Visible = false;
        }

        private void buttonOrangeTagSave_Click(object sender, EventArgs e)
        {
            refreshPictureBox.Visible = true;

            BackgroundWorker bwChangeTags = new BackgroundWorker();
            bwChangeTags.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwChangeTags_RunWorkerCompleted);
            bwChangeTags.DoWork += new DoWorkEventHandler(bwChangeTags_DoWork);
            bwChangeTags.RunWorkerAsync(autoCompleteTextBox1.Text);
        }

        void bwChangeTags_DoWork(object sender, DoWorkEventArgs e)
        {
            RembyClipper2.Helpers.History.Content selectedHContent = (RembyClipper2.Helpers.History.Content)selectedItem.Tag;
            var result = RembyServices.ChangeTagsForAnElement(selectedHContent.key,e.Argument.ToString());
            Tags.GetTags();
            e.Result = result;
        }

        void bwChangeTags_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           var result = (MediaStoreResponse)e.Result;
            if (!result.Status)
            {
                MessageBox.Show(Localization.LanguageMgr.LM.GetText(Labels.History_ChangeTagsError), Localization.LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelNewTags.Visible = false;
                return;
            }

            if (autoCompleteTextBox1.Text.Trim().EndsWith(","))
                selectedItem.Text = autoCompleteTextBox1.Text.Trim().Substring(0, autoCompleteTextBox1.Text.Trim().Length - 1); // remove last ,
            else
                selectedItem.Text = autoCompleteTextBox1.Text.Trim();
            
            panelNewTags.Visible = false;
            refreshPictureBox.Visible = false;
            autoCompleteTextBox1.Values = AppConfig.SupportedTags;
        }


        bool wordadded = false;
        void autoCompleteTextBox1_onWordAdded()
        {
            wordadded = true;
        }

        private void autoCompleteTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!wordadded && e.KeyCode == Keys.Enter)
                buttonOrangeTagSave_Click(sender, e);
            if (wordadded)
                wordadded = false;
        }


        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void expandListButton_Click(object sender, EventArgs e)
        {
            History.IncraseListSize();
            RefreshHistory();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            listView1.BeginUpdate();
            listView1.Items.Clear();

            ComboboxItem<string> item = toolStripComboBox1.SelectedItem as  ComboboxItem<string>;
            if(item != null)
            {
                foreach (ListViewItem lvi in AppConfig.WebHistory.historyItems)
                {
                    if (((RembyClipper2.Helpers.History.Content)lvi.Tag).file_role.ToString() == item.Value)
                    {
                        //filter items
                        listView1.Items.Add((ListViewItem)lvi.Clone());
                    }
                    else if (item.Value == "all")
                    {
                        //All items will be added here
                        listView1.Items.Add((ListViewItem)lvi.Clone());
                    }
                }
                
            }

            listView1.EndUpdate();

        }
    }
}
