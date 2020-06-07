namespace RembyClipper2.Forms.InformationDialog
{
    partial class InfoBoxTag
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
            this.changeTagsLabel = new System.Windows.Forms.Label();
            this.cancelButton = new RembyClipper2.Base.GrayButton();
            this.uploadButton = new RembyClipper2.Base.BlueButton();
            this.tagEditControl1 = new RembyClipper2.Base.TagEditControl();
            this.grayPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grayPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Size = new System.Drawing.Size(288, 149);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tagEditControl1);
            this.panel1.Controls.Add(this.uploadButton);
            this.panel1.Controls.Add(this.changeTagsLabel);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Size = new System.Drawing.Size(286, 146);
            this.panel1.Controls.SetChildIndex(this.cancelButton, 0);
            this.panel1.Controls.SetChildIndex(this.changeTagsLabel, 0);
            this.panel1.Controls.SetChildIndex(this.uploadButton, 0);
            this.panel1.Controls.SetChildIndex(this.tagEditControl1, 0);
            this.panel1.Controls.SetChildIndex(this.grayPanel2, 0);
            // 
            // countDownLabel
            // 
            this.countDownLabel.Location = new System.Drawing.Point(220, 5);
            // 
            // grayPanel2
            // 
            this.grayPanel2.Size = new System.Drawing.Size(284, 27);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(259, 3);
            // 
            // captionLabel
            // 
            this.captionLabel.Size = new System.Drawing.Size(80, 16);
            this.captionLabel.Text = "InfoBoxTag";
            // 
            // changeTagsLabel
            // 
            this.changeTagsLabel.AutoSize = true;
            this.changeTagsLabel.Location = new System.Drawing.Point(8, 37);
            this.changeTagsLabel.Name = "changeTagsLabel";
            this.changeTagsLabel.Size = new System.Drawing.Size(102, 13);
            this.changeTagsLabel.TabIndex = 1;
            this.changeTagsLabel.Text = "Edit to change tags:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cancelButton.ButtonCaption = "Cancel";
            this.cancelButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.cancelButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cancelButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.FontColor = System.Drawing.Color.Black;
            this.cancelButton.Image = null;
            this.cancelButton.ImageSize = new System.Drawing.Size(20, 20);
            this.cancelButton.Location = new System.Drawing.Point(213, 115);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RoundingRadius = 10;
            this.cancelButton.Size = new System.Drawing.Size(65, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.uploadButton.ButtonCaption = "Upload";
            this.uploadButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.uploadButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.uploadButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.uploadButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.uploadButton.FontColor = System.Drawing.Color.White;
            this.uploadButton.Image = null;
            this.uploadButton.ImageSize = new System.Drawing.Size(20, 20);
            this.uploadButton.Location = new System.Drawing.Point(135, 115);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.RoundingRadius = 10;
            this.uploadButton.Size = new System.Drawing.Size(65, 23);
            this.uploadButton.TabIndex = 5;
            this.uploadButton.Text = "Upload";
            this.uploadButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // tagEditControl1
            // 
            this.tagEditControl1.AutoSize = true;
            this.tagEditControl1.BackColor = System.Drawing.Color.Transparent;
            this.tagEditControl1.Location = new System.Drawing.Point(8, 56);
            this.tagEditControl1.Name = "tagEditControl1";
            this.tagEditControl1.Size = new System.Drawing.Size(270, 50);
            this.tagEditControl1.TabIndex = 6;
            // 
            // InfoBoxTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 149);
            this.Name = "InfoBoxTag";
            this.Text = "InfoBoxTag";
            this.grayPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grayPanel2.ResumeLayout(false);
            this.grayPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label changeTagsLabel;
        private Base.GrayButton cancelButton;
        private Base.BlueButton uploadButton;
        private Base.TagEditControl tagEditControl1;
    }
}