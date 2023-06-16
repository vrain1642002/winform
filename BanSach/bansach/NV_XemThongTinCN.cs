using bansach.Properties;
using CustomButton;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class NV_XemThongTinCN : Form
	{
		private CXuLyNV xulyNV;
		private IContainer components = null;
		private GroupBox groupBox4;
		private TextBox txtMKNL;
		private Label label18;
		private Label label21;
		private TextBox txtMKHT;
		private Label label19;
		private TextBox txtMKM;
		private GroupBox groupBox2;
		private Label label1;
		private TextBox txtTENNV;
		private Label label15;
		private TextBox txtDiaChiNV;
		private TextBox txtLNV;
		private Label label16;
		private TextBox txtIDNV;
		private Label label17;
		private TextBox txtNS;
		private Label label4;
		private TextBox txtSDTNV;
		private Label label3;
		private TextBox txtL;
		private Label label2;
		private TextBox txtGT;
		private Label label5;
		private CheckBox chkHien;
		private Label label22;
		private TextBox txtSDTNVM;
		private TextBox txtDCNVM;
		private Label label20;
		private GroupBox groupBox3;
		private Panel panel1;
		private VBButton btnDoiMK;
		private VBButton btndoiTT;
		public NV_XemThongTinCN()
		{
			this.InitializeComponent();
		}
		private void XemThongTinCN_Load(object sender, EventArgs e)
		{
			this.xulyNV = new CXuLyNV();
			bool flag = !this.xulyNV.docFile("DSNhanVien.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhanVien.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.txtIDNV.Text = CConst.Nhanvien.IDNV;
			this.txtLNV.Text = CConst.Nhanvien.LoaiNV;
			this.txtTENNV.Text = CConst.Nhanvien.TenNV;
			this.txtL.Text = CConst.Nhanvien.LuongCoBanNV.ToString();
			this.txtGT.Text = CConst.Nhanvien.GioitinhNV;
			this.txtNS.Text = CConst.Nhanvien.NgaysinhNV.ToShortDateString();
			this.txtSDTNV.Text = CConst.Nhanvien.SDTNV;
			this.txtDiaChiNV.Text = CConst.Nhanvien.DiaChiNV;
			base.KeyPreview = true;
		}
		private void btndoiTT_Click(object sender, EventArgs e)
		{
			bool flag = this.txtDCNVM.Text == "" && this.txtSDTNVM.Text == "";
			if (flag)
			{
				MessageBox.Show("Bạn chưa điền dữ liệu thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtSDTNVM.Text != "" && this.txtDCNVM.Text == "";
				if (flag2)
				{
					bool flag3 = this.txtSDTNVM.Text.ToString().Length < 10;
					if (flag3)
					{
						MessageBox.Show("Số điện thoại sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					this.xulyNV.tim(this.txtIDNV.Text).SDTNV = this.txtSDTNVM.Text;
					this.xulyNV.ghiFile("DSNhanVien.dat");
					this.txtSDTNV.Text = this.xulyNV.tim(this.txtIDNV.Text).SDTNV;
					CConst.Nhanvien = this.xulyNV.tim(this.txtIDNV.Text);
					this.txtSDTNVM.Text = "";
				}
				bool flag4 = this.txtDCNVM.Text != "" && this.txtSDTNV.Text == "";
				if (flag4)
				{
					this.xulyNV.tim(this.txtIDNV.Text).DiaChiNV = this.txtDCNVM.Text;
					this.xulyNV.ghiFile("DSNhanVien.dat");
					CConst.Nhanvien = this.xulyNV.tim(this.txtIDNV.Text);
					this.txtDCNVM.Text = "";
				}
				bool flag5 = this.txtDCNVM.Text != "" && this.txtSDTNV.Text != "";
				if (flag5)
				{
					bool flag6 = this.txtSDTNVM.Text.ToString().Length < 10;
					if (flag6)
					{
						MessageBox.Show("Số điện thoại sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						this.xulyNV.tim(this.txtIDNV.Text).SDTNV = this.txtSDTNVM.Text;
						this.xulyNV.tim(this.txtIDNV.Text).DiaChiNV = this.txtDCNVM.Text;
						this.xulyNV.ghiFile("DSNhanVien.dat");
						CConst.Nhanvien = this.xulyNV.tim(this.txtIDNV.Text);
						this.txtSDTNV.Text = this.xulyNV.tim(this.txtIDNV.Text).SDTNV;
						this.txtDiaChiNV.Text = this.xulyNV.tim(this.txtIDNV.Text).DiaChiNV;
						this.txtSDTNVM.Text = "";
						this.txtDCNVM.Text = "";
					}
				}
			}
		}
		private void txtSDTNVM_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void btnDoiMK_Click(object sender, EventArgs e)
		{
			bool flag = this.txtMKHT.Text == "" || this.txtMKM.Text == "" || this.txtMKNL.Text == "";
			if (flag)
			{
				MessageBox.Show("Bạn chưa điền đủ dữ liệu thay đổi  mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtMKHT.Text != CConst.Nhanvien.MatKhauNV;
				if (flag2)
				{
					MessageBox.Show("Bạn đã nhập sai mật khẩu hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					bool flag3 = this.txtMKM.Text == CConst.Nhanvien.MatKhauNV;
					if (flag3)
					{
						MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.txtMKM.Text = "";
					}
					else
					{
						bool flag4 = this.txtMKM.Text.Length < 10 || !this.xulyNV.coSo(this.txtMKM.Text) || !this.xulyNV.cochu(this.txtMKM.Text);
						if (flag4)
						{
							MessageBox.Show("Mật khẩu mới không đủ an toàn,Mật khẩu phải vừa có số lượng kí tự>9,vừa phải bao gồm chữ và số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.txtMKM.Text = "";
						}
						else
						{
							bool flag5 = this.txtMKNL.Text != this.txtMKM.Text;
							if (flag5)
							{
								MessageBox.Show("Mật khẩu nhắc lại không trùng với mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								this.txtMKNL.Text = "";
							}
							else
							{
								MessageBox.Show("Đã đổi thành công mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								this.xulyNV.tim(this.txtIDNV.Text).MatKhauNV = this.txtMKM.Text;
								this.xulyNV.ghiFile("DSNhanVien.dat");
								CConst.Nhanvien = this.xulyNV.tim(this.txtIDNV.Text);
							}
						}
					}
				}
			}
		}
		private void chkHien_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.chkHien.Checked;
			if (flag)
			{
				this.txtMKHT.UseSystemPasswordChar = true;
				this.txtMKM.UseSystemPasswordChar = true;
				this.txtMKNL.UseSystemPasswordChar = true;
			}
			else
			{
				this.txtMKHT.UseSystemPasswordChar = false;
				this.txtMKM.UseSystemPasswordChar = false;
				this.txtMKNL.UseSystemPasswordChar = false;
			}
		}
		private void XemThongTinCN_KeyUp(object sender, KeyEventArgs e)
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
		}
		private void XemThongTinCN_FormClosed_1(object sender, FormClosedEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NV_XemThongTinCN));
			this.groupBox4 = new GroupBox();
			this.btnDoiMK = new VBButton();
			this.chkHien = new CheckBox();
			this.txtMKNL = new TextBox();
			this.label18 = new Label();
			this.label21 = new Label();
			this.txtMKHT = new TextBox();
			this.label19 = new Label();
			this.txtMKM = new TextBox();
			this.groupBox2 = new GroupBox();
			this.txtGT = new TextBox();
			this.label5 = new Label();
			this.txtNS = new TextBox();
			this.label4 = new Label();
			this.txtSDTNV = new TextBox();
			this.label3 = new Label();
			this.txtL = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			this.txtTENNV = new TextBox();
			this.label15 = new Label();
			this.txtDiaChiNV = new TextBox();
			this.txtLNV = new TextBox();
			this.label16 = new Label();
			this.txtIDNV = new TextBox();
			this.label17 = new Label();
			this.label22 = new Label();
			this.txtSDTNVM = new TextBox();
			this.txtDCNVM = new TextBox();
			this.label20 = new Label();
			this.groupBox3 = new GroupBox();
			this.btndoiTT = new VBButton();
			this.panel1 = new Panel();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox4.BackColor = Color.LightSkyBlue;
			this.groupBox4.Controls.Add(this.btnDoiMK);
			this.groupBox4.Controls.Add(this.chkHien);
			this.groupBox4.Controls.Add(this.txtMKNL);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label21);
			this.groupBox4.Controls.Add(this.txtMKHT);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.txtMKM);
			this.groupBox4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox4.Location = new Point(81, 687);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(591, 188);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Đổi mật khẩu";
			this.btnDoiMK.BackColor = Color.DeepSkyBlue;
			this.btnDoiMK.BackgroundColor = Color.DeepSkyBlue;
			this.btnDoiMK.BorderColor = Color.PaleVioletRed;
			this.btnDoiMK.BorderRadius = 5;
			this.btnDoiMK.BorderSize = 0;
			this.btnDoiMK.FlatAppearance.BorderSize = 0;
			this.btnDoiMK.FlatStyle = FlatStyle.Flat;
			this.btnDoiMK.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDoiMK.ForeColor = Color.Black;
			this.btnDoiMK.Image = Resources.circle_edit_outline_icon_1397991;
			this.btnDoiMK.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnDoiMK.Location = new Point(468, 64);
			this.btnDoiMK.Name = "btnDoiMK";
			this.btnDoiMK.Size = new Size(105, 60);
			this.btnDoiMK.TabIndex = 8;
			this.btnDoiMK.Text = "  Đổi";
			this.btnDoiMK.TextColor = Color.Black;
			this.btnDoiMK.UseVisualStyleBackColor = false;
			this.btnDoiMK.Click += new EventHandler(this.btnDoiMK_Click);
			this.chkHien.AutoSize = true;
			this.chkHien.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkHien.Location = new Point(126, 3);
			this.chkHien.Name = "chkHien";
			this.chkHien.Size = new Size(15, 14);
			this.chkHien.TabIndex = 4;
			this.chkHien.UseVisualStyleBackColor = true;
			this.chkHien.CheckedChanged += new EventHandler(this.chkHien_CheckedChanged);
			this.txtMKNL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMKNL.Location = new Point(207, 131);
			this.txtMKNL.Name = "txtMKNL";
			this.txtMKNL.Size = new Size(243, 29);
			this.txtMKNL.TabIndex = 7;
			this.txtMKNL.UseSystemPasswordChar = true;
			this.label18.AutoSize = true;
			this.label18.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label18.ForeColor = Color.Black;
			this.label18.Location = new Point(12, 86);
			this.label18.Name = "label18";
			this.label18.Size = new Size(112, 21);
			this.label18.TabIndex = 180;
			this.label18.Text = "Mật khẩu mới";
			this.label21.AutoSize = true;
			this.label21.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label21.ForeColor = Color.Black;
			this.label21.Location = new Point(11, 139);
			this.label21.Name = "label21";
			this.label21.Size = new Size(143, 21);
			this.label21.TabIndex = 175;
			this.label21.Text = "Nhập lại mât khẩu";
			this.txtMKHT.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMKHT.Location = new Point(207, 20);
			this.txtMKHT.Name = "txtMKHT";
			this.txtMKHT.Size = new Size(243, 29);
			this.txtMKHT.TabIndex = 5;
			this.txtMKHT.UseSystemPasswordChar = true;
			this.label19.AutoSize = true;
			this.label19.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label19.ForeColor = Color.Black;
			this.label19.Location = new Point(9, 28);
			this.label19.Name = "label19";
			this.label19.Size = new Size(136, 21);
			this.label19.TabIndex = 173;
			this.label19.Text = "Mật khẩu hiện tại";
			this.txtMKM.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMKM.Location = new Point(207, 78);
			this.txtMKM.Name = "txtMKM";
			this.txtMKM.Size = new Size(243, 29);
			this.txtMKM.TabIndex = 6;
			this.txtMKM.UseSystemPasswordChar = true;
			this.groupBox2.BackColor = SystemColors.ActiveCaption;
			this.groupBox2.Controls.Add(this.txtGT);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtNS);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtSDTNV);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtL);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txtTENNV);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.txtDiaChiNV);
			this.groupBox2.Controls.Add(this.txtLNV);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.txtIDNV);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.Location = new Point(81, 28);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(583, 427);
			this.groupBox2.TabIndex = 187;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin";
			this.txtGT.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGT.Location = new Point(215, 237);
			this.txtGT.Name = "txtGT";
			this.txtGT.ReadOnly = true;
			this.txtGT.Size = new Size(243, 29);
			this.txtGT.TabIndex = 170;
			this.txtGT.TabStop = false;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.ForeColor = Color.Black;
			this.label5.Location = new Point(7, 245);
			this.label5.Name = "label5";
			this.label5.Size = new Size(76, 21);
			this.label5.TabIndex = 169;
			this.label5.Text = "Giới tính";
			this.txtNS.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNS.Location = new Point(215, 283);
			this.txtNS.Name = "txtNS";
			this.txtNS.ReadOnly = true;
			this.txtNS.Size = new Size(243, 29);
			this.txtNS.TabIndex = 168;
			this.txtNS.TabStop = false;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Black;
			this.label4.Location = new Point(7, 193);
			this.label4.Name = "label4";
			this.label4.Size = new Size(115, 21);
			this.label4.TabIndex = 167;
			this.label4.Text = "Lương cơ bản";
			this.txtSDTNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNV.Location = new Point(215, 333);
			this.txtSDTNV.Name = "txtSDTNV";
			this.txtSDTNV.ReadOnly = true;
			this.txtSDTNV.Size = new Size(243, 29);
			this.txtSDTNV.TabIndex = 166;
			this.txtSDTNV.TabStop = false;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Black;
			this.label3.Location = new Point(7, 291);
			this.label3.Name = "label3";
			this.label3.Size = new Size(84, 21);
			this.label3.TabIndex = 165;
			this.label3.Text = "Ngày sinh";
			this.txtL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtL.Location = new Point(215, 185);
			this.txtL.Name = "txtL";
			this.txtL.ReadOnly = true;
			this.txtL.Size = new Size(243, 29);
			this.txtL.TabIndex = 164;
			this.txtL.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.ForeColor = Color.Black;
			this.label2.Location = new Point(7, 143);
			this.label2.Name = "label2";
			this.label2.Size = new Size(118, 21);
			this.label2.TabIndex = 163;
			this.label2.Text = "Loại nhân viên";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.ForeColor = Color.Black;
			this.label1.Location = new Point(7, 341);
			this.label1.Name = "label1";
			this.label1.Size = new Size(121, 21);
			this.label1.TabIndex = 162;
			this.label1.Text = "SDT nhân viên";
			this.txtTENNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTENNV.Location = new Point(216, 84);
			this.txtTENNV.Name = "txtTENNV";
			this.txtTENNV.ReadOnly = true;
			this.txtTENNV.Size = new Size(243, 29);
			this.txtTENNV.TabIndex = 161;
			this.txtTENNV.TabStop = false;
			this.label15.AutoSize = true;
			this.label15.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label15.ForeColor = Color.Black;
			this.label15.Location = new Point(7, 92);
			this.label15.Name = "label15";
			this.label15.Size = new Size(114, 21);
			this.label15.TabIndex = 160;
			this.label15.Text = "Tên nhân viên";
			this.txtDiaChiNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDiaChiNV.Location = new Point(216, 378);
			this.txtDiaChiNV.Name = "txtDiaChiNV";
			this.txtDiaChiNV.ReadOnly = true;
			this.txtDiaChiNV.Size = new Size(243, 29);
			this.txtDiaChiNV.TabIndex = 159;
			this.txtDiaChiNV.TabStop = false;
			this.txtDiaChiNV.WordWrap = false;
			this.txtLNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtLNV.Location = new Point(216, 135);
			this.txtLNV.Name = "txtLNV";
			this.txtLNV.ReadOnly = true;
			this.txtLNV.Size = new Size(243, 29);
			this.txtLNV.TabIndex = 158;
			this.txtLNV.TabStop = false;
			this.label16.AutoSize = true;
			this.label16.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label16.ForeColor = Color.Black;
			this.label16.Location = new Point(7, 386);
			this.label16.Name = "label16";
			this.label16.Size = new Size(140, 21);
			this.label16.TabIndex = 157;
			this.label16.Text = "Địa chỉ nhân viên";
			this.txtIDNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNV.Location = new Point(215, 31);
			this.txtIDNV.Name = "txtIDNV";
			this.txtIDNV.ReadOnly = true;
			this.txtIDNV.Size = new Size(243, 29);
			this.txtIDNV.TabIndex = 1;
			this.txtIDNV.TabStop = false;
			this.label17.AutoSize = true;
			this.label17.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label17.ForeColor = Color.Black;
			this.label17.Location = new Point(7, 39);
			this.label17.Name = "label17";
			this.label17.Size = new Size(104, 21);
			this.label17.TabIndex = 155;
			this.label17.Text = "ID nhân viên";
			this.label22.AutoSize = true;
			this.label22.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label22.ForeColor = Color.Black;
			this.label22.Location = new Point(12, 78);
			this.label22.Name = "label22";
			this.label22.Size = new Size(140, 21);
			this.label22.TabIndex = 167;
			this.label22.Text = "Địa chỉ nhân viên";
			this.txtSDTNVM.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNVM.Location = new Point(210, 23);
			this.txtSDTNVM.MaxLength = 10;
			this.txtSDTNVM.Name = "txtSDTNVM";
			this.txtSDTNVM.Size = new Size(243, 29);
			this.txtSDTNVM.TabIndex = 1;
			this.txtSDTNVM.KeyPress += new KeyPressEventHandler(this.txtSDTNVM_KeyPress);
			this.txtDCNVM.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDCNVM.Location = new Point(210, 70);
			this.txtDCNVM.Name = "txtDCNVM";
			this.txtDCNVM.Size = new Size(243, 29);
			this.txtDCNVM.TabIndex = 2;
			this.txtDCNVM.WordWrap = false;
			this.label20.AutoSize = true;
			this.label20.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label20.ForeColor = Color.Black;
			this.label20.Location = new Point(12, 31);
			this.label20.Name = "label20";
			this.label20.Size = new Size(121, 21);
			this.label20.TabIndex = 172;
			this.label20.Text = "SDT nhân viên";
			this.groupBox3.BackColor = Color.LightSkyBlue;
			this.groupBox3.Controls.Add(this.btndoiTT);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.txtDCNVM);
			this.groupBox3.Controls.Add(this.txtSDTNVM);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox3.Location = new Point(81, 506);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(591, 119);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Đổi thông tin";
			this.btndoiTT.BackColor = Color.DeepSkyBlue;
			this.btndoiTT.BackgroundColor = Color.DeepSkyBlue;
			this.btndoiTT.BorderColor = Color.PaleVioletRed;
			this.btndoiTT.BorderRadius = 5;
			this.btndoiTT.BorderSize = 0;
			this.btndoiTT.FlatAppearance.BorderSize = 0;
			this.btndoiTT.FlatStyle = FlatStyle.Flat;
			this.btndoiTT.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btndoiTT.ForeColor = Color.Black;
			this.btndoiTT.Image = Resources.circle_edit_outline_icon_1397991;
			this.btndoiTT.ImageAlign = ContentAlignment.MiddleLeft;
			this.btndoiTT.Location = new Point(468, 39);
			this.btndoiTT.Name = "btndoiTT";
			this.btndoiTT.Size = new Size(105, 60);
			this.btndoiTT.TabIndex = 3;
			this.btndoiTT.Text = "  Đổi";
			this.btndoiTT.TextColor = Color.Black;
			this.btndoiTT.UseVisualStyleBackColor = false;
			this.btndoiTT.Click += new EventHandler(this.btndoiTT_Click);
			this.panel1.BackColor = Color.White;
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(759, 887);
			this.panel1.TabIndex = 192;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			base.ClientSize = new Size(762, 887);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NV_XemThongTinCN";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "XEM VÀ ĐỔI TT NV";
			base.FormClosed += new FormClosedEventHandler(this.XemThongTinCN_FormClosed_1);
			base.Load += new EventHandler(this.XemThongTinCN_Load);
			base.KeyUp += new KeyEventHandler(this.XemThongTinCN_KeyUp);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
