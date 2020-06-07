namespace RembyClipper2.Base
{
    partial class BarControl
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
            this.SuspendLayout();
            // 
            // BarControl
            // 
            this.BackgroundImage = global::RembyClipper2.Properties.Resources.Progress_bg;
            this.MinimumSize = new System.Drawing.Size(100, 32);
            this.Name = "BarControl";
            this.Size = new System.Drawing.Size(100, 32);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
