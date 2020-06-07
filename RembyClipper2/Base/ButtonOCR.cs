using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class ButtonOCR : ButtonBlack
    {
        public ButtonOCR()
        {
            InitializeComponent();
            this.ImageHover = global::RembyClipper2.Properties.Resources.OCR_Button_hover;
            this.ImageNormal = global::RembyClipper2.Properties.Resources.OCR_Button;
        }
    }
}
