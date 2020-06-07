using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.VideoEngine;
using RembyClipper2.Base;

namespace RembyClipper2.Base
{
    public partial class VideoRecorder : BaseControl
    {
        public event CustomButtonClicked OnBlackClicked;
        public event CustomButtonClicked OnOrangeClicked;
        public event CustomButtonClicked OnMuteClicked;
        public event CustomButtonClicked OnWebcamClicked;

        public string BoundSize { get { return label1.Text; } set { this.Invoke(() => label1.Text = value); } }
        public string Duration { get { return label2.Text; } set { this.Invoke(() => label2.Text = value); } }

        private bool micEnabled = true;
        private bool camEnabled = true;

        public VideoRecorder()
        {
            
            InitializeComponent();
            buttonMute1.Visible = false;

            if (!this.DesignMode)
            {
                ApplyLanguage();

                if (!AppConfig.IsCamConnected)
                {
                    camEnabled = false;
                }
            }

            FlipCamImage();
            FlipMicImage();
            grayPanel1.MouseDown += new MouseEventHandler(grayPanel1_MouseDown);
            grayPanel1.MouseUp += new MouseEventHandler(grayPanel1_MouseUp);
            grayPanel1.MouseMove += new MouseEventHandler(grayPanel1_MouseMove);
        }

        private void ApplyLanguage()
        {
            cancelButton.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Cancel);
            this.toolTip1.SetToolTip(this.buttonMute1, Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_MuteMic));
            this.toolTip1.SetToolTip(this.buttonWebcam1, Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_CloseCam));
            startStopButton.Text = Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_StartRecording); 
        }

        void grayPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        void grayPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        void grayPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            if (OnBlackClicked != null)
                OnBlackClicked();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (OnOrangeClicked != null)
                OnOrangeClicked();
            startStopButton.Image = global::RembyClipper2.NewDesign.stop_btn;
            startStopButton.Text = Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_StopRecording);
            cancelButton.Visible = false;
            buttonMute1.Visible = true;
        }

        private void FlipMicImage()
        {
            buttonMute1.Image = micEnabled
                                        ? RembyClipper2.NewDesign.mute
                                        : RembyClipper2.NewDesign.mute_off;
            this.toolTip1.SetToolTip(this.buttonMute1, micEnabled ? Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_MuteMic) : Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_UnmutMic));
        }

        private void FlipCamImage()
        {
            buttonWebcam1.Image = camEnabled
                                      ? RembyClipper2.NewDesign.webcam
                                      : RembyClipper2.NewDesign.webcam_off;
            this.toolTip1.SetToolTip(this.buttonWebcam1, camEnabled ? Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_CloseCam) : Localization.LanguageMgr.LM.GetText(Labels.VideoRecorder_OpenCam));
        }

        public void WebCamStateChange()
        {
            ButtonWebcam1Click(null, EventArgs.Empty);
        }

        public void MuteStateChange()
        {
            ButtonMute1Click(null, EventArgs.Empty);
        }

        private void ButtonMute1Click(object sender, EventArgs e)
        {
            micEnabled = !micEnabled;
            FlipMicImage();
            if (OnMuteClicked != null)
                OnMuteClicked();

        }

        private void ButtonWebcam1Click(object sender, EventArgs e)
        {
            camEnabled = !camEnabled;
            FlipCamImage();
            if (OnWebcamClicked != null)
                OnWebcamClicked();
            
        }
    }
}
