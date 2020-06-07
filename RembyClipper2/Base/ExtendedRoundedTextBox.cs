using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class ExtendedRoundedTextBox : UserControl
    {
        //public event ContentsResizedEventHandler ContentsResized;
        public event KeyEventHandler CustomKeyUp;
        public event EventHandler CustomTextChanged;
        public event KeyPressEventHandler CustomKeyPress;
        public event KeyEventHandler CustomKeyDown;
        public event EventHandler CustomGotFocus;


        public int TextLength
        {
            get { return textBox.MaxLength; }
            set { textBox.MaxLength = value; }
        }

        public bool ReadOnly
        {
            get { return textBox.ReadOnly; }
            set { textBox.ReadOnly = value; }
        }

        public ExtendedRoundedTextBox()
        {
            InitializeComponent();
            RoundingRadius = 10;
            textBox.KeyUp += new KeyEventHandler(textBox_KeyUp);
            textBox.TextChanged += new EventHandler(textBox_TextChanged);
            textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textBox.GotFocus += new EventHandler(textBox_GotFocus);
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            SizeChanged += new EventHandler(ExtendedRoundedTextBox_SizeChanged);
            textBox.SizeChanged += new EventHandler(textBox_SizeChanged);
            
            //textBox.re
        }

        void textBox_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        void ExtendedRoundedTextBox_SizeChanged(object sender, EventArgs e)
        {
            //panel1.Refresh();
        }

        void textBox_GotFocus(object sender, EventArgs e)
        {
            if(CustomGotFocus != null)
            {
                CustomGotFocus(sender, e);
            }
        }

        public void Select(int start, int length)
        {
            textBox.Select(start, length);
        }

        void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(CustomKeyDown != null)
            {
                CustomKeyDown(this, e);
            }
            
        }

        void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(CustomKeyPress!= null)
            {
                CustomKeyPress(this, e);
            }
        }

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                if(value)
                {
                    this.BackColor = Color.White;
                    textBox.BackColor = Color.White;
                    panel1.BackColor = Color.White;
                }
                else
                {
                    this.BackColor = SystemColors.Control;
                    textBox.BackColor = SystemColors.Control;
                    panel1.BackColor = SystemColors.Control;
                    
                }
            }
        }

        public char PasswordChar
        {
            get 
            {
                return textBox.PasswordChar;
            }

            set
            {
                textBox.PasswordChar = value;
            }
        }

        void textBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomTextChanged != null)
            {
                CustomTextChanged(sender, e);
            }
        }

        void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (CustomKeyUp != null)
            {
                CustomKeyUp(textBox, e);
            }
        }

        public int SelectionStart
        {
            get
            {
                return textBox.SelectionStart;

            }
            set
            {
                textBox.SelectionStart = value;
            }
        }

        public bool Multiline
        {
            get { return textBox.Multiline; }
            set { textBox.Multiline = value; }
                
        }

        public int SelectionLength
        {
            get { return textBox.SelectionLength; }
            set { textBox.SelectionLength = value; }
        }

        public string InnerText
        {
            get
            {
                return Text;
            }
            set 
            {
                Text = value;
            }
        }

        public override string Text
        {
            get 
            {
                return textBox.Text; 
            }
            set 
            {
                textBox.Text = value;
            }
        }

        public void SelectAll()
        {
            textBox.SelectAll();
                
        }

       protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //panel1.Invalidate();
            return;
           /*
            {
                GraphicsPath clipPath = new GraphicsPath();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


                int r = RoundingRadius;
                int w = Width;
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

       //         this.Region = new Region(clipPath);
                //draw border
                using (Pen p = new Pen(Color.FromArgb(145, 145, 145), 4))
                {
                    //set the rounding
                    
                    e.Graphics.DrawPath(p, clipPath);
                }

            }*/
        }

        protected int RoundingRadius { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath clipPath = new GraphicsPath();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            int r = RoundingRadius;
            int w = Width;
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
            using (Pen p = new Pen(Color.Gray, 3))
            {
                //set the rounding

                e.Graphics.DrawPath(p, clipPath);
            }
        }
    }
}
