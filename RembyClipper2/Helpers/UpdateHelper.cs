using System;
using System.Collections.Generic;
using System.Text;
using System.Deployment.Application;
using System.Windows.Forms;
using System.ComponentModel;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Forms.InformationDialog;

namespace RembyClipper2.Helpers
{
    public class UpdateHelper
    {
        long sizeOfUpdate = 0;
        bool _fromTray = false;

        public void UpdateApplication(bool fromTray = false)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                ad.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(ad_CheckForUpdateCompleted);
                ad.CheckForUpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_CheckForUpdateProgressChanged);

                ad.CheckForUpdateAsync();
                _fromTray = fromTray;
            }
        }

        void ad_CheckForUpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            DebugHelper.Log(String.Format("Downloading: {0}. {1:D}K of {2:D}K downloaded.", GetProgressString(e.State), e.BytesCompleted / 1024, e.BytesTotal / 1024));
        }

        string GetProgressString(DeploymentProgressState state)
        {
            if (state == DeploymentProgressState.DownloadingApplicationFiles)
            {
                //LanguageMgr.LM.GetText(Labels.Update_)
                return "application files";
            }
            else if (state == DeploymentProgressState.DownloadingApplicationInformation)
            {
                //LanguageMgr.LM.GetText(Labels.Update_)
                return "application manifest";
            }
            else
            {
                //LanguageMgr.LM.GetText(Labels.Update_)
                return "deployment manifest";
            }
        }

        void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            ApplicationDeployment.CurrentDeployment.CheckForUpdateCompleted -= ad_CheckForUpdateCompleted;
            ApplicationDeployment.CurrentDeployment.CheckForUpdateProgressChanged -= ad_CheckForUpdateProgressChanged;
            if (e.Error != null)
            {
                MessageBox.Show(LanguageMgr.LM.GetFormattedText(Labels.Update_NewVersionCouldNotBeRetreivedWithParam, e.Error.Message), LanguageMgr.LM.GetText(Labels.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (e.Cancelled == true)
            {
                MessageBox.Show(LanguageMgr.LM.GetText(Labels.Update_Cancelled));
            }

            // Ask the user if they would like to update the application now.
            if (e.UpdateAvailable)
            {
                sizeOfUpdate = e.UpdateSizeBytes;

                if (!e.IsUpdateRequired)
                {
                    DialogResult dr = MessageBox.Show(LanguageMgr.LM.GetText(Labels.Update_AvailableMessageWithQuestion), LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (DialogResult.OK == dr)
                    {
                        BeginUpdate();
                    }
                }
                else
                {
                    
                    MessageBox.Show(LanguageMgr.LM.GetFormattedText(Labels.Update_MandatoryUpdateWithParam, e.MinimumRequiredVersion.ToString()),
                                    LanguageMgr.LM.GetText(Labels.Update_AvailableText), 
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    BeginUpdate();
                }
            }
            else
            {
                if (_fromTray)
                {
                    MessageBox.Show(LanguageMgr.LM.GetText(Labels.Update_LatestVersionRunning), LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BeginUpdate()
        {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.UpdateCompleted += ad_UpdateCompleted;

            // Indicate progress in the application's status bar.
            ad.UpdateProgressChanged += ad_UpdateProgressChanged;
            ad.UpdateAsync();
            InfoBoxDispatcher.ShowSimple("Update started");
        }
        int lastProgress = 0;
        void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            String progressText = String.Format("{0:D}K out of {1:D}K downloaded - {2:D}% complete", e.BytesCompleted / 1024, e.BytesTotal / 1024, e.ProgressPercentage);
            DebugHelper.Log(progressText);
            if (e.ProgressPercentage - lastProgress > 10)
            {
                lastProgress = e.ProgressPercentage;
                InfoBoxDispatcher.ShowSimple(string.Format("{0:D}% downloaded", e.ProgressPercentage));
            }
            
            
        }

        void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lastProgress = 0;
            if (e.Cancelled)
            {
                MessageBox.Show(LanguageMgr.LM.GetText(Labels.Update_UpdateToLatestVerWasCanc), LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (e.Error != null)
            {
                
                MessageBox.Show(LanguageMgr.LM.GetFormattedText(Labels.Update_CouldNotInstallLatestVersionWithParam, e.Error.Message), LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DialogResult dr = MessageBox.Show(LanguageMgr.LM.GetText(Labels.Update_WouldYouLikeToRestartMessage), LanguageMgr.LM.GetText(Labels.RembyClipper), MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult.OK == dr)
            {
                Application.Restart();
            }
        }

    }
}
