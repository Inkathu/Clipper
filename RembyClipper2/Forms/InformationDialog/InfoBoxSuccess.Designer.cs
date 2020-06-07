namespace RembyClipper2.Forms.InformationDialog
{
    partial class InfoBoxSuccess
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
            this.crossPictureBox = new System.Windows.Forms.PictureBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.grayPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grayPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Size = new System.Drawing.Size(240, 109);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crossPictureBox);
            this.panel1.Controls.Add(this.messageLabel);
            this.panel1.Size = new System.Drawing.Size(238, 106);
            this.panel1.Controls.SetChildIndex(this.grayPanel2, 0);
            this.panel1.Controls.SetChildIndex(this.messageLabel, 0);
            this.panel1.Controls.SetChildIndex(this.crossPictureBox, 0);
            // 
            // countDownLabel
            // 
            this.countDownLabel.Location = new System.Drawing.Point(182, 5);
            // 
            // grayPanel2
            // 
            this.grayPanel2.Size = new System.Drawing.Size(236, 27);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(222, 3);
            // 
            // captionLabel
            // 
            this.captionLabel.Size = new System.Drawing.Size(108, 16);
            this.captionLabel.Text = "InfoBoxSuccess";
            // 
            // crossPictureBox
            // 
            this.crossPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crossPictureBox.Image = global::RembyClipper2.Properties.Resources.tick1;
            this.crossPictureBox.Location = new System.Drawing.Point(7, 50);
            this.crossPictureBox.Name = "crossPictureBox";
            this.crossPictureBox.Size = new System.Drawing.Size(32, 32);
            this.crossPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.crossPictureBox.TabIndex = 2;
            this.crossPictureBox.TabStop = false;
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.ForeColor = System.Drawing.Color.Black;
            this.messageLabel.Location = new System.Drawing.Point(44, 32);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(191, 69);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "#message#";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoBoxSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 109);
            this.Name = "InfoBoxSuccess";
            this.Text = "InfoBoxSuccess";
            this.grayPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grayPanel2.ResumeLayout(false);
            this.grayPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.PictureBox crossPictureBox;
        protected System.Windows.Forms.Label messageLabel;

    }
}