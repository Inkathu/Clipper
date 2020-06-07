namespace RembyClipper2.Base
{
    partial class TagItem
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
            this.panelBase1 = new RembyClipper2.Base.GrayPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.blueButton1 = new RembyClipper2.Base.BlueButton();
            this.panelBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBase1
            // 
            this.panelBase1.AutoSize = true;
            this.panelBase1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBase1.BackColor = System.Drawing.Color.Transparent;
            this.panelBase1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(248)))));
            this.panelBase1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(248)))));
            this.panelBase1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelBase1.Controls.Add(this.label1);
            this.panelBase1.Controls.Add(this.blueButton1);
            this.panelBase1.DrawRoundedBorder = true;
            this.panelBase1.HighLightedColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(177)))), ((int)(((byte)(206)))));
            this.panelBase1.Location = new System.Drawing.Point(1, 1);
            this.panelBase1.Margin = new System.Windows.Forms.Padding(0);
            this.panelBase1.Name = "panelBase1";
            this.panelBase1.Padding = new System.Windows.Forms.Padding(2);
            this.panelBase1.RoundingRadius = 13;
            this.panelBase1.ShowBorder = true;
            this.panelBase1.Size = new System.Drawing.Size(41, 17);
            this.panelBase1.TabIndex = 0;
            this.panelBase1.TopGlowLineColor = System.Drawing.Color.Transparent;
            this.panelBase1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.panelBase1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "tag";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // blueButton1
            // 
            this.blueButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(248)))));
            this.blueButton1.ButtonCaption = "x";
            this.blueButton1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(248)))));
            this.blueButton1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(248)))));
            this.blueButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.blueButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.blueButton1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.blueButton1.FontColor = System.Drawing.Color.DimGray;
            this.blueButton1.Image = null;
            this.blueButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.blueButton1.Location = new System.Drawing.Point(24, 2);
            this.blueButton1.Margin = new System.Windows.Forms.Padding(0);
            this.blueButton1.Name = "blueButton1";
            this.blueButton1.RoundingRadius = 14;
            this.blueButton1.Size = new System.Drawing.Size(15, 13);
            this.blueButton1.TabIndex = 1;
            this.blueButton1.TabStop = false;
            this.blueButton1.Text = "x";
            this.blueButton1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(248)))));
            this.blueButton1.UseVisualStyleBackColor = true;
            this.blueButton1.Click += new System.EventHandler(this.blueButton1_Click);
            this.blueButton1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.blueButton1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // TagItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelBase1);
            this.Name = "TagItem";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(43, 19);
            this.panelBase1.ResumeLayout(false);
            this.panelBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GrayPanel panelBase1;
        private System.Windows.Forms.Label label1;
        private BlueButton blueButton1;
    }
}
