namespace RembyClipper2.Base
{
    partial class FirstUserExperience
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstUserExperience));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dontShowCheckBox = new System.Windows.Forms.CheckBox();
            this.termsLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.title2Label = new System.Windows.Forms.Label();
            this.title3label = new System.Windows.Forms.Label();
            this.buttonOrange1 = new RembyClipper2.Base.BlueButton();
            this.buttonBlack1 = new RembyClipper2.Base.GrayButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::RembyClipper2.Properties.Resources.editor_video;
            this.pictureBox2.Location = new System.Drawing.Point(10, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 51);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // dontShowCheckBox
            // 
            this.dontShowCheckBox.AutoSize = true;
            this.dontShowCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.dontShowCheckBox.Checked = true;
            this.dontShowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dontShowCheckBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dontShowCheckBox.ForeColor = System.Drawing.Color.Black;
            this.dontShowCheckBox.Location = new System.Drawing.Point(12, 156);
            this.dontShowCheckBox.Name = "dontShowCheckBox";
            this.dontShowCheckBox.Size = new System.Drawing.Size(184, 18);
            this.dontShowCheckBox.TabIndex = 7;
            this.dontShowCheckBox.Text = "Don\'t show this screen again";
            this.dontShowCheckBox.UseVisualStyleBackColor = false;
            // 
            // termsLabel
            // 
            this.termsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.termsLabel.BackColor = System.Drawing.Color.Transparent;
            this.termsLabel.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termsLabel.ForeColor = System.Drawing.Color.Black;
            this.termsLabel.Location = new System.Drawing.Point(1, 233);
            this.termsLabel.Name = "termsLabel";
            this.termsLabel.Size = new System.Drawing.Size(411, 60);
            this.termsLabel.TabIndex = 30;
            this.termsLabel.Text = resources.GetString("termsLabel.Text");
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(7, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(395, 32);
            this.titleLabel.TabIndex = 33;
            this.titleLabel.Text = "To add your video to Remby, You need to upload it to YouTube";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // title2Label
            // 
            this.title2Label.BackColor = System.Drawing.Color.Transparent;
            this.title2Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title2Label.ForeColor = System.Drawing.Color.Black;
            this.title2Label.Location = new System.Drawing.Point(9, 48);
            this.title2Label.Name = "title2Label";
            this.title2Label.Size = new System.Drawing.Size(393, 48);
            this.title2Label.TabIndex = 34;
            this.title2Label.Text = "In the next step, we will ask you to log in to your existing YouTube account or t" +
    "o create a new one.";
            // 
            // title3label
            // 
            this.title3label.BackColor = System.Drawing.Color.Transparent;
            this.title3label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title3label.ForeColor = System.Drawing.Color.Black;
            this.title3label.Location = new System.Drawing.Point(61, 99);
            this.title3label.Name = "title3label";
            this.title3label.Size = new System.Drawing.Size(341, 48);
            this.title3label.TabIndex = 35;
            this.title3label.Text = "After uploading your video it will be available in My Content Panelon the web. Fr" +
    "om there you can easily add it to your pages.";
            // 
            // buttonOrange1
            // 
            this.buttonOrange1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.buttonOrange1.ButtonCaption = "*Continue";
            this.buttonOrange1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.buttonOrange1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.buttonOrange1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonOrange1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.buttonOrange1.FontColor = System.Drawing.Color.White;
            this.buttonOrange1.Image = null;
            this.buttonOrange1.ImageSize = new System.Drawing.Size(20, 20);
            this.buttonOrange1.Location = new System.Drawing.Point(194, 190);
            this.buttonOrange1.Name = "buttonOrange1";
            this.buttonOrange1.RoundingRadius = 10;
            this.buttonOrange1.Size = new System.Drawing.Size(101, 32);
            this.buttonOrange1.TabIndex = 36;
            this.buttonOrange1.Text = "*Continue";
            this.buttonOrange1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.buttonOrange1.UseVisualStyleBackColor = true;
            this.buttonOrange1.Click += new System.EventHandler(this.buttonOrange1_Click);
            // 
            // buttonBlack1
            // 
            this.buttonBlack1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonBlack1.ButtonCaption = "*Cancel";
            this.buttonBlack1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonBlack1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonBlack1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonBlack1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBlack1.FontColor = System.Drawing.Color.Black;
            this.buttonBlack1.Image = null;
            this.buttonBlack1.ImageSize = new System.Drawing.Size(20, 20);
            this.buttonBlack1.Location = new System.Drawing.Point(317, 191);
            this.buttonBlack1.Name = "buttonBlack1";
            this.buttonBlack1.RoundingRadius = 10;
            this.buttonBlack1.Size = new System.Drawing.Size(85, 30);
            this.buttonBlack1.TabIndex = 37;
            this.buttonBlack1.Text = "*Cancel";
            this.buttonBlack1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonBlack1.UseVisualStyleBackColor = true;
            this.buttonBlack1.Click += new System.EventHandler(this.buttonBlack1_Click);
            // 
            // FirstUserExperience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 299);
            this.Controls.Add(this.buttonBlack1);
            this.Controls.Add(this.buttonOrange1);
            this.Controls.Add(this.title3label);
            this.Controls.Add(this.title2Label);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.termsLabel);
            this.Controls.Add(this.dontShowCheckBox);
            this.Controls.Add(this.pictureBox2);
            this.MinimumSize = new System.Drawing.Size(420, 327);
            this.Name = "FirstUserExperience";
            this.Text = "Remby screen video";
            this.Load += new System.EventHandler(this.FirstUserExperience_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox dontShowCheckBox;
        private System.Windows.Forms.Label termsLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label title2Label;
        private System.Windows.Forms.Label title3label;
        private BlueButton buttonOrange1;
        private GrayButton buttonBlack1;
    }
}