namespace RembyClipper2.Base
{
    partial class ButtonMute
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
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.Text = "";
            // 
            // ButtonMute
            // 
            this.BackgroundImage = global::RembyClipper2.Properties.Resources.mute;
            this.MaximumSize = new System.Drawing.Size(0, 28);
            this.MinimumSize = new System.Drawing.Size(30, 28);
            this.Name = "ButtonMute";
            this.Size = new System.Drawing.Size(30, 28);
            this.Click += new System.EventHandler(this.ButtonMute_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
