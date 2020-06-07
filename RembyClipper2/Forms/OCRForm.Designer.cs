using RembyClipper2.Base;
namespace RembyClipper2.Forms
{
    partial class OCRForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancel = new RembyClipper2.Base.GrayButton();
            this.btnSaveChanges = new RembyClipper2.Base.BlueButton();
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.buttonCopy1 = new RembyClipper2.Base.GrayButton();
            this.grayPanel2 = new RembyClipper2.Base.GrayPanel();
            this.rembyProgressBar1 = new RembyClipper2.Base.ExtendedProgressBar();
            this.grayPanel1.SuspendLayout();
            this.grayPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Extracted text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = " (we’ll use this text to index the screenshot on Remby)";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(452, 340);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "OCR Quality:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(304, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "How to improve OCR quality";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 15000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnCancel.ButtonCaption = "*Cancel";
            this.btnCancel.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnCancel.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.FontColor = System.Drawing.Color.Black;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = null;
            this.btnCancel.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCancel.Location = new System.Drawing.Point(379, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundingRadius = 10;
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "*Cancel";
            this.btnCancel.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.buttonBlack1_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(136)))), ((int)(((byte)(213)))));
            this.btnSaveChanges.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnSaveChanges.ButtonCaption = "*Save";
            this.btnSaveChanges.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.btnSaveChanges.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnSaveChanges.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveChanges.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveChanges.FontColor = System.Drawing.Color.White;
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Image = null;
            this.btnSaveChanges.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSaveChanges.Location = new System.Drawing.Point(250, 8);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.RoundingRadius = 10;
            this.btnSaveChanges.Size = new System.Drawing.Size(114, 30);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "*Save";
            this.btnSaveChanges.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.buttonOrange1_Click);
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.buttonCopy1);
            this.grayPanel1.Controls.Add(this.btnCancel);
            this.grayPanel1.Controls.Add(this.btnSaveChanges);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel1.Location = new System.Drawing.Point(0, 435);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(468, 44);
            this.grayPanel1.TabIndex = 27;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // buttonCopy1
            // 
            this.buttonCopy1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonCopy1.ButtonCaption = "";
            this.buttonCopy1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonCopy1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonCopy1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonCopy1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCopy1.FontColor = System.Drawing.Color.Black;
            this.buttonCopy1.Image = global::RembyClipper2.NewDesign.icon_copy;
            this.buttonCopy1.ImageSize = new System.Drawing.Size(29, 26);
            this.buttonCopy1.Location = new System.Drawing.Point(7, 11);
            this.buttonCopy1.Name = "buttonCopy1";
            this.buttonCopy1.RoundingRadius = 10;
            this.buttonCopy1.Size = new System.Drawing.Size(29, 25);
            this.buttonCopy1.TabIndex = 0;
            this.buttonCopy1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonCopy1.UseVisualStyleBackColor = true;
            this.buttonCopy1.Click += new System.EventHandler(this.buttonCopy1_Click);
            // 
            // grayPanel2
            // 
            this.grayPanel2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grayPanel2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.grayPanel2.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel2.Controls.Add(this.rembyProgressBar1);
            this.grayPanel2.Controls.Add(this.label3);
            this.grayPanel2.Controls.Add(this.label4);
            this.grayPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel2.DrawRoundedBorder = false;
            this.grayPanel2.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel2.Location = new System.Drawing.Point(0, 392);
            this.grayPanel2.Name = "grayPanel2";
            this.grayPanel2.RoundingRadius = 10;
            this.grayPanel2.ShowBorder = true;
            this.grayPanel2.Size = new System.Drawing.Size(468, 43);
            this.grayPanel2.TabIndex = 28;
            this.grayPanel2.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // rembyProgressBar1
            // 
            this.rembyProgressBar1.AllowEventFiring = false;
            this.rembyProgressBar1.DrawText = false;
            this.rembyProgressBar1.Location = new System.Drawing.Point(94, 16);
            this.rembyProgressBar1.MaxValue = 100;
            this.rembyProgressBar1.MinValue = 0;
            this.rembyProgressBar1.Name = "rembyProgressBar1";
            this.rembyProgressBar1.PercentValue = 0;
            this.rembyProgressBar1.Size = new System.Drawing.Size(204, 12);
            this.rembyProgressBar1.TabIndex = 17;
            this.rembyProgressBar1.Value = 0;
            // 
            // OCRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 479);
            this.Controls.Add(this.grayPanel2);
            this.Controls.Add(this.grayPanel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OCRForm";
            this.Text = "Remby screenshot OCR";
            this.Load += new System.EventHandler(this.OCRForm_Load);
            this.grayPanel1.ResumeLayout(false);
            this.grayPanel2.ResumeLayout(false);
            this.grayPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private GrayButton btnCancel;
        private BlueButton btnSaveChanges;
        private Base.GrayPanel grayPanel1;
        private Base.GrayPanel grayPanel2;
        private GrayButton buttonCopy1;
        private ExtendedProgressBar rembyProgressBar1;
    }
}