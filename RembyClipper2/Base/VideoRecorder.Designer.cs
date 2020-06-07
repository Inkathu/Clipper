namespace RembyClipper2.Base
{
    partial class VideoRecorder
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.buttonMute1 = new RembyClipper2.Base.GrayButton();
            this.startStopButton = new RembyClipper2.Base.BlueButton();
            this.cancelButton = new RembyClipper2.Base.GrayButton();
            this.buttonWebcam1 = new RembyClipper2.Base.GrayButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grayPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "640x480 px";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(71, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "00:00";
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.buttonMute1);
            this.grayPanel1.Controls.Add(this.startStopButton);
            this.grayPanel1.Controls.Add(this.cancelButton);
            this.grayPanel1.Controls.Add(this.buttonWebcam1);
            this.grayPanel1.Controls.Add(this.label2);
            this.grayPanel1.Controls.Add(this.label1);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.Location = new System.Drawing.Point(0, 0);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(470, 40);
            this.grayPanel1.TabIndex = 6;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // buttonMute1
            // 
            this.buttonMute1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMute1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonMute1.ButtonCaption = "";
            this.buttonMute1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonMute1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonMute1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonMute1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMute1.FontColor = System.Drawing.Color.Black;
            this.buttonMute1.Image = global::RembyClipper2.NewDesign.mute;
            this.buttonMute1.ImageSize = new System.Drawing.Size(29, 26);
            this.buttonMute1.Location = new System.Drawing.Point(315, 5);
            this.buttonMute1.Name = "buttonMute1";
            this.buttonMute1.RoundingRadius = 10;
            this.buttonMute1.Size = new System.Drawing.Size(30, 28);
            this.buttonMute1.TabIndex = 40;
            this.buttonMute1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonMute1.UseVisualStyleBackColor = true;
            this.buttonMute1.Click += new System.EventHandler(this.ButtonMute1Click);
            // 
            // startStopButton
            // 
            this.startStopButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startStopButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.startStopButton.ButtonCaption = "Start Recording";
            this.startStopButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.startStopButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.startStopButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.startStopButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.startStopButton.FontColor = System.Drawing.Color.White;
            this.startStopButton.Image = global::RembyClipper2.NewDesign.srart_btn;
            this.startStopButton.ImageSize = new System.Drawing.Size(15, 15);
            this.startStopButton.Location = new System.Drawing.Point(134, 5);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.RoundingRadius = 10;
            this.startStopButton.Size = new System.Drawing.Size(166, 29);
            this.startStopButton.TabIndex = 39;
            this.startStopButton.Text = "Start Recording";
            this.startStopButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cancelButton.ButtonCaption = "Cancel";
            this.cancelButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.cancelButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cancelButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.FontColor = System.Drawing.Color.Black;
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Image = null;
            this.cancelButton.ImageSize = new System.Drawing.Size(20, 20);
            this.cancelButton.Location = new System.Drawing.Point(385, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RoundingRadius = 10;
            this.cancelButton.Size = new System.Drawing.Size(77, 29);
            this.cancelButton.TabIndex = 37;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.buttonBlack1_Click);
            // 
            // buttonWebcam1
            // 
            this.buttonWebcam1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWebcam1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonWebcam1.ButtonCaption = "";
            this.buttonWebcam1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonWebcam1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonWebcam1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonWebcam1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonWebcam1.FontColor = System.Drawing.Color.Black;
            this.buttonWebcam1.Image = global::RembyClipper2.NewDesign.webcam;
            this.buttonWebcam1.ImageSize = new System.Drawing.Size(29, 26);
            this.buttonWebcam1.Location = new System.Drawing.Point(349, 5);
            this.buttonWebcam1.Name = "buttonWebcam1";
            this.buttonWebcam1.RoundingRadius = 10;
            this.buttonWebcam1.Size = new System.Drawing.Size(30, 28);
            this.buttonWebcam1.TabIndex = 41;
            this.buttonWebcam1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonWebcam1.UseVisualStyleBackColor = true;
            this.buttonWebcam1.Click += new System.EventHandler(this.ButtonWebcam1Click);
            // 
            // VideoRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grayPanel1);
            this.MinimumSize = new System.Drawing.Size(470, 40);
            this.Name = "VideoRecorder";
            this.Size = new System.Drawing.Size(470, 40);
            this.Click += new System.EventHandler(this.ButtonMute1Click);
            this.grayPanel1.ResumeLayout(false);
            this.grayPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private GrayPanel grayPanel1;
        public GrayButton buttonMute1;
        private GrayButton buttonWebcam1;
        private System.Windows.Forms.ToolTip toolTip1;
        public BlueButton startStopButton;
        public GrayButton cancelButton;
    }
}
