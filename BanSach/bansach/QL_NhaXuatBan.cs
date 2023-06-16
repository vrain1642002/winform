using bansach.Properties;
using CustomButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class QL_NhaXuatBan : Form
	{
		private CXuLyNXB xulyNXB;
		private CXuLyLichSuHD xuLyLichSuHD;
		private IContainer components = null;
		private Panel panel1;
		private DataGridView dgvNXB;
		private DataGridViewTextBoxColumn Column10;
		private DataGridViewTextBoxColumn Column11;
		private DataGridViewTextBoxColumn Column12;
		private DataGridViewTextBoxColumn Column13;
		private DataGridViewTextBoxColumn Column14;
		private CheckBox chkHienMKNXB;
		private TextBox txtDiaChiNXB;
		private TextBox txtSDTNXB;
		private TextBox txtTenNXB;
		private TextBox txtIDNXB;
		private TextBox txtMatKhauNXB;
		private Label label17;
		private Label label16;
		private Label label15;
		private Label label14;
		private Label label13;
		private Label label11;
		private VBButton btnXoa;
		private VBButton btnSua;
		private VBButton btnthem;
		private Label label1;
		private Panel panel2;
		private VBButton btnCapID;
		private Panel panel4;
		private Panel panel3;
		public QL_NhaXuatBan()
		{
			this.InitializeComponent();
		}
		private void hienthiNhaXuatBan(List<CNhaXuatBan> dsNXB)
		{
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dsNXB;
			this.dgvNXB.DataSource = bindingSource;
		}
		private void QL_NhaXuatBan_Load(object sender, EventArgs e)
		{
			this.xulyNXB = new CXuLyNXB();
			bool flag = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiNhaXuatBan(this.xulyNXB.getDSNXB());
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag2 = !this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
		}
		private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.xulyNXB.getDSNXB().Count > 0;
			if (flag)
			{
				bool flag2 = this.dgvNXB.Rows[e.RowIndex].Cells[0].Value == null;
				if (flag2)
				{
					MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this.txtIDNXB.Text = this.dgvNXB.Rows[e.RowIndex].Cells[0].Value.ToString();
					this.txtMatKhauNXB.Text = this.dgvNXB.Rows[e.RowIndex].Cells[1].Value.ToString();
					this.txtTenNXB.Text = this.dgvNXB.Rows[e.RowIndex].Cells[2].Value.ToString();
					this.txtDiaChiNXB.Text = this.dgvNXB.Rows[e.RowIndex].Cells[3].Value.ToString();
					this.txtSDTNXB.Text = this.dgvNXB.Rows[e.RowIndex].Cells[4].Value.ToString();
				}
			}
		}
		private void btnthem_Click(object sender, EventArgs e)
		{
			bool flag = this.xulyNXB.tim(this.txtIDNXB.Text) != null;
			if (flag)
			{
				MessageBox.Show("ID nhà xuất bản đã tồn tại, không thể thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtIDNXB.Text == "" || this.txtTenNXB.Text == "" || this.txtMatKhauNXB.Text == "" || this.txtSDTNXB.Text == "" || this.txtDiaChiNXB.Text == "";
				if (flag2)
				{
					MessageBox.Show("Điền thông tin nhà xuất bản chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					CNhaXuatBan cNhaXuatBan = new CNhaXuatBan();
					bool flag3 = !this.xulyNXB.ktID(this.txtIDNXB.Text);
					if (flag3)
					{
						MessageBox.Show("ID nhà xuất bản sai định dạng,ID phải gồm 10 kí tự,bắt đầu là NXB và rồi 7 kí tự còn lại là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						cNhaXuatBan.IDNXB = this.txtIDNXB.Text;
						bool flag4 = this.xulyNXB.toanSo(this.txtTenNXB.Text);
						if (flag4)
						{
							MessageBox.Show("Tên nhà xuất bản sai định dạng,tên nhà xuất bản không được toàn là kí tự sô", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							bool flag5 = this.xulyNXB.timTenNXB(this.txtTenNXB.Text) != null;
							if (flag5)
							{
								MessageBox.Show("Tên Nhà Xuất Bản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								cNhaXuatBan.TenNXB = this.txtTenNXB.Text;
								bool flag6 = this.txtMatKhauNXB.Text.Length < 10 || !this.xulyNXB.coSo(this.txtMatKhauNXB.Text) || !this.xulyNXB.cochu(this.txtMatKhauNXB.Text);
								if (flag6)
								{
									MessageBox.Show("Mật khẩu không đủ an toàn,Mật khẩu phải vừa có số lượng kí tự>9,vừa phải bao gồm chữ và số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									cNhaXuatBan.MatKhauNXB = this.txtMatKhauNXB.Text;
									bool flag7 = this.txtSDTNXB.Text.Length != 10 || !this.xulyNXB.toanSo(this.txtSDTNXB.Text);
									if (flag7)
									{
										MessageBox.Show("Số điện thoại không đúng định dạng.SDT phải là một chuỗi có 10 kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										cNhaXuatBan.SDTNXB = this.txtSDTNXB.Text;
										bool flag8 = this.xulyNXB.toanSo(this.txtDiaChiNXB.Text);
										if (flag8)
										{
											MessageBox.Show("Tên địa chỉ không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										else
										{
											cNhaXuatBan.DiaChiNXB = this.txtDiaChiNXB.Text;
											this.xulyNXB.Them(cNhaXuatBan);
											this.xulyNXB.ghiFile("DSNhaXuatBan.dat");
											this.hienthiNhaXuatBan(this.xulyNXB.getDSNXB());
											CLichSuHD cLichSuHD = new CLichSuHD();
											cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
											cLichSuHD.NHoatDong = DateTime.Now;
											cLichSuHD.IDND = CConst.Nhanvien.IDNV;
											cLichSuHD.TenND = CConst.Nhanvien.TenNV;
											cLichSuHD.HoatDong = "Thêm nhà xuất bản";
											cLichSuHD.IDDoiTuong = cNhaXuatBan.IDNXB;
											cLichSuHD.DoiTuong = "Nhà xuất bản " + cNhaXuatBan.TenNXB;
											cLichSuHD.NoiDung = "Thêm nhà xuất bản mới với ID nhà xuất bản=" + cNhaXuatBan.IDNXB;
											this.xuLyLichSuHD.them(cLichSuHD);
											this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
											this.txtIDNXB.Text = "";
											this.txtTenNXB.Text = "";
											this.txtMatKhauNXB.Text = "";
											this.txtSDTNXB.Text = "";
											this.txtDiaChiNXB.Text = "";
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			bool flag = this.xulyNXB.tim(this.txtIDNXB.Text) == null;
			if (flag)
			{
				MessageBox.Show("ID nhà xuất bản không tồn tại, không thể sửa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtIDNXB.Text == "" || this.txtTenNXB.Text == "" || this.txtMatKhauNXB.Text == "" || this.txtSDTNXB.Text == "" || this.txtDiaChiNXB.Text == "";
				if (flag2)
				{
					MessageBox.Show("Điền thông tin nhà xuất bản chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					CNhaXuatBan cNhaXuatBan = new CNhaXuatBan();
					bool flag3 = !this.xulyNXB.ktID(this.txtIDNXB.Text);
					if (flag3)
					{
						MessageBox.Show("ID nhà xuất bản sai định dạng,ID phải gồm 10 kí tự,bắt đầu là NXB và rồi 7 kí tự còn lại là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						cNhaXuatBan.IDNXB = this.txtIDNXB.Text;
						bool flag4 = this.xulyNXB.toanSo(this.txtTenNXB.Text);
						if (flag4)
						{
							MessageBox.Show("Tên nhà xuất bản sai định dạng,tên nhà xuất bản không được toàn là kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							bool flag5 = this.xulyNXB.timTenNXB(this.txtTenNXB.Text) != null && this.xulyNXB.timTenNXB(this.txtTenNXB.Text).IDNXB != this.txtIDNXB.Text;
							if (flag5)
							{
								MessageBox.Show("Tên nhà xuất bản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								MessageBox.Show("Tên nhà xuất bản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								cNhaXuatBan.TenNXB = this.txtTenNXB.Text;
								bool flag6 = this.txtMatKhauNXB.Text.Length < 10 || !this.xulyNXB.coSo(this.txtMatKhauNXB.Text) || !this.xulyNXB.cochu(this.txtMatKhauNXB.Text);
								if (flag6)
								{
									MessageBox.Show("Mật khẩu không đủ an toàn,Mật khẩu phải vừa có số lượng kí tự>9,vừa phải bao gồm chữ và số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									cNhaXuatBan.MatKhauNXB = this.txtMatKhauNXB.Text;
									bool flag7 = this.txtSDTNXB.Text.Length != 10 || !this.xulyNXB.toanSo(this.txtSDTNXB.Text);
									if (flag7)
									{
										MessageBox.Show("Số điện thoại không đúng định dạng.SDT phải là một chuỗi có 10 kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										cNhaXuatBan.SDTNXB = this.txtSDTNXB.Text;
										bool flag8 = this.xulyNXB.toanSo(this.txtDiaChiNXB.Text);
										if (flag8)
										{
											MessageBox.Show("Địa chỉ không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										else
										{
											cNhaXuatBan.DiaChiNXB = this.txtDiaChiNXB.Text;
											CLichSuHD cLichSuHD = new CLichSuHD();
											cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
											cLichSuHD.NHoatDong = DateTime.Now;
											cLichSuHD.IDND = CConst.Nhanvien.IDNV;
											cLichSuHD.TenND = CConst.Nhanvien.TenNV;
											cLichSuHD.HoatDong = "Sửa thông tin nhà xuất bản";
											cLichSuHD.IDDoiTuong = cNhaXuatBan.IDNXB;
											cLichSuHD.DoiTuong = "Nhà xuất bản " + cNhaXuatBan.TenNXB;
											cLichSuHD.NoiDung = "Sửa thông tin nhà xuất bản với ID nhà xuất bản =" + cNhaXuatBan.IDNXB + " || ";
											bool flag9 = this.xulyNXB.tim(cNhaXuatBan.IDNXB).TenNXB != cNhaXuatBan.TenNXB;
											if (flag9)
											{
												cLichSuHD.NoiDung = string.Concat(new string[]
												{
													cLichSuHD.NoiDung,
													"Sửa tên nhà xuất bản:",
													this.xulyNXB.tim(cNhaXuatBan.IDNXB).TenNXB,
													"->",
													cNhaXuatBan.TenNXB,
													" || "
												});
											}
											bool flag10 = this.xulyNXB.tim(cNhaXuatBan.IDNXB).MatKhauNXB != cNhaXuatBan.MatKhauNXB;
											if (flag10)
											{
												cLichSuHD.NoiDung = string.Concat(new string[]
												{
													cLichSuHD.NoiDung,
													"Sửa mật khẩu nhà xuất bản:",
													this.xulyNXB.tim(cNhaXuatBan.IDNXB).MatKhauNXB,
													"->",
													cNhaXuatBan.MatKhauNXB,
													" || "
												});
											}
											bool flag11 = this.xulyNXB.tim(cNhaXuatBan.IDNXB).SDTNXB != cNhaXuatBan.SDTNXB;
											if (flag11)
											{
												cLichSuHD.NoiDung = string.Concat(new string[]
												{
													cLichSuHD.NoiDung,
													"Sửa điện thoại nhà xuất bản:",
													this.xulyNXB.tim(cNhaXuatBan.IDNXB).SDTNXB,
													"->",
													cNhaXuatBan.SDTNXB,
													" || "
												});
											}
											bool flag12 = this.xulyNXB.tim(cNhaXuatBan.IDNXB).DiaChiNXB != cNhaXuatBan.DiaChiNXB;
											if (flag12)
											{
												cLichSuHD.NoiDung = string.Concat(new string[]
												{
													cLichSuHD.NoiDung,
													"Sửa địa chỉ xuất bản:",
													this.xulyNXB.tim(cNhaXuatBan.IDNXB).DiaChiNXB,
													"->",
													cNhaXuatBan.DiaChiNXB,
													" || "
												});
											}
											this.xuLyLichSuHD.them(cLichSuHD);
											this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
											this.xulyNXB.Sua(cNhaXuatBan);
											this.xulyNXB.ghiFile("DSNhaXuatBan.dat");
											this.hienthiNhaXuatBan(this.xulyNXB.getDSNXB());
											this.txtIDNXB.Text = "";
											this.txtTenNXB.Text = "";
											this.txtMatKhauNXB.Text = "";
											this.txtSDTNXB.Text = "";
											this.txtDiaChiNXB.Text = "";
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void btnXoa_Click(object sender, EventArgs e)
		{
			bool flag = this.xulyNXB.tim(this.txtIDNXB.Text) == null;
			if (flag)
			{
				MessageBox.Show("ID nhà xuất bản không tồn tại, không thể xóa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				CLichSuHD cLichSuHD = new CLichSuHD();
				cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
				cLichSuHD.NHoatDong = DateTime.Now;
				cLichSuHD.IDND = CConst.Nhanvien.IDNV;
				cLichSuHD.TenND = CConst.Nhanvien.TenNV;
				cLichSuHD.HoatDong = "Xóa nhà xuất bản";
				cLichSuHD.IDDoiTuong = this.txtIDNXB.Text;
				cLichSuHD.DoiTuong = "Nhà xuất bản " + this.xulyNXB.tim(this.txtIDNXB.Text).TenNXB;
				cLichSuHD.NoiDung = "Xóa nhà xuất bản với ID nhà xuất bản=" + this.txtIDNXB.Text;
				this.xuLyLichSuHD.them(cLichSuHD);
				this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
				this.xulyNXB.Xoa(this.txtIDNXB.Text);
				this.xulyNXB.ghiFile("DSNhaXuatBan.dat");
				this.hienthiNhaXuatBan(this.xulyNXB.getDSNXB());
				this.txtIDNXB.Text = "";
				this.txtTenNXB.Text = "";
				this.txtMatKhauNXB.Text = "";
				this.txtSDTNXB.Text = "";
				this.txtDiaChiNXB.Text = "";
			}
		}
		private void txtSDTNXB_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void chkHienMKNXB_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.chkHienMKNXB.Checked;
			if (flag)
			{
				this.txtMatKhauNXB.UseSystemPasswordChar = true;
			}
			else
			{
				this.txtMatKhauNXB.UseSystemPasswordChar = false;
			}
		}
		private void QL_NhaXuatBan_KeyUp(object sender, KeyEventArgs e)
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
		private void btnCapID_Click(object sender, EventArgs e)
		{
			this.txtIDNXB.Text = this.xulyNXB.CapIDNXB();
			this.txtTenNXB.Text = "";
			this.txtMatKhauNXB.Text = "";
			this.txtSDTNXB.Text = "";
			this.txtDiaChiNXB.Text = "";
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
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QL_NhaXuatBan));
			this.btnXoa = new VBButton();
			this.btnSua = new VBButton();
			this.btnthem = new VBButton();
			this.panel1 = new Panel();
			this.panel4 = new Panel();
			this.btnCapID = new VBButton();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.label1 = new Label();
			this.chkHienMKNXB = new CheckBox();
			this.txtDiaChiNXB = new TextBox();
			this.txtSDTNXB = new TextBox();
			this.txtTenNXB = new TextBox();
			this.txtIDNXB = new TextBox();
			this.txtMatKhauNXB = new TextBox();
			this.label17 = new Label();
			this.label16 = new Label();
			this.label15 = new Label();
			this.label14 = new Label();
			this.label13 = new Label();
			this.label11 = new Label();
			this.dgvNXB = new DataGridView();
			this.Column10 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column12 = new DataGridViewTextBoxColumn();
			this.Column13 = new DataGridViewTextBoxColumn();
			this.Column14 = new DataGridViewTextBoxColumn();
			GroupBox groupBox = new GroupBox();
			groupBox.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.dgvNXB).BeginInit();
			base.SuspendLayout();
			groupBox.BackColor = Color.Pink;
			groupBox.Controls.Add(this.btnXoa);
			groupBox.Controls.Add(this.btnSua);
			groupBox.Controls.Add(this.btnthem);
			groupBox.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox.Location = new Point(44, 686);
			groupBox.Name = "groupBox6";
			groupBox.Size = new Size(421, 116);
			groupBox.TabIndex = 7;
			groupBox.TabStop = false;
			groupBox.Text = "THAO TÁC";
			this.btnXoa.BackColor = Color.Red;
			this.btnXoa.BackgroundColor = Color.Red;
			this.btnXoa.BorderColor = Color.PaleVioletRed;
			this.btnXoa.BorderRadius = 5;
			this.btnXoa.BorderSize = 0;
			this.btnXoa.FlatAppearance.BorderSize = 0;
			this.btnXoa.FlatStyle = FlatStyle.Flat;
			this.btnXoa.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXoa.ForeColor = Color.White;
			this.btnXoa.Image = Resources.add_circle_create_expand_new_plus_icon_1232181;
			this.btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnXoa.Location = new Point(310, 39);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new Size(105, 60);
			this.btnXoa.TabIndex = 9;
			this.btnXoa.Text = "  Xóa";
			this.btnXoa.TextColor = Color.White;
			this.btnXoa.UseVisualStyleBackColor = false;
			this.btnXoa.Click += new EventHandler(this.btnXoa_Click);
			this.btnSua.BackColor = Color.DeepSkyBlue;
			this.btnSua.BackgroundColor = Color.DeepSkyBlue;
			this.btnSua.BorderColor = Color.PaleVioletRed;
			this.btnSua.BorderRadius = 5;
			this.btnSua.BorderSize = 0;
			this.btnSua.FlatAppearance.BorderSize = 0;
			this.btnSua.FlatStyle = FlatStyle.Flat;
			this.btnSua.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSua.ForeColor = Color.Black;
			this.btnSua.Image = Resources.circle_edit_outline_icon_1397992;
			this.btnSua.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnSua.Location = new Point(154, 39);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new Size(105, 60);
			this.btnSua.TabIndex = 8;
			this.btnSua.Text = "  Sửa";
			this.btnSua.TextColor = Color.Black;
			this.btnSua.UseVisualStyleBackColor = false;
			this.btnSua.Click += new EventHandler(this.btnSua_Click);
			this.btnthem.BackColor = Color.Lime;
			this.btnthem.BackgroundColor = Color.Lime;
			this.btnthem.BorderColor = Color.PaleVioletRed;
			this.btnthem.BorderRadius = 5;
			this.btnthem.BorderSize = 0;
			this.btnthem.FlatAppearance.BorderSize = 0;
			this.btnthem.FlatStyle = FlatStyle.Flat;
			this.btnthem.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnthem.ForeColor = Color.Black;
			this.btnthem.Image = Resources.add_circle_create_expand_new_plus_icon_1232181;
			this.btnthem.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnthem.Location = new Point(6, 39);
			this.btnthem.Name = "btnthem";
			this.btnthem.Size = new Size(105, 60);
			this.btnthem.TabIndex = 7;
			this.btnthem.Text = "Thêm";
			this.btnthem.TextAlign = ContentAlignment.MiddleRight;
			this.btnthem.TextColor = Color.Black;
			this.btnthem.UseVisualStyleBackColor = false;
			this.btnthem.Click += new EventHandler(this.btnthem_Click);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.btnCapID);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(groupBox);
			this.panel1.Controls.Add(this.chkHienMKNXB);
			this.panel1.Controls.Add(this.txtDiaChiNXB);
			this.panel1.Controls.Add(this.txtSDTNXB);
			this.panel1.Controls.Add(this.txtTenNXB);
			this.panel1.Controls.Add(this.txtIDNXB);
			this.panel1.Controls.Add(this.txtMatKhauNXB);
			this.panel1.Controls.Add(this.label17);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.dgvNXB);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1473, 1010);
			this.panel1.TabIndex = 0;
			this.panel4.BackColor = Color.Black;
			this.panel4.Location = new Point(1, 1002);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(509, 4);
			this.panel4.TabIndex = 105;
			this.btnCapID.BackColor = SystemColors.ActiveCaption;
			this.btnCapID.BackgroundColor = SystemColors.ActiveCaption;
			this.btnCapID.BorderColor = SystemColors.ActiveBorder;
			this.btnCapID.BorderRadius = 0;
			this.btnCapID.BorderSize = 0;
			this.btnCapID.FlatAppearance.BorderSize = 0;
			this.btnCapID.FlatStyle = FlatStyle.Flat;
			this.btnCapID.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.btnCapID.ForeColor = SystemColors.ActiveCaptionText;
			this.btnCapID.Location = new Point(385, 139);
			this.btnCapID.Name = "btnCapID";
			this.btnCapID.Size = new Size(80, 30);
			this.btnCapID.TabIndex = 104;
			this.btnCapID.Text = "Cấp ID";
			this.btnCapID.TextColor = SystemColors.ActiveCaptionText;
			this.btnCapID.UseVisualStyleBackColor = false;
			this.btnCapID.Click += new EventHandler(this.btnCapID_Click);
			this.panel2.BackColor = Color.Black;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Location = new Point(1, 505);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(509, 4);
			this.panel2.TabIndex = 103;
			this.panel3.BackColor = Color.Black;
			this.panel3.Location = new Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(509, 4);
			this.panel3.TabIndex = 104;
			this.label1.AutoSize = true;
			this.label1.BackColor = SystemColors.HighlightText;
			this.label1.Font = new Font("Tahoma", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Image = Resources._3289576_individual_man_people_person_107097__1_3;
			this.label1.ImageAlign = ContentAlignment.MiddleLeft;
			this.label1.Location = new Point(803, 63);
			this.label1.Name = "label1";
			this.label1.Size = new Size(444, 33);
			this.label1.TabIndex = 102;
			this.label1.Text = "   Thông tin danh sách nhà xuất bản";
			this.label1.TextAlign = ContentAlignment.MiddleRight;
			this.chkHienMKNXB.AutoSize = true;
			this.chkHienMKNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkHienMKNXB.Location = new Point(137, 312);
			this.chkHienMKNXB.Name = "chkHienMKNXB";
			this.chkHienMKNXB.Size = new Size(15, 14);
			this.chkHienMKNXB.TabIndex = 3;
			this.chkHienMKNXB.UseVisualStyleBackColor = true;
			this.chkHienMKNXB.CheckedChanged += new EventHandler(this.chkHienMKNXB_CheckedChanged);
			this.txtDiaChiNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDiaChiNXB.Location = new Point(197, 466);
			this.txtDiaChiNXB.Name = "txtDiaChiNXB";
			this.txtDiaChiNXB.Size = new Size(268, 30);
			this.txtDiaChiNXB.TabIndex = 6;
			this.txtSDTNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNXB.Location = new Point(197, 378);
			this.txtSDTNXB.MaxLength = 10;
			this.txtSDTNXB.Name = "txtSDTNXB";
			this.txtSDTNXB.Size = new Size(268, 30);
			this.txtSDTNXB.TabIndex = 5;
			this.txtSDTNXB.KeyPress += new KeyPressEventHandler(this.txtSDTNXB_KeyPress);
			this.txtTenNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenNXB.Location = new Point(198, 223);
			this.txtTenNXB.Name = "txtTenNXB";
			this.txtTenNXB.Size = new Size(268, 30);
			this.txtTenNXB.TabIndex = 2;
			this.txtIDNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNXB.Location = new Point(198, 140);
			this.txtIDNXB.MaxLength = 10;
			this.txtIDNXB.Name = "txtIDNXB";
			this.txtIDNXB.Size = new Size(268, 30);
			this.txtIDNXB.TabIndex = 1;
			this.txtMatKhauNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMatKhauNXB.Location = new Point(197, 299);
			this.txtMatKhauNXB.Name = "txtMatKhauNXB";
			this.txtMatKhauNXB.Size = new Size(268, 30);
			this.txtMatKhauNXB.TabIndex = 4;
			this.txtMatKhauNXB.UseSystemPasswordChar = true;
			this.label17.AutoSize = true;
			this.label17.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label17.Location = new Point(40, 386);
			this.label17.Name = "label17";
			this.label17.Size = new Size(114, 22);
			this.label17.TabIndex = 22;
			this.label17.Text = "Số điện thoại";
			this.label16.AccessibleRole = AccessibleRole.CheckButton;
			this.label16.AutoSize = true;
			this.label16.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label16.Location = new Point(40, 226);
			this.label16.Name = "label16";
			this.label16.Size = new Size(142, 22);
			this.label16.TabIndex = 21;
			this.label16.Text = "Tên nhà xuất bản";
			this.label15.AutoSize = true;
			this.label15.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label15.Location = new Point(40, 148);
			this.label15.Name = "label15";
			this.label15.Size = new Size(132, 22);
			this.label15.TabIndex = 19;
			this.label15.Text = "ID nhà xuất bản";
			this.label14.AutoSize = true;
			this.label14.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label14.Location = new Point(40, 307);
			this.label14.Name = "label14";
			this.label14.Size = new Size(82, 22);
			this.label14.TabIndex = 17;
			this.label14.Text = "Mật khẩu";
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label13.Location = new Point(40, 474);
			this.label13.Name = "label13";
			this.label13.Size = new Size(68, 22);
			this.label13.TabIndex = 15;
			this.label13.Text = "Địa chỉ";
			this.label11.AutoSize = true;
			this.label11.BackColor = SystemColors.HighlightText;
			this.label11.Font = new Font("Tahoma", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label11.Image = Resources._3289576_individual_man_people_person_107097__1_3;
			this.label11.ImageAlign = ContentAlignment.MiddleLeft;
			this.label11.Location = new Point(131, 63);
			this.label11.Name = "label11";
			this.label11.Size = new Size(316, 33);
			this.label11.TabIndex = 12;
			this.label11.Text = "   Thông tin nhà xuất bản";
			this.label11.TextAlign = ContentAlignment.MiddleRight;
			this.dgvNXB.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvNXB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvNXB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvNXB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNXB.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column10,
				this.Column11,
				this.Column12,
				this.Column13,
				this.Column14
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dgvNXB.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvNXB.Location = new Point(510, 140);
			this.dgvNXB.Name = "dgvNXB";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvNXB.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvNXB.RowTemplate.Height = 50;
			this.dgvNXB.Size = new Size(961, 868);
			this.dgvNXB.TabIndex = 10;
			this.dgvNXB.CellClick += new DataGridViewCellEventHandler(this.dgvNXB_CellClick);
			this.Column10.DataPropertyName = "IDNXB";
			this.Column10.HeaderText = "ID nhà xuất bản";
			this.Column10.Name = "Column10";
			this.Column10.Width = 115;
			this.Column11.DataPropertyName = "TenNXB";
			this.Column11.HeaderText = "Tên nhà xuất bản";
			this.Column11.Name = "Column11";
			this.Column11.Width = 124;
			this.Column12.DataPropertyName = "MatKhauNXB";
			this.Column12.HeaderText = "Mật khẩu";
			this.Column12.Name = "Column12";
			this.Column12.Width = 96;
			this.Column13.DataPropertyName = "SDTNXB";
			this.Column13.HeaderText = "Số điện thoại";
			this.Column13.Name = "Column13";
			this.Column13.Width = 122;
			this.Column14.DataPropertyName = "DiaChiNXB";
			this.Column14.HeaderText = "địa chỉ";
			this.Column14.Name = "Column14";
			this.Column14.Width = 79;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1474, 1011);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "QL_NhaXuatBan";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ DANH SÁCH NHÀ XUẤT BẢN";
			base.Load += new EventHandler(this.QL_NhaXuatBan_Load);
			base.KeyUp += new KeyEventHandler(this.QL_NhaXuatBan_KeyUp);
			groupBox.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((ISupportInitialize)this.dgvNXB).EndInit();
			base.ResumeLayout(false);
		}
	}
}
