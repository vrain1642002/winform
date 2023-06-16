using bansach.Properties;
using CustomButton;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class Login : Form
	{
		private CXuLyNV xulyNV;
		private CXuLyNXB xulyNXB;
		private CXuLyLichSuHD xuLyLichSuHD;
		private IContainer components = null;
		private TextBox txtDangNhap;
		private TextBox txtMatKhau;
		private Label label2;
		private Label label3;
		private Panel panel1;
		private CheckBox chkhien;
		private PictureBox pictureBox2;
		private PictureBox pictureBox1;
		private Panel panel2;
		private Panel panel3;
		private VBButton btnDangNhap;
		private VBButton btnThoat;
		public Login()
		{
			this.InitializeComponent();
		}
		private void Login_Load(object sender, EventArgs e)
		{
			this.xulyNV = new CXuLyNV();
			bool flag = !this.xulyNV.docFile("DSNhanVien.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhanVien.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.xulyNXB = new CXuLyNXB();
			bool flag2 = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu fie DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag3 = !this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag3)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
		}
		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			bool flag = this.txtDangNhap.Text == "ADMIN" && this.txtMatKhau.Text == "ADMIN" && this.xulyNV.getDSNV().Count == 0;
			if (flag)
			{
				MessageBox.Show("Bạn đăng nhập vào tài khoản admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Ql_NhanVien ql_NhanVien = new Ql_NhanVien();
				ql_NhanVien.ShowDialog();
				this.txtDangNhap.Text = "";
				this.txtMatKhau.Text = "";
			}
			else
			{
				bool flag2 = this.txtDangNhap.Text == "" || this.txtMatKhau.Text == "";
				if (flag2)
				{
					MessageBox.Show("Bạn chưa nhập đủ tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					bool flag3 = this.txtDangNhap.Text == "";
					if (flag3)
					{
						this.txtDangNhap.Focus();
					}
					else
					{
						this.txtMatKhau.Focus();
					}
				}
				else
				{
					CNhanVien cNhanVien = new CNhanVien();
					cNhanVien = this.xulyNV.tim(this.txtDangNhap.Text);
					bool flag4 = cNhanVien != null && cNhanVien.MatKhauNV == this.txtMatKhau.Text;
					if (flag4)
					{
						CLichSuHD cLichSuHD = new CLichSuHD();
						cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
						cLichSuHD.NHoatDong = DateTime.Now;
						cLichSuHD.IDND = cNhanVien.IDNV;
						cLichSuHD.TenND = cNhanVien.TenNV;
						cLichSuHD.HoatDong = "Đăng nhập ";
						cLichSuHD.IDDoiTuong = "";
						cLichSuHD.DoiTuong = "";
						cLichSuHD.NoiDung = "Đăng nhập hệ thống ";
						this.xuLyLichSuHD.them(cLichSuHD);
						this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
						CConst.Nhanvien = cNhanVien;
						MainNV mainNV = new MainNV();
						this.txtDangNhap.Text = "";
						this.txtMatKhau.Text = "";
						mainNV.ShowDialog();
					}
					else
					{
						CNhaXuatBan cNhaXuatBan = new CNhaXuatBan();
						cNhaXuatBan = this.xulyNXB.tim(this.txtDangNhap.Text);
						bool flag5 = cNhaXuatBan != null && cNhaXuatBan.MatKhauNXB == this.txtMatKhau.Text;
						if (flag5)
						{
							CConst.NhaXuatBan = cNhaXuatBan;
							MainNXB mainNXB = new MainNXB();
							this.txtDangNhap.Text = "";
							this.txtMatKhau.Text = "";
							mainNXB.ShowDialog();
						}
						else
						{
							MessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu,vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.txtDangNhap.Text = "";
							this.txtMatKhau.Text = "";
						}
					}
				}
			}
		}
		private void btnthoat_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = MessageBox.Show("Bạn muốn thoát chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
			if (flag)
			{
				e.Cancel = true;
			}
			else
			{
				bool flag2 = CConst.Nhanvien != null;
				if (flag2)
				{
					CLichSuHD cLichSuHD = new CLichSuHD();
					cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
					cLichSuHD.NHoatDong = DateTime.Now;
					cLichSuHD.IDND = CConst.Nhanvien.IDNV;
					cLichSuHD.TenND = CConst.Nhanvien.TenNV;
					cLichSuHD.HoatDong = "Đăng xuất ";
					cLichSuHD.IDDoiTuong = "";
					cLichSuHD.DoiTuong = "";
					cLichSuHD.NoiDung = "Đăng xuất khỏi hệ thống ";
					foreach (CLichSuHD current in this.xuLyLichSuHD.getDSLSHD())
					{
						bool flag3 = current.NoiDung == cLichSuHD.NoiDung && current.NHoatDong.Year == cLichSuHD.NHoatDong.Year && current.NHoatDong.Month == cLichSuHD.NHoatDong.Month && current.NHoatDong.Day == cLichSuHD.NHoatDong.Day && current.NHoatDong.Hour == cLichSuHD.NHoatDong.Hour && current.NHoatDong.Minute == cLichSuHD.NHoatDong.Minute;
						if (flag3)
						{
							return;
						}
					}
					this.xuLyLichSuHD.them(cLichSuHD);
					this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
				}
			}
		}
		private void Login_KeyUp(object sender, KeyEventArgs e)
		{
			bool control = e.Control;
			if (control)
			{
				bool flag = e.KeyCode.Equals(Keys.LWin);
				if (flag)
				{
					base.Close();
				}
			}
			bool flag2 = e.KeyCode.Equals(Keys.Return);
			if (flag2)
			{
				this.btnDangNhap_Click(sender, e);
			}
		}
		private void chkhien_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkhien.Checked;
			if (@checked)
			{
				this.txtMatKhau.UseSystemPasswordChar = false;
			}
			else
			{
				this.txtMatKhau.UseSystemPasswordChar = true;
			}
		}
		private void btnThoat_Click_1(object sender, EventArgs e)
		{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Login));
			this.panel1 = new Panel();
			this.btnThoat = new VBButton();
			this.btnDangNhap = new VBButton();
			this.panel3 = new Panel();
			this.pictureBox2 = new PictureBox();
			this.label3 = new Label();
			this.txtMatKhau = new TextBox();
			this.panel2 = new Panel();
			this.pictureBox1 = new PictureBox();
			this.label2 = new Label();
			this.txtDangNhap = new TextBox();
			this.chkhien = new CheckBox();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = Resources.Screenshot_2022_12_09_0733142;
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnThoat);
			this.panel1.Controls.Add(this.btnDangNhap);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.chkhien);
			this.panel1.Location = new Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(514, 349);
			this.panel1.TabIndex = 6;
			this.btnThoat.BackColor = Color.LightGray;
			this.btnThoat.BackgroundColor = Color.LightGray;
			this.btnThoat.BorderColor = Color.LightGray;
			this.btnThoat.BorderRadius = 8;
			this.btnThoat.BorderSize = 0;
			this.btnThoat.FlatAppearance.BorderSize = 0;
			this.btnThoat.FlatStyle = FlatStyle.Flat;
			this.btnThoat.Font = new Font("Times New Roman", 18.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnThoat.ForeColor = Color.Black;
			this.btnThoat.Location = new Point(300, 277);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new Size(150, 40);
			this.btnThoat.TabIndex = 6;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.TextColor = Color.Black;
			this.btnThoat.UseVisualStyleBackColor = false;
			this.btnThoat.Click += new EventHandler(this.btnThoat_Click_1);
			this.btnDangNhap.BackColor = SystemColors.Highlight;
			this.btnDangNhap.BackgroundColor = SystemColors.Highlight;
			this.btnDangNhap.BorderColor = Color.DeepSkyBlue;
			this.btnDangNhap.BorderRadius = 5;
			this.btnDangNhap.BorderSize = 0;
			this.btnDangNhap.FlatAppearance.BorderSize = 0;
			this.btnDangNhap.FlatStyle = FlatStyle.Flat;
			this.btnDangNhap.Font = new Font("Times New Roman", 18.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDangNhap.ForeColor = SystemColors.ButtonHighlight;
			this.btnDangNhap.Location = new Point(93, 277);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new Size(150, 40);
			this.btnDangNhap.TabIndex = 5;
			this.btnDangNhap.Text = "Đăng nhập";
			this.btnDangNhap.TextColor = SystemColors.ButtonHighlight;
			this.btnDangNhap.UseVisualStyleBackColor = false;
			this.btnDangNhap.Click += new EventHandler(this.btnDangNhap_Click);
			this.panel3.BackColor = SystemColors.Window;
			this.panel3.Controls.Add(this.pictureBox2);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.txtMatKhau);
			this.panel3.Location = new Point(93, 175);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(354, 36);
			this.panel3.TabIndex = 2;
			this.pictureBox2.Image = Resources.secure_safety_password_protection_security_lock_padlock_icon_219355__1_;
			this.pictureBox2.Location = new Point(6, 8);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(25, 25);
			this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.ImageAlign = ContentAlignment.MiddleLeft;
			this.label3.Location = new Point(29, 9);
			this.label3.Name = "label3";
			this.label3.Size = new Size(110, 27);
			this.label3.TabIndex = 5;
			this.label3.Text = "Mật khẩu:";
			this.txtMatKhau.Font = new Font("Times New Roman", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMatKhau.Location = new Point(139, 2);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new Size(212, 32);
			this.txtMatKhau.TabIndex = 2;
			this.txtMatKhau.UseSystemPasswordChar = true;
			this.panel2.BackColor = SystemColors.Window;
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.txtDangNhap);
			this.panel2.Location = new Point(93, 84);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(357, 36);
			this.panel2.TabIndex = 0;
			this.pictureBox1.Image = Resources._3289576_individual_man_people_person_107097__1_1;
			this.pictureBox1.Location = new Point(6, 9);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(25, 25);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.ImageAlign = ContentAlignment.MiddleLeft;
			this.label2.Location = new Point(29, 9);
			this.label2.Name = "label2";
			this.label2.Size = new Size(43, 27);
			this.label2.TabIndex = 4;
			this.label2.Text = "ID:";
			this.txtDangNhap.Font = new Font("Times New Roman", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDangNhap.Location = new Point(139, 2);
			this.txtDangNhap.MaxLength = 10;
			this.txtDangNhap.Name = "txtDangNhap";
			this.txtDangNhap.Size = new Size(215, 32);
			this.txtDangNhap.TabIndex = 1;
			this.chkhien.AutoSize = true;
			this.chkhien.BackColor = Color.Transparent;
			this.chkhien.Font = new Font("Times New Roman", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkhien.Location = new Point(232, 226);
			this.chkhien.Name = "chkhien";
			this.chkhien.Size = new Size(113, 21);
			this.chkhien.TabIndex = 3;
			this.chkhien.Text = "Hiện mật khẩu";
			this.chkhien.UseVisualStyleBackColor = false;
			this.chkhien.CheckedChanged += new EventHandler(this.chkhien_CheckedChanged);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(519, 353);
			base.Controls.Add(this.panel1);
			this.Cursor = Cursors.Arrow;
			this.DoubleBuffered = true;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Login";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ĐĂNG NHẬP";
			base.FormClosing += new FormClosingEventHandler(this.Login_FormClosing);
			base.Load += new EventHandler(this.Login_Load);
			base.KeyUp += new KeyEventHandler(this.Login_KeyUp);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((ISupportInitialize)this.pictureBox2).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
