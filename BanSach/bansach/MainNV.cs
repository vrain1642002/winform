using bansach.Properties;
using CustomButton;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class MainNV : Form
	{
		private CXuLyLichSuHD xuLyLichSuHD;
		private IContainer components = null;
		private MenuStrip mnsNV;
		private ToolStripMenuItem tsmQuanLy;
		private ToolStripMenuItem tsmThongKe;
		private ToolStripMenuItem tsmBanSach;
		private ToolStripMenuItem tsmTTNV;
		private ToolStripMenuItem tsmDangXuat;
		private ToolStripMenuItem tsmThoat;
		private ToolStripMenuItem tmsXemHD;
		private Panel panel1;
		private VBButton vbButton1;
		public MainNV()
		{
			this.InitializeComponent();
		}
		private void tsmQuanLy_Click(object sender, EventArgs e)
		{
			bool flag = CConst.Nhanvien.LoaiNV == "Quản Lý";
			if (flag)
			{
				base.Hide();
				MainQL mainQL = new MainQL();
				mainQL.ShowDialog();
				base.Close();
			}
			else
			{
				MessageBox.Show("Bạn không phải là quản lý không thể truy cập vào được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void tsmThongKe_Click(object sender, EventArgs e)
		{
			base.Hide();
			NV_ThongKe nV_ThongKe = new NV_ThongKe();
			nV_ThongKe.ShowDialog();
			base.Close();
		}
		private void tsmBanSach_Click(object sender, EventArgs e)
		{
			base.Hide();
			NV_BanSach nV_BanSach = new NV_BanSach();
			nV_BanSach.ShowDialog();
			base.Close();
		}
		private void tmsXemHD_Click(object sender, EventArgs e)
		{
			base.Hide();
			NV_XemHoaDon nV_XemHoaDon = new NV_XemHoaDon();
			nV_XemHoaDon.ShowDialog();
			base.Close();
		}
		private void tsmTTNV_Click(object sender, EventArgs e)
		{
			base.Hide();
			NV_XemThongTinCN nV_XemThongTinCN = new NV_XemThongTinCN();
			nV_XemThongTinCN.ShowDialog();
			base.Close();
		}
		private void tsmDangXuat_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void tsmThoat_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void MainNV_Load(object sender, EventArgs e)
		{
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			this.xuLyLichSuHD.docFile("LichSuHD.dat");
			base.KeyPreview = true;
		}
		private void MainNV_KeyUp(object sender, KeyEventArgs e)
		{
			bool control = e.Control;
			if (control)
			{
				bool flag = e.KeyCode.Equals(Keys.Q);
				if (flag)
				{
					this.tsmQuanLy_Click(null, null);
				}
				bool flag2 = e.KeyCode.Equals(Keys.K);
				if (flag2)
				{
					this.tsmThongKe_Click(null, null);
				}
				bool flag3 = e.KeyCode.Equals(Keys.B);
				if (flag3)
				{
					this.tsmBanSach_Click(null, null);
				}
				bool flag4 = e.KeyCode.Equals(Keys.H);
				if (flag4)
				{
					this.tmsXemHD_Click(null, null);
				}
				bool flag5 = e.KeyCode.Equals(Keys.N);
				if (flag5)
				{
					this.tsmTTNV_Click(null, null);
				}
				bool flag6 = e.KeyCode.Equals(Keys.G);
				if (flag6)
				{
					this.tsmDangXuat_Click(null, null);
				}
				bool flag7 = e.KeyCode.Equals(Keys.T);
				if (flag7)
				{
					this.tsmThoat_Click(null, null);
				}
				bool flag8 = e.KeyCode.Equals(Keys.LWin);
				if (flag8)
				{
					base.Close();
				}
			}
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainNV));
			this.mnsNV = new MenuStrip();
			this.tsmQuanLy = new ToolStripMenuItem();
			this.tsmThongKe = new ToolStripMenuItem();
			this.tsmBanSach = new ToolStripMenuItem();
			this.tmsXemHD = new ToolStripMenuItem();
			this.tsmTTNV = new ToolStripMenuItem();
			this.tsmDangXuat = new ToolStripMenuItem();
			this.tsmThoat = new ToolStripMenuItem();
			this.panel1 = new Panel();
			this.vbButton1 = new VBButton();
			this.mnsNV.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.mnsNV.BackColor = Color.LavenderBlush;
			this.mnsNV.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.mnsNV.Items.AddRange(new ToolStripItem[]
			{
				this.tsmQuanLy,
				this.tsmThongKe,
				this.tsmBanSach,
				this.tmsXemHD,
				this.tsmTTNV,
				this.tsmDangXuat,
				this.tsmThoat
			});
			this.mnsNV.Location = new Point(0, 0);
			this.mnsNV.Name = "mnsNV";
			this.mnsNV.Padding = new Padding(12, 4, 0, 4);
			this.mnsNV.Size = new Size(1168, 39);
			this.mnsNV.TabIndex = 0;
			this.mnsNV.Text = "menuStrip1";
			this.tsmQuanLy.BackgroundImageLayout = ImageLayout.None;
			this.tsmQuanLy.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmQuanLy.Image = Resources.lockicon_120641;
			this.tsmQuanLy.Name = "tsmQuanLy";
			this.tsmQuanLy.ShortcutKeys = (Keys)131137;
			this.tsmQuanLy.Size = new Size(116, 31);
			this.tsmQuanLy.Text = "&Quản lý";
			this.tsmQuanLy.Click += new EventHandler(this.tsmQuanLy_Click);
			this.tsmThongKe.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmThongKe.Image = Resources.statisticalchart_102630;
			this.tsmThongKe.Name = "tsmThongKe";
			this.tsmThongKe.ShortcutKeys = (Keys)131155;
			this.tsmThongKe.Size = new Size(135, 31);
			this.tsmThongKe.Text = "Thống &Kê";
			this.tsmThongKe.Click += new EventHandler(this.tsmThongKe_Click);
			this.tsmBanSach.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmBanSach.Image = Resources.emptyshoppingcart_shopingcart_carritodelacompravacio_4565;
			this.tsmBanSach.Name = "tsmBanSach";
			this.tsmBanSach.ShortcutKeys = (Keys)131140;
			this.tsmBanSach.Size = new Size(131, 31);
			this.tsmBanSach.Text = "&Bán Sách";
			this.tsmBanSach.Click += new EventHandler(this.tsmBanSach_Click);
			this.tmsXemHD.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tmsXemHD.Image = Resources.ecommerce_receipt_dollar_39921;
			this.tmsXemHD.Name = "tmsXemHD";
			this.tmsXemHD.ShortcutKeys = (Keys)131142;
			this.tmsXemHD.Size = new Size(180, 31);
			this.tmsXemHD.Text = "Xem &Hóa Đơn";
			this.tmsXemHD.Click += new EventHandler(this.tmsXemHD_Click);
			this.tsmTTNV.BackColor = Color.LavenderBlush;
			this.tsmTTNV.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmTTNV.Image = Resources.humman;
			this.tsmTTNV.Name = "tsmTTNV";
			this.tsmTTNV.ShortcutKeys = (Keys)131162;
			this.tsmTTNV.Size = new Size(352, 31);
			this.tsmTTNV.Text = "Xem và Sửa Thông Tin Cá &Nhân";
			this.tsmTTNV.TextAlign = ContentAlignment.TopRight;
			this.tsmTTNV.Click += new EventHandler(this.tsmTTNV_Click);
			this.tsmDangXuat.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmDangXuat.Image = Resources.out_log_icon_2180151;
			this.tsmDangXuat.Name = "tsmDangXuat";
			this.tsmDangXuat.ShortcutKeys = (Keys)131160;
			this.tsmDangXuat.Size = new Size(144, 31);
			this.tsmDangXuat.Text = "Đăn&g Xuất";
			this.tsmDangXuat.Click += new EventHandler(this.tsmDangXuat_Click);
			this.tsmThoat.BackColor = Color.LavenderBlush;
			this.tsmThoat.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmThoat.Image = Resources.cancel_96245;
			this.tsmThoat.Name = "tsmThoat";
			this.tsmThoat.ShortcutKeys = (Keys)131139;
			this.tsmThoat.Size = new Size(96, 31);
			this.tsmThoat.Text = "&Thoát";
			this.tsmThoat.Click += new EventHandler(this.tsmThoat_Click);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = SystemColors.InactiveBorder;
			this.panel1.BackgroundImage = Resources._86348578_2543488405780768_8176631147531337728_n2;
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.vbButton1);
			this.panel1.Location = new Point(0, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1166, 679);
			this.panel1.TabIndex = 1;
			this.vbButton1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.vbButton1.BackColor = Color.Transparent;
			this.vbButton1.BackgroundColor = Color.Transparent;
			this.vbButton1.BorderColor = Color.Pink;
			this.vbButton1.BorderRadius = 5;
			this.vbButton1.BorderSize = 1;
			this.vbButton1.FlatAppearance.BorderSize = 0;
			this.vbButton1.FlatStyle = FlatStyle.Flat;
			this.vbButton1.Font = new Font("Sitka Display", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.vbButton1.ForeColor = Color.Red;
			this.vbButton1.Location = new Point(219, 619);
			this.vbButton1.Name = "vbButton1";
			this.vbButton1.Size = new Size(724, 53);
			this.vbButton1.TabIndex = 6;
			this.vbButton1.TabStop = false;
			this.vbButton1.Text = "CHÀO MỪNG BẠN ĐẾN TRANG  NHÂN VIÊN";
			this.vbButton1.TextColor = Color.Red;
			this.vbButton1.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new SizeF(12f, 23f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.BackColor = SystemColors.Control;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(1168, 716);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.mnsNV);
			this.Font = new Font("Times New Roman", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.mnsNV;
			base.Margin = new Padding(6, 5, 6, 5);
			base.MaximizeBox = false;
			base.Name = "MainNV";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "NHÂN VIÊN";
			base.Load += new EventHandler(this.MainNV_Load);
			base.KeyUp += new KeyEventHandler(this.MainNV_KeyUp);
			this.mnsNV.ResumeLayout(false);
			this.mnsNV.PerformLayout();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
