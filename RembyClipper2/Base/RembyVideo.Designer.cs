namespace RembyClipper2.Base
{
    partial class RembyVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RembyVideo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.labelYT = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.videoPlayer1 = new RembyClipper2.Base.VideoPlayer();
            this.labelError = new System.Windows.Forms.Label();
            this.btnCancel = new RembyClipper2.Base.GrayButton();
            this.btnAddToRemby = new RembyClipper2.Base.BlueButton();
            this.buttonSave1 = new RembyClipper2.Base.GrayButton();
            this.pictureBoxError = new System.Windows.Forms.PictureBox();
            this.textBoxTitle = new RembyClipper2.Base.ExtendedRoundedTextBox();
            this.textBoxDescription = new RembyClipper2.Base.ExtendedRoundedTextBox();
            this.tagEditControl = new RembyClipper2.Base.TagEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(240, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tags";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Category";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.ForeColor = System.Drawing.Color.Black;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(9, 465);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(184, 21);
            this.comboBoxCategories.TabIndex = 3;
            // 
            // labelYT
            // 
            this.labelYT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYT.BackColor = System.Drawing.Color.Transparent;
            this.labelYT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYT.ForeColor = System.Drawing.Color.Black;
            this.labelYT.Location = new System.Drawing.Point(3, 494);
            this.labelYT.Name = "labelYT";
            this.labelYT.Size = new System.Drawing.Size(461, 55);
            this.labelYT.TabIndex = 29;
            this.labelYT.Text = resources.GetString("labelYT.Text");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "MP4 Files|*.mp4";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Remby";
            // 
            // videoPlayer1
            // 
            this.videoPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.videoPlayer1.Filename = null;
            this.videoPlayer1.Location = new System.Drawing.Point(2, 3);
            this.videoPlayer1.Name = "videoPlayer1";
            this.videoPlayer1.Size = new System.Drawing.Size(468, 345);
            this.videoPlayer1.TabIndex = 0;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(192)))));
            this.labelError.Location = new System.Drawing.Point(60, 20);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(35, 13);
            this.labelError.TabIndex = 32;
            this.labelError.Text = "label2";
            this.labelError.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnCancel.ButtonCaption = "*Close";
            this.btnCancel.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnCancel.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.FontColor = System.Drawing.Color.Black;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = null;
            this.btnCancel.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCancel.Location = new System.Drawing.Point(389, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundingRadius = 10;
            this.btnCancel.Size = new System.Drawing.Size(77, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "*Close";
            this.btnCancel.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.buttonBlack1_Click);
            // 
            // btnAddToRemby
            // 
            this.btnAddToRemby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToRemby.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(136)))), ((int)(((byte)(213)))));
            this.btnAddToRemby.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnAddToRemby.ButtonCaption = "*Save";
            this.btnAddToRemby.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.btnAddToRemby.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.btnAddToRemby.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddToRemby.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddToRemby.FontColor = System.Drawing.Color.White;
            this.btnAddToRemby.ForeColor = System.Drawing.Color.White;
            this.btnAddToRemby.Image = null;
            this.btnAddToRemby.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddToRemby.Location = new System.Drawing.Point(240, 461);
            this.btnAddToRemby.Name = "btnAddToRemby";
            this.btnAddToRemby.RoundingRadius = 10;
            this.btnAddToRemby.Size = new System.Drawing.Size(143, 29);
            this.btnAddToRemby.TabIndex = 5;
            this.btnAddToRemby.Text = "*Save";
            this.btnAddToRemby.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.btnAddToRemby.UseVisualStyleBackColor = false;
            this.btnAddToRemby.Click += new System.EventHandler(this.buttonOrange1_Click);
            // 
            // buttonSave1
            // 
            this.buttonSave1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonSave1.ButtonCaption = "";
            this.buttonSave1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonSave1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonSave1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonSave1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave1.FontColor = System.Drawing.Color.Black;
            this.buttonSave1.Image = global::RembyClipper2.NewDesign.icon_save;
            this.buttonSave1.ImageSize = new System.Drawing.Size(29, 26);
            this.buttonSave1.Location = new System.Drawing.Point(201, 462);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.RoundingRadius = 10;
            this.buttonSave1.Size = new System.Drawing.Size(30, 26);
            this.buttonSave1.TabIndex = 4;
            this.buttonSave1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonSave1.UseVisualStyleBackColor = true;
            this.buttonSave1.Click += new System.EventHandler(this.buttonSave1_Click);
            // 
            // pictureBoxError
            // 
            this.pictureBoxError.Image = global::RembyClipper2.Properties.Resources.ErrorBG;
            this.pictureBoxError.Location = new System.Drawing.Point(12, 0);
            this.pictureBoxError.Name = "pictureBoxError";
            this.pictureBoxError.Size = new System.Drawing.Size(449, 52);
            this.pictureBoxError.TabIndex = 31;
            this.pictureBoxError.TabStop = false;
            this.pictureBoxError.Visible = false;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.InnerText = "";
            this.textBoxTitle.Location = new System.Drawing.Point(9, 378);
            this.textBoxTitle.MinimumSize = new System.Drawing.Size(0, 20);
            this.textBoxTitle.Multiline = false;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.PasswordChar = '\0';
            this.textBoxTitle.SelectionLength = 0;
            this.textBoxTitle.SelectionStart = 0;
            this.textBoxTitle.Size = new System.Drawing.Size(224, 20);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.TextLength = 32767;
            this.textBoxTitle.CustomTextChanged += new System.EventHandler(this.tagEditControl_TagsCollectionChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.InnerText = "Remby screen video - ";
            this.textBoxDescription.Location = new System.Drawing.Point(9, 422);
            this.textBoxDescription.MinimumSize = new System.Drawing.Size(0, 20);
            this.textBoxDescription.Multiline = false;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.PasswordChar = '\0';
            this.textBoxDescription.SelectionLength = 0;
            this.textBoxDescription.SelectionStart = 0;
            this.textBoxDescription.Size = new System.Drawing.Size(224, 20);
            this.textBoxDescription.TabIndex = 2;
            this.textBoxDescription.TextLength = 32767;
            this.textBoxDescription.CustomTextChanged += new System.EventHandler(this.tagEditControl_TagsCollectionChanged);
            // 
            // tagEditControl
            // 
            this.tagEditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tagEditControl.AutoSize = true;
            this.tagEditControl.BackColor = System.Drawing.Color.Transparent;
            this.tagEditControl.Location = new System.Drawing.Point(243, 378);
            this.tagEditControl.Name = "tagEditControl";
            this.tagEditControl.Size = new System.Drawing.Size(223, 64);
            this.tagEditControl.TabIndex = 0;
            this.tagEditControl.TagsCollectionChanged += new System.EventHandler(this.tagEditControl_TagsCollectionChanged);
            // 
            // RembyVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tagEditControl);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonSave1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddToRemby);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.pictureBoxError);
            this.Controls.Add(this.videoPlayer1);
            this.Controls.Add(this.labelYT);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RembyVideo";
            this.Size = new System.Drawing.Size(473, 549);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public VideoPlayer videoPlayer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Label labelYT;
        public System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.PictureBox pictureBoxError;
        private GrayButton buttonSave1;
        private ExtendedRoundedTextBox textBoxTitle;
        private ExtendedRoundedTextBox textBoxDescription;
        public BlueButton btnAddToRemby;
        public GrayButton btnCancel;
        private TagEditControl tagEditControl;
    }
}
