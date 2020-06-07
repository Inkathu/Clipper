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
    public partial class CustomListItem : UserControl
    {
        public event EventHandler RemoveClicked;
        private Color oddColor = SystemColors.Control;
        private Color evenColor = SystemColors.ControlLight;
        public bool Odd
        {
            set
            {
                if(value)
                {
                    this.BackColor = oddColor;
                } else
                {
                    this.BackColor = evenColor;
                }
            }
        }
        public Image Image
        {
            get { return _image; }
            set 
            { 
                _image = value;
                itemImage.Image = value;
            }
        }
        private Image _image;

        [Browsable(true)]
        public new string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                itemText.Text = value;
            }

        }
        private string _text;

        public object Item { get; set; }

        public CustomListItem()
        {
            InitializeComponent();
            itemText.MouseWheel += new MouseEventHandler(CustomListItem_MouseWheel);
            panel1.Click += new EventHandler(itemText_Click);
            panel2.Click += new EventHandler(itemText_Click);
            panel3.Click += new EventHandler(itemText_Click);
        }

        void CustomListItem_MouseWheel(object sender, MouseEventArgs e)
        {
            IMouseWheelContrllable parent = Parent as IMouseWheelContrllable;
            if(parent != null)
            {
                parent.DoMouseWheel(e);
            }
        }

        public T GetItem<T>() where T : new()
        {
            return (T) Item;
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if(RemoveClicked != null)
            {
                RemoveClicked(this, EventArgs.Empty);
            }
        }

        private void itemText_Click(object sender, EventArgs e)
        {
            Parent.Focus();
        }

        private void itemText_MouseHover(object sender, EventArgs e)
        {
            Parent.Focus();
        }
    }
}
