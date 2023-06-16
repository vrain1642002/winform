using bansach.Properties;
using CustomButton;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class MainQL : Form
	{
		private IContainer components = null;
		private Panel panel1;
		private MenuStrip mnsQL;
		private ToolStripMenuItem tsmXacNhanPN;
		private ToolStripMenuItem tsmThongKe;
		private ToolStripMenuItem tsmDMS;
		private ToolStripMenuItem tsmQlNXB;
		private ToolStripMenuItem tsmQLNV;
		private ToolStripMenuItem tsmLichSuHD;
		private ToolStripMenuItem tsmQuayVe;
		private VBButton vbButton1;
		public MainQL()
		{
			this.InitializeComponent();
		}
		private void MainQL_Load(object sender, EventArgs e)
		{
			base.KeyPreview = true;
		}
		private void XacNhanPNToolStripMenuItem_Click(object sender, EventArgs e)
		{
			QL_XacNhanPN qL_XacNhanPN = new QL_XacNhanPN();
			qL_XacNhanPN.ShowDialog();
		}
		private void baocaoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			QL_BaoCao qL_BaoCao = new QL_BaoCao();
			qL_BaoCao.ShowDialog();
		}
		private void DanhMucSachToolStripMenuItem_Click(object sender, EventArgs e)
		{
			QL_DanhMucSach qL_DanhMucSach = new QL_DanhMucSach();
			qL_DanhMucSach.ShowDialog();
		}
		private void QLNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ql_NhanVien ql_NhanVien = new Ql_NhanVien();
			ql_NhanVien.ShowDialog();
		}
		private void QLNXBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			QL_NhaXuatBan qL_NhaXuatBan = new QL_NhaXuatBan();
			qL_NhaXuatBan.ShowDialog();
		}
		private void LichSuHDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ql_LichSuHoatDong ql_LichSuHoatDong = new Ql_LichSuHoatDong();
			ql_LichSuHoatDong.ShowDialog();
		}
		private void quayVeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void MainQL_KeyUp(object sender, KeyEventArgs e)
		{
			bool control = e.Control;
			if (control)
			{
				bool flag = e.KeyCode.Equals(Keys.P);
				if (flag)
				{
					this.XacNhanPNToolStripMenuItem_Click(null, null);
				}
				bool flag2 = e.KeyCode.Equals(Keys.B);
				if (flag2)
				{
					this.baocaoToolStripMenuItem_Click(null, null);
				}
				bool flag3 = e.KeyCode.Equals(Keys.N);
				if (flag3)
				{
					this.QLNXBToolStripMenuItem_Click(null, null);
				}
				bool flag4 = e.KeyCode.Equals(Keys.D);
				if (flag4)
				{
					this.DanhMucSachToolStripMenuItem_Click(null, null);
				}
				bool flag5 = e.KeyCode.Equals(Keys.V);
				if (flag5)
				{
					this.QLNhanVienToolStripMenuItem_Click(null, null);
				}
				bool flag6 = e.KeyCode.Equals(Keys.L);
				if (flag6)
				{
					this.LichSuHDToolStripMenuItem_Click(null, null);
				}
				bool flag7 = e.KeyCode.Equals(Keys.Q);
				if (flag7)
				{
					this.quayVeToolStripMenuItem_Click(null, null);
				}
				bool flag8 = e.KeyCode.Equals(Keys.LWin);
				if (flag8)
				{
					base.Close();
				}
			}
		}
		private void MainQL_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Hide();
			MainNV mainNV = new MainNV();
			mainNV.ShowDialog();
			base.Close();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainQL));
			this.mnsQL = new MenuStrip();
			this.tsmXacNhanPN = new ToolStripMenuItem();
			this.tsmThongKe = new ToolStripMenuItem();
			this.tsmDMS = new ToolStripMenuItem();
			this.tsmQlNXB = new ToolStripMenuItem();
			this.tsmQLNV = new ToolStripMenuItem();
			this.tsmLichSuHD = new ToolStripMenuItem();
			this.tsmQuayVe = new ToolStripMenuItem();
			this.panel1 = new Panel();
			this.vbButton1 = new VBButton();
			this.mnsQL.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.mnsQL.BackColor = Color.LavenderBlush;
			this.mnsQL.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.mnsQL.Items.AddRange(new ToolStripItem[]
			{
				this.tsmXacNhanPN,
				this.tsmThongKe,
				this.tsmDMS,
				this.tsmQlNXB,
				this.tsmQLNV,
				this.tsmLichSuHD,
				this.tsmQuayVe
			});
			this.mnsQL.Location = new Point(0, 0);
			this.mnsQL.Name = "mnsQL";
			this.mnsQL.Padding = new Padding(12, 4, 0, 4);
			this.mnsQL.Size = new Size(1374, 39);
			this.mnsQL.TabIndex = 0;
			this.mnsQL.Text = "menuStrip1";
			this.tsmXacNhanPN.BackColor = Color.LavenderBlush;
			this.tsmXacNhanPN.BackgroundImageLayout = ImageLayout.None;
			this.tsmXacNhanPN.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmXacNhanPN.Image = Resources.checkform_85890;
			this.tsmXacNhanPN.Name = "tsmXacNhanPN";
			this.tsmXacNhanPN.ShortcutKeys = (Keys)131137;
			this.tsmXacNhanPN.Size = new Size(337, 31);
			this.tsmXacNhanPN.Text = "Xem và Xác Nhận &Phiếu Nhập";
			this.tsmXacNhanPN.Click += new EventHandler(this.XacNhanPNToolStripMenuItem_Click);
			this.tsmThongKe.BackColor = Color.LavenderBlush;
			this.tsmThongKe.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmThongKe.Image = Resources.form_85828;
			this.tsmThongKe.Name = "tsmThongKe";
			this.tsmThongKe.ShortcutKeys = (Keys)131155;
			this.tsmThongKe.Size = new Size(124, 31);
			this.tsmThongKe.Text = "&Báo Cáo";
			this.tsmThongKe.Click += new EventHandler(this.baocaoToolStripMenuItem_Click);
			this.tsmDMS.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmDMS.Image = Resources.book_open_shape_icon_icons_com_70792__1_;
			this.tsmDMS.Name = "tsmDMS";
			this.tsmDMS.ShortcutKeys = (Keys)131140;
			this.tsmDMS.Size = new Size(231, 31);
			this.tsmDMS.Text = "QL &Danh Mục Sách";
			this.tsmDMS.Click += new EventHandler(this.DanhMucSachToolStripMenuItem_Click);
			this.tsmQlNXB.BackColor = Color.LavenderBlush;
			this.tsmQlNXB.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmQlNXB.Image = Resources.msn_user_avatar_person_people_icon_124220;
			this.tsmQlNXB.Name = "tsmQlNXB";
			this.tsmQlNXB.ShortcutKeys = (Keys)131162;
			this.tsmQlNXB.Size = new Size(215, 31);
			this.tsmQlNXB.Text = "QL &Nhà Xuất Bản";
			this.tsmQlNXB.Click += new EventHandler(this.QLNXBToolStripMenuItem_Click);
			this.tsmQLNV.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmQLNV.Image = Resources.humman;
			this.tsmQLNV.Name = "tsmQLNV";
			this.tsmQLNV.ShortcutKeys = (Keys)131160;
			this.tsmQLNV.Size = new Size(179, 31);
			this.tsmQLNV.Text = "QL Nhân &Viên";
			this.tsmQLNV.Click += new EventHandler(this.QLNhanVienToolStripMenuItem_Click);
			this.tsmLichSuHD.BackColor = Color.LavenderBlush;
			this.tsmLichSuHD.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmLichSuHD.Image = Resources.clock_hour_minute_second_time_timer_watch_icon_123193;
			this.tsmLichSuHD.Name = "tsmLichSuHD";
			this.tsmLichSuHD.ShortcutKeys = (Keys)131139;
			this.tsmLichSuHD.Size = new Size(152, 31);
			this.tsmLichSuHD.Text = "&Lịch sử HD";
			this.tsmLichSuHD.Click += new EventHandler(this.LichSuHDToolStripMenuItem_Click);
			this.tsmQuayVe.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tsmQuayVe.Image = Resources.ic_back_97586;
			this.tsmQuayVe.ImageAlign = ContentAlignment.MiddleLeft;
			this.tsmQuayVe.Name = "tsmQuayVe";
			this.tsmQuayVe.Size = new Size(121, 31);
			this.tsmQuayVe.Text = "&Quay về";
			this.tsmQuayVe.Click += new EventHandler(this.quayVeToolStripMenuItem_Click);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BackgroundImage = Resources._86348578_2543488405780768_8176631147531337728_n1;
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.vbButton1);
			this.panel1.Location = new Point(0, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1374, 717);
			this.panel1.TabIndex = 3;
			this.vbButton1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.vbButton1.BackColor = Color.Transparent;
			this.vbButton1.BackgroundColor = Color.Transparent;
			this.vbButton1.BorderColor = Color.Pink;
			this.vbButton1.BorderRadius = 5;
			this.vbButton1.BorderSize = 1;
			this.vbButton1.FlatAppearance.BorderSize = 0;
			this.vbButton1.FlatStyle = FlatStyle.Flat;
			this.vbButton1.Font = new Font("Sitka Display", 26.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.vbButton1.ForeColor = Color.Red;
			this.vbButton1.Location = new Point(334, 653);
			this.vbButton1.Name = "vbButton1";
			this.vbButton1.Size = new Size(767, 57);
			this.vbButton1.TabIndex = 5;
			this.vbButton1.TabStop = false;
			this.vbButton1.Text = "CHÀO MỪNG BẠN ĐẾN TRANG QUẢN LÝ";
			this.vbButton1.TextColor = Color.Red;
			this.vbButton1.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackgroundImageLayout = ImageLayout.None;
			base.ClientSize = new Size(1374, 754);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.mnsQL);
			base.FormBorderStyle = FormBorderStyle.Fixed3D;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "MainQL";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ";
			base.FormClosed += new FormClosedEventHandler(this.MainQL_FormClosed);
			base.Load += new EventHandler(this.MainQL_Load);
			base.KeyUp += new KeyEventHandler(this.MainQL_KeyUp);
			this.mnsQL.ResumeLayout(false);
			this.mnsQL.PerformLayout();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
