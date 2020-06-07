using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Localization;
using RembyClipper.Helpers;

namespace RembyClipper2.DrawingTool
{
    /// <summary>
    /// Description of CustomColorDialog.
    /// Grabbed from the previous version of the system.
    /// </summary>
    public partial class CustomColorDialog
    {
        //TODO : Add comments for this entity

        //private Language lang;
        private static CustomColorDialog uniqueInstance;
        private readonly List<Button> colorButtons = new List<Button>();
        private readonly List<Button> recentColorButtons = new List<Button>();
        private readonly List<Color> recentColors = new List<Color>();
        private readonly ToolTip toolTip = new ToolTip();
        private bool updateInProgress;

        private CustomColorDialog()
        {
            //SuspendLayout();
            InitializeComponent();
            //lang = Language.GetInstance();
            ApplyLanguage();
            SuspendLayout();
            createColorPalette(0, 0, 15, 15);
            createLastUsedColorButtonRow(0, 0, 15, 15);
            //ResumeLayout();
        }

        public Color[] RecentColors
        {
            get { return recentColors.ToArray(); }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    recentColors.Add(value[i]);
                }
                updateRecentColorsButtonRow();
            }
        }

        public Color Color
        {
            get { return colorPanel.BackColor; }
            set { previewColor(value, this); }
        }

        #region user interface generation

        private void createColorPalette(int x, int y, int w, int h)
        {
            createColorButtonColumn(255, 0, 0, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(255, 255/2, 0, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(255, 255, 0, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(255/2, 255, 0, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(0, 255, 0, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(0, 255, 255/2, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(0, 255, 255, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(0, 255/2, 255, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(0, 0, 255, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(255/2, 0, 255, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(255, 0, 255, x, y, w, h, 11);
            x += w;
            createColorButtonColumn(255, 0, 255/2, x, y, w, h, 11);
            x += w + 5;
            createColorButtonColumn(255/2, 255/2, 255/2, x, y, w, h, 11);

            panel1.Controls.AddRange(colorButtons.ToArray());
        }

        private void createColorButtonColumn(int red, int green, int blue, int x, int y, int w, int h, int shades)
        {
            int shadedColorsNum = (shades - 1)/2;
            for (int i = 0; i <= shadedColorsNum; i++)
            {
                colorButtons.Add(createColorButton(red*i/shadedColorsNum, green*i/shadedColorsNum,
                                                   blue*i/shadedColorsNum, x, y + i*h, w, h));
                if (i > 0)
                    colorButtons.Add(createColorButton(red + (255 - red)*i/shadedColorsNum,
                                                       green + (255 - green)*i/shadedColorsNum,
                                                       blue + (255 - blue)*i/shadedColorsNum, x,
                                                       y + (i + shadedColorsNum)*h, w, h));
            }
        }

        private Button createColorButton(int red, int green, int blue, int x, int y, int w, int h)
        {
            return createColorButton(Color.FromArgb(255, red, green, blue), x, y, w, h);
        }

        private Button createColorButton(Color color, int x, int y, int w, int h)
        {
            var b = new Button();
            b.BackColor = color;
            b.FlatAppearance.BorderSize = 0;
            b.FlatStyle = FlatStyle.Flat;
            b.Location = new Point(x, y);
            b.Size = new Size(w, h);
            b.TabStop = false;
            b.Click += colorButtonClick;
            toolTip.SetToolTip(b,
                               ColorTranslator.ToHtml(color) + " | R:" + color.R + ", G:" + color.G + ", B:" + color.B);
            return b;
        }

        private void createLastUsedColorButtonRow(int x, int y, int w, int h)
        {
            for (int i = 0; i < 12; i++)
            {
                Button b = createColorButton(Color.Transparent, x, y, w, h);
                b.Enabled = false;
                recentColorButtons.Add(b);
                x += w;
            }
            panel2.Controls.AddRange(recentColorButtons.ToArray());
        }

        #endregion

        #region update user interface

        private void updateRecentColorsButtonRow()
        {
            for (int i = 0; i < recentColors.Count && i < 12; i++)
            {
                recentColorButtons[i].BackColor = recentColors[i];
                recentColorButtons[i].Enabled = true;
            }
        }

        private void previewColor(Color c, Control trigger)
        {
            updateInProgress = true;
            colorPanel.BackColor = c;
            if (trigger != textBoxHtmlColor)
            {
                textBoxHtmlColor.Text = ColorTranslator.ToHtml(c);
            }
            else
            {
                if (!textBoxHtmlColor.Text.StartsWith("#"))
                {
                    int selStart = textBoxHtmlColor.SelectionStart;
                    int selLength = textBoxHtmlColor.SelectionLength;
                    textBoxHtmlColor.Text = "#" + textBoxHtmlColor.Text;
                    textBoxHtmlColor.Select(selStart + 1, selLength + 1);
                }
            }
            if (trigger != redUpDown && trigger != greenUpDown && trigger != blueUpDown && trigger != alphaUpDown)
            {
                redUpDown.Value = c.R;
                greenUpDown.Value = c.G;
                blueUpDown.Value = c.B;
                alphaUpDown.Value = c.A;
                trackBar1.Value = (int)alphaUpDown.Value;
            }
            updateInProgress = false;
        }

        private void addToRecentColors(Color c)
        {
            recentColors.Remove(c);
            recentColors.Insert(0, c);
            if (recentColors.Count > 12) recentColors.RemoveRange(12, recentColors.Count - 12);
            updateRecentColorsButtonRow();
        }

        #endregion

        #region textbox event handlers

        private bool isNumerikEntered;

        private void TextBoxHexadecimalTextChanged(object sender, EventArgs e)
        {
            if (updateInProgress) return;
            var tb = (TextBox) sender;
            string t = tb.Text.Replace("#", "");
            int i = 0;
            Int32.TryParse(t, NumberStyles.AllowHexSpecifier, Thread.CurrentThread.CurrentCulture, out i);
            Color c = Color.FromArgb(i);
            Color opaqueColor = Color.FromArgb(255, c.R, c.G, c.B);
            previewColor(opaqueColor, tb);
        }

        private void RGBChanged(object sender, EventArgs e)
        {
            if (updateInProgress) return;
            var ctrl = (Control) sender;
            Color cl = Color.FromArgb((int) alphaUpDown.Value, (int) redUpDown.Value, (int) greenUpDown.Value,
                                      (int) blueUpDown.Value);
            previewColor(cl, ctrl);
            try
            {
                trackBar1.Value = cl.A;
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
            }

        }

        private void TextBoxGotFocus(object sender, EventArgs e)
        {
            textBoxHtmlColor.SelectAll();
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                addToRecentColors(colorPanel.BackColor);
            }
            if (sender == textBoxHtmlColor)
            {
                isNumerikEntered = CheckIfNumericKey(e.KeyCode, false);
            }
        }

        #endregion

        #region button event handlers

        private void colorButtonClick(object sender, EventArgs e)
        {
            var b = (Control) sender;
            previewColor(b.BackColor, b);
        }

        private void btnTransparentClick(object sender, EventArgs e)
        {
            colorButtonClick(sender, e);
        }

        private void BtnApplyClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
            addToRecentColors(colorPanel.BackColor);
        }

        #endregion

        #region helper functions

        private int getColorPartIntFromString(string s)
        {
            int ret = 0;
            Int32.TryParse(s, out ret);
            if (ret < 0) ret = 0;
            else if (ret > 255) ret = 255;
            return ret;
        }

        #endregion

        public static CustomColorDialog GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new CustomColorDialog();
            }
            return uniqueInstance;
        }

        private void ApplyLanguage()
        {
            this.Text = LanguageMgr.LM.GetText(Labels.ColorDialog_title);
            this.btnApply.Text = LanguageMgr.LM.GetText(Labels.ColorDialog_ApplyBtn);
//            this.btnTransparent.Text = lang.GetString("colorpicker_transparent");
            this.labelHtmlColor.Text = LanguageMgr.LM.GetLabelText(Labels.ColorDialog_HTMLColor);
            this.labelRed.Text = LanguageMgr.LM.GetLabelText(Labels.ColorDialog_Red);
            this.labelGreen.Text = LanguageMgr.LM.GetLabelText(Labels.ColorDialog_Green);
            this.labelBlue.Text = LanguageMgr.LM.GetLabelText(Labels.ColorDialog_Blue);
            this.labelOpacity.Text = LanguageMgr.LM.GetLabelText(Labels.ColorDialog_Opacity);
            this.labelRecentColors.Text = LanguageMgr.LM.GetLabelText(Labels.ColorDialog_RecentColors);
        }

        private void ColorDialog_Load(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Value = (int) alphaUpDown.Value;
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                alphaUpDown.Value = trackBar1.Value;
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
            }

        }

        private bool CheckIfNumericKey(Keys k, bool isDecimalPoint)
        {
            if (k == Keys.Back) //backspace?
            {
                return true;
            }
            else if (k == Keys.OemPeriod || k == Keys.Decimal) //decimal point?
            {
                return isDecimalPoint ? false : true; //or: return !isDecimalPoint
            }
            else if ((k >= Keys.D0) && (k <= Keys.D9)) //digit from top of keyboard?
            {
                return true;
            }
            else if ((k >= Keys.NumPad0) && (k <= Keys.NumPad9)) //digit from keypad?
            {
                return true;
            }
            else if ((k >= Keys.A) && (k <= Keys.F))
            {
                return true;
            }
            else
                return false; //no "numeric" key
        }

        private void textBoxHtmlColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumerikEntered)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            advancedPanel.Visible = checkBox1.Checked;
           
        }
    }
}