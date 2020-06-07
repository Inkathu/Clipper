namespace RembyClipper2.Forms
{
    partial class FormImgPreview
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
            this.rembyScreenshot1 = new RembyClipper2.Base.RembyScreenshot();
            this.rembyLoginControl1 = new RembyClipper2.Base.RembyLoginControl();
            this.rembyUploading1 = new RembyClipper2.Base.RembyUploading();
            this.rembyDone1 = new RembyClipper2.Base.RembyDone();
            this.SuspendLayout();
            // 
            // rembyScreenshot1
            // 
            this.rembyScreenshot1.BackColor = System.Drawing.Color.Transparent;
            this.rembyScreenshot1.Location = new System.Drawing.Point(-2, -1);
            this.rembyScreenshot1.MinimumSize = new System.Drawing.Size(473, 426);
            this.rembyScreenshot1.Name = "rembyScreenshot1";
            this.rembyScreenshot1.Screenshot = null;
            this.rembyScreenshot1.Size = new System.Drawing.Size(473, 426);
            this.rembyScreenshot1.Source = "title of the window";
            this.rembyScreenshot1.TabIndex = 6;
            // 
            // rembyLoginControl1
            // 
            this.rembyLoginControl1.BackColor = System.Drawing.Color.Transparent;
            this.rembyLoginControl1.Location = new System.Drawing.Point(81, 50);
            this.rembyLoginControl1.MaximumSize = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.MinimumSize = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.Name = "rembyLoginControl1";
            this.rembyLoginControl1.Size = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.TabIndex = 7;
            this.rembyLoginControl1.Visible = false;
            // 
            // rembyUploading1
            // 
            this.rembyUploading1.BackColor = System.Drawing.Color.Transparent;
            this.rembyUploading1.Location = new System.Drawing.Point(121, 50);
            this.rembyUploading1.MaximumSize = new System.Drawing.Size(230, 230);
            this.rembyUploading1.MinimumSize = new System.Drawing.Size(230, 230);
            this.rembyUploading1.Name = "rembyUploading1";
            this.rembyUploading1.Size = new System.Drawing.Size(230, 230);
            this.rembyUploading1.TabIndex = 8;
            this.rembyUploading1.Visible = false;
            // 
            // rembyDone1
            // 
            this.rembyDone1.BackColor = System.Drawing.Color.Transparent;
            this.rembyDone1.Location = new System.Drawing.Point(275, 144);
            this.rembyDone1.Name = "rembyDone1";
            this.rembyDone1.Size = new System.Drawing.Size(296, 240);
            this.rembyDone1.TabIndex = 9;
            this.rembyDone1.Visible = false;
            // 
            // FormImgPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(459, 424);
            this.Controls.Add(this.rembyDone1);
            this.Controls.Add(this.rembyUploading1);
            this.Controls.Add(this.rembyLoginControl1);
            this.Controls.Add(this.rembyScreenshot1);
            this.Name = "FormImgPreview";
            this.Text = "Remby screenshot";
            this.Load += new System.EventHandler(this.FormImgPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Base.RembyLoginControl rembyLoginControl1;
        private Base.RembyUploading rembyUploading1;
        private Base.RembyDone rembyDone1;
        public Base.RembyScreenshot rembyScreenshot1;


    }
}
