using bansach.Properties;
using CustomButton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class QL_XacNhanPN : Form
	{
		private CXuLyPhieuNhap xulyPhieuNhap;
		private CXuLyLichSuHD xuLyLichSuHD;
		private CXuLySach xulySach;
		private CXuLyNXB xulyNXB;
		private IContainer components = null;
		private Panel panel1;
		private Panel panel2;
		private Panel panel3;
		private Panel panel4;
		private VBButton btnDongY;
		private VBButton btnKhongDongY;
		private VBButton btnXemPN;
		private DataGridView dgvDsPN;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private GroupBox groupBox3;
		private ComboBox cbxTrangThai;
		private CheckBox chkTrangThai;
		private DateTimePicker dtpNLPN;
		private Label label18;
		private CheckBox chkTenNXB;
		private CheckBox chkNL;
		private ComboBox cbxChonNhaXuatBan;
		private TextBox txtIDNXB1;
		private Label label1;
		public QL_XacNhanPN()
		{
			this.InitializeComponent();
		}
		private void hienthiDSPhieuNhap(List<CPhieuNhap> ds)
		{
			bool flag = !this.chkTenNXB.Checked && !this.chkTrangThai.Checked && !this.chkNL.Checked;
			if (flag)
			{
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = ds;
				this.dgvDsPN.DataSource = bindingSource;
			}
			else
			{
				bool flag2 = this.chkTenNXB.Checked && !this.chkTrangThai.Checked && !this.chkNL.Checked;
				if (flag2)
				{
					List<CPhieuNhap> list = new List<CPhieuNhap>();
					foreach (CPhieuNhap current in ds)
					{
						bool flag3 = current.TenNXB == this.cbxChonNhaXuatBan.Text;
						if (flag3)
						{
							list.Add(current);
						}
					}
					BindingSource bindingSource2 = new BindingSource();
					bindingSource2.DataSource = list;
					this.dgvDsPN.DataSource = bindingSource2;
					bool flag4 = list.Count == 0;
					if (flag4)
					{
						MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					bool flag5 = !this.chkTenNXB.Checked && this.chkTrangThai.Checked && !this.chkNL.Checked;
					if (flag5)
					{
						List<CPhieuNhap> list2 = new List<CPhieuNhap>();
						foreach (CPhieuNhap current2 in ds)
						{
							bool flag6 = current2.TrangThai == this.cbxTrangThai.Text;
							if (flag6)
							{
								list2.Add(current2);
							}
						}
						BindingSource bindingSource3 = new BindingSource();
						bindingSource3.DataSource = list2;
						this.dgvDsPN.DataSource = bindingSource3;
						bool flag7 = list2.Count == 0;
						if (flag7)
						{
							MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						bool flag8 = !this.chkTenNXB.Checked && !this.chkTrangThai.Checked && this.chkNL.Checked;
						if (flag8)
						{
							List<CPhieuNhap> list3 = new List<CPhieuNhap>();
							foreach (CPhieuNhap current3 in ds)
							{
								bool flag9 = current3.NgayTaoPN.Year == this.dtpNLPN.Value.Year && current3.NgayTaoPN.Month == this.dtpNLPN.Value.Month && current3.NgayTaoPN.Day == this.dtpNLPN.Value.Day;
								if (flag9)
								{
									list3.Add(current3);
								}
							}
							BindingSource bindingSource4 = new BindingSource();
							bindingSource4.DataSource = list3;
							this.dgvDsPN.DataSource = bindingSource4;
							bool flag10 = list3.Count == 0;
							if (flag10)
							{
								MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							bool flag11 = this.chkTenNXB.Checked && this.chkTrangThai.Checked && !this.chkNL.Checked;
							if (flag11)
							{
								List<CPhieuNhap> list4 = new List<CPhieuNhap>();
								foreach (CPhieuNhap current4 in ds)
								{
									bool flag12 = current4.TrangThai == this.cbxTrangThai.Text && current4.TenNXB == this.cbxChonNhaXuatBan.Text;
									if (flag12)
									{
										list4.Add(current4);
									}
								}
								BindingSource bindingSource5 = new BindingSource();
								bindingSource5.DataSource = list4;
								this.dgvDsPN.DataSource = bindingSource5;
								bool flag13 = list4.Count == 0;
								if (flag13)
								{
									MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								bool flag14 = !this.chkTenNXB.Checked && this.chkTrangThai.Checked && this.chkNL.Checked;
								if (flag14)
								{
									List<CPhieuNhap> list5 = new List<CPhieuNhap>();
									foreach (CPhieuNhap current5 in ds)
									{
										bool flag15 = current5.TrangThai == this.cbxTrangThai.Text && current5.NgayTaoPN.Year == this.dtpNLPN.Value.Year && current5.NgayTaoPN.Month == this.dtpNLPN.Value.Month && current5.NgayTaoPN.Day == this.dtpNLPN.Value.Day;
										if (flag15)
										{
											list5.Add(current5);
										}
									}
									BindingSource bindingSource6 = new BindingSource();
									bindingSource6.DataSource = list5;
									this.dgvDsPN.DataSource = bindingSource6;
									bool flag16 = list5.Count == 0;
									if (flag16)
									{
										MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
								}
								else
								{
									bool flag17 = this.chkTenNXB.Checked && this.chkTrangThai.Checked && this.chkNL.Checked;
									if (flag17)
									{
										List<CPhieuNhap> list6 = new List<CPhieuNhap>();
										foreach (CPhieuNhap current6 in ds)
										{
											bool flag18 = current6.TenNXB == this.cbxChonNhaXuatBan.Text && current6.TrangThai == this.cbxTrangThai.Text && current6.NgayTaoPN.Year == this.dtpNLPN.Value.Year && current6.NgayTaoPN.Month == this.dtpNLPN.Value.Month && current6.NgayTaoPN.Day == this.dtpNLPN.Value.Day;
											if (flag18)
											{
												list6.Add(current6);
											}
										}
										BindingSource bindingSource7 = new BindingSource();
										bindingSource7.DataSource = list6;
										this.dgvDsPN.DataSource = bindingSource7;
										bool flag19 = list6.Count == 0;
										if (flag19)
										{
											MessageBox.Show("Không có phiếu  nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void hienthiComboBoxchonNXB(List<CNhaXuatBan> ds)
		{
			this.cbxChonNhaXuatBan.DisplayMember = "TenNXB";
			this.cbxChonNhaXuatBan.ValueMember = "TenNXB";
			this.cbxChonNhaXuatBan.DataSource = ds;
		}
		private void QL_XacNhanPN_Load(object sender, EventArgs e)
		{
			this.xulySach = new CXuLySach();
			bool flag = !this.xulySach.docFile("DanhMucSach.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DanhMucSach.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.xulyNXB = new CXuLyNXB();
			bool flag2 = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiComboBoxchonNXB(this.xulyNXB.getDSNXB());
			}
			this.xulyPhieuNhap = new CXuLyPhieuNhap();
			bool flag3 = !this.xulyPhieuNhap.docFile("DSPhieuNhap.dat");
			if (flag3)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSPhieuNhap.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag4 = !this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag4)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
		}
		private void cbxChonNhaXuatBan_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			string b = this.cbxChonNhaXuatBan.SelectedValue.ToString();
			foreach (CNhaXuatBan current in this.xulyNXB.getDSNXB())
			{
				bool flag = current.TenNXB == b;
				if (flag)
				{
					this.txtIDNXB1.Text = current.IDNXB;
				}
			}
			this.xulyPhieuNhap = new CXuLyPhieuNhap();
			bool flag2 = this.xulyPhieuNhap.docFile("DSPhieuNhap.dat");
			if (flag2)
			{
				this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
			}
		}
		private void chkTrangThai_CheckedChanged_1(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void cbxTrangThai_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void chkNL_CheckedChanged_1(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void dtpNLPN_ValueChanged_1(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void chkTenNXB_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void btnXemPN_Click(object sender, EventArgs e)
		{
			IEnumerator enumerator = this.dgvDsPN.SelectedRows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					bool flag = dataGridViewRow.Cells[0].Value == null;
					if (flag)
					{
						MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						string iDPN = dataGridViewRow.Cells[0].Value.ToString();
						CPhieuNhap phieunhap = this.xulyPhieuNhap.tim(iDPN);
						new NXB_XemChiTietPhieuNhap
						{
							phieunhap = phieunhap
						}.ShowDialog();
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		private void btnKhongDongY_Click_1(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show("Bạn có chắc với quyết định của mình không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
			if (!flag)
			{
				IEnumerator enumerator = this.dgvDsPN.SelectedRows.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
						bool flag2 = dataGridViewRow.Cells[0].Value == null;
						if (flag2)
						{
							MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							bool flag3 = dataGridViewRow.Cells[8].Value.ToString() != "Chờ";
							if (flag3)
							{
								MessageBox.Show("Phiếu nhập này đã được xác nhận là " + dataGridViewRow.Cells[8].Value.ToString() + " ;không thể thay đổi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								string iDPN = dataGridViewRow.Cells[0].Value.ToString();
								this.xulyPhieuNhap.tim(iDPN).TrangThai = "Không đồng ý";
								this.xulyPhieuNhap.ghiFile("DSPhieuNhap.dat");
								this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
								CLichSuHD cLichSuHD = new CLichSuHD();
								cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
								cLichSuHD.NHoatDong = DateTime.Now;
								cLichSuHD.IDND = CConst.Nhanvien.IDNV;
								cLichSuHD.TenND = CConst.Nhanvien.TenNV;
								cLichSuHD.HoatDong = "Xác nhận phiếu nhập";
								cLichSuHD.IDDoiTuong = this.xulyPhieuNhap.tim(iDPN).IDPN;
								cLichSuHD.DoiTuong = "Phiếu nhập";
								cLichSuHD.NoiDung = "Không đồng ý phiếu nhập với ID=" + this.xulyPhieuNhap.tim(iDPN).IDPN;
								this.xuLyLichSuHD.them(cLichSuHD);
								this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
							}
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		private void btnDongY_Click_1(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show("Bạn có chắc với quyết định của mình không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
			if (!flag)
			{
				IEnumerator enumerator = this.dgvDsPN.SelectedRows.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
						bool flag2 = dataGridViewRow.Cells[0].Value == null;
						if (flag2)
						{
							MessageBox.Show("Dòng này không chứa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							bool flag3 = dataGridViewRow.Cells[8].Value.ToString() != "Chờ";
							if (flag3)
							{
								MessageBox.Show("Phiếu nhập này đã được xác nhận là " + dataGridViewRow.Cells[8].Value.ToString() + " ;không thể thay đổi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								string iDPN = dataGridViewRow.Cells[0].Value.ToString();
								this.xulyPhieuNhap.tim(iDPN).TrangThai = "Đồng ý";
								this.xulyPhieuNhap.ghiFile("DSPhieuNhap.dat");
								this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
								foreach (CChiTietPhieuNhap current in this.xulyPhieuNhap.tim(iDPN).ChiTietPhieuNhap)
								{
									bool flag4 = current.Sach.IDSach.StartsWith("S");
									if (flag4)
									{
										CSach cSach = new CSach(current.Sach);
										cSach.SoLuongT = this.xulySach.tim(cSach.IDSach).SoLuongT + current.SoLuongN;
										cSach.GiaNhapGanNhat = current.GiaNhap;
										this.xulySach.sua(cSach);
										List<CPhieuNhap> dSPhieuNhap = this.xulyPhieuNhap.getDSPhieuNhap();
										foreach (CPhieuNhap current2 in dSPhieuNhap)
										{
											foreach (CChiTietPhieuNhap current3 in this.xulyPhieuNhap.tim(current2.IDPN).ChiTietPhieuNhap)
											{
												bool flag5 = current3.Sach.IDSach == cSach.IDSach;
												if (flag5)
												{
													current3.Sach.GiaNhapGanNhat = cSach.GiaNhapGanNhat;
												}
											}
										}
									}
									bool flag6 = current.Sach.IDSach.StartsWith("T");
									if (flag6)
									{
										bool flag7 = this.xulySach.timTenSach(current.Sach.TenSach) != null;
										if (flag7)
										{
											MessageBox.Show("Sách " + current.Sach.TenSach + " đã có trong danh mục sách nên phiếu nhập này không hợp lệ,không thể đồng ý được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											return;
										}
										CSach cSach2 = new CSach(current.Sach);
										cSach2.IDSach = this.xulySach.CapIDSach();
										cSach2.SoLuongT += current.SoLuongN;
										cSach2.GiaNhapGanNhat = current.GiaNhap;
										this.xulySach.them(cSach2);
										List<CPhieuNhap> dSPhieuNhap2 = this.xulyPhieuNhap.getDSPhieuNhap();
										foreach (CPhieuNhap current4 in dSPhieuNhap2)
										{
											foreach (CChiTietPhieuNhap current5 in this.xulyPhieuNhap.tim(current4.IDPN).ChiTietPhieuNhap)
											{
												bool flag8 = current5.Sach.TenSach == cSach2.TenSach;
												if (flag8)
												{
													current5.Sach.IDSach = cSach2.IDSach;
												}
											}
										}
									}
								}
								this.xulySach.ghiFile("DanhMucSach.dat");
								this.xulyPhieuNhap.ghiFile("DSPhieuNhap.dat");
								this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
								CLichSuHD cLichSuHD = new CLichSuHD();
								cLichSuHD.IDLSHD = (this.xuLyLichSuHD.getDSLSHD().Count + 1).ToString();
								cLichSuHD.NHoatDong = DateTime.Now;
								cLichSuHD.IDND = CConst.Nhanvien.IDNV;
								cLichSuHD.TenND = CConst.Nhanvien.TenNV;
								cLichSuHD.HoatDong = "Xác nhận phiếu nhập";
								cLichSuHD.IDDoiTuong = this.xulyPhieuNhap.tim(iDPN).IDPN;
								cLichSuHD.DoiTuong = "Phiếu nhập";
								cLichSuHD.NoiDung = "Đồng ý phiếu nhập với ID=" + this.xulyPhieuNhap.tim(iDPN).IDPN;
								this.xuLyLichSuHD.them(cLichSuHD);
								this.xuLyLichSuHD.ghiFile("LichSuHD.dat");
							}
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		private void QL_XacNhanPN_KeyUp(object sender, KeyEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QL_XacNhanPN));
			this.btnDongY = new VBButton();
			this.btnKhongDongY = new VBButton();
			this.btnXemPN = new VBButton();
			this.panel1 = new Panel();
			this.label1 = new Label();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.panel4 = new Panel();
			this.dgvDsPN = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
			this.groupBox3 = new GroupBox();
			this.cbxTrangThai = new ComboBox();
			this.chkTrangThai = new CheckBox();
			this.dtpNLPN = new DateTimePicker();
			this.label18 = new Label();
			this.chkTenNXB = new CheckBox();
			this.chkNL = new CheckBox();
			this.cbxChonNhaXuatBan = new ComboBox();
			this.txtIDNXB1 = new TextBox();
			GroupBox groupBox = new GroupBox();
			groupBox.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((ISupportInitialize)this.dgvDsPN).BeginInit();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			groupBox.BackColor = Color.Pink;
			groupBox.Controls.Add(this.btnDongY);
			groupBox.Controls.Add(this.btnKhongDongY);
			groupBox.Controls.Add(this.btnXemPN);
			groupBox.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox.Location = new Point(10, 79);
			groupBox.Name = "groupBox12";
			groupBox.Size = new Size(532, 122);
			groupBox.TabIndex = 6;
			groupBox.TabStop = false;
			groupBox.Text = "THAO TÁC";
			this.btnDongY.BackColor = Color.Lime;
			this.btnDongY.BackgroundColor = Color.Lime;
			this.btnDongY.BorderColor = Color.PaleVioletRed;
			this.btnDongY.BorderRadius = 5;
			this.btnDongY.BorderSize = 0;
			this.btnDongY.FlatAppearance.BorderSize = 0;
			this.btnDongY.FlatStyle = FlatStyle.Flat;
			this.btnDongY.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDongY.ForeColor = Color.Black;
			this.btnDongY.Image = Resources.accept_check_checklist_circle_mark_ok_yes_icon_123225;
			this.btnDongY.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnDongY.Location = new Point(344, 44);
			this.btnDongY.Name = "btnDongY";
			this.btnDongY.Size = new Size(182, 60);
			this.btnDongY.TabIndex = 9;
			this.btnDongY.Text = "  Đồng ý";
			this.btnDongY.TextColor = Color.Black;
			this.btnDongY.UseVisualStyleBackColor = false;
			this.btnDongY.Click += new EventHandler(this.btnDongY_Click_1);
			this.btnKhongDongY.BackColor = Color.Red;
			this.btnKhongDongY.BackgroundColor = Color.Red;
			this.btnKhongDongY.BorderColor = Color.Red;
			this.btnKhongDongY.BorderRadius = 5;
			this.btnKhongDongY.BorderSize = 0;
			this.btnKhongDongY.FlatAppearance.BorderSize = 0;
			this.btnKhongDongY.FlatStyle = FlatStyle.Flat;
			this.btnKhongDongY.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnKhongDongY.ForeColor = Color.White;
			this.btnKhongDongY.Image = Resources.cancel_circle_close_delete_discard_file_x_icon_123219;
			this.btnKhongDongY.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnKhongDongY.Location = new Point(141, 44);
			this.btnKhongDongY.Name = "btnKhongDongY";
			this.btnKhongDongY.Size = new Size(182, 60);
			this.btnKhongDongY.TabIndex = 8;
			this.btnKhongDongY.Text = "    Không đồng ý";
			this.btnKhongDongY.TextColor = Color.White;
			this.btnKhongDongY.UseVisualStyleBackColor = false;
			this.btnKhongDongY.Click += new EventHandler(this.btnKhongDongY_Click_1);
			this.btnXemPN.AccessibleDescription = "";
			this.btnXemPN.BackColor = SystemColors.ButtonHighlight;
			this.btnXemPN.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnXemPN.BorderColor = Color.PaleVioletRed;
			this.btnXemPN.BorderRadius = 5;
			this.btnXemPN.BorderSize = 0;
			this.btnXemPN.FlatAppearance.BorderSize = 0;
			this.btnXemPN.FlatStyle = FlatStyle.Flat;
			this.btnXemPN.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXemPN.ForeColor = Color.Black;
			this.btnXemPN.Image = Resources.searchmagnifierinterfacesymbol1_798934;
			this.btnXemPN.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnXemPN.Location = new Point(6, 44);
			this.btnXemPN.Name = "btnXemPN";
			this.btnXemPN.Size = new Size(105, 60);
			this.btnXemPN.TabIndex = 7;
			this.btnXemPN.Text = "   Xem";
			this.btnXemPN.TextColor = Color.Black;
			this.btnXemPN.UseVisualStyleBackColor = false;
			this.btnXemPN.Click += new EventHandler(this.btnXemPN_Click);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.dgvDsPN);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Location = new Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1083, 825);
			this.panel1.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Times New Roman", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = SystemColors.Desktop;
			this.label1.Location = new Point(19, 263);
			this.label1.Name = "label1";
			this.label1.Size = new Size(275, 31);
			this.label1.TabIndex = 171;
			this.label1.Text = "Danh sách phiếu nhập";
			this.panel2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel2.BackColor = Color.Black;
			this.panel2.Location = new Point(-4, 243);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(1087, 4);
			this.panel2.TabIndex = 170;
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Location = new Point(530, -4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(553, 247);
			this.panel3.TabIndex = 169;
			this.panel4.BackColor = SystemColors.InactiveBorder;
			this.panel4.Controls.Add(groupBox);
			this.panel4.Location = new Point(0, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(552, 244);
			this.panel4.TabIndex = 6;
			this.dgvDsPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDsPN.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvDsPN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvDsPN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDsPN.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn3,
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewTextBoxColumn5,
				this.dataGridViewTextBoxColumn6,
				this.dataGridViewTextBoxColumn7,
				this.dataGridViewTextBoxColumn8,
				this.dataGridViewTextBoxColumn9
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dgvDsPN.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDsPN.Location = new Point(-4, 296);
			this.dgvDsPN.Margin = new Padding(2);
			this.dgvDsPN.Name = "dgvDsPN";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvDsPN.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvDsPN.RowHeadersWidth = 62;
			this.dgvDsPN.RowTemplate.Height = 50;
			this.dgvDsPN.Size = new Size(1087, 529);
			this.dgvDsPN.TabIndex = 10;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "IDPN";
			this.dataGridViewTextBoxColumn1.FillWeight = 200f;
			this.dataGridViewTextBoxColumn1.HeaderText = "ID phiếu nhập";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 128;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "NgayTaoPN";
			dataGridViewCellStyle4.Format = "dd/MM/yyyy hh:mm:ss";
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn2.HeaderText = "Ngày lập phiếu nhập";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 138;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "ThanhToanNXB";
			this.dataGridViewTextBoxColumn3.FillWeight = 200f;
			this.dataGridViewTextBoxColumn3.HeaderText = "Thanh toán";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 109;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "TrangThai";
			this.dataGridViewTextBoxColumn4.HeaderText = "Trạng thái";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn5.DataPropertyName = "ThanhTienN";
			this.dataGridViewTextBoxColumn5.HeaderText = "Thành tiền ";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Visible = false;
			this.dataGridViewTextBoxColumn5.Width = 108;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "NXBGiam";
			this.dataGridViewTextBoxColumn6.HeaderText = "Giảm";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Visible = false;
			this.dataGridViewTextBoxColumn6.Width = 75;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "IDNXB";
			this.dataGridViewTextBoxColumn7.HeaderText = "ID nhà xuất bản";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Width = 115;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "TenNXB";
			this.dataGridViewTextBoxColumn8.HeaderText = "Tền nhà xuất bản";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Width = 124;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "SDTNXB";
			this.dataGridViewTextBoxColumn9.HeaderText = "Số điện thoại nhà xuất bản";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Width = 154;
			this.groupBox3.BackColor = SystemColors.ActiveCaption;
			this.groupBox3.Controls.Add(this.cbxTrangThai);
			this.groupBox3.Controls.Add(this.chkTrangThai);
			this.groupBox3.Controls.Add(this.dtpNLPN);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.chkTenNXB);
			this.groupBox3.Controls.Add(this.chkNL);
			this.groupBox3.Controls.Add(this.cbxChonNhaXuatBan);
			this.groupBox3.Controls.Add(this.txtIDNXB1);
			this.groupBox3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox3.Location = new Point(-4, -1);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(538, 244);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tìm phiếu nhập";
			this.cbxTrangThai.DisplayMember = "Chờ";
			this.cbxTrangThai.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxTrangThai.FormattingEnabled = true;
			this.cbxTrangThai.IntegralHeight = false;
			this.cbxTrangThai.Items.AddRange(new object[]
			{
				"Chờ",
				"Đồng ý",
				"Không đồng ý"
			});
			this.cbxTrangThai.Location = new Point(256, 121);
			this.cbxTrangThai.Name = "cbxTrangThai";
			this.cbxTrangThai.Size = new Size(243, 29);
			this.cbxTrangThai.TabIndex = 3;
			this.cbxTrangThai.SelectedIndexChanged += new EventHandler(this.cbxTrangThai_SelectedIndexChanged_1);
			this.chkTrangThai.AutoSize = true;
			this.chkTrangThai.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkTrangThai.Location = new Point(23, 125);
			this.chkTrangThai.Name = "chkTrangThai";
			this.chkTrangThai.Size = new Size(227, 25);
			this.chkTrangThai.TabIndex = 2;
			this.chkTrangThai.Text = "Theo trạng thái phiếu nhập";
			this.chkTrangThai.UseVisualStyleBackColor = true;
			this.chkTrangThai.CheckedChanged += new EventHandler(this.chkTrangThai_CheckedChanged_1);
			this.dtpNLPN.CustomFormat = "dd/MM/yyyy";
			this.dtpNLPN.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpNLPN.Format = DateTimePickerFormat.Custom;
			this.dtpNLPN.Location = new Point(256, 174);
			this.dtpNLPN.Name = "dtpNLPN";
			this.dtpNLPN.Size = new Size(245, 29);
			this.dtpNLPN.TabIndex = 5;
			this.dtpNLPN.ValueChanged += new EventHandler(this.dtpNLPN_ValueChanged_1);
			this.label18.AutoSize = true;
			this.label18.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label18.Location = new Point(25, 80);
			this.label18.Name = "label18";
			this.label18.Size = new Size(72, 21);
			this.label18.TabIndex = 155;
			this.label18.Text = "ID NXB";
			this.chkTenNXB.AutoSize = true;
			this.chkTenNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkTenNXB.Location = new Point(29, 32);
			this.chkTenNXB.Name = "chkTenNXB";
			this.chkTenNXB.Size = new Size(194, 25);
			this.chkTenNXB.TabIndex = 0;
			this.chkTenNXB.Text = "Theo tên nhà xuất bản";
			this.chkTenNXB.UseVisualStyleBackColor = true;
			this.chkTenNXB.CheckedChanged += new EventHandler(this.chkTenNXB_CheckedChanged);
			this.chkNL.AutoSize = true;
			this.chkNL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkNL.Location = new Point(23, 174);
			this.chkNL.Name = "chkNL";
			this.chkNL.Size = new Size(221, 25);
			this.chkNL.TabIndex = 4;
			this.chkNL.Text = "Theo ngày lập phiếu nhập";
			this.chkNL.UseVisualStyleBackColor = true;
			this.chkNL.CheckedChanged += new EventHandler(this.chkNL_CheckedChanged_1);
			this.cbxChonNhaXuatBan.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxChonNhaXuatBan.FormattingEnabled = true;
			this.cbxChonNhaXuatBan.IntegralHeight = false;
			this.cbxChonNhaXuatBan.Location = new Point(258, 28);
			this.cbxChonNhaXuatBan.Name = "cbxChonNhaXuatBan";
			this.cbxChonNhaXuatBan.Size = new Size(243, 29);
			this.cbxChonNhaXuatBan.TabIndex = 1;
			this.cbxChonNhaXuatBan.SelectedIndexChanged += new EventHandler(this.cbxChonNhaXuatBan_SelectedIndexChanged_1);
			this.txtIDNXB1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNXB1.Location = new Point(258, 72);
			this.txtIDNXB1.Name = "txtIDNXB1";
			this.txtIDNXB1.ReadOnly = true;
			this.txtIDNXB1.Size = new Size(243, 29);
			this.txtIDNXB1.TabIndex = 150;
			this.txtIDNXB1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1088, 829);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "QL_XacNhanPN";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "XÁC NHẬN PHIẾU NHẬP";
			base.Load += new EventHandler(this.QL_XacNhanPN_Load);
			base.KeyUp += new KeyEventHandler(this.QL_XacNhanPN_KeyUp);
			groupBox.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((ISupportInitialize)this.dgvDsPN).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
