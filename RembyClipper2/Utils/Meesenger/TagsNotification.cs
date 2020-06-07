using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;

namespace RembyClipper2.Utils.Meesenger
{
    public partial class TagsNotification : NotificationBase
    {
        public Action<string> Action { get; set; }
        private bool _actionCalled;
        public TagsNotification()
        {
            InitializeComponent();
            tagEditControl1.CustomMouseDown += new MouseEventHandler(tagEditControl1_CustomMouseDown);
            //tagTextBox.MouseMove += new MouseEventHandler(Window_MouseMove);
            tagEditControl1.CustomGotFocus += new EventHandler(tagTextBox_CustomGotFocus);
            NotificationHided += new EventHandler(TagsNotification_NotificationHided);
            tagEditControl1.SetTagsCollection(AppConfig.SupportedTags);
            tagEditControl1.AddTags(AppConfig.Instance.LastUsedTags);
            TTL = DateTime.Now.AddSeconds(5);

        }

        void tagEditControl1_CustomMouseDown(object sender, MouseEventArgs e)
        {
            CanBeRemoved = false;
        }

        void TagsNotification_NotificationHided(object sender, EventArgs e)
        {
            if (!closedByCross)
            {
                var lastUsedTags = tagEditControl1.GetTagsString();
                AppConfig.Instance.LastUsedTags = lastUsedTags;
                AppConfig.Instance.Store();
                if (!_actionCalled)
                {
                    Action(lastUsedTags);
                    _actionCalled = true;
                }
            }
        }

        void tagTextBox_CustomGotFocus(object sender, EventArgs e)
        {
            CanBeRemoved = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            closedByCross = true;
            TTL = DateTime.Now.AddSeconds(-1);
            CanBeRemoved = true;
            //cancelButton.PerformClick();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            var lastUsedTags = tagEditControl1.GetTagsString();
            AppConfig.Instance.LastUsedTags = lastUsedTags;
            AppConfig.Instance.Store();
            
            Action(lastUsedTags);
            _actionCalled = true;
            CanBeRemoved = true;
        }


    }
}
