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
	public class NV_XemHoaDon : Form
	{
		private CXuLyHoaDon xulyHD;
		private CXuLyNV xulyNV;
		private List<CHoaDon> t;
		private IContainer components = null;
		private DataGridView dgvDsHD;
		private TextBox txtSDTKH;
		private ComboBox cbxChonNhanVien;
		private TextBox txtIDNV;
		private CheckBox chkSDTKH;
		private CheckBox chkTenNV;
		private Label label2;
		private DateTimePicker dtpNLHD;
		private CheckBox chkNL;
		private GroupBox groupBox1;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column8;
		private DataGridViewTextBoxColumn Column7;
		private DataGridViewTextBoxColumn Column14;
		private DataGridViewTextBoxColumn Column15;
		private DataGridViewTextBoxColumn Column16;
		private DataGridViewTextBoxColumn Column9;
		private DataGridViewTextBoxColumn Column17;
		private DataGridViewTextBoxColumn Column13;
		private DataGridViewTextBoxColumn Column18;
		private DataGridViewTextBoxColumn Column19;
		private Panel panel2;
		private Panel panel1;
		private Panel panel3;
		private Panel panel4;
		private VBButton btnXemHD;
		private Label label16;
		public NV_XemHoaDon()
		{
			this.InitializeComponent();
		}
		private void hienthiDSHoadon(List<CHoaDon> ds)
		{
			bool flag = !this.chkSDTKH.Checked && !this.chkTenNV.Checked && !this.chkNL.Checked;
			if (flag)
			{
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = ds;
				this.dgvDsHD.DataSource = bindingSource;
			}
			else
			{
				bool flag2 = this.chkSDTKH.Checked && !this.chkTenNV.Checked && !this.chkNL.Checked;
				if (flag2)
				{
					this.t = new List<CHoaDon>();
					foreach (CHoaDon current in ds)
					{
						bool flag3 = current.SDTKH == this.txtSDTKH.Text;
						if (flag3)
						{
							this.t.Add(current);
						}
					}
					BindingSource bindingSource2 = new BindingSource();
					bindingSource2.DataSource = this.t;
					this.dgvDsHD.DataSource = bindingSource2;
					bool flag4 = this.t.Count == 0;
					if (flag4)
					{
						MessageBox.Show("Không có hóa đơn nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					bool flag5 = !this.chkSDTKH.Checked && this.chkTenNV.Checked && !this.chkNL.Checked;
					if (flag5)
					{
						this.t = new List<CHoaDon>();
						foreach (CHoaDon current2 in ds)
						{
							bool flag6 = current2.IDNguoiTao == this.txtIDNV.Text;
							if (flag6)
							{
								this.t.Add(current2);
							}
						}
						BindingSource bindingSource3 = new BindingSource();
						bindingSource3.DataSource = this.t;
						this.dgvDsHD.DataSource = bindingSource3;
						bool flag7 = this.t.Count == 0;
						if (flag7)
						{
							MessageBox.Show("Không có hóa đơn nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						bool flag8 = !this.chkSDTKH.Checked && !this.chkTenNV.Checked && this.chkNL.Checked;
						if (flag8)
						{
							this.t = new List<CHoaDon>();
							foreach (CHoaDon current3 in ds)
							{
								bool flag9 = current3.NgayTaoHD.Year == this.dtpNLHD.Value.Year && current3.NgayTaoHD.Month == this.dtpNLHD.Value.Month && current3.NgayTaoHD.Day == this.dtpNLHD.Value.Day;
								if (flag9)
								{
									this.t.Add(current3);
								}
							}
							BindingSource bindingSource4 = new BindingSource();
							bindingSource4.DataSource = this.t;
							this.dgvDsHD.DataSource = bindingSource4;
							bool flag10 = this.t.Count == 0;
							if (flag10)
							{
								MessageBox.Show("Không có hóa đơn nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							bool flag11 = this.chkSDTKH.Checked && this.chkTenNV.Checked && !this.chkNL.Checked;
							if (flag11)
							{
								this.t = new List<CHoaDon>();
								foreach (CHoaDon current4 in ds)
								{
									bool flag12 = current4.SDTKH == this.txtSDTKH.Text && current4.IDNguoiTao == this.txtIDNV.Text;
									if (flag12)
									{
										this.t.Add(current4);
									}
								}
								BindingSource bindingSource5 = new BindingSource();
								bindingSource5.DataSource = this.t;
								this.dgvDsHD.DataSource = bindingSource5;
								bool flag13 = this.t.Count == 0;
								if (flag13)
								{
									MessageBox.Show("Không có hóa đơn nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								bool flag14 = this.chkSDTKH.Checked && !this.chkTenNV.Checked && this.chkNL.Checked;
								if (flag14)
								{
									this.t = new List<CHoaDon>();
									foreach (CHoaDon current5 in ds)
									{
										bool flag15 = current5.SDTKH == this.txtSDTKH.Text && current5.NgayTaoHD.Year == this.dtpNLHD.Value.Year && current5.NgayTaoHD.Month == this.dtpNLHD.Value.Month && current5.NgayTaoHD.Day == this.dtpNLHD.Value.Day;
										if (flag15)
										{
											this.t.Add(current5);
										}
									}
									BindingSource bindingSource6 = new BindingSource();
									bindingSource6.DataSource = this.t;
									this.dgvDsHD.DataSource = bindingSource6;
									bool flag16 = this.t.Count == 0;
									if (flag16)
									{
										MessageBox.Show("Không có hóa đơn nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
								}
								else
								{
									bool flag17 = !this.chkSDTKH.Checked && this.chkTenNV.Checked && this.chkNL.Checked;
									if (flag17)
									{
										this.t = new List<CHoaDon>();
										foreach (CHoaDon current6 in ds)
										{
											bool flag18 = current6.IDNguoiTao == this.txtIDNV.Text && current6.NgayTaoHD.Year == this.dtpNLHD.Value.Year && current6.NgayTaoHD.Month == this.dtpNLHD.Value.Month && current6.NgayTaoHD.Day == this.dtpNLHD.Value.Day;
											if (flag18)
											{
												this.t.Add(current6);
											}
										}
										BindingSource bindingSource7 = new BindingSource();
										bindingSource7.DataSource = this.t;
										this.dgvDsHD.DataSource = bindingSource7;
										bool flag19 = this.t.Count == 0;
										if (flag19)
										{
											MessageBox.Show("Không có hóa đơn nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
									}
									else
									{
										bool flag20 = this.chkSDTKH.Checked && this.chkTenNV.Checked && this.chkNL.Checked;
										if (flag20)
										{
											this.t = new List<CHoaDon>();
											foreach (CHoaDon current7 in ds)
											{
												bool flag21 = current7.SDTKH == this.txtSDTKH.Text && current7.IDNguoiTao == this.txtIDNV.Text && current7.NgayTaoHD.Year == this.dtpNLHD.Value.Year && current7.NgayTaoHD.Month == this.dtpNLHD.Value.Month && current7.NgayTaoHD.Day == this.dtpNLHD.Value.Day;
												if (flag21)
												{
													this.t.Add(current7);
												}
											}
											BindingSource bindingSource8 = new BindingSource();
											bindingSource8.DataSource = this.t;
											this.dgvDsHD.DataSource = bindingSource8;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void hienthiComboBoxNV(List<CNhanVien> ds)
		{
			this.cbxChonNhanVien.DisplayMember = "TenNV";
			this.cbxChonNhanVien.ValueMember = "TenNV";
			this.cbxChonNhanVien.DataSource = ds;
		}
		private void XemHoaDon_Load(object sender, EventArgs e)
		{
			this.xulyNV = new CXuLyNV();
			bool flag = !this.xulyNV.docFile("DSNhanVien.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhanVien.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiComboBoxNV(this.xulyNV.getDSNV());
			}
			this.xulyHD = new CXuLyHoaDon();
			bool flag2 = !this.xulyHD.docFile("DSHoaDon.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSHoaDon.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiDSHoadon(this.xulyHD.getDSHoaDon());
			}
			base.KeyPreview = true;
		}
		private void cbxChonNhanVien_SelectedIndexChanged(object sender, EventArgs e)
		{
			string b = this.cbxChonNhanVien.SelectedValue.ToString();
			foreach (CNhanVien current in this.xulyNV.getDSNV())
			{
				bool flag = current.TenNV == b;
				if (flag)
				{
					this.txtIDNV.Text = current.IDNV;
				}
			}
		}
		private void chkSDTKH_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkSDTKH.Checked;
			if (@checked)
			{
				this.txtSDTKH.ReadOnly = true;
			}
			else
			{
				this.txtSDTKH.ReadOnly = false;
			}
			this.hienthiDSHoadon(this.xulyHD.getDSHoaDon());
		}
		private void chkTenNV_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkTenNV.Checked;
			if (@checked)
			{
				this.cbxChonNhanVien.Enabled = false;
			}
			else
			{
				this.cbxChonNhanVien.Enabled = true;
			}
			this.hienthiDSHoadon(this.xulyHD.getDSHoaDon());
		}
		private void chkNL_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiDSHoadon(this.xulyHD.getDSHoaDon());
		}
		private void btnXemHD_Click(object sender, EventArgs e)
		{
			IEnumerator enumerator = this.dgvDsHD.SelectedRows.GetEnumerator();
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
						string iDHoaDon = dataGridViewRow.Cells[0].Value.ToString();
						CHoaDon hoadon = this.xulyHD.tim(iDHoaDon);
						new NV_XemChiTietHoaDon
						{
							hoadon = hoadon
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
		private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void XemHoaDon_KeyUp(object sender, KeyEventArgs e)
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
		private void XemHoaDon_FormClosed(object sender, FormClosedEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NV_XemHoaDon));
			this.dgvDsHD = new DataGridView();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.Column14 = new DataGridViewTextBoxColumn();
			this.Column15 = new DataGridViewTextBoxColumn();
			this.Column16 = new DataGridViewTextBoxColumn();
			this.Column9 = new DataGridViewTextBoxColumn();
			this.Column17 = new DataGridViewTextBoxColumn();
			this.Column13 = new DataGridViewTextBoxColumn();
			this.Column18 = new DataGridViewTextBoxColumn();
			this.Column19 = new DataGridViewTextBoxColumn();
			this.txtSDTKH = new TextBox();
			this.cbxChonNhanVien = new ComboBox();
			this.txtIDNV = new TextBox();
			this.chkSDTKH = new CheckBox();
			this.chkTenNV = new CheckBox();
			this.label2 = new Label();
			this.dtpNLHD = new DateTimePicker();
			this.chkNL = new CheckBox();
			this.groupBox1 = new GroupBox();
			this.btnXemHD = new VBButton();
			this.panel2 = new Panel();
			this.panel1 = new Panel();
			this.panel3 = new Panel();
			this.panel4 = new Panel();
			this.label16 = new Label();
			((ISupportInitialize)this.dgvDsHD).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.dgvDsHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDsHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvDsHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvDsHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDsHD.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column6,
				this.Column8,
				this.Column7,
				this.Column14,
				this.Column15,
				this.Column16,
				this.Column9,
				this.Column17,
				this.Column13,
				this.Column18,
				this.Column19
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dgvDsHD.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDsHD.Location = new Point(2, 290);
			this.dgvDsHD.Margin = new Padding(2);
			this.dgvDsHD.Name = "dgvDsHD";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvDsHD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvDsHD.RowHeadersWidth = 62;
			this.dgvDsHD.RowTemplate.Height = 50;
			this.dgvDsHD.Size = new Size(998, 508);
			this.dgvDsHD.TabIndex = 7;
			this.Column6.DataPropertyName = "IDHoaDon";
			this.Column6.FillWeight = 200f;
			this.Column6.HeaderText = "ID hóa đơn";
			this.Column6.Name = "Column6";
			this.Column6.Width = 110;
			this.Column8.DataPropertyName = "NgayTaoHD";
			dataGridViewCellStyle4.Format = "dd/MM/yyyy";
			this.Column8.DefaultCellStyle = dataGridViewCellStyle4;
			this.Column8.HeaderText = "Ngày lập hóa đơn";
			this.Column8.Name = "Column8";
			this.Column8.Width = 126;
			this.Column7.DataPropertyName = "ThanhToan";
			this.Column7.FillWeight = 200f;
			this.Column7.HeaderText = "Thanh toán";
			this.Column7.Name = "Column7";
			this.Column7.Width = 109;
			this.Column14.DataPropertyName = "ThanhTien";
			this.Column14.HeaderText = "Thành tiền";
			this.Column14.Name = "Column14";
			this.Column14.Visible = false;
			this.Column14.Width = 96;
			this.Column15.DataPropertyName = "Giam";
			this.Column15.HeaderText = "Giảm";
			this.Column15.Name = "Column15";
			this.Column15.Visible = false;
			this.Column15.Width = 71;
			this.Column16.DataPropertyName = "IDNguoiTao";
			this.Column16.HeaderText = "ID nhân viên";
			this.Column16.Name = "Column16";
			this.Column16.Visible = false;
			this.Column16.Width = 108;
			this.Column9.DataPropertyName = "TenNguoiTao";
			this.Column9.HeaderText = "Tên nhân viên";
			this.Column9.Name = "Column9";
			this.Column9.Width = 127;
			this.Column17.DataPropertyName = "SDTNguoiTao";
			this.Column17.HeaderText = "SDT nhân viên";
			this.Column17.Name = "Column17";
			this.Column17.Visible = false;
			this.Column17.Width = 120;
			this.Column13.DataPropertyName = "TenKH";
			this.Column13.HeaderText = "Tên khách hàng";
			this.Column13.Name = "Column13";
			this.Column13.Width = 140;
			this.Column18.DataPropertyName = "SDTKH";
			this.Column18.HeaderText = "SDT KH";
			this.Column18.Name = "Column18";
			this.Column18.Width = 94;
			this.Column19.DataPropertyName = "DiaChiKH";
			this.Column19.HeaderText = "Địa Chỉ KH";
			this.Column19.Name = "Column19";
			this.Column19.Visible = false;
			this.Column19.Width = 105;
			this.txtSDTKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTKH.Location = new Point(327, 151);
			this.txtSDTKH.MaxLength = 10;
			this.txtSDTKH.Name = "txtSDTKH";
			this.txtSDTKH.Size = new Size(387, 29);
			this.txtSDTKH.TabIndex = 4;
			this.txtSDTKH.KeyPress += new KeyPressEventHandler(this.txtSDTKH_KeyPress);
			this.cbxChonNhanVien.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxChonNhanVien.FormattingEnabled = true;
			this.cbxChonNhanVien.IntegralHeight = false;
			this.cbxChonNhanVien.Location = new Point(327, 39);
			this.cbxChonNhanVien.Name = "cbxChonNhanVien";
			this.cbxChonNhanVien.Size = new Size(387, 29);
			this.cbxChonNhanVien.TabIndex = 2;
			this.cbxChonNhanVien.SelectedIndexChanged += new EventHandler(this.cbxChonNhanVien_SelectedIndexChanged);
			this.txtIDNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNV.Location = new Point(327, 89);
			this.txtIDNV.Name = "txtIDNV";
			this.txtIDNV.ReadOnly = true;
			this.txtIDNV.Size = new Size(387, 29);
			this.txtIDNV.TabIndex = 137;
			this.txtIDNV.TabStop = false;
			this.chkSDTKH.AutoSize = true;
			this.chkSDTKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkSDTKH.Location = new Point(7, 151);
			this.chkSDTKH.Name = "chkSDTKH";
			this.chkSDTKH.Size = new Size(206, 25);
			this.chkSDTKH.TabIndex = 3;
			this.chkSDTKH.Text = "Theo SDT Khách Hàng";
			this.chkSDTKH.UseVisualStyleBackColor = true;
			this.chkSDTKH.CheckedChanged += new EventHandler(this.chkSDTKH_CheckedChanged);
			this.chkTenNV.AutoSize = true;
			this.chkTenNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkTenNV.Location = new Point(7, 41);
			this.chkTenNV.Name = "chkTenNV";
			this.chkTenNV.Size = new Size(170, 25);
			this.chkTenNV.TabIndex = 1;
			this.chkTenNV.Text = "Theo tên nhân viên";
			this.chkTenNV.UseVisualStyleBackColor = true;
			this.chkTenNV.CheckedChanged += new EventHandler(this.chkTenNV_CheckedChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(41, 92);
			this.label2.Name = "label2";
			this.label2.Size = new Size(104, 21);
			this.label2.TabIndex = 148;
			this.label2.Text = "ID nhân viên";
			this.dtpNLHD.CalendarFont = new Font("Microsoft Sans Serif", 17f);
			this.dtpNLHD.CustomFormat = "dd/MM/yyyy";
			this.dtpNLHD.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpNLHD.Format = DateTimePickerFormat.Custom;
			this.dtpNLHD.Location = new Point(327, 198);
			this.dtpNLHD.Name = "dtpNLHD";
			this.dtpNLHD.Size = new Size(273, 29);
			this.dtpNLHD.TabIndex = 6;
			this.chkNL.AutoSize = true;
			this.chkNL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkNL.Location = new Point(7, 202);
			this.chkNL.Name = "chkNL";
			this.chkNL.Size = new Size(201, 25);
			this.chkNL.TabIndex = 5;
			this.chkNL.Text = "Theo ngày lập hóa đơn";
			this.chkNL.UseVisualStyleBackColor = true;
			this.chkNL.CheckedChanged += new EventHandler(this.chkNL_CheckedChanged);
			this.groupBox1.BackColor = SystemColors.ActiveCaption;
			this.groupBox1.Controls.Add(this.btnXemHD);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.chkNL);
			this.groupBox1.Controls.Add(this.dtpNLHD);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.chkTenNV);
			this.groupBox1.Controls.Add(this.chkSDTKH);
			this.groupBox1.Controls.Add(this.cbxChonNhanVien);
			this.groupBox1.Controls.Add(this.txtIDNV);
			this.groupBox1.Controls.Add(this.txtSDTKH);
			this.groupBox1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(1, -2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(994, 241);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tìm hóa đơn";
			this.btnXemHD.BackColor = SystemColors.ButtonHighlight;
			this.btnXemHD.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnXemHD.BorderColor = Color.PaleVioletRed;
			this.btnXemHD.BorderRadius = 5;
			this.btnXemHD.BorderSize = 0;
			this.btnXemHD.FlatAppearance.BorderSize = 0;
			this.btnXemHD.FlatStyle = FlatStyle.Flat;
			this.btnXemHD.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXemHD.ForeColor = Color.Black;
			this.btnXemHD.Image = Resources.searchmagnifierinterfacesymbol1_798933;
			this.btnXemHD.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnXemHD.Location = new Point(801, 89);
			this.btnXemHD.Name = "btnXemHD";
			this.btnXemHD.Size = new Size(111, 70);
			this.btnXemHD.TabIndex = 8;
			this.btnXemHD.Text = "  Xem";
			this.btnXemHD.TextColor = Color.Black;
			this.btnXemHD.UseVisualStyleBackColor = false;
			this.btnXemHD.Click += new EventHandler(this.btnXemHD_Click);
			this.panel2.Location = new Point(3, 243);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(1229, 48);
			this.panel2.TabIndex = 150;
			this.panel1.Location = new Point(4, 243);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(744, 49);
			this.panel1.TabIndex = 149;
			this.panel3.BackColor = Color.Black;
			this.panel3.Location = new Point(2, 241);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(999, 4);
			this.panel3.TabIndex = 160;
			this.panel4.BackColor = Color.White;
			this.panel4.BorderStyle = BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.label16);
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Controls.Add(this.dgvDsHD);
			this.panel4.Controls.Add(this.panel3);
			this.panel4.Location = new Point(1, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(997, 804);
			this.panel4.TabIndex = 161;
			this.label16.AutoSize = true;
			this.label16.BackColor = Color.Transparent;
			this.label16.Font = new Font("Times New Roman", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label16.ForeColor = SystemColors.Desktop;
			this.label16.Location = new Point(9, 262);
			this.label16.Name = "label16";
			this.label16.Size = new Size(206, 26);
			this.label16.TabIndex = 166;
			this.label16.Text = "Danh sách hóa đơn";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			base.ClientSize = new Size(1000, 805);
			base.Controls.Add(this.panel4);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NV_XemHoaDon";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "XEM HÓA ĐƠN";
			base.FormClosed += new FormClosedEventHandler(this.XemHoaDon_FormClosed);
			base.Load += new EventHandler(this.XemHoaDon_Load);
			base.KeyUp += new KeyEventHandler(this.XemHoaDon_KeyUp);
			((ISupportInitialize)this.dgvDsHD).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
