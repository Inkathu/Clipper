using RembyClipper2.Base;
namespace RembyClipper2.Forms
{
    partial class FormQuickTag
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
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.autoCompleteTextBox1 = new RembyClipper2.Base.TagsCombo();
            this.btnUpload = new RembyClipper2.Base.BlueButton();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.btnClose = new RembyClipper2.Base.GrayButton();
            this.grayPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.autoCompleteTextBox1);
            this.grayPanel1.Controls.Add(this.btnUpload);
            this.grayPanel1.Controls.Add(this.tagsLabel);
            this.grayPanel1.Controls.Add(this.btnClose);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.Location = new System.Drawing.Point(0, 0);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = true;
            this.grayPanel1.Size = new System.Drawing.Size(390, 32);
            this.grayPanel1.TabIndex = 49;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.grayPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.grayPanel1_Paint);
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.BackColor = System.Drawing.Color.DimGray;
            this.autoCompleteTextBox1.CustomText = "";
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(50, 6);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(182, 21);
            this.autoCompleteTextBox1.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(136)))), ((int)(((byte)(213)))));
            this.btnUpload.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnUpload.ButtonCaption = "*Upload";
            this.btnUpload.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.btnUpload.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpload.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpload.FontColor = System.Drawing.Color.White;
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Image = null;
            this.btnUpload.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUpload.Location = new System.Drawing.Point(238, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.RoundingRadius = 10;
            this.btnUpload.Size = new System.Drawing.Size(76, 24);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "*Upload";
            this.btnUpload.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tagsLabel
            // 
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.BackColor = System.Drawing.Color.Transparent;
            this.tagsLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagsLabel.ForeColor = System.Drawing.Color.Black;
            this.tagsLabel.Location = new System.Drawing.Point(5, 9);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(39, 14);
            this.tagsLabel.TabIndex = 0;
            this.tagsLabel.Text = "Tags:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnClose.ButtonCaption = "*Close";
            this.btnClose.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnClose.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.FontColor = System.Drawing.Color.Black;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = null;
            this.btnClose.ImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(320, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.RoundingRadius = 10;
            this.btnClose.Size = new System.Drawing.Size(67, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "*Close";
            this.btnClose.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormQuickTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 32);
            this.Controls.Add(this.grayPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(390, 32);
            this.MinimumSize = new System.Drawing.Size(390, 32);
            this.Name = "FormQuickTag";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormQuickTag_Load);
            this.grayPanel1.ResumeLayout(false);
            this.grayPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public GrayButton btnClose;
        public BlueButton btnUpload;
        protected System.Windows.Forms.Label tagsLabel;
        private Base.GrayPanel grayPanel1;
        private TagsCombo autoCompleteTextBox1;
    }
}
