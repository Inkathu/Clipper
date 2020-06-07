using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Base;
using RembyClipper2.Config;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace RembyClipper2.Forms
{
    public partial class OCRForm : BaseForm
    {

        private Image screenshot;

        private string _ocrtext = "";

        public string OCRText { get { return GetContentTS(); } }

        public event Action<string> OCRComplete;

        private delegate string getRichTextBoxContentDelegate();
        private string GetContentTS()
        {
            if (this.InvokeRequired)
            {
                getRichTextBoxContentDelegate d = new getRichTextBoxContentDelegate(GetContentTS);
                return (string)this.Invoke(d);
            }
            else
                return richTextBox1.Text;
        }

        public bool isOCRFinished { get; private set; }

        private ToolTip toolTipHelp = new ToolTip();

        public OCRForm()
        {
            InitializeComponent();
            ApplyLanguage();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            if (AppConfig.topnav != null)
            {
                AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
            }
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        public void CancelRecognition()
        {
            if (bw.IsBusy && bw.WorkerSupportsCancellation)
            {
                bw.CancelAsync();
            }
        }

        private void ApplyLanguage()
        {
            this.btnSaveChanges.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_SaveChanges);
            this.btnCancel.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Cancel);

            toolTip1.SetToolTip(label4, Localization.LanguageMgr.LM.GetText(Labels.OCR_Tips));
            toolTipHelp.SetToolTip(buttonCopy1, Localization.LanguageMgr.LM.GetText(Labels.ToolTip_Copy));

            this.Text = Localization.LanguageMgr.LM.GetText(Labels.OCR_FormTitle);
            label1.Text = Localization.LanguageMgr.LM.GetText(Labels.OCR_Title1);
            label2.Text = Localization.LanguageMgr.LM.GetText(Labels.OCR_Title2);
            label3.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.OCR_Quality);
            label4.Text = Localization.LanguageMgr.LM.GetText(Labels.OCR_HowToImprove);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.richTextBox1.Text = _ocrtext;
            isOCRFinished = true;
            Action<string> eventTorise = OCRComplete;
            if(eventTorise != null)
            {
                AppConfig.topnav.Invoke(() => eventTorise(_ocrtext));

            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5);
            tessnet2.Tesseract tess = new tessnet2.Tesseract();
            tess.Init("tessdata", "eng", false); // RAK: !!!!! Make user selectable language
            // Download files from GOogle and place \RembyClipper\bin\Debug\tessdata
            string ocrresult = "";

            AForge.Imaging.Filters.GrayscaleBT709 gsfilter = new AForge.Imaging.Filters.GrayscaleBT709();
            AForge.Imaging.Filters.Threshold tfilter = new AForge.Imaging.Filters.Threshold(128);

            double count = 0;
            double conf = 0;

          
            Bitmap bmp = new Bitmap((int)tmp.Width * 4, (int)tmp.Height * 4);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.DrawImage(tmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            }
            tmp.Dispose();
            List<tessnet2.Word> result = null;
            try
            {

                bmp = gsfilter.Apply(bmp);

                result = tess.DoOCR((bmp), new Rectangle(0, 0, bmp.Width, bmp.Height));
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
            }


            if (result == null)
                return;

            foreach (tessnet2.Word word in result)
            {
                ocrresult += word.Text + " ";
                count++;
                conf += word.Confidence;
            }


            _ocrtext = ocrresult.Trim();

            double avg = 0;
            try
            {
                avg = conf / count;
            }
            catch (Exception exc)
            {
                avg = 0;
                DebugHelper.Log(exc.ToString());
            }

            rembyProgressBar1.Value = (int)avg;
            //cntr.TranslationConfidence = avg.ToString();

            //e.Result = cntr;

        }

        BackgroundWorker bw = new BackgroundWorker();
        Bitmap tmp;
        public void DoOCR(Image img)
        {
            isOCRFinished = false;
            screenshot = img;
            tmp = (Bitmap)screenshot.Clone();
            bw.RunWorkerAsync();
        }

        string originalText = "";

        private void OCRForm_Load(object sender, EventArgs e)
        {
            originalText = richTextBox1.Text;
        }

        private void buttonOrange1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = originalText;
            this.Hide();
        }

        private void buttonCopy1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox1.Text, true, 5, 200);
            toolTip2.Show(Localization.LanguageMgr.LM.GetText(Labels.OCR_TextCopied), buttonCopy1, 3000);
            Timer t = new Timer();
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 3000;
            t.Start();



        }

        void t_Tick(object sender, EventArgs e)
        {
            toolTip2.RemoveAll();
            Timer t = sender as Timer;
            if(t != null)
            {
                t.Stop();
                t.Dispose();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

    }
}
