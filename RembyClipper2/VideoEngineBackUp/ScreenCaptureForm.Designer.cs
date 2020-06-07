namespace RembyClipper.Forms
{
    partial class ScreenCaptureForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenCaptureForm));
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.pictureBox321 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.videoRecorder1 = new RembyClipper2.Base.VideoRecorder();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.webcamSurface1 = new RembyClipper2.VideoEngine.WebcamSurface();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox321)).BeginInit();
            this.SuspendLayout();
            // 
            // timerStart
            // 
            this.timerStart.Interval = 1000;
            // 
            // pictureBox321
            // 
            this.pictureBox321.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox321.Image = global::RembyClipper2.Properties.Resources.C3;
            this.pictureBox321.Location = new System.Drawing.Point(219, 56);
            this.pictureBox321.Name = "pictureBox321";
            this.pictureBox321.Size = new System.Drawing.Size(115, 114);
            this.pictureBox321.TabIndex = 3;
            this.pictureBox321.TabStop = false;
            this.pictureBox321.Visible = false;
            // 
            // videoRecorder1
            // 
            this.videoRecorder1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("videoRecorder1.BackgroundImage")));
            this.videoRecorder1.BoundSize = "640x480 px";
            this.videoRecorder1.Duration = "00:00";
            this.videoRecorder1.Location = new System.Drawing.Point(50, 200);
            this.videoRecorder1.MaximumSize = new System.Drawing.Size(0, 46);
            this.videoRecorder1.MinimumSize = new System.Drawing.Size(449, 46);
            this.videoRecorder1.Name = "videoRecorder1";
            this.videoRecorder1.Size = new System.Drawing.Size(449, 46);
            this.videoRecorder1.TabIndex = 2;
            this.videoRecorder1.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // webcamSurface1
            // 
            this.webcamSurface1.BackColor = System.Drawing.Color.White;
            this.webcamSurface1.CaptureRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.webcamSurface1.Location = new System.Drawing.Point(377, 12);
            this.webcamSurface1.Name = "webcamSurface1";
            this.webcamSurface1.Size = new System.Drawing.Size(160, 120);
            this.webcamSurface1.TabIndex = 4;
            this.webcamSurface1.Visible = false;
            this.webcamSurface1.MouseEnter += new System.EventHandler(this.webcamSurface1_MouseEnter);
            this.webcamSurface1.MouseLeave += new System.EventHandler(this.webcamSurface1_MouseLeave);
            // 
            // ScreenCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(549, 302);
            this.Controls.Add(this.webcamSurface1);
            this.Controls.Add(this.pictureBox321);
            this.Controls.Add(this.videoRecorder1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenCaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Capture";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.ScreenCaptureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox321)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerTicker;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.PictureBox pictureBox321;
        private System.Windows.Forms.Timer timer1;
        private RembyClipper2.Base.VideoRecorder videoRecorder1;
        private System.Windows.Forms.Timer timer2;
        private RembyClipper2.VideoEngine.WebcamSurface webcamSurface1;
    }
}