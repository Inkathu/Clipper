using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RembyClipper2.Base
{
    public class AutoCompleteTextBox : ExtendedRoundedTextBox
    {

        private ListBox _listBox;
        private bool _isAdded;
        private String[] _values;
        private String _formerValue = String.Empty;

        public delegate void lixtBoxStateChanged();
        public event lixtBoxStateChanged onListboxOpened;
        public event lixtBoxStateChanged onListboxClosed;

        public event lixtBoxStateChanged onWordAdded;

        public int ListboxHeight { get { return _listBox.Items.Count; } }

        public bool ListboxOpen { get { return _listBox.Visible; } }

        private int maxListBoxHeight = 48;

        public Point CustomPosition { get; set; }

        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
            this.Multiline = false;
        }

        private void InitializeComponent()
        {
            this._listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.TextChanged += new System.EventHandler(this.AutoCompleteTextBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.this_KeyDown);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.this_KeyUp);
            // 
            // _listBox
            // 
            this._listBox.Location = new System.Drawing.Point(0, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(120, 96);
            this._listBox.TabIndex = 0;
            this._listBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this._listBox_MouseClick);
            this._listBox.DoubleClick += new System.EventHandler(this._listBox_DoubleClick);
            this._listBox.GotFocus += new System.EventHandler(this._listBox_GotFocus);
            // 
            // AutoCompleteTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "AutoCompleteTextBox";
            this.ResumeLayout(false);

        }

        void _listBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        void _listBox_DoubleClick(object sender, EventArgs e)
        {
            addSelectedWord();
        }

        void _listBox_GotFocus(object sender, EventArgs e)
        {
         //   this.Focus();
        }

        void AutoCompleteTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Parent.Parent.Controls.Add(_listBox);
                if (CustomPosition != null)
                    if (CustomPosition.X != 0 && CustomPosition.Y != 0)
                        _listBox.Location = CustomPosition;
                    else
                    {
                        _listBox.Left = this.Left;
                        _listBox.Top = this.Top + this.Height;
                    }
                _isAdded = true;
                _listBox.Show();
                _listBox.BringToFront();
            }

            if (CustomPosition != null)
                if (CustomPosition.X != 0 && CustomPosition.Y != 0)
                    _listBox.Location = CustomPosition;

            if (onListboxOpened != null && _listBox.Visible == false)
                onListboxOpened();
            _listBox.Visible = true;
            
        }

        private void ResetListBox()
        {
            if (onListboxClosed != null)
                onListboxClosed();

            _listBox.Visible = false;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }
        
        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        addSelectedWord();
                        e.Handled = true;
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                        {
                            _listBox.SelectedIndex++;
                        }
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                        {
                            _listBox.SelectedIndex--;
                        }
                        e.Handled = true;
                        break;
                    }
            }
        }

        private void addSelectedWord()
        {
            if (_listBox.Visible)
            {
                InsertWord((String)_listBox.SelectedItem);
                ResetListBox();
                _formerValue = this.Text;
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                case Keys.Enter:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void UpdateListBox()
        {
            if (this.Text != _formerValue)
            {
                _formerValue = this.Text;
                String word = GetWord().Trim();

                if (word.Length > 0 && _values != null)
                {
                    word = word.ToLower();
                    String[] matches = Array.FindAll(_values,
                        x => (x.StartsWith(word) && !SelectedValues.Contains(x)));
                    if (matches.Length > 0)
                    {
                        ShowListBox();
                        _listBox.Items.Clear();
                        Array.ForEach(matches, x => _listBox.Items.Add(x));
                        _listBox.SelectedIndex = 0;
                        _listBox.Height = 0;
                        _listBox.Width = 0;
                        this.Focus();
                        using (Graphics graphics = _listBox.CreateGraphics())
                        {
                            for (int i = 0; i < _listBox.Items.Count; i++)
                            {
                                if(_listBox.Height <= maxListBoxHeight)
                                    _listBox.Height += _listBox.GetItemHeight(i);
                                // it item width is larger than the current one
                                // set it to the new max item width
                                // GetItemRectangle does not work for me
                                // we add a little extra space by using '_'
                                int itemWidth = (int)graphics.MeasureString(((String)_listBox.Items[i]) + "_", _listBox.Font).Width;
                                _listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : _listBox.Width;
                            }
                        }
                    }
                    else
                    {
                        ResetListBox();
                    }
                }
                else
                {
                    ResetListBox();
                }
            }
        }

        private String GetWord()
        {
            String text = this.Text;
            int pos = this.SelectionStart;

            int posStart = text.LastIndexOf(',', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(',', pos);
            posEnd = (posEnd == -1) ? text.Length : posEnd;

            int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;

            return text.Substring(posStart, length);
        }

        private void InsertWord(String newTag)
        {
            String text = this.Text;
            int pos = this.SelectionStart;
            
            int posStart = text.LastIndexOf(',', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(',', pos);

            String firstPart = text.Substring(0, posStart) + " " + newTag;
            String updatedText = firstPart.Trim() + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));


            this.Text = updatedText + ", ";
            this.SelectionStart = firstPart.Length + 2;

            if (onWordAdded != null)
                onWordAdded();
        }

        public String[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
                if (_values != null)
                {
                    for (int i = 0; i < _values.Length; i++)
                        _values[i] = _values[i].ToLower();
                }
            }
        }

        public List<String> SelectedValues
        {
            get
            {
                String[] result = Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < result.Length; i++)
                    result[i] = result[i].Trim();
                return new List<String>(result);
            }            
        }

    }
}
