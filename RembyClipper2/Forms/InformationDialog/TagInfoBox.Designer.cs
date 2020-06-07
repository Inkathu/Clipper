namespace RembyClipper2.Forms.InformationDialog
{
    partial class TagInfoBox
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
            this.tagTextBox = new RembyClipper2.Base.AutoCompleteTextBox();
            this.okButton = new RembyClipper2.Base.GrayButton();
            this.grayPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grayPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Size = new System.Drawing.Size(326, 142);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tagTextBox);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.changeTagsLabel);
            this.panel1.Size = new System.Drawing.Size(324, 139);
            this.panel1.Controls.SetChildIndex(this.changeTagsLabel, 0);
            this.panel1.Controls.SetChildIndex(this.okButton, 0);
            this.panel1.Controls.SetChildIndex(this.tagTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.grayPanel2, 0);
            // 
            // countDownLabel
            // 
            this.countDownLabel.Location = new System.Drawing.Point(246, 0);
            // 
            // grayPanel2
            // 
            this.grayPanel2.Size = new System.Drawing.Size(322, 41);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(297, 11);
            // 
            // captionLabel
            // 
            this.captionLabel.Size = new System.Drawing.Size(80, 16);
            this.captionLabel.Text = "TagInfoBox";
            // 
            // changeTagsLabel
            // 
            this.changeTagsLabel.AutoSize = true;
            this.changeTagsLabel.Location = new System.Drawing.Point(10, 52);
            this.changeTagsLabel.Name = "changeTagsLabel";
            this.changeTagsLabel.Size = new System.Drawing.Size(70, 13);
            this.changeTagsLabel.TabIndex = 1;
            this.changeTagsLabel.Text = "Change tags:";
            // 
            // tagTextBox
            // 
            this.tagTextBox.CustomPosition = new System.Drawing.Point(0, 0);
            this.tagTextBox.InnerText = "";
            this.tagTextBox.Location = new System.Drawing.Point(10, 74);
            this.tagTextBox.MinimumSize = new System.Drawing.Size(0, 20);
            this.tagTextBox.Multiline = false;
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.PasswordChar = '\0';
            this.tagTextBox.SelectionLength = 0;
            this.tagTextBox.SelectionStart = 0;
            this.tagTextBox.Size = new System.Drawing.Size(302, 20);
            this.tagTextBox.TabIndex = 3;
            this.tagTextBox.TextLength = 32767;
            this.tagTextBox.Values = null;
            // 
            // okButton
            // 
            this.okButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.okButton.ButtonCaption = "Ok";
            this.okButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.okButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.okButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okButton.FontColor = System.Drawing.Color.Black;
            this.okButton.Image = null;
            this.okButton.ImageSize = new System.Drawing.Size(20, 20);
            this.okButton.Location = new System.Drawing.Point(247, 107);
            this.okButton.Name = "okButton";
            this.okButton.RoundingRadius = 10;
            this.okButton.Size = new System.Drawing.Size(65, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // TagInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 142);
            this.Name = "TagInfoBox";
            this.Text = "TagInfoBox";
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
        private Base.AutoCompleteTextBox tagTextBox;
        private Base.GrayButton okButton;
    }
}