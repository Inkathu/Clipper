using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Forms
{
    public partial class FormYouTubeLogin : Form
    {
        public FormYouTubeLogin()
        {
            InitializeComponent();
            rembyYouTubeControl.ApplyLanguage();
        }

        private void rembyYouTubeControl_OnCloseButtonClicked()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rembyYouTubeControl_OnLoginButtonClicked()
        {

            if (rembyYouTubeControl.ValidateYouTube())
            {
                rembyYouTubeControl.InitYouTube();
                DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
