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
    public partial class TextListItem : ListItemBase
    {
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                textLabel.Text = value;
            }
        }
        public TextListItem()
        {
            InitializeComponent();
        }
    }
}
