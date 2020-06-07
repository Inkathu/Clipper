namespace RembyClipper2.Base
{
    partial class RembyProgressBar
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
            this.pictureBoxStart = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnd = new System.Windows.Forms.PictureBox();
            this.pictureBoxContent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContent)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxStart
            // 
            this.pictureBoxStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxStart.Image = global::RembyClipper2.Properties.Resources.Progress_start_white;
            this.pictureBoxStart.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxStart.Name = "pictureBoxStart";
            this.pictureBoxStart.Size = new System.Drawing.Size(3, 15);
            this.pictureBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStart.TabIndex = 0;
            this.pictureBoxStart.TabStop = false;
            this.pictureBoxStart.Click += new System.EventHandler(this.ProgressBar_Click);
            // 
            // pictureBoxEnd
            // 
            this.pictureBoxEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxEnd.Image = global::RembyClipper2.Properties.Resources.Progress_end_white;
            this.pictureBoxEnd.Location = new System.Drawing.Point(251, 0);
            this.pictureBoxEnd.Name = "pictureBoxEnd";
            this.pictureBoxEnd.Size = new System.Drawing.Size(3, 15);
            this.pictureBoxEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEnd.TabIndex = 1;
            this.pictureBoxEnd.TabStop = false;
            this.pictureBoxEnd.Click += new System.EventHandler(this.ProgressBar_Click);
            // 
            // pictureBoxContent
            // 
            this.pictureBoxContent.BackgroundImage = global::RembyClipper2.Properties.Resources.Progress_step_white;
            this.pictureBoxContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxContent.Location = new System.Drawing.Point(3, 0);
            this.pictureBoxContent.Name = "pictureBoxContent";
            this.pictureBoxContent.Size = new System.Drawing.Size(248, 15);
            this.pictureBoxContent.TabIndex = 2;
            this.pictureBoxContent.TabStop = false;
            this.pictureBoxContent.Click += new System.EventHandler(this.ProgressBar_Click);
            this.pictureBoxContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxContent_Paint);
            this.pictureBoxContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxContent_MouseClick);
            // 
            // RembyProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RembyClipper2.Properties.Resources.Progress_bg;
            this.Controls.Add(this.pictureBoxContent);
            this.Controls.Add(this.pictureBoxEnd);
            this.Controls.Add(this.pictureBoxStart);
            this.Name = "RembyProgressBar";
            this.Size = new System.Drawing.Size(254, 15);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxStart;
        private System.Windows.Forms.PictureBox pictureBoxEnd;
        private System.Windows.Forms.PictureBox pictureBoxContent;
    }
}
