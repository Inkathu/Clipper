namespace ControlsTest.CustomList
{
    partial class ListItemBase
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.timeStampLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(16, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(128, 128);
            this.contentPanel.TabIndex = 0;
            // 
            // timeStampLabel
            // 
            this.timeStampLabel.Location = new System.Drawing.Point(16, 132);
            this.timeStampLabel.Name = "timeStampLabel";
            this.timeStampLabel.Size = new System.Drawing.Size(128, 23);
            this.timeStampLabel.TabIndex = 1;
            this.timeStampLabel.Text = "label1";
            this.timeStampLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListItemBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.timeStampLabel);
            this.Controls.Add(this.contentPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ListItemBase";
            this.Size = new System.Drawing.Size(160, 155);
            this.MouseEnter += new System.EventHandler(this.ListItemBase_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ListItemBase_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label timeStampLabel;
        protected System.Windows.Forms.Panel contentPanel;

    }
}
