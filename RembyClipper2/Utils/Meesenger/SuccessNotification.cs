namespace RembyClipper2.Utils.Meesenger
{
    public class SuccessNotification : NotificationBase
    {
        public SuccessNotification()
        {
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::RembyClipper2.Properties.Resources.tick1;
            // 
            // label
            // 
            this.label.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // SuccessNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Image = global::RembyClipper2.Properties.Resources.tick1;
            this.Name = "SuccessNotification";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}