using bansach.Properties;
using CustomButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class Ql_NhanVien : Form
	{
		private CXuLyNV xulyNV;
		private CXuLyLichSuHD xuLyLichSuHD;
		private IContainer components = null;
		private Panel panel1;
		private DataGridView dgvNV;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column7;
		private DataGridViewTextBoxColumn Column8;
		private DataGridViewTextBoxColumn Column9;
		private CheckBox chkhmkQL;
		private GroupBox groupBox2;
		private RadioButton radNam;
		private RadioButton radNu;
		private GroupBox groupBox1;
		private RadioButton radNVBH;
		private RadioButton radQl;
		private DateTimePicker dtpnsnv;
		private TextBox txtLuongNV;
		private TextBox txtSDTNV;
		private TextBox txtDCNV;
		private TextBox txtTenNV;
		private TextBox txtIDNV;
		private TextBox txtMatKhauNV;
		private Label label10;
		private Label label9;
		private Label label8;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private Label label11;
		private VBButton btnXoa;
		private VBButton btnSua;
		private VBButton btnthem;
		private Panel panel2;
		private VBButton btnCapID;
		private Panel panel3;
		public Ql_NhanVien()
		{
			this.InitializeComponent();
		}
		private void hienthiNhanVien(List<CNhanVien> dsNV)
		{
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dsNV;
			this.dgvNV.DataSource = bindingSource;
		}
		private void Ql_NhanVien_Load(object sender, EventArgs e)
		{
			this.xulyNV = new CXuLyNV();
			bool flag = !this.xulyNV.docFile("DSNhanVien.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhanVien.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiNhanVien(this.xulyNV.getDSNV());
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag2 = !this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
			bool flag3 = this.xulyNV.getDSNV().Count == 0;
			if (flag3)
			{
				this.radNVBH.Enabled = false;
				this.btnSua.Enabled = false;
				this.btnXoa.Enabled = false;
			}
		}
		private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.xulyNV.getDSNV().Count > 0;
			if (flag)
			{
				bool flag2 = this.dgvNV.Rows[e.RowIndex].Cells[0].Value == null;
				if (flag2)
				{
					MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this.txtIDNV.Text = this.dgvNV.Rows[e.RowIndex].Cells[0].Value.ToString();
					this.txtMatKhauNV.Text = this.dgvNV.Rows[e.RowIndex].Cells[1].Value.ToString();
					bool flag3 = this.dgvNV.Rows[e.RowIndex].Cells[2].Value.ToString() == "Quản Lý";
					if (flag3)
					{
						this.radQl.Checked = true;
					}
					else
					{
						this.radNVBH.Checked = true;
					}
					this.txtTenNV.Text = this.dgvNV.Rows[e.RowIndex].Cells[3].Value.ToString();
					this.txtSDTNV.Text = this.dgvNV.Rows[e.RowIndex].Cells[4].Value.ToString();
					this.txtDCNV.Text = this.dgvNV.Rows[e.RowIndex].Cells[5].Value.ToString();
					bool flag4 = this.dgvNV.Rows[e.RowIndex].Cells[6].Value.ToString() == "Nam";
					if (flag4)
					{
						this.radNam.Checked = true;
					}
					else
					{
						this.radNu.Checked = true;
					}
					this.dtpnsnv.Value = Convert.ToDateTime(this.dgvNV.Rows[e.RowIndex].Cells[7].Value);
					this.txtLuongNV.Text = this.dgvNV.Rows[e.RowIndex].Cells[8].Value.ToString();
				}
			}
		}
		private void btnthem_Click(object sender, EventArgs e)
		{
			bool flag = this.xulyNV.tim(this.txtIDNV.Text) != null;
			if (flag)
			{
				MessageBox.Show("ID nhân viên đã tồn tại, không thể thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtIDNV.Text == "" || this.txtTenNV.Text == "" || this.txtMatKhauNV.Text == "" || this.txtSDTNV.Text == "" || this.txtDCNV.Text == "" || this.txtLuongNV.Text == "" || (!this.radNam.Checked && !this.radNu.Checked) || (!this.radQl.Checked && !this.radNVBH.Checked);
				if (flag2)
				{
					MessageBox.Show("Điền thông tin nhân viên chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					CNhanVien cNhanVien = new CNhanVien();
					cNhanVien.NgaysinhNV = this.dtpnsnv.Value;
					bool flag3 = !this.xulyNV.ktID(this.txtIDNV.Text);
					if (flag3)
					{
						MessageBox.Show("ID nhân viên sai định dạng,ID phải gồm 10 kí tự,bắt đầu là NV và rồi 8 kí tự còn lại là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						cNhanVien.IDNV = this.txtIDNV.Text;
						bool flag4 = this.xulyNV.coSo(this.txtTenNV.Text);
						if (flag4)
						{
							MessageBox.Show("Tên nhân viên sai định dạng,tên nhân viên không có kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							cNhanVien.TenNV = this.txtTenNV.Text;
							bool flag5 = this.txtMatKhauNV.Text.Length < 10 || !this.xulyNV.coSo(this.txtMatKhauNV.Text) || !this.xulyNV.cochu(this.txtMatKhauNV.Text);
							if (flag5)
							{
								MessageBox.Show("Mật khẩu không đủ an toàn.Mật khẩu phải vừa có số lượng kí tự>9,vừa phải bao gồm chữ và số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								cNhanVien.MatKhauNV = this.txtMatKhauNV.Text;
								bool flag6 = this.txtSDTNV.Text.Length != 10 || !this.xulyNV.toanSo(this.txtSDTNV.Text);
								if (flag6)
								{
									MessageBox.Show("Số điện thoại không đúng định dạng.SDT phải là một chuỗi có 10 kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									cNhanVien.SDTNV = this.txtSDTNV.Text;
									bool flag7 = this.xulyNV.toanSo(this.txtDCNV.Text);
									if (flag7)
									{
										MessageBox.Show("Địa chỉ không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										cNhanVien.DiaChiNV = this.txtDCNV.Text;
										bool flag8 = int.Parse(this.txtLuongNV.Text) <= 0 || !this.xulyNV.toanSo(this.txtLuongNV.Text);
										if (flag8)
										{
											MessageBox.Show("Nhập sai định dạng số lương,số lương phải lớn hơn 0 và chỉ bao gồm kí tự số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										else
										{
											cNhanVien.LuongCoBanNV = (long)int.Parse(this.txtLuongNV.Text);
											bool @checked = this.radNam.Checked;
											if (@checked)
											{
												cNhanVien.GioitinhNV = "Nam";
											}
											else
											{
												cNhanVien.GioitinhNV = "Nữ";
											}
											bool checked2 = this.radQl.Checked;
											if (checked2)
											{
												bool flag9 = this.xulyNV.timQl();
												if (flag9)
												{
													MessageBox.Show("Đã tồn tại tại khoản quản lý ,không thể thêm tài khoản quản lí khác được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
													this.radNVBH.Checked = true;
													return;
												}
												cNhanVien.LoaiNV = "Quản Lý";
											}
											else
											{
												cNhanVien.LoaiNV = "Nhân viên Bán Hàng";
											}
											bool flag10 = this.xulyNV.getDSNV().Count == 0;
											if (flag10)
											{
												CLichSuHD cLichSuHD = new CLichSuHD();
												cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
												cLichSuHD.NHoatDong = DateTime.Now;
												cLichSuHD.IDND = "Admin";
												cLichSuHD.TenND = "Admin";
												cLichSuHD.HoatDong = "Thêm nhân viên quản lý";
												cLichSuHD.IDDoiTuong = this.txtIDNV.Text;
												cLichSuHD.DoiTuong = "Nhân viên quản lý " + this.txtTenNV.Text;
												cLichSuHD.NoiDung = "Thêm  nhân viên quản lý với ID nhân viên =" + this.txtIDNV.Text;
												this.xuLyLichSuHD.them(cLichSuHD);
												this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
												this.xulyNV.them(cNhanVien);
												this.xulyNV.ghiFile("DSNhanVien.dat");
												this.hienthiNhanVien(this.xulyNV.getDSNV());
												this.txtIDNV.Text = "";
												this.txtMatKhauNV.Text = "";
												this.txtTenNV.Text = "";
												this.txtDCNV.Text = "";
												this.txtSDTNV.Text = "";
												this.txtLuongNV.Text = "";
												this.dtpnsnv.Value = DateTime.Now;
												this.xulyNV.docFile("DSNhanVien.dat");
												MessageBox.Show("Bạn đã tài thành công tài khoản quản lý,hãy thoát hẳn chương tình và đăng nhập bằng tài khoản quản lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
												base.Close();
											}
											else
											{
												bool flag11 = this.xulyNV.getDSNV().Count > 0;
												if (flag11)
												{
													CLichSuHD cLichSuHD2 = new CLichSuHD();
													cLichSuHD2.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
													cLichSuHD2.NHoatDong = DateTime.Now;
													cLichSuHD2.IDND = CConst.Nhanvien.IDNV;
													cLichSuHD2.TenND = CConst.Nhanvien.TenNV;
													cLichSuHD2.HoatDong = "Thêm nhân viên";
													cLichSuHD2.IDDoiTuong = this.txtIDNV.Text;
													cLichSuHD2.DoiTuong = "Nhân viên " + this.txtTenNV.Text;
													cLichSuHD2.NoiDung = "Thêm  nhân viên mới  với ID nhân viên =" + this.txtIDNV.Text;
													this.xuLyLichSuHD.them(cLichSuHD2);
													this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
													this.xulyNV.them(cNhanVien);
													this.xulyNV.ghiFile("DSNhanVien.dat");
													this.hienthiNhanVien(this.xulyNV.getDSNV());
													this.txtIDNV.Text = "";
													this.txtMatKhauNV.Text = "";
													this.txtTenNV.Text = "";
													this.txtDCNV.Text = "";
													this.txtSDTNV.Text = "";
													this.txtLuongNV.Text = "";
													this.dtpnsnv.Value = DateTime.Now;
												}
											}
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
			bool flag = this.xulyNV.tim(this.txtIDNV.Text) == null;
			if (flag)
			{
				MessageBox.Show("ID nhân viên không tồn tại, không thể sửa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtIDNV.Text == "" || this.txtTenNV.Text == "" || this.txtMatKhauNV.Text == "" || this.txtSDTNV.Text == "" || this.txtDCNV.Text == "" || this.txtLuongNV.Text == "" || (!this.radNam.Checked && !this.radNu.Checked) || (!this.radQl.Checked && !this.radNVBH.Checked);
				if (flag2)
				{
					MessageBox.Show("Điền thông tin nhân viên chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					CNhanVien cNhanVien = new CNhanVien();
					cNhanVien.NgaysinhNV = this.dtpnsnv.Value;
					bool flag3 = !this.xulyNV.ktID(this.txtIDNV.Text);
					if (flag3)
					{
						MessageBox.Show("ID nhân viên sai định dạng,ID phải gồm 10 kí tự,bắt đầu là NV và rồi 8 kí tự còn lại là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						cNhanVien.IDNV = this.txtIDNV.Text;
						bool flag4 = this.xulyNV.coSo(this.txtTenNV.Text);
						if (flag4)
						{
							MessageBox.Show("Tên nhân viên sai định dạng,tên nhân viên phải toàn là kí tự chữ cái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							cNhanVien.TenNV = this.txtTenNV.Text;
							bool flag5 = this.txtMatKhauNV.Text.Length < 10 || !this.xulyNV.coSo(this.txtMatKhauNV.Text) || !this.xulyNV.cochu(this.txtMatKhauNV.Text);
							if (flag5)
							{
								MessageBox.Show("Mật khẩu không đủ an toàn,Mật khẩu phải vừa có số lượng kí tự>9,vừa phải bao gồm chữ và số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								cNhanVien.MatKhauNV = this.txtMatKhauNV.Text;
								bool flag6 = this.txtSDTNV.Text.Length != 10 || !this.xulyNV.toanSo(this.txtSDTNV.Text);
								if (flag6)
								{
									MessageBox.Show("Số điện thoại không đúng định dạng.SDT phải là một chuỗi có 10 kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									cNhanVien.SDTNV = this.txtSDTNV.Text;
									bool flag7 = this.xulyNV.toanSo(this.txtDCNV.Text);
									if (flag7)
									{
										MessageBox.Show("Địa chỉ không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										cNhanVien.DiaChiNV = this.txtDCNV.Text;
										bool flag8 = int.Parse(this.txtLuongNV.Text) <= 0 || !this.xulyNV.toanSo(this.txtLuongNV.Text);
										if (flag8)
										{
											MessageBox.Show("Nhập sai định dạng số lương,số lương phải lớn hơn 0 và chỉ bao gồm kí tự số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										else
										{
											cNhanVien.LuongCoBanNV = (long)int.Parse(this.txtLuongNV.Text);
											bool @checked = this.radNam.Checked;
											if (@checked)
											{
												cNhanVien.GioitinhNV = "Nam";
											}
											else
											{
												cNhanVien.GioitinhNV = "Nữ";
											}
											bool checked2 = this.radQl.Checked;
											if (checked2)
											{
												bool flag9 = this.xulyNV.timQl() && this.xulyNV.tim(this.txtIDNV.Text).LoaiNV != "Quản Lý";
												if (flag9)
												{
													MessageBox.Show("Đã tồn tại tài khoản quản lý ,không thể đổi quyền thành tài khoản quản lí khác được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
													this.radNVBH.Checked = true;
													return;
												}
												cNhanVien.LoaiNV = "Quản Lý";
											}
											else
											{
												cNhanVien.LoaiNV = "Nhân viên Bán Hàng";
											}
											bool flag10 = this.xulyNV.tim(this.txtIDNV.Text).LoaiNV == "Quản Lý" && cNhanVien.LoaiNV == "Nhân viên Bán Hàng";
											if (flag10)
											{
												MessageBox.Show("Không thể đổi quyền tài khoản quản lí được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
												this.radQl.Checked = true;
											}
											else
											{
												CLichSuHD cLichSuHD = new CLichSuHD();
												cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
												cLichSuHD.NHoatDong = DateTime.Now;
												cLichSuHD.IDND = CConst.Nhanvien.IDNV;
												cLichSuHD.TenND = CConst.Nhanvien.TenNV;
												cLichSuHD.HoatDong = "Sửa thông tin nhân viên";
												cLichSuHD.IDDoiTuong = this.txtIDNV.Text;
												cLichSuHD.DoiTuong = "Nhân viên " + this.xulyNV.tim(this.txtIDNV.Text).TenNV;
												cLichSuHD.NoiDung = "Sửa thông tin nhân viên ID nhân viên =" + cNhanVien.IDNV + " || ";
												bool flag11 = this.xulyNV.tim(cNhanVien.IDNV).TenNV != cNhanVien.TenNV;
												if (flag11)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa tên nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).TenNV,
														"->",
														cNhanVien.TenNV,
														" || "
													});
												}
												bool flag12 = this.xulyNV.tim(cNhanVien.IDNV).MatKhauNV != cNhanVien.MatKhauNV;
												if (flag12)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa mật khẩu nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).MatKhauNV,
														"->",
														cNhanVien.MatKhauNV,
														" || "
													});
												}
												bool flag13 = this.xulyNV.tim(cNhanVien.IDNV).LoaiNV != cNhanVien.LoaiNV;
												if (flag13)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa quyền nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).LoaiNV,
														"->",
														cNhanVien.LoaiNV,
														" || "
													});
												}
												bool flag14 = this.xulyNV.tim(cNhanVien.IDNV).DiaChiNV != cNhanVien.DiaChiNV;
												if (flag14)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa địa chỉ nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).DiaChiNV,
														"->",
														cNhanVien.DiaChiNV,
														" || "
													});
												}
												bool flag15 = this.xulyNV.tim(cNhanVien.IDNV).SDTNV != cNhanVien.SDTNV;
												if (flag15)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa số điện thoại nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).SDTNV,
														"->",
														cNhanVien.SDTNV,
														" || "
													});
												}
												bool flag16 = this.xulyNV.tim(cNhanVien.IDNV).GioitinhNV != cNhanVien.GioitinhNV;
												if (flag16)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa giới tính nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).GioitinhNV,
														"->",
														cNhanVien.GioitinhNV,
														" || "
													});
												}
												bool flag17 = this.xulyNV.tim(cNhanVien.IDNV).NgaysinhNV != cNhanVien.NgaysinhNV;
												if (flag17)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa ngày sinh nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).NgaysinhNV.ToString(),
														"->",
														cNhanVien.NgaysinhNV.ToString(),
														" || "
													});
												}
												bool flag18 = this.xulyNV.tim(cNhanVien.IDNV).LuongCoBanNV != cNhanVien.LuongCoBanNV;
												if (flag18)
												{
													cLichSuHD.NoiDung = string.Concat(new string[]
													{
														cLichSuHD.NoiDung,
														"Sửa lương khẩu nhân viên:",
														this.xulyNV.tim(cNhanVien.IDNV).LuongCoBanNV.ToString(),
														"->",
														cNhanVien.LuongCoBanNV.ToString(),
														" || "
													});
												}
												this.xuLyLichSuHD.them(cLichSuHD);
												this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
												this.xulyNV.sua(cNhanVien);
												this.xulyNV.ghiFile("DSNhanVien.dat");
												this.hienthiNhanVien(this.xulyNV.getDSNV());
												this.txtIDNV.Text = "";
												this.txtMatKhauNV.Text = "";
												this.txtTenNV.Text = "";
												this.txtDCNV.Text = "";
												this.txtSDTNV.Text = "";
												this.txtLuongNV.Text = "";
												this.dtpnsnv.Value = DateTime.Now;
											}
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
			bool flag = this.xulyNV.tim(this.txtIDNV.Text) == null;
			if (flag)
			{
				MessageBox.Show("ID nhân viên không tồn tại, không thể xóa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.xulyNV.tim(this.txtIDNV.Text).LoaiNV == "Quản Lý";
				if (flag2)
				{
					MessageBox.Show("Không thể xóa tài khoản quản lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					CLichSuHD cLichSuHD = new CLichSuHD();
					cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
					cLichSuHD.NHoatDong = DateTime.Now;
					cLichSuHD.IDND = CConst.Nhanvien.IDNV;
					cLichSuHD.TenND = CConst.Nhanvien.TenNV;
					cLichSuHD.HoatDong = "Xóa nhân viên";
					cLichSuHD.IDDoiTuong = this.txtIDNV.Text;
					cLichSuHD.DoiTuong = "Nhân viên " + this.xulyNV.tim(this.txtIDNV.Text).TenNV;
					cLichSuHD.NoiDung = "Xóa nhân viên với ID nhân viên =" + this.txtIDNV.Text;
					this.xuLyLichSuHD.them(cLichSuHD);
					this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
					this.xulyNV.xoa(this.txtIDNV.Text);
					this.xulyNV.ghiFile("DSNhanVien.dat");
					this.hienthiNhanVien(this.xulyNV.getDSNV());
					this.txtIDNV.Text = "";
					this.txtMatKhauNV.Text = "";
					this.txtTenNV.Text = "";
					this.txtDCNV.Text = "";
					this.txtSDTNV.Text = "";
					this.txtLuongNV.Text = "";
					this.dtpnsnv.Value = DateTime.Now;
				}
			}
		}
		private void txtSDTNV_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void txtLuongNV_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void chkhmkQL_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.chkhmkQL.Checked;
			if (flag)
			{
				this.txtMatKhauNV.UseSystemPasswordChar = true;
			}
			else
			{
				this.txtMatKhauNV.UseSystemPasswordChar = false;
			}
		}
		private void Ql_NhanVien_KeyUp(object sender, KeyEventArgs e)
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
			this.txtIDNV.Text = this.xulyNV.CapIDNV();
			this.txtTenNV.Text = "";
			this.txtMatKhauNV.Text = "";
			this.radNam.Checked = false;
			this.radQl.Checked = false;
			this.txtSDTNV.Text = "";
			this.txtDCNV.Text = "";
			this.txtLuongNV.Text = "";
			this.dtpnsnv.Value = DateTime.Now;
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
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Ql_NhanVien));
			this.btnXoa = new VBButton();
			this.btnSua = new VBButton();
			this.btnthem = new VBButton();
			this.panel1 = new Panel();
			this.panel3 = new Panel();
			this.btnCapID = new VBButton();
			this.panel2 = new Panel();
			this.label11 = new Label();
			this.chkhmkQL = new CheckBox();
			this.groupBox2 = new GroupBox();
			this.radNam = new RadioButton();
			this.radNu = new RadioButton();
			this.groupBox1 = new GroupBox();
			this.radNVBH = new RadioButton();
			this.radQl = new RadioButton();
			this.dtpnsnv = new DateTimePicker();
			this.txtLuongNV = new TextBox();
			this.txtSDTNV = new TextBox();
			this.txtDCNV = new TextBox();
			this.txtTenNV = new TextBox();
			this.txtIDNV = new TextBox();
			this.txtMatKhauNV = new TextBox();
			this.label10 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.label6 = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.dgvNV = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.Column9 = new DataGridViewTextBoxColumn();
			GroupBox groupBox = new GroupBox();
			groupBox.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dgvNV).BeginInit();
			base.SuspendLayout();
			groupBox.BackColor = Color.Pink;
			groupBox.Controls.Add(this.btnXoa);
			groupBox.Controls.Add(this.btnSua);
			groupBox.Controls.Add(this.btnthem);
			groupBox.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox.Location = new Point(28, 728);
			groupBox.Name = "groupBox6";
			groupBox.Size = new Size(433, 116);
			groupBox.TabIndex = 13;
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
			this.btnXoa.TabIndex = 15;
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
			this.btnSua.Location = new Point(165, 39);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new Size(105, 60);
			this.btnSua.TabIndex = 14;
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
			this.btnthem.TabIndex = 13;
			this.btnthem.Text = "Thêm";
			this.btnthem.TextAlign = ContentAlignment.MiddleRight;
			this.btnthem.TextColor = Color.Black;
			this.btnthem.UseVisualStyleBackColor = false;
			this.btnthem.Click += new EventHandler(this.btnthem_Click);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.btnCapID);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(groupBox);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.chkhmkQL);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.dtpnsnv);
			this.panel1.Controls.Add(this.txtLuongNV);
			this.panel1.Controls.Add(this.txtSDTNV);
			this.panel1.Controls.Add(this.txtDCNV);
			this.panel1.Controls.Add(this.txtTenNV);
			this.panel1.Controls.Add(this.txtIDNV);
			this.panel1.Controls.Add(this.txtMatKhauNV);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.dgvNV);
			this.panel1.Location = new Point(0, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1515, 1009);
			this.panel1.TabIndex = 0;
			this.panel3.BackColor = Color.Black;
			this.panel3.Location = new Point(1, 1000);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(510, 4);
			this.panel3.TabIndex = 106;
			this.btnCapID.BackColor = SystemColors.ActiveCaption;
			this.btnCapID.BackgroundColor = SystemColors.ActiveCaption;
			this.btnCapID.BorderColor = SystemColors.ActiveBorder;
			this.btnCapID.BorderRadius = 0;
			this.btnCapID.BorderSize = 0;
			this.btnCapID.FlatAppearance.BorderSize = 0;
			this.btnCapID.FlatStyle = FlatStyle.Flat;
			this.btnCapID.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.btnCapID.ForeColor = SystemColors.ActiveCaptionText;
			this.btnCapID.Location = new Point(381, 122);
			this.btnCapID.Name = "btnCapID";
			this.btnCapID.Size = new Size(80, 30);
			this.btnCapID.TabIndex = 105;
			this.btnCapID.Text = "Cấp ID";
			this.btnCapID.TextColor = SystemColors.ActiveCaptionText;
			this.btnCapID.UseVisualStyleBackColor = false;
			this.btnCapID.Click += new EventHandler(this.btnCapID_Click);
			this.panel2.BackColor = Color.Black;
			this.panel2.Location = new Point(1, 598);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(510, 4);
			this.panel2.TabIndex = 49;
			this.label11.AutoSize = true;
			this.label11.BackColor = SystemColors.ControlLightLight;
			this.label11.Font = new Font("Tahoma", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label11.Image = Resources._3289576_individual_man_people_person_107097;
			this.label11.ImageAlign = ContentAlignment.MiddleLeft;
			this.label11.Location = new Point(917, 50);
			this.label11.Name = "label11";
			this.label11.Size = new Size(404, 33);
			this.label11.TabIndex = 48;
			this.label11.Text = "   Thông tin danh sách nhân viên";
			this.label11.TextAlign = ContentAlignment.MiddleRight;
			this.chkhmkQL.AutoSize = true;
			this.chkhmkQL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkhmkQL.Location = new Point(106, 237);
			this.chkhmkQL.Name = "chkhmkQL";
			this.chkhmkQL.Size = new Size(15, 14);
			this.chkhmkQL.TabIndex = 3;
			this.chkhmkQL.UseVisualStyleBackColor = true;
			this.chkhmkQL.CheckedChanged += new EventHandler(this.chkhmkQL_CheckedChanged);
			this.groupBox2.Controls.Add(this.radNam);
			this.groupBox2.Controls.Add(this.radNu);
			this.groupBox2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.Location = new Point(193, 331);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(268, 55);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.radNam.AutoSize = true;
			this.radNam.Checked = true;
			this.radNam.Location = new Point(6, 24);
			this.radNam.Name = "radNam";
			this.radNam.Size = new Size(63, 25);
			this.radNam.TabIndex = 7;
			this.radNam.TabStop = true;
			this.radNam.Text = "Nam";
			this.radNam.UseVisualStyleBackColor = true;
			this.radNu.AutoSize = true;
			this.radNu.Location = new Point(146, 24);
			this.radNu.Name = "radNu";
			this.radNu.Size = new Size(51, 25);
			this.radNu.TabIndex = 9;
			this.radNu.TabStop = true;
			this.radNu.Text = "Nữ";
			this.radNu.UseVisualStyleBackColor = true;
			this.groupBox1.Controls.Add(this.radNVBH);
			this.groupBox1.Controls.Add(this.radQl);
			this.groupBox1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(193, 263);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(274, 52);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.radNVBH.AutoSize = true;
			this.radNVBH.Location = new Point(94, 20);
			this.radNVBH.Name = "radNVBH";
			this.radNVBH.Size = new Size(174, 25);
			this.radNVBH.TabIndex = 6;
			this.radNVBH.TabStop = true;
			this.radNVBH.Text = "Nhân viên bán hàng";
			this.radNVBH.UseVisualStyleBackColor = true;
			this.radQl.AutoSize = true;
			this.radQl.Checked = true;
			this.radQl.Location = new Point(2, 20);
			this.radQl.Name = "radQl";
			this.radQl.Size = new Size(86, 25);
			this.radQl.TabIndex = 5;
			this.radQl.TabStop = true;
			this.radQl.Text = "Quản lý";
			this.radQl.UseVisualStyleBackColor = true;
			this.dtpnsnv.CustomFormat = "dd/MM/yyyy";
			this.dtpnsnv.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpnsnv.Format = DateTimePickerFormat.Custom;
			this.dtpnsnv.Location = new Point(193, 410);
			this.dtpnsnv.Name = "dtpnsnv";
			this.dtpnsnv.Size = new Size(268, 29);
			this.dtpnsnv.TabIndex = 9;
			this.txtLuongNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtLuongNV.Location = new Point(193, 560);
			this.txtLuongNV.Name = "txtLuongNV";
			this.txtLuongNV.Size = new Size(268, 29);
			this.txtLuongNV.TabIndex = 12;
			this.txtLuongNV.KeyPress += new KeyPressEventHandler(this.txtLuongNV_KeyPress);
			this.txtSDTNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNV.Location = new Point(193, 459);
			this.txtSDTNV.MaxLength = 10;
			this.txtSDTNV.Name = "txtSDTNV";
			this.txtSDTNV.Size = new Size(268, 29);
			this.txtSDTNV.TabIndex = 10;
			this.txtSDTNV.KeyPress += new KeyPressEventHandler(this.txtSDTNV_KeyPress);
			this.txtDCNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDCNV.Location = new Point(193, 509);
			this.txtDCNV.Name = "txtDCNV";
			this.txtDCNV.Size = new Size(268, 29);
			this.txtDCNV.TabIndex = 11;
			this.txtTenNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenNV.Location = new Point(193, 171);
			this.txtTenNV.Name = "txtTenNV";
			this.txtTenNV.Size = new Size(268, 29);
			this.txtTenNV.TabIndex = 2;
			this.txtIDNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNV.Location = new Point(193, 122);
			this.txtIDNV.MaxLength = 10;
			this.txtIDNV.Name = "txtIDNV";
			this.txtIDNV.Size = new Size(268, 29);
			this.txtIDNV.TabIndex = 1;
			this.txtMatKhauNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMatKhauNV.Location = new Point(193, 222);
			this.txtMatKhauNV.Name = "txtMatKhauNV";
			this.txtMatKhauNV.Size = new Size(268, 29);
			this.txtMatKhauNV.TabIndex = 4;
			this.txtMatKhauNV.UseSystemPasswordChar = true;
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label10.Location = new Point(24, 560);
			this.label10.Name = "label10";
			this.label10.Size = new Size(59, 21);
			this.label10.TabIndex = 43;
			this.label10.Text = "Lương";
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(24, 517);
			this.label9.Name = "label9";
			this.label9.Size = new Size(65, 21);
			this.label9.TabIndex = 42;
			this.label9.Text = "Địa chỉ";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(24, 294);
			this.label8.Name = "label8";
			this.label8.Size = new Size(43, 21);
			this.label8.TabIndex = 40;
			this.label8.Text = "Loại";
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(20, 467);
			this.label7.Name = "label7";
			this.label7.Size = new Size(108, 21);
			this.label7.TabIndex = 38;
			this.label7.Text = "Số điện thoại";
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(18, 365);
			this.label6.Name = "label6";
			this.label6.Size = new Size(76, 21);
			this.label6.TabIndex = 37;
			this.label6.Text = "Giới tính";
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(21, 418);
			this.label5.Name = "label5";
			this.label5.Size = new Size(84, 21);
			this.label5.TabIndex = 36;
			this.label5.Text = "Ngày sinh";
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(21, 233);
			this.label4.Name = "label4";
			this.label4.Size = new Size(79, 21);
			this.label4.TabIndex = 34;
			this.label4.Text = "Mật khẩu";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(20, 179);
			this.label3.Name = "label3";
			this.label3.Size = new Size(82, 21);
			this.label3.TabIndex = 32;
			this.label3.Text = "Họ và tên";
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(20, 122);
			this.label2.Name = "label2";
			this.label2.Size = new Size(104, 21);
			this.label2.TabIndex = 30;
			this.label2.Text = "ID nhân viên";
			this.label1.AutoSize = true;
			this.label1.BackColor = SystemColors.ControlLightLight;
			this.label1.Font = new Font("Tahoma", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Image = Resources._3289576_individual_man_people_person_107097;
			this.label1.ImageAlign = ContentAlignment.MiddleLeft;
			this.label1.Location = new Point(154, 50);
			this.label1.Name = "label1";
			this.label1.Size = new Size(276, 33);
			this.label1.TabIndex = 28;
			this.label1.Text = "   Thông tin nhân viên";
			this.label1.TextAlign = ContentAlignment.MiddleRight;
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dgvNV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dgvNV.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvNV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			this.dgvNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNV.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column1,
				this.Column2,
				this.Column3,
				this.Column4,
				this.Column5,
				this.Column6,
				this.Column7,
				this.Column8,
				this.Column9
			});
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			this.dgvNV.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvNV.Location = new Point(511, 122);
			this.dgvNV.Name = "dgvNV";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dgvNV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvNV.RowHeadersWidth = 70;
			this.dgvNV.RowTemplate.Height = 50;
			this.dgvNV.Size = new Size(1002, 885);
			this.dgvNV.TabIndex = 16;
			this.dgvNV.CellClick += new DataGridViewCellEventHandler(this.dgvNV_CellClick);
			this.Column1.DataPropertyName = "IDNV";
			this.Column1.HeaderText = "ID nhân viên";
			this.Column1.Name = "Column1";
			this.Column1.Width = 129;
			this.Column2.DataPropertyName = "TenNV";
			this.Column2.HeaderText = "Họ và tên";
			this.Column2.Name = "Column2";
			this.Column2.Width = 107;
			this.Column3.DataPropertyName = "MatKhauNV";
			this.Column3.HeaderText = "Mật khẩu";
			this.Column3.Name = "Column3";
			this.Column3.Width = 104;
			this.Column4.DataPropertyName = "LoaiNV";
			this.Column4.HeaderText = "Loại";
			this.Column4.Name = "Column4";
			this.Column4.Width = 68;
			this.Column5.DataPropertyName = "GioiTinhNV";
			this.Column5.HeaderText = "Giới tính";
			this.Column5.Name = "Column5";
			this.Column5.Width = 101;
			this.Column6.DataPropertyName = "NgaySinhNV";
			dataGridViewCellStyle5.Format = "dd/MM/yyyy";
			this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column6.HeaderText = "Ngày sinh";
			this.Column6.Name = "Column6";
			this.Column6.Width = 109;
			this.Column7.DataPropertyName = "SDTNV";
			this.Column7.HeaderText = "Số điện thoại";
			this.Column7.Name = "Column7";
			this.Column7.Width = 133;
			this.Column8.DataPropertyName = "DiaChiNV";
			this.Column8.HeaderText = "Địa chỉ";
			this.Column8.Name = "Column8";
			this.Column8.Width = 90;
			this.Column9.DataPropertyName = "LuongCoBanNV";
			this.Column9.HeaderText = "Lương";
			this.Column9.Name = "Column9";
			this.Column9.Width = 84;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1516, 1011);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Ql_NhanVien";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ DANH SÁCH NHÂN VIÊN";
			base.Load += new EventHandler(this.Ql_NhanVien_Load);
			base.KeyUp += new KeyEventHandler(this.Ql_NhanVien_KeyUp);
			groupBox.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.dgvNV).EndInit();
			base.ResumeLayout(false);
		}
	}
}
