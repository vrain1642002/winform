using bansach.Properties;
using CustomButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class NV_BanSach : Form
	{
		private CXuLySach xulySach;
		private CXuLyHoaDon xulyHD;
		private CHoaDon hd;
		private CSach sach;
		private CXuLyLichSuHD xuLyLichSuHD;
		private IContainer components = null;
		private Panel panel1;
		private Panel panel2;
		private DateTimePicker dtpngayLapHD;
		private TextBox txtDiaChiKH;
		private Label label13;
		private TextBox txtSDTKH;
		private Label label5;
		private TextBox txtTenKH;
		private Label label2;
		private TextBox txtThanhToan;
		private Label label8;
		private TextBox txtGiam;
		private Label label4;
		private Label label3;
		private TextBox txtthanhTien;
		private DataGridView dgvTT;
		private Label label27;
		private VBButton btnXoa;
		private VBButton btnSua;
		private VBButton btnthem;
		private VBButton btnlapHD;
		private Label label16;
		private Panel panel3;
		private TextBox txtNamXB;
		private Label label15;
		private Label label14;
		private TextBox txtTenTG;
		private TextBox txtSoLuongT;
		private Label label10;
		private TextBox txtGiaBan;
		private Label label7;
		private Label label1;
		private ComboBox cbxChonSach;
		private Label label12;
		private TextBox txtIDSach;
		private NumericUpDown nubSoLuongB;
		private TextBox txtTenNhaXB;
		private Label label9;
		private Label label11;
		private Panel panel4;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column11;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column12;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn Column10;
		private Panel panel5;
		private Label label17;
		public NV_BanSach()
		{
			this.InitializeComponent();
		}
		private void hienthiComboBoxSach(List<CSach> ds)
		{
			this.cbxChonSach.DisplayMember = "TenSach";
			this.cbxChonSach.ValueMember = "TenSach";
			this.cbxChonSach.DataSource = ds;
		}
		private void cbxChonSach_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			string b = this.cbxChonSach.SelectedValue.ToString();
			foreach (CSach current in this.xulySach.getDSSach())
			{
				bool flag = current.TenSach == b;
				if (flag)
				{
					this.txtIDSach.Text = current.IDSach;
					this.txtTenNhaXB.Text = current.TenNXB;
					this.txtTenTG.Text = current.TenTG;
					this.txtGiaBan.Text = current.GiaBan.ToString();
					this.txtSoLuongT.Text = current.SoLuongT.ToString();
					this.txtNamXB.Text = current.NXB.ToString();
				}
			}
		}
		private void hienthiHoadon(CHoaDon x)
		{
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = CViewHoaDon.chuyenDoi(x);
			this.dgvTT.DataSource = bindingSource;
		}
		private void BanSach_Load(object sender, EventArgs e)
		{
			this.xulySach = new CXuLySach();
			bool flag = !this.xulySach.docFile("DanhMucSach.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DanhMucSach.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiComboBoxSach(this.xulySach.getDSSach());
			}
			this.hd = new CHoaDon();
			this.xulyHD = new CXuLyHoaDon();
			bool flag2 = !this.xulyHD.docFile("DSHoaDon.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSHoaDon.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag3 = !this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag3)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
		}
		private void btnthem_Click_1(object sender, EventArgs e)
		{
			string text = this.txtIDSach.Text;
			bool flag = this.xulySach.tim(text).SoLuongT == 0;
			if (flag)
			{
				MessageBox.Show("Sách này đã hết hàng không thể thêm được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				bool flag2 = this.xulySach.tim(text).GiaBan == 0;
				if (flag2)
				{
					MessageBox.Show("Sách này người quản lý chưa đặt giá bán nên không thể bán được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					bool flag3 = this.hd.ChiTietHoaDon.Count == 0;
					if (flag3)
					{
						CChiTietHoaDon cChiTietHoaDon = new CChiTietHoaDon();
						cChiTietHoaDon.Sach = this.xulySach.tim(text);
						bool flag4 = (int)this.nubSoLuongB.Value > int.Parse(this.txtSoLuongT.Text);
						if (flag4)
						{
							MessageBox.Show("Số lượng bán lớn hơn số lượng tồn nên không thể thêm được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							cChiTietHoaDon.SoLuongB = (int)this.nubSoLuongB.Value;
							this.hd.ChiTietHoaDon.Add(cChiTietHoaDon);
							this.txtthanhTien.Text = this.hd.tinhTien().ToString();
							this.hienthiHoadon(this.hd);
							this.nubSoLuongB.Value = decimal.One;
						}
					}
					else
					{
						foreach (CChiTietHoaDon current in this.hd.ChiTietHoaDon)
						{
							bool flag5 = current.Sach.IDSach == this.txtIDSach.Text;
							if (flag5)
							{
								MessageBox.Show("Sách này đã có rồi không thể thêm được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return;
							}
						}
						CChiTietHoaDon cChiTietHoaDon2 = new CChiTietHoaDon();
						cChiTietHoaDon2.Sach = this.xulySach.tim(text);
						bool flag6 = (int)this.nubSoLuongB.Value > int.Parse(this.txtSoLuongT.Text);
						if (flag6)
						{
							MessageBox.Show("Số lượng bán lớn hơn số lượng tồn nên không thể thêm được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							cChiTietHoaDon2.SoLuongB = (int)this.nubSoLuongB.Value;
							this.hd.ChiTietHoaDon.Add(cChiTietHoaDon2);
							this.txtthanhTien.Text = this.hd.tinhTien().ToString();
							this.hienthiHoadon(this.hd);
							this.nubSoLuongB.Value = decimal.One;
							this.txtGiam.Text = "";
						}
					}
				}
			}
		}
		private void btnSua_Click_1(object sender, EventArgs e)
		{
			int num = 0;
			foreach (CChiTietHoaDon current in this.hd.ChiTietHoaDon)
			{
				bool flag = current.Sach.IDSach == this.txtIDSach.Text;
				if (flag)
				{
					num = 1;
					break;
				}
			}
			bool flag2 = num == 0;
			if (flag2)
			{
				MessageBox.Show("Sách chưa thêm vào hóa đơn nên không thể sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				foreach (CChiTietHoaDon current2 in this.hd.ChiTietHoaDon)
				{
					bool flag3 = current2.Sach.IDSach == this.txtIDSach.Text;
					if (flag3)
					{
						bool flag4 = (int)this.nubSoLuongB.Value > int.Parse(this.txtSoLuongT.Text);
						if (flag4)
						{
							MessageBox.Show("Số lượng bán lớn hơn số lượng tồn nên không thể sửa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						current2.SoLuongB = (int)this.nubSoLuongB.Value;
					}
				}
				this.txtthanhTien.Text = this.hd.tinhTien().ToString();
				this.hienthiHoadon(this.hd);
				this.nubSoLuongB.Value = decimal.One;
				this.txtGiam.Text = "";
			}
		}
		private void btnXoa_Click_1(object sender, EventArgs e)
		{
			int num = 0;
			foreach (CChiTietHoaDon current in this.hd.ChiTietHoaDon)
			{
				bool flag = current.Sach.IDSach == this.txtIDSach.Text;
				if (flag)
				{
					num = 1;
					break;
				}
			}
			bool flag2 = num == 0;
			if (flag2)
			{
				MessageBox.Show("Sách chưa thêm vào hóa đơn nên không thể xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				foreach (CChiTietHoaDon current2 in this.hd.ChiTietHoaDon)
				{
					bool flag3 = current2.Sach.IDSach == this.txtIDSach.Text;
					if (flag3)
					{
						this.hd.ChiTietHoaDon.Remove(current2);
						break;
					}
				}
				this.txtthanhTien.Text = this.hd.tinhTien().ToString();
				this.hienthiHoadon(this.hd);
				this.nubSoLuongB.Value = decimal.One;
				this.txtGiam.Text = "";
			}
		}
		private void dgvTT_RowEnter_1(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.hd.ChiTietHoaDon.Count > 0;
			if (flag)
			{
				bool flag2 = this.dgvTT.Rows[e.RowIndex].Cells[0].Value == null;
				if (flag2)
				{
					MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this.txtIDSach.Text = this.dgvTT.Rows[e.RowIndex].Cells[0].Value.ToString();
					foreach (CChiTietHoaDon current in this.hd.ChiTietHoaDon)
					{
						bool flag3 = current.Sach.IDSach == this.txtIDSach.Text;
						if (flag3)
						{
							this.cbxChonSach.Text = current.Sach.TenSach;
							this.txtTenNhaXB.Text = current.Sach.TenNXB;
							this.txtTenTG.Text = current.Sach.TenTG;
							this.txtGiaBan.Text = current.Sach.GiaBan.ToString();
							this.txtSoLuongT.Text = current.Sach.SoLuongT.ToString();
							this.nubSoLuongB.Value = current.SoLuongB;
						}
					}
				}
			}
		}
		private void txtGiam_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void btnlapHD_Click(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show("Bạn có chắc với quyết định của mình không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
			if (!flag)
			{
				bool flag2 = this.hd.ChiTietHoaDon.Count == 0;
				if (flag2)
				{
					MessageBox.Show("Hóa đơn chưa có sách nào nên không thể lập hóa đơn được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					bool flag3 = this.txtGiam.Text == "" || this.txtThanhToan.Text == "" || this.txtTenKH.Text == "" || this.txtSDTKH.Text == "" || this.txtDiaChiKH.Text == "";
					if (flag3)
					{
						MessageBox.Show("Điền thông tin hóa đơn chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						this.hd.ThanhTien = int.Parse(this.txtthanhTien.Text);
						bool flag4 = !this.xulyHD.toanSo(this.txtGiam.Text) || int.Parse(this.txtGiam.Text) < 0;
						if (flag4)
						{
							MessageBox.Show("Số tiền giảm sai định dạng phải toàn là số và >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							this.hd.Giam = int.Parse(this.txtGiam.Text);
							this.hd.ThanhToan = int.Parse(this.txtThanhToan.Text);
							bool flag5 = this.xulyHD.coSo(this.txtTenKH.Text);
							if (flag5)
							{
								MessageBox.Show("Tên khách hàng sai định dạng,tên khách hàng không bao gồm kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								this.hd.TenKH = this.txtTenKH.Text;
								bool flag6 = this.txtSDTKH.Text.Length != 10 || !this.xulyHD.toanSo(this.txtSDTKH.Text);
								if (flag6)
								{
									MessageBox.Show("Số điện thoại không đúng định dạng.SDT phải là một chuỗi có 10 kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									this.hd.SDTKH = this.txtSDTKH.Text;
									bool flag7 = this.xulyHD.toanSo(this.txtDiaChiKH.Text);
									if (flag7)
									{
										MessageBox.Show("Địa chỉ không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										this.hd.DiaChiKH = this.txtDiaChiKH.Text;
										this.hd.NgayTaoHD = this.dtpngayLapHD.Value;
										this.hd.IDHoaDon = (this.xulyHD.getDSHoaDon().Count + 1).ToString();
										this.hd.IDNguoiTao = CConst.Nhanvien.IDNV;
										this.hd.TenNguoiTao = CConst.Nhanvien.TenNV;
										this.hd.SDTNguoiTao = CConst.Nhanvien.SDTNV;
										foreach (CChiTietHoaDon current in this.hd.ChiTietHoaDon)
										{
											this.sach = new CSach(current.Sach);
											this.sach.SoLuongT = this.xulySach.tim(this.sach.IDSach).SoLuongT - current.SoLuongB;
											this.xulySach.sua(this.sach);
										}
										this.xulySach.ghiFile("DanhMucSach.dat");
										this.hienthiComboBoxSach(this.xulySach.getDSSach());
										this.xulyHD.them(this.hd);
										this.xulyHD.ghiFile("DSHoaDon.dat");
										MessageBox.Show("Đã tạo hóa đơn thành công mã hóa đơn vừa tạo là: " + this.hd.IDHoaDon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										CLichSuHD cLichSuHD = new CLichSuHD();
										cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
										cLichSuHD.NHoatDong = DateTime.Now;
										cLichSuHD.IDND = CConst.Nhanvien.IDNV;
										cLichSuHD.TenND = CConst.Nhanvien.TenNV;
										cLichSuHD.HoatDong = "Tạo hóa đơn";
										cLichSuHD.IDDoiTuong = this.hd.IDHoaDon;
										cLichSuHD.DoiTuong = "Hóa đơn";
										cLichSuHD.NoiDung = "Tạo hóa đơn mới với ID hóa đơn= " + this.hd.IDHoaDon;
										this.xuLyLichSuHD.them(cLichSuHD);
										this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
										this.hd = new CHoaDon();
										this.hienthiHoadon(this.hd);
										this.txtthanhTien.Text = "";
										this.txtGiam.Text = "";
										this.txtThanhToan.Text = "";
										this.txtTenKH.Text = "";
										this.txtSDTKH.Text = "";
										this.txtDiaChiKH.Text = "";
										this.txtDiaChiKH.Text = "";
										this.dtpngayLapHD.Value = DateTime.Now;
									}
								}
							}
						}
					}
				}
			}
		}
		private void txtGiam_TextChanged_1(object sender, EventArgs e)
		{
			bool flag = this.txtGiam.Text != "" && this.xulyHD.toanSo(this.txtGiam.Text) && this.txtthanhTien.Text != "";
			if (flag)
			{
				bool flag2 = int.Parse(this.txtGiam.Text) > 1000000;
				if (flag2)
				{
					MessageBox.Show("Chỉ được giảm tối đa 1 triệu trên mỗi hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtGiam.Text = "0";
				}
				else
				{
					bool flag3 = int.Parse(this.txtGiam.Text) > int.Parse(this.txtthanhTien.Text);
					if (flag3)
					{
						this.txtThanhToan.Text = "0";
					}
					else
					{
						this.txtThanhToan.Text = (int.Parse(this.txtthanhTien.Text) - int.Parse(this.txtGiam.Text)).ToString();
					}
				}
			}
		}
		private void BanSach_KeyUp(object sender, KeyEventArgs e)
		{
			bool control = e.Control;
			if (control)
			{
				bool flag = e.KeyCode.Equals(Keys.Alt);
				if (flag)
				{
					base.Close();
				}
			}
		}
		private void BanSach_FormClosed(object sender, FormClosedEventArgs e)
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
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NV_BanSach));
			this.btnXoa = new VBButton();
			this.btnSua = new VBButton();
			this.btnthem = new VBButton();
			this.panel1 = new Panel();
			this.panel5 = new Panel();
			this.label17 = new Label();
			this.txtthanhTien = new TextBox();
			this.label16 = new Label();
			this.panel2 = new Panel();
			this.btnlapHD = new VBButton();
			this.dtpngayLapHD = new DateTimePicker();
			this.txtDiaChiKH = new TextBox();
			this.label13 = new Label();
			this.txtSDTKH = new TextBox();
			this.label5 = new Label();
			this.txtTenKH = new TextBox();
			this.label2 = new Label();
			this.txtThanhToan = new TextBox();
			this.label8 = new Label();
			this.txtGiam = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.panel3 = new Panel();
			this.txtNamXB = new TextBox();
			this.label15 = new Label();
			this.label14 = new Label();
			this.txtTenTG = new TextBox();
			this.txtSoLuongT = new TextBox();
			this.label10 = new Label();
			this.txtGiaBan = new TextBox();
			this.label7 = new Label();
			this.label1 = new Label();
			this.cbxChonSach = new ComboBox();
			this.label12 = new Label();
			this.txtIDSach = new TextBox();
			this.nubSoLuongB = new NumericUpDown();
			this.txtTenNhaXB = new TextBox();
			this.label9 = new Label();
			this.label11 = new Label();
			this.dgvTT = new DataGridView();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column12 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column10 = new DataGridViewTextBoxColumn();
			this.label27 = new Label();
			this.panel4 = new Panel();
			GroupBox groupBox = new GroupBox();
			groupBox.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((ISupportInitialize)this.nubSoLuongB).BeginInit();
			((ISupportInitialize)this.dgvTT).BeginInit();
			base.SuspendLayout();
			groupBox.BackColor = Color.Pink;
			groupBox.Controls.Add(this.btnXoa);
			groupBox.Controls.Add(this.btnSua);
			groupBox.Controls.Add(this.btnthem);
			groupBox.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox.Location = new Point(359, 402);
			groupBox.Name = "groupBox6";
			groupBox.Size = new Size(434, 95);
			groupBox.TabIndex = 3;
			groupBox.TabStop = false;
			groupBox.Text = "THAO TÁC";
			this.btnXoa.BackColor = Color.Red;
			this.btnXoa.BackgroundColor = Color.Red;
			this.btnXoa.BorderColor = Color.Transparent;
			this.btnXoa.BorderRadius = 5;
			this.btnXoa.BorderSize = 0;
			this.btnXoa.FlatAppearance.BorderSize = 0;
			this.btnXoa.FlatStyle = FlatStyle.Flat;
			this.btnXoa.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXoa.ForeColor = Color.WhiteSmoke;
			this.btnXoa.Image = Resources.add_circle_create_expand_new_plus_icon_1232181;
			this.btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnXoa.Location = new Point(323, 28);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new Size(105, 60);
			this.btnXoa.TabIndex = 5;
			this.btnXoa.Text = "  Xóa";
			this.btnXoa.TextColor = Color.WhiteSmoke;
			this.btnXoa.UseVisualStyleBackColor = false;
			this.btnXoa.Click += new EventHandler(this.btnXoa_Click_1);
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
			this.btnSua.Location = new Point(166, 28);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new Size(105, 60);
			this.btnSua.TabIndex = 4;
			this.btnSua.Text = "  Sửa";
			this.btnSua.TextColor = Color.Black;
			this.btnSua.UseVisualStyleBackColor = false;
			this.btnSua.Click += new EventHandler(this.btnSua_Click_1);
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
			this.btnthem.Location = new Point(6, 29);
			this.btnthem.Name = "btnthem";
			this.btnthem.Size = new Size(105, 60);
			this.btnthem.TabIndex = 3;
			this.btnthem.Text = "Thêm";
			this.btnthem.TextAlign = ContentAlignment.MiddleRight;
			this.btnthem.TextColor = Color.Black;
			this.btnthem.UseVisualStyleBackColor = false;
			this.btnthem.Click += new EventHandler(this.btnthem_Click_1);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(groupBox);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.dgvTT);
			this.panel1.Controls.Add(this.label27);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Location = new Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1470, 1007);
			this.panel1.TabIndex = 0;
			this.panel5.BackColor = SystemColors.ButtonHighlight;
			this.panel5.Controls.Add(this.label17);
			this.panel5.Controls.Add(this.txtthanhTien);
			this.panel5.Location = new Point(310, 961);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(281, 39);
			this.panel5.TabIndex = 169;
			this.label17.AutoSize = true;
			this.label17.BackColor = Color.Transparent;
			this.label17.Font = new Font("Times New Roman", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label17.ForeColor = Color.Black;
			this.label17.Location = new Point(3, 9);
			this.label17.Name = "label17";
			this.label17.Size = new Size(119, 22);
			this.label17.TabIndex = 167;
			this.label17.Text = "TỔNG TIỀN";
			this.txtthanhTien.BackColor = Color.White;
			this.txtthanhTien.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtthanhTien.Location = new Point(128, 5);
			this.txtthanhTien.Name = "txtthanhTien";
			this.txtthanhTien.ReadOnly = true;
			this.txtthanhTien.Size = new Size(150, 29);
			this.txtthanhTien.TabIndex = 117;
			this.txtthanhTien.TabStop = false;
			this.txtthanhTien.WordWrap = false;
			this.label16.AutoSize = true;
			this.label16.BackColor = Color.Transparent;
			this.label16.Font = new Font("Times New Roman", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label16.ForeColor = SystemColors.Desktop;
			this.label16.Location = new Point(26, 469);
			this.label16.Name = "label16";
			this.label16.Size = new Size(230, 31);
			this.label16.TabIndex = 12;
			this.label16.Text = "Thông tin hóa đơn";
			this.panel2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel2.BackColor = SystemColors.GradientActiveCaption;
			this.panel2.Controls.Add(this.btnlapHD);
			this.panel2.Controls.Add(this.dtpngayLapHD);
			this.panel2.Controls.Add(this.txtDiaChiKH);
			this.panel2.Controls.Add(this.label13);
			this.panel2.Controls.Add(this.txtSDTKH);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.txtTenKH);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.txtThanhToan);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.txtGiam);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new Point(789, -6);
			this.panel2.Margin = new Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(676, 393);
			this.panel2.TabIndex = 7;
			this.btnlapHD.BackColor = Color.Yellow;
			this.btnlapHD.BackgroundColor = Color.Yellow;
			this.btnlapHD.BorderColor = Color.PaleVioletRed;
			this.btnlapHD.BorderRadius = 5;
			this.btnlapHD.BorderSize = 0;
			this.btnlapHD.FlatAppearance.BorderSize = 0;
			this.btnlapHD.FlatStyle = FlatStyle.Flat;
			this.btnlapHD.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnlapHD.ForeColor = Color.Black;
			this.btnlapHD.Image = Resources.ecommerce_receipt_dollar_399212;
			this.btnlapHD.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnlapHD.Location = new Point(337, 311);
			this.btnlapHD.Name = "btnlapHD";
			this.btnlapHD.Size = new Size(162, 75);
			this.btnlapHD.TabIndex = 12;
			this.btnlapHD.Text = "    Lập hóa đơn";
			this.btnlapHD.TextColor = Color.Black;
			this.btnlapHD.UseVisualStyleBackColor = false;
			this.btnlapHD.Click += new EventHandler(this.btnlapHD_Click);
			this.dtpngayLapHD.CustomFormat = "dd/MM/yyyy hh:mm:ss";
			this.dtpngayLapHD.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpngayLapHD.Format = DateTimePickerFormat.Custom;
			this.dtpngayLapHD.Location = new Point(308, 262);
			this.dtpngayLapHD.Name = "dtpngayLapHD";
			this.dtpngayLapHD.Size = new Size(224, 29);
			this.dtpngayLapHD.TabIndex = 11;
			this.txtDiaChiKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDiaChiKH.Location = new Point(308, 219);
			this.txtDiaChiKH.Name = "txtDiaChiKH";
			this.txtDiaChiKH.Size = new Size(226, 29);
			this.txtDiaChiKH.TabIndex = 10;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label13.ForeColor = Color.Black;
			this.label13.Location = new Point(153, 219);
			this.label13.Name = "label13";
			this.label13.Size = new Size(100, 21);
			this.label13.TabIndex = 109;
			this.label13.Text = "Địa Chỉ KH";
			this.txtSDTKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTKH.Location = new Point(308, 170);
			this.txtSDTKH.MaxLength = 10;
			this.txtSDTKH.Name = "txtSDTKH";
			this.txtSDTKH.Size = new Size(226, 29);
			this.txtSDTKH.TabIndex = 9;
			this.txtSDTKH.KeyPress += new KeyPressEventHandler(this.txtSDTKH_KeyPress);
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.ForeColor = Color.Black;
			this.label5.Location = new Point(155, 178);
			this.label5.Name = "label5";
			this.label5.Size = new Size(78, 21);
			this.label5.TabIndex = 107;
			this.label5.Text = "SĐT KH";
			this.txtTenKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenKH.Location = new Point(308, 117);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.Size = new Size(226, 29);
			this.txtTenKH.TabIndex = 8;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.ForeColor = Color.Black;
			this.label2.Location = new Point(155, 120);
			this.label2.Name = "label2";
			this.label2.Size = new Size(128, 21);
			this.label2.TabIndex = 105;
			this.label2.Text = "Tên khách hàng";
			this.txtThanhToan.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtThanhToan.Location = new Point(306, 66);
			this.txtThanhToan.Name = "txtThanhToan";
			this.txtThanhToan.ReadOnly = true;
			this.txtThanhToan.Size = new Size(226, 29);
			this.txtThanhToan.TabIndex = 104;
			this.txtThanhToan.TabStop = false;
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label8.ForeColor = Color.Black;
			this.label8.Location = new Point(155, 268);
			this.label8.Name = "label8";
			this.label8.Size = new Size(142, 21);
			this.label8.TabIndex = 99;
			this.label8.Text = "Ngày lập hóa đơn";
			this.txtGiam.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiam.Location = new Point(306, 25);
			this.txtGiam.Name = "txtGiam";
			this.txtGiam.Size = new Size(228, 29);
			this.txtGiam.TabIndex = 7;
			this.txtGiam.TextChanged += new EventHandler(this.txtGiam_TextChanged_1);
			this.txtGiam.KeyPress += new KeyPressEventHandler(this.txtGiam_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Black;
			this.label4.Location = new Point(159, 74);
			this.label4.Name = "label4";
			this.label4.Size = new Size(94, 21);
			this.label4.TabIndex = 102;
			this.label4.Text = "Thanh toán";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Black;
			this.label3.Location = new Point(159, 22);
			this.label3.Name = "label3";
			this.label3.Size = new Size(102, 21);
			this.label3.TabIndex = 101;
			this.label3.Text = "Số tiền giảm";
			this.panel3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel3.BackColor = SystemColors.InactiveBorder;
			this.panel3.Controls.Add(this.txtNamXB);
			this.panel3.Controls.Add(this.label15);
			this.panel3.Controls.Add(this.label14);
			this.panel3.Controls.Add(this.txtTenTG);
			this.panel3.Controls.Add(this.txtSoLuongT);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.txtGiaBan);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.cbxChonSach);
			this.panel3.Controls.Add(this.label12);
			this.panel3.Controls.Add(this.txtIDSach);
			this.panel3.Controls.Add(this.nubSoLuongB);
			this.panel3.Controls.Add(this.txtTenNhaXB);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Location = new Point(-1, -6);
			this.panel3.Margin = new Padding(2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(794, 393);
			this.panel3.TabIndex = 1;
			this.txtNamXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNamXB.Location = new Point(207, 198);
			this.txtNamXB.Name = "txtNamXB";
			this.txtNamXB.ReadOnly = true;
			this.txtNamXB.Size = new Size(226, 29);
			this.txtNamXB.TabIndex = 103;
			this.txtNamXB.TabStop = false;
			this.label15.AutoSize = true;
			this.label15.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label15.Location = new Point(29, 206);
			this.label15.Name = "label15";
			this.label15.Size = new Size(113, 21);
			this.label15.TabIndex = 102;
			this.label15.Text = "Năm xuất bản";
			this.label14.AutoSize = true;
			this.label14.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label14.Location = new Point(29, 158);
			this.label14.Name = "label14";
			this.label14.Size = new Size(104, 21);
			this.label14.TabIndex = 101;
			this.label14.Text = "Tên Tác Giả";
			this.txtTenTG.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenTG.Location = new Point(207, 158);
			this.txtTenTG.Name = "txtTenTG";
			this.txtTenTG.ReadOnly = true;
			this.txtTenTG.Size = new Size(226, 29);
			this.txtTenTG.TabIndex = 100;
			this.txtTenTG.TabStop = false;
			this.txtSoLuongT.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSoLuongT.Location = new Point(207, 297);
			this.txtSoLuongT.Name = "txtSoLuongT";
			this.txtSoLuongT.ReadOnly = true;
			this.txtSoLuongT.Size = new Size(105, 29);
			this.txtSoLuongT.TabIndex = 99;
			this.txtSoLuongT.TabStop = false;
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label10.Location = new Point(29, 114);
			this.label10.Name = "label10";
			this.label10.Size = new Size(138, 21);
			this.label10.TabIndex = 98;
			this.label10.Text = "Tên nhà xuất bản";
			this.txtGiaBan.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiaBan.Location = new Point(207, 246);
			this.txtGiaBan.Name = "txtGiaBan";
			this.txtGiaBan.ReadOnly = true;
			this.txtGiaBan.Size = new Size(226, 29);
			this.txtGiaBan.TabIndex = 97;
			this.txtGiaBan.TabStop = false;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(32, 297);
			this.label7.Name = "label7";
			this.label7.Size = new Size(107, 21);
			this.label7.TabIndex = 96;
			this.label7.Text = "Số lượng tồn";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(29, 28);
			this.label1.Name = "label1";
			this.label1.Size = new Size(90, 21);
			this.label1.TabIndex = 78;
			this.label1.Text = "Chọn sách";
			this.cbxChonSach.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxChonSach.FormattingEnabled = true;
			this.cbxChonSach.Location = new Point(207, 19);
			this.cbxChonSach.Name = "cbxChonSach";
			this.cbxChonSach.Size = new Size(226, 29);
			this.cbxChonSach.TabIndex = 1;
			this.cbxChonSach.SelectedIndexChanged += new EventHandler(this.cbxChonSach_SelectedIndexChanged_1);
			this.label12.AutoSize = true;
			this.label12.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label12.Location = new Point(29, 348);
			this.label12.Name = "label12";
			this.label12.Size = new Size(110, 21);
			this.label12.TabIndex = 95;
			this.label12.Text = "Số lượng bán";
			this.txtIDSach.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDSach.Location = new Point(207, 63);
			this.txtIDSach.Name = "txtIDSach";
			this.txtIDSach.ReadOnly = true;
			this.txtIDSach.Size = new Size(226, 29);
			this.txtIDSach.TabIndex = 2;
			this.txtIDSach.TabStop = false;
			this.nubSoLuongB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.nubSoLuongB.Location = new Point(207, 340);
			this.nubSoLuongB.Margin = new Padding(2);
			NumericUpDown arg_1D91_0 = this.nubSoLuongB;
			int[] expr_1D84 = new int[4];
			expr_1D84[0] = 1000000;
			arg_1D91_0.Maximum = new decimal(expr_1D84);
			NumericUpDown arg_1DAC_0 = this.nubSoLuongB;
			int[] expr_1DA3 = new int[4];
			expr_1DA3[0] = 1;
			arg_1DAC_0.Minimum = new decimal(expr_1DA3);
			this.nubSoLuongB.Name = "nubSoLuongB";
			this.nubSoLuongB.Size = new Size(97, 29);
			this.nubSoLuongB.TabIndex = 2;
			NumericUpDown arg_1DFA_0 = this.nubSoLuongB;
			int[] expr_1DF1 = new int[4];
			expr_1DF1[0] = 1;
			arg_1DFA_0.Value = new decimal(expr_1DF1);
			this.txtTenNhaXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenNhaXB.Location = new Point(207, 106);
			this.txtTenNhaXB.Name = "txtTenNhaXB";
			this.txtTenNhaXB.ReadOnly = true;
			this.txtTenNhaXB.Size = new Size(226, 29);
			this.txtTenNhaXB.TabIndex = 2;
			this.txtTenNhaXB.TabStop = false;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(29, 69);
			this.label9.Name = "label9";
			this.label9.Size = new Size(71, 21);
			this.label9.TabIndex = 34;
			this.label9.Text = "ID Sách";
			this.label11.AutoSize = true;
			this.label11.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label11.Location = new Point(32, 250);
			this.label11.Name = "label11";
			this.label11.Size = new Size(70, 21);
			this.label11.TabIndex = 26;
			this.label11.Text = "Giá Bán";
			this.dgvTT.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvTT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvTT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvTT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvTT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTT.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column2,
				this.Column3,
				this.Column4,
				this.Column11,
				this.Column1,
				this.Column12,
				this.Column5,
				this.Column10
			});
			this.dgvTT.Cursor = Cursors.Default;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dgvTT.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvTT.Location = new Point(0, 502);
			this.dgvTT.Margin = new Padding(2);
			this.dgvTT.Name = "dgvTT";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvTT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvTT.RowHeadersWidth = 62;
			this.dgvTT.RowTemplate.Height = 50;
			this.dgvTT.Size = new Size(1468, 507);
			this.dgvTT.TabIndex = 6;
			this.dgvTT.RowEnter += new DataGridViewCellEventHandler(this.dgvTT_RowEnter_1);
			this.Column2.DataPropertyName = "TenSach";
			dataGridViewCellStyle4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
			this.Column2.FillWeight = 200f;
			this.Column2.HeaderText = "Tên Sách";
			this.Column2.Name = "Column2";
			this.Column2.Width = 97;
			this.Column3.DataPropertyName = "GiaBan";
			dataGridViewCellStyle5.NullValue = null;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column3.HeaderText = "Giá Bán";
			this.Column3.Name = "Column3";
			this.Column3.Width = 88;
			this.Column4.DataPropertyName = "SoLuongB";
			this.Column4.HeaderText = "Số Lượng bán";
			this.Column4.Name = "Column4";
			this.Column4.Width = 130;
			this.Column11.DataPropertyName = "ThanhTien";
			dataGridViewCellStyle6.Format = "#,###";
			dataGridViewCellStyle6.NullValue = null;
			this.Column11.DefaultCellStyle = dataGridViewCellStyle6;
			this.Column11.HeaderText = "Thành tiền";
			this.Column11.Name = "Column11";
			this.Column11.Width = 104;
			this.Column1.DataPropertyName = "IDSach";
			this.Column1.HeaderText = "ID Sách";
			this.Column1.Name = "Column1";
			this.Column1.Width = 88;
			this.Column12.DataPropertyName = "IDHD";
			this.Column12.HeaderText = "ID hóa đơn";
			this.Column12.Name = "Column12";
			this.Column12.Visible = false;
			this.Column12.Width = 120;
			this.Column5.DataPropertyName = "TenTG";
			this.Column5.HeaderText = "Tên tác giả";
			this.Column5.Name = "Column5";
			this.Column5.Width = 88;
			this.Column10.DataPropertyName = "TenNXB";
			this.Column10.HeaderText = "Tên nhà xuất bản";
			this.Column10.Name = "Column10";
			this.Column10.Width = 124;
			this.label27.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.label27.AutoSize = true;
			this.label27.Font = new Font("Microsoft Sans Serif", 25f);
			this.label27.Location = new Point(548, 557);
			this.label27.Name = "label27";
			this.label27.Size = new Size(0, 39);
			this.label27.TabIndex = 115;
			this.panel4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel4.BackColor = Color.Black;
			this.panel4.Location = new Point(-2, 386);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(1469, 4);
			this.panel4.TabIndex = 3;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			base.ClientSize = new Size(1474, 1011);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "NV_BanSach";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "BÁN SÁCH";
			base.FormClosed += new FormClosedEventHandler(this.BanSach_FormClosed);
			base.Load += new EventHandler(this.BanSach_Load);
			base.KeyUp += new KeyEventHandler(this.BanSach_KeyUp);
			groupBox.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((ISupportInitialize)this.nubSoLuongB).EndInit();
			((ISupportInitialize)this.dgvTT).EndInit();
			base.ResumeLayout(false);
		}
	}
}
