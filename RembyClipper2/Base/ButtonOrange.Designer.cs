namespace RembyClipper2.Base
{
    partial class ButtonOrange
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
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ButtonOrange
            // 
            this.BackgroundImage = global::RembyClipper2.Properties.Resources.Orange_button;
            this.Name = "ButtonOrange";
            this.Click += new System.EventHandler(this.ButtonOrange_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
