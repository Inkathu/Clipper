namespace RembyClipper2.VideoEngine
{
    partial class WebcamSurface
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinMax = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::RembyClipper2.Properties.Resources.Artwork_DesignService_fedora_spinner;
            this.pictureBox1.Location = new System.Drawing.Point(30, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBoxMinMax
            // 
            this.pictureBoxMinMax.Image = global::RembyClipper2.Properties.Resources.WebcamZoomIn;
            this.pictureBoxMinMax.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMinMax.Name = "pictureBoxMinMax";
            this.pictureBoxMinMax.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxMinMax.TabIndex = 0;
            this.pictureBoxMinMax.TabStop = false;
            this.pictureBoxMinMax.Visible = false;
            this.pictureBoxMinMax.Click += new System.EventHandler(this.pictureBoxMinMax_Click);
            this.pictureBoxMinMax.MouseEnter += new System.EventHandler(this.pictureBoxMinMax_MouseEnter);
            this.pictureBoxMinMax.MouseLeave += new System.EventHandler(this.pictureBoxMinMax_MouseLeave);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.Image = global::RembyClipper2.Properties.Resources.WebcamClose;
            this.pictureBoxClose.Location = new System.Drawing.Point(127, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxClose.TabIndex = 1;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Visible = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // WebcamSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxMinMax);
            this.Controls.Add(this.pictureBoxClose);
            this.Name = "WebcamSurface";
            this.Size = new System.Drawing.Size(160, 120);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPIP_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPIP_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPIP_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMinMax;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
