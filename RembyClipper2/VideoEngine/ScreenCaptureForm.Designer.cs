using System.Timers;

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
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.webcamSurface1 = new RembyClipper2.VideoEngine.WebcamSurface();
            this.videoRecorder1 = new RembyClipper2.Base.VideoRecorder();
            this.barControl1 = new RembyClipper2.Base.BarControl();
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
            this.pictureBox321.Location = new System.Drawing.Point(237, 119);
            this.pictureBox321.Name = "pictureBox321";
            this.pictureBox321.Size = new System.Drawing.Size(92, 92);
            this.pictureBox321.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox321.TabIndex = 3;
            this.pictureBox321.TabStop = false;
            this.pictureBox321.Visible = false;
            this.pictureBox321.Click += new System.EventHandler(this.pictureBox321_Click);
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
            this.webcamSurface1.OnCloseClicked += new RembyClipper2.Base.CustomButtonClicked(this.webcamSurface1_OnCloseClicked);
            this.webcamSurface1.OnMove += new RembyClipper2.Base.CustomButtonClicked(this.webcamSurface1_OnMove);
            this.webcamSurface1.MouseEnter += new System.EventHandler(this.webcamSurface1_MouseEnter);
            this.webcamSurface1.MouseLeave += new System.EventHandler(this.webcamSurface1_MouseLeave);
            // 
            // videoRecorder1
            // 
            this.videoRecorder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.videoRecorder1.BoundSize = "640x480 px";
            this.videoRecorder1.Duration = "00:00";
            this.videoRecorder1.Location = new System.Drawing.Point(37, 268);
            this.videoRecorder1.MinimumSize = new System.Drawing.Size(455, 38);
            this.videoRecorder1.Name = "videoRecorder1";
            this.videoRecorder1.Size = new System.Drawing.Size(455, 38);
            this.videoRecorder1.TabIndex = 5;
            this.videoRecorder1.Visible = false;
            // 
            // barControl1
            // 
            this.barControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.barControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barControl1.BackgroundImage")));
            this.barControl1.Location = new System.Drawing.Point(0, 180);
            this.barControl1.MinimumSize = new System.Drawing.Size(100, 32);
            this.barControl1.Name = "barControl1";
            this.barControl1.Size = new System.Drawing.Size(100, 32);
            this.barControl1.TabIndex = 6;
            this.barControl1.Visible = false;
            // 
            // ScreenCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(567, 330);
            this.Controls.Add(this.pictureBox321);
            this.Controls.Add(this.barControl1);
            this.Controls.Add(this.webcamSurface1);
            this.Controls.Add(this.videoRecorder1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenCaptureForm";
            this.ShowIcon = false;
            this.Text = "Screen Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenCaptureForm_FormClosing);
            this.Load += new System.EventHandler(this.ScreenCaptureForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScreenCaptureForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScreenCaptureForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox321)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timer timerTicker;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.PictureBox pictureBox321;
        private System.Windows.Forms.Timer timer1;
        private RembyClipper2.Base.VideoRecorder videoRecorder1;
        private System.Windows.Forms.Timer timer2;
        private RembyClipper2.VideoEngine.WebcamSurface webcamSurface1;
        private RembyClipper2.Base.BarControl barControl1;
    }
}