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
	public class NXB_XemPhieuNhap : Form
	{
		private CXuLyPhieuNhap xulyPhieuNhap;
		private List<CPhieuNhap> dsPNNXB;
		private IContainer components = null;
		private DataGridView dgvDsPN;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn Column16;
		private DataGridViewTextBoxColumn Column14;
		private DataGridViewTextBoxColumn Column15;
		private DataGridViewTextBoxColumn Column9;
		private DataGridViewTextBoxColumn Column17;
		private DataGridViewTextBoxColumn Column13;
		private GroupBox groupBox1;
		private DateTimePicker dtpNL;
		private ComboBox cbxTrangThai;
		private CheckBox chkTrangThai;
		private CheckBox chkNL;
		private Panel panel4;
		private Panel panel1;
		private Panel panel2;
		private VBButton btnXemPN;
		private Label label1;
		public NXB_XemPhieuNhap()
		{
			this.InitializeComponent();
		}
		private void XemPN_Load(object sender, EventArgs e)
		{
			this.xulyPhieuNhap = new CXuLyPhieuNhap();
			bool flag = !this.xulyPhieuNhap.docFile("DSPhieuNhap.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSPhieuNhap.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
			}
			base.KeyPreview = true;
		}
		private void hienthiDSPhieuNhap(List<CPhieuNhap> ds)
		{
			bool flag = this.chkNL.Checked && !this.chkTrangThai.Checked;
			if (flag)
			{
				this.dsPNNXB = new List<CPhieuNhap>();
				foreach (CPhieuNhap current in ds)
				{
					bool flag2 = current.IDNXB == CConst.NhaXuatBan.IDNXB && (current.NgayTaoPN.Year == this.dtpNL.Value.Year && current.NgayTaoPN.Month == this.dtpNL.Value.Month) && current.NgayTaoPN.Day == this.dtpNL.Value.Day;
					if (flag2)
					{
						this.dsPNNXB.Add(current);
					}
				}
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = this.dsPNNXB;
				this.dgvDsPN.DataSource = bindingSource;
				bool flag3 = this.dsPNNXB.Count == 0;
				if (flag3)
				{
					MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool flag4 = !this.chkNL.Checked && this.chkTrangThai.Checked;
			if (flag4)
			{
				this.dsPNNXB = new List<CPhieuNhap>();
				foreach (CPhieuNhap current2 in ds)
				{
					bool flag5 = current2.IDNXB == CConst.NhaXuatBan.IDNXB && current2.TrangThai == this.cbxTrangThai.Text.ToString();
					if (flag5)
					{
						this.dsPNNXB.Add(current2);
					}
				}
				BindingSource bindingSource2 = new BindingSource();
				bindingSource2.DataSource = this.dsPNNXB;
				this.dgvDsPN.DataSource = bindingSource2;
				bool flag6 = this.dsPNNXB.Count == 0;
				if (flag6)
				{
					MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool flag7 = this.chkNL.Checked && this.chkTrangThai.Checked;
			if (flag7)
			{
				this.dsPNNXB = new List<CPhieuNhap>();
				foreach (CPhieuNhap current3 in ds)
				{
					bool flag8 = current3.IDNXB == CConst.NhaXuatBan.IDNXB && current3.NgayTaoPN.Year == this.dtpNL.Value.Year && current3.NgayTaoPN.Month == this.dtpNL.Value.Month && current3.NgayTaoPN.Day == this.dtpNL.Value.Day && current3.TrangThai == this.cbxTrangThai.Text.ToString();
					if (flag8)
					{
						this.dsPNNXB.Add(current3);
					}
				}
				BindingSource bindingSource3 = new BindingSource();
				bindingSource3.DataSource = this.dsPNNXB;
				this.dgvDsPN.DataSource = bindingSource3;
				bool flag9 = this.dsPNNXB.Count == 0;
				if (flag9)
				{
					MessageBox.Show("Không có phiếu nhập nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool flag10 = !this.chkNL.Checked && !this.chkTrangThai.Checked;
			if (flag10)
			{
				this.dsPNNXB = new List<CPhieuNhap>();
				foreach (CPhieuNhap current4 in ds)
				{
					bool flag11 = current4.IDNXB == CConst.NhaXuatBan.IDNXB;
					if (flag11)
					{
						this.dsPNNXB.Add(current4);
					}
				}
				BindingSource bindingSource4 = new BindingSource();
				bindingSource4.DataSource = this.dsPNNXB;
				this.dgvDsPN.DataSource = bindingSource4;
			}
		}
		private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void chkNL_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void cbxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.hienthiDSPhieuNhap(this.xulyPhieuNhap.getDSPhieuNhap());
		}
		private void dtpNL_ValueChanged(object sender, EventArgs e)
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
		private void XemPN_KeyUp(object sender, KeyEventArgs e)
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
		private void XemPN_FormClosed(object sender, FormClosedEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NXB_XemPhieuNhap));
			this.dgvDsPN = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.Column16 = new DataGridViewTextBoxColumn();
			this.Column14 = new DataGridViewTextBoxColumn();
			this.Column15 = new DataGridViewTextBoxColumn();
			this.Column9 = new DataGridViewTextBoxColumn();
			this.Column17 = new DataGridViewTextBoxColumn();
			this.Column13 = new DataGridViewTextBoxColumn();
			this.groupBox1 = new GroupBox();
			this.dtpNL = new DateTimePicker();
			this.cbxTrangThai = new ComboBox();
			this.chkTrangThai = new CheckBox();
			this.chkNL = new CheckBox();
			this.panel4 = new Panel();
			this.btnXemPN = new VBButton();
			this.panel1 = new Panel();
			this.label1 = new Label();
			this.panel2 = new Panel();
			((ISupportInitialize)this.dgvDsPN).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			this.dgvDsPN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dgvDsPN.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvDsPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDsPN.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			this.dgvDsPN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDsPN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDsPN.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn3,
				this.Column16,
				this.Column14,
				this.Column15,
				this.Column9,
				this.Column17,
				this.Column13
			});
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			this.dgvDsPN.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvDsPN.Location = new Point(2, 281);
			this.dgvDsPN.Margin = new Padding(2);
			this.dgvDsPN.Name = "dgvDsPN";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dgvDsPN.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvDsPN.RowHeadersWidth = 62;
			this.dgvDsPN.RowTemplate.Height = 50;
			this.dgvDsPN.Size = new Size(942, 482);
			this.dgvDsPN.TabIndex = 5;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "IDPN";
			this.dataGridViewTextBoxColumn1.FillWeight = 200f;
			this.dataGridViewTextBoxColumn1.HeaderText = "ID phiếu nhập";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 128;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "NgayTaoPN";
			dataGridViewCellStyle5.Format = "dd/MM/yyyy hh:mm:ss";
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewTextBoxColumn2.HeaderText = "Ngày lập phiếu nhập";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 138;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "ThanhToanNXB";
			this.dataGridViewTextBoxColumn3.FillWeight = 200f;
			this.dataGridViewTextBoxColumn3.HeaderText = "Thanh toán";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 109;
			this.Column16.DataPropertyName = "TrangThai";
			this.Column16.HeaderText = "Trạng thái";
			this.Column16.Name = "Column16";
			this.Column14.DataPropertyName = "ThanhTienN";
			this.Column14.HeaderText = "Thành tiền ";
			this.Column14.Name = "Column14";
			this.Column14.Visible = false;
			this.Column14.Width = 99;
			this.Column15.DataPropertyName = "NXBGiam";
			this.Column15.HeaderText = "Giảm";
			this.Column15.Name = "Column15";
			this.Column15.Visible = false;
			this.Column15.Width = 71;
			this.Column9.DataPropertyName = "IDNXB";
			this.Column9.HeaderText = "ID nhà xuất bản";
			this.Column9.Name = "Column9";
			this.Column9.Width = 115;
			this.Column17.DataPropertyName = "TenNXB";
			this.Column17.HeaderText = "Tên nhà xuất bản";
			this.Column17.Name = "Column17";
			this.Column17.Width = 124;
			this.Column13.DataPropertyName = "SDTNXB";
			this.Column13.HeaderText = "Số điện thoại nhà xuất bản";
			this.Column13.Name = "Column13";
			this.Column13.Width = 154;
			this.groupBox1.BackColor = SystemColors.ActiveCaption;
			this.groupBox1.Controls.Add(this.dtpNL);
			this.groupBox1.Controls.Add(this.cbxTrangThai);
			this.groupBox1.Controls.Add(this.chkTrangThai);
			this.groupBox1.Controls.Add(this.chkNL);
			this.groupBox1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(3, 34);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(622, 148);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tìm phiếu nhập";
			this.dtpNL.CustomFormat = "dd/MM/yyyy";
			this.dtpNL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpNL.Format = DateTimePickerFormat.Custom;
			this.dtpNL.Location = new Point(312, 79);
			this.dtpNL.Name = "dtpNL";
			this.dtpNL.Size = new Size(273, 29);
			this.dtpNL.TabIndex = 4;
			this.dtpNL.ValueChanged += new EventHandler(this.dtpNL_ValueChanged);
			this.cbxTrangThai.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxTrangThai.FormattingEnabled = true;
			this.cbxTrangThai.IntegralHeight = false;
			this.cbxTrangThai.Items.AddRange(new object[]
			{
				"Chờ",
				"Đồng ý",
				"Không đồng ý"
			});
			this.cbxTrangThai.Location = new Point(312, 29);
			this.cbxTrangThai.Name = "cbxTrangThai";
			this.cbxTrangThai.Size = new Size(273, 29);
			this.cbxTrangThai.TabIndex = 2;
			this.cbxTrangThai.SelectedIndexChanged += new EventHandler(this.cbxTrangThai_SelectedIndexChanged);
			this.chkTrangThai.AutoSize = true;
			this.chkTrangThai.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkTrangThai.Location = new Point(12, 31);
			this.chkTrangThai.Name = "chkTrangThai";
			this.chkTrangThai.Size = new Size(227, 25);
			this.chkTrangThai.TabIndex = 1;
			this.chkTrangThai.Text = "Theo trạng thái phiếu nhập";
			this.chkTrangThai.UseVisualStyleBackColor = true;
			this.chkTrangThai.CheckedChanged += new EventHandler(this.chkTrangThai_CheckedChanged);
			this.chkNL.AutoSize = true;
			this.chkNL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkNL.Location = new Point(12, 87);
			this.chkNL.Name = "chkNL";
			this.chkNL.Size = new Size(221, 25);
			this.chkNL.TabIndex = 3;
			this.chkNL.Text = "Theo ngày lập phiếu nhập";
			this.chkNL.UseVisualStyleBackColor = true;
			this.chkNL.CheckedChanged += new EventHandler(this.chkNL_CheckedChanged);
			this.panel4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel4.BackColor = SystemColors.ActiveBorder;
			this.panel4.Controls.Add(this.btnXemPN);
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Location = new Point(1, -2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(942, 238);
			this.panel4.TabIndex = 1;
			this.btnXemPN.BackColor = SystemColors.ButtonHighlight;
			this.btnXemPN.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnXemPN.BorderColor = Color.PaleVioletRed;
			this.btnXemPN.BorderRadius = 5;
			this.btnXemPN.BorderSize = 0;
			this.btnXemPN.FlatAppearance.BorderSize = 0;
			this.btnXemPN.FlatStyle = FlatStyle.Flat;
			this.btnXemPN.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXemPN.ForeColor = Color.Black;
			this.btnXemPN.Image = Resources.searchmagnifierinterfacesymbol1_798933;
			this.btnXemPN.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnXemPN.Location = new Point(731, 72);
			this.btnXemPN.Name = "btnXemPN";
			this.btnXemPN.Size = new Size(111, 70);
			this.btnXemPN.TabIndex = 6;
			this.btnXemPN.Text = "  Xem";
			this.btnXemPN.TextColor = Color.Black;
			this.btnXemPN.UseVisualStyleBackColor = false;
			this.btnXemPN.Click += new EventHandler(this.btnXemPN_Click);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.dgvDsPN);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Location = new Point(-2, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(946, 752);
			this.panel1.TabIndex = 165;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Times New Roman", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = SystemColors.Desktop;
			this.label1.Location = new Point(10, 248);
			this.label1.Name = "label1";
			this.label1.Size = new Size(275, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Danh sách phiếu nhập";
			this.panel2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel2.BackColor = Color.Black;
			this.panel2.Location = new Point(1, 235);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(942, 4);
			this.panel2.TabIndex = 165;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(944, 753);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "NXB_XemPhieuNhap";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "XEM PHIẾU NHẬP";
			base.FormClosed += new FormClosedEventHandler(this.XemPN_FormClosed);
			base.Load += new EventHandler(this.XemPN_Load);
			base.KeyUp += new KeyEventHandler(this.XemPN_KeyUp);
			((ISupportInitialize)this.dgvDsPN).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
