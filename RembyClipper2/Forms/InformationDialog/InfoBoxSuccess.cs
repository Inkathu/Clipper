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
    public partial class InfoBoxSuccess : InfoBox
    {
        public InfoBoxSuccess()
        {
            InitializeComponent();
            messageLabel.MouseMove += new MouseEventHandler(Window_MouseMove);
            messageLabel.MouseDown += new MouseEventHandler(Window_MouseDown);
            crossPictureBox.MouseMove += new MouseEventHandler(Window_MouseMove);
            crossPictureBox.MouseDown += new MouseEventHandler(Window_MouseDown);

        }

        public void Show(string caption, string message, int seconds, bool showCountDown)
        {
            //captionLabel.Text = caption;
            messageLabel.Text = message;
            Show(caption, seconds, showCountDown);
        }

    }
}
