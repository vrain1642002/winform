using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace CustomButton
{
	public class VBButton : Button
	{
		private int borderSize = 0;
		private int borderRadius = 20;
		private Color borderColor = Color.PaleVioletRed;
		[Category("Custom Props")]
		public int BorderSize
		{
			get
			{
				return this.borderSize;
			}
			set
			{
				this.borderSize = value;
				base.Invalidate();
			}
		}
		[Category("Custom Props")]
		public int BorderRadius
		{
			get
			{
				return this.borderRadius;
			}
			set
			{
				this.borderRadius = value;
				base.Invalidate();
			}
		}
		[Category("Custom Props")]
		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				this.borderColor = value;
				base.Invalidate();
			}
		}
		[Category("Custom Props")]
		public Color BackgroundColor
		{
			get
			{
				return this.BackColor;
			}
			set
			{
				this.BackColor = value;
			}
		}
		[Category("Custom Props")]
		public Color TextColor
		{
			get
			{
				return this.ForeColor;
			}
			set
			{
				this.ForeColor = value;
			}
		}
		public VBButton()
		{
			base.FlatStyle = FlatStyle.Flat;
			base.FlatAppearance.BorderSize = 0;
			base.Size = new Size(150, 40);
			this.BackColor = Color.MediumSlateBlue;
			this.ForeColor = Color.White;
			base.Resize += new EventHandler(this.Button_Resize);
		}
		private GraphicsPath GetFigurePath(Rectangle rect, float radius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			float num = radius * 2f;
			graphicsPath.StartFigure();
			graphicsPath.AddArc((float)rect.X, (float)rect.Y, num, num, 180f, 90f);
			graphicsPath.AddArc((float)rect.Right - num, (float)rect.Y, num, num, 270f, 90f);
			graphicsPath.AddArc((float)rect.Right - num, (float)rect.Bottom - num, num, num, 0f, 90f);
			graphicsPath.AddArc((float)rect.X, (float)rect.Bottom - num, num, num, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Rectangle clientRectangle = base.ClientRectangle;
			Rectangle rect = Rectangle.Inflate(clientRectangle, -this.borderSize, -this.borderSize);
			int num = 2;
			bool flag = this.borderSize > 0;
			if (flag)
			{
				num = this.borderSize;
			}
			bool flag2 = this.borderRadius > 2;
			if (flag2)
			{
				using (GraphicsPath figurePath = this.GetFigurePath(clientRectangle, (float)this.borderRadius))
				{
					using (GraphicsPath figurePath2 = this.GetFigurePath(rect, (float)(this.borderRadius - this.borderSize)))
					{
						using (Pen pen = new Pen(base.Parent.BackColor, (float)num))
						{
							using (Pen pen2 = new Pen(this.borderColor, (float)this.borderSize))
							{
								base.Region = new Region(figurePath);
								pevent.Graphics.DrawPath(pen, figurePath);
								bool flag3 = this.borderSize >= 1;
								if (flag3)
								{
									pevent.Graphics.DrawPath(pen2, figurePath2);
								}
							}
						}
					}
				}
			}
			else
			{
				base.Region = new Region(clientRectangle);
				bool flag4 = this.borderSize >= 1;
				if (flag4)
				{
					using (Pen pen3 = new Pen(this.borderColor, (float)this.borderSize))
					{
						pen3.Alignment = PenAlignment.Inset;
						pevent.Graphics.DrawRectangle(pen3, 0, 0, base.Width - 1, base.Height - 1);
					}
				}
			}
		}
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			base.Parent.BackColorChanged += new EventHandler(this.Container_BackColorChanged);
		}
		private void Container_BackColorChanged(object sender, EventArgs e)
		{
			base.Invalidate();
		}
		private void Button_Resize(object sender, EventArgs e)
		{
			bool flag = this.borderRadius > base.Height;
			if (flag)
			{
				this.borderRadius = base.Height;
			}
		}
	}
}
