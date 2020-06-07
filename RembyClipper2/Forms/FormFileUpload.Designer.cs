namespace RembyClipper2.Forms
{
    partial class FormFileUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileUpload));
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.tagEditControl = new RembyClipper2.Base.TagEditControl();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.clearBtn = new RembyClipper2.Base.GrayButton();
            this.browseButton = new RembyClipper2.Base.GrayButton();
            this.cancelButton = new RembyClipper2.Base.GrayButton();
            this.uploadButton = new RembyClipper2.Base.BlueButton();
            this.helpLabel = new System.Windows.Forms.Label();
            this.customList1 = new RembyClipper2.Base.CustomList();
            this.grayPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.tagEditControl);
            this.grayPanel1.Controls.Add(this.tagsLabel);
            this.grayPanel1.Controls.Add(this.clearBtn);
            this.grayPanel1.Controls.Add(this.browseButton);
            this.grayPanel1.Controls.Add(this.cancelButton);
            this.grayPanel1.Controls.Add(this.uploadButton);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel1.Location = new System.Drawing.Point(0, 260);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(474, 114);
            this.grayPanel1.TabIndex = 3;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // tagEditControl
            // 
            this.tagEditControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagEditControl.AutoSize = true;
            this.tagEditControl.BackColor = System.Drawing.Color.Transparent;
            this.tagEditControl.Location = new System.Drawing.Point(12, 23);
            this.tagEditControl.Name = "tagEditControl";
            this.tagEditControl.Size = new System.Drawing.Size(453, 51);
            this.tagEditControl.TabIndex = 0;
            // 
            // tagsLabel
            // 
            this.tagsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.BackColor = System.Drawing.Color.Transparent;
            this.tagsLabel.Location = new System.Drawing.Point(12, 7);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(48, 13);
            this.tagsLabel.TabIndex = 4;
            this.tagsLabel.Text = "#Tags#:";
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.clearBtn.ButtonCaption = "#Clear#";
            this.clearBtn.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.clearBtn.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.clearBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.clearBtn.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearBtn.FontColor = System.Drawing.Color.Black;
            this.clearBtn.Image = null;
            this.clearBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.clearBtn.Location = new System.Drawing.Point(112, 80);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.RoundingRadius = 10;
            this.clearBtn.Size = new System.Drawing.Size(85, 25);
            this.clearBtn.TabIndex = 2;
            this.clearBtn.Text = "#Clear#";
            this.clearBtn.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.browseButton.ButtonCaption = "#Browse#";
            this.browseButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.browseButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.browseButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.browseButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.browseButton.FontColor = System.Drawing.Color.Black;
            this.browseButton.Image = null;
            this.browseButton.ImageSize = new System.Drawing.Size(20, 20);
            this.browseButton.Location = new System.Drawing.Point(12, 80);
            this.browseButton.Name = "browseButton";
            this.browseButton.RoundingRadius = 10;
            this.browseButton.Size = new System.Drawing.Size(85, 25);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "#Browse#";
            this.browseButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cancelButton.ButtonCaption = "#Cancel#";
            this.cancelButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.cancelButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.FontColor = System.Drawing.Color.Black;
            this.cancelButton.Image = null;
            this.cancelButton.ImageSize = new System.Drawing.Size(20, 20);
            this.cancelButton.Location = new System.Drawing.Point(380, 80);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RoundingRadius = 10;
            this.cancelButton.Size = new System.Drawing.Size(85, 25);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "#Cancel#";
            this.cancelButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.uploadButton.ButtonCaption = "#Upload#";
            this.uploadButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.uploadButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.uploadButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.uploadButton.Enabled = false;
            this.uploadButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.uploadButton.FontColor = System.Drawing.Color.White;
            this.uploadButton.Image = null;
            this.uploadButton.ImageSize = new System.Drawing.Size(20, 20);
            this.uploadButton.Location = new System.Drawing.Point(287, 80);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.RoundingRadius = 10;
            this.uploadButton.Size = new System.Drawing.Size(85, 25);
            this.uploadButton.TabIndex = 3;
            this.uploadButton.Text = "#Upload#";
            this.uploadButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.helpLabel.BackColor = System.Drawing.Color.Transparent;
            this.helpLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.helpLabel.Location = new System.Drawing.Point(138, 96);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(199, 68);
            this.helpLabel.TabIndex = 5;
            this.helpLabel.Text = "#Click browse to select the items you want to upload#";
            this.helpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customList1
            // 
            this.customList1.AutoScroll = true;
            this.customList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customList1.Location = new System.Drawing.Point(0, 0);
            this.customList1.Name = "customList1";
            this.customList1.Size = new System.Drawing.Size(474, 260);
            this.customList1.TabIndex = 6;
            this.customList1.TabStop = false;
            // 
            // FormFileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(474, 374);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.customList1);
            this.Controls.Add(this.grayPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(490, 412);
            this.Name = "FormFileUpload";
            this.Text = "#File Upload#";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFileUpload_FormClosed);
            this.Load += new System.EventHandler(this.FormFileUpload_Load);
            this.grayPanel1.ResumeLayout(false);
            this.grayPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.BlueButton uploadButton;
        private Base.GrayButton cancelButton;
        private Base.GrayButton browseButton;
        private Base.GrayPanel grayPanel1;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.Label helpLabel;
        private Base.GrayButton clearBtn;
        private Base.TagEditControl tagEditControl;
        private Base.CustomList customList1;
    }
}