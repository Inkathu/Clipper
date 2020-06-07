using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Utils;

namespace RembyClipper2.Base
{
    public partial class TagEditControl : UserControl
    {
        public event EventHandler CustomGotFocus;
        public event MouseEventHandler CustomMouseDown;
        public event EventHandler TagsCollectionChanged;
        public TagEditControl()
        {
            InitializeComponent();
            tagsLP.Controls.SetChildIndex(tagsTB, 1000);
            tagsTB.GotFocus += new EventHandler(tagsTB_GotFocus);
            tagsLP.GotFocus += new EventHandler(tagsTB_GotFocus);
            tagsTB.MouseDown += new MouseEventHandler(tagsTB_MouseDown);
            tagsLP.MouseDown += new MouseEventHandler(tagsTB_MouseDown);
            SizeChanged += new EventHandler(TagEditControl_SizeChanged);
        }

        void TagEditControl_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

      

        void tagsTB_MouseDown(object sender, MouseEventArgs e)
        {
            if(CustomMouseDown!= null)
            {
                CustomMouseDown(sender, e);
            }
        }

        void tagsTB_GotFocus(object sender, EventArgs e)
        {
            if(CustomGotFocus!= null)
            {
                CustomGotFocus(sender, e);
            }
        }


        public void SetTagsCollection(string[] tags)
        {
            SetTagsCollection(new List<string>(tags));
        }
        public void SetTagsCollection(List<string> tags)
        {
            tagsTB.AutoCompleteCustomSource.AddRange(tags.ToArray());
        }

        private void tagsTB_KeyUp(object sender, KeyEventArgs e)
        {
            
            switch(e.KeyCode)
            {
                case Keys.Oemcomma:
                    tagsTB.Text = tagsTB.Text.Replace(',', ' ');
                    ProcessSpacePress();
                    e.Handled = true;
                    break;
                case Keys.Space:
                    ProcessSpacePress();
                    e.Handled = true;
                    break;
                case Keys.Back:
                    ProcessBackPress();
                    e.Handled = true;
                    break;
            }
        }

        private void RiseCollectionChangeEvent()
        {
            if(TagsCollectionChanged != null)
            {
                TagsCollectionChanged(this, EventArgs.Empty);
            }
        }

        private void ProcessBackPress()
        {
            if (tagsLP.Controls.Count <= 1 || textBoxContent.HasValue())
            {
                return;
            }
            var ctrl = tagsLP.Controls[tagsLP.Controls.Count - 2];
            tagsLP.Controls.Remove(ctrl);
            tagsTB.AutoCompleteCustomSource.Add(ctrl.Text);
            RiseCollectionChangeEvent();

        }

        private void ProcessSpacePress()
        {

            string tag = tagsTB.Text.Trim();
            tagsTB.Text = "";
            if (string.IsNullOrEmpty(tag))
            {
                tagsTB.Text = "";
                return;
            }
 
            if(tag.Contains(" "))
            {
                tag = tag.Substring(0, tag.IndexOf(" "));
            }
            if (GetTags().Contains(tag))
            {
                var tagItem =  tagsLP.Controls.OfType<TagItem>().Where(control => control.Text == tag).Select(control => control).First();
                toolTip.Show(LanguageMgr.LM.GetText(Labels.TagIsAlreadyUsed), tagItem, 3000);
                tagsTB.Text = "";
                return;
            }
            if(tagsTB.AutoCompleteCustomSource.Contains(tag))
            {
                tagsTB.AutoCompleteCustomSource.Remove(tag);
            }
            TagItem ti = new TagItem(){Text = tag};
            

            tagsLP.Controls.Add(ti);
            tagsLP.Controls.SetChildIndex(ti, tagsLP.Controls.Count - 1);
            tagsLP.Controls.SetChildIndex(tagsTB, tagsLP.Controls.Count);
            
            tagsTB.Text = "";
            tagsLP.VerticalScroll.Value = tagsLP.VerticalScroll.Maximum;
            RiseCollectionChangeEvent();
        }

        public List<string> GetTags()
        {
            return tagsLP.Controls.OfType<TagItem>().Select(control => (control).Text).ToList();
        }

        public string GetTagsString()
        {
            if(GetTags().Count > 0)
            {
                return GetTags().Aggregate((t1, t2) => t1 + " " + t2);
            }
            return "";
        }

        /// <summary>
        /// This variable need to prevent tag item removing in case when text box contains only one character
        /// and deletion of this character will cause removing of the last tag
        /// </summary>
        private string textBoxContent = "";
        
        private void tagsTB_KeyDown(object sender, KeyEventArgs e)
        {

            textBoxContent = tagsTB.Text;
            
        }

        private void tagsLP_Click(object sender, EventArgs e)
        {
            tagsTB.Focus();
        }

        private void tagsLP_Scroll(object sender, ScrollEventArgs e)
        {
            grayPanel1.Refresh();
        }

        public void AddTags(string lastUsedTags)
        {
            tagsLP.SuspendLayout();
            char splitChar = ',';
            if(!lastUsedTags.Contains(splitChar))
            {
                splitChar = ' ';
            }
            string[] splittedTags = lastUsedTags.Split(new char[] {splitChar});
            
            foreach (var splittedTag in splittedTags)
            {
                tagsTB.Text = splittedTag;
                ProcessSpacePress();
            }
            tagsLP.ResumeLayout();
        }

        private void tagsTB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || (e.KeyCode == Keys.Tab && tagsTB.Text.HasValue()))
            {
                //it's bad practice to use some logic in this method 
                //but in some reason inputkey doesn't allow  to catch tab key in keydown handler.
                ProcessSpacePress();
            }
        }

        private void tagsTB_Leave(object sender, EventArgs e)
        {
            if(tagsTB.Text.HasValue())
            {
                ProcessSpacePress();
            }
        }

        private void tagsLP_ControlRemoved(object sender, ControlEventArgs e)
        {
            RiseCollectionChangeEvent();
        }

       
        private void tagsTB_Enter(object sender, EventArgs e)
        {
            int i = 1;
        }

        private void tagsTB_TextChanged(object sender, EventArgs e)
        {
            if(tagsTB.SelectionLength == tagsTB.Text.Length)
            {
               
            }
        }

     
    }
}
