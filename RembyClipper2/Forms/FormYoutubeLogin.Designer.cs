namespace RembyClipper2.Forms
{
    partial class FormYouTubeLogin
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
            this.rembyYouTubeControl = new RembyClipper2.Base.RembyYouTubeControl();
            this.SuspendLayout();
            // 
            // rembyYouTubeControl
            // 
            this.rembyYouTubeControl.BackColor = System.Drawing.Color.Transparent;
            this.rembyYouTubeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rembyYouTubeControl.Location = new System.Drawing.Point(0, 0);
            this.rembyYouTubeControl.Name = "rembyYouTubeControl";
            this.rembyYouTubeControl.Size = new System.Drawing.Size(273, 272);
            this.rembyYouTubeControl.TabIndex = 0;
            this.rembyYouTubeControl.OnLoginButtonClicked += new RembyClipper2.Base.CustomButtonClicked(this.rembyYouTubeControl_OnLoginButtonClicked);
            this.rembyYouTubeControl.OnCloseButtonClicked += new RembyClipper2.Base.CustomButtonClicked(this.rembyYouTubeControl_OnCloseButtonClicked);
            // 
            // FormYouTubeLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 274);
            this.Controls.Add(this.rembyYouTubeControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormYouTubeLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormYouTubeLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private Base.RembyYouTubeControl rembyYouTubeControl;
    }
}