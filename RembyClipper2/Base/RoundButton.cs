using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using RembyClipper.Helpers;

namespace RembyClipper2.Base
{
	public class RoundButtonBase : Control, IButtonControl
	{
		#region Fields

		private Container components = null;

		public enum States
		{
			Normal,
			MouseOver,
			Pushed
		}

		protected States state = States.Normal;
		protected GraphicsPath path;
		protected ToolTip toolTip;
		private Rectangle bounds;
		private Image image;
		private StringFormat sf;
		private Color textColor = SystemColors.ControlText;
		private SolidBrush textBrush;
		private Point iPoint, tPoint;
		protected bool isDefault = false;
		private DialogResult dialogResult = DialogResult.None;

		#endregion

		#region Constructor

        public RoundButtonBase()
		{
			try
			{
				SetStyle(ControlStyles.DoubleBuffer, true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				SetStyle(ControlStyles.UserPaint, true);
				SetStyle(ControlStyles.SupportsTransparentBackColor, true);
				SetStyle(ControlStyles.StandardDoubleClick, false);
				SetStyle(ControlStyles.Selectable, true);
				Size = new Size(10, 10);
				ResizeRedraw = true;
				toolTip = new ToolTip();
			}
			catch(Exception exc)
			{
                DebugHelper.Log(exc.ToString());
			}

		}

		#endregion

		#region Public Properties

		[DefaultValue(null),
			RefreshProperties(RefreshProperties.Repaint)]
		public Image Image
		{
			get { return image; }
			set
			{
				image = value;
				Invalidate();
			}
		}

		public override string Text
		{
			get { return base.Text; }
			set
			{
				base.Text = value;
				Invalidate();
			}
		}

		[DefaultValue(typeof (Color), "ControlText"),
			RefreshProperties(RefreshProperties.Repaint)]
		public Color TextColor
		{
			get { return textColor; }
			set
			{
				textColor = value;
				if (textBrush != null) textBrush.Dispose();
				textBrush = new SolidBrush(textColor);
				Invalidate();
			}
		}

		public String Hint
		{
			get { return toolTip.GetToolTip(this); }
			set
			{
				toolTip.RemoveAll();
				toolTip.SetToolTip(this, value);
			}
		}

		#endregion

		#region Protected Methods

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				DisposePensBrushes();
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (!bounds.Contains(e.X, e.Y)) state = States.Normal;
			else state = States.MouseOver;
			Invalidate(bounds);
			base.OnMouseMove(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			state = States.MouseOver;
			Invalidate(bounds);
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			state = States.Normal;
			Invalidate();
			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;

			if (bounds.Contains(e.X, e.Y))
			{
				state = States.Pushed;
				Focus();
			}
			else state = States.Normal;
			Invalidate(bounds);
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				state = States.Normal;
			Invalidate(bounds);
			base.OnMouseUp(e);
		}

		protected override void OnEnter(EventArgs e)
		{
			Invalidate(bounds);
			base.OnEnter(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			Invalidate(bounds);
			base.OnLeave(e);
		}

		protected override void OnClick(EventArgs e)
		{
			if (state == States.Pushed)
			{
				state = States.Normal;
				Invalidate(bounds);
			}
			if (dialogResult != DialogResult.None)
			{
				Form form = FindForm();
				form.DialogResult = DialogResult;
			}
			base.OnClick(e);
		}

		protected override void OnKeyDown(KeyEventArgs ke)
		{
			if (ke.KeyData == Keys.Enter || ke.KeyData == Keys.Space)
				PerformClick();
			base.OnKeyDown(ke);
		}

		protected override void OnKeyUp(KeyEventArgs ke)
		{
			base.OnKeyUp(ke);
		}

		protected override bool ProcessMnemonic(char charCode)
		{
			if (IsMnemonic(charCode, base.Text))
			{
				PerformClick();
				return true;
			}
			return base.ProcessMnemonic(charCode);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			bounds = new Rectangle(0, 0, Width, Height);
			OnParentChanged(e);
			base.OnSizeChanged(e);
		}

		protected override void OnParentChanged(EventArgs e)
		{
			if (Parent == null) return;
			GetPoints();
			CreateRegion();
			base.OnParentChanged(e);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			if (sf != null) sf.Dispose();
			sf = new StringFormat();
			sf.HotkeyPrefix = HotkeyPrefix.Show;
			GetPoints();
			base.OnTextChanged(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			GetPoints();
			if (image != null)
			{
				if (Enabled) e.Graphics.DrawImage(image, iPoint);
				else ControlPaint.DrawImageDisabled(e.Graphics, image, iPoint.X, iPoint.Y, BackColor);
			}

			e.Graphics.DrawString(Text, Font, textBrush, tPoint, StringFormat.GenericTypographic);
		}

		#endregion

		#region Private Methods

		private void GetPoints()
		{
			int X = Width, Y = Height;

			if (Image != null)
			{
				if (Text.Length == 0) iPoint = new Point((X - Image.Width)/2, (Y - Image.Height)/2);
				else iPoint = new Point(BT.LeftMargin, (Y - Image.Height)/2);

				tPoint = new Point(BT.LeftMargin + Image.Width + BT.TextMargin, (Y - Font.Height)/2);
			}
			else
			{
				Size size = TextUtil.GetTextSize(CreateGraphics(), Text.Replace("&", ""), Font, new Size(X, Y));
				tPoint = new Point((X - size.Width - 2)/2, (Y - Font.Height)/2);
			}
		}

		#endregion

		#region Virtual methods

		protected virtual void CreateRegion()
		{
		}

		protected virtual void CreatePensBrushes()
		{
			if (textBrush != null) textBrush.Dispose();
			textBrush = new SolidBrush(textColor);
		}

		protected virtual void DisposePensBrushes()
		{
			if (textBrush != null) textBrush.Dispose();
		}

		#endregion

		#region Implementation of IButtonControl

		public void PerformClick()
		{
			if (CanSelect)
			{
				OnClick(EventArgs.Empty);
			}
		}

		public void NotifyDefault(bool value)
		{
			isDefault = value;
			Invalidate();
		}

		public DialogResult DialogResult
		{
			get { return dialogResult; }
			set { dialogResult = value; }
		}

		#endregion
	}

	public class RoundButton : RoundButtonBase 
	{
		public int radius = 5;

		[DefaultValue(5),
			RefreshProperties(RefreshProperties.Repaint)]
		public int Radius
		{
			get { return radius; }
			set
			{
				radius = value;
				Invalidate();
			}
		}

		#region Pens & Brushes

		private Rectangle[] rects0;
		private Rectangle[] rects1;

		private LinearGradientBrush
			mainEnabledBrush, enabledGradientBrush;

		private SolidBrush
			notEnabledBrush01, notEnabledBrush02;

		private Pen
			drawNormalPen01,
			drawNormalPen02,
			drawHoverPen02,
			drawHoverPen01,
			enabledRectPen,
			notEnabledPen01,
			notEnabledPen02;

	    public Color notEnabledBrush01Color { get; set; }
        public Color notEnabledBrush02Color { get; set; }
        public Color notEnabledPen01Color { get; set; }
        public Color notEnabledPen02Color { get; set; }
        public Color enabledRectPenColor { get; set; }
        public Color mainEnabledGradientBrush01Color1 { get; set; }
        public Color mainEnabledGradientBrush01Color2 { get; set; }
        public Color normalPen1Color { get; set; }
        public Color normalPen2Color { get; set; }
        public Color hoverPen01Color { get; set; }
        public Color hoverPen02Color { get; set; }
        public Color enabledGradientBrushColor1 { get; set; }
        public Color enabledGradientBrushColor2 { get; set; }

	    public RoundButton()
	    {
	        notEnabledBrush01Color = Color.FromArgb(64, 201, 199, 186);
	        notEnabledBrush02Color = Color.FromArgb(245, 244, 234);
	        notEnabledPen01Color = Color.FromArgb(201, 199, 186);
	        notEnabledPen02Color = Color.FromArgb(170, 201, 199, 186);
	        enabledRectPenColor = Color.FromArgb(0, 60, 116);
	        mainEnabledGradientBrush01Color1 = Color.FromArgb(64, 171, 168, 137);
	        mainEnabledGradientBrush01Color2 = Color.FromArgb(92, 255, 255, 255);
	        normalPen1Color = Color.FromArgb(188, 212, 246);
	        normalPen2Color = Color.FromArgb(137, 173, 228);
	        hoverPen01Color = Color.FromArgb(253, 216, 137);
	        hoverPen02Color = Color.FromArgb(248, 178, 48);
	        enabledGradientBrushColor1 = Color.FromArgb(255, 255, 255);
	        enabledGradientBrushColor2 = Color.FromArgb(240, 240, 234);
	    }

	    #endregion

		#region Constructor

		#endregion

		#region Protected Methods

		protected override void OnPaint(PaintEventArgs e)
		{
			SmoothingMode oldSmoothingMode = e.Graphics.SmoothingMode;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			int X = Width;
			int Y = Height;

			CreatePensBrushes();

			e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
			if (!Enabled)
			{
				//e.Graphics.FillPath( notEnabledBrush02, CreateSolidRoundRectPath( 2, 2, X-4, Y-4, Radius ) );
				FillRRect(e.Graphics, notEnabledBrush02);

				e.Graphics.DrawLine(notEnabledPen01, 3, 1, X - 4, 1);
				e.Graphics.DrawLine(notEnabledPen01, 3, Y - 2, X - 4, Y - 2);
				e.Graphics.DrawLine(notEnabledPen01, 1, 3, 1, Y - 4);
				e.Graphics.DrawLine(notEnabledPen01, X - 2, 3, X - 2, Y - 4);

				e.Graphics.DrawLine(notEnabledPen02, 1, 2, 2, 1);
				e.Graphics.DrawLine(notEnabledPen02, 1, Y - 3, 2, Y - 2);
				e.Graphics.DrawLine(notEnabledPen02, X - 2, 2, X - 3, 1);
				e.Graphics.DrawLine(notEnabledPen02, X - 2, Y - 3, X - 3, Y - 2);
				e.Graphics.FillRectangles(notEnabledBrush01, rects1);
			}
			else
			{
				FillRRect(e.Graphics, mainEnabledBrush);
				switch (state)
				{
					case States.Normal:
						Rectangle rect = ClientRectangle;
					rect.Width += 2;
						FillRRect(e.Graphics, enabledGradientBrush, rect);
						if (isDefault)
						{
							DrawHover(e.Graphics, drawNormalPen02, drawNormalPen01);
						}
						break;

					case States.MouseOver:
						FillRRect(e.Graphics, notEnabledBrush01);
						DrawHover(e.Graphics, drawHoverPen01, drawHoverPen02);
						break;
				}

				Rectangle r = ClientRectangle;
				r.Width--;
				r.Height--;
				DrawRect(e.Graphics, enabledRectPen, r);

				int OffsX = radius/2;
				int OffsY = radius/2;
				if (radius/2 < 4)
				{
					OffsX = OffsY = 4;
				}
				if (Focused) ControlPaint.DrawFocusRectangle(e.Graphics,
				                                                  new Rectangle(OffsX, OffsY, X - OffsX*2, Y - OffsY*2), Color.Black,
				                                                  BackColor);
			}

			base.OnPaint(e);
			DisposePensBrushes();

			e.Graphics.SmoothingMode = oldSmoothingMode;
		}

		protected override void OnParentChanged(EventArgs e)
		{
			if (Parent == null) return;
			BackColor = Color.FromArgb(0, Parent.BackColor);
			base.OnParentChanged(e);
		}

		protected override void CreatePensBrushes()
		{
			DisposePensBrushes();
			if (Region == null) return;

			int X = Width;
			int Y = Height;

			mainEnabledBrush =
				new LinearGradientBrush(
					new Rectangle(0, 0, X, Y), mainEnabledGradientBrush01Color1, mainEnabledGradientBrush01Color2, 85.0f);
			drawNormalPen01 = new Pen(normalPen1Color);
			drawNormalPen02 = new Pen(normalPen2Color);
			drawHoverPen02 = new Pen(hoverPen01Color);
			drawHoverPen01 = new Pen(hoverPen02Color);
			enabledRectPen = new Pen(enabledRectPenColor);

			notEnabledBrush01 = new SolidBrush(notEnabledBrush01Color);
			notEnabledBrush02 = new SolidBrush(notEnabledBrush02Color);
			notEnabledPen01 = new Pen(notEnabledPen01Color);
			notEnabledPen02 = new Pen(notEnabledPen02Color);


			enabledGradientBrush =
				new LinearGradientBrush(
					new Rectangle(2, 2, X - 5, Y - 7), enabledGradientBrushColor1, enabledGradientBrushColor2, 90.0f);

			Rectangle rect = new Rectangle(2, 3, X - 4, Y - 7);


			base.CreatePensBrushes();
		}

		private Pen CreateGradPen(Rectangle rect, Color c1, Color c2, float angle)
		{
			LinearGradientBrush _brush = new LinearGradientBrush(rect, c1, c2, angle);
			Pen result = new Pen(_brush);
			_brush.Dispose();
			return result;
		}

		protected override void DisposePensBrushes()
		{
			if (enabledGradientBrush != null) enabledGradientBrush.Dispose();

			if (drawNormalPen01 != null) drawNormalPen01.Dispose();
			if (drawNormalPen02 != null) drawNormalPen02.Dispose();
			if (drawHoverPen02 != null) drawHoverPen02.Dispose();
			if (drawHoverPen01 != null) drawHoverPen01.Dispose();
			if (enabledRectPen != null) enabledRectPen.Dispose();

			if (notEnabledBrush01 != null) notEnabledBrush01.Dispose();
			if (notEnabledBrush02 != null) notEnabledBrush02.Dispose();
			if (notEnabledPen01 != null) notEnabledPen01.Dispose();
			if (notEnabledPen02 != null) notEnabledPen02.Dispose();

			base.DisposePensBrushes();
		}

		protected override void CreateRegion()
		{
			int X = Width;
			int Y = Height;

			rects0 = new Rectangle[2];
			rects0[0] = new Rectangle(2, 4, 2, Y - 8);
			rects0[1] = new Rectangle(X - 4, 4, 2, Y - 8);

			rects1 = new Rectangle[8];
			rects1[0] = new Rectangle(2, 1, 2, 2);
			rects1[1] = new Rectangle(1, 2, 2, 2);
			rects1[2] = new Rectangle(X - 4, 1, 2, 2);
			rects1[3] = new Rectangle(X - 3, 2, 2, 2);
			rects1[4] = new Rectangle(2, Y - 3, 2, 2);
			rects1[5] = new Rectangle(1, Y - 4, 2, 2);
			rects1[6] = new Rectangle(X - 4, Y - 3, 2, 2);
			rects1[7] = new Rectangle(X - 3, Y - 4, 2, 2);

			Point[] points = {
			                 	new Point(1, 0),
			                 	new Point(X - 1, 0),
			                 	new Point(X - 1, 1),
			                 	new Point(X, 1),
			                 	new Point(X, Y - 1),
			                 	new Point(X - 1, Y - 1),
			                 	new Point(X - 1, Y),
			                 	new Point(1, Y),
			                 	new Point(1, Y - 1),
			                 	new Point(0, Y - 1),
			                 	new Point(0, 1),
			                 	new Point(1, 1)
			                 };

			GraphicsPath path = new GraphicsPath();
			path.AddLines(points);

			Region = new Region(path);
			base.CreateRegion();
		}

		#endregion

		private GraphicsPath CreateRoundRectPath(Rectangle r, int radius)
		{
			if (radius < 1) radius = 1;
			GraphicsPath gp = new GraphicsPath();

			gp.AddArc(new Rectangle(r.X, r.Y, radius*2, radius*2), 180, 90);
			gp.AddArc(new Rectangle(r.X + r.Width - radius*2, r.Y, radius*2, radius*2), 270, 90);
			gp.AddArc(new Rectangle(r.X + r.Width - radius*2, r.Y + r.Height - radius*2, radius*2, radius*2), 0, 90);
			gp.AddArc(new Rectangle(r.X, r.Y + r.Height - radius*2, radius*2, radius*2), 90, 90);
			gp.CloseFigure();
			return gp;
		}

		private GraphicsPath CreateRoundRectPath(int x, int y, int w, int h, int radius)
		{
			return CreateRoundRectPath(new Rectangle(x, y, w, h), radius);
		}

		private void DrawRect(Graphics e, Pen p, Rectangle r)
		{
			e.DrawPath(p, CreateRoundRectPath(r, radius));
		}

		private void DrawRect(Graphics e, Pen p, int x, int y, int w, int h)
		{
			e.DrawPath(p, CreateRoundRectPath(x, y, w, h, radius));
		}

		private void DrawRect(Graphics e, Pen p)
		{
			e.DrawPath(p, CreateRoundRectPath(ClientRectangle, radius));
		}

		private void FillRRect(Graphics e, Brush b, int x, int y, int w, int h)
		{
			e.FillPath(b, CreateRoundRectPath(x, y, w, h, radius));
		}

		private void FillRRect(Graphics e, Brush b)
		{
			e.FillPath(b, CreateRoundRectPath(ClientRectangle, radius));
		}

		private void FillRRect(Graphics e, Brush b, Rectangle rect)
		{
			e.FillPath(b, CreateRoundRectPath(rect, radius));
		}

		private void DrawHover(Graphics g, Pen pen1, Pen pen2)
		{
			SmoothingMode oldSmoothingMode = g.SmoothingMode;
			g.SmoothingMode = SmoothingMode.AntiAlias;

			Rectangle rcBorder = ClientRectangle;

			//			rcBorder.X += 1;
			//			rcBorder.Y += 1;
			rcBorder.Width -= 1;
			rcBorder.Height -= 1;

			int r = radius;

			using (GraphicsPath gp1 = CreateRoundRectPath(
				new Rectangle(rcBorder.Left + 1, rcBorder.Top + 1, rcBorder.Width - 2, rcBorder.Height - 2),
				r))
			using (GraphicsPath gp2 = CreateRoundRectPath(
				new Rectangle(rcBorder.Left + 2, rcBorder.Top + 2, rcBorder.Width - 4, rcBorder.Height - 4),
				r - 1))
			{
				g.DrawPath(pen1, gp1);
				g.DrawPath(pen2, gp2);
			}

			g.SmoothingMode = oldSmoothingMode;
		}


	}

	public struct BT
	{
		public const int LeftMargin = 7;
		public const int TextMargin = 7;
	}

	public class TextUtil
	{
		public static Size GetTextSize(Graphics graphics, string text, Font font, Size size)
		{
			if (text.Length == 0) return Size.Empty;

			StringFormat format = new StringFormat();
			format.FormatFlags = StringFormatFlags.FitBlackBox; //MeasureTrailingSpaces;

			RectangleF layoutRect = new RectangleF(0, 0, size.Width, size.Height);
			CharacterRange[] chRange = {new CharacterRange(0, text.Length)};
			Region[] regs = new Region[1];

			format.SetMeasurableCharacterRanges(chRange);

			regs = graphics.MeasureCharacterRanges(text, font, layoutRect, format);
			Rectangle rect = Rectangle.Round(regs[0].GetBounds(graphics));

			return new Size(rect.Width, rect.Height);
		}

		private TextUtil()
		{
		}
	}

}