namespace RembyClipper2.Forms.InformationDialog
{
    partial class InfoBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grayPanel2 = new RembyClipper2.Base.GrayPanel();
            this.countDownLabel = new System.Windows.Forms.Label();
            this.closeButton = new RembyClipper2.Base.GrayButton();
            this.captionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grayPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grayPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.panel1);
            this.grayPanel1.DrawRoundedBorder = true;
            this.grayPanel1.Location = new System.Drawing.Point(0, 0);
            this.grayPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = true;
            this.grayPanel1.Size = new System.Drawing.Size(404, 151);
            this.grayPanel1.TabIndex = 0;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.grayPanel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(403, 148);
            this.panel1.TabIndex = 2;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            // 
            // grayPanel2
            // 
            this.grayPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grayPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grayPanel2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.grayPanel2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel2.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel2.Controls.Add(this.countDownLabel);
            this.grayPanel2.Controls.Add(this.closeButton);
            this.grayPanel2.Controls.Add(this.captionLabel);
            this.grayPanel2.Controls.Add(this.pictureBox1);
            this.grayPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.grayPanel2.DrawRoundedBorder = true;
            this.grayPanel2.Location = new System.Drawing.Point(2, 0);
            this.grayPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.grayPanel2.Name = "grayPanel2";
            this.grayPanel2.RoundingRadius = 10;
            this.grayPanel2.ShowBorder = false;
            this.grayPanel2.Size = new System.Drawing.Size(401, 27);
            this.grayPanel2.TabIndex = 0;
            this.grayPanel2.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.grayPanel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.grayPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            // 
            // countDownLabel
            // 
            this.countDownLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countDownLabel.BackColor = System.Drawing.Color.Transparent;
            this.countDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countDownLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.countDownLabel.Location = new System.Drawing.Point(335, 6);
            this.countDownLabel.Margin = new System.Windows.Forms.Padding(0);
            this.countDownLabel.Name = "countDownLabel";
            this.countDownLabel.Size = new System.Drawing.Size(32, 16);
            this.countDownLabel.TabIndex = 0;
            this.countDownLabel.Text = "0";
            this.countDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.countDownLabel.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.closeButton.ButtonCaption = "X";
            this.closeButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.closeButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.closeButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.FontColor = System.Drawing.Color.Black;
            this.closeButton.Image = null;
            this.closeButton.ImageSize = new System.Drawing.Size(20, 20);
            this.closeButton.Location = new System.Drawing.Point(374, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.RoundingRadius = 10;
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.closeButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CrossButtonClick);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.BackColor = System.Drawing.Color.Transparent;
            this.captionLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.Location = new System.Drawing.Point(41, 5);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(57, 16);
            this.captionLabel.TabIndex = 1;
            this.captionLabel.Text = "Caption";
            this.captionLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.captionLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::RembyClipper2.NewDesign.clipper_icon;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            // 
            // InfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(600, 488);
            this.Controls.Add(this.grayPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InfoBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "InfoBox";
            this.TopMost = true;
            this.grayPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grayPanel2.ResumeLayout(false);
            this.grayPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Base.GrayPanel grayPanel1;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label countDownLabel;
        protected Base.GrayPanel grayPanel2;
        protected Base.GrayButton closeButton;
        protected System.Windows.Forms.Label captionLabel;
        protected System.Windows.Forms.PictureBox pictureBox1;

    }
}