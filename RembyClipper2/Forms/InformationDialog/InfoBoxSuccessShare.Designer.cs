namespace RembyClipper2.Forms.InformationDialog
{
    partial class InfoBoxSuccessShare
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.googlePictureBox = new System.Windows.Forms.PictureBox();
            this.facebookPictureBox = new System.Windows.Forms.PictureBox();
            this.twitterPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.crossPictureBox)).BeginInit();
            this.grayPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grayPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.googlePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // crossPictureBox
            // 
            this.crossPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crossPictureBox.Location = new System.Drawing.Point(7, 41);
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageLabel.Location = new System.Drawing.Point(44, 31);
            this.messageLabel.Size = new System.Drawing.Size(188, 52);
            // 
            // grayPanel1
            // 
            this.grayPanel1.Size = new System.Drawing.Size(240, 140);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.twitterPictureBox);
            this.panel1.Controls.Add(this.googlePictureBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.facebookPictureBox);
            this.panel1.Size = new System.Drawing.Size(238, 137);
            this.panel1.Controls.SetChildIndex(this.facebookPictureBox, 0);
            this.panel1.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.Controls.SetChildIndex(this.googlePictureBox, 0);
            this.panel1.Controls.SetChildIndex(this.twitterPictureBox, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.messageLabel, 0);
            this.panel1.Controls.SetChildIndex(this.grayPanel2, 0);
            this.panel1.Controls.SetChildIndex(this.crossPictureBox, 0);
            // 
            // countDownLabel
            // 
            this.countDownLabel.Location = new System.Drawing.Point(173, 5);
            // 
            // grayPanel2
            // 
            this.grayPanel2.Size = new System.Drawing.Size(236, 27);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(209, 3);
            // 
            // captionLabel
            // 
            this.captionLabel.Size = new System.Drawing.Size(146, 16);
            this.captionLabel.Text = "InfoBoxSuccessShare";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(77, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Copy link:";
            this.label1.Click += new System.EventHandler(this.googlePictureBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Share to:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(47, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 1);
            this.panel2.TabIndex = 6;
            // 
            // googlePictureBox
            // 
            this.googlePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.googlePictureBox.Image = global::RembyClipper2.NewDesign.share_icon_google_s;
            this.googlePictureBox.Location = new System.Drawing.Point(139, 86);
            this.googlePictureBox.Name = "googlePictureBox";
            this.googlePictureBox.Size = new System.Drawing.Size(18, 18);
            this.googlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.googlePictureBox.TabIndex = 7;
            this.googlePictureBox.TabStop = false;
            this.googlePictureBox.Click += new System.EventHandler(this.googlePictureBox_Click);
            // 
            // facebookPictureBox
            // 
            this.facebookPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facebookPictureBox.Image = global::RembyClipper2.NewDesign.share_icon_facebook_s;
            this.facebookPictureBox.Location = new System.Drawing.Point(139, 114);
            this.facebookPictureBox.Name = "facebookPictureBox";
            this.facebookPictureBox.Size = new System.Drawing.Size(18, 18);
            this.facebookPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.facebookPictureBox.TabIndex = 8;
            this.facebookPictureBox.TabStop = false;
            this.facebookPictureBox.Click += new System.EventHandler(this.facebookPictureBox_Click);
            // 
            // twitterPictureBox
            // 
            this.twitterPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.twitterPictureBox.Image = global::RembyClipper2.NewDesign.share_icon_twitter_s;
            this.twitterPictureBox.Location = new System.Drawing.Point(168, 114);
            this.twitterPictureBox.Name = "twitterPictureBox";
            this.twitterPictureBox.Size = new System.Drawing.Size(18, 18);
            this.twitterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.twitterPictureBox.TabIndex = 9;
            this.twitterPictureBox.TabStop = false;
            this.twitterPictureBox.Click += new System.EventHandler(this.twitterPictureBox_Click);
            // 
            // InfoBoxSuccessShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 140);
            this.Name = "InfoBoxSuccessShare";
            this.Text = "InfoBoxSuccessShare";
            ((System.ComponentModel.ISupportInitialize)(this.crossPictureBox)).EndInit();
            this.grayPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grayPanel2.ResumeLayout(false);
            this.grayPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.googlePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox twitterPictureBox;
        private System.Windows.Forms.PictureBox googlePictureBox;
        private System.Windows.Forms.PictureBox facebookPictureBox;
    }
}