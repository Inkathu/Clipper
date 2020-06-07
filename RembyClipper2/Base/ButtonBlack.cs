using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class ButtonBlack : BaseControl
    {
        public ButtonBlack()
        {
            InitializeComponent();
            this.ImageNormal = global::RembyClipper2.Properties.Resources.Black_button;
            this.ImageHover = global::RembyClipper2.Properties.Resources.Black_button_hover;
        }

        /// <summary>
        /// Set text of element
        /// </summary>
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return label1.Text;
            }
            set
            {
                
                label1.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Image")]
        protected Image ImageHover { get; set; }

        [Browsable(true)]
        [Category("Image")]
        protected Image ImageNormal { get; set; }

        private void pictureBoxMiddle_MouseEnter(object sender, EventArgs e)
        {
            if(ImageHover != null)
                this.BackgroundImage = ImageHover;
        }

        private void pictureBoxMiddle_MouseLeave(object sender, EventArgs e)
        {
            if(ImageNormal != null)
                this.BackgroundImage = ImageNormal;
        }

        private void pictureBoxMiddle_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
