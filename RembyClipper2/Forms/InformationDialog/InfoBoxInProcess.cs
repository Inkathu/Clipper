using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Forms.InformationDialog
{
    public partial class InfoBoxInProcess : InfoBox
    {
        public InfoBoxInProcess()
        {
            InitializeComponent();
        }

        public void Show(string caption, string message, int seconds, bool showCountDown)
        {
            //captionLabel.Text = caption;
            messageLabel.Text = message;
            Show(caption, seconds, showCountDown);
        }

        private void messageLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
