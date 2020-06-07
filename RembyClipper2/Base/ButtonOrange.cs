using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class ButtonOrange : ButtonBlack
    {
        public ButtonOrange()
        {
            InitializeComponent();
            this.ImageHover = global::RembyClipper2.Properties.Resources.Orange_button_hover;
            this.ImageNormal = global::RembyClipper2.Properties.Resources.Orange_button;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonOrange_Click(object sender, EventArgs e)
        {
          
        }
    }
}
