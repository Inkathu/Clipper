namespace RembyClipper2.Forms
{
    partial class FormVideoPlayer
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
            this.rembyVideo1 = new RembyClipper2.Base.RembyVideo();
            this.SuspendLayout();
            // 
            // rembyVideo1
            // 
            this.rembyVideo1.BackColor = System.Drawing.Color.Transparent;
            this.rembyVideo1.Description = "Remby screen video - ";
            this.rembyVideo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rembyVideo1.Location = new System.Drawing.Point(0, 0);
            this.rembyVideo1.Name = "rembyVideo1";
            this.rembyVideo1.Size = new System.Drawing.Size(468, 558);
            this.rembyVideo1.TabIndex = 6;
            //this.rembyVideo1.Tags = "***";
            this.rembyVideo1.Title = "27.04.2011 0:05";
            // 
            // FormVideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(468, 558);
            this.Controls.Add(this.rembyVideo1);
            this.Name = "FormVideoPlayer";
            this.Text = "Remby screen video";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormVideoPlayer_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormVideoPlayer_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public Base.RembyVideo rembyVideo1;
    }
}
