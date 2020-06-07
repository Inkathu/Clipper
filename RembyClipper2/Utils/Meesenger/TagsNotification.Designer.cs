namespace RembyClipper2.Utils.Meesenger
{
    partial class TagsNotification
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
            this.tagEditControl1 = new RembyClipper2.Base.TagEditControl();
            this.uploadButton = new RembyClipper2.Base.BlueButton();
            this.changeTagsLabel = new System.Windows.Forms.Label();
            this.cancelButton = new RembyClipper2.Base.GrayButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::RembyClipper2.Properties.Resources.page_edit;
            this.pictureBox.Location = new System.Drawing.Point(4, 72);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(41, 176);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tagEditControl1);
            this.panel2.Controls.Add(this.uploadButton);
            this.panel2.Controls.Add(this.changeTagsLabel);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Size = new System.Drawing.Size(294, 176);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            this.panel2.Controls.SetChildIndex(this.cancelButton, 0);
            this.panel2.Controls.SetChildIndex(this.changeTagsLabel, 0);
            this.panel2.Controls.SetChildIndex(this.uploadButton, 0);
            this.panel2.Controls.SetChildIndex(this.label, 0);
            this.panel2.Controls.SetChildIndex(this.tagEditControl1, 0);
            this.panel2.Controls.SetChildIndex(this.timerLabel, 0);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(7, 131);
            this.label.Size = new System.Drawing.Size(272, 10);
            this.label.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(280, 4);
            // 
            // timerLabel
            // 
            this.timerLabel.Location = new System.Drawing.Point(279, 158);
            // 
            // tagEditControl1
            // 
            this.tagEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagEditControl1.AutoSize = true;
            this.tagEditControl1.BackColor = System.Drawing.Color.Transparent;
            this.tagEditControl1.Location = new System.Drawing.Point(10, 26);
            this.tagEditControl1.Name = "tagEditControl1";
            this.tagEditControl1.Size = new System.Drawing.Size(270, 102);
            this.tagEditControl1.TabIndex = 0;
            this.tagEditControl1.CustomGotFocus += new System.EventHandler(this.tagTextBox_CustomGotFocus);
            this.tagEditControl1.CustomMouseDown += new System.Windows.Forms.MouseEventHandler(this.tagEditControl1_CustomMouseDown);
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
            this.uploadButton.Location = new System.Drawing.Point(132, 144);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.RoundingRadius = 10;
            this.uploadButton.Size = new System.Drawing.Size(65, 23);
            this.uploadButton.TabIndex = 1;
            this.uploadButton.Text = "Upload";
            this.uploadButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // changeTagsLabel
            // 
            this.changeTagsLabel.AutoSize = true;
            this.changeTagsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.changeTagsLabel.Location = new System.Drawing.Point(10, 7);
            this.changeTagsLabel.Name = "changeTagsLabel";
            this.changeTagsLabel.Size = new System.Drawing.Size(102, 13);
            this.changeTagsLabel.TabIndex = 7;
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
            this.cancelButton.Location = new System.Drawing.Point(210, 144);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RoundingRadius = 10;
            this.cancelButton.Size = new System.Drawing.Size(65, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TagsNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Image = global::RembyClipper2.Properties.Resources.page_edit;
            this.Name = "TagsNotification";
            this.Size = new System.Drawing.Size(335, 176);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.TagEditControl tagEditControl1;
        private Base.BlueButton uploadButton;
        private System.Windows.Forms.Label changeTagsLabel;
        private Base.GrayButton cancelButton;
    }
}
