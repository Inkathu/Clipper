using RembyClipper2.Base;

namespace RembyClipper2.Forms
{
    partial class FormHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistory));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("History", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item 1"}, 0, System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(120))))), System.Drawing.Color.Empty, new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.postOnFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tweetItOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortenURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.changeTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.refreshPictureBox = new System.Windows.Forms.PictureBox();
            this.panelNewTags = new RembyClipper2.Base.GrayPanel();
            this.autoCompleteTextBox1 = new RembyClipper2.Base.TagsCombo();
            this.buttonBlackTagCancel = new RembyClipper2.Base.GrayButton();
            this.buttonOrangeTagSave = new RembyClipper2.Base.BlueButton();
            this.labelLoggedIn = new System.Windows.Forms.Label();
            this.listView1 = new RembyClipper2.Base.BaseListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.expandListButton = new RembyClipper2.Base.GrayButton();
            this.itemsCountLabel = new System.Windows.Forms.Label();
            this.changeTagsButton = new RembyClipper2.Base.GrayButton();
            this.buttonBlack1 = new RembyClipper2.Base.GrayButton();
            this.googlePictureBox = new System.Windows.Forms.PictureBox();
            this.faceBookPictureBox = new System.Windows.Forms.PictureBox();
            this.twitterPictureBox = new System.Windows.Forms.PictureBox();
            this.shareThisLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new RembyClipper2.Base.GrayToolStrip();
            this.showLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox)).BeginInit();
            this.panelNewTags.SuspendLayout();
            this.grayPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.googlePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceBookPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postOnFacebookToolStripMenuItem,
            this.tweetItOnTwitterToolStripMenuItem,
            this.shortenURLToolStripMenuItem,
            this.toolStripSeparator3,
            this.changeTagsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 98);
            // 
            // postOnFacebookToolStripMenuItem
            // 
            this.postOnFacebookToolStripMenuItem.Image = global::RembyClipper2.Properties.Resources.small_facebook_icon;
            this.postOnFacebookToolStripMenuItem.Name = "postOnFacebookToolStripMenuItem";
            this.postOnFacebookToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.postOnFacebookToolStripMenuItem.Tag = "fb";
            this.postOnFacebookToolStripMenuItem.Text = "Post on Facebook";
            this.postOnFacebookToolStripMenuItem.Click += new System.EventHandler(this.postOnFacebookToolStripMenuItem_Click);
            // 
            // tweetItOnTwitterToolStripMenuItem
            // 
            this.tweetItOnTwitterToolStripMenuItem.Image = global::RembyClipper2.Properties.Resources.twitter_icon;
            this.tweetItOnTwitterToolStripMenuItem.Name = "tweetItOnTwitterToolStripMenuItem";
            this.tweetItOnTwitterToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.tweetItOnTwitterToolStripMenuItem.Tag = "twitter";
            this.tweetItOnTwitterToolStripMenuItem.Text = "Tweet it on Twitter";
            this.tweetItOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.postOnFacebookToolStripMenuItem_Click);
            // 
            // shortenURLToolStripMenuItem
            // 
            this.shortenURLToolStripMenuItem.Image = global::RembyClipper2.Properties.Resources.icon_google_small;
            this.shortenURLToolStripMenuItem.Name = "shortenURLToolStripMenuItem";
            this.shortenURLToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.shortenURLToolStripMenuItem.Tag = "google";
            this.shortenURLToolStripMenuItem.Text = "Share Item";
            this.shortenURLToolStripMenuItem.Click += new System.EventHandler(this.postOnFacebookToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // changeTagsToolStripMenuItem
            // 
            this.changeTagsToolStripMenuItem.Name = "changeTagsToolStripMenuItem";
            this.changeTagsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.changeTagsToolStripMenuItem.Text = "Change tags";
            this.changeTagsToolStripMenuItem.Click += new System.EventHandler(this.changeTagsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Photo_big.png");
            this.imageList1.Images.SetKeyName(1, "Video_big.png");
            // 
            // refreshPictureBox
            // 
            this.refreshPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.refreshPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.refreshPictureBox.Image = global::RembyClipper2.NewDesign.ajax_loader;
            this.refreshPictureBox.Location = new System.Drawing.Point(155, 189);
            this.refreshPictureBox.Name = "refreshPictureBox";
            this.refreshPictureBox.Size = new System.Drawing.Size(105, 100);
            this.refreshPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.refreshPictureBox.TabIndex = 10;
            this.refreshPictureBox.TabStop = false;
            this.refreshPictureBox.Visible = false;
            // 
            // panelNewTags
            // 
            this.panelNewTags.BackgroundImage = global::RembyClipper2.Properties.Resources.Form_background;
            this.panelNewTags.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.panelNewTags.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.panelNewTags.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.panelNewTags.Controls.Add(this.autoCompleteTextBox1);
            this.panelNewTags.Controls.Add(this.buttonBlackTagCancel);
            this.panelNewTags.Controls.Add(this.buttonOrangeTagSave);
            this.panelNewTags.Controls.Add(this.labelLoggedIn);
            this.panelNewTags.DrawRoundedBorder = true;
            this.panelNewTags.Location = new System.Drawing.Point(22, 48);
            this.panelNewTags.Name = "panelNewTags";
            this.panelNewTags.RoundingRadius = 10;
            this.panelNewTags.ShowBorder = true;
            this.panelNewTags.Size = new System.Drawing.Size(371, 147);
            this.panelNewTags.TabIndex = 11;
            this.panelNewTags.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelNewTags.Visible = false;
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.BackColor = System.Drawing.Color.DimGray;
            this.autoCompleteTextBox1.CustomText = "";
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(74, 55);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(256, 21);
            this.autoCompleteTextBox1.TabIndex = 0;
            // 
            // buttonBlackTagCancel
            // 
            this.buttonBlackTagCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBlackTagCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonBlackTagCancel.ButtonCaption = "*Cancel";
            this.buttonBlackTagCancel.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonBlackTagCancel.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonBlackTagCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonBlackTagCancel.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBlackTagCancel.FontColor = System.Drawing.Color.Black;
            this.buttonBlackTagCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonBlackTagCancel.Image = null;
            this.buttonBlackTagCancel.ImageSize = new System.Drawing.Size(20, 20);
            this.buttonBlackTagCancel.Location = new System.Drawing.Point(250, 102);
            this.buttonBlackTagCancel.Name = "buttonBlackTagCancel";
            this.buttonBlackTagCancel.RoundingRadius = 10;
            this.buttonBlackTagCancel.Size = new System.Drawing.Size(75, 29);
            this.buttonBlackTagCancel.TabIndex = 2;
            this.buttonBlackTagCancel.Text = "*Cancel";
            this.buttonBlackTagCancel.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonBlackTagCancel.UseVisualStyleBackColor = false;
            this.buttonBlackTagCancel.Click += new System.EventHandler(this.buttonBlackTagCancel_Click);
            // 
            // buttonOrangeTagSave
            // 
            this.buttonOrangeTagSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(136)))), ((int)(((byte)(213)))));
            this.buttonOrangeTagSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.buttonOrangeTagSave.ButtonCaption = "*Save";
            this.buttonOrangeTagSave.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(153)))), ((int)(((byte)(229)))));
            this.buttonOrangeTagSave.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(189)))));
            this.buttonOrangeTagSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonOrangeTagSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrangeTagSave.FontColor = System.Drawing.Color.White;
            this.buttonOrangeTagSave.ForeColor = System.Drawing.Color.White;
            this.buttonOrangeTagSave.Image = null;
            this.buttonOrangeTagSave.ImageSize = new System.Drawing.Size(20, 20);
            this.buttonOrangeTagSave.Location = new System.Drawing.Point(83, 102);
            this.buttonOrangeTagSave.Name = "buttonOrangeTagSave";
            this.buttonOrangeTagSave.RoundingRadius = 10;
            this.buttonOrangeTagSave.Size = new System.Drawing.Size(75, 29);
            this.buttonOrangeTagSave.TabIndex = 1;
            this.buttonOrangeTagSave.Text = "*Save";
            this.buttonOrangeTagSave.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(186)))), ((int)(((byte)(238)))));
            this.buttonOrangeTagSave.UseVisualStyleBackColor = false;
            this.buttonOrangeTagSave.Click += new System.EventHandler(this.buttonOrangeTagSave_Click);
            // 
            // labelLoggedIn
            // 
            this.labelLoggedIn.AutoSize = true;
            this.labelLoggedIn.BackColor = System.Drawing.Color.Transparent;
            this.labelLoggedIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoggedIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.labelLoggedIn.Location = new System.Drawing.Point(34, 59);
            this.labelLoggedIn.Name = "labelLoggedIn";
            this.labelLoggedIn.Size = new System.Drawing.Size(34, 13);
            this.labelLoggedIn.TabIndex = 15;
            this.labelLoggedIn.Text = "Tags:";
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.BackgroundImageTiled = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listViewGroup1.Header = "History";
            listViewGroup1.Name = "listViewGroup1";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 35);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(414, 371);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Scroll += new System.EventHandler(this.listView1_Scroll);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "History";
            // 
            // grayPanel1
            // 
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.expandListButton);
            this.grayPanel1.Controls.Add(this.itemsCountLabel);
            this.grayPanel1.Controls.Add(this.changeTagsButton);
            this.grayPanel1.Controls.Add(this.buttonBlack1);
            this.grayPanel1.Controls.Add(this.googlePictureBox);
            this.grayPanel1.Controls.Add(this.faceBookPictureBox);
            this.grayPanel1.Controls.Add(this.twitterPictureBox);
            this.grayPanel1.Controls.Add(this.shareThisLabel);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.Location = new System.Drawing.Point(0, 406);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(414, 73);
            this.grayPanel1.TabIndex = 2;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // expandListButton
            // 
            this.expandListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.expandListButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.expandListButton.ButtonCaption = "More";
            this.expandListButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.expandListButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.expandListButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.expandListButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expandListButton.FontColor = System.Drawing.Color.Black;
            this.expandListButton.Image = null;
            this.expandListButton.ImageSize = new System.Drawing.Size(20, 20);
            this.expandListButton.Location = new System.Drawing.Point(111, 5);
            this.expandListButton.Name = "expandListButton";
            this.expandListButton.RoundingRadius = 10;
            this.expandListButton.Size = new System.Drawing.Size(62, 23);
            this.expandListButton.TabIndex = 18;
            this.expandListButton.Text = "More";
            this.expandListButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.expandListButton.UseVisualStyleBackColor = true;
            this.expandListButton.Click += new System.EventHandler(this.expandListButton_Click);
            // 
            // itemsCountLabel
            // 
            this.itemsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.itemsCountLabel.AutoSize = true;
            this.itemsCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.itemsCountLabel.Location = new System.Drawing.Point(5, 10);
            this.itemsCountLabel.Name = "itemsCountLabel";
            this.itemsCountLabel.Size = new System.Drawing.Size(85, 13);
            this.itemsCountLabel.TabIndex = 17;
            this.itemsCountLabel.Text = "List: 25 from 175";
            // 
            // changeTagsButton
            // 
            this.changeTagsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeTagsButton.BackColor = System.Drawing.SystemColors.Control;
            this.changeTagsButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.changeTagsButton.ButtonCaption = "*Change tags";
            this.changeTagsButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.changeTagsButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.changeTagsButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.changeTagsButton.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeTagsButton.FontColor = System.Drawing.Color.Black;
            this.changeTagsButton.ForeColor = System.Drawing.Color.Black;
            this.changeTagsButton.Image = null;
            this.changeTagsButton.ImageSize = new System.Drawing.Size(20, 20);
            this.changeTagsButton.Location = new System.Drawing.Point(8, 38);
            this.changeTagsButton.Name = "changeTagsButton";
            this.changeTagsButton.RoundingRadius = 10;
            this.changeTagsButton.Size = new System.Drawing.Size(103, 28);
            this.changeTagsButton.TabIndex = 0;
            this.changeTagsButton.Text = "*Change tags";
            this.changeTagsButton.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.changeTagsButton.UseVisualStyleBackColor = false;
            this.changeTagsButton.Click += new System.EventHandler(this.changeTagsToolStripMenuItem_Click);
            // 
            // buttonBlack1
            // 
            this.buttonBlack1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBlack1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBlack1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.buttonBlack1.ButtonCaption = "*Close";
            this.buttonBlack1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonBlack1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.buttonBlack1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonBlack1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBlack1.FontColor = System.Drawing.Color.Black;
            this.buttonBlack1.ForeColor = System.Drawing.Color.Black;
            this.buttonBlack1.Image = null;
            this.buttonBlack1.ImageSize = new System.Drawing.Size(20, 20);
            this.buttonBlack1.Location = new System.Drawing.Point(328, 38);
            this.buttonBlack1.Name = "buttonBlack1";
            this.buttonBlack1.RoundingRadius = 10;
            this.buttonBlack1.Size = new System.Drawing.Size(75, 28);
            this.buttonBlack1.TabIndex = 1;
            this.buttonBlack1.Text = "*Close";
            this.buttonBlack1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonBlack1.UseVisualStyleBackColor = false;
            this.buttonBlack1.Click += new System.EventHandler(this.buttonBlack1_Click);
            // 
            // googlePictureBox
            // 
            this.googlePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.googlePictureBox.Image = global::RembyClipper2.NewDesign.share_icon_google;
            this.googlePictureBox.Location = new System.Drawing.Point(215, 41);
            this.googlePictureBox.Name = "googlePictureBox";
            this.googlePictureBox.Size = new System.Drawing.Size(24, 24);
            this.googlePictureBox.TabIndex = 16;
            this.googlePictureBox.TabStop = false;
            this.googlePictureBox.Tag = "google";
            this.googlePictureBox.Click += new System.EventHandler(this.postOnFacebookToolStripMenuItem_Click);
            // 
            // faceBookPictureBox
            // 
            this.faceBookPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.faceBookPictureBox.Image = global::RembyClipper2.NewDesign.share_icon_facebook;
            this.faceBookPictureBox.Location = new System.Drawing.Point(246, 41);
            this.faceBookPictureBox.Name = "faceBookPictureBox";
            this.faceBookPictureBox.Size = new System.Drawing.Size(24, 24);
            this.faceBookPictureBox.TabIndex = 16;
            this.faceBookPictureBox.TabStop = false;
            this.faceBookPictureBox.Tag = "fb";
            this.faceBookPictureBox.Click += new System.EventHandler(this.postOnFacebookToolStripMenuItem_Click);
            // 
            // twitterPictureBox
            // 
            this.twitterPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.twitterPictureBox.Image = global::RembyClipper2.NewDesign.share_icon_twitter;
            this.twitterPictureBox.Location = new System.Drawing.Point(277, 41);
            this.twitterPictureBox.Name = "twitterPictureBox";
            this.twitterPictureBox.Size = new System.Drawing.Size(24, 24);
            this.twitterPictureBox.TabIndex = 16;
            this.twitterPictureBox.TabStop = false;
            this.twitterPictureBox.Tag = "twitter";
            this.twitterPictureBox.Click += new System.EventHandler(this.postOnFacebookToolStripMenuItem_Click);
            // 
            // shareThisLabel
            // 
            this.shareThisLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shareThisLabel.BackColor = System.Drawing.Color.Transparent;
            this.shareThisLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shareThisLabel.ForeColor = System.Drawing.Color.Black;
            this.shareThisLabel.Location = new System.Drawing.Point(122, 47);
            this.shareThisLabel.Name = "shareThisLabel";
            this.shareThisLabel.Size = new System.Drawing.Size(85, 13);
            this.shareThisLabel.TabIndex = 15;
            this.shareThisLabel.Text = "Share this:";
            this.shareThisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.toolStrip1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLabel,
            this.toolStripComboBox1,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(414, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            // 
            // showLabel
            // 
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(39, 32);
            this.showLabel.Text = "Show:";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 35);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(130, 35);
            this.toolStripTextBox1.Text = "Filter on tags";
            this.toolStripTextBox1.Enter += new System.EventHandler(this.toolStripTextBox1_Enter);
            this.toolStripTextBox1.Leave += new System.EventHandler(this.toolStripTextBox1_Leave);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::RembyClipper2.NewDesign.icon_refresh;
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(33, 32);
            this.toolStripButton7.Text = "Refresh";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton7.Click += new System.EventHandler(this.refreshTSPButton_Click);
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(414, 479);
            this.Controls.Add(this.refreshPictureBox);
            this.Controls.Add(this.panelNewTags);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.grayPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(430, 513);
            this.Name = "FormHistory";
            this.Text = "History";
            this.Load += new System.EventHandler(this.FormHistory_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox)).EndInit();
            this.panelNewTags.ResumeLayout(false);
            this.panelNewTags.PerformLayout();
            this.grayPanel1.ResumeLayout(false);
            this.grayPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.googlePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceBookPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RembyClipper2.Base.BaseListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;

        private GrayToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem postOnFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tweetItOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shortenURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.PictureBox refreshPictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem changeTagsToolStripMenuItem;
        private GrayPanel panelNewTags;
        private System.Windows.Forms.Label labelLoggedIn;
        private GrayPanel grayPanel1;
        private System.Windows.Forms.Label shareThisLabel;
        private System.Windows.Forms.PictureBox googlePictureBox;
        private System.Windows.Forms.PictureBox faceBookPictureBox;
        private System.Windows.Forms.PictureBox twitterPictureBox;
        private GrayButton buttonBlackTagCancel;
        private BlueButton buttonOrangeTagSave;
        private GrayButton changeTagsButton;
        private GrayButton buttonBlack1;
        private System.Windows.Forms.ToolTip toolTip1;
        private TagsCombo autoCompleteTextBox1;
        private GrayButton expandListButton;
        private System.Windows.Forms.Label itemsCountLabel;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripLabel showLabel;
    }
}
