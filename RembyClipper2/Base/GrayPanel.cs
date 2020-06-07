using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class GrayPanel : PanelBase
    {
        public GrayPanel()
        {
            InitializeComponent();
            Color1 = Color.FromArgb(0xE2, 0xE2, 0xE3);
            Color2 = Color.FromArgb(0xD2, 0xD3, 0xD3);
            TopGlowLineColor = Color.FromArgb(0xF6, 0xF6, 0xF6);
            ColorOfBorder = Color.FromArgb(0x8B, 0x8B, 0x8B);
        }
    }
}
