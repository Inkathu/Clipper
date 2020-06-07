using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using RembyClipper2.Forms;
using RembyClipper2.Config;
using RembyClipper2.Drawing;

namespace RembyClipper2.Base
{
    public delegate void CustomButtonClicked();
    public delegate void CustomError();

    public partial class RembyScreenshot : BaseControl
    {
        private ToolTip tooltipHelp = new ToolTip();

        public event CustomButtonClicked OnAddToRembyClicked;
        public event CustomButtonClicked OnCloseClicked;

        OCRForm ocr = new OCRForm();

        public RembyScreenshot()
        {
            InitializeComponent();
            this.btnAddToRemby.Text = AppConfig.Lang.GetValue("Button_AddRemby");
            this.btnClose.Text = AppConfig.Lang.GetValue("Button_Close");
            this.Disposed += new EventHandler(RembyScreenshot_Disposed);
            label1.Text = AppConfig.Lang.GetValue("RembyScreenshot_Source");
            tooltipHelp.SetToolTip(this.buttonCopy1, AppConfig.Lang.GetValue("ToolTip_Copy"));
            tooltipHelp.SetToolTip(this.buttonOCR1, AppConfig.Lang.GetValue("ToolTip_OCR"));
            tooltipHelp.SetToolTip(this.buttonSave1, AppConfig.Lang.GetValue("ToolTip_Save"));
            textBoxTags.Values = AppConfig.SupportedTags;
            //pictureBoxZoom.Click += new EventHandler(pictureBoxScreenshot_Click);
            //pictureBox2.Click += new EventHandler(pictureBoxScreenshot_Click);
            pictureBox2.SendToBack();
        }

        void RembyScreenshot_Disposed(object sender, EventArgs e)
        {
            ocr.Dispose();
        }

        public string Source { get { return textBoxSource.Text; } set { textBoxSource.Text = value; } }
        public new string Tag { get { return textBoxTags.Text; } }
        public string OCR { get { return ocr.OCRText; } }

        public Image Screenshot
        {
            get { return pictureBoxScreenshot.BackgroundImage; }
            set
            {
                pictureBoxScreenshot.BackgroundImage = value;

            } 
        }



        private void btnAddToRembyClicked(object sender, EventArgs e)
        {
            if (OnAddToRembyClicked != null)
                OnAddToRembyClicked();
        }

        private void btnCloseClicked(object sender, EventArgs e)
        {
            if (OnCloseClicked != null)
                OnCloseClicked();
        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxScreenshot.BackgroundImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void buttonCopy1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBoxScreenshot.BackgroundImage);
            //toolTip1.SetToolTip(buttonCopy1, "Image copied to your clipboard");
            toolTip1.Show(AppConfig.Lang.GetValue("RembyScreenshot_CopiedToClipboard"), buttonCopy1);
        }

        private void buttonOCR1_Click(object sender, EventArgs e)
        {
            if (ocr == null || ocr.IsDisposed)
                ocr = new OCRForm();
            ocr.ShowDialog();
           
        }

        public bool IsOCRFinished { get { return this.ocr.isOCRFinished; } }

        public void StartOCR()
        {
            this.ocr.DoOCR(pictureBoxScreenshot.BackgroundImage);
        }

        RembyEditingForm ef;
        private void pictureBoxScreenshot_Click(object sender, EventArgs e)
        {
            /*if (pictureBoxScreenshot.BackgroundImage.Size.Height > pictureBoxScreenshot.Size.Height && pictureBoxScreenshot.BackgroundImage.Size.Width > pictureBoxScreenshot.Size.Width)
            {
                PreviewForm pf = new PreviewForm();
                pf.pictureBox1.Image = pictureBoxScreenshot.BackgroundImage;
                pf.ImgSize = pictureBoxScreenshot.BackgroundImage.Size;
                pf.ShowWithZoom();
                pf.Dispose();
            }*/
            ef = new RembyEditingForm();
            ef.img = pictureBoxScreenshot.BackgroundImage;
            ef.LoadImage();
            ef.FormClosing += new FormClosingEventHandler(ef_FormClosing);
            ef.Show();
        }

        void ef_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ef.saved)
                pictureBoxScreenshot.BackgroundImage = ef.img;
        }

        private void pictureBoxScreenshot_MouseEnter(object sender, EventArgs e)
        {
            //pictureBox2.Visible = true;
            pictureBox2.BringToFront();
        }

        private void pictureBoxScreenshot_MouseLeave(object sender, EventArgs e)
        {
            //pictureBox2.Visible = false;
            pictureBox2.SendToBack();
        }

        public void ShowError(string text)
        {
            labelError.Text = text;
            labelError.Visible = true;
            pictureBoxError.Visible = true;
        }

        private void pictureBoxZoom_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxScreenshot_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBoxScreenshot_Click(sender, e);
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOrange1_Click(object sender, EventArgs e)
        {

        }
    }
}
