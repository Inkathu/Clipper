using RembyClipper2.Base;

namespace RembyClipper2.Forms
{
    partial class RembyEditingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RembyEditingForm));
            this.panel3 = new RembyClipper2.Base.GrayPanel();
            this.textBoxTags = new RembyClipper2.Base.TagsCombo();
            this.textBoxSource = new RembyClipper2.Base.ExtendedRoundedTextBox();
            this.buttonOCR1 = new RembyClipper2.Base.GrayButton();
            this.buttonCopy1 = new RembyClipper2.Base.GrayButton();
            this.buttonSave1 = new RembyClipper2.Base.GrayButton();
            this.buttonBlack1 = new RembyClipper2.Base.GrayButton();
            this.btnAddToRemby = new RembyClipper2.Base.BlueButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBoxError = new System.Windows.Forms.PictureBox();
            this.tooltipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.labelError = new System.Windows.Forms.Label();
            this.rembyDone1 = new RembyClipper2.Base.RembyDone();
            this.rembyUploading1 = new RembyClipper2.Base.RembyUploading();
            this.rembyLoginControl1 = new RembyClipper2.Base.RembyLoginControl();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStripContainerTB.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surface)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(715, 445);
            this.toolStripContainer1.Size = new System.Drawing.Size(715, 445);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rembyLoginControl1);
            this.panel1.Controls.Add(this.rembyUploading1);
            this.panel1.Controls.Add(this.rembyDone1);
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.pictureBoxError);
            this.panel1.Size = new System.Drawing.Size(715, 355);
            this.panel1.Controls.SetChildIndex(this.surface, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBoxError, 0);
            this.panel1.Controls.SetChildIndex(this.toolStripContainerTB, 0);
            this.panel1.Controls.SetChildIndex(this.labelError, 0);
            this.panel1.Controls.SetChildIndex(this.rembyDone1, 0);
            this.panel1.Controls.SetChildIndex(this.rembyUploading1, 0);
            this.panel1.Controls.SetChildIndex(this.rembyLoginControl1, 0);
            // 
            // pnlDDMenu
            // 
            this.pnlDDMenu.Location = new System.Drawing.Point(736, 338);
            // 
            // toolStripContainerTB
            // 
            // 
            // toolStripContainerTB.ContentPanel
            // 
            this.toolStripContainerTB.ContentPanel.Size = new System.Drawing.Size(335, 56);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 355);
            this.panel2.Size = new System.Drawing.Size(715, 90);
            // 
            // surface
            // 
            this.surface.Location = new System.Drawing.Point(31, 38);
            this.surface.Size = new System.Drawing.Size(653, 279);
            // 
            // panel3
            // 
            this.panel3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.panel3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panel3.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.panel3.Controls.Add(this.textBoxTags);
            this.panel3.Controls.Add(this.textBoxSource);
            this.panel3.Controls.Add(this.buttonOCR1);
            this.panel3.Controls.Add(this.buttonCopy1);
            this.panel3.Controls.Add(this.buttonSave1);
            this.panel3.Controls.Add(this.buttonBlack1);
            this.panel3.Controls.Add(this.btnAddToRemby);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.DrawRoundedBorder = false;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.RoundingRadius = 10;
            this.panel3.ShowBorder = false;
            this.panel3.Size = new System.Drawing.Size(715, 90);
            this.panel3.TabIndex = 32;
            this.panel3.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // textBoxTags
            // 
            this.textBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTags.BackColor = System.Drawing.Color.DimGray;
            this.textBoxTags.CustomText = "Remby, ";
            this.textBoxTags.Location = new System.Drawing.Point(533, 22);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(178, 21);
            this.textBoxTags.TabIndex = 53;
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.InnerText = "title of the window";
            this.textBoxSource.Location = new System.Drawing.Point(7, 22);
            this.textBoxSource.MinimumSize = new System.Drawing.Size(0, 20);
            this.textBoxSource.Multiline = false;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.PasswordChar = '\0';
            this.textBoxSource.SelectionLength = 0;
            this.textBoxSource.SelectionStart = 0;
            this.textBoxSource.Size = new System.Drawing.Size(513, 20);
            this.textBoxSource.TabIndex = 52;
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
            this.buttonOCR1.Location = new System.Drawing.Point(80, 55);
            this.buttonOCR1.Name = "buttonOCR1";
            this.buttonOCR1.RoundingRadius = 10;
            this.buttonOCR1.Size = new System.Drawing.Size(44, 26);
            this.buttonOCR1.TabIndex = 51;
            this.buttonOCR1.Text = "OCR";
            this.buttonOCR1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonOCR1.UseVisualStyleBackColor = true;
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
            this.buttonCopy1.Location = new System.Drawing.Point(45, 55);
            this.buttonCopy1.Name = "buttonCopy1";
            this.buttonCopy1.RoundingRadius = 10;
            this.buttonCopy1.Size = new System.Drawing.Size(29, 26);
            this.buttonCopy1.TabIndex = 51;
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
            this.buttonSave1.Location = new System.Drawing.Point(10, 55);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.RoundingRadius = 10;
            this.buttonSave1.Size = new System.Drawing.Size(29, 26);
            this.buttonSave1.TabIndex = 51;
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
            this.buttonBlack1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonBlack1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBlack1.FontColor = System.Drawing.Color.Black;
            this.buttonBlack1.ForeColor = System.Drawing.Color.Black;
            this.buttonBlack1.Image = null;
            this.buttonBlack1.ImageSize = new System.Drawing.Size(20, 20);
            this.buttonBlack1.Location = new System.Drawing.Point(627, 55);
            this.buttonBlack1.Name = "buttonBlack1";
            this.buttonBlack1.RoundingRadius = 10;
            this.buttonBlack1.Size = new System.Drawing.Size(77, 30);
            this.buttonBlack1.TabIndex = 50;
            this.buttonBlack1.Text = "*Cancel";
            this.buttonBlack1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonBlack1.UseVisualStyleBackColor = true;
            this.buttonBlack1.Click += new System.EventHandler(this.buttonBlack1_Click);
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
            this.btnAddToRemby.Location = new System.Drawing.Point(471, 55);
            this.btnAddToRemby.Name = "btnAddToRemby";
            this.btnAddToRemby.RoundingRadius = 10;
            this.btnAddToRemby.Size = new System.Drawing.Size(150, 30);
            this.btnAddToRemby.TabIndex = 49;
            this.btnAddToRemby.Text = "*Add To Remby";
            this.btnAddToRemby.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.btnAddToRemby.UseVisualStyleBackColor = false;
            this.btnAddToRemby.Click += new System.EventHandler(this.buttonOrange1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(530, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tags";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Source";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG Files|*.png";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Remby - Save screenshot";
            // 
            // pictureBoxError
            // 
            this.pictureBoxError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxError.Image = global::RembyClipper2.Properties.Resources.ErrorBG;
            this.pictureBoxError.Location = new System.Drawing.Point(20, 0);
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.Size = new System.Drawing.Size(231, 52);
            this.pictureBoxError.TabIndex = 35;
            this.pictureBoxError.TabStop = false;
            this.pictureBoxError.Visible = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(192)))));
            this.labelError.Location = new System.Drawing.Point(58, 20);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(35, 13);
            this.labelError.TabIndex = 39;
            this.labelError.Text = "label2";
            this.labelError.Visible = false;
            // 
            // rembyDone1
            // 
            this.rembyDone1.BackColor = System.Drawing.Color.Transparent;
            this.rembyDone1.Location = new System.Drawing.Point(219, 20);
            this.rembyDone1.Name = "rembyDone1";
            this.rembyDone1.Size = new System.Drawing.Size(296, 240);
            this.rembyDone1.TabIndex = 40;
            this.rembyDone1.Visible = false;
            // 
            // rembyUploading1
            // 
            this.rembyUploading1.BackColor = System.Drawing.Color.Transparent;
            this.rembyUploading1.Location = new System.Drawing.Point(-17, 66);
            this.rembyUploading1.MaximumSize = new System.Drawing.Size(230, 230);
            this.rembyUploading1.MinimumSize = new System.Drawing.Size(230, 230);
            this.rembyUploading1.Name = "rembyUploading1";
            this.rembyUploading1.Size = new System.Drawing.Size(230, 230);
            this.rembyUploading1.TabIndex = 41;
            this.rembyUploading1.Visible = false;
            // 
            // rembyLoginControl1
            // 
            this.rembyLoginControl1.BackColor = System.Drawing.Color.Transparent;
            this.rembyLoginControl1.Location = new System.Drawing.Point(375, 38);
            this.rembyLoginControl1.MaximumSize = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.MinimumSize = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.Name = "rembyLoginControl1";
            this.rembyLoginControl1.Size = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.TabIndex = 42;
            this.rembyLoginControl1.Visible = false;
            // 
            // RembyEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 448);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RembyEditingForm";
            this.Text = "Remby Clipper";
            this.Controls.SetChildIndex(this.pnlDDMenu, 0);
            this.Controls.SetChildIndex(this.toolStripContainer1, 0);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripContainerTB.ResumeLayout(false);
            this.toolStripContainerTB.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.surface)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GrayPanel panel3;
        public GrayButton buttonBlack1;
        public BlueButton btnAddToRemby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxError;
        private System.Windows.Forms.ToolTip tooltipHelp;
        private System.Windows.Forms.Label labelError;
        private RembyDone rembyDone1;
        private RembyUploading rembyUploading1;
        private RembyLoginControl rembyLoginControl1;
        private GrayButton buttonOCR1;
        private GrayButton buttonCopy1;
        private GrayButton buttonSave1;
        private ExtendedRoundedTextBox textBoxSource;
        private TagsCombo textBoxTags;
    }
}