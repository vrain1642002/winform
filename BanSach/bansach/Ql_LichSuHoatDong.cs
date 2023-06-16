using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class Ql_LichSuHoatDong : Form
	{
		private CXuLyLichSuHD xuLyLichSuHD;
		private CXuLyNV xulyNV;
		private IContainer components = null;
		private Panel panel1;
		private DataGridView dgvHD;
		private Panel panel2;
		private Label label1;
		private GroupBox groupBox10;
		private CheckBox chkTenNV;
		private DateTimePicker dtpNHD;
		private CheckBox chkHD;
		private Label label33;
		private ComboBox cbxChonNhanVien;
		private TextBox txtIDNV1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
		public Ql_LichSuHoatDong()
		{
			this.InitializeComponent();
		}
		private void Ql_LichSuHoatDong_Load(object sender, EventArgs e)
		{
			this.xulyNV = new CXuLyNV();
			bool flag = !this.xulyNV.docFile("DSNhanVien.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhanVien.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiComboBoxchonNV(this.xulyNV.getDSNV());
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag2 = !this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiLichSuHD(this.xuLyLichSuHD.getDSLSHD());
			}
			base.KeyPreview = true;
		}
		private void hienthiComboBoxchonNV(List<CNhanVien> ds)
		{
			this.cbxChonNhanVien.DisplayMember = "TenNV";
			this.cbxChonNhanVien.ValueMember = "TenNV";
			this.cbxChonNhanVien.DataSource = ds;
		}
		private void hienthiLichSuHD(List<CLichSuHD> LichSuHD)
		{
			bool flag = !this.chkTenNV.Checked && !this.chkHD.Checked;
			if (flag)
			{
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = LichSuHD;
				this.dgvHD.DataSource = bindingSource;
			}
			bool flag2 = this.chkTenNV.Checked && !this.chkHD.Checked;
			if (flag2)
			{
				List<CLichSuHD> list = new List<CLichSuHD>();
				foreach (CLichSuHD current in LichSuHD)
				{
					bool flag3 = current.TenND == this.cbxChonNhanVien.Text;
					if (flag3)
					{
						list.Add(current);
					}
				}
				BindingSource bindingSource2 = new BindingSource();
				bindingSource2.DataSource = list;
				this.dgvHD.DataSource = bindingSource2;
				bool flag4 = list.Count == 0;
				if (flag4)
				{
					MessageBox.Show("Không có hoạt động nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				bool flag5 = !this.chkTenNV.Checked && this.chkHD.Checked;
				if (flag5)
				{
					List<CLichSuHD> list2 = new List<CLichSuHD>();
					foreach (CLichSuHD current2 in LichSuHD)
					{
						bool flag6 = current2.NHoatDong.Year == this.dtpNHD.Value.Year && current2.NHoatDong.Month == this.dtpNHD.Value.Month && current2.NHoatDong.Day == this.dtpNHD.Value.Day;
						if (flag6)
						{
							list2.Add(current2);
						}
					}
					BindingSource bindingSource3 = new BindingSource();
					bindingSource3.DataSource = list2;
					this.dgvHD.DataSource = bindingSource3;
					bool flag7 = list2.Count == 0;
					if (flag7)
					{
						MessageBox.Show("Không có hoạt động nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					bool flag8 = this.chkTenNV.Checked && this.chkHD.Checked;
					if (flag8)
					{
						List<CLichSuHD> list3 = new List<CLichSuHD>();
						foreach (CLichSuHD current3 in LichSuHD)
						{
							bool flag9 = current3.TenND == this.cbxChonNhanVien.Text && current3.NHoatDong.Year == this.dtpNHD.Value.Year && current3.NHoatDong.Month == this.dtpNHD.Value.Month && current3.NHoatDong.Day == this.dtpNHD.Value.Day;
							if (flag9)
							{
								list3.Add(current3);
							}
						}
						BindingSource bindingSource4 = new BindingSource();
						bindingSource4.DataSource = list3;
						this.dgvHD.DataSource = bindingSource4;
						bool flag10 = list3.Count == 0;
						if (flag10)
						{
							MessageBox.Show("Không có hoạt động nào thỏa điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
				}
			}
		}
		private void cbxChonNhanVien_SelectedIndexChanged(object sender, EventArgs e)
		{
			string b = this.cbxChonNhanVien.SelectedValue.ToString();
			foreach (CNhanVien current in this.xulyNV.getDSNV())
			{
				bool flag = current.TenNV == b;
				if (flag)
				{
					this.txtIDNV1.Text = current.IDNV;
				}
			}
			this.xuLyLichSuHD = new CXuLyLichSuHD();
			bool flag2 = this.xuLyLichSuHD.docFile("LichSuHD.dat");
			if (flag2)
			{
				this.hienthiLichSuHD(this.xuLyLichSuHD.getDSLSHD());
			}
		}
		private void chkTenNV_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiLichSuHD(this.xuLyLichSuHD.getDSLSHD());
		}
		private void chkHD_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiLichSuHD(this.xuLyLichSuHD.getDSLSHD());
		}
		private void dtpNHD_ValueChanged(object sender, EventArgs e)
		{
			this.hienthiLichSuHD(this.xuLyLichSuHD.getDSLSHD());
		}
		private void Ql_LichSuHoatDong_KeyUp(object sender, KeyEventArgs e)
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
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Ql_LichSuHoatDong));
			this.panel1 = new Panel();
			this.label1 = new Label();
			this.groupBox10 = new GroupBox();
			this.chkTenNV = new CheckBox();
			this.dtpNHD = new DateTimePicker();
			this.chkHD = new CheckBox();
			this.label33 = new Label();
			this.cbxChonNhanVien = new ComboBox();
			this.txtIDNV1 = new TextBox();
			this.panel2 = new Panel();
			this.dgvHD = new DataGridView();
			this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.groupBox10.SuspendLayout();
			((ISupportInitialize)this.dgvHD).BeginInit();
			base.SuspendLayout();
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.groupBox10);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.dgvHD);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(968, 741);
			this.panel1.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Times New Roman", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = SystemColors.Desktop;
			this.label1.Location = new Point(9, 247);
			this.label1.Name = "label1";
			this.label1.Size = new Size(195, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lịch sử hoạt động";
			this.groupBox10.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox10.BackColor = SystemColors.ActiveCaption;
			this.groupBox10.Controls.Add(this.chkTenNV);
			this.groupBox10.Controls.Add(this.dtpNHD);
			this.groupBox10.Controls.Add(this.chkHD);
			this.groupBox10.Controls.Add(this.label33);
			this.groupBox10.Controls.Add(this.cbxChonNhanVien);
			this.groupBox10.Controls.Add(this.txtIDNV1);
			this.groupBox10.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox10.Location = new Point(-2, 1);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new Size(968, 222);
			this.groupBox10.TabIndex = 1;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Tìm hoạt động";
			this.chkTenNV.AutoSize = true;
			this.chkTenNV.Location = new Point(16, 45);
			this.chkTenNV.Name = "chkTenNV";
			this.chkTenNV.Size = new Size(170, 25);
			this.chkTenNV.TabIndex = 1;
			this.chkTenNV.Text = "Theo tên nhân viên";
			this.chkTenNV.UseVisualStyleBackColor = true;
			this.chkTenNV.CheckedChanged += new EventHandler(this.chkTenNV_CheckedChanged);
			this.dtpNHD.CustomFormat = "dd/MM/yyyy";
			this.dtpNHD.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpNHD.Format = DateTimePickerFormat.Custom;
			this.dtpNHD.Location = new Point(277, 151);
			this.dtpNHD.Name = "dtpNHD";
			this.dtpNHD.Size = new Size(245, 29);
			this.dtpNHD.TabIndex = 4;
			this.dtpNHD.ValueChanged += new EventHandler(this.dtpNHD_ValueChanged);
			this.chkHD.AutoSize = true;
			this.chkHD.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.chkHD.Location = new Point(16, 151);
			this.chkHD.Name = "chkHD";
			this.chkHD.Size = new Size(188, 25);
			this.chkHD.TabIndex = 3;
			this.chkHD.Text = "Theo ngày hoạt động";
			this.chkHD.UseVisualStyleBackColor = true;
			this.chkHD.CheckedChanged += new EventHandler(this.chkHD_CheckedChanged);
			this.label33.AutoSize = true;
			this.label33.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label33.Location = new Point(40, 86);
			this.label33.Name = "label33";
			this.label33.Size = new Size(104, 21);
			this.label33.TabIndex = 148;
			this.label33.Text = "ID nhân viên";
			this.cbxChonNhanVien.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxChonNhanVien.FormattingEnabled = true;
			this.cbxChonNhanVien.IntegralHeight = false;
			this.cbxChonNhanVien.Location = new Point(277, 41);
			this.cbxChonNhanVien.Name = "cbxChonNhanVien";
			this.cbxChonNhanVien.Size = new Size(243, 29);
			this.cbxChonNhanVien.TabIndex = 2;
			this.cbxChonNhanVien.SelectedIndexChanged += new EventHandler(this.cbxChonNhanVien_SelectedIndexChanged);
			this.txtIDNV1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNV1.Location = new Point(277, 86);
			this.txtIDNV1.Name = "txtIDNV1";
			this.txtIDNV1.ReadOnly = true;
			this.txtIDNV1.Size = new Size(243, 29);
			this.txtIDNV1.TabIndex = 137;
			this.txtIDNV1.TabStop = false;
			this.panel2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel2.BackColor = Color.Black;
			this.panel2.Location = new Point(2, 224);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(964, 4);
			this.panel2.TabIndex = 166;
			this.dgvHD.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHD.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn10,
				this.dataGridViewTextBoxColumn13,
				this.dataGridViewTextBoxColumn11,
				this.dataGridViewTextBoxColumn12,
				this.dataGridViewTextBoxColumn14,
				this.dataGridViewTextBoxColumn16,
				this.dataGridViewTextBoxColumn15,
				this.dataGridViewTextBoxColumn17
			});
			this.dgvHD.Location = new Point(2, 275);
			this.dgvHD.Margin = new Padding(2);
			this.dgvHD.Name = "dgvHD";
			this.dgvHD.RowHeadersWidth = 62;
			this.dgvHD.RowTemplate.Height = 50;
			this.dgvHD.Size = new Size(964, 465);
			this.dgvHD.TabIndex = 3;
			this.dgvHD.TabStop = false;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "IDLSHD";
			dataGridViewCellStyle.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewTextBoxColumn10.FillWeight = 200f;
			this.dataGridViewTextBoxColumn10.HeaderText = "ID hoạt động";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.Width = 88;
			this.dataGridViewTextBoxColumn13.DataPropertyName = "NHoatDong";
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.Format = "dd/MM/yyyy hh:mm:ss";
			this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTextBoxColumn13.HeaderText = "Thời gian";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.Width = 70;
			this.dataGridViewTextBoxColumn11.DataPropertyName = "IDND";
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.Format = "dd/MM/yyyy";
			this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTextBoxColumn11.HeaderText = "ID người dùng";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.Width = 91;
			this.dataGridViewTextBoxColumn12.DataPropertyName = "TenND";
			dataGridViewCellStyle4.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn12.FillWeight = 200f;
			this.dataGridViewTextBoxColumn12.HeaderText = "Tên người dùng";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.Width = 98;
			this.dataGridViewTextBoxColumn14.DataPropertyName = "HoatDong";
			dataGridViewCellStyle5.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewTextBoxColumn14.HeaderText = "Tên hoạt động";
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.Width = 95;
			this.dataGridViewTextBoxColumn16.DataPropertyName = "IDDoiTuong";
			dataGridViewCellStyle6.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn16.HeaderText = "ID đối tượng bị ảnh hưởng";
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.Visible = false;
			this.dataGridViewTextBoxColumn16.Width = 97;
			this.dataGridViewTextBoxColumn15.DataPropertyName = "DoiTuong";
			dataGridViewCellStyle7.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewTextBoxColumn15.HeaderText = "Tên đối tượng bị ảnh hưởng";
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.Width = 104;
			this.dataGridViewTextBoxColumn17.DataPropertyName = "NoiDung";
			dataGridViewCellStyle8.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewTextBoxColumn17.HeaderText = "Nội dụng chi tiết hoạt động";
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.Width = 103;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(969, 739);
			base.Controls.Add(this.panel1);
			this.Font = new Font("Microsoft Sans Serif", 8.25f);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Ql_LichSuHoatDong";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "LỊCH SỬ HOẠT ĐỘNG";
			base.Load += new EventHandler(this.Ql_LichSuHoatDong_Load);
			base.KeyUp += new KeyEventHandler(this.Ql_LichSuHoatDong_KeyUp);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			((ISupportInitialize)this.dgvHD).EndInit();
			base.ResumeLayout(false);
		}
	}
}
