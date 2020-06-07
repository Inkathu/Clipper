namespace RembyClipper2.Base
{
    partial class RembyYouTubeControl
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
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.Location = new System.Drawing.Point(57, 29);
            this.label1.Size = new System.Drawing.Size(210, 29);
            this.label1.Text = "Please log into your YouTube account";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(7, 139);
            this.checkBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 240);
            this.label4.Size = new System.Drawing.Size(159, 13);
            this.label4.Text = "Don\'t have a YouTube account?";
            // 
            // signupLabel
            // 
            this.signupLabel.Location = new System.Drawing.Point(6, 255);
            this.signupLabel.Size = new System.Drawing.Size(181, 13);
            this.signupLabel.Text = "Go to YouTube to create an account";
            this.signupLabel.Click += new System.EventHandler(this.SignUpLabelClick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 62);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 100);
            // 
            // pictureBoxError
            // 
            this.pictureBoxError.Location = new System.Drawing.Point(1, 0);
            this.pictureBoxError.Size = new System.Drawing.Size(266, 56);
            // 
            // labelError
            // 
            this.labelError.Location = new System.Drawing.Point(50, 19);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(238, 18);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(151, 206);
            this.closeButton.Size = new System.Drawing.Size(101, 30);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(18, 206);
            this.loginButton.Size = new System.Drawing.Size(101, 30);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxUsername.Location = new System.Drawing.Point(6, 78);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPassword.Location = new System.Drawing.Point(7, 116);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 48);
            this.label6.TabIndex = 14;
            this.label6.Text = "We will keep you logged in until you quit RembyCollector.\r\nAnd we will not store y" +
    "our password. Promised.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::RembyClipper2.Properties.Resources.youtube_logo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(1, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 34);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 32);
            this.label5.TabIndex = 44;
            this.label5.Text = "As a free user, your videos will be stored on YouTube";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RembyYouTubeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Name = "RembyYouTubeControl";
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.loginButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.textBoxUsername, 0);
            this.Controls.SetChildIndex(this.textBoxPassword, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.labelError, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.signupLabel, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.pictureBoxError, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
    }
}
