using bansach.Properties;
using CustomButton;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class MainNXB : Form
	{
		private IContainer components = null;
		private MenuStrip mnsNXB;
		private ContextMenuStrip contextMenuStrip1;
		private ContextMenuStrip contextMenuStrip2;
		private ToolStripMenuItem tmnTaoPN;
		private ToolStripMenuItem tmnXemPN;
		private ToolStripMenuItem tmnTT;
		private ToolStripMenuItem tmnDX;
		private ToolStripMenuItem tmnThoat;
		private Panel panel1;
		private VBButton vbButton1;
		public MainNXB()
		{
			this.InitializeComponent();
		}
		private void MainNXB_Load(object sender, EventArgs e)
		{
			base.KeyPreview = true;
		}
		private void MainNXB_KeyUp(object sender, KeyEventArgs e)
		{
			bool control = e.Control;
			if (control)
			{
				bool flag = e.KeyCode.Equals(Keys.P);
				if (flag)
				{
					this.tmnTaoPN_Click(null, null);
				}
				bool flag2 = e.KeyCode.Equals(Keys.X);
				if (flag2)
				{
					this.tmnXemPN_Click(null, null);
				}
				bool flag3 = e.KeyCode.Equals(Keys.S);
				if (flag3)
				{
					this.tmnTT_Click(null, null);
				}
				bool flag4 = e.KeyCode.Equals(Keys.D);
				if (flag4)
				{
					this.tmnDX_Click(null, null);
				}
				bool flag5 = e.KeyCode.Equals(Keys.T);
				if (flag5)
				{
					this.tmnThoat_Click(null, null);
				}
				bool flag6 = e.KeyCode.Equals(Keys.LWin);
				if (flag6)
				{
					base.Close();
				}
			}
		}
		private void tmnTaoPN_Click(object sender, EventArgs e)
		{
			base.Hide();
			NXB_TaoPhieuNhap nXB_TaoPhieuNhap = new NXB_TaoPhieuNhap();
			nXB_TaoPhieuNhap.ShowDialog();
		}
		private void tmnXemPN_Click(object sender, EventArgs e)
		{
			base.Hide();
			NXB_XemPhieuNhap nXB_XemPhieuNhap = new NXB_XemPhieuNhap();
			nXB_XemPhieuNhap.ShowDialog();
		}
		private void tmnTT_Click(object sender, EventArgs e)
		{
			base.Hide();
			NXB_XemThongTinNXB nXB_XemThongTinNXB = new NXB_XemThongTinNXB();
			nXB_XemThongTinNXB.ShowDialog();
		}
		private void tmnDX_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void tmnThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainNXB));
			this.mnsNXB = new MenuStrip();
			this.tmnTaoPN = new ToolStripMenuItem();
			this.tmnXemPN = new ToolStripMenuItem();
			this.tmnTT = new ToolStripMenuItem();
			this.tmnDX = new ToolStripMenuItem();
			this.tmnThoat = new ToolStripMenuItem();
			this.contextMenuStrip1 = new ContextMenuStrip(this.components);
			this.contextMenuStrip2 = new ContextMenuStrip(this.components);
			this.panel1 = new Panel();
			this.vbButton1 = new VBButton();
			this.mnsNXB.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.mnsNXB.BackColor = Color.LavenderBlush;
			this.mnsNXB.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.mnsNXB.Items.AddRange(new ToolStripItem[]
			{
				this.tmnTaoPN,
				this.tmnXemPN,
				this.tmnTT,
				this.tmnDX,
				this.tmnThoat
			});
			this.mnsNXB.Location = new Point(0, 0);
			this.mnsNXB.Name = "mnsNXB";
			this.mnsNXB.Size = new Size(1058, 35);
			this.mnsNXB.TabIndex = 0;
			this.mnsNXB.Text = "menuStrip1";
			this.tmnTaoPN.BackColor = Color.LavenderBlush;
			this.tmnTaoPN.ForeColor = SystemColors.ControlText;
			this.tmnTaoPN.Image = Resources.HD1;
			this.tmnTaoPN.Name = "tmnTaoPN";
			this.tmnTaoPN.Size = new Size(196, 31);
			this.tmnTaoPN.Text = "Tạo &Phiếu Nhập";
			this.tmnTaoPN.Click += new EventHandler(this.tmnTaoPN_Click);
			this.tmnXemPN.Image = Resources.searchmagnifierinterfacesymbol1_79893;
			this.tmnXemPN.Name = "tmnXemPN";
			this.tmnXemPN.Size = new Size(205, 31);
			this.tmnXemPN.Text = "&Xem Phiếu Nhập";
			this.tmnXemPN.Click += new EventHandler(this.tmnXemPN_Click);
			this.tmnTT.Image = Resources.msn_user_avatar_person_people_icon_124220;
			this.tmnTT.Name = "tmnTT";
			this.tmnTT.Size = new Size(405, 31);
			this.tmnTT.Text = "Xem và &Sửa Thông Tin Nhà Xuất Bản";
			this.tmnTT.Click += new EventHandler(this.tmnTT_Click);
			this.tmnDX.Image = Resources.out_log_icon_218015;
			this.tmnDX.Name = "tmnDX";
			this.tmnDX.Size = new Size(139, 31);
			this.tmnDX.Text = "&Đăng xuất";
			this.tmnDX.Click += new EventHandler(this.tmnDX_Click);
			this.tmnThoat.Image = Resources.cancel_962451;
			this.tmnThoat.Name = "tmnThoat";
			this.tmnThoat.Size = new Size(96, 31);
			this.tmnThoat.Text = "&Thoát";
			this.tmnThoat.Click += new EventHandler(this.tmnThoat_Click);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(61, 4);
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new Size(61, 4);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = SystemColors.InactiveBorder;
			this.panel1.BackgroundImage = Resources._86348578_2543488405780768_8176631147531337728_n2;
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.vbButton1);
			this.panel1.Location = new Point(0, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1058, 618);
			this.panel1.TabIndex = 3;
			this.vbButton1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.vbButton1.BackColor = Color.Transparent;
			this.vbButton1.BackgroundColor = Color.Transparent;
			this.vbButton1.BorderColor = Color.Pink;
			this.vbButton1.BorderRadius = 5;
			this.vbButton1.BorderSize = 1;
			this.vbButton1.FlatAppearance.BorderSize = 0;
			this.vbButton1.FlatStyle = FlatStyle.Flat;
			this.vbButton1.Font = new Font("Sitka Display", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.vbButton1.ForeColor = Color.Red;
			this.vbButton1.Location = new Point(219, 563);
			this.vbButton1.Name = "vbButton1";
			this.vbButton1.Size = new Size(645, 48);
			this.vbButton1.TabIndex = 7;
			this.vbButton1.TabStop = false;
			this.vbButton1.Text = "CHÀO MỪNG BẠN ĐẾN TRANG NHÀ  XUẤT BẢN";
			this.vbButton1.TextColor = Color.Red;
			this.vbButton1.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1058, 657);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.mnsNXB);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.mnsNXB;
			base.MaximizeBox = false;
			base.Name = "MainNXB";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "TRANG NHÀ XUẤT BẢN";
			base.Load += new EventHandler(this.MainNXB_Load);
			base.KeyUp += new KeyEventHandler(this.MainNXB_KeyUp);
			this.mnsNXB.ResumeLayout(false);
			this.mnsNXB.PerformLayout();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
