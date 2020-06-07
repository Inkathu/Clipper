namespace ControlsTest
{
    partial class Form1
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
            this.figureCommandsTS = new System.Windows.Forms.ToolStrip();
            this.surfaceTS = new System.Windows.Forms.ToolStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.drawingSurface1 = new RembyClipper2.DrawingTool.DrawingSurface();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // figureCommandsTS
            // 
            this.figureCommandsTS.Location = new System.Drawing.Point(0, 25);
            this.figureCommandsTS.Name = "figureCommandsTS";
            this.figureCommandsTS.Size = new System.Drawing.Size(696, 25);
            this.figureCommandsTS.TabIndex = 1;
            this.figureCommandsTS.Text = "figureCommandsTS";
            // 
            // surfaceTS
            // 
            this.surfaceTS.Location = new System.Drawing.Point(0, 0);
            this.surfaceTS.Name = "surfaceTS";
            this.surfaceTS.Size = new System.Drawing.Size(696, 25);
            this.surfaceTS.TabIndex = 2;
            this.surfaceTS.Text = "toolStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(511, 178);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 411);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(696, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // drawingSurface1
            // 
            this.drawingSurface1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingSurface1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingSurface1.CurrentBorderColor = System.Drawing.Color.Black;
            this.drawingSurface1.CurrentFillColor = System.Drawing.Color.Yellow;
            this.drawingSurface1.DefaultCreator = null;
            this.drawingSurface1.Label = this.toolStripStatusLabel1;
            this.drawingSurface1.Location = new System.Drawing.Point(0, 53);
            this.drawingSurface1.Name = "drawingSurface1";
            this.drawingSurface1.Size = new System.Drawing.Size(672, 110);
            this.drawingSurface1.TabIndex = 0;
            this.drawingSurface1.figureSelectionChanged += new RembyClipper2.DrawingTool.FigureSelectionChanged(this.drawingSurface1_figureSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(696, 433);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.figureCommandsTS);
            this.Controls.Add(this.drawingSurface1);
            this.Controls.Add(this.surfaceTS);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RembyClipper2.DrawingTool.DrawingSurface drawingSurface1;
        private System.Windows.Forms.ToolStrip figureCommandsTS;
        private System.Windows.Forms.ToolStrip surfaceTS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;




    }
}

