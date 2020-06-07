using RembyClipper2.Base;
namespace RembyClipper2.Forms
{
    partial class FormQuicktext
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
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.tagEditControl1 = new RembyClipper2.Base.TagEditControl();
            this.btnClose = new RembyClipper2.Base.GrayButton();
            this.btnUpload = new RembyClipper2.Base.BlueButton();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grayPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.tagEditControl1);
            this.grayPanel1.Controls.Add(this.btnClose);
            this.grayPanel1.Controls.Add(this.btnUpload);
            this.grayPanel1.Controls.Add(this.label1);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel1.Location = new System.Drawing.Point(0, 263);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(467, 106);
            this.grayPanel1.TabIndex = 0;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // tagEditControl1
            // 
            this.tagEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagEditControl1.AutoSize = true;
            this.tagEditControl1.BackColor = System.Drawing.Color.Transparent;
            this.tagEditControl1.Location = new System.Drawing.Point(8, 19);
            this.tagEditControl1.Name = "tagEditControl1";
            this.tagEditControl1.Size = new System.Drawing.Size(451, 48);
            this.tagEditControl1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnClose.ButtonCaption = "*Close";
            this.btnClose.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnClose.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.FontColor = System.Drawing.Color.Black;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = null;
            this.btnClose.ImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(382, 73);
            this.btnClose.Name = "btnClose";
            this.btnClose.RoundingRadius = 10;
            this.btnClose.Size = new System.Drawing.Size(77, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "*Close";
            this.btnClose.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(136)))), ((int)(((byte)(213)))));
            this.btnUpload.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnUpload.ButtonCaption = "*Upload";
            this.btnUpload.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.btnUpload.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpload.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpload.FontColor = System.Drawing.Color.White;
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Image = null;
            this.btnUpload.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUpload.Location = new System.Drawing.Point(216, 73);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.RoundingRadius = 10;
            this.btnUpload.Size = new System.Drawing.Size(146, 28);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "*Upload";
            this.btnUpload.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.UploadButtonClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tags:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(467, 263);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBox1_ContentsResized);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichTextBox1KeyUp);
            // 
            // FormQuicktext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(467, 369);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.grayPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(475, 400);
            this.Name = "FormQuicktext";
            this.ShowInTaskbar = false;
            this.Text = "Text";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormQuicktext_FormClosed);
            this.Load += new System.EventHandler(this.FormQuicktext_Load);
            this.SizeChanged += new System.EventHandler(this.FormQuicktext_SizeChanged);
            this.grayPanel1.ResumeLayout(false);
            this.grayPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.RichTextBox richTextBox1;
        protected System.Windows.Forms.Label label1;
        public GrayButton btnClose;
        public BlueButton btnUpload;
        private Base.GrayPanel grayPanel1;
        private TagEditControl tagEditControl1;

    }
}