using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class GrayToolStrip : ToolStripBase
    {
        public GrayToolStrip()
        {
            InitializeComponent();

            Color1 = Color.FromArgb(0xDD, 0xDD, 0xDD);
            Color2 = Color.FromArgb(0xC3, 0xC5, 0xC7);
            TopGlowLineColor = Color.FromArgb(0xEE, 0xEE, 0xEE);

        }
    }
}
