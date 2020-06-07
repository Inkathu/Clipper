using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class ButtonCopy : ButtonBlack
    {
        public ButtonCopy()
        {
            InitializeComponent();
            this.ImageHover = global::RembyClipper2.Properties.Resources.Button_copy_hover;
            this.ImageNormal = global::RembyClipper2.Properties.Resources.Button_copy;
        }
    }
}
