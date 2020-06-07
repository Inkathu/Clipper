namespace RembyClipper2.DrawingTool.Editors
{
    partial class PropertyEditor
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
            this.borderColorLabel = new System.Windows.Forms.Label();
            this.fillColorLabel = new System.Windows.Forms.Label();
            this.borderWidthlabel = new System.Windows.Forms.Label();
            this.borderOpacityLabel = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.fillOpacityLabel = new System.Windows.Forms.Label();
            this.borderTranparencyTrackBar = new System.Windows.Forms.TrackBar();
            this.fillTransparencyTrackBar = new System.Windows.Forms.TrackBar();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.browseBorderColorBtn = new System.Windows.Forms.Button();
            this.BrowseFillColorBtn = new System.Windows.Forms.Button();
            this.borderWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.fontTextBox = new System.Windows.Forms.TextBox();
            this.browseFontBtn = new System.Windows.Forms.Button();
            this.borderTransparencyTextBox = new System.Windows.Forms.TextBox();
            this.fillTransparencyTextBox = new System.Windows.Forms.TextBox();
            this.fontColorBrowseBtn = new System.Windows.Forms.Button();
            this.fontColorLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.figuresComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fontColorPanel = new RembyClipper2.DrawingTool.Editors.DoubleBufferedPanel();
            this.borderColorPanel = new RembyClipper2.DrawingTool.Editors.DoubleBufferedPanel();
            this.fillColorPanel = new RembyClipper2.DrawingTool.Editors.DoubleBufferedPanel();
            ((System.ComponentModel.ISupportInitialize)(this.borderTranparencyTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillTransparencyTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderColorLabel
            // 
            this.borderColorLabel.Location = new System.Drawing.Point(7, 68);
            this.borderColorLabel.Name = "borderColorLabel";
            this.borderColorLabel.Size = new System.Drawing.Size(96, 29);
            this.borderColorLabel.TabIndex = 0;
            this.borderColorLabel.Text = "Border color:";
            this.borderColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fillColorLabel
            // 
            this.fillColorLabel.Location = new System.Drawing.Point(7, 158);
            this.fillColorLabel.Name = "fillColorLabel";
            this.fillColorLabel.Size = new System.Drawing.Size(96, 29);
            this.fillColorLabel.TabIndex = 0;
            this.fillColorLabel.Text = "Fill color:";
            this.fillColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // borderWidthlabel
            // 
            this.borderWidthlabel.AutoSize = true;
            this.borderWidthlabel.Location = new System.Drawing.Point(7, 133);
            this.borderWidthlabel.Name = "borderWidthlabel";
            this.borderWidthlabel.Size = new System.Drawing.Size(69, 13);
            this.borderWidthlabel.TabIndex = 0;
            this.borderWidthlabel.Text = "Border width:";
            // 
            // borderOpacityLabel
            // 
            this.borderOpacityLabel.Location = new System.Drawing.Point(7, 98);
            this.borderOpacityLabel.Name = "borderOpacityLabel";
            this.borderOpacityLabel.Size = new System.Drawing.Size(96, 29);
            this.borderOpacityLabel.TabIndex = 0;
            this.borderOpacityLabel.Text = "Border opacity:";
            this.borderOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(7, 220);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(31, 13);
            this.fontLabel.TabIndex = 0;
            this.fontLabel.Text = "Font:";
            // 
            // fillOpacityLabel
            // 
            this.fillOpacityLabel.Location = new System.Drawing.Point(7, 185);
            this.fillOpacityLabel.Name = "fillOpacityLabel";
            this.fillOpacityLabel.Size = new System.Drawing.Size(96, 29);
            this.fillOpacityLabel.TabIndex = 0;
            this.fillOpacityLabel.Text = "Fill opacity:";
            this.fillOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // borderTranparencyTrackBar
            // 
            this.borderTranparencyTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderTranparencyTrackBar.AutoSize = false;
            this.borderTranparencyTrackBar.Location = new System.Drawing.Point(109, 102);
            this.borderTranparencyTrackBar.Maximum = 255;
            this.borderTranparencyTrackBar.Name = "borderTranparencyTrackBar";
            this.borderTranparencyTrackBar.Size = new System.Drawing.Size(179, 20);
            this.borderTranparencyTrackBar.TabIndex = 1;
            this.borderTranparencyTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.borderTranparencyTrackBar.Value = 1;
            this.borderTranparencyTrackBar.ValueChanged += new System.EventHandler(this.borderTranparencyTrackBar_ValueChanged);
            // 
            // fillTransparencyTrackBar
            // 
            this.fillTransparencyTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fillTransparencyTrackBar.AutoSize = false;
            this.fillTransparencyTrackBar.Location = new System.Drawing.Point(109, 189);
            this.fillTransparencyTrackBar.Maximum = 255;
            this.fillTransparencyTrackBar.Name = "fillTransparencyTrackBar";
            this.fillTransparencyTrackBar.Size = new System.Drawing.Size(179, 20);
            this.fillTransparencyTrackBar.TabIndex = 1;
            this.fillTransparencyTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fillTransparencyTrackBar.Value = 1;
            this.fillTransparencyTrackBar.ValueChanged += new System.EventHandler(this.fillTransparencyTrackBar_ValueChanged);
            // 
            // browseBorderColorBtn
            // 
            this.browseBorderColorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseBorderColorBtn.Location = new System.Drawing.Point(290, 72);
            this.browseBorderColorBtn.Name = "browseBorderColorBtn";
            this.browseBorderColorBtn.Size = new System.Drawing.Size(23, 21);
            this.browseBorderColorBtn.TabIndex = 3;
            this.browseBorderColorBtn.Text = "...";
            this.browseBorderColorBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.browseBorderColorBtn.UseVisualStyleBackColor = true;
            this.browseBorderColorBtn.Click += new System.EventHandler(this.BrowseBorderColorBtnClick);
            // 
            // BrowseFillColorBtn
            // 
            this.BrowseFillColorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseFillColorBtn.Location = new System.Drawing.Point(290, 162);
            this.BrowseFillColorBtn.Name = "BrowseFillColorBtn";
            this.BrowseFillColorBtn.Size = new System.Drawing.Size(23, 21);
            this.BrowseFillColorBtn.TabIndex = 3;
            this.BrowseFillColorBtn.Text = "...";
            this.BrowseFillColorBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BrowseFillColorBtn.UseVisualStyleBackColor = true;
            this.BrowseFillColorBtn.Click += new System.EventHandler(this.BrowseFillColorBtn_Click);
            // 
            // borderWidthUpDown
            // 
            this.borderWidthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderWidthUpDown.Location = new System.Drawing.Point(117, 133);
            this.borderWidthUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.borderWidthUpDown.Name = "borderWidthUpDown";
            this.borderWidthUpDown.Size = new System.Drawing.Size(168, 20);
            this.borderWidthUpDown.TabIndex = 4;
            this.borderWidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.borderWidthUpDown.ValueChanged += new System.EventHandler(this.borderWidthUpDown_ValueChanged);
            // 
            // fontTextBox
            // 
            this.fontTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.fontTextBox.Location = new System.Drawing.Point(117, 216);
            this.fontTextBox.Name = "fontTextBox";
            this.fontTextBox.ReadOnly = true;
            this.fontTextBox.Size = new System.Drawing.Size(168, 20);
            this.fontTextBox.TabIndex = 5;
            // 
            // browseFontBtn
            // 
            this.browseFontBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseFontBtn.Location = new System.Drawing.Point(290, 216);
            this.browseFontBtn.Name = "browseFontBtn";
            this.browseFontBtn.Size = new System.Drawing.Size(23, 21);
            this.browseFontBtn.TabIndex = 3;
            this.browseFontBtn.Text = "...";
            this.browseFontBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.browseFontBtn.UseVisualStyleBackColor = true;
            this.browseFontBtn.Click += new System.EventHandler(this.browseFontBtn_Click);
            // 
            // borderTransparencyTextBox
            // 
            this.borderTransparencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.borderTransparencyTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.borderTransparencyTextBox.Location = new System.Drawing.Point(290, 102);
            this.borderTransparencyTextBox.Name = "borderTransparencyTextBox";
            this.borderTransparencyTextBox.ReadOnly = true;
            this.borderTransparencyTextBox.Size = new System.Drawing.Size(24, 20);
            this.borderTransparencyTextBox.TabIndex = 6;
            this.borderTransparencyTextBox.Text = "255";
            // 
            // fillTransparencyTextBox
            // 
            this.fillTransparencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillTransparencyTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.fillTransparencyTextBox.Location = new System.Drawing.Point(290, 189);
            this.fillTransparencyTextBox.Name = "fillTransparencyTextBox";
            this.fillTransparencyTextBox.ReadOnly = true;
            this.fillTransparencyTextBox.Size = new System.Drawing.Size(24, 20);
            this.fillTransparencyTextBox.TabIndex = 6;
            this.fillTransparencyTextBox.Text = "255";
            // 
            // fontColorBrowseBtn
            // 
            this.fontColorBrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontColorBrowseBtn.Location = new System.Drawing.Point(290, 247);
            this.fontColorBrowseBtn.Name = "fontColorBrowseBtn";
            this.fontColorBrowseBtn.Size = new System.Drawing.Size(23, 21);
            this.fontColorBrowseBtn.TabIndex = 9;
            this.fontColorBrowseBtn.Text = "...";
            this.fontColorBrowseBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.fontColorBrowseBtn.UseVisualStyleBackColor = true;
            this.fontColorBrowseBtn.Click += new System.EventHandler(this.fontColorBrowseBtn_Click);
            // 
            // fontColorLabel
            // 
            this.fontColorLabel.AutoSize = true;
            this.fontColorLabel.Location = new System.Drawing.Point(8, 247);
            this.fontColorLabel.Name = "fontColorLabel";
            this.fontColorLabel.Size = new System.Drawing.Size(57, 13);
            this.fontColorLabel.TabIndex = 7;
            this.fontColorLabel.Text = "Font color:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(7, 46);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.nameTextBox.Location = new System.Drawing.Point(117, 42);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(168, 20);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
            // 
            // figuresComboBox
            // 
            this.figuresComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.figuresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figuresComboBox.FormattingEnabled = true;
            this.figuresComboBox.Location = new System.Drawing.Point(7, 8);
            this.figuresComboBox.Name = "figuresComboBox";
            this.figuresComboBox.Size = new System.Drawing.Size(306, 21);
            this.figuresComboBox.TabIndex = 10;
            this.figuresComboBox.SelectedIndexChanged += new System.EventHandler(this.FiguresComboBoxSelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.borderColorLabel);
            this.panel1.Controls.Add(this.fontColorBrowseBtn);
            this.panel1.Controls.Add(this.fillColorLabel);
            this.panel1.Controls.Add(this.fontColorPanel);
            this.panel1.Controls.Add(this.borderWidthlabel);
            this.panel1.Controls.Add(this.fontColorLabel);
            this.panel1.Controls.Add(this.borderOpacityLabel);
            this.panel1.Controls.Add(this.fillTransparencyTextBox);
            this.panel1.Controls.Add(this.fillOpacityLabel);
            this.panel1.Controls.Add(this.borderTransparencyTextBox);
            this.panel1.Controls.Add(this.fontLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.borderTranparencyTrackBar);
            this.panel1.Controls.Add(this.fontTextBox);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.borderWidthUpDown);
            this.panel1.Controls.Add(this.fillTransparencyTrackBar);
            this.panel1.Controls.Add(this.browseFontBtn);
            this.panel1.Controls.Add(this.borderColorPanel);
            this.panel1.Controls.Add(this.BrowseFillColorBtn);
            this.panel1.Controls.Add(this.browseBorderColorBtn);
            this.panel1.Controls.Add(this.fillColorPanel);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 277);
            this.panel1.TabIndex = 11;
            this.panel1.MouseEnter += new System.EventHandler(this.PropertyEditor_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.PropertyEditor_MouseLeave);
            // 
            // fontColorPanel
            // 
            this.fontColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontColorPanel.Location = new System.Drawing.Point(117, 247);
            this.fontColorPanel.Name = "fontColorPanel";
            this.fontColorPanel.Size = new System.Drawing.Size(168, 21);
            this.fontColorPanel.TabIndex = 8;
            this.fontColorPanel.Click += new System.EventHandler(this.FontColorPanelClick);
            // 
            // borderColorPanel
            // 
            this.borderColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderColorPanel.Location = new System.Drawing.Point(117, 72);
            this.borderColorPanel.Name = "borderColorPanel";
            this.borderColorPanel.Size = new System.Drawing.Size(168, 21);
            this.borderColorPanel.TabIndex = 2;
            this.borderColorPanel.Click += new System.EventHandler(this.borderColorPanel_Click);
            // 
            // fillColorPanel
            // 
            this.fillColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fillColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fillColorPanel.Location = new System.Drawing.Point(117, 162);
            this.fillColorPanel.Name = "fillColorPanel";
            this.fillColorPanel.Size = new System.Drawing.Size(168, 21);
            this.fillColorPanel.TabIndex = 2;
            this.fillColorPanel.Click += new System.EventHandler(this.fillColorPanel_Click);
            // 
            // PropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 276);
            this.Controls.Add(this.figuresComboBox);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PropertyEditor";
            this.Text = "Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertyEditor_FormClosing);
            this.Leave += new System.EventHandler(this.PropertyEditor_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PropertyEditor_MouseDown);
            this.MouseEnter += new System.EventHandler(this.PropertyEditor_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.PropertyEditor_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PropertyEditor_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.borderTranparencyTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillTransparencyTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label borderColorLabel;
        private System.Windows.Forms.Label fillColorLabel;
        private System.Windows.Forms.Label borderWidthlabel;
        private System.Windows.Forms.Label borderOpacityLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Label fillOpacityLabel;
        private System.Windows.Forms.TrackBar borderTranparencyTrackBar;
        private System.Windows.Forms.TrackBar fillTransparencyTrackBar;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private DoubleBufferedPanel borderColorPanel;
        private System.Windows.Forms.Button browseBorderColorBtn;
        private DoubleBufferedPanel fillColorPanel;
        private System.Windows.Forms.Button BrowseFillColorBtn;
        private System.Windows.Forms.NumericUpDown borderWidthUpDown;
        private System.Windows.Forms.TextBox fontTextBox;
        private System.Windows.Forms.Button browseFontBtn;
        private System.Windows.Forms.TextBox borderTransparencyTextBox;
        private System.Windows.Forms.TextBox fillTransparencyTextBox;
        private System.Windows.Forms.Button fontColorBrowseBtn;
        private DoubleBufferedPanel fontColorPanel;
        private System.Windows.Forms.Label fontColorLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox figuresComboBox;
        private System.Windows.Forms.Panel panel1;
    }
}