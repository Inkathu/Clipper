using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;

namespace RembyClipper2.Base
{
    public partial class RembyUploading : BaseControl
    {
        public RembyUploading()
        {
            InitializeComponent();
#if !DEBUG
            //this.buttonBlack1.Text = AppConfig.Lang.GetValue("Button_Cancel");
            //TODO: Remove this component
            //label1.Text = AppConfig.Lang.GetValue("RembyUpload_UploadingToRemby");
#endif
        }

        public void SetToVideo()
        {
            this.pictureBox1.Image = global::RembyClipper2.Properties.Resources.uploading_video_anim_win;
            //this.label1.Text = AppConfig.Lang.GetValue("RembyUpload_UploadingToYouTube");
            //TODO: Remove this component
        }

        public event CustomButtonClicked OnBlackClicked;


        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            if (OnBlackClicked != null)
                OnBlackClicked();
        }
    }
}
