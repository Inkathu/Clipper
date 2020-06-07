namespace RembyClipper2.Base
{
    partial class VideoPlayer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerLength = new System.Windows.Forms.Timer(this.components);
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rembyProgressBar1 = new RembyClipper2.Base.ExtendedProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonPlayPause1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.grayPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlayPause1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBoxLoading);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 273);
            this.panel1.TabIndex = 3;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxLoading.Image = global::RembyClipper2.NewDesign.ajax_loader;
            this.pictureBoxLoading.Location = new System.Drawing.Point(148, 99);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(103, 100);
            this.pictureBoxLoading.TabIndex = 1;
            this.pictureBoxLoading.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.panel2);
            this.grayPanel1.Controls.Add(this.pictureBox2);
            this.grayPanel1.Controls.Add(this.panel3);
            this.grayPanel1.Controls.Add(this.buttonPlayPause1);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.Location = new System.Drawing.Point(0, 277);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(414, 36);
            this.grayPanel1.TabIndex = 5;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rembyProgressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(43, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 36);
            this.panel2.TabIndex = 5;
            // 
            // rembyProgressBar1
            // 
            this.rembyProgressBar1.AllowEventFiring = false;
            this.rembyProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rembyProgressBar1.DrawText = false;
            this.rembyProgressBar1.Location = new System.Drawing.Point(0, 12);
            this.rembyProgressBar1.MaxValue = 100;
            this.rembyProgressBar1.MinValue = 0;
            this.rembyProgressBar1.Name = "rembyProgressBar1";
            this.rembyProgressBar1.PercentValue = 0;
            this.rembyProgressBar1.Size = new System.Drawing.Size(303, 13);
            this.rembyProgressBar1.TabIndex = 0;
            this.rembyProgressBar1.Value = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::RembyClipper2.NewDesign.divider1;
            this.pictureBox2.Location = new System.Drawing.Point(38, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(5, 36);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(347, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(67, 36);
            this.panel3.TabIndex = 6;
            // 
            // buttonPlayPause1
            // 
            this.buttonPlayPause1.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPlayPause1.Image = global::RembyClipper2.NewDesign.video_btn_play;
            this.buttonPlayPause1.Location = new System.Drawing.Point(0, 0);
            this.buttonPlayPause1.Name = "buttonPlayPause1";
            this.buttonPlayPause1.Size = new System.Drawing.Size(38, 36);
            this.buttonPlayPause1.TabIndex = 0;
            this.buttonPlayPause1.TabStop = false;
            this.buttonPlayPause1.Click += new System.EventHandler(this.buttonPlayPause1_Click);
            // 
            // VideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grayPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "VideoPlayer";
            this.Size = new System.Drawing.Size(414, 313);
            this.Load += new System.EventHandler(this.VideoPlayer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.grayPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlayPause1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerLength;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private GrayPanel grayPanel1;
        private System.Windows.Forms.PictureBox buttonPlayPause1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ExtendedProgressBar rembyProgressBar1;
    }
}
