using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Base;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Forms.InformationDialog.FormPlacer;
using RembyClipper2.Properties;
using RembyClipper2.Utils;
using RembyClipper2.VideoEngine;
using RembyClipper2.Web;

namespace RembyClipper2.Config
{
    public partial class Options2 : BaseForm
    {
        private const int MB = 1024*1024;
        public static Options2 _instance;
        public Options2()
        {
            InitializeComponent();
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            //Localization.LanguageMgr.LM.GetText(Labels.);
            if(AppConfig.Instance.Username.HasValue())
            {
                LanguageMgr.LM.SetDefaultLanguage(AppConfig.Instance.CurrentLanguage);
            }
            Text = LanguageMgr.LM.GetText(Labels.Options_Title);
            tpAdvanced.Text = LanguageMgr.LM.GetText(Labels.Options_Advanced);
            tpGeneral.Text = LanguageMgr.LM.GetText(Labels.Options_General);
            tpScreenVideo.Text = LanguageMgr.LM.GetText(Labels.Options_Video);


            signButton.Text = LanguageMgr.LM.GetText(Labels.Options_LogOut);
            resetButton.Text = LanguageMgr.LM.GetText(Labels.Options_Reset);

            saveButton.Text = LanguageMgr.LM.GetText(Labels.Button_Save);
            closeButton.Text = LanguageMgr.LM.GetText(Labels.Button_Cancel);


            label2.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Video_Title);
            label3.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Video_FrameRate);
            checkBoxYTPrivate.Text = LanguageMgr.LM.GetText(Labels.Options_Video_YouTubePrivate);

            label15.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Audio_Title);
            label7.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Audio_Channels);
            label4.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Audio_Sample);
            label5.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Audio_Bitrate);
            label6.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Audio_Bitspersample);

            label9.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Webcam_Title);
            label10.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Webcam_Device);
            label1.Text = LanguageMgr.LM.GetText(Labels.Options_RembyAccount);
            labelLoggedIn.Text = LanguageMgr.LM.GetLabelText(Labels.Options_LoggedIn);
            label11.Text = LanguageMgr.LM.GetText(Labels.Options_Language_Title);
            label12.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Language_UseIn);
            checkBox1.Text = LanguageMgr.LM.GetText(Labels.Options_StartWithWindows);

            msgBoxPlacementLabel.Text = LanguageMgr.LM.GetText(Labels.Options_MsgBoxPlacement);
            placeAtLabel.Text = LanguageMgr.LM.GetLabelText(Labels.Options_placeAt);

            tpMyAccaunt.Text = LanguageMgr.LM.GetText(Labels.Options_Account_TabTitle);
            subscriptionTypeTextLabel.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Account_SubcriptionLabel);
            //userIdTextLabel.Text            = LanguageMgr.LM.GetLabelText(Labels.Options_Account_UserIdLabel);
            fileSizeLimitTextLabel.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Account_FileSizeLimitLabel);
            storageSizeLimitTextLabel.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Account_StorageSizeLimitLabel);
            //
            //            
            //    [0]: {[watermark_screenshot, 1]}
            //    [1]: {[watermark_screenvideo, 1]}
            //    [2]: {[watermark_pdf, 1]}
            //    [3]: {[max_page_per_month, 25]}
            //    [4]: {[max_page_size, 3072000]}
            //    [5]: {[max_video_length, 5]}
            //    [6]: {[max_size_storage_default, 104857600]}
            //    [7]: {[max_number_storage_default, 100]}
            //    [8]: {[max_number_storage_video, 10]}
            //    [9]: {[max_number_storage_text, -1]}
            //    [10]: {[max_number_storage_image, -1]}
            //    [11]: {[sell_book, 0]}
            //    [12]: {[show_ads, 1]}
            //    [13]: {[phone_support, 0]}
            //    [14]: {[can_print, 0]}


            subscriptionTypeLabel.Text = AppConfig.Instance.LoginResponse.subscription;
            //userIdLabel.Text = RembyServices.uID;
            fileSizeLimitLabel.Text = string.Format("{0} MB", AppConfig.Instance.LoginResponse.subscription.HasValue() ? (AppConfig.Instance.LoginResponse.filesizelimit / MB).ToString() : "0");
            storageSizeLimitLabel.Text = string.Format("{0} MB", AppConfig.Instance.LoginResponse.subscription.HasValue() ? (AppConfig.Instance.LoginResponse.storagesizelimit / MB).ToString() : "0");

            upgradeBtn.Text = LanguageMgr.LM.GetText(Labels.Options_Account_UpgradeBtn);
            upgradeBtn.Visible = AppConfig.accountType == AppConfig.ACCOUNT_NAME_BASIC;


            updatePolicyLabel.Text = LanguageMgr.LM.GetText(Labels.Options_Account_UpdatePolicyLabel);
            updateEveryLabel.Text = LanguageMgr.LM.GetLabelText(Labels.Options_Account_UpdatePeriodLabel);

            //update CB
            updateCB.Items.Clear();
            updateCB.Items.Add(new ComboboxItem<AppConfig.Updates>(AppConfig.Updates.Never, LanguageMgr.LM.GetText(Labels.Options_Update_Never)));
            //updateCB.Items.Add(new ComboboxItem<AppConfig.Updates>(AppConfig.Updates.EveryHour,  LanguageMgr.LM.GetText(Labels.Options_Update_EveryHour)));
            updateCB.Items.Add(new ComboboxItem<AppConfig.Updates>(AppConfig.Updates.EveryDay, LanguageMgr.LM.GetText(Labels.Options_Update_EveryDay)));
            updateCB.Items.Add(new ComboboxItem<AppConfig.Updates>(AppConfig.Updates.EveryWeek, LanguageMgr.LM.GetText(Labels.Options_Update_EveryWeek)));
            var item = updateCB.FindItem<AppConfig.Updates>(AppConfig.Instance.UpdatePeriod);
            if (item != null)
            {
                updateCB.SelectedItem = item;
            }
        }

        private void Options2Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppConfig.GetInstance().Username))
            {
                labelLoggedIn.Text = LanguageMgr.LM.GetLabelText(Labels.Options_LoggedIn) + @" " +
                                     AppConfig.Instance.Username;
                signButton.Text = LanguageMgr.LM.GetText(Labels.Options_LogOut);
            }
            else
            {
                //signButton.Visible = false;
                signButton.Text = LanguageMgr.LM.GetText(Labels.Options_Login);
                labelLoggedIn.Text = LanguageMgr.LM.GetText(Labels.Options_NotLoggedIn);
            }

            checkBoxYTPrivate.Checked = AppConfig.GetInstance().VideoPrivate;
            textBoxFrameRate.Text = AppConfig.Instance.VideoFPS.ToString();

            textBoxBitrate.Text = AppConfig.Instance.audioBitrate.ToString();
            textBoxBitsPerSample.Text = AppConfig.Instance.audioBitsPerSample.ToString();
            textBoxChannels.Text = AppConfig.Instance.audioChannels.ToString();
            textBoxSampleFreq.Text = AppConfig.Instance.audioSampleFreq.ToString();

            authenticationUrlTB.Text = Settings.Default.ServiceUrl;
            uploadUrlTB.Text = Settings.Default.UploadUrl;
            
            checkBox1.Checked = AppConfig.Instance.AutoStart;
            string[] c = CameraControl.GetCameras();
            if (c != null && c.Length > 0)
            {
                comboBoxDevice.Items.AddRange(c);
                if (comboBoxDevice.Items.Count > 0)
                {
                    comboBoxDevice.SelectedItem = AppConfig.Instance.CaptureDevice;
                    if (comboBoxDevice.SelectedItem == null)
                        comboBoxDevice.SelectedIndex = 0;
                }
            }
            //init language combo
            comboBoxLanguage.Items.Clear();
            var defItem = new ComboboxItem<Language>
                              {
                                  Text = LanguageMgr.GetLanguageDescription(AppConfig.Instance.CurrentLanguage),
                                  Value = AppConfig.Instance.CurrentLanguage
                              };

            foreach (Language lang in Enum.GetValues(typeof(Language)))
            {
                var comboboxItem = new ComboboxItem<Language>
                                       {
                                           Text = LanguageMgr.GetLanguageDescription(lang),
                                           Value = lang
                                       };
                comboBoxLanguage.Items.Add(comboboxItem);
                if (comboboxItem.Value == AppConfig.Instance.CurrentLanguage)
                {
                    defItem = comboboxItem;
                }
            }
            comboBoxLanguage.SelectedItem = defItem;

            placementComboBox.Items.Clear();
            List<PlaceCombobxItem> possibleComboValues = InfoBoxDispatcher.GetPossiblePlaceComboValues();
            placementComboBox.Items.AddRange(possibleComboValues.ToArray());
            var defComboItem = (from item in possibleComboValues
                                where item.Value.Equals(AppConfig.Instance.MessageBoxDefaultPlace)
                                select item).FirstOrDefault();
            if (defComboItem != null)
            {
                placementComboBox.SelectedItem = defComboItem;
            }
            else
            {
                placementComboBox.SelectedIndex = 0;
            }


        }

        public void ShowInstance()
        {
            if (_instance == null || _instance.IsDisposed || !_instance.Visible)
            {
                _instance = this;
                _instance.Show(AppConfig.topnav);
            }

            if (_instance != null)
            {
                _instance.Focus();
            }



        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (AppConfig.Instance.ClearPasswordOnExit)
                {
                    AppConfig.Instance.ClearPasswordOnExit = false;
                    AppConfig.Instance.Username = "";
                    AppConfig.Instance.Password = "";
                    AppConfig.Instance.Store(false, true);
                    RembyServices.securityID = "";
                    //                    Close();
                    //                    return;
                    AppConfig.Instance.Store();
                    Application.Restart();
                    //Application.Exit();
                    return;
                }

                int frameRate = Convert.ToInt32(textBoxFrameRate.Text);
                int bitRate = Convert.ToInt32(textBoxBitrate.Text);
                int bitsPerSample = Convert.ToInt32(textBoxBitsPerSample.Text);
                int channels = Convert.ToInt32(textBoxChannels.Text);
                int sampleFreq = Convert.ToInt32(textBoxSampleFreq.Text);

                AppConfig.Instance.audioBitrate = bitRate;
                AppConfig.Instance.audioBitsPerSample = bitsPerSample;
                AppConfig.Instance.audioChannels = channels;
                AppConfig.Instance.audioSampleFreq = sampleFreq;
                AppConfig.Instance.VideoFPS = frameRate;
                AppConfig.Instance.VideoPrivate = checkBoxYTPrivate.Checked;
                if (connectToPanel.Visible)
                {
                    Settings.Default.ServiceUrl = authenticationUrlTB.Text;
                    Settings.Default.UploadUrl = uploadUrlTB.Text;
                }

                var item = placementComboBox.SelectedItem as PlaceCombobxItem;
                if (item != null)
                {
                    AppConfig.Instance.MessageBoxDefaultPlace = item.Value;
                }



                if (comboBoxDevice.SelectedItem != null)
                    AppConfig.Instance.CaptureDevice = comboBoxDevice.SelectedItem.ToString();

                AppConfig.Instance.AutoStart = checkBox1.Checked;

                if (AppConfig.Instance.AutoStart)
                    ShortcutManager.createShortcut(Environment.SpecialFolder.Startup);
                else
                    ShortcutManager.removeShortcut(Environment.SpecialFolder.Startup);

                AppConfig.Instance.UpdatePeriod = ((ComboboxItem<AppConfig.Updates>)updateCB.SelectedItem).Value;

                AppConfig.Instance.CurrentLanguage =
                    ((ComboboxItem<Language>)comboBoxLanguage.SelectedItem).Value;
                Settings.Default.Save();
                AppConfig.Instance.Store();
                LanguageMgr.LM.SetDefaultLanguage(AppConfig.Instance.CurrentLanguage);
                Close();
            }
            catch (Exception ee)
            {
                DebugHelper.Log(ee.ToString());
                MessageBox.Show(LanguageMgr.LM.GetText(Labels.Options_SaveDataError),
                                LanguageMgr.LM.GetText(Labels.Remby), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SignButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppConfig.GetInstance().Username))
            {
                //user logged in, process logout case
                AppConfig.Instance.ClearPasswordOnExit = true;

#if !legacyLogin
                var t = new WebLogout();
#endif

                labelLoggedIn.Text = LanguageMgr.LM.GetText(Labels.Options_SignedOutNote);
                signButton.Visible = false;
                //AppConfig.Instance.Store();
                SaveButtonClick(sender, e);
                AppConfig.RestInstance();
            }
            else
            {
                if (TopNav.Login())
                {
                    Options2Load(null, EventArgs.Empty);
                }
            }
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
            AppConfig.Instance.Store(true);
            MessageBox.Show(LanguageMgr.LM.GetText(Labels.Options_SettingsRestored),
                            LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Options2Load(null, EventArgs.Empty);
        }

        private void placementComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = placementComboBox.SelectedItem as PlaceCombobxItem;
            if (item == null)
            {
                return;
            }

            InfoBoxDispatcher.SetSetting(item.Value);
        }

        private void upgradeBtn_Click(object sender, EventArgs e)
        {
            var subscriptionRestrictions = AppConfig.Instance.subscriptionRestrictions;
            var t = new Process();
            t.StartInfo.FileName = string.Format("{0}/user/{1}/myplan", RembyConstants.RembyURL, RembyServices.uID);
            t.Start();
        }

        private void panelGeneral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Options2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (myAccountTC.SelectedTab == tpAdvanced && e.KeyCode == Keys.U && e.Modifiers == (Keys.Control | Keys.Shift | Keys.Alt))
            {
                e.IsInputKey = true;
            }
        }

        private void Options2_KeyDown(object sender, KeyEventArgs e)
        {
            if (myAccountTC.SelectedTab == tpAdvanced && e.KeyCode == Keys.U && e.Modifiers == (Keys.Control | Keys.Shift | Keys.Alt))
            {
                connectToPanel.Visible = !connectToPanel.Visible;
            }

        }
    }
}