namespace RembyClipper2.Forms
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOrangeClear = new RembyClipper2.Base.ButtonOrange();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxBitsPerSample = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBitrate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSampleFreq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxChannels = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxYTPrivate = new System.Windows.Forms.CheckBox();
            this.textBoxFrameRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxCaptureFPS = new System.Windows.Forms.ComboBox();
            this.comboBoxCaptureResolution = new System.Windows.Forms.ComboBox();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonOrangeLoadXML = new RembyClipper2.Base.ButtonOrange();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxLegacy = new System.Windows.Forms.CheckBox();
            this.textBoxMediaStore = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRembyURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonBlack1 = new RembyClipper2.Base.ButtonBlack();
            this.buttonOrangeSave = new RembyClipper2.Base.ButtonOrange();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(405, 383);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::RembyClipper2.Properties.Resources.stdbg;
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(397, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkBox1.Location = new System.Drawing.Point(8, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(187, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Start automatically with Windows?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOrangeClear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remby account";
            // 
            // buttonOrangeClear
            // 
            this.buttonOrangeClear.BackColor = System.Drawing.Color.Transparent;
            this.buttonOrangeClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOrangeClear.BackgroundImage")));
            this.buttonOrangeClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOrangeClear.Location = new System.Drawing.Point(221, 19);
            this.buttonOrangeClear.MinimumSize = new System.Drawing.Size(67, 30);
            this.buttonOrangeClear.Name = "buttonOrangeClear";
            this.buttonOrangeClear.Size = new System.Drawing.Size(131, 30);
            this.buttonOrangeClear.TabIndex = 1;
            this.buttonOrangeClear.Click += new System.EventHandler(this.buttonOrangeClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logged in as:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::RembyClipper2.Properties.Resources.stdbg;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(397, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Screenshot";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::RembyClipper2.Properties.Resources.stdbg;
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(397, 353);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Screen video";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxBitsPerSample);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxBitrate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxSampleFreq);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxChannels);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.Color.Silver;
            this.groupBox3.Location = new System.Drawing.Point(8, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 168);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio";
            // 
            // textBoxBitsPerSample
            // 
            this.textBoxBitsPerSample.Location = new System.Drawing.Point(111, 107);
            this.textBoxBitsPerSample.Name = "textBoxBitsPerSample";
            this.textBoxBitsPerSample.Size = new System.Drawing.Size(94, 20);
            this.textBoxBitsPerSample.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Bits per Sample";
            // 
            // textBoxBitrate
            // 
            this.textBoxBitrate.Location = new System.Drawing.Point(111, 81);
            this.textBoxBitrate.Name = "textBoxBitrate";
            this.textBoxBitrate.Size = new System.Drawing.Size(94, 20);
            this.textBoxBitrate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bitrate";
            // 
            // textBoxSampleFreq
            // 
            this.textBoxSampleFreq.Location = new System.Drawing.Point(111, 55);
            this.textBoxSampleFreq.Name = "textBoxSampleFreq";
            this.textBoxSampleFreq.Size = new System.Drawing.Size(94, 20);
            this.textBoxSampleFreq.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sample frequency";
            // 
            // textBoxChannels
            // 
            this.textBoxChannels.Location = new System.Drawing.Point(111, 29);
            this.textBoxChannels.Name = "textBoxChannels";
            this.textBoxChannels.Size = new System.Drawing.Size(94, 20);
            this.textBoxChannels.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Channels";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxYTPrivate);
            this.groupBox2.Controls.Add(this.textBoxFrameRate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 86);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video";
            // 
            // checkBoxYTPrivate
            // 
            this.checkBoxYTPrivate.AutoSize = true;
            this.checkBoxYTPrivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxYTPrivate.Location = new System.Drawing.Point(9, 48);
            this.checkBoxYTPrivate.Name = "checkBoxYTPrivate";
            this.checkBoxYTPrivate.Size = new System.Drawing.Size(196, 17);
            this.checkBoxYTPrivate.TabIndex = 2;
            this.checkBoxYTPrivate.Text = "Mark video as private on YouTube?";
            this.checkBoxYTPrivate.UseVisualStyleBackColor = true;
            // 
            // textBoxFrameRate
            // 
            this.textBoxFrameRate.Location = new System.Drawing.Point(111, 22);
            this.textBoxFrameRate.Name = "textBoxFrameRate";
            this.textBoxFrameRate.Size = new System.Drawing.Size(94, 20);
            this.textBoxFrameRate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Framerate";
            // 
            // tabPage5
            // 
            this.tabPage5.BackgroundImage = global::RembyClipper2.Properties.Resources.stdbg;
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(397, 353);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Camera";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxCaptureFPS);
            this.groupBox5.Controls.Add(this.comboBoxCaptureResolution);
            this.groupBox5.Controls.Add(this.comboBoxDevice);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.ForeColor = System.Drawing.Color.Silver;
            this.groupBox5.Location = new System.Drawing.Point(8, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(381, 117);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Camera";
            // 
            // comboBoxCaptureFPS
            // 
            this.comboBoxCaptureFPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptureFPS.FormattingEnabled = true;
            this.comboBoxCaptureFPS.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "10",
            "15",
            "20",
            "22",
            "25",
            "30",
            "33",
            "60"});
            this.comboBoxCaptureFPS.Location = new System.Drawing.Point(113, 76);
            this.comboBoxCaptureFPS.Name = "comboBoxCaptureFPS";
            this.comboBoxCaptureFPS.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCaptureFPS.TabIndex = 9;
            // 
            // comboBoxCaptureResolution
            // 
            this.comboBoxCaptureResolution.AutoCompleteCustomSource.AddRange(new string[] {
            "160x120",
            "320x240",
            "640x480",
            "800x600",
            "1024x768",
            "1280x720",
            "1920x1080"});
            this.comboBoxCaptureResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptureResolution.FormattingEnabled = true;
            this.comboBoxCaptureResolution.Items.AddRange(new object[] {
            "160x120",
            "320x240",
            "640x480",
            "800x600",
            "1024x768",
            "1280x720",
            "1920x1080"});
            this.comboBoxCaptureResolution.Location = new System.Drawing.Point(113, 49);
            this.comboBoxCaptureResolution.Name = "comboBoxCaptureResolution";
            this.comboBoxCaptureResolution.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCaptureResolution.TabIndex = 8;
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(113, 22);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDevice.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Frame rate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Capture resolution";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Device";
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImage = global::RembyClipper2.Properties.Resources.stdbg;
            this.tabPage4.Controls.Add(this.buttonOrangeLoadXML);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.checkBoxLegacy);
            this.tabPage4.Controls.Add(this.textBoxMediaStore);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.textBoxRembyURL);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(397, 353);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Internal";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonOrangeLoadXML
            // 
            this.buttonOrangeLoadXML.BackColor = System.Drawing.Color.Transparent;
            this.buttonOrangeLoadXML.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOrangeLoadXML.BackgroundImage")));
            this.buttonOrangeLoadXML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOrangeLoadXML.Location = new System.Drawing.Point(301, 317);
            this.buttonOrangeLoadXML.MinimumSize = new System.Drawing.Size(60, 30);
            this.buttonOrangeLoadXML.Name = "buttonOrangeLoadXML";
            this.buttonOrangeLoadXML.Size = new System.Drawing.Size(84, 30);
            this.buttonOrangeLoadXML.TabIndex = 10;
            this.buttonOrangeLoadXML.Click += new System.EventHandler(this.buttonOrangeLoadXML_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.ForeColor = System.Drawing.Color.Silver;
            this.groupBox4.Location = new System.Drawing.Point(13, 60);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(372, 251);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Current configuration file";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(360, 226);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // checkBoxLegacy
            // 
            this.checkBoxLegacy.AutoSize = true;
            this.checkBoxLegacy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxLegacy.ForeColor = System.Drawing.Color.Silver;
            this.checkBoxLegacy.Location = new System.Drawing.Point(286, 34);
            this.checkBoxLegacy.Name = "checkBoxLegacy";
            this.checkBoxLegacy.Size = new System.Drawing.Size(99, 17);
            this.checkBoxLegacy.TabIndex = 8;
            this.checkBoxLegacy.Text = "Legacy storage";
            this.checkBoxLegacy.UseVisualStyleBackColor = true;
            // 
            // textBoxMediaStore
            // 
            this.textBoxMediaStore.Location = new System.Drawing.Point(114, 34);
            this.textBoxMediaStore.Name = "textBoxMediaStore";
            this.textBoxMediaStore.Size = new System.Drawing.Size(166, 20);
            this.textBoxMediaStore.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(14, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Media store";
            // 
            // textBoxRembyURL
            // 
            this.textBoxRembyURL.Location = new System.Drawing.Point(114, 8);
            this.textBoxRembyURL.Name = "textBoxRembyURL";
            this.textBoxRembyURL.Size = new System.Drawing.Size(275, 20);
            this.textBoxRembyURL.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(14, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Remby URL";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(28, 19);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonBlack1
            // 
            this.buttonBlack1.BackColor = System.Drawing.Color.Transparent;
            this.buttonBlack1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBlack1.BackgroundImage")));
            this.buttonBlack1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBlack1.Location = new System.Drawing.Point(316, 433);
            this.buttonBlack1.MinimumSize = new System.Drawing.Size(67, 30);
            this.buttonBlack1.Name = "buttonBlack1";
            this.buttonBlack1.Size = new System.Drawing.Size(77, 30);
            this.buttonBlack1.TabIndex = 3;
            this.buttonBlack1.Click += new System.EventHandler(this.buttonBlack1_Click);
            // 
            // buttonOrangeSave
            // 
            this.buttonOrangeSave.BackColor = System.Drawing.Color.Transparent;
            this.buttonOrangeSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOrangeSave.BackgroundImage")));
            this.buttonOrangeSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOrangeSave.Location = new System.Drawing.Point(240, 433);
            this.buttonOrangeSave.MinimumSize = new System.Drawing.Size(60, 30);
            this.buttonOrangeSave.Name = "buttonOrangeSave";
            this.buttonOrangeSave.Size = new System.Drawing.Size(60, 30);
            this.buttonOrangeSave.TabIndex = 2;
            this.buttonOrangeSave.Click += new System.EventHandler(this.buttonOrangeSave_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 480);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonBlack1);
            this.Controls.Add(this.buttonOrangeSave);
            this.DoubleBuffered = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.Controls.SetChildIndex(this.buttonOrangeSave, 0);
            this.Controls.SetChildIndex(this.buttonBlack1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList imageList1;
        private Base.ButtonBlack buttonBlack1;
        private Base.ButtonOrange buttonOrangeSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private Base.ButtonOrange buttonOrangeClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFrameRate;
        private System.Windows.Forms.CheckBox checkBoxYTPrivate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxBitsPerSample;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBitrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSampleFreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxChannels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox checkBoxLegacy;
        private System.Windows.Forms.TextBox textBoxMediaStore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRembyURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Base.ButtonOrange buttonOrangeLoadXML;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxCaptureFPS;
        private System.Windows.Forms.ComboBox comboBoxCaptureResolution;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}