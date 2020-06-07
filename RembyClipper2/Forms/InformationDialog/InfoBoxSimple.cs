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
    public partial class InfoBoxSimple : InfoBox
    {
        public InfoBoxSimple()
        {
            InitializeComponent();
        }

        public void Show(string caption, string message, int seconds, bool showCountDown)
        {
            messageLabel.Text = message;
            Show(caption, seconds, showCountDown, true);
        }

    }
}
