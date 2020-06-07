using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Localization;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.Editors
{
    /// <summary>
    /// This form allow to edit properties of the entity
    /// </summary>
    public partial class PropertyEditor : Form
    {
        /// <summary>
        /// form instance
        /// </summary>
        private static PropertyEditor _instance;
        
        /// <summary>
        /// Timer which check mouse placement to make form inactive
        /// </summary>
        private readonly Timer _mouseChecker;

        /// <summary>
        /// Animation timer - need to smoth reduce opacity of the window
        /// </summary>
        private readonly Timer opacityTimer;

        /// <summary>
        /// Current figure
        /// </summary>
        private IFigure _figure;

        /// <summary>
        /// figures
        /// </summary>
        private List<IFigure> _figures;

        /// <summary>
        /// x point of the window
        /// </summary>
        private int startX;

        /// <summary>
        /// y point of the window
        /// </summary>
        private int startY;

        /// <summary>
        /// Constructor
        /// </summary>
        public PropertyEditor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            _mouseChecker = new Timer();
            _mouseChecker.Interval = 1000;
            _mouseChecker.Tick += MouseCheckerTick;
            opacityTimer = new Timer();
            opacityTimer.Interval = 10;
            opacityTimer.Tick += opacityTimer_Tick;
            Opacity = 0.5;

            ApplyLanguage();
        }

        /// <summary>
        /// Public instance of the property editor
        /// </summary>
        public static PropertyEditor Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new PropertyEditor();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Source of the figures
        /// </summary>
        public List<IFigure> FiguresDataSource
        {
            set
            {
                _figures = value;
                UpdateFiguresList(value);
            }
        }

        /// <summary>
        /// Figure changed event
        /// </summary>
        public static event EventHandler SelectionChanged;

        /// <summary>
        /// This method performs to apply localization
        /// </summary>
        private void ApplyLanguage()
        {
            Text = LanguageMgr.LM.GetText(Labels.Properties);
            nameLabel.Text = LanguageMgr.LM.GetLabelText(Labels.FigureName);
            borderColorLabel.Text = LanguageMgr.LM.GetLabelText(Labels.BorderColor);
            borderOpacityLabel.Text = LanguageMgr.LM.GetLabelText(Labels.BorderOpacity);
            borderWidthlabel.Text = LanguageMgr.LM.GetLabelText(Labels.BorderWidth);
            fillColorLabel.Text = LanguageMgr.LM.GetLabelText(Labels.FillColor);
            fillOpacityLabel.Text = LanguageMgr.LM.GetLabelText(Labels.FillOpacity);
            fontLabel.Text = LanguageMgr.LM.GetLabelText(Labels.Font);
            fontColorLabel.Text = LanguageMgr.LM.GetLabelText(Labels.FontColor);
        }


        /// <summary>
        /// Mouse timer tick event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseCheckerTick(object sender, EventArgs e)
        {
            PropertyEditor_MouseLeave(null, EventArgs.Empty);
        }

        /// <summary>
        /// Mouse down event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyEditor_MouseDown(object sender, MouseEventArgs e)
        {
            startX = Cursor.Position.X;
            startY = Cursor.Position.Y;
        }

        /// <summary>
        /// Mouse move event handler. Need to drag window while it picked in client area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point newPos = Cursor.Position;
                int dx = startX - newPos.X;
                int dy = startY - newPos.Y;
                Left -= dx;
                Top -= dy;
                startX = newPos.X;
                startY = newPos.Y;
            }
        }

        /// <summary>
        /// This method performs to change opacity of the window
        /// </summary>
        /// <param name="opacityTo"></param>
        private void ChangeOpacity(double opacityTo)
        {
            if (Opacity == opacityTo)
            {
                return;
            }
            int multiplier = 1;
            if (opacityTo < Opacity)
            {
                multiplier = -1;
            }
            opacityTimer.Tag = multiplier;
            opacityTimer.Start();
        }


        /// <summary>
        /// Opacity timer tick event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opacityTimer_Tick(object sender, EventArgs e)
        {
            var multiplier = (int) opacityTimer.Tag;

            if (multiplier > 0 && Opacity >= 1)
            {
                Opacity = 1;
                opacityTimer.Stop();
                return;
            }
            else if (multiplier < 0 && Opacity <= 0.5)
            {
                Opacity = 0.5;
                opacityTimer.Stop();
                return;
            }

            Opacity += (0.05*multiplier);
        }

        /// <summary>
        /// Mouse enter event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyEditor_MouseEnter(object sender, EventArgs e)
        {
            ChangeOpacity(1);
        }

        /// <summary>
        /// Mouse leave event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyEditor_MouseLeave(object sender, EventArgs e)
        {
            Point p = Cursor.Position;

            if (!((p.X > Left) && (p.X < (Left + Width)) && (p.Y > Top) && (p.Y < (Top + Height))))
            {
                ChangeOpacity(0.5);
            }
        }

        /// <summary>
        /// Focus leave event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyEditor_Leave(object sender, EventArgs e)
        {
            ChangeOpacity(0.5);
        }

        /// <summary>
        /// This method performs to update list of the figures
        /// </summary>
        /// <param name="value">new list</param>
        private void UpdateFiguresList(List<IFigure> value)
        {
            figuresComboBox.Items.Clear();
            figuresComboBox.Items.Add(LanguageMgr.LM.GetText(Labels.None));
            value.ForEach(figure => figuresComboBox.Items.Add(figure));
            if (_figure != null)
            {
                figuresComboBox.SelectedItem = _figure;
            }
        }

        /// <summary>
        /// This method performs to show figure properties
        /// </summary>
        /// <param name="owner">owner control</param>
        /// <param name="figure">figure to show</param>
        public void Show(Control owner, IFigure figure)
        {
            _figure = figure;
            if (_figure != null)
            {
                panel1.Enabled = true;
                figuresComboBox.SelectedItem = _figure;
                ReadFigureProperties();
            }
            else
            {
                panel1.Enabled = false;
                nameTextBox.Text = "";
                figuresComboBox.SelectedIndex = 0;
            }
            if (!Visible)
            {
                base.Show(owner);
                _mouseChecker.Start();
            }
        }

        /// <summary>
        /// This method performs to read properties of the figure
        /// </summary>
        private void ReadFigureProperties()
        {
            if (_figure != null)
            {
                nameTextBox.Text = _figure.Name;
                Text = _figure.Name + " " + LanguageMgr.LM.GetText(Labels.Properties);
                borderColorPanel.BackColor = _figure.BorderColor;
                borderTransparencyTextBox.Text = _figure.BorderColor.A.ToString();
                borderTranparencyTrackBar.Value = _figure.BorderColor.A;

                if (_figure.AllowFill())
                {
                    fillColorPanel.BackColor = _figure.FillColor;
                    fillTransparencyTextBox.Text = _figure.FillColor.A.ToString();
                    fillTransparencyTrackBar.Value = _figure.FillColor.A;
                    fillColorPanel.Enabled = true;
                    fillTransparencyTextBox.Enabled = true;
                    fillTransparencyTrackBar.Enabled = true;
                }
                else
                {
                    fillColorPanel.Enabled = false;
                    fillTransparencyTextBox.Enabled = false;
                    fillTransparencyTrackBar.Enabled = false;
                    fillColorPanel.BackColor = SystemColors.Control;
                    fillTransparencyTextBox.Text = 0.ToString();
                    fillTransparencyTrackBar.Value = 0;
                }


                if (_figure.AllowText())
                {
                    fontTextBox.Enabled = true;
                    fontTextBox.Text = FontName(_figure.Font);
                    fontColorPanel.Enabled = true;
                    fontColorPanel.BackColor = _figure.FontColor;
                    fontColorBrowseBtn.Enabled = true;
                    browseFontBtn.Enabled = true;
                }
                else
                {
                    fontTextBox.Enabled = false;
                    fontTextBox.Text = "";
                    fontColorPanel.BackColor = SystemColors.Control;
                    fontColorPanel.Enabled = false;
                    fontColorBrowseBtn.Enabled = false;
                    browseFontBtn.Enabled = false;
                }
                //_figure.
            }
        }

        /// <summary>
        /// This method performs to get human readable string of the font
        /// </summary>
        /// <param name="font">font</param>
        /// <returns>HR string</returns>
        private static string FontName(Font font)
        {
            return string.Format("{0}, {1}, {2}", font.Name, font.SizeInPoints, font.Style);
        }

        /// <summary>
        /// This method performs to choose new color of the border
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseBorderColorBtnClick(object sender, EventArgs e)
        {
            var dialog = CustomColorDialog.GetInstance();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Color col = Color.FromArgb(borderTranparencyTrackBar.Value, dialog.Color);
                borderColorPanel.BackColor = col;
                if (_figure != null)
                {
                    _figure.BorderColor = col;
                }
            }
        }

        /// <summary>
        /// Closing form event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            _mouseChecker.Stop();
        }

        /// <summary>
        /// This method performs to change figure border transparency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void borderTranparencyTrackBar_ValueChanged(object sender, EventArgs e)
        {
            borderTransparencyTextBox.Text = borderTranparencyTrackBar.Value.ToString();
            if (_figure != null)
            {
                Color borderColor = Color.FromArgb(borderTranparencyTrackBar.Value, _figure.BorderColor);
                borderColorPanel.BackColor = borderColor;
                _figure.BorderColor = borderColor;
            }
        }

        /// <summary>
        /// This method performs to change border thickness
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void borderWidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_figure != null)
            {
                _figure.BorderSize = (int) borderWidthUpDown.Value;
            }
        }

        /// <summary>
        /// This method performs to change border color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void borderColorPanel_Click(object sender, EventArgs e)
        {
            BrowseBorderColorBtnClick(null, EventArgs.Empty);
        }

        /// <summary>
        /// This method performs to change fill color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseFillColorBtn_Click(object sender, EventArgs e)
        {
            var dialog = CustomColorDialog.GetInstance();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Color col = Color.FromArgb(fillTransparencyTrackBar.Value, dialog.Color);
                fillColorPanel.BackColor = col;
                if (_figure != null)
                {
                    _figure.FillColor = col;
                }
            }
        }

        /// <summary>
        /// This method performs to change fill color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fillColorPanel_Click(object sender, EventArgs e)
        {
            BrowseFillColorBtn_Click(null, EventArgs.Empty);
        }

        /// <summary>
        /// This method performs to change fill color transparency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fillTransparencyTrackBar_ValueChanged(object sender, EventArgs e)
        {
            fillTransparencyTextBox.Text = fillTransparencyTrackBar.Value.ToString();
            if (_figure != null)
            {
                Color color = Color.FromArgb(fillTransparencyTrackBar.Value, _figure.FillColor);
                fillColorPanel.BackColor = color;
                _figure.FillColor = color;
            }
        }

        /// <summary>
        /// This method performs to change figure text font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseFontBtn_Click(object sender, EventArgs e)
        {
            if (_figure != null)
            {
                var fd = new FontDialog();
                fd.Font = _figure.Font;
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    Font f = fd.Font;
                    fontTextBox.Text = FontName(f);
                    _figure.Font = f;
                }
            }
        }

        /// <summary>
        /// This method performs to change font color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fontColorBrowseBtn_Click(object sender, EventArgs e)
        {
            var dialog = CustomColorDialog.GetInstance();
            dialog.Color = _figure.FontColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fontColorPanel.BackColor = dialog.Color;
                if (_figure != null)
                {
                    _figure.FontColor = dialog.Color;
                }
            }
        }

        /// <summary>
        /// This method performs to change font color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontColorPanelClick(object sender, EventArgs e)
        {
            fontColorBrowseBtn_Click(null, EventArgs.Empty);
        }

        /// <summary>
        /// This method performs to react on the changing name of the figure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            if (_figure != null)
            {
                _figure.Name = nameTextBox.Text;
                UpdateFiguresList(_figures);
            }
        }

        /// <summary>
        /// This method performs to react on the current figure changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiguresComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _figure = figuresComboBox.SelectedItem as IFigure;
            if (SelectionChanged != null)
            {
                SelectionChanged(_figure, e);
                if (_figure != null)
                {
                    panel1.Enabled = true;
                }
                ReadFigureProperties();
            }
            if (figuresComboBox.SelectedItem is string)
            {
                panel1.Enabled = false;
            }
        }
    }
}