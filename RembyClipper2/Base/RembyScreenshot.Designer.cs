namespace RembyClipper2.Base
{
    partial class RembyScreenshot
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new RembyClipper2.Base.GrayButton();
            this.btnAddToRemby = new RembyClipper2.Base.BlueButton();
            this.buttonSave1 = new System.Windows.Forms.PictureBox();
            this.buttonCopy1 = new System.Windows.Forms.PictureBox();
            this.buttonOCR1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxTags = new RembyClipper2.Base.AutoCompleteTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.pictureBoxError = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxScreenshot = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSave1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCopy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOCR1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnAddToRemby);
            this.panel1.Controls.Add(this.buttonSave1);
            this.panel1.Controls.Add(this.buttonCopy1);
            this.panel1.Controls.Add(this.buttonOCR1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textBoxTags);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.pictureBoxError);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.textBoxSource);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBoxScreenshot);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 417);
            this.panel1.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnClose.ButtonCaption = "*Cancel";
            this.btnClose.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnClose.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.FontColor = System.Drawing.Color.Black;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = null;
            this.btnClose.ImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(370, 379);
            this.btnClose.Name = "btnClose";
            this.btnClose.RoundingRadius = 10;
            this.btnClose.Size = new System.Drawing.Size(77, 30);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "*Cancel";
            this.btnClose.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCloseClicked);
            // 
            // btnAddToRemby
            // 
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
            this.btnAddToRemby.Location = new System.Drawing.Point(251, 379);
            this.btnAddToRemby.Name = "btnAddToRemby";
            this.btnAddToRemby.RoundingRadius = 10;
            this.btnAddToRemby.Size = new System.Drawing.Size(113, 30);
            this.btnAddToRemby.TabIndex = 40;
            this.btnAddToRemby.Text = "*Add To Remby";
            this.btnAddToRemby.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.btnAddToRemby.UseVisualStyleBackColor = false;
            this.btnAddToRemby.Click += new System.EventHandler(this.btnAddToRembyClicked);
            // 
            // buttonSave1
            // 
            this.buttonSave1.Image = global::RembyClipper2.NewDesign.btn_icon_save;
            this.buttonSave1.Location = new System.Drawing.Point(6, 379);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(29, 26);
            this.buttonSave1.TabIndex = 39;
            this.buttonSave1.TabStop = false;
            this.buttonSave1.Click += new System.EventHandler(this.buttonSave1_Click);
            // 
            // buttonCopy1
            // 
            this.buttonCopy1.Image = global::RembyClipper2.NewDesign.btn_icon_copy;
            this.buttonCopy1.Location = new System.Drawing.Point(44, 379);
            this.buttonCopy1.Name = "buttonCopy1";
            this.buttonCopy1.Size = new System.Drawing.Size(29, 26);
            this.buttonCopy1.TabIndex = 38;
            this.buttonCopy1.TabStop = false;
            this.buttonCopy1.Click += new System.EventHandler(this.buttonCopy1_Click);
            // 
            // buttonOCR1
            // 
            this.buttonOCR1.Image = global::RembyClipper2.NewDesign.btn_ocr;
            this.buttonOCR1.Location = new System.Drawing.Point(80, 379);
            this.buttonOCR1.Name = "buttonOCR1";
            this.buttonOCR1.Size = new System.Drawing.Size(44, 26);
            this.buttonOCR1.TabIndex = 37;
            this.buttonOCR1.TabStop = false;
            this.buttonOCR1.Click += new System.EventHandler(this.buttonOCR1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RembyClipper2.Properties.Resources.toolbar;
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 38);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBoxScreenshot_Click);
            // 
            // textBoxTags
            // 
            this.textBoxTags.CustomPosition = new System.Drawing.Point(0, 0);
            this.textBoxTags.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTags.ForeColor = System.Drawing.Color.Black;
            this.textBoxTags.Location = new System.Drawing.Point(266, 344);
            this.textBoxTags.Multiline = false;
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(184, 22);
            this.textBoxTags.TabIndex = 17;
            this.textBoxTags.Text = "Remby,";
            this.textBoxTags.Values = null;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(263, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tags";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(192)))));
            this.labelError.Location = new System.Drawing.Point(49, 61);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(35, 13);
            this.labelError.TabIndex = 24;
            this.labelError.Text = "label2";
            this.labelError.Visible = false;
            // 
            // pictureBoxError
            // 
            this.pictureBoxError.Image = global::RembyClipper2.Properties.Resources.ErrorBG;
            this.pictureBoxError.Location = new System.Drawing.Point(1, 41);
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.Size = new System.Drawing.Size(449, 52);
            this.pictureBoxError.TabIndex = 23;
            this.pictureBoxError.TabStop = false;
            this.pictureBoxError.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::RembyClipper2.Properties.Resources.FullView;
            this.pictureBox2.Location = new System.Drawing.Point(113, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(224, 39);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBoxScreenshot_Click);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSource.ForeColor = System.Drawing.Color.Black;
            this.textBoxSource.Location = new System.Drawing.Point(6, 344);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(254, 22);
            this.textBoxSource.TabIndex = 16;
            this.textBoxSource.Text = "title of the window";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Source";
            // 
            // pictureBoxScreenshot
            // 
            this.pictureBoxScreenshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxScreenshot.Location = new System.Drawing.Point(3, 41);
            this.pictureBoxScreenshot.Name = "pictureBoxScreenshot";
            this.pictureBoxScreenshot.Size = new System.Drawing.Size(444, 276);
            this.pictureBoxScreenshot.TabIndex = 14;
            this.pictureBoxScreenshot.TabStop = false;
            this.pictureBoxScreenshot.Click += new System.EventHandler(this.pictureBoxScreenshot_Click);
            this.pictureBoxScreenshot.MouseEnter += new System.EventHandler(this.pictureBoxScreenshot_MouseEnter);
            this.pictureBoxScreenshot.MouseLeave += new System.EventHandler(this.pictureBoxScreenshot_MouseLeave);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG Files|*.png";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Remby - Save screenshot";
            // 
            // RembyScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(473, 426);
            this.Name = "RembyScreenshot";
            this.Size = new System.Drawing.Size(473, 426);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSave1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCopy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOCR1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxScreenshot;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBoxError;
        private System.Windows.Forms.Label labelError;
        private RembyClipper2.Base.AutoCompleteTextBox textBoxTags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox buttonOCR1;
        private System.Windows.Forms.PictureBox buttonSave1;
        private System.Windows.Forms.PictureBox buttonCopy1;
        public GrayButton btnClose;
        public BlueButton btnAddToRemby;
    }
}
