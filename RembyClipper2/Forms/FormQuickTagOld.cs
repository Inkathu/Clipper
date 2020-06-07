using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;

namespace RembyClipper2.Forms
{
    public partial class FormQuickTagOld : FormQuicktext
    {

        public string[] Values { get; set; }
        public string Tags { get { return autoCompleteTextBox1.Text; } }

        public FormQuickTagOld()
        {
            InitializeComponent();
            autoCompleteTextBox1.Values = AppConfig.SupportedTags;
            autoCompleteTextBox1.Multiline = false;
        }

        private void autoCompleteTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            autoCompleteTextBox1.Height = e.NewRectangle.Height + 8;
            this.Height = e.NewRectangle.Height + 16;
            if (this.Height < 32)
                this.Height = 32;
        }

        int originalHeight = 0;

        private void autoCompleteTextBox1_onListboxClosed()
        {
            if(originalHeight!=0)
                this.Height = originalHeight;
        }

        private void autoCompleteTextBox1_onListboxOpened()
        {
            originalHeight = this.Height;
            this.Height += 64;
        }

        protected override void UploadButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void autoCompleteTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                this.Close();
        }
    }
}
