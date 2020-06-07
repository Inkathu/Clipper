using RembyClipper2.DrawingTool.Editors;

namespace RembyClipper2.DrawingTool
{
	partial class CustomColorDialog : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.advancedPanel = new System.Windows.Forms.Panel();
            this.labelHtmlColor = new System.Windows.Forms.Label();
            this.textBoxHtmlColor = new RembyClipper2.Base.ExtendedRoundedTextBox();
            this.redUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.greenUpDown = new System.Windows.Forms.NumericUpDown();
            this.blueUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new RembyClipper2.Base.GrayButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorPanel = new RembyClipper2.DrawingTool.Editors.DoubleBufferedPanel();
            this.labelRecentColors = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.alphaUpDown = new System.Windows.Forms.NumericUpDown();
            this.grayPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.advancedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grayPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(227)))));
            this.grayPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.panel4);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayPanel1.DrawRoundedBorder = false;
            this.grayPanel1.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel1.Location = new System.Drawing.Point(0, 0);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.RoundingRadius = 1;
            this.grayPanel1.ShowBorder = false;
            this.grayPanel1.Size = new System.Drawing.Size(372, 174);
            this.grayPanel1.TabIndex = 20;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.advancedPanel);
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.btnApply);
            this.panel4.Controls.Add(this.trackBar1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.colorPanel);
            this.panel4.Controls.Add(this.labelRecentColors);
            this.panel4.Controls.Add(this.labelOpacity);
            this.panel4.Controls.Add(this.alphaUpDown);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 173);
            this.panel4.TabIndex = 0;
            // 
            // advancedPanel
            // 
            this.advancedPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.advancedPanel.BackColor = System.Drawing.Color.Transparent;
            this.advancedPanel.Controls.Add(this.labelHtmlColor);
            this.advancedPanel.Controls.Add(this.textBoxHtmlColor);
            this.advancedPanel.Controls.Add(this.redUpDown);
            this.advancedPanel.Controls.Add(this.labelRed);
            this.advancedPanel.Controls.Add(this.labelBlue);
            this.advancedPanel.Controls.Add(this.labelGreen);
            this.advancedPanel.Controls.Add(this.greenUpDown);
            this.advancedPanel.Controls.Add(this.blueUpDown);
            this.advancedPanel.Location = new System.Drawing.Point(305, 56);
            this.advancedPanel.Name = "advancedPanel";
            this.advancedPanel.Size = new System.Drawing.Size(18, 10);
            this.advancedPanel.TabIndex = 2;
            this.advancedPanel.Visible = false;
            // 
            // labelHtmlColor
            // 
            this.labelHtmlColor.BackColor = System.Drawing.Color.Transparent;
            this.labelHtmlColor.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.labelHtmlColor.Location = new System.Drawing.Point(3, 1);
            this.labelHtmlColor.Name = "labelHtmlColor";
            this.labelHtmlColor.Size = new System.Drawing.Size(78, 13);
            this.labelHtmlColor.TabIndex = 2;
            this.labelHtmlColor.Text = "#HTML color:";
            // 
            // textBoxHtmlColor
            // 
            this.textBoxHtmlColor.Enabled = false;
            this.textBoxHtmlColor.InnerText = "";
            this.textBoxHtmlColor.Location = new System.Drawing.Point(5, 16);
            this.textBoxHtmlColor.MinimumSize = new System.Drawing.Size(0, 20);
            this.textBoxHtmlColor.Multiline = false;
            this.textBoxHtmlColor.Name = "textBoxHtmlColor";
            this.textBoxHtmlColor.PasswordChar = '\0';
            this.textBoxHtmlColor.SelectionLength = 0;
            this.textBoxHtmlColor.SelectionStart = 0;
            this.textBoxHtmlColor.Size = new System.Drawing.Size(103, 20);
            this.textBoxHtmlColor.TabIndex = 20;
            this.textBoxHtmlColor.TextLength = 0;
            this.textBoxHtmlColor.CustomTextChanged += new System.EventHandler(this.TextBoxHexadecimalTextChanged);
            this.textBoxHtmlColor.CustomKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHtmlColor_KeyPress);
            this.textBoxHtmlColor.CustomKeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            this.textBoxHtmlColor.Click += new System.EventHandler(this.TextBoxGotFocus);
            // 
            // redUpDown
            // 
            this.redUpDown.Location = new System.Drawing.Point(119, 16);
            this.redUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redUpDown.Name = "redUpDown";
            this.redUpDown.Size = new System.Drawing.Size(50, 20);
            this.redUpDown.TabIndex = 15;
            this.redUpDown.ValueChanged += new System.EventHandler(this.RGBChanged);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.BackColor = System.Drawing.Color.Transparent;
            this.labelRed.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.labelRed.Location = new System.Drawing.Point(116, 1);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(38, 13);
            this.labelRed.TabIndex = 4;
            this.labelRed.Text = "#Red:";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.BackColor = System.Drawing.Color.Transparent;
            this.labelBlue.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.labelBlue.Location = new System.Drawing.Point(234, 2);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(39, 13);
            this.labelBlue.TabIndex = 6;
            this.labelBlue.Text = "#Blue:";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.BackColor = System.Drawing.Color.Transparent;
            this.labelGreen.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.labelGreen.Location = new System.Drawing.Point(175, 1);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(48, 13);
            this.labelGreen.TabIndex = 5;
            this.labelGreen.Text = "#Green:";
            // 
            // greenUpDown
            // 
            this.greenUpDown.Location = new System.Drawing.Point(178, 16);
            this.greenUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenUpDown.Name = "greenUpDown";
            this.greenUpDown.Size = new System.Drawing.Size(50, 20);
            this.greenUpDown.TabIndex = 15;
            this.greenUpDown.ValueChanged += new System.EventHandler(this.RGBChanged);
            // 
            // blueUpDown
            // 
            this.blueUpDown.Location = new System.Drawing.Point(237, 16);
            this.blueUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueUpDown.Name = "blueUpDown";
            this.blueUpDown.Size = new System.Drawing.Size(50, 20);
            this.blueUpDown.TabIndex = 15;
            this.blueUpDown.ValueChanged += new System.EventHandler(this.RGBChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(221, 146);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 23);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Advanced";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 167);
            this.panel1.TabIndex = 16;
            // 
            // btnApply
            // 
            this.btnApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnApply.ButtonCaption = "#Apply";
            this.btnApply.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnApply.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(199)))));
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnApply.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.FontColor = System.Drawing.Color.Black;
            this.btnApply.Image = null;
            this.btnApply.ImageSize = new System.Drawing.Size(20, 20);
            this.btnApply.Location = new System.Drawing.Point(284, 144);
            this.btnApply.Name = "btnApply";
            this.btnApply.RoundingRadius = 10;
            this.btnApply.Size = new System.Drawing.Size(85, 25);
            this.btnApply.TabIndex = 19;
            this.btnApply.Text = "#Apply";
            this.btnApply.TopGlowLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.trackBar1.Location = new System.Drawing.Point(210, 72);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(113, 20);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(207, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 17);
            this.panel2.TabIndex = 17;
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel.Location = new System.Drawing.Point(210, 4);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(159, 51);
            this.colorPanel.TabIndex = 1;
            // 
            // labelRecentColors
            // 
            this.labelRecentColors.BackColor = System.Drawing.Color.Transparent;
            this.labelRecentColors.Location = new System.Drawing.Point(207, 95);
            this.labelRecentColors.Name = "labelRecentColors";
            this.labelRecentColors.Size = new System.Drawing.Size(116, 13);
            this.labelRecentColors.TabIndex = 10;
            this.labelRecentColors.Text = "#Recently used colors:";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.BackColor = System.Drawing.Color.Transparent;
            this.labelOpacity.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.labelOpacity.Location = new System.Drawing.Point(210, 56);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(56, 13);
            this.labelOpacity.TabIndex = 14;
            this.labelOpacity.Text = "#Opacity:";
            // 
            // alphaUpDown
            // 
            this.alphaUpDown.Location = new System.Drawing.Point(326, 72);
            this.alphaUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaUpDown.Name = "alphaUpDown";
            this.alphaUpDown.Size = new System.Drawing.Size(43, 20);
            this.alphaUpDown.TabIndex = 15;
            this.alphaUpDown.ValueChanged += new System.EventHandler(this.RGBChanged);
            // 
            // CustomColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(372, 174);
            this.Controls.Add(this.grayPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomColorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ColorDialog_Load);
            this.grayPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.advancedPanel.ResumeLayout(false);
            this.advancedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaUpDown)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label labelRed;
		private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.Label labelRecentColors;
        private System.Windows.Forms.Label labelHtmlColor;
        private DoubleBufferedPanel colorPanel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.NumericUpDown blueUpDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown greenUpDown;
        private System.Windows.Forms.NumericUpDown redUpDown;
        private Base.GrayButton btnApply;
        private System.Windows.Forms.NumericUpDown alphaUpDown;
        private Base.GrayPanel grayPanel1;
        private Base.ExtendedRoundedTextBox textBoxHtmlColor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel advancedPanel;
		
		

		
		
	}
}
