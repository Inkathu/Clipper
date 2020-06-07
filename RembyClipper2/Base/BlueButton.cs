using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class BlueButton : BaseButton
    {
        public BlueButton()
        {
            InitializeComponent();

            Color1 = Color.FromArgb(0x20, 0x99, 0xE5);
            Color2 = Color.FromArgb(0x0, 0x74, 0xBD);
            FontColor = Color.White;
            BorderColor = Color.FromArgb(0x00, 0x74, 0xBD);
            TopGlowLineColor = Color.FromArgb(0x68, 0xBA, 0xEE);


        }
    }
}
