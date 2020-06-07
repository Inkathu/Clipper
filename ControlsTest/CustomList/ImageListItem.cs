using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlsTest.CustomList
{
    public partial class ImageListItem : ListItemBase
    {

        public Color SizeColor { get; set; }
        public virtual Image Image
        {
            get { return Picture.Image; }
            set
            {
                Picture.Image = value;
                if (value != null)
                {
                    sizeLabel.Text = string.Format("{0}x{1}", value.Size.Width, value.Size.Height);
                }
            }

        }
        public ImageListItem()
        {
            InitializeComponent();
            SizeColor = Color.FromArgb(128, Color.Black);
            sizeLabel.BackColor = SizeColor;
            
        }

      
    }
}
