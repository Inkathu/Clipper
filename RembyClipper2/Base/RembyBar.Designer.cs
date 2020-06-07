namespace RembyClipper2.Base
{
    partial class RembyBar
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
            this.SuspendLayout();
            // 
            // RembyBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RembyClipper2.Properties.Resources.Progress_bg;
            this.MaximumSize = new System.Drawing.Size(0, 32);
            this.MinimumSize = new System.Drawing.Size(8, 32);
            this.Name = "RembyBar";
            this.Size = new System.Drawing.Size(24, 32);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
