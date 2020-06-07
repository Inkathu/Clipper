using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localization;

namespace RembyClipper2.Utils.Meesenger
{
    public partial class InfoWithDontShowNotification : NotificationBase
    {
        private Action<bool> _action;
        public InfoWithDontShowNotification(Action<bool> checkBoxAction)
        {
            InitializeComponent();
            ApplyLanguage();
            _action = checkBoxAction;
            ExtendTTL(5);
        }

        private void ApplyLanguage()
        {
            dontShowCB.Text = LanguageMgr.LM.GetText(Labels.NotificationDontShowAgain);
        }

        private void dontShowCB_CheckedChanged(object sender, EventArgs e)
        {
            _action(dontShowCB.Checked);
            InitiateClosing();
        }
    }
}
