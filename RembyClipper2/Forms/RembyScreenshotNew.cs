using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Meesenger.Uploading;
using RembyClipper2.Utils.Uploading;
using RembyClipper2.Utils.Uploading.Entities;
using RembyClipper2.Utils;

namespace RembyClipper2.Forms
{
    public partial class RembyScreenshotNew : Form
    {
        public Image Image
        {
            
            get { return drawingSurface.GetImage(); }
            set
            {
                
                drawingSurface.SetImage(value);
                RelayoutSurface(true);
                CheckWindowSize();
                
            }
        }

        private void CheckWindowSize()
        {
            int width = Size.Width;
            int height = Size.Height;

            if(Size.Width > Screen.PrimaryScreen.WorkingArea.Size.Width)
            {
                width = Screen.PrimaryScreen.WorkingArea.Size.Width;
            }

            if(Size.Height > Screen.PrimaryScreen.WorkingArea.Size.Height)
            {
                height = Screen.PrimaryScreen.WorkingArea.Size.Height;
            }

            if(width != Size.Width || height != Size.Height)
            {
                Size = new Size(width, height);
                StartPosition = FormStartPosition.Manual;
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Left,Screen.PrimaryScreen.WorkingArea.Top);

            } else
            {
                StartPosition = FormStartPosition.CenterScreen;
            }


        }

        private void RelayoutSurface(bool changeWindowSize)
        {
            int dx = 0;
            int dy = 0;
            if (surfacePanel.Size.Width < panel1.Size.Width)
            {
                surfacePanel.Left = (panel1.Size.Width - surfacePanel.Size.Width) / 2;
            } else
            {
                surfacePanel.Left = 0;
                dx = surfacePanel.Size.Width - panel1.Size.Width;
            }
            if (surfacePanel.Size.Height < panel1.Size.Height)
            {
                surfacePanel.Top = (panel1.Size.Height - surfacePanel.Height) / 2;
            } else
            {
                surfacePanel.Top = 0;
                dy = surfacePanel.Size.Height - panel1.Size.Height;
            }
            if (changeWindowSize)
            {
                this.Width += dx;
                this.Height += dy;
            }
        }

        public bool saved = false;

        OCRForm ocr = new OCRForm();
        public string FileName
        {
            get { return textBoxFileName.Text; }
            set
            {
                textBoxFileName.Text = value;
                Text = Localization.LanguageMgr.LM.GetFormattedText(Labels.RembyScrennshot_WindowTitle, "- " + FileName);
                drawingSurface.ImageName = value;
            }
        }

        public bool IsScreenShot = true;

        public string Source { get { return textBoxSource.Text; } set { textBoxSource.Text = value; } }
        private string src { get; set; }
        public new string Tag { get { return tagEditControl.GetTagsString(); } set { tagEditControl.AddTags(value); } }

        public string OCR { get { return ocr.OCRText; } }

        /// <summary>
        /// .ctor
        /// </summary>
        public RembyScreenshotNew()
        {
            InitializeComponent();

            ApplyLanguage();
            tagEditControl.SetTagsCollection(AppConfig.SupportedTags);
            if (!string.IsNullOrEmpty(AppConfig.Instance.LastUsedTags))
            {
                tagEditControl.AddTags(AppConfig.Instance.LastUsedTags);
            }
            this.FormClosing += new FormClosingEventHandler(FormImgPreview_FormClosing);
            this.Load += new EventHandler(RembyEditingForm_Load);
            if (AppConfig.topnav != null)
            {
                AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
            }
            figureCommandsTS.Items.Clear();
            var surfCommands = (from command in drawingSurface.GetCommands()
                                select command.GetMenu()).ToArray();
            surfaceTS.Items.AddRange(surfCommands);
            drawingSurface.figureSelectionChanged += new DrawingTool.FigureSelectionChanged(drawingSurface_figureSelectionChanged);
            drawingSurface.CurrentFillColor = AppConfig.Instance.DrawingFillrColor;
            drawingSurface.CurrentBorderColor = AppConfig.Instance.DrawingBorderColor;
            DateTime now = DateTime.Now;
            FileName = Localization.LanguageMgr.LM.GetFormattedText(Labels.ScreenshotTextParam, now.Date.ToString("yyyyMMdd"), now.ToString("HH:mm"));
            Source = AppConfig.topnav.LastAppName;
            

        }

