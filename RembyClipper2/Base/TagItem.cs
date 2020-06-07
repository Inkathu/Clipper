using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class TagItem : UserControl
    {
        public TagItem()
        {
            InitializeComponent();
            panelColor = panelBase1.Color1;
            panelHighLightedColor = panelBase1.HighLightedColor;
            TabStop = false;
        }

        [Browsable(true)]
        public override string Text
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
                Refresh();
            }
        }

        private Color panelColor;
        private Color panelHighLightedColor;

        private void blueButton1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            if(panelBase1.Color1 == panelColor)
            {
                panelBase1.Color1 = panelHighLightedColor;
                panelBase1.Color2 = panelHighLightedColor;
                blueButton1.Color1 = panelHighLightedColor;
                blueButton1.Color2 = panelHighLightedColor;
                blueButton1.BorderColor = panelHighLightedColor;
                blueButton1.TopGlowLineColor = panelHighLightedColor;
                panelBase1.Refresh();
                blueButton1.Refresh();
            }
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (panelBase1.Color1 == panelHighLightedColor)
            {
                panelBase1.Color1 = panelColor;
                panelBase1.Color2 = panelColor;
                blueButton1.Color1 = panelColor;
                blueButton1.Color2 = panelColor;
                blueButton1.BorderColor = panelColor;
                blueButton1.TopGlowLineColor = panelColor;
                panelBase1.Refresh();
                blueButton1.Refresh();
            }
        }
    }
}
