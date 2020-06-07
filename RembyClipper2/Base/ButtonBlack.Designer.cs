namespace RembyClipper2.Base
{
    partial class ButtonBlack
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.pictureBoxMiddle_Click);
            this.label1.MouseEnter += new System.EventHandler(this.pictureBoxMiddle_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.pictureBoxMiddle_MouseLeave);
            // 
            // ButtonBlack
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::RembyClipper2.Properties.Resources.Black_button;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(67, 30);
            this.Name = "ButtonBlack";
            this.Size = new System.Drawing.Size(67, 30);
            this.MouseEnter += new System.EventHandler(this.pictureBoxMiddle_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.pictureBoxMiddle_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label1;
    }
}
