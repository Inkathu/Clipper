namespace RembyClipper2.Forms
{
    partial class LoginForm
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
            this.rembyLoginControl1 = new RembyClipper2.Base.RembyLoginControl();
            this.SuspendLayout();
            // 
            // rembyLoginControl1
            // 
            this.rembyLoginControl1.BackColor = System.Drawing.Color.Transparent;
            this.rembyLoginControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rembyLoginControl1.Location = new System.Drawing.Point(0, 0);
            this.rembyLoginControl1.MaximumSize = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.MinimumSize = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.Name = "rembyLoginControl1";
            this.rembyLoginControl1.Size = new System.Drawing.Size(270, 270);
            this.rembyLoginControl1.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(270, 275);
            this.Controls.Add(this.rembyLoginControl1);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private Base.RembyLoginControl rembyLoginControl1;
    }
}
