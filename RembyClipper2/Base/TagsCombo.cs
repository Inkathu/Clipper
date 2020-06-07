using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;


namespace RembyClipper2.Base
{
    public partial class TagsCombo : UserControl
    {
        public event EventHandler CustomGotFocus;
        List<string> tags;
        //string currentText = "";
        public TagsCombo()
        {
            InitializeComponent();
            tags = new List<string>();
            comboBox1.SelectionChangeCommitted += new EventHandler(TagsCombo_SelectionChangeCommitted);

            //this.KeyPress += new KeyPressEventHandler(TagsCombo_KeyPress);
            //textBox1.TextChanged += new EventHandler(TagsCombo_TextChanged);
            textBox1.CustomKeyUp += new KeyEventHandler(TagsCombo_KeyUp);
            comboBox1.Font = textBox1.Font;
            textBox1.CustomTextChanged += new EventHandler(textBox1_CustomTextChanged);
            textBox1.CustomGotFocus += new EventHandler(textBox1_CustomGotFocus);
        }

        void textBox1_CustomGotFocus(object sender, EventArgs e)
        {
            if(CustomGotFocus != null)
            {
                CustomGotFocus(sender, e);
            }
        }

        void textBox1_CustomTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                //currentText = "";
            }
        }

        public string[] Values
        {
            set 
            {
                tags = new List<string>(value);
            }
        }

        public string CustomText
        {
            get { return Text; }
            set { Text = value; }
        }
        public new string Text
        {
            get 
            {
                return textBox1.Text;
            }
            set 
            {
                textBox1.Text = value;
                //currentText = value;
            }
        }

        public void SelectAll()
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Region = textBox1.Region;
            GraphicsPath clipPath = new GraphicsPath();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            int r = 10;
            int w = Width-1;
            int h = Height;
            clipPath.StartFigure();
            clipPath.AddArc(-1, -1, r, r, 180, 90);
            clipPath.AddLine(r, -1, w - r, -1);
            clipPath.AddArc(w - r, -1, r, r, 270, 90);
            clipPath.AddLine(w, r, w, h - r);
            clipPath.AddArc(w - r, h - r, r, r, 0, 90);
            clipPath.AddLine(w - r, h, r, h);
            //            clipPath.AddLine(w, r, w, h - r - 1);
            //            clipPath.AddArc(w - r - 1, h - r - 1, r + 1, r + 1, 0, 90);
            //            clipPath.AddLine(w - r - 1, h, r, h);
            clipPath.AddArc(-1, h - r, r, r, 90, 90);
            clipPath.CloseFigure();

            this.Region = new Region(clipPath);
            //draw border
//            using (Pen p = new Pen(Color.FromArgb(145, 145, 145), 4))
//            {
                //set the rounding
//
//                e.Graphics.DrawPath(p, clipPath);
//            }
//            
        }

        void TagsCombo_KeyUp(object sender, KeyEventArgs e)
        {
            List<string> items = new List<string>();
            List<string> usedTags = new List<string>(textBox1.Text.Split(new char[]{','}));
            int maxString = 0;
            for (int i = 0; i < usedTags.Count; i++)
            {
                usedTags[i] = usedTags[i].Trim().ToLower();
            }
            if (string.IsNullOrEmpty(textBox1.Text) && comboBox1.DroppedDown)
            {
                comboBox1.DroppedDown = false;
                comboBox1.Items.Clear();
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
            string lastWord = GetLastWord();
            if (e.KeyCode == Keys.Down && comboBox1.DroppedDown)
            {
                comboBox1.Focus();
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
                return;
            }
            if (!string.IsNullOrEmpty(lastWord))
            {
                foreach (string tag in tags)
                {
                    if (tag.StartsWith(lastWord) && !usedTags.Contains(tag.ToLower()))
                    {
                        items.Add(tag);
                        using (var gr = this.CreateGraphics())
                        {
                            var size = gr.MeasureString(tag, comboBox1.Font);
                            if (size.Width > maxString)
                            {
                                maxString = (int)size.Width + 1;
                            }
                        }
                    }
                }
                comboBox1.Items.Clear();
                if (items.Count > 0)
                {
                    comboBox1.DropDownWidth = maxString;
                    comboBox1.Items.AddRange(items.ToArray());
                    comboBox1.DroppedDown = true;
                }
                else
                {
                    comboBox1.SelectedIndex = -1;
                    comboBox1.DroppedDown = false;
                }
            }
            else
            {
                if (comboBox1.DroppedDown)
                {
                    comboBox1.SelectedIndex = -1;
                    comboBox1.DroppedDown = false;
                    comboBox1.Items.Clear();
                    
                }
            }
        }

        void TagsCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            //currentText += comboBox1.Items[comboBox1.SelectedIndex] + ", ";
            string lastWord = GetLastWord();
            if(!string.IsNullOrEmpty(lastWord) && textBox1.Text.LastIndexOf(lastWord) != -1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.LastIndexOf(lastWord), lastWord.Length);
            }

            textBox1.Text += comboBox1.Items[comboBox1.SelectedIndex] + ", ";
            comboBox1.DroppedDown = false;
            comboBox1.Items.Clear();
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        void TagsCombo_TextChanged(object sender, EventArgs e)
        {
            //if (!processEvents)
            //{
            //    return;
            //}
        }


        private string GetLastWord()
        {
            string lastWord = "";
            if (textBox1.Text.Contains(","))
            {
                string[] words = textBox1.Text.Split(new char[] { ',' });
                if (words.Length > 0)
                {
                    lastWord = words[words.Length - 1];
                }
            }
            else 
            {
                lastWord = textBox1.Text;
            }

            return lastWord.Trim();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            SendMessage(this.Handle, 0x0020, 0, 0);
        }
    }
}
