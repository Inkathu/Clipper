namespace RembyClipper2.Utils.Meesenger
{
    partial class SuccessShareNotification
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
            this.label11 = new System.Windows.Forms.Label();
            this.shareToLabel = new System.Windows.Forms.Label();
            this.twitterPictureBox = new System.Windows.Forms.PictureBox();
            this.googlePictureBox = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.facebookPictureBox = new System.Windows.Forms.PictureBox();
            this.link = new System.Windows.Forms.LinkLabel();
            this.copyButton = new RembyClipper2.Base.GrayButton();
            this.availableAtLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.googlePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::RembyClipper2.Properties.Resources.tick1;
            this.pictureBox.Location = new System.Drawing.Point(4, 41);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(41, 115);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.availableAtLabel);
            this.panel2.Controls.Add(this.copyButton);
            this.panel2.Controls.Add(this.link);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.shareToLabel);
            this.panel2.Controls.Add(this.twitterPictureBox);
            this.panel2.Controls.Add(this.googlePictureBox);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.facebookPictureBox);
            this.panel2.Size = new System.Drawing.Size(318, 115);
            this.panel2.Controls.SetChildIndex(this.facebookPictureBox, 0);
            this.panel2.Controls.SetChildIndex(this.panel3, 0);
            this.panel2.Controls.SetChildIndex(this.googlePictureBox, 0);
            this.panel2.Controls.SetChildIndex(this.twitterPictureBox, 0);
            this.panel2.Controls.SetChildIndex(this.shareToLabel, 0);
            this.panel2.Controls.SetChildIndex(this.label11, 0);
            this.panel2.Controls.SetChildIndex(this.link, 0);
            this.panel2.Controls.SetChildIndex(this.copyButton, 0);
            this.panel2.Controls.SetChildIndex(this.availableAtLabel, 0);
            this.panel2.Controls.SetChildIndex(this.label, 0);
            this.panel2.Controls.SetChildIndex(this.timerLabel, 0);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(26, 1);
            this.label.Size = new System.Drawing.Size(260, 39);
            // 
            // timerLabel
            // 
            this.timerLabel.Location = new System.Drawing.Point(304, 99);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(-4, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Copy link:";
            this.label11.Visible = false;
            this.label11.Click += new System.EventHandler(this.googlePictureBox_Click);
            // 
            // shareToLabel
            // 
            this.shareToLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.shareToLabel.AutoSize = true;
            this.shareToLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.shareToLabel.Location = new System.Drawing.Point(50, 94);
            this.shareToLabel.Name = "shareToLabel";
            this.shareToLabel.Size = new System.Drawing.Size(50, 13);
            this.shareToLabel.TabIndex = 11;
            this.shareToLabel.Text = "Share to:";
            // 
            // twitterPictureBox
            // 
            this.twitterPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.twitterPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.twitterPictureBox.Image = global::RembyClipper2.NewDesign.share_icon_twitter_s;
            this.twitterPictureBox.Location = new System.Drawing.Point(146, 91);
            this.twitterPictureBox.Name = "twitterPictureBox";
            this.twitterPictureBox.Size = new System.Drawing.Size(18, 18);
            this.twitterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.twitterPictureBox.TabIndex = 15;
            this.twitterPictureBox.TabStop = false;
            this.twitterPictureBox.Click += new System.EventHandler(this.twitterPictureBox_Click);
            // 
            // googlePictureBox
            // 
            this.googlePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.googlePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.googlePictureBox.Image = global::RembyClipper2.NewDesign.share_icon_google_s;
            this.googlePictureBox.Location = new System.Drawing.Point(170, 92);
            this.googlePictureBox.Name = "googlePictureBox";
            this.googlePictureBox.Size = new System.Drawing.Size(18, 18);
            this.googlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.googlePictureBox.TabIndex = 13;
            this.googlePictureBox.TabStop = false;
            this.googlePictureBox.Visible = false;
            this.googlePictureBox.Click += new System.EventHandler(this.googlePictureBox_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(25, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(243, 1);
            this.panel3.TabIndex = 12;
            // 
            // facebookPictureBox
            // 
            this.facebookPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.facebookPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facebookPictureBox.Image = global::RembyClipper2.NewDesign.share_icon_facebook_s;
            this.facebookPictureBox.Location = new System.Drawing.Point(117, 91);
            this.facebookPictureBox.Name = "facebookPictureBox";
            this.facebookPictureBox.Size = new System.Drawing.Size(18, 18);
            this.facebookPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.facebookPictureBox.TabIndex = 14;
            this.facebookPictureBox.TabStop = false;
            this.facebookPictureBox.Click += new System.EventHandler(this.facebookPictureBox_Click);
            // 
            // link
            // 
            this.link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.link.AutoEllipsis = true;
            this.link.Location = new System.Drawing.Point(26, 65);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(172, 13);
            this.link.TabIndex = 16;
            this.link.TabStop = true;
            this.link.Text = "link";
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.copyButton.ButtonCaption = "Copy";
            this.copyButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.copyButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.copyButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.copyButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyButton.FontColor = System.Drawing.Color.Black;
            this.copyButton.Image = null;
            this.copyButton.ImageSize = new System.Drawing.Size(20, 20);
            this.copyButton.Location = new System.Drawing.Point(218, 62);
            this.copyButton.Name = "copyButton";
            this.copyButton.RoundingRadius = 10;
            this.copyButton.Size = new System.Drawing.Size(50, 20);
            this.copyButton.TabIndex = 17;
            this.copyButton.Text = "Copy";
            this.copyButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.grayButton1_Click);
            // 
            // availableAtLabel
            // 
            this.availableAtLabel.AutoSize = true;
            this.availableAtLabel.Location = new System.Drawing.Point(25, 49);
            this.availableAtLabel.Name = "availableAtLabel";
            this.availableAtLabel.Size = new System.Drawing.Size(85, 13);
            this.availableAtLabel.TabIndex = 18;
            this.availableAtLabel.Text = "and available at:";
            // 
            // SuccessShareNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Image = global::RembyClipper2.Properties.Resources.tick1;
            this.Name = "SuccessShareNotification";
            this.Size = new System.Drawing.Size(359, 115);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.googlePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label shareToLabel;
        private System.Windows.Forms.PictureBox twitterPictureBox;
        private System.Windows.Forms.PictureBox googlePictureBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox facebookPictureBox;
        private System.Windows.Forms.LinkLabel link;
        private Base.GrayButton copyButton;
        private System.Windows.Forms.Label availableAtLabel;
    }
}
