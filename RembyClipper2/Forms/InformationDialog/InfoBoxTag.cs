using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;

namespace RembyClipper2.Forms.InformationDialog
{
    public partial class InfoBoxTag : InfoBox
    {
        private Action<string> _action;
        public InfoBoxTag()
        {
            InitializeComponent();
            tagEditControl1.CustomMouseDown += new MouseEventHandler(Window_MouseDown);
            //tagTextBox.MouseMove += new MouseEventHandler(Window_MouseMove);
            tagEditControl1.CustomGotFocus += new EventHandler(tagTextBox_CustomGotFocus);
            WindowHiding += new EventHandler(InfoBoxTag_WindowHiding);
            //Shown += new EventHandler(InfoBoxTag_Shown);
            

        }

//        void InfoBoxTag_Shown(object sender, EventArgs e)
//        {
//            tagEditControl1.AddTags(AppConfig.Instance.LastUsedTags);
//        }


        void InfoBoxTag_WindowHiding(object sender, EventArgs e)
        {
            if (DialogResult != DialogResult.Cancel)
            {
                var lastUsedTags = tagEditControl1.GetTagsString();
                AppConfig.Instance.LastUsedTags = lastUsedTags;
                AppConfig.Instance.Store();

                _action(lastUsedTags);
                Hide();
            }
        }

       
        void tagTextBox_CustomGotFocus(object sender, EventArgs e)
        {
            StopTimer();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            closeButton.PerformClick();
        }

        public void Show(Action<string> action, string caption, int seconds, bool showCountDown)
        {
            _action = action;
            tagEditControl1.SetTagsCollection(AppConfig.SupportedTags);
            tagEditControl1.AddTags(AppConfig.Instance.LastUsedTags);
            Show(caption, seconds, showCountDown);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            var lastUsedTags = tagEditControl1.GetTagsString();
            AppConfig.Instance.LastUsedTags = lastUsedTags;
            AppConfig.Instance.Store();
            StopTimer();
            _action(lastUsedTags);
            
            Hide();
        }
    }
}
