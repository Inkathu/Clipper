using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using FilePlayer;
using RembyClipper2.Base;
using RembyClipper2.Forms;

namespace RembyClipper2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var g = this.CreateGraphics())
            {
                GraphicsPath clipPath = new GraphicsPath();
                int r =5;
                int w = 50;
                int h = 50;
                //clipPath.StartFigure();
                g.DrawArc(Pens.White, 0, 0, r, r, 180, 90);
                //clipPath.AddLine(r, 0, w - r, 0);
                g.DrawArc(Pens.White, w - r, 0, r, r, 270, 90);
                //clipPath.AddLine(w, r, w, h - r -1);
                g.DrawArc(Pens.White, w - r - 1, h - r -1, r + 1, r + 1, 0, 90);
                //clipPath.AddLine(w - r- 1, h, r, h);
                g.DrawArc(Pens.White, 0, h - r, r, r, 90, 90);
                //clipPath.CloseFigure();
                
                //g.DrawPath(Pens.White, clipPath);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OCRForm o = new OCRForm();
            o.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
//            FormImgPreview p = new FormImgPreview();
//            p.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormVideoPlayer f = new FormVideoPlayer();
            f.rembyVideo1.videoPlayer1.Filename = "ttt.avi";
            f.rembyVideo1.videoPlayer1.Init();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            //CaptureForm cf = new CaptureForm(new Image());
            //cf.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TopNav tn = new TopNav();
            tn.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            Button roundButton = (Button)sender;
            System.Drawing.Drawing2D.GraphicsPath buttonPath =
           new System.Drawing.Drawing2D.GraphicsPath();

            // Set a new rectangle to the same size as the button's 
            // ClientRectangle property.
            System.Drawing.Rectangle newRectangle = roundButton.ClientRectangle;

            // Decrease the size of the rectangle.
            newRectangle.Inflate(-10, -10);

            // Draw the button's border.
            e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);

            // Increase the size of the rectangle to include the border.
            newRectangle.Inflate(1, 1);

            // Create a circle within the new rectangle.
            buttonPath.AddEllipse(newRectangle);

            // Set the button's Region property to the newly created 
            // circle region.
            roundButton.Region = new System.Drawing.Region(buttonPath);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ExtendedProgressBar pb = new ExtendedProgressBar();
            PlayerForm pf = new PlayerForm();

            pf.filename = "asfiqdih.mp4";
            pf.progressBar = pb;
            pf.Start();
            pf.ShowDialog();
        }

        private void blueButton1_Click(object sender, EventArgs e)
        {
        }
    }
}
