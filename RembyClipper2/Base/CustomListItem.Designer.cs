namespace RembyClipper2.Base
{
    partial class CustomListItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.itemText = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.itemImage = new System.Windows.Forms.PictureBox();
            this.removeBtn = new RembyClipper2.Base.GrayButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.itemImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(22, 25);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.itemText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(22, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 25);
            this.panel2.TabIndex = 0;
            // 
            // itemText
            // 
            this.itemText.AutoSize = true;
            this.itemText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemText.Location = new System.Drawing.Point(0, 0);
            this.itemText.MinimumSize = new System.Drawing.Size(0, 25);
            this.itemText.Name = "itemText";
            this.itemText.Size = new System.Drawing.Size(60, 25);
            this.itemText.TabIndex = 0;
            this.itemText.Text = "##text##";
            this.itemText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.itemText.Click += new System.EventHandler(this.itemText_Click);
            this.itemText.MouseHover += new System.EventHandler(this.itemText_MouseHover);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.removeBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(82, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(27, 25);
            this.panel3.TabIndex = 0;
            this.panel3.MouseHover += new System.EventHandler(this.itemText_MouseHover);
            // 
            // itemImage
            // 
            this.itemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.itemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemImage.Image = global::RembyClipper2.Properties.Resources.file_extension_doc;
            this.itemImage.Location = new System.Drawing.Point(0, 0);
            this.itemImage.Name = "itemImage";
            this.itemImage.Size = new System.Drawing.Size(22, 25);
            this.itemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.itemImage.TabIndex = 0;
            this.itemImage.TabStop = false;
            this.itemImage.MouseHover += new System.EventHandler(this.itemText_MouseHover);
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.removeBtn.ButtonCaption = "";
            this.removeBtn.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.removeBtn.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.removeBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.removeBtn.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeBtn.FontColor = System.Drawing.Color.Black;
            this.removeBtn.Image = global::RembyClipper2.Properties.Resources.remove;
            this.removeBtn.ImageSize = new System.Drawing.Size(13, 13);
            this.removeBtn.Location = new System.Drawing.Point(3, 3);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.RoundingRadius = 10;
            this.removeBtn.Size = new System.Drawing.Size(20, 19);
            this.removeBtn.TabIndex = 0;
            this.removeBtn.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            this.removeBtn.MouseHover += new System.EventHandler(this.itemText_MouseHover);
            // 
            // CustomListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CustomListItem";
            this.Size = new System.Drawing.Size(109, 25);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox itemImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private GrayButton removeBtn;
        private System.Windows.Forms.Label itemText;
    }
}
