namespace RembyClipper2.Base
{
    partial class TagEditControl
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
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grayPanel1 = new RembyClipper2.Base.GrayPanel();
            this.tagsLP = new System.Windows.Forms.FlowLayoutPanel();
            this.tagsTB = new System.Windows.Forms.TextBox();
            this.grayPanel1.SuspendLayout();
            this.tagsLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // grayPanel1
            // 
            this.grayPanel1.AutoSize = true;
            this.grayPanel1.Color1 = System.Drawing.Color.White;
            this.grayPanel1.Color2 = System.Drawing.Color.White;
            this.grayPanel1.ColorOfBorder = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.grayPanel1.Controls.Add(this.tagsLP);
            this.grayPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayPanel1.DrawRoundedBorder = true;
            this.grayPanel1.HighLightedColor = System.Drawing.SystemColors.ControlLight;
            this.grayPanel1.Location = new System.Drawing.Point(0, 0);
            this.grayPanel1.Name = "grayPanel1";
            this.grayPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.grayPanel1.RoundingRadius = 10;
            this.grayPanel1.ShowBorder = true;
            this.grayPanel1.Size = new System.Drawing.Size(185, 43);
            this.grayPanel1.TabIndex = 1;
            this.grayPanel1.TopGlowLineColor = System.Drawing.Color.White;
            // 
            // tagsLP
            // 
            this.tagsLP.AutoScroll = true;
            this.tagsLP.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.tagsLP.BackColor = System.Drawing.Color.Transparent;
            this.tagsLP.Controls.Add(this.tagsTB);
            this.tagsLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsLP.Location = new System.Drawing.Point(3, 3);
            this.tagsLP.Name = "tagsLP";
            this.tagsLP.Size = new System.Drawing.Size(179, 37);
            this.tagsLP.TabIndex = 0;
            this.tagsLP.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tagsLP_Scroll);
            this.tagsLP.Click += new System.EventHandler(this.tagsLP_Click);
            this.tagsLP.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tagsLP_ControlRemoved);
            // 
            // tagsTB
            // 
            this.tagsTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tagsTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tagsTB.BackColor = System.Drawing.Color.White;
            this.tagsTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tagsTB.Location = new System.Drawing.Point(5, 5);
            this.tagsTB.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.tagsTB.Name = "tagsTB";
            this.tagsTB.Size = new System.Drawing.Size(77, 13);
            this.tagsTB.TabIndex = 0;
            this.tagsTB.TextChanged += new System.EventHandler(this.tagsTB_TextChanged);
            this.tagsTB.Enter += new System.EventHandler(this.tagsTB_Enter);
            this.tagsTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tagsTB_KeyDown);
            this.tagsTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tagsTB_KeyUp);
            this.tagsTB.Leave += new System.EventHandler(this.tagsTB_Leave);
            this.tagsTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tagsTB_PreviewKeyDown);
            // 
            // TagEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.grayPanel1);
            this.Name = "TagEditControl";
            this.Size = new System.Drawing.Size(185, 43);
            this.grayPanel1.ResumeLayout(false);
            this.tagsLP.ResumeLayout(false);
            this.tagsLP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel tagsLP;
        private System.Windows.Forms.TextBox tagsTB;
        private System.Windows.Forms.ToolTip toolTip;
        private GrayPanel grayPanel1;
    }
}
