namespace RembyClipper2.Forms
{
    partial class OneClickScreenShotWarning
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.grayPanel2 = new RembyClipper2.Base.GrayPanel();
            this.dontShowAgainCB = new System.Windows.Forms.CheckBox();
            this.reselectButton = new RembyClipper2.Base.BlueButton();
            this.closeButton = new RembyClipper2.Base.GrayButton();
            this.grayPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grayPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Controls.Add(this.pictureBox1);
            this.grayPanel1.Controls.Add(this.textLabel);
            this.grayPanel1.Controls.Add(this.titleLabel);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel1.Location = new System.Drawing.Point(0, 0);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 1;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(456, 163);
            this.grayPanel1.TabIndex = 0;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::RembyClipper2.Properties.Resources.RembyLogo;
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textLabel
            // 
            this.textLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLabel.BackColor = System.Drawing.Color.Transparent;
            this.textLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLabel.Location = new System.Drawing.Point(7, 64);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(441, 93);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "To select a specific area: \r\n1. Click and hold the mouse button in  the top left " +
    "corner of the area you want to select\r\n2. Drag to the bottom left corner of the " +
    "area\r\n3. Rlease the mouse button";
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(60, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(388, 42);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "You clicked once and Remby has taken a screenshot of the whole screen.";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grayPanel2
            // 
            this.grayPanel2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel2.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel2.Controls.Add(this.dontShowAgainCB);
            this.grayPanel2.Controls.Add(this.reselectButton);
            this.grayPanel2.Controls.Add(this.closeButton);
            this.grayPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel2.DrawRoundedBorder = false;
            this.grayPanel2.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel2.Location = new System.Drawing.Point(0, 163);
            this.grayPanel2.Name = "grayPanel2";
            this.grayPanel2.RoundingRadius = 10;
            this.grayPanel2.ShowBorder = false;
            this.grayPanel2.Size = new System.Drawing.Size(456, 41);
            this.grayPanel2.TabIndex = 0;
            this.grayPanel2.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // dontShowAgainCB
            // 
            this.dontShowAgainCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dontShowAgainCB.AutoSize = true;
            this.dontShowAgainCB.BackColor = System.Drawing.Color.Transparent;
            this.dontShowAgainCB.Location = new System.Drawing.Point(12, 12);
            this.dontShowAgainCB.Name = "dontShowAgainCB";
            this.dontShowAgainCB.Size = new System.Drawing.Size(137, 17);
            this.dontShowAgainCB.TabIndex = 2;
            this.dontShowAgainCB.Text = " Do not show this again";
            this.dontShowAgainCB.UseVisualStyleBackColor = false;
            // 
            // reselectButton
            // 
            this.reselectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reselectButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.reselectButton.ButtonCaption = "Reselect";
            this.reselectButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.reselectButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.reselectButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.reselectButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.reselectButton.FontColor = System.Drawing.Color.White;
            this.reselectButton.Image = null;
            this.reselectButton.ImageSize = new System.Drawing.Size(20, 20);
            this.reselectButton.Location = new System.Drawing.Point(271, 7);
            this.reselectButton.Name = "reselectButton";
            this.reselectButton.RoundingRadius = 10;
            this.reselectButton.Size = new System.Drawing.Size(84, 27);
            this.reselectButton.TabIndex = 1;
            this.reselectButton.Text = "Reselect";
            this.reselectButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.reselectButton.UseVisualStyleBackColor = true;
            this.reselectButton.Click += new System.EventHandler(this.reselectButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.closeButton.ButtonCaption = "Close";
            this.closeButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.closeButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.closeButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.FontColor = System.Drawing.Color.Black;
            this.closeButton.Image = null;
            this.closeButton.ImageSize = new System.Drawing.Size(20, 20);
            this.closeButton.Location = new System.Drawing.Point(364, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.RoundingRadius = 10;
            this.closeButton.Size = new System.Drawing.Size(84, 27);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // OneClickScreenShotWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 204);
            this.Controls.Add(this.grayPanel1);
            this.Controls.Add(this.grayPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OneClickScreenShotWarning";
            this.ShowInTaskbar = false;
            this.Text = "#Attention#";
            this.TopMost = true;
            this.grayPanel1.ResumeLayout(false);
            this.grayPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grayPanel2.ResumeLayout(false);
            this.grayPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.GrayPanel grayPanel1;
        private Base.GrayPanel grayPanel2;
        private System.Windows.Forms.CheckBox dontShowAgainCB;
        private Base.BlueButton reselectButton;
        private Base.GrayButton closeButton;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}