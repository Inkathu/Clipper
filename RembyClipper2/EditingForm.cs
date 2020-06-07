using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RembyClipper.Helpers;

namespace RembyClipper2.Drawing
{
    public partial class EditingForm : RembyClipper.RembyEditorForm
    {
        public Image img = null;
        public EditingForm()
        {
            InitializeComponent();
            FormHelper.EditorForm = this;
            this.FormClosing += new FormClosingEventHandler(EditingForm_FormClosing);
        }

        public void LoadImage()
        {
            this.surface.Width = img.Width;//  +10;  sa : ????
            this.surface.Height = img.Height;// +10; sa : ????
            this.CanvasSize = img.Size;
            Clipboard.SetImage(img);
            this.SetImage(img, "", "");
            this.Size = new System.Drawing.Size(img.Width + 120, img.Height + 120);
        }

        void EditingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //img = surface.GetImageForExport();
        }
    }
}
