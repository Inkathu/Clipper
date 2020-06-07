using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class RembyProgressBar : BaseControl
    {

        public delegate void ChangeProgressEventHandler(int changeTo);

        public event ChangeProgressEventHandler onProgressChange;

        public RembyProgressBar()
        {
            InitializeComponent();
        }

        private int value = 0;


        public int Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                if (this.value == 0)
                {
                    pictureBoxContent.Invalidate();
                    lastOX = 0;
                }
                drawGray();
            }
        }

        bool firstDraw = true;

        int lastOX = 0;

        private void pictureBoxContent_Paint(object sender, PaintEventArgs e)
        {
            if (value == 0)
                pictureBoxStart.Image = global::RembyClipper2.Properties.Resources.Progress_start_white;
            else
                pictureBoxStart.Image = global::RembyClipper2.Properties.Resources.Progress_start_gray;

            if (value == 100)
                pictureBoxEnd.Image = global::RembyClipper2.Properties.Resources.Progress_end_gray;
            else
                pictureBoxEnd.Image = global::RembyClipper2.Properties.Resources.Progress_end_white;

            int max = pictureBoxContent.Size.Width;

            //100% ..... width
            //z%   ...   n-ig

            int grayWidth = Value * max / 100;
            int whiteWidth = max - grayWidth;
            int i=0;
            for (i = 0; i < grayWidth; i++)
                e.Graphics.DrawImage(global::RembyClipper2.Properties.Resources.Progress_step, i, 0F, 1F, Height);
            for (i = grayWidth; i < whiteWidth && firstDraw; i++)
                e.Graphics.DrawImage(global::RembyClipper2.Properties.Resources.Progress_step_white, i, 0F, 1F, Height);
            firstDraw = false;
        }

        private void drawGray()
        {
            if (value == 0)
                pictureBoxStart.Image = global::RembyClipper2.Properties.Resources.Progress_start_white;
            else
                pictureBoxStart.Image = global::RembyClipper2.Properties.Resources.Progress_start_gray;

            if (value == 100)
                pictureBoxEnd.Image = global::RembyClipper2.Properties.Resources.Progress_end_gray;
            else
                pictureBoxEnd.Image = global::RembyClipper2.Properties.Resources.Progress_end_white;
            
            int max = pictureBoxContent.Size.Width;

            int grayWidth = Value * max / 100;
            int whiteWidth = max - grayWidth;
            int i = 0;

            using (Graphics g = pictureBoxContent.CreateGraphics())
            {
                for (i = lastOX; i < grayWidth; i++)
                    g.DrawImage(global::RembyClipper2.Properties.Resources.Progress_step, i, 0F, 1F, Height);
                lastOX = i;
            }
        }

        private void pictureBoxContent_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void ProgressBar_Click(object sender, EventArgs e)
        {
            Point localPos = this.PointToClient(Cursor.Position);

            if(onProgressChange != null)
            {
                int progress = (int) (((double) localPos.X)/Width*100);
                onProgressChange(progress);
            }
        }
    }
}
