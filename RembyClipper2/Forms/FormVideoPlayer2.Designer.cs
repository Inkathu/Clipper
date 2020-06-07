namespace RembyClipper2.Forms
{
    partial class FormVideoPlayer2
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
            this.rembyVideo1.Description = "";
            this.rembyVideo1.Location = new System.Drawing.Point(12, 12);
            this.rembyVideo1.Name = "rembyVideo1";
            this.rembyVideo1.Size = new System.Drawing.Size(473, 599);
            this.rembyVideo1.TabIndex = 0;
            // 
            // FormVideoPlayer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 578);
            this.Controls.Add(this.rembyVideo1);
            this.Name = "FormVideoPlayer2";
            this.Text = "FormVideoPlayer2";
            this.ResumeLayout(false);

        }

        #endregion

        public Base.RembyVideo rembyVideo1;


    }
}