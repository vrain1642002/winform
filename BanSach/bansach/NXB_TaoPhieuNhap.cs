using bansach.Properties;
using CustomButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class NXB_TaoPhieuNhap : Form
	{
		private CXuLySach xulySach;
		private CXuLyPhieuNhap xulyPhieuNhap;
		private CXuLyNXB xulyNXB;
		private List<CSach> dsSNXB;
		private CPhieuNhap pn;
		private CSach Sach;
		private IContainer components = null;
		private Label label11;
		private Label label9;
		private TextBox txtIDSach;
		private Label label12;
		private Label label10;
		private TextBox txtGiaNhap;
		private ComboBox cbxChonSach;
		private Label lblchon;
		private TextBox txtTenNhaXB;
		private Label label5;
		private Label label14;
		private TextBox txtGiaNhapGN;
		private Label label7;
		private TextBox txtSoLuongT;
		private TextBox txtNXB;
		private Label label13;
		private Label lblTenSach;
		private TextBox txtTenSach;
		private NumericUpDown nubSoLuongN;
		private Panel panel1;
		private Panel panel2;
		private TextBox txtThanhToan;
		private Label label8;
		private DateTimePicker dtpNLPN;
		private TextBox txtNXBGiam;
		private Label label4;
		private Label label3;
		private TextBox txtthanhTien;
		private Label label6;
		private Panel panel3;
		private DataGridView dgvPN;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column7;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column11;
		private DataGridViewTextBoxColumn Column12;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn Column10;
		private DataGridViewTextBoxColumn Column8;
		private Panel panel4;
		private CheckBox chkThemSach;
		private TextBox txtTenTG;
		private VBButton btnthem;
		private VBButton btnXoa;
		private VBButton btnsua;
		private VBButton btnlapPN;
		private Label label1;
		private Panel panel5;
		public NXB_TaoPhieuNhap()
		{
			this.InitializeComponent();
		}
		private void hienthiComboBoxSach(List<CSach> ds)
		{
			this.dsSNXB = new List<CSach>();
			foreach (CSach current in ds)
			{
				bool flag = current.IDNXB == CConst.NhaXuatBan.IDNXB;
				if (flag)
				{
					this.dsSNXB.Add(current);
				}
			}
			this.cbxChonSach.DisplayMember = "TenSach";
			this.cbxChonSach.ValueMember = "TenSach";
			this.cbxChonSach.DataSource = this.dsSNXB;
		}
		private void TaoPN_Load(object sender, EventArgs e)
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
			this.pn = new CPhieuNhap();
			this.xulyPhieuNhap = new CXuLyPhieuNhap();
			bool flag2 = !this.xulyPhieuNhap.docFile("DSPhieuNhap.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSPhieuNhap.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.xulyNXB = new CXuLyNXB();
			bool flag3 = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag3)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
		}
		private void cbxChonSach_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.cbxChonSach.SelectedValue != null;
			if (flag)
			{
				string b = this.cbxChonSach.SelectedValue.ToString();
				foreach (CSach current in this.xulySach.getDSSach())
				{
					bool flag2 = current.TenSach == b;
					if (flag2)
					{
						this.txtIDSach.Text = current.IDSach;
						this.txtTenNhaXB.Text = current.TenNXB;
						this.txtTenTG.Text = current.TenTG;
						this.txtNXB.Text = current.NXB.ToString();
						this.txtSoLuongT.Text = current.SoLuongT.ToString();
						this.txtGiaNhapGN.Text = current.GiaNhapGanNhat.ToString();
					}
				}
			}
		}
		private void hienthiPhieuNhap(CPhieuNhap x)
		{
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = CViewPhieuNhap.chuyenDoi(x);
			this.dgvPN.DataSource = bindingSource;
		}
		private void txtNXBGiam_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.txtNXBGiam.Text != "" && this.xulyPhieuNhap.toanSo(this.txtNXBGiam.Text) && this.txtthanhTien.Text != "";
			if (flag)
			{
				bool flag2 = int.Parse(this.txtNXBGiam.Text) > 1000000;
				if (flag2)
				{
					MessageBox.Show("Chỉ được giảm tối đa 1 triệu trên mỗi phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtNXBGiam.Text = "0";
				}
				else
				{
					bool flag3 = int.Parse(this.txtNXBGiam.Text) > int.Parse(this.txtthanhTien.Text);
					if (flag3)
					{
						this.txtThanhToan.Text = "0";
					}
					else
					{
						this.txtThanhToan.Text = (int.Parse(this.txtthanhTien.Text) - int.Parse(this.txtNXBGiam.Text)).ToString();
					}
				}
			}
		}
		private void chkThemSach_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkThemSach.Checked;
			if (@checked)
			{
				this.lblchon.Visible = false;
				this.cbxChonSach.Visible = false;
				this.lblTenSach.Visible = true;
				this.txtTenSach.Visible = true;
				this.txtTenTG.ReadOnly = false;
				this.txtNXB.ReadOnly = false;
				this.txtSoLuongT.Text = 0.ToString();
				this.txtGiaNhapGN.Text = 0.ToString();
				this.txtTenTG.Text = "";
				this.txtNXB.Text = "";
				this.txtIDSach.Text = "T" + (this.pn.ChiTietPhieuNhap.Count + 1).ToString();
				this.txtSoLuongT.Text = "0";
				this.txtGiaNhapGN.Text = "0";
				this.nubSoLuongN.Value = decimal.One;
				this.txtGiaNhap.Text = "";
			}
			else
			{
				this.lblchon.Visible = true;
				this.cbxChonSach.Visible = true;
				this.lblTenSach.Visible = false;
				this.txtTenSach.Visible = false;
				this.txtTenTG.ReadOnly = true;
				this.txtNXB.ReadOnly = true;
				this.cbxChonSach_SelectedIndexChanged(sender, e);
				this.nubSoLuongN.Value = decimal.One;
				this.txtGiaNhap.Text = "";
			}
		}
		private void dgvPN_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.pn.ChiTietPhieuNhap.Count > 0;
			if (flag)
			{
				bool flag2 = this.dgvPN.Rows[e.RowIndex].Cells[0].Value == null;
				if (flag2)
				{
					MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this.txtIDSach.Text = this.dgvPN.Rows[e.RowIndex].Cells[0].Value.ToString();
					foreach (CChiTietPhieuNhap current in this.pn.ChiTietPhieuNhap)
					{
						bool flag3 = current.Sach.IDSach == this.txtIDSach.Text && !this.txtIDSach.Text.StartsWith("T");
						if (flag3)
						{
							this.chkThemSach.Checked = false;
							this.cbxChonSach.Text = current.Sach.TenSach;
							this.txtTenNhaXB.Text = current.Sach.TenNXB;
							this.txtTenTG.Text = current.Sach.TenTG;
							this.txtNXB.Text = current.Sach.NXB.ToString();
							this.txtSoLuongT.Text = current.Sach.SoLuongT.ToString();
							this.txtGiaNhapGN.Text = current.Sach.GiaNhapGanNhat.ToString();
							this.nubSoLuongN.Value = current.SoLuongN;
							this.txtGiaNhap.Text = current.GiaNhap.ToString();
						}
						else
						{
							bool flag4 = current.Sach.IDSach == this.txtIDSach.Text && this.txtIDSach.Text.StartsWith("T");
							if (flag4)
							{
								this.chkThemSach.Checked = true;
								this.txtTenSach.Text = current.Sach.TenSach.ToString();
								this.txtTenNhaXB.Text = current.Sach.TenNXB;
								this.txtTenTG.Text = current.Sach.TenTG;
								this.txtNXB.Text = current.Sach.NXB.ToString();
								this.txtSoLuongT.Text = current.Sach.SoLuongT.ToString();
								this.txtGiaNhapGN.Text = current.Sach.GiaNhapGanNhat.ToString();
								this.nubSoLuongN.Value = current.SoLuongN;
								this.txtGiaNhap.Text = current.GiaNhap.ToString();
							}
						}
					}
				}
			}
		}
		private void btnthem_Click(object sender, EventArgs e)
		{
			string text = this.txtIDSach.Text;
			bool flag = !this.chkThemSach.Checked;
			if (flag)
			{
				bool flag2 = this.txtGiaNhap.Text == "";
				if (flag2)
				{
					MessageBox.Show("Bạn chưa nhập giá nhập của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					bool flag3 = this.pn.ChiTietPhieuNhap.Count == 0;
					if (flag3)
					{
						CChiTietPhieuNhap cChiTietPhieuNhap = new CChiTietPhieuNhap();
						cChiTietPhieuNhap.Sach = this.xulySach.tim(text);
						cChiTietPhieuNhap.SoLuongN = (int)this.nubSoLuongN.Value;
						bool flag4 = !this.xulyPhieuNhap.toanSo(this.txtGiaNhap.Text) || long.Parse(this.txtGiaNhap.Text) <= 0L;
						if (flag4)
						{
							MessageBox.Show("Giá nhập phải toàn là kí tự số và lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							cChiTietPhieuNhap.GiaNhap = int.Parse(this.txtGiaNhap.Text);
							this.pn.ChiTietPhieuNhap.Add(cChiTietPhieuNhap);
							this.txtthanhTien.Text = this.pn.tinhTienNhap().ToString();
							this.hienthiPhieuNhap(this.pn);
							this.nubSoLuongN.Value = decimal.One;
							this.txtGiaNhap.Text = "";
						}
					}
					else
					{
						foreach (CChiTietPhieuNhap current in this.pn.ChiTietPhieuNhap)
						{
							bool flag5 = current.Sach.IDSach == this.txtIDSach.Text;
							if (flag5)
							{
								MessageBox.Show("Sách này đã có rồi không thể thêm được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return;
							}
						}
						CChiTietPhieuNhap cChiTietPhieuNhap2 = new CChiTietPhieuNhap();
						cChiTietPhieuNhap2.Sach = this.xulySach.tim(text);
						cChiTietPhieuNhap2.SoLuongN = (int)this.nubSoLuongN.Value;
						bool flag6 = !this.xulyPhieuNhap.toanSo(this.txtGiaNhap.Text) || int.Parse(this.txtGiaNhap.Text) <= 0;
						if (flag6)
						{
							MessageBox.Show("Giá nhập phải toàn là kí tự số và >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							cChiTietPhieuNhap2.GiaNhap = int.Parse(this.txtGiaNhap.Text);
							this.pn.ChiTietPhieuNhap.Add(cChiTietPhieuNhap2);
							this.txtthanhTien.Text = this.pn.tinhTienNhap().ToString();
							this.hienthiPhieuNhap(this.pn);
							this.nubSoLuongN.Value = decimal.One;
							this.txtGiaNhap.Text = "";
							this.txtNXBGiam.Text = "";
						}
					}
				}
			}
			else
			{
				this.Sach = new CSach();
				bool flag7 = this.txtTenTG.Text == "" || this.txtNXB.Text == "" || this.txtTenSach.Text == "" || this.txtGiaNhap.Text == "";
				if (flag7)
				{
					MessageBox.Show("Điền thông tin sách mới chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					bool flag8 = this.xulySach.toanSo(this.txtTenSach.Text);
					if (flag8)
					{
						MessageBox.Show("Tên sách sai định dạng khi toàn là kí tự số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						bool flag9 = this.xulySach.timTenSach(this.txtTenSach.Text) != null && this.xulySach.timTenSach(this.txtTenSach.Text).IDNXB == CConst.NhaXuatBan.IDNXB;
						if (flag9)
						{
							MessageBox.Show("Sách này đã có trong danh mục sách và do cùng nhà xuất bản nên bạn hãy chọn sách để thêm vào phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.chkThemSach.Checked = false;
						}
						else
						{
							bool flag10 = this.xulySach.timTenSach(this.txtTenSach.Text) != null && this.xulySach.timTenSach(this.txtTenSach.Text).IDNXB != CConst.NhaXuatBan.IDNXB;
							if (flag10)
							{
								MessageBox.Show("Sách này đã được nhập và do nhà xuất bản khác nên bạn không thể thêm vào phiếu nhập được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								this.txtTenSach.Text = "";
							}
							else
							{
								this.Sach.IDSach = this.txtIDSach.Text;
								this.Sach.TenSach = this.txtTenSach.Text;
								bool flag11 = !this.xulySach.toanSo(this.txtNXB.Text) || int.Parse(this.txtNXB.Text) <= 0;
								if (flag11)
								{
									MessageBox.Show("Năm xuất bản sách sai định dạng,phải toàn là kí tự số và >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
								else
								{
									bool flag12 = int.Parse(this.txtNXB.Text) > DateTime.Now.Year;
									if (flag12)
									{
										MessageBox.Show("Năm xuất bản không được lớn hơn năm hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									else
									{
										this.Sach.NXB = int.Parse(this.txtNXB.Text);
										bool flag13 = this.xulySach.toanSo(this.txtTenTG.Text);
										if (flag13)
										{
											MessageBox.Show("Tên tác giả sai định dạng khi toàn là kí tự số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
										else
										{
											this.Sach.TenTG = this.txtTenTG.Text;
											this.Sach.IDNXB = CConst.NhaXuatBan.IDNXB;
											this.Sach.TenNXB = CConst.NhaXuatBan.TenNXB;
											this.Sach.SoLuongT = 0;
											this.Sach.GiaNhapGanNhat = 0;
											this.Sach.GiaBan = 0;
											CChiTietPhieuNhap cChiTietPhieuNhap3 = new CChiTietPhieuNhap();
											cChiTietPhieuNhap3.Sach = this.Sach;
											cChiTietPhieuNhap3.SoLuongN = (int)this.nubSoLuongN.Value;
											bool flag14 = !this.xulyPhieuNhap.toanSo(this.txtGiaNhap.Text) || int.Parse(this.txtGiaNhap.Text) <= 0;
											if (flag14)
											{
												MessageBox.Show("Giá nhập phải toàn là kí tự số và >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
											}
											else
											{
												cChiTietPhieuNhap3.GiaNhap = int.Parse(this.txtGiaNhap.Text);
												this.pn.ChiTietPhieuNhap.Add(cChiTietPhieuNhap3);
												this.txtthanhTien.Text = this.pn.tinhTienNhap().ToString();
												this.hienthiPhieuNhap(this.pn);
												this.nubSoLuongN.Value = decimal.One;
												this.txtTenSach.Text = "";
												this.txtTenTG.Text = "";
												this.txtNXB.Text = "";
												this.txtIDSach.Text = "T" + (this.pn.ChiTietPhieuNhap.Count + 1).ToString();
												this.txtSoLuongT.Text = "0";
												this.txtGiaNhapGN.Text = "0";
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
		private void btnsua_Click(object sender, EventArgs e)
		{
			int num = 0;
			foreach (CChiTietPhieuNhap current in this.pn.ChiTietPhieuNhap)
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
				MessageBox.Show("Sách chưa thêm vào phiếu nhập nên không thể sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				foreach (CChiTietPhieuNhap current2 in this.pn.ChiTietPhieuNhap)
				{
					bool flag3 = current2.Sach.IDSach == this.txtIDSach.Text;
					if (flag3)
					{
						current2.SoLuongN = (int)this.nubSoLuongN.Value;
						current2.GiaNhap = int.Parse(this.txtGiaNhap.Text);
					}
				}
				this.txtthanhTien.Text = this.pn.tinhTienNhap().ToString();
				this.hienthiPhieuNhap(this.pn);
				this.nubSoLuongN.Value = decimal.One;
				this.txtGiaNhap.Text = "";
				this.txtNXBGiam.Text = "";
			}
		}
		private void btnXoa_Click(object sender, EventArgs e)
		{
			int num = 0;
			foreach (CChiTietPhieuNhap current in this.pn.ChiTietPhieuNhap)
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
				MessageBox.Show("Sách chưa thêm vào phiếu nhập nên không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				foreach (CChiTietPhieuNhap current2 in this.pn.ChiTietPhieuNhap)
				{
					bool flag3 = current2.Sach.IDSach == this.txtIDSach.Text;
					if (flag3)
					{
						this.pn.ChiTietPhieuNhap.Remove(current2);
						break;
					}
				}
				this.txtthanhTien.Text = this.pn.tinhTienNhap().ToString();
				this.hienthiPhieuNhap(this.pn);
				this.nubSoLuongN.Value = decimal.One;
				this.txtGiaNhap.Text = "";
				this.txtNXBGiam.Text = "";
			}
		}
		private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void txtNXBGiam_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void btnlapPN_Click(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show("Bạn có chắc với quyết định của mình không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
			if (!flag)
			{
				bool flag2 = this.pn.ChiTietPhieuNhap.Count == 0;
				if (flag2)
				{
					MessageBox.Show("Phiếu nhập chưa có sách nào nên không thể lập phiếu nhập được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					bool flag3 = this.txtNXBGiam.Text == "";
					if (flag3)
					{
						MessageBox.Show("Chưa điền số tiền giảm,không giảm thì điền 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						this.pn.ThanhTienN = int.Parse(this.txtthanhTien.Text);
						bool flag4 = !this.xulyPhieuNhap.toanSo(this.txtNXBGiam.Text) || int.Parse(this.txtNXBGiam.Text) < 0;
						if (flag4)
						{
							MessageBox.Show("Số tiền giảm phải toàn là kí tự số và >=0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							bool flag5 = this.txtThanhToan.Text == "";
							if (flag5)
							{
								MessageBox.Show("Lỗi nhập chưa có số tiền thanh toán ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
							else
							{
								this.pn.ThanhToanNXB = int.Parse(this.txtThanhToan.Text);
								this.pn.NgayTaoPN = this.dtpNLPN.Value;
								this.pn.IDPN = (this.xulyPhieuNhap.getDSPhieuNhap().Count + 1).ToString();
								this.pn.IDNXB = CConst.NhaXuatBan.IDNXB;
								this.pn.TenNXB = CConst.NhaXuatBan.TenNXB;
								this.pn.SDTNXB = CConst.NhaXuatBan.SDTNXB;
								this.pn.TrangThai = "Chờ";
								this.xulyPhieuNhap.them(this.pn);
								this.xulyPhieuNhap.ghiFile("DSPhieuNhap.dat");
								MessageBox.Show("Đã tạo phiếu nhập thành công mã phiếu nhập vừa tạo là: " + this.pn.IDPN, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								this.pn = new CPhieuNhap();
								this.hienthiPhieuNhap(this.pn);
								this.txtthanhTien.Text = "";
								this.txtNXBGiam.Text = "";
								this.txtThanhToan.Text = "";
							}
						}
					}
				}
			}
		}
		private void TaoPN_KeyUp(object sender, KeyEventArgs e)
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
		private void TaoPN_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Hide();
			MainNXB mainNXB = new MainNXB();
			mainNXB.ShowDialog();
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
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NXB_TaoPhieuNhap));
			this.label11 = new Label();
			this.label9 = new Label();
			this.txtIDSach = new TextBox();
			this.label12 = new Label();
			this.label10 = new Label();
			this.txtGiaNhap = new TextBox();
			this.cbxChonSach = new ComboBox();
			this.lblchon = new Label();
			this.txtTenNhaXB = new TextBox();
			this.label5 = new Label();
			this.label14 = new Label();
			this.txtGiaNhapGN = new TextBox();
			this.label7 = new Label();
			this.txtSoLuongT = new TextBox();
			this.txtNXB = new TextBox();
			this.label13 = new Label();
			this.lblTenSach = new Label();
			this.txtTenSach = new TextBox();
			this.nubSoLuongN = new NumericUpDown();
			this.panel1 = new Panel();
			this.panel5 = new Panel();
			this.label6 = new Label();
			this.txtthanhTien = new TextBox();
			this.label1 = new Label();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.txtTenTG = new TextBox();
			this.chkThemSach = new CheckBox();
			this.panel2 = new Panel();
			this.txtThanhToan = new TextBox();
			this.label8 = new Label();
			this.dtpNLPN = new DateTimePicker();
			this.txtNXBGiam = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.dgvPN = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column12 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column10 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.btnXoa = new VBButton();
			this.btnsua = new VBButton();
			this.btnthem = new VBButton();
			this.btnlapPN = new VBButton();
			GroupBox groupBox = new GroupBox();
			groupBox.SuspendLayout();
			((ISupportInitialize)this.nubSoLuongN).BeginInit();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((ISupportInitialize)this.dgvPN).BeginInit();
			base.SuspendLayout();
			groupBox.BackColor = Color.Pink;
			groupBox.Controls.Add(this.btnXoa);
			groupBox.Controls.Add(this.btnsua);
			groupBox.Controls.Add(this.btnthem);
			groupBox.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox.ForeColor = Color.Black;
			groupBox.Location = new Point(359, 418);
			groupBox.Name = "groupBox6";
			groupBox.Size = new Size(435, 95);
			groupBox.TabIndex = 11;
			groupBox.TabStop = false;
			groupBox.Text = "THAO TÁC";
			this.label11.AutoSize = true;
			this.label11.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label11.ForeColor = Color.Black;
			this.label11.Location = new Point(28, 293);
			this.label11.Name = "label11";
			this.label11.Size = new Size(144, 21);
			this.label11.TabIndex = 128;
			this.label11.Text = "Giá nhập gần nhất";
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label9.ForeColor = Color.Black;
			this.label9.Location = new Point(28, 73);
			this.label9.Name = "label9";
			this.label9.Size = new Size(71, 21);
			this.label9.TabIndex = 130;
			this.label9.Text = "ID Sách";
			this.txtIDSach.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDSach.Location = new Point(172, 65);
			this.txtIDSach.Name = "txtIDSach";
			this.txtIDSach.ReadOnly = true;
			this.txtIDSach.Size = new Size(243, 29);
			this.txtIDSach.TabIndex = 3;
			this.label12.AutoSize = true;
			this.label12.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label12.ForeColor = Color.Black;
			this.label12.Location = new Point(28, 378);
			this.label12.Name = "label12";
			this.label12.Size = new Size(78, 21);
			this.label12.TabIndex = 132;
			this.label12.Text = "Số lượng";
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label10.ForeColor = Color.Black;
			this.label10.Location = new Point(28, 335);
			this.label10.Name = "label10";
			this.label10.Size = new Size(77, 21);
			this.label10.TabIndex = 129;
			this.label10.Text = "Giá nhập";
			this.txtGiaNhap.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiaNhap.Location = new Point(172, 327);
			this.txtGiaNhap.Name = "txtGiaNhap";
			this.txtGiaNhap.Size = new Size(243, 29);
			this.txtGiaNhap.TabIndex = 9;
			this.txtGiaNhap.WordWrap = false;
			this.txtGiaNhap.KeyPress += new KeyPressEventHandler(this.txtGiaNhap_KeyPress);
			this.cbxChonSach.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxChonSach.FormattingEnabled = true;
			this.cbxChonSach.Location = new Point(172, 25);
			this.cbxChonSach.Name = "cbxChonSach";
			this.cbxChonSach.Size = new Size(243, 29);
			this.cbxChonSach.TabIndex = 1;
			this.cbxChonSach.SelectedIndexChanged += new EventHandler(this.cbxChonSach_SelectedIndexChanged);
			this.lblchon.AutoSize = true;
			this.lblchon.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblchon.ForeColor = Color.Black;
			this.lblchon.Location = new Point(28, 33);
			this.lblchon.Name = "lblchon";
			this.lblchon.Size = new Size(90, 21);
			this.lblchon.TabIndex = 131;
			this.lblchon.Text = "Chọn sách";
			this.txtTenNhaXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenNhaXB.Location = new Point(172, 200);
			this.txtTenNhaXB.Name = "txtTenNhaXB";
			this.txtTenNhaXB.ReadOnly = true;
			this.txtTenNhaXB.Size = new Size(243, 29);
			this.txtTenNhaXB.TabIndex = 6;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.ForeColor = Color.Black;
			this.label5.Location = new Point(28, 208);
			this.label5.Name = "label5";
			this.label5.Size = new Size(138, 21);
			this.label5.TabIndex = 133;
			this.label5.Text = "Tên nhà xuất bản";
			this.label14.AutoSize = true;
			this.label14.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label14.ForeColor = Color.Black;
			this.label14.Location = new Point(28, 118);
			this.label14.Name = "label14";
			this.label14.Size = new Size(104, 21);
			this.label14.TabIndex = 134;
			this.label14.Text = "Tên Tác Giả";
			this.txtGiaNhapGN.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiaNhapGN.Location = new Point(172, 285);
			this.txtGiaNhapGN.Name = "txtGiaNhapGN";
			this.txtGiaNhapGN.ReadOnly = true;
			this.txtGiaNhapGN.Size = new Size(243, 29);
			this.txtGiaNhapGN.TabIndex = 8;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.ForeColor = Color.Black;
			this.label7.Location = new Point(28, 253);
			this.label7.Name = "label7";
			this.label7.Size = new Size(107, 21);
			this.label7.TabIndex = 135;
			this.label7.Text = "Số lượng tồn";
			this.txtSoLuongT.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSoLuongT.Location = new Point(172, 245);
			this.txtSoLuongT.Name = "txtSoLuongT";
			this.txtSoLuongT.ReadOnly = true;
			this.txtSoLuongT.Size = new Size(243, 29);
			this.txtSoLuongT.TabIndex = 7;
			this.txtNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNXB.Location = new Point(172, 156);
			this.txtNXB.Name = "txtNXB";
			this.txtNXB.ReadOnly = true;
			this.txtNXB.Size = new Size(243, 29);
			this.txtNXB.TabIndex = 5;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label13.ForeColor = Color.Black;
			this.label13.Location = new Point(28, 162);
			this.label13.Name = "label13";
			this.label13.Size = new Size(113, 21);
			this.label13.TabIndex = 136;
			this.label13.Text = "Năm xuất bản";
			this.lblTenSach.AutoSize = true;
			this.lblTenSach.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblTenSach.ForeColor = Color.Black;
			this.lblTenSach.Location = new Point(28, 33);
			this.lblTenSach.Name = "lblTenSach";
			this.lblTenSach.Size = new Size(78, 21);
			this.lblTenSach.TabIndex = 137;
			this.lblTenSach.Text = "Tên sách";
			this.lblTenSach.TextAlign = ContentAlignment.TopCenter;
			this.lblTenSach.Visible = false;
			this.txtTenSach.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenSach.Location = new Point(172, 25);
			this.txtTenSach.Name = "txtTenSach";
			this.txtTenSach.Size = new Size(243, 29);
			this.txtTenSach.TabIndex = 1;
			this.txtTenSach.TabStop = false;
			this.txtTenSach.Visible = false;
			this.nubSoLuongN.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.nubSoLuongN.Location = new Point(172, 364);
			this.nubSoLuongN.Margin = new Padding(2);
			NumericUpDown arg_E63_0 = this.nubSoLuongN;
			int[] expr_E56 = new int[4];
			expr_E56[0] = 1000000;
			arg_E63_0.Maximum = new decimal(expr_E56);
			NumericUpDown arg_E7E_0 = this.nubSoLuongN;
			int[] expr_E75 = new int[4];
			expr_E75[0] = 1;
			arg_E7E_0.Minimum = new decimal(expr_E75);
			this.nubSoLuongN.Name = "nubSoLuongN";
			this.nubSoLuongN.Size = new Size(88, 29);
			this.nubSoLuongN.TabIndex = 10;
			NumericUpDown arg_ECD_0 = this.nubSoLuongN;
			int[] expr_EC4 = new int[4];
			expr_EC4[0] = 1;
			arg_ECD_0.Value = new decimal(expr_EC4);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(groupBox);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.dgvPN);
			this.panel1.ForeColor = Color.White;
			this.panel1.Location = new Point(1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1474, 1012);
			this.panel1.TabIndex = 0;
			this.panel5.BackColor = SystemColors.ButtonHighlight;
			this.panel5.Controls.Add(this.label6);
			this.panel5.Controls.Add(this.txtthanhTien);
			this.panel5.Location = new Point(349, 966);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(281, 39);
			this.panel5.TabIndex = 168;
			this.label6.AutoSize = true;
			this.label6.BackColor = Color.Transparent;
			this.label6.Font = new Font("Times New Roman", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.ForeColor = Color.Black;
			this.label6.Location = new Point(3, 9);
			this.label6.Name = "label6";
			this.label6.Size = new Size(119, 22);
			this.label6.TabIndex = 167;
			this.label6.Text = "TỔNG TIỀN";
			this.txtthanhTien.BackColor = Color.White;
			this.txtthanhTien.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtthanhTien.Location = new Point(128, 7);
			this.txtthanhTien.Name = "txtthanhTien";
			this.txtthanhTien.ReadOnly = true;
			this.txtthanhTien.Size = new Size(150, 29);
			this.txtthanhTien.TabIndex = 166;
			this.txtthanhTien.TabStop = false;
			this.txtthanhTien.WordWrap = false;
			this.label1.AutoSize = true;
			this.label1.BackColor = SystemColors.ButtonHighlight;
			this.label1.Font = new Font("Times New Roman", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = SystemColors.Desktop;
			this.label1.Location = new Point(26, 482);
			this.label1.Name = "label1";
			this.label1.Size = new Size(266, 31);
			this.label1.TabIndex = 12;
			this.label1.Text = "Thông tin phiếu nhập";
			this.panel4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel4.BackColor = Color.Black;
			this.panel4.Location = new Point(0, 402);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(1472, 4);
			this.panel4.TabIndex = 11;
			this.panel3.BackColor = SystemColors.InactiveBorder;
			this.panel3.Controls.Add(this.txtTenTG);
			this.panel3.Controls.Add(this.chkThemSach);
			this.panel3.Controls.Add(this.nubSoLuongN);
			this.panel3.Controls.Add(this.txtTenSach);
			this.panel3.Controls.Add(this.lblTenSach);
			this.panel3.Controls.Add(this.label13);
			this.panel3.Controls.Add(this.txtNXB);
			this.panel3.Controls.Add(this.txtSoLuongT);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.txtGiaNhapGN);
			this.panel3.Controls.Add(this.label14);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.txtTenNhaXB);
			this.panel3.Controls.Add(this.lblchon);
			this.panel3.Controls.Add(this.cbxChonSach);
			this.panel3.Controls.Add(this.txtGiaNhap);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.label12);
			this.panel3.Controls.Add(this.txtIDSach);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.label11);
			this.panel3.ForeColor = Color.White;
			this.panel3.Location = new Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(794, 402);
			this.panel3.TabIndex = 1;
			this.txtTenTG.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenTG.Location = new Point(172, 110);
			this.txtTenTG.Name = "txtTenTG";
			this.txtTenTG.ReadOnly = true;
			this.txtTenTG.Size = new Size(243, 29);
			this.txtTenTG.TabIndex = 4;
			this.chkThemSach.AutoSize = true;
			this.chkThemSach.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkThemSach.ForeColor = Color.Black;
			this.chkThemSach.Location = new Point(421, 31);
			this.chkThemSach.Name = "chkThemSach";
			this.chkThemSach.Size = new Size(119, 23);
			this.chkThemSach.TabIndex = 138;
			this.chkThemSach.Text = "Thêm sách mới";
			this.chkThemSach.UseVisualStyleBackColor = true;
			this.chkThemSach.CheckedChanged += new EventHandler(this.chkThemSach_CheckedChanged);
			this.panel2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel2.BackColor = SystemColors.GradientActiveCaption;
			this.panel2.Controls.Add(this.btnlapPN);
			this.panel2.Controls.Add(this.txtThanhToan);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.dtpNLPN);
			this.panel2.Controls.Add(this.txtNXBGiam);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.ForeColor = SystemColors.HighlightText;
			this.panel2.Location = new Point(794, 0);
			this.panel2.Margin = new Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(2061, 402);
			this.panel2.TabIndex = 16;
			this.txtThanhToan.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtThanhToan.Location = new Point(302, 154);
			this.txtThanhToan.Name = "txtThanhToan";
			this.txtThanhToan.ReadOnly = true;
			this.txtThanhToan.Size = new Size(243, 29);
			this.txtThanhToan.TabIndex = 8;
			this.txtThanhToan.TabStop = false;
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label8.ForeColor = Color.Black;
			this.label8.Location = new Point(103, 251);
			this.label8.Name = "label8";
			this.label8.Size = new Size(162, 21);
			this.label8.TabIndex = 99;
			this.label8.Text = "Ngày lập phiếu nhập";
			this.dtpNLPN.CustomFormat = "dd/MM/yyyy hh:mm:ss";
			this.dtpNLPN.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpNLPN.Format = DateTimePickerFormat.Custom;
			this.dtpNLPN.Location = new Point(302, 245);
			this.dtpNLPN.Name = "dtpNLPN";
			this.dtpNLPN.Size = new Size(240, 29);
			this.dtpNLPN.TabIndex = 17;
			this.txtNXBGiam.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNXBGiam.Location = new Point(299, 65);
			this.txtNXBGiam.Name = "txtNXBGiam";
			this.txtNXBGiam.Size = new Size(243, 29);
			this.txtNXBGiam.TabIndex = 16;
			this.txtNXBGiam.TextChanged += new EventHandler(this.txtNXBGiam_TextChanged);
			this.txtNXBGiam.KeyPress += new KeyPressEventHandler(this.txtNXBGiam_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Black;
			this.label4.Location = new Point(103, 162);
			this.label4.Name = "label4";
			this.label4.Size = new Size(94, 21);
			this.label4.TabIndex = 102;
			this.label4.Text = "Thanh toán";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Black;
			this.label3.Location = new Point(103, 73);
			this.label3.Name = "label3";
			this.label3.Size = new Size(145, 21);
			this.label3.TabIndex = 101;
			this.label3.Text = "Số tiền NXB giảm";
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			this.dgvPN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dgvPN.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvPN.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvPN.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			this.dgvPN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvPN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPN.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column1,
				this.Column2,
				this.Column3,
				this.Column7,
				this.Column6,
				this.Column4,
				this.Column11,
				this.Column12,
				this.Column5,
				this.Column10,
				this.Column8
			});
			this.dgvPN.Cursor = Cursors.Default;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			this.dgvPN.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvPN.Location = new Point(-2, 518);
			this.dgvPN.Margin = new Padding(2);
			this.dgvPN.Name = "dgvPN";
			this.dgvPN.RowHeadersWidth = 62;
			dataGridViewCellStyle4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			this.dgvPN.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvPN.RowTemplate.Height = 50;
			this.dgvPN.Size = new Size(2857, 501);
			this.dgvPN.TabIndex = 15;
			this.dgvPN.RowEnter += new DataGridViewCellEventHandler(this.dgvPN_RowEnter);
			this.Column1.DataPropertyName = "IDSach";
			dataGridViewCellStyle5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column1.HeaderText = "ID Sách";
			this.Column1.MinimumWidth = 6;
			this.Column1.Name = "Column1";
			this.Column1.Width = 96;
			this.Column2.DataPropertyName = "TenSach";
			dataGridViewCellStyle6.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
			this.Column2.FillWeight = 200f;
			this.Column2.HeaderText = "Tên Sách";
			this.Column2.MinimumWidth = 6;
			this.Column2.Name = "Column2";
			this.Column2.Width = 106;
			this.Column3.DataPropertyName = "GiaBan";
			dataGridViewCellStyle7.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column3.DefaultCellStyle = dataGridViewCellStyle7;
			this.Column3.HeaderText = "Giá Bán";
			this.Column3.MinimumWidth = 6;
			this.Column3.Name = "Column3";
			this.Column3.Visible = false;
			this.Column3.Width = 95;
			this.Column7.DataPropertyName = "GiaNhapGanNhat";
			dataGridViewCellStyle8.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column7.DefaultCellStyle = dataGridViewCellStyle8;
			this.Column7.HeaderText = "Giá nhập gần nhất";
			this.Column7.MinimumWidth = 6;
			this.Column7.Name = "Column7";
			this.Column7.Visible = false;
			this.Column7.Width = 169;
			this.Column6.DataPropertyName = "GiaNhap";
			dataGridViewCellStyle9.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column6.DefaultCellStyle = dataGridViewCellStyle9;
			this.Column6.HeaderText = "Giá nhập";
			this.Column6.MinimumWidth = 6;
			this.Column6.Name = "Column6";
			this.Column6.Width = 102;
			this.Column4.DataPropertyName = "SoLuongN";
			dataGridViewCellStyle10.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column4.DefaultCellStyle = dataGridViewCellStyle10;
			this.Column4.HeaderText = "Số lượng nhập";
			this.Column4.MinimumWidth = 6;
			this.Column4.Name = "Column4";
			this.Column4.Width = 144;
			this.Column11.DataPropertyName = "ThanhTienN";
			dataGridViewCellStyle11.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column11.DefaultCellStyle = dataGridViewCellStyle11;
			this.Column11.HeaderText = "Thành tiền";
			this.Column11.MinimumWidth = 6;
			this.Column11.Name = "Column11";
			this.Column11.Width = 113;
			this.Column12.DataPropertyName = "IDPN";
			dataGridViewCellStyle12.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column12.DefaultCellStyle = dataGridViewCellStyle12;
			this.Column12.HeaderText = "ID phiếu nhập";
			this.Column12.MinimumWidth = 6;
			this.Column12.Name = "Column12";
			this.Column12.Visible = false;
			this.Column12.Width = 140;
			this.Column5.DataPropertyName = "TenTG";
			dataGridViewCellStyle13.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column5.DefaultCellStyle = dataGridViewCellStyle13;
			this.Column5.HeaderText = "Tên tác giả";
			this.Column5.MinimumWidth = 6;
			this.Column5.Name = "Column5";
			this.Column5.Width = 117;
			this.Column10.DataPropertyName = "TenNXB";
			dataGridViewCellStyle14.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column10.DefaultCellStyle = dataGridViewCellStyle14;
			this.Column10.HeaderText = "Tên nhà xuất bản";
			this.Column10.MinimumWidth = 6;
			this.Column10.Name = "Column10";
			this.Column10.Visible = false;
			this.Column10.Width = 163;
			this.Column8.DataPropertyName = "NXB";
			dataGridViewCellStyle15.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column8.DefaultCellStyle = dataGridViewCellStyle15;
			this.Column8.HeaderText = "Năm xuất bản";
			this.Column8.MinimumWidth = 6;
			this.Column8.Name = "Column8";
			this.Column8.Width = 138;
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
			this.btnXoa.Location = new Point(324, 28);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new Size(105, 60);
			this.btnXoa.TabIndex = 14;
			this.btnXoa.Text = "  Xóa";
			this.btnXoa.TextColor = Color.White;
			this.btnXoa.UseVisualStyleBackColor = false;
			this.btnXoa.Click += new EventHandler(this.btnXoa_Click);
			this.btnsua.BackColor = Color.DeepSkyBlue;
			this.btnsua.BackgroundColor = Color.DeepSkyBlue;
			this.btnsua.BorderColor = Color.PaleVioletRed;
			this.btnsua.BorderRadius = 5;
			this.btnsua.BorderSize = 0;
			this.btnsua.FlatAppearance.BorderSize = 0;
			this.btnsua.FlatStyle = FlatStyle.Flat;
			this.btnsua.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnsua.ForeColor = Color.Black;
			this.btnsua.Image = Resources.circle_edit_outline_icon_1397993;
			this.btnsua.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnsua.Location = new Point(166, 28);
			this.btnsua.Name = "btnsua";
			this.btnsua.Size = new Size(105, 60);
			this.btnsua.TabIndex = 13;
			this.btnsua.Text = "  Sửa";
			this.btnsua.TextColor = Color.Black;
			this.btnsua.UseVisualStyleBackColor = false;
			this.btnsua.Click += new EventHandler(this.btnsua_Click);
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
			this.btnthem.Location = new Point(6, 28);
			this.btnthem.Name = "btnthem";
			this.btnthem.Size = new Size(105, 60);
			this.btnthem.TabIndex = 12;
			this.btnthem.Text = "Thêm";
			this.btnthem.TextAlign = ContentAlignment.MiddleRight;
			this.btnthem.TextColor = Color.Black;
			this.btnthem.UseVisualStyleBackColor = false;
			this.btnthem.Click += new EventHandler(this.btnthem_Click);
			this.btnlapPN.BackColor = Color.Yellow;
			this.btnlapPN.BackgroundColor = Color.Yellow;
			this.btnlapPN.BorderColor = Color.PaleVioletRed;
			this.btnlapPN.BorderRadius = 5;
			this.btnlapPN.BorderSize = 0;
			this.btnlapPN.FlatAppearance.BorderSize = 0;
			this.btnlapPN.FlatStyle = FlatStyle.Flat;
			this.btnlapPN.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnlapPN.ForeColor = Color.Black;
			this.btnlapPN.Image = Resources.ecommerce_receipt_dollar_399212;
			this.btnlapPN.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnlapPN.Location = new Point(321, 293);
			this.btnlapPN.Name = "btnlapPN";
			this.btnlapPN.Size = new Size(195, 90);
			this.btnlapPN.TabIndex = 18;
			this.btnlapPN.Text = "    Lập phiếu nhập";
			this.btnlapPN.TextColor = Color.Black;
			this.btnlapPN.UseVisualStyleBackColor = false;
			this.btnlapPN.Click += new EventHandler(this.btnlapPN_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.ClientSize = new Size(1474, 1011);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "NXB_TaoPhieuNhap";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "TẠO PHIẾU NHẬP";
			base.FormClosed += new FormClosedEventHandler(this.TaoPN_FormClosed);
			base.Load += new EventHandler(this.TaoPN_Load);
			base.KeyUp += new KeyEventHandler(this.TaoPN_KeyUp);
			groupBox.ResumeLayout(false);
			((ISupportInitialize)this.nubSoLuongN).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((ISupportInitialize)this.dgvPN).EndInit();
			base.ResumeLayout(false);
		}
	}
}
