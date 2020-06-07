using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using RembyClipper2.Drawing;

namespace RembyClipper2.Forms
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        public Size ImgSize { get; set; }

        public void ShowWithZoom()
        {
            /*
            this.Size = ImgSize;
            this.BackgroundImage = pictureBox1.Image;
            
            int X = this.Left + this.Width / 2 - (pictureBox6.Size.Width / 2);
            int Y = this.Top + this.Height / 2 - (pictureBox6.Size.Height / 2);
            pictureBox6.Location = new Point(X,5);
            pictureBox6.BringToFront();
            this.ShowDialog();*/
            EditingForm ef = new EditingForm();
            ef.img = pictureBox1.Image;
            ef.Show();
            ef.btnFitcanvas.PerformClick();
        }

        private void PreviewForm_Click(object sender, EventArgs e)
        {
            //for (int i = 100; i > 0; i--)
            //{
            //    int w = ImgSize.Width * i / 100;
            //    int h = ImgSize.Height * i / 100;
            //    this.Size = new Size(w, h);
           // }
            this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
            pictureBox6.BringToFront();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
        }

    }
}
