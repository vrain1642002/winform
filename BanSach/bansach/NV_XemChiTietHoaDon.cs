using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class NV_XemChiTietHoaDon : Form
	{
		public object hoadon;
		private IContainer components = null;
		private Panel panel1;
		private Label label1;
		private TextBox txtSDTKH;
		private TextBox txtIDHoaDon;
		private TextBox txtGiam;
		private Label label5;
		private Panel panel2;
		private DateTimePicker dtpNLHD;
		private Label label9;
		private TextBox txtSDTNV;
		private TextBox txtthanhTien;
		private TextBox txtTenNV;
		private Label lblIDHD;
		private Label label8;
		private Label label7;
		private TextBox txtDiaChiKH;
		private Label label6;
		private TextBox txtThanhToan;
		private Label label4;
		private Label label3;
		private TextBox txtIDNhanVien;
		private Label label13;
		private TextBox txtTenKH;
		private Label label2;
		private DataGridView dgvTT;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column11;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column12;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn Column10;
		private Label label16;
		public NV_XemChiTietHoaDon()
		{
			this.InitializeComponent();
		}
		private void hienthiHoadon(CHoaDon x)
		{
			BindingSource bindingSource = new BindingSource();
			CViewHoaDon.chuyenDoi(x);
			bindingSource.DataSource = CViewHoaDon.chuyenDoi(x);
			this.dgvTT.DataSource = bindingSource;
		}
		private void XemChiTietHoaDon_Load(object sender, EventArgs e)
		{
			CHoaDon cHoaDon = this.hoadon as CHoaDon;
			this.txtIDHoaDon.Text = cHoaDon.IDHoaDon;
			this.dtpNLHD.Value = cHoaDon.NgayTaoHD;
			this.txtthanhTien.Text = cHoaDon.ThanhTien.ToString();
			this.txtGiam.Text = cHoaDon.Giam.ToString();
			this.txtThanhToan.Text = cHoaDon.ThanhToan.ToString();
			this.txtTenKH.Text = cHoaDon.TenKH;
			this.txtSDTKH.Text = cHoaDon.SDTKH;
			this.txtDiaChiKH.Text = cHoaDon.DiaChiKH;
			this.txtIDNhanVien.Text = cHoaDon.IDNguoiTao;
			this.txtTenNV.Text = cHoaDon.TenNguoiTao;
			this.txtSDTNV.Text = cHoaDon.SDTNguoiTao;
			this.hienthiHoadon(cHoaDon);
			base.KeyPreview = true;
		}
		private void XemChiTietHoaDon_KeyUp(object sender, KeyEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NV_XemChiTietHoaDon));
			this.panel1 = new Panel();
			this.label16 = new Label();
			this.label1 = new Label();
			this.txtSDTKH = new TextBox();
			this.txtIDHoaDon = new TextBox();
			this.txtGiam = new TextBox();
			this.label5 = new Label();
			this.panel2 = new Panel();
			this.dtpNLHD = new DateTimePicker();
			this.label9 = new Label();
			this.txtSDTNV = new TextBox();
			this.txtthanhTien = new TextBox();
			this.txtTenNV = new TextBox();
			this.lblIDHD = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.txtDiaChiKH = new TextBox();
			this.label6 = new Label();
			this.txtThanhToan = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtIDNhanVien = new TextBox();
			this.label13 = new Label();
			this.txtTenKH = new TextBox();
			this.label2 = new Label();
			this.dgvTT = new DataGridView();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column12 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column10 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.dgvTT).BeginInit();
			base.SuspendLayout();
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtSDTKH);
			this.panel1.Controls.Add(this.txtIDHoaDon);
			this.panel1.Controls.Add(this.txtGiam);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.dtpNLHD);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.txtSDTNV);
			this.panel1.Controls.Add(this.txtthanhTien);
			this.panel1.Controls.Add(this.txtTenNV);
			this.panel1.Controls.Add(this.lblIDHD);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.txtDiaChiKH);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.txtThanhToan);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtIDNhanVien);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.txtTenKH);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dgvTT);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1212, 811);
			this.panel1.TabIndex = 0;
			this.label16.AutoSize = true;
			this.label16.BackColor = Color.Transparent;
			this.label16.Font = new Font("Times New Roman", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label16.ForeColor = SystemColors.Desktop;
			this.label16.Location = new Point(37, 268);
			this.label16.Name = "label16";
			this.label16.Size = new Size(213, 26);
			this.label16.TabIndex = 165;
			this.label16.Text = "Danh sách sách bán";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(875, 23);
			this.label1.Name = "label1";
			this.label1.Size = new Size(104, 21);
			this.label1.TabIndex = 161;
			this.label1.Text = "ID nhân viên";
			this.txtSDTKH.BackColor = SystemColors.ControlLightLight;
			this.txtSDTKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTKH.Location = new Point(620, 122);
			this.txtSDTKH.Name = "txtSDTKH";
			this.txtSDTKH.ReadOnly = true;
			this.txtSDTKH.Size = new Size(204, 29);
			this.txtSDTKH.TabIndex = 157;
			this.txtSDTKH.TabStop = false;
			this.txtIDHoaDon.BackColor = SystemColors.ControlLightLight;
			this.txtIDHoaDon.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDHoaDon.Location = new Point(208, 6);
			this.txtIDHoaDon.Name = "txtIDHoaDon";
			this.txtIDHoaDon.ReadOnly = true;
			this.txtIDHoaDon.Size = new Size(204, 29);
			this.txtIDHoaDon.TabIndex = 141;
			this.txtIDHoaDon.TabStop = false;
			this.txtIDHoaDon.WordWrap = false;
			this.txtGiam.BackColor = SystemColors.ControlLightLight;
			this.txtGiam.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiam.Location = new Point(208, 158);
			this.txtGiam.Name = "txtGiam";
			this.txtGiam.ReadOnly = true;
			this.txtGiam.Size = new Size(204, 29);
			this.txtGiam.TabIndex = 144;
			this.txtGiam.TabStop = false;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(495, 130);
			this.label5.Name = "label5";
			this.label5.Size = new Size(77, 21);
			this.label5.TabIndex = 150;
			this.label5.Text = "SDT KH";
			this.panel2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel2.BackColor = Color.Black;
			this.panel2.Location = new Point(0, 246);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(1208, 4);
			this.panel2.TabIndex = 164;
			this.dtpNLHD.CustomFormat = "dd/MM/yyyy hh:mm:ss";
			this.dtpNLHD.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpNLHD.Format = DateTimePickerFormat.Custom;
			this.dtpNLHD.Location = new Point(208, 61);
			this.dtpNLHD.Name = "dtpNLHD";
			this.dtpNLHD.Size = new Size(204, 29);
			this.dtpNLHD.TabIndex = 142;
			this.dtpNLHD.TabStop = false;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(875, 112);
			this.label9.Name = "label9";
			this.label9.Size = new Size(114, 21);
			this.label9.TabIndex = 163;
			this.label9.Text = "Tên nhân viên";
			this.txtSDTNV.BackColor = SystemColors.ControlLightLight;
			this.txtSDTNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNV.Location = new Point(1002, 211);
			this.txtSDTNV.Name = "txtSDTNV";
			this.txtSDTNV.ReadOnly = true;
			this.txtSDTNV.Size = new Size(204, 29);
			this.txtSDTNV.TabIndex = 159;
			this.txtSDTNV.TabStop = false;
			this.txtthanhTien.BackColor = SystemColors.ControlLightLight;
			this.txtthanhTien.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtthanhTien.Location = new Point(208, 112);
			this.txtthanhTien.Name = "txtthanhTien";
			this.txtthanhTien.ReadOnly = true;
			this.txtthanhTien.Size = new Size(204, 29);
			this.txtthanhTien.TabIndex = 143;
			this.txtthanhTien.TabStop = false;
			this.txtthanhTien.WordWrap = false;
			this.txtTenNV.BackColor = SystemColors.ControlLightLight;
			this.txtTenNV.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenNV.Location = new Point(1002, 104);
			this.txtTenNV.Name = "txtTenNV";
			this.txtTenNV.ReadOnly = true;
			this.txtTenNV.Size = new Size(204, 29);
			this.txtTenNV.TabIndex = 158;
			this.txtTenNV.TabStop = false;
			this.lblIDHD.AutoSize = true;
			this.lblIDHD.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblIDHD.Location = new Point(38, 9);
			this.lblIDHD.Name = "lblIDHD";
			this.lblIDHD.Size = new Size(95, 21);
			this.lblIDHD.TabIndex = 156;
			this.lblIDHD.Text = "ID hóa đơn";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(38, 64);
			this.label8.Name = "label8";
			this.label8.Size = new Size(142, 21);
			this.label8.TabIndex = 148;
			this.label8.Text = "Ngày lập hóa đơn";
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(875, 214);
			this.label7.Name = "label7";
			this.label7.Size = new Size(121, 21);
			this.label7.TabIndex = 162;
			this.label7.Text = "SDT nhân viên";
			this.txtDiaChiKH.BackColor = SystemColors.ControlLightLight;
			this.txtDiaChiKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDiaChiKH.Location = new Point(620, 206);
			this.txtDiaChiKH.Name = "txtDiaChiKH";
			this.txtDiaChiKH.ReadOnly = true;
			this.txtDiaChiKH.Size = new Size(204, 29);
			this.txtDiaChiKH.TabIndex = 160;
			this.txtDiaChiKH.TabStop = false;
			this.txtDiaChiKH.WordWrap = false;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(39, 112);
			this.label6.Name = "label6";
			this.label6.Size = new Size(81, 21);
			this.label6.TabIndex = 155;
			this.label6.Text = "Tổng tiền";
			this.txtThanhToan.BackColor = SystemColors.ControlLightLight;
			this.txtThanhToan.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtThanhToan.Location = new Point(208, 206);
			this.txtThanhToan.Name = "txtThanhToan";
			this.txtThanhToan.ReadOnly = true;
			this.txtThanhToan.Size = new Size(204, 29);
			this.txtThanhToan.TabIndex = 145;
			this.txtThanhToan.TabStop = false;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(38, 214);
			this.label4.Name = "label4";
			this.label4.Size = new Size(94, 21);
			this.label4.TabIndex = 154;
			this.label4.Text = "Thanh toán";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(39, 166);
			this.label3.Name = "label3";
			this.label3.Size = new Size(102, 21);
			this.label3.TabIndex = 153;
			this.label3.Text = "Số tiền giảm";
			this.txtIDNhanVien.BackColor = SystemColors.ControlLightLight;
			this.txtIDNhanVien.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNhanVien.Location = new Point(1002, 20);
			this.txtIDNhanVien.Name = "txtIDNhanVien";
			this.txtIDNhanVien.ReadOnly = true;
			this.txtIDNhanVien.Size = new Size(204, 29);
			this.txtIDNhanVien.TabIndex = 152;
			this.txtIDNhanVien.TabStop = false;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label13.Location = new Point(486, 214);
			this.label13.Name = "label13";
			this.label13.Size = new Size(100, 21);
			this.label13.TabIndex = 151;
			this.label13.Text = "Địa Chỉ KH";
			this.txtTenKH.BackColor = SystemColors.ControlLightLight;
			this.txtTenKH.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenKH.Location = new Point(620, 25);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.ReadOnly = true;
			this.txtTenKH.Size = new Size(204, 29);
			this.txtTenKH.TabIndex = 146;
			this.txtTenKH.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(486, 28);
			this.label2.Name = "label2";
			this.label2.Size = new Size(128, 21);
			this.label2.TabIndex = 149;
			this.label2.Text = "Tên khách hàng";
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
			this.dgvTT.Location = new Point(0, 296);
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
			this.dgvTT.Size = new Size(1210, 513);
			this.dgvTT.TabIndex = 147;
			this.dgvTT.TabStop = false;
			this.Column2.DataPropertyName = "TenSach";
			dataGridViewCellStyle4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
			this.Column2.FillWeight = 200f;
			this.Column2.HeaderText = "Tên Sách";
			this.Column2.Name = "Column2";
			this.Column2.Width = 97;
			this.Column3.DataPropertyName = "GiaBan";
			this.Column3.HeaderText = "Giá Bán";
			this.Column3.Name = "Column3";
			this.Column3.Width = 88;
			this.Column4.DataPropertyName = "SoLuongB";
			this.Column4.HeaderText = "Số Lượng bán";
			this.Column4.Name = "Column4";
			this.Column4.Width = 130;
			this.Column11.DataPropertyName = "ThanhTien";
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
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.InactiveBorder;
			base.ClientSize = new Size(1212, 811);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "NV_XemChiTietHoaDon";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "XEM CHI Tiết HÓA ĐƠN";
			base.Load += new EventHandler(this.XemChiTietHoaDon_Load);
			base.KeyUp += new KeyEventHandler(this.XemChiTietHoaDon_KeyUp);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((ISupportInitialize)this.dgvTT).EndInit();
			base.ResumeLayout(false);
		}
	}
}
