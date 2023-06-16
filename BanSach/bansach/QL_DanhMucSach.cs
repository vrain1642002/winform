using bansach.Properties;
using CustomButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class QL_DanhMucSach : Form
	{
		private CXuLyLichSuHD xuLyLichSuHD;
		private CXuLySach xulySach;
		private CXuLyNXB xulyNXB;
		private IContainer components = null;
		private Panel panel1;
		private VBButton btnXoa;
		private VBButton btnSua;
		private VBButton btnthem;
		private TextBox txtSoLuongT;
		private TextBox txtGiaBanSach;
		private TextBox txtIDNXBS;
		private TextBox txtNXB;
		private TextBox txtTenTG;
		private TextBox txtTenSach;
		private TextBox txtIDSach;
		private TextBox txtGiaNhapGanNhat;
		private Label label12;
		private ComboBox cbxNXB;
		private Label label19;
		private Label label20;
		private Label label21;
		private Label label22;
		private Label label23;
		private Label label24;
		private Label label25;
		private Label label26;
		private Label label27;
		private DataGridView dgvSach;
		private DataGridViewTextBoxColumn Column15;
		private DataGridViewTextBoxColumn Column16;
		private DataGridViewTextBoxColumn Column17;
		private DataGridViewTextBoxColumn Column18;
		private DataGridViewTextBoxColumn Column19;
		private DataGridViewTextBoxColumn Column20;
		private DataGridViewTextBoxColumn Column21;
		private DataGridViewTextBoxColumn Column22;
		private DataGridViewTextBoxColumn Column23;
		private Label label1;
		private Panel panel2;
		private VBButton btnCapID;
		private Panel panel3;
		public QL_DanhMucSach()
		{
			this.InitializeComponent();
		}
		private void hienthiSach(List<CSach> dmSach)
		{
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = dmSach;
			this.dgvSach.DataSource = bindingSource;
		}
		private void hienthiComboBoxchonNXB(List<CNhaXuatBan> ds)
		{
			this.cbxNXB.DisplayMember = "TenNXB";
			this.cbxNXB.ValueMember = "TenNXB";
			this.cbxNXB.DataSource = ds;
		}
		private void QL_DanhMucSach_Load(object sender, EventArgs e)
		{
			this.xulyNXB = new CXuLyNXB();
			bool flag = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiComboBoxchonNXB(this.xulyNXB.getDSNXB());
			}
			this.xulySach = new CXuLySach();
			bool flag2 = !this.xulySach.docFile("DanhMucSach.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu file DanhMucSach.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiSach(this.xulySach.getDSSach());
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag3 = !this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag3)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
		}
		private void cbxNXB_SelectedIndexChanged(object sender, EventArgs e)
		{
			string b = this.cbxNXB.SelectedValue.ToString();
			foreach (CNhaXuatBan current in this.xulyNXB.getDSNXB())
			{
				bool flag = current.TenNXB == b;
				if (flag)
				{
					this.txtIDNXBS.Text = current.IDNXB;
				}
			}
		}
		private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.xulySach.getDSSach().Count > 0;
			if (flag)
			{
				bool flag2 = this.dgvSach.Rows[e.RowIndex].Cells[0].Value == null;
				if (flag2)
				{
					MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this.txtIDSach.Text = this.dgvSach.Rows[e.RowIndex].Cells[0].Value.ToString();
					this.txtTenSach.Text = this.dgvSach.Rows[e.RowIndex].Cells[1].Value.ToString();
					this.txtSoLuongT.Text = this.dgvSach.Rows[e.RowIndex].Cells[2].Value.ToString();
					this.txtGiaBanSach.Text = this.dgvSach.Rows[e.RowIndex].Cells[3].Value.ToString();
					this.txtGiaNhapGanNhat.Text = this.dgvSach.Rows[e.RowIndex].Cells[4].Value.ToString();
					this.txtIDNXBS.Text = this.dgvSach.Rows[e.RowIndex].Cells[5].Value.ToString();
					this.cbxNXB.Text = this.dgvSach.Rows[e.RowIndex].Cells[6].Value.ToString();
					this.txtNXB.Text = this.dgvSach.Rows[e.RowIndex].Cells[7].Value.ToString();
					this.txtTenTG.Text = this.dgvSach.Rows[e.RowIndex].Cells[8].Value.ToString();
				}
			}
		}
		private void btnthem_Click(object sender, EventArgs e)
		{
			bool flag = this.xulySach.tim(this.txtIDSach.Text) != null;
			if (flag)
			{
				MessageBox.Show("ID sách bản đã tồn tại, không thể thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtTenSach.Text == "" || this.txtGiaNhapGanNhat.Text == "" || this.txtGiaBanSach.Text == "" || this.txtIDNXBS.Text == "" || this.txtNXB.Text == "" || this.txtTenTG.Text == "";
				if (flag2)
				{
					MessageBox.Show("Điền thông tin sách chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					CSach cSach = new CSach();
					bool flag3 = !this.xulySach.ktID(this.txtIDSach.Text);
					if (flag3)
					{
						MessageBox.Show("ID sách sai định dạng,ID phải gồm 10 kí tự,bắt đầu là S và rồi 9 kí tự còn lại là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						cSach.IDSach = this.txtIDSach.Text;
						bool flag4 = this.xulySach.toanSo(this.txtTenSach.Text);
						if (flag4)
						{
							MessageBox.Show("Tên sách sai định dạng khi toàn là kí tự số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							bool flag5 = this.xulySach.timTenSach(this.txtTenSach.Text) != null;
							if (flag5)
							{
								MessageBox.Show("Tên sách đã tồn tại  nên không thể thêm được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								cSach.TenSach = this.txtTenSach.Text;
								bool flag6 = !this.xulySach.toanSo(this.txtSoLuongT.Text) || int.Parse(this.txtSoLuongT.Text) > 0;
								if (flag6)
								{
									MessageBox.Show("Số lượng tồn sai định dạng ,phải toàn là kí tự số và=0 khi thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									cSach.SoLuongT = int.Parse(this.txtSoLuongT.Text);
									bool flag7 = !this.xulySach.toanSo(this.txtGiaBanSach.Text) || int.Parse(this.txtGiaBanSach.Text) > 0;
									if (flag7)
									{
										MessageBox.Show("Giá bán sai định dạng,phải toàn là kí tự số và =0 khi thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										cSach.GiaBan = int.Parse(this.txtGiaBanSach.Text);
										bool flag8 = !this.xulySach.toanSo(this.txtGiaNhapGanNhat.Text) || int.Parse(this.txtGiaNhapGanNhat.Text) > 0;
										if (flag8)
										{
											MessageBox.Show("Giá nhập gần nhất sai định dạng,phải toàn là kí tự số và =0 khi thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										else
										{
											cSach.GiaNhapGanNhat = int.Parse(this.txtGiaNhapGanNhat.Text);
											cSach.TenNXB = this.cbxNXB.SelectedValue.ToString();
											cSach.IDNXB = this.txtIDNXBS.Text;
											bool flag9 = !this.xulySach.toanSo(this.txtNXB.Text) || int.Parse(this.txtNXB.Text) <= 0;
											if (flag9)
											{
												MessageBox.Show("Năm xuất bản sách sai định dạng,phải toàn là kí tự số và >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											}
											else
											{
												bool flag10 = int.Parse(this.txtNXB.Text) > DateTime.Now.Year;
												if (flag10)
												{
													MessageBox.Show("Năm xuất bản không được lớn hơn năm hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
												}
												else
												{
													cSach.NXB = int.Parse(this.txtNXB.Text);
													bool flag11 = this.xulySach.toanSo(this.txtTenTG.Text);
													if (flag11)
													{
														MessageBox.Show("Tên tác giả sai định dạng khi toàn là kí tự số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
													}
													else
													{
														cSach.TenTG = this.txtTenTG.Text;
														this.xulySach.them(cSach);
														this.hienthiSach(this.xulySach.getDSSach());
														this.xulySach.ghiFile("DanhMucSach.dat");
														CLichSuHD cLichSuHD = new CLichSuHD();
														cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
														cLichSuHD.NHoatDong = DateTime.Now;
														cLichSuHD.IDND = CConst.Nhanvien.IDNV;
														cLichSuHD.TenND = CConst.Nhanvien.TenNV;
														cLichSuHD.HoatDong = "Thêm sách ";
														cLichSuHD.IDDoiTuong = cSach.IDSach;
														cLichSuHD.DoiTuong = "Sách " + cSach.TenSach;
														cLichSuHD.NoiDung = "Thêm sách mới với ID sách=" + cSach.IDSach;
														this.xuLyLichSuHD.them(cLichSuHD);
														this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
														this.txtIDSach.Text = "";
														this.txtTenSach.Text = "";
														this.txtTenTG.Text = "";
														this.txtSoLuongT.Text = "";
														this.txtGiaNhapGanNhat.Text = "";
														this.txtGiaBanSach.Text = "";
														this.txtNXB.Text = "";
														this.txtTenTG.Text = "";
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
		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			bool flag = this.xulySach.tim(this.txtIDSach.Text) == null;
			if (flag)
			{
				MessageBox.Show("ID sách không tồn tại, không thể sửa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtTenSach.Text == "" || this.txtGiaNhapGanNhat.Text == "" || this.txtGiaBanSach.Text == "" || this.txtIDNXBS.Text == "" || this.txtNXB.Text == "" || this.txtTenTG.Text == "";
				if (flag2)
				{
					MessageBox.Show("Điền thông tin sách chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					CSach cSach = new CSach();
					cSach.IDSach = this.txtIDSach.Text;
					bool flag3 = this.xulySach.toanSo(this.txtTenSach.Text);
					if (flag3)
					{
						MessageBox.Show("Tên sách sai định dạng khi toàn là kí tự số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						bool flag4 = this.xulySach.timTenSach(this.txtTenSach.Text) != null && this.txtIDNXBS.Text != this.xulySach.timTenSach(this.txtTenSach.Text).IDNXB;
						if (flag4)
						{
							MessageBox.Show("Không thể đổi sách sang nhà xuất bản khác,phải xóa đi để chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							cSach.TenSach = this.txtTenSach.Text;
							bool flag5 = !this.xulySach.toanSo(this.txtSoLuongT.Text) || int.Parse(this.txtSoLuongT.Text) < 0;
							if (flag5)
							{
								MessageBox.Show("Số lượng tồn sai định dạng ,phải toàn là kí tự số và >=0 khi sua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								cSach.SoLuongT = int.Parse(this.txtSoLuongT.Text);
								bool flag6 = this.xulySach.tim(this.txtIDSach.Text).GiaNhapGanNhat != int.Parse(this.txtGiaNhapGanNhat.Text);
								if (flag6)
								{
									MessageBox.Show("Không thể sửa giá nhập gần nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									cSach.GiaNhapGanNhat = int.Parse(this.txtGiaNhapGanNhat.Text);
									bool flag7 = !this.xulySach.toanSo(this.txtGiaBanSach.Text) || int.Parse(this.txtGiaBanSach.Text) <= 0;
									if (flag7)
									{
										MessageBox.Show("Giá bán sai định dạng,phải toàn là kí tự số và >0 khi sua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										cSach.GiaBan = int.Parse(this.txtGiaBanSach.Text);
										cSach.TenNXB = this.cbxNXB.SelectedValue.ToString();
										cSach.IDNXB = this.txtIDNXBS.Text;
										bool flag8 = !this.xulySach.toanSo(this.txtNXB.Text) || int.Parse(this.txtNXB.Text) <= 0;
										if (flag8)
										{
											MessageBox.Show("Năm xuất bản sách sai định dạng,phải toàn là kí tự số và >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										else
										{
											bool flag9 = int.Parse(this.txtNXB.Text) > DateTime.Now.Year;
											if (flag9)
											{
												MessageBox.Show("Năm xuất bản không được lớn hơn năm hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											}
											else
											{
												cSach.NXB = int.Parse(this.txtNXB.Text);
												bool flag10 = this.xulySach.toanSo(this.txtTenTG.Text);
												if (flag10)
												{
													MessageBox.Show("Tên tác giả sai định dạng khi toàn là kí tự số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
												}
												else
												{
													cSach.TenTG = this.txtTenTG.Text;
													CLichSuHD cLichSuHD = new CLichSuHD();
													cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
													cLichSuHD.NHoatDong = DateTime.Now;
													cLichSuHD.IDND = CConst.Nhanvien.IDNV;
													cLichSuHD.TenND = CConst.Nhanvien.TenNV;
													cLichSuHD.HoatDong = "Sửa thông tin sách";
													cLichSuHD.IDDoiTuong = this.txtIDSach.Text;
													cLichSuHD.DoiTuong = "Sách " + this.txtIDSach.Text;
													cLichSuHD.NoiDung = "Sửa thông tin sách với ID Sách=" + this.txtIDSach.Text + " || ";
													bool flag11 = this.xulySach.tim(cSach.IDSach).TenSach != cSach.TenSach;
													if (flag11)
													{
														cLichSuHD.NoiDung = string.Concat(new string[]
														{
															cLichSuHD.NoiDung,
															"Sửa tên sách:",
															this.xulySach.tim(cSach.IDSach).TenSach,
															"->",
															cSach.TenSach,
															" || "
														});
													}
													bool flag12 = this.xulySach.tim(cSach.IDSach).SoLuongT != cSach.SoLuongT;
													if (flag12)
													{
														cLichSuHD.NoiDung = string.Concat(new string[]
														{
															cLichSuHD.NoiDung,
															"Sửa số lượng tồn:",
															this.xulySach.tim(cSach.IDSach).SoLuongT.ToString(),
															"->",
															cSach.SoLuongT.ToString(),
															" || "
														});
													}
													bool flag13 = this.xulySach.tim(cSach.IDSach).GiaNhapGanNhat != cSach.GiaNhapGanNhat;
													if (flag13)
													{
														cLichSuHD.NoiDung = string.Concat(new string[]
														{
															cLichSuHD.NoiDung,
															"Sửa giá nhập gần nhất:",
															this.xulySach.tim(cSach.IDSach).GiaNhapGanNhat.ToString(),
															"->",
															cSach.GiaNhapGanNhat.ToString(),
															" || "
														});
													}
													bool flag14 = this.xulySach.tim(cSach.IDSach).GiaBan != cSach.GiaBan;
													if (flag14)
													{
														cLichSuHD.NoiDung = string.Concat(new string[]
														{
															cLichSuHD.NoiDung,
															"Sửa giá bán:",
															this.xulySach.tim(cSach.IDSach).GiaBan.ToString(),
															"->",
															cSach.GiaBan.ToString(),
															" || "
														});
													}
													bool flag15 = this.xulySach.tim(cSach.IDSach).NXB != cSach.NXB;
													if (flag15)
													{
														cLichSuHD.NoiDung = string.Concat(new string[]
														{
															cLichSuHD.NoiDung,
															"Sửa năm xuất bản:",
															this.xulySach.tim(cSach.IDSach).NXB.ToString(),
															"->",
															cSach.NXB.ToString(),
															" || "
														});
													}
													bool flag16 = this.xulySach.tim(cSach.IDSach).TenTG != cSach.TenTG;
													if (flag16)
													{
														cLichSuHD.NoiDung = string.Concat(new string[]
														{
															cLichSuHD.NoiDung,
															"Sửa tên tác giả:",
															this.xulySach.tim(cSach.IDSach).TenTG,
															"->",
															cSach.TenTG,
															" || "
														});
													}
													this.xuLyLichSuHD.them(cLichSuHD);
													this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
													this.xulySach.sua(cSach);
													this.hienthiSach(this.xulySach.getDSSach());
													this.xulySach.ghiFile("DanhMucSach.dat");
													this.txtIDSach.Text = "";
													this.txtSoLuongT.Text = "";
													this.txtTenSach.Text = "";
													this.txtTenTG.Text = "";
													this.txtGiaNhapGanNhat.Text = "";
													this.txtGiaBanSach.Text = "";
													this.txtNXB.Text = "";
													this.txtTenTG.Text = "";
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
		private void btnXoa_Click(object sender, EventArgs e)
		{
			bool flag = this.xulySach.tim(this.txtIDSach.Text) == null;
			if (flag)
			{
				MessageBox.Show("ID sách không tồn tại, không thể xóa được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				CLichSuHD cLichSuHD = new CLichSuHD();
				cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
				cLichSuHD.NHoatDong = DateTime.Now;
				cLichSuHD.IDND = CConst.Nhanvien.IDNV;
				cLichSuHD.TenND = CConst.Nhanvien.TenNV;
				cLichSuHD.HoatDong = "Xóa sách";
				cLichSuHD.IDDoiTuong = this.txtIDSach.Text;
				cLichSuHD.DoiTuong = "Sách " + this.xulySach.tim(this.txtIDSach.Text).TenSach;
				cLichSuHD.NoiDung = "Xóa sách với ID Sách=" + this.txtIDSach.Text;
				this.xuLyLichSuHD.them(cLichSuHD);
				this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
				this.xulySach.xoa(this.txtIDSach.Text);
				this.hienthiSach(this.xulySach.getDSSach());
				this.xulySach.ghiFile("DanhMucSach.dat");
				this.txtIDSach.Text = "";
				this.txtTenSach.Text = "";
				this.txtTenTG.Text = "";
				this.txtGiaNhapGanNhat.Text = "";
				this.txtGiaBanSach.Text = "";
				this.txtNXB.Text = "";
				this.txtTenTG.Text = "";
			}
		}
		private void txtSoLuongT_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void txtGiaNhapGanNhat_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void txtGiaBanSach_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void txtNXB_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void QL_DanhMucSach_KeyUp(object sender, KeyEventArgs e)
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
			this.txtIDSach.Text = this.xulySach.CapIDSach();
			this.txtTenSach.Text = "";
			this.txtSoLuongT.Text = "";
			this.txtGiaNhapGanNhat.Text = "";
			this.txtGiaBanSach.Text = "";
			this.cbxNXB.Text = "";
			this.txtIDNXBS.Text = "";
			this.txtNXB.Text = "";
			this.txtTenTG.Text = "";
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QL_DanhMucSach));
			this.panel1 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.label1 = new Label();
			this.txtSoLuongT = new TextBox();
			this.txtGiaBanSach = new TextBox();
			this.txtIDNXBS = new TextBox();
			this.txtNXB = new TextBox();
			this.txtTenTG = new TextBox();
			this.txtTenSach = new TextBox();
			this.txtIDSach = new TextBox();
			this.txtGiaNhapGanNhat = new TextBox();
			this.label12 = new Label();
			this.cbxNXB = new ComboBox();
			this.label19 = new Label();
			this.label20 = new Label();
			this.label21 = new Label();
			this.label22 = new Label();
			this.label23 = new Label();
			this.label24 = new Label();
			this.label25 = new Label();
			this.label26 = new Label();
			this.label27 = new Label();
			this.dgvSach = new DataGridView();
			this.Column15 = new DataGridViewTextBoxColumn();
			this.Column16 = new DataGridViewTextBoxColumn();
			this.Column17 = new DataGridViewTextBoxColumn();
			this.Column18 = new DataGridViewTextBoxColumn();
			this.Column19 = new DataGridViewTextBoxColumn();
			this.Column20 = new DataGridViewTextBoxColumn();
			this.Column21 = new DataGridViewTextBoxColumn();
			this.Column22 = new DataGridViewTextBoxColumn();
			this.Column23 = new DataGridViewTextBoxColumn();
			this.btnCapID = new VBButton();
			this.btnXoa = new VBButton();
			this.btnSua = new VBButton();
			this.btnthem = new VBButton();
			GroupBox groupBox = new GroupBox();
			groupBox.SuspendLayout();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.dgvSach).BeginInit();
			base.SuspendLayout();
			groupBox.BackColor = Color.Pink;
			groupBox.Controls.Add(this.btnXoa);
			groupBox.Controls.Add(this.btnSua);
			groupBox.Controls.Add(this.btnthem);
			groupBox.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox.Location = new Point(18, 746);
			groupBox.Name = "groupBox6";
			groupBox.Size = new Size(426, 116);
			groupBox.TabIndex = 9;
			groupBox.TabStop = false;
			groupBox.Text = "THAO TÁC";
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.btnCapID);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(groupBox);
			this.panel1.Controls.Add(this.txtSoLuongT);
			this.panel1.Controls.Add(this.txtGiaBanSach);
			this.panel1.Controls.Add(this.txtIDNXBS);
			this.panel1.Controls.Add(this.txtNXB);
			this.panel1.Controls.Add(this.txtTenTG);
			this.panel1.Controls.Add(this.txtTenSach);
			this.panel1.Controls.Add(this.txtIDSach);
			this.panel1.Controls.Add(this.txtGiaNhapGanNhat);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.cbxNXB);
			this.panel1.Controls.Add(this.label19);
			this.panel1.Controls.Add(this.label20);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.label24);
			this.panel1.Controls.Add(this.label25);
			this.panel1.Controls.Add(this.label26);
			this.panel1.Controls.Add(this.label27);
			this.panel1.Controls.Add(this.dgvSach);
			this.panel1.Location = new Point(1, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1479, 1006);
			this.panel1.TabIndex = 0;
			this.panel3.BackColor = Color.Black;
			this.panel3.ForeColor = SystemColors.ControlLightLight;
			this.panel3.Location = new Point(-2, 1000);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(488, 4);
			this.panel3.TabIndex = 104;
			this.panel2.BackColor = Color.Black;
			this.panel2.Location = new Point(-2, 592);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(488, 4);
			this.panel2.TabIndex = 102;
			this.label1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.BackColor = SystemColors.HighlightText;
			this.label1.Font = new Font("Tahoma", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Image = Resources.book_open_shape_icon_icons1;
			this.label1.ImageAlign = ContentAlignment.MiddleLeft;
			this.label1.Location = new Point(883, 45);
			this.label1.Name = "label1";
			this.label1.Size = new Size(355, 33);
			this.label1.TabIndex = 101;
			this.label1.Text = "    Thông tin danh mục  sách";
			this.label1.TextAlign = ContentAlignment.MiddleRight;
			this.txtSoLuongT.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSoLuongT.Location = new Point(176, 209);
			this.txtSoLuongT.Name = "txtSoLuongT";
			this.txtSoLuongT.Size = new Size(268, 30);
			this.txtSoLuongT.TabIndex = 3;
			this.txtSoLuongT.KeyPress += new KeyPressEventHandler(this.txtSoLuongT_KeyPress);
			this.txtGiaBanSach.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiaBanSach.Location = new Point(176, 303);
			this.txtGiaBanSach.Name = "txtGiaBanSach";
			this.txtGiaBanSach.Size = new Size(268, 30);
			this.txtGiaBanSach.TabIndex = 5;
			this.txtGiaBanSach.KeyPress += new KeyPressEventHandler(this.txtGiaBanSach_KeyPress);
			this.txtIDNXBS.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNXBS.Location = new Point(176, 418);
			this.txtIDNXBS.MaxLength = 10;
			this.txtIDNXBS.Name = "txtIDNXBS";
			this.txtIDNXBS.ReadOnly = true;
			this.txtIDNXBS.Size = new Size(267, 30);
			this.txtIDNXBS.TabIndex = 97;
			this.txtIDNXBS.TabStop = false;
			this.txtNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNXB.Location = new Point(175, 494);
			this.txtNXB.MaxLength = 10;
			this.txtNXB.Name = "txtNXB";
			this.txtNXB.Size = new Size(268, 30);
			this.txtNXB.TabIndex = 7;
			this.txtNXB.KeyPress += new KeyPressEventHandler(this.txtNXB_KeyPress);
			this.txtTenTG.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenTG.Location = new Point(176, 556);
			this.txtTenTG.Name = "txtTenTG";
			this.txtTenTG.Size = new Size(268, 30);
			this.txtTenTG.TabIndex = 8;
			this.txtTenSach.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenSach.Location = new Point(176, 155);
			this.txtTenSach.Name = "txtTenSach";
			this.txtTenSach.Size = new Size(268, 30);
			this.txtTenSach.TabIndex = 2;
			this.txtIDSach.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDSach.Location = new Point(176, 110);
			this.txtIDSach.MaxLength = 10;
			this.txtIDSach.Name = "txtIDSach";
			this.txtIDSach.Size = new Size(268, 30);
			this.txtIDSach.TabIndex = 1;
			this.txtGiaNhapGanNhat.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiaNhapGanNhat.Location = new Point(176, 256);
			this.txtGiaNhapGanNhat.Name = "txtGiaNhapGanNhat";
			this.txtGiaNhapGanNhat.Size = new Size(268, 30);
			this.txtGiaNhapGanNhat.TabIndex = 4;
			this.txtGiaNhapGanNhat.KeyPress += new KeyPressEventHandler(this.txtGiaNhapGanNhat_KeyPress);
			this.label12.AutoSize = true;
			this.label12.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label12.Location = new Point(18, 212);
			this.label12.Name = "label12";
			this.label12.Size = new Size(111, 22);
			this.label12.TabIndex = 98;
			this.label12.Text = "Số lượng tồn";
			this.cbxNXB.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxNXB.FormattingEnabled = true;
			this.cbxNXB.Location = new Point(176, 360);
			this.cbxNXB.Name = "cbxNXB";
			this.cbxNXB.Size = new Size(268, 30);
			this.cbxNXB.TabIndex = 6;
			this.cbxNXB.SelectedIndexChanged += new EventHandler(this.cbxNXB_SelectedIndexChanged);
			this.label19.AutoSize = true;
			this.label19.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label19.Location = new Point(14, 559);
			this.label19.Name = "label19";
			this.label19.Size = new Size(97, 22);
			this.label19.TabIndex = 96;
			this.label19.Text = "Tên tác giả";
			this.label20.AutoSize = true;
			this.label20.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label20.Location = new Point(17, 306);
			this.label20.Name = "label20";
			this.label20.Size = new Size(72, 22);
			this.label20.TabIndex = 95;
			this.label20.Text = "Giá bán";
			this.label21.AutoSize = true;
			this.label21.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label21.Location = new Point(18, 494);
			this.label21.Name = "label21";
			this.label21.Size = new Size(117, 22);
			this.label21.TabIndex = 94;
			this.label21.Text = "Năm xuất bản";
			this.label22.AutoSize = true;
			this.label22.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label22.Location = new Point(17, 368);
			this.label22.Name = "label22";
			this.label22.Size = new Size(142, 22);
			this.label22.TabIndex = 93;
			this.label22.Text = "Tên nhà xuất bản";
			this.label23.AutoSize = true;
			this.label23.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label23.Location = new Point(18, 426);
			this.label23.Name = "label23";
			this.label23.Size = new Size(132, 22);
			this.label23.TabIndex = 92;
			this.label23.Text = "ID nhà xuất bản";
			this.label24.AutoSize = true;
			this.label24.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label24.Location = new Point(14, 259);
			this.label24.Name = "label24";
			this.label24.Size = new Size(150, 22);
			this.label24.TabIndex = 91;
			this.label24.Text = "Giá nhập gần nhất";
			this.label25.AutoSize = true;
			this.label25.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label25.Location = new Point(18, 163);
			this.label25.Name = "label25";
			this.label25.Size = new Size(80, 22);
			this.label25.TabIndex = 90;
			this.label25.Text = "Tên sách";
			this.label26.AutoSize = true;
			this.label26.Font = new Font("Times New Roman", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label26.Location = new Point(18, 118);
			this.label26.Name = "label26";
			this.label26.Size = new Size(70, 22);
			this.label26.TabIndex = 89;
			this.label26.Text = "ID sách";
			this.label27.AutoSize = true;
			this.label27.BackColor = SystemColors.HighlightText;
			this.label27.Font = new Font("Tahoma", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label27.Image = Resources.book_open_shape_icon_icons1;
			this.label27.ImageAlign = ContentAlignment.MiddleLeft;
			this.label27.Location = new Point(145, 45);
			this.label27.Name = "label27";
			this.label27.Size = new Size(222, 33);
			this.label27.TabIndex = 88;
			this.label27.Text = "    Thông tin sách";
			this.label27.TextAlign = ContentAlignment.MiddleRight;
			this.dgvSach.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSach.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column15,
				this.Column16,
				this.Column17,
				this.Column18,
				this.Column19,
				this.Column20,
				this.Column21,
				this.Column22,
				this.Column23
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dgvSach.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvSach.Location = new Point(486, 110);
			this.dgvSach.Name = "dgvSach";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvSach.RowTemplate.Height = 50;
			this.dgvSach.Size = new Size(986, 894);
			this.dgvSach.TabIndex = 12;
			this.dgvSach.CellClick += new DataGridViewCellEventHandler(this.dgvSach_CellClick);
			this.Column15.DataPropertyName = "IDSach";
			this.Column15.HeaderText = "ID sách";
			this.Column15.Name = "Column15";
			this.Column15.Width = 86;
			this.Column16.DataPropertyName = "TenSach";
			this.Column16.HeaderText = "Tên sách";
			this.Column16.Name = "Column16";
			this.Column16.Width = 95;
			this.Column17.DataPropertyName = "SoLuongT";
			this.Column17.HeaderText = "Số lượng tồn";
			this.Column17.Name = "Column17";
			this.Column17.Width = 121;
			this.Column18.DataPropertyName = "GiaNhapGanNhat";
			this.Column18.HeaderText = "Giá nhập gần nhất";
			this.Column18.Name = "Column18";
			this.Column18.Width = 126;
			this.Column19.DataPropertyName = "GiaBan";
			this.Column19.HeaderText = "Giá bán";
			this.Column19.Name = "Column19";
			this.Column19.Width = 86;
			this.Column20.DataPropertyName = "TenNXB";
			this.Column20.HeaderText = "Tên nhà xuất bản";
			this.Column20.Name = "Column20";
			this.Column20.Width = 124;
			this.Column21.DataPropertyName = "IDNXB";
			this.Column21.HeaderText = "ID nhà xuất bản";
			this.Column21.Name = "Column21";
			this.Column21.Width = 115;
			this.Column22.DataPropertyName = "NXB";
			this.Column22.HeaderText = "Năm xuất bản";
			this.Column22.Name = "Column22";
			this.Column22.Width = 102;
			this.Column23.DataPropertyName = "TenTG";
			this.Column23.HeaderText = "Tên tác giả";
			this.Column23.Name = "Column23";
			this.Column23.Width = 88;
			this.btnCapID.BackColor = SystemColors.ActiveCaption;
			this.btnCapID.BackgroundColor = SystemColors.ActiveCaption;
			this.btnCapID.BorderColor = SystemColors.ActiveBorder;
			this.btnCapID.BorderRadius = 0;
			this.btnCapID.BorderSize = 0;
			this.btnCapID.FlatAppearance.BorderSize = 0;
			this.btnCapID.FlatStyle = FlatStyle.Flat;
			this.btnCapID.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.btnCapID.ForeColor = SystemColors.ActiveCaptionText;
			this.btnCapID.Location = new Point(364, 109);
			this.btnCapID.Name = "btnCapID";
			this.btnCapID.Size = new Size(80, 30);
			this.btnCapID.TabIndex = 103;
			this.btnCapID.Text = "Cấp ID";
			this.btnCapID.TextColor = SystemColors.ActiveCaptionText;
			this.btnCapID.UseVisualStyleBackColor = false;
			this.btnCapID.Click += new EventHandler(this.btnCapID_Click);
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
			this.btnXoa.Location = new Point(315, 39);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new Size(105, 60);
			this.btnXoa.TabIndex = 11;
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
			this.btnSua.Location = new Point(158, 39);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new Size(105, 60);
			this.btnSua.TabIndex = 10;
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
			this.btnthem.TabIndex = 9;
			this.btnthem.Text = "Thêm";
			this.btnthem.TextAlign = ContentAlignment.MiddleRight;
			this.btnthem.TextColor = Color.Black;
			this.btnthem.UseVisualStyleBackColor = false;
			this.btnthem.Click += new EventHandler(this.btnthem_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1481, 1011);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "QL_DanhMucSach";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ DANH MỤC SÁCH";
			base.Load += new EventHandler(this.QL_DanhMucSach_Load);
			base.KeyUp += new KeyEventHandler(this.QL_DanhMucSach_KeyUp);
			groupBox.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((ISupportInitialize)this.dgvSach).EndInit();
			base.ResumeLayout(false);
		}
	}
}
