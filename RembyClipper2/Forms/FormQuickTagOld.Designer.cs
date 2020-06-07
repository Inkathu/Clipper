namespace RembyClipper2.Forms
{
    partial class FormQuickTagOld
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
            this.autoCompleteTextBox1 = new RembyClipper2.Base.AutoCompleteTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(82, 6);
            this.richTextBox1.Visible = false;
            // 
            // pictureBox2
            // 
            // 
            // autoCompleteTextBox1
            // 
            this.autoCompleteTextBox1.Location = new System.Drawing.Point(84, 6);
            this.autoCompleteTextBox1.Name = "autoCompleteTextBox1";
            this.autoCompleteTextBox1.Size = new System.Drawing.Size(159, 20);
            this.autoCompleteTextBox1.TabIndex = 5;
            this.autoCompleteTextBox1.Text = "";
            this.autoCompleteTextBox1.Values = null;
            this.autoCompleteTextBox1.onListboxOpened += new RembyClipper2.Base.AutoCompleteTextBox.lixtBoxStateChanged(this.autoCompleteTextBox1_onListboxOpened);
            this.autoCompleteTextBox1.onListboxClosed += new RembyClipper2.Base.AutoCompleteTextBox.lixtBoxStateChanged(this.autoCompleteTextBox1_onListboxClosed);
//            this.autoCompleteTextBox1.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.autoCompleteTextBox1_ContentsResized);
            this.autoCompleteTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.autoCompleteTextBox1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tags";
            // 
            // FormQuickTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 32);
            this.Controls.Add(this.autoCompleteTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormQuickTag";
            this.Text = "FormQuickTag";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.richTextBox1, 0);
            this.Controls.SetChildIndex(this.autoCompleteTextBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RembyClipper2.Base.AutoCompleteTextBox autoCompleteTextBox1;
        private new System.Windows.Forms.Label label1;
    }
}