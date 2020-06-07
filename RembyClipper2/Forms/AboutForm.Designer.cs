namespace RembyClipper2.Forms
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.grayButton2 = new RembyClipper2.Base.GrayButton();
            this.panelBase1 = new RembyClipper2.Base.PanelBase();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.reservedRightsLabel = new System.Windows.Forms.Label();
            this.copyRightsLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grayPanel1.SuspendLayout();
            this.panelBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.grayButton2);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.Location = new System.Drawing.Point(0, 203);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(511, 46);
            this.grayPanel1.TabIndex = 1;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // grayButton2
            // 
            this.grayButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grayButton2.ButtonCaption = "OK";
            this.grayButton2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.grayButton2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.grayButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.grayButton2.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grayButton2.FontColor = System.Drawing.Color.Black;
            this.grayButton2.Image = null;
            this.grayButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.grayButton2.Location = new System.Drawing.Point(213, 8);
            this.grayButton2.Name = "grayButton2";
            this.grayButton2.RoundingRadius = 10;
            this.grayButton2.Size = new System.Drawing.Size(85, 30);
            this.grayButton2.TabIndex = 19;
            this.grayButton2.Text = "OK";
            this.grayButton2.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.grayButton2.UseVisualStyleBackColor = true;
            this.grayButton2.Click += new System.EventHandler(this.grayButton1_Click);
            // 
            // panelBase1
            // 
            this.panelBase1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.panelBase1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.panelBase1.ColorOfBorder = System.Drawing.Color.Black;
            this.panelBase1.Controls.Add(this.linkLabel);
            this.panelBase1.Controls.Add(this.reservedRightsLabel);
            this.panelBase1.Controls.Add(this.copyRightsLabel);
            this.panelBase1.Controls.Add(this.versionLabel);
            this.panelBase1.Controls.Add(this.productNameLabel);
            this.panelBase1.Controls.Add(this.pictureBox1);
            this.panelBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase1.DrawRoundedBorder = false;
            this.panelBase1.Location = new System.Drawing.Point(0, 0);
            this.panelBase1.Name = "panelBase1";
            this.panelBase1.RoundingRadius = 10;
            this.panelBase1.ShowBorder = false;
            this.panelBase1.Size = new System.Drawing.Size(511, 203);
            this.panelBase1.TabIndex = 2;
            this.panelBase1.TopGlowLineColor = System.Drawing.Color.White;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel.Font = new System.Drawing.Font("Arial", 12.25F);
            this.linkLabel.Location = new System.Drawing.Point(166, 143);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(33, 19);
            this.linkLabel.TabIndex = 2;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "link";
            // 
            // reservedRightsLabel
            // 
            this.reservedRightsLabel.AutoSize = true;
            this.reservedRightsLabel.BackColor = System.Drawing.Color.Transparent;
            this.reservedRightsLabel.Font = new System.Drawing.Font("Arial", 12.25F);
            this.reservedRightsLabel.Location = new System.Drawing.Point(166, 122);
            this.reservedRightsLabel.Name = "reservedRightsLabel";
            this.reservedRightsLabel.Size = new System.Drawing.Size(117, 19);
            this.reservedRightsLabel.TabIndex = 1;
            this.reservedRightsLabel.Text = "reserved rights";
            // 
            // copyRightsLabel
            // 
            this.copyRightsLabel.AutoSize = true;
            this.copyRightsLabel.BackColor = System.Drawing.Color.Transparent;
            this.copyRightsLabel.Font = new System.Drawing.Font("Arial", 12.25F);
            this.copyRightsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.copyRightsLabel.Location = new System.Drawing.Point(166, 100);
            this.copyRightsLabel.Name = "copyRightsLabel";
            this.copyRightsLabel.Size = new System.Drawing.Size(85, 19);
            this.copyRightsLabel.TabIndex = 1;
            this.copyRightsLabel.Text = "copyrights";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Arial", 12.25F);
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            this.versionLabel.Location = new System.Drawing.Point(169, 59);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(61, 19);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "version";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.productNameLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.productNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.productNameLabel.Location = new System.Drawing.Point(166, 32);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(140, 22);
            this.productNameLabel.TabIndex = 1;
            this.productNameLabel.Text = "product Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::RembyClipper2.NewDesign.remby_icon_big;
            this.pictureBox1.Location = new System.Drawing.Point(14, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 132);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 249);
            this.Controls.Add(this.panelBase1);
            this.Controls.Add(this.grayPanel1);
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About Remby";
            this.grayPanel1.ResumeLayout(false);
            this.panelBase1.ResumeLayout(false);
            this.panelBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.GrayPanel grayPanel1;
        private Base.PanelBase panelBase1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label reservedRightsLabel;
        private System.Windows.Forms.Label copyRightsLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label productNameLabel;
        private Base.GrayButton grayButton2;
    }
}