        void drawingSurface_figureSelectionChanged(DrawingTool.Figures.IFigure figure)
        {
            figureCommandsTS.Items.Clear();
            if (figure != null)
            {
                var menus = (from command in figure.GetCommands()
                             select command.GetMenu()).ToArray();
                figureCommandsTS.Items.AddRange(menus);

            }
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            Text = Localization.LanguageMgr.LM.GetFormattedText(Labels.RembyScrennshot_WindowTitle, " #");
            btnAddToRemby.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_AddRemby);
            buttonBlack1.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Close);
            buttonOCR1.Text = Localization.LanguageMgr.LM.GetText(Labels.OCR);
            label2.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Tags);
            label1.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Source);
            tooltipHelp.SetToolTip(this.buttonCopy1, Localization.LanguageMgr.LM.GetText(Labels.ToolTip_Copy));
            tooltipHelp.SetToolTip(this.buttonOCR1, Localization.LanguageMgr.LM.GetText(Labels.ToolTip_OCR));
            tooltipHelp.SetToolTip(this.buttonSave1, Localization.LanguageMgr.LM.GetText(Labels.ToolTip_Save));
            //labelDescription.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.DescriptionText);
            labelName.Text = Localization.LanguageMgr.LM.GetLabelText(Labels.Name);
            //rembyLoginControl1.ApplyLanguage();
        }

        void RembyEditingForm_Load(object sender, EventArgs e)
        {
            StartOCR();
            AppConfig.topnav.RegisterOpenWindow(this);
            
            drawingSurface.ClearUndoRedo();
            drawingSurface.UpdateUndoRedo();
        }

        void FormImgPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsOCRFinished == false)
            {
                ocr.CancelRecognition();
            }
            AppConfig.topnav.RegisterCloseWindow(this);
            AppConfig.Instance.Store();
            Image.Dispose();

            if (AppConfig.topnav != null)
            {
                AppConfig.topnav.languageChanged -= topnav_languageChanged;
            }

            drawingSurface.figureSelectionChanged -= drawingSurface_figureSelectionChanged;
            drawingSurface.Dispose();

        }
        void rembyDone1_OnBlackClicked()
        {
            this.Close();
        }
        
        private void CancelClick(object sender, EventArgs e)
        {
            this.saved = false;
            this.Close();
        }

        private void UploadClick(object sender, EventArgs e)
        {
            processDataUpoloading();
        }

        void processDataUpoloading()
        {
            //CurrentState = WindowState.login;
            this.Hide();
            AppConfig.Instance.LastUsedTags = tagEditControl.GetTagsString();
            AppConfig.Instance.Store();
            UploadDispatcher.Instance.Upload(new ScreenShootEntity()
                                                 {
                                                     Image = Image,
                                                     FileName = FileName,
                                                     OCR = "",//OCR,
                                                     Description = "",
                                                     SRC = Source,
                                                     Tags = Tag,
                                                     CallerForm = this,
                                                     IsScreenShot = IsScreenShot,
                                                     Context = Source.HasValue() ? Source : ""
                                                 }.Init());

        }



        public bool IsOCRFinished { get { return this.ocr.isOCRFinished; } }

        public void StartOCR()
        {
            //this.ocr.OCRComplete += new Action<string>(ocr_OCRComplete);
            //this.ocr.DoOCR(Image);
        }

        void ocr_OCRComplete(string obj)
        {
            //textBoxDescription.Text = obj;
        }

        public void ShowError(string text)
        {
            labelError.Text = text;
            labelError.Visible = true;
            pictureBoxError.Visible = true;
        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {

                Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void buttonCopy1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Image, true, 5, 200);
            tooltipHelp.ToolTipTitle = "Clipboard";
            tooltipHelp.ShowCustom(Localization.LanguageMgr.LM.GetText(Labels.RembyScreenshot_CopiedToClipboard), buttonCopy1);

        }

        private void buttonOCR1_Click(object sender, EventArgs e)
        {
            if (ocr == null || ocr.IsDisposed)
                ocr = new OCRForm();
            ocr.ShowDialog(this);

        }

        private void RembyScreenshotNew_SizeChanged(object sender, EventArgs e)
        {
            RelayoutSurface(false);
        }

    }
}
