namespace RembyClipper2.Forms
{
    partial class RembyScreenshotNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RembyScreenshotNew));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tooltipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.labelError = new System.Windows.Forms.Label();
            this.pictureBoxError = new System.Windows.Forms.PictureBox();
            this.surfaceTS = new System.Windows.Forms.ToolStrip();
            this.figureCommandsTS = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.surfacePanel = new System.Windows.Forms.Panel();
            this.drawingSurface = new RembyClipper2.DrawingTool.DrawingSurface();
            this.panel3 = new RembyClipper2.Base.GrayPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxFileName = new RembyClipper2.Base.ExtendedRoundedTextBox();
            this.tagEditControl = new RembyClipper2.Base.TagEditControl();
            this.textBoxSource = new RembyClipper2.Base.ExtendedRoundedTextBox();
            this.buttonOCR1 = new RembyClipper2.Base.GrayButton();
            this.buttonCopy1 = new RembyClipper2.Base.GrayButton();
            this.buttonSave1 = new RembyClipper2.Base.GrayButton();
            this.buttonBlack1 = new RembyClipper2.Base.GrayButton();
            this.btnAddToRemby = new RembyClipper2.Base.BlueButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).BeginInit();
            this.panel1.SuspendLayout();
            this.surfacePanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG Files|*.png";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Remby - Save screenshot";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(192)))));
            this.labelError.Location = new System.Drawing.Point(144, 27);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(35, 13);
            this.labelError.TabIndex = 48;
            this.labelError.Text = "label2";
            this.labelError.Visible = false;
            // 
            // pictureBoxError
            // 
            this.pictureBoxError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxError.Image = global::RembyClipper2.Properties.Resources.ErrorBG;
            this.pictureBoxError.Location = new System.Drawing.Point(85, 12);
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.Size = new System.Drawing.Size(250, 52);
            this.pictureBoxError.TabIndex = 49;
            this.pictureBoxError.TabStop = false;
            this.pictureBoxError.Visible = false;
            // 
            // surfaceTS
            // 
            this.surfaceTS.Location = new System.Drawing.Point(0, 0);
            this.surfaceTS.Name = "surfaceTS";
            this.surfaceTS.Size = new System.Drawing.Size(419, 25);
            this.surfaceTS.TabIndex = 1;
            this.surfaceTS.Text = "toolStrip1";
            // 
            // figureCommandsTS
            // 
            this.figureCommandsTS.Location = new System.Drawing.Point(0, 25);
            this.figureCommandsTS.Name = "figureCommandsTS";
            this.figureCommandsTS.Size = new System.Drawing.Size(419, 25);
            this.figureCommandsTS.TabIndex = 2;
            this.figureCommandsTS.Text = "toolStrip2";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.surfacePanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 213);
            this.panel1.TabIndex = 3;
            // 
            // surfacePanel
            // 
            this.surfacePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surfacePanel.Controls.Add(this.drawingSurface);
            this.surfacePanel.Location = new System.Drawing.Point(106, 65);
            this.surfacePanel.Name = "surfacePanel";
            this.surfacePanel.Size = new System.Drawing.Size(176, 97);
            this.surfacePanel.TabIndex = 1;
            // 
            // drawingSurface
            // 
            this.drawingSurface.BackColor = System.Drawing.Color.Transparent;
            this.drawingSurface.CurrentBorderColor = System.Drawing.Color.Black;
            this.drawingSurface.CurrentFillColor = System.Drawing.Color.Yellow;
            this.drawingSurface.DefaultCreator = null;
            this.drawingSurface.Label = null;
            this.drawingSurface.Location = new System.Drawing.Point(0, 0);
            this.drawingSurface.Name = "drawingSurface";
            this.drawingSurface.Size = new System.Drawing.Size(174, 95);
            this.drawingSurface.TabIndex = 0;
            this.drawingSurface.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.panel3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panel3.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Controls.Add(this.tagEditControl);
            this.panel3.Controls.Add(this.textBoxSource);
            this.panel3.Controls.Add(this.buttonOCR1);
            this.panel3.Controls.Add(this.buttonCopy1);
            this.panel3.Controls.Add(this.buttonSave1);
            this.panel3.Controls.Add(this.buttonBlack1);
            this.panel3.Controls.Add(this.btnAddToRemby);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.DrawRoundedBorder = false;
            this.panel3.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Location = new System.Drawing.Point(0, 263);
            this.panel3.Name = "panel3";
            this.panel3.RoundingRadius = 10;
            this.panel3.ShowBorder = false;
            this.panel3.Size = new System.Drawing.Size(419, 181);
            this.panel3.TabIndex = 0;
            this.panel3.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFileName, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 40);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(3, 2);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(396, 13);
            this.labelName.TabIndex = 47;
            this.labelName.Text = "#Name#";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.BackColor = System.Drawing.Color.Transparent;
            this.textBoxFileName.InnerText = "";
            this.textBoxFileName.Location = new System.Drawing.Point(3, 18);
            this.textBoxFileName.MinimumSize = new System.Drawing.Size(0, 20);
            this.textBoxFileName.Multiline = false;
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.PasswordChar = '\0';
            this.textBoxFileName.ReadOnly = false;
            this.textBoxFileName.SelectionLength = 0;
            this.textBoxFileName.SelectionStart = 0;
            this.textBoxFileName.Size = new System.Drawing.Size(396, 20);
            this.textBoxFileName.TabIndex = 46;
            this.textBoxFileName.TextLength = 32767;
            // 
            // tagEditControl
            // 
            this.tagEditControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagEditControl.AutoSize = true;
            this.tagEditControl.BackColor = System.Drawing.Color.Transparent;
            this.tagEditControl.Location = new System.Drawing.Point(11, 100);
            this.tagEditControl.Name = "tagEditControl";
            this.tagEditControl.Size = new System.Drawing.Size(396, 40);
            this.tagEditControl.TabIndex = 0;
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.BackColor = System.Drawing.Color.Transparent;
            this.textBoxSource.InnerText = "";
            this.textBoxSource.Location = new System.Drawing.Point(11, 63);
            this.textBoxSource.MinimumSize = new System.Drawing.Size(0, 20);
            this.textBoxSource.Multiline = false;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.PasswordChar = '\0';
            this.textBoxSource.ReadOnly = true;
            this.textBoxSource.SelectionLength = 0;
            this.textBoxSource.SelectionStart = 0;
            this.textBoxSource.Size = new System.Drawing.Size(396, 20);
            this.textBoxSource.TabIndex = 1;
            this.textBoxSource.TextLength = 32767;
            // 
            // buttonOCR1
            // 
            this.buttonOCR1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOCR1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonOCR1.ButtonCaption = "OCR";
            this.buttonOCR1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonOCR1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonOCR1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonOCR1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOCR1.FontColor = System.Drawing.Color.Black;
            this.buttonOCR1.Image = null;
            this.buttonOCR1.ImageSize = new System.Drawing.Size(29, 26);
            this.buttonOCR1.Location = new System.Drawing.Point(80, 146);
            this.buttonOCR1.Name = "buttonOCR1";
            this.buttonOCR1.RoundingRadius = 10;
            this.buttonOCR1.Size = new System.Drawing.Size(44, 26);
            this.buttonOCR1.TabIndex = 4;
            this.buttonOCR1.Text = "OCR";
            this.buttonOCR1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonOCR1.UseVisualStyleBackColor = true;
            this.buttonOCR1.Visible = false;
            this.buttonOCR1.Click += new System.EventHandler(this.buttonOCR1_Click);
            // 
            // buttonCopy1
            // 
            this.buttonCopy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopy1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonCopy1.ButtonCaption = "";
            this.buttonCopy1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonCopy1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonCopy1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonCopy1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCopy1.FontColor = System.Drawing.Color.Black;
            this.buttonCopy1.Image = global::RembyClipper2.NewDesign.icon_copy;
            this.buttonCopy1.ImageSize = new System.Drawing.Size(29, 26);
            this.buttonCopy1.Location = new System.Drawing.Point(45, 146);
            this.buttonCopy1.Name = "buttonCopy1";
            this.buttonCopy1.RoundingRadius = 10;
            this.buttonCopy1.Size = new System.Drawing.Size(29, 26);
            this.buttonCopy1.TabIndex = 3;
            this.buttonCopy1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonCopy1.UseVisualStyleBackColor = true;
            this.buttonCopy1.Click += new System.EventHandler(this.buttonCopy1_Click);
            // 
            // buttonSave1
            // 
            this.buttonSave1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonSave1.ButtonCaption = "";
            this.buttonSave1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonSave1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonSave1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSave1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave1.FontColor = System.Drawing.Color.Black;
            this.buttonSave1.Image = global::RembyClipper2.NewDesign.icon_save;
            this.buttonSave1.ImageSize = new System.Drawing.Size(29, 26);
            this.buttonSave1.Location = new System.Drawing.Point(10, 146);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.RoundingRadius = 10;
            this.buttonSave1.Size = new System.Drawing.Size(29, 26);
            this.buttonSave1.TabIndex = 2;
            this.buttonSave1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonSave1.UseVisualStyleBackColor = true;
            this.buttonSave1.Click += new System.EventHandler(this.buttonSave1_Click);
            // 
            // buttonBlack1
            // 
            this.buttonBlack1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBlack1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonBlack1.ButtonCaption = "*Cancel";
            this.buttonBlack1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonBlack1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonBlack1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBlack1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBlack1.FontColor = System.Drawing.Color.Black;
            this.buttonBlack1.ForeColor = System.Drawing.Color.Black;
            this.buttonBlack1.Image = null;
            this.buttonBlack1.ImageSize = new System.Drawing.Size(20, 20);
            this.buttonBlack1.Location = new System.Drawing.Point(330, 146);
            this.buttonBlack1.Name = "buttonBlack1";
            this.buttonBlack1.RoundingRadius = 10;
            this.buttonBlack1.Size = new System.Drawing.Size(77, 30);
            this.buttonBlack1.TabIndex = 6;
            this.buttonBlack1.Text = "*Cancel";
            this.buttonBlack1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonBlack1.UseVisualStyleBackColor = true;
            this.buttonBlack1.Click += new System.EventHandler(this.CancelClick);
            // 
            // btnAddToRemby
            // 
            this.btnAddToRemby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToRemby.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(136)))), ((int)(((byte)(213)))));
            this.btnAddToRemby.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnAddToRemby.ButtonCaption = "*Add To Remby";
            this.btnAddToRemby.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.btnAddToRemby.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnAddToRemby.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddToRemby.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddToRemby.FontColor = System.Drawing.Color.White;
            this.btnAddToRemby.ForeColor = System.Drawing.Color.White;
            this.btnAddToRemby.Image = null;
            this.btnAddToRemby.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddToRemby.Location = new System.Drawing.Point(170, 146);
            this.btnAddToRemby.Name = "btnAddToRemby";
            this.btnAddToRemby.RoundingRadius = 10;
            this.btnAddToRemby.Size = new System.Drawing.Size(150, 30);
            this.btnAddToRemby.TabIndex = 5;
            this.btnAddToRemby.Text = "*Add To Remby";
            this.btnAddToRemby.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.btnAddToRemby.UseVisualStyleBackColor = false;
            this.btnAddToRemby.Click += new System.EventHandler(this.UploadClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tags";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Source";
            // 
            // RembyScreenshotNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonBlack1;
            this.ClientSize = new System.Drawing.Size(419, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.figureCommandsTS);
            this.Controls.Add(this.surfaceTS);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.pictureBoxError);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(435, 445);
            this.Name = "RembyScreenshotNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RembyScreenshot";
            this.SizeChanged += new System.EventHandler(this.RembyScreenshotNew_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).EndInit();
            this.panel1.ResumeLayout(false);
            this.surfacePanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Base.GrayPanel panel3;
        private Base.ExtendedRoundedTextBox textBoxSource;
        private Base.GrayButton buttonOCR1;
        private Base.GrayButton buttonCopy1;
        private Base.GrayButton buttonSave1;
        public Base.GrayButton buttonBlack1;
        public Base.BlueButton btnAddToRemby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip tooltipHelp;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.PictureBox pictureBoxError;
        private System.Windows.Forms.ToolStrip surfaceTS;
        private System.Windows.Forms.ToolStrip figureCommandsTS;
        private System.Windows.Forms.Panel panel1;
        private DrawingTool.DrawingSurface drawingSurface;
        private Base.TagEditControl tagEditControl;
        private System.Windows.Forms.Panel surfacePanel;
        private Base.ExtendedRoundedTextBox textBoxFileName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}