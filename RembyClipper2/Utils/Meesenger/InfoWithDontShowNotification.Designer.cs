namespace RembyClipper2.Utils.Meesenger
{
    partial class InfoWithDontShowNotification
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
            this.dontShowCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::RembyClipper2.Properties.Resources.exclamation;
            this.pictureBox.Location = new System.Drawing.Point(4, 31);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(41, 94);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dontShowCB);
            this.panel2.Size = new System.Drawing.Size(318, 94);
            this.panel2.Controls.SetChildIndex(this.timerLabel, 0);
            this.panel2.Controls.SetChildIndex(this.dontShowCB, 0);
            this.panel2.Controls.SetChildIndex(this.label, 0);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(5, 4);
            this.label.Size = new System.Drawing.Size(299, 73);
            // 
            // timerLabel
            // 
            this.timerLabel.Location = new System.Drawing.Point(304, 77);
            // 
            // dontShowCB
            // 
            this.dontShowCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dontShowCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dontShowCB.Location = new System.Drawing.Point(6, 76);
            this.dontShowCB.Name = "dontShowCB";
            this.dontShowCB.Size = new System.Drawing.Size(295, 18);
            this.dontShowCB.TabIndex = 2;
            this.dontShowCB.Text = "dontShowCB";
            this.dontShowCB.UseVisualStyleBackColor = true;
            this.dontShowCB.CheckedChanged += new System.EventHandler(this.dontShowCB_CheckedChanged);
            // 
            // InfoWithDontShowNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Image = global::RembyClipper2.Properties.Resources.exclamation;
            this.Name = "InfoWithDontShowNotification";
            this.Size = new System.Drawing.Size(359, 94);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox dontShowCB;
    }
}
