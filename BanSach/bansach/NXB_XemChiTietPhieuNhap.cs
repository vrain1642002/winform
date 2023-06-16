using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class NXB_XemChiTietPhieuNhap : Form
	{
		public object phieunhap;
		private CXuLyNXB xulyNXB;
		private IContainer components = null;
		private Panel panel1;
		private DateTimePicker dtpnNLPN;
		private TextBox txtTrangThai;
		private Label label5;
		private Label label7;
		private TextBox txtTenNXB;
		private Label label1;
		private TextBox txtDiaChiNXB;
		private TextBox txtSDTNXB;
		private Label label13;
		private TextBox txtIDNXB;
		private Label label2;
		private TextBox txtIDPhieuNhap;
		private Label lblIDHD;
		private TextBox txtTongTien;
		private Label label6;
		private TextBox txtThanhToanNXB;
		private TextBox txtGiam;
		private Label label4;
		private Label label3;
		private Label label8;
		private DataGridView dgvTT;
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
		private Panel panel2;
		private Label label16;
		public NXB_XemChiTietPhieuNhap()
		{
			this.InitializeComponent();
		}
		private void hienthiPhieuNhap(CPhieuNhap x)
		{
			BindingSource bindingSource = new BindingSource();
			CViewPhieuNhap.chuyenDoi(x);
			bindingSource.DataSource = CViewPhieuNhap.chuyenDoi(x);
			this.dgvTT.DataSource = bindingSource;
		}
		private void XemChiTietPhieuNhap_Load(object sender, EventArgs e)
		{
			this.xulyNXB = new CXuLyNXB();
			bool flag = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			CPhieuNhap cPhieuNhap = this.phieunhap as CPhieuNhap;
			this.txtIDPhieuNhap.Text = cPhieuNhap.IDPN;
			this.dtpnNLPN.Value = cPhieuNhap.NgayTaoPN;
			this.txtTongTien.Text = cPhieuNhap.ThanhTienN.ToString();
			this.txtGiam.Text = cPhieuNhap.NXBGiam.ToString();
			this.txtThanhToanNXB.Text = cPhieuNhap.ThanhToanNXB.ToString();
			this.txtIDNXB.Text = cPhieuNhap.IDNXB;
			this.txtTenNXB.Text = cPhieuNhap.TenNXB;
			this.txtSDTNXB.Text = cPhieuNhap.SDTNXB;
			this.txtDiaChiNXB.Text = this.xulyNXB.tim(cPhieuNhap.IDNXB).DiaChiNXB;
			this.txtTrangThai.Text = cPhieuNhap.TrangThai;
			this.hienthiPhieuNhap(cPhieuNhap);
			base.KeyPreview = true;
		}
		private void XemChiTietPhieuNhap_KeyUp(object sender, KeyEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NXB_XemChiTietPhieuNhap));
			this.panel1 = new Panel();
			this.dtpnNLPN = new DateTimePicker();
			this.txtTrangThai = new TextBox();
			this.label5 = new Label();
			this.label7 = new Label();
			this.txtTenNXB = new TextBox();
			this.label1 = new Label();
			this.txtDiaChiNXB = new TextBox();
			this.txtSDTNXB = new TextBox();
			this.label13 = new Label();
			this.txtIDNXB = new TextBox();
			this.label2 = new Label();
			this.txtIDPhieuNhap = new TextBox();
			this.lblIDHD = new Label();
			this.txtTongTien = new TextBox();
			this.label6 = new Label();
			this.txtThanhToanNXB = new TextBox();
			this.txtGiam = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label8 = new Label();
			this.Column10 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column12 = new DataGridViewTextBoxColumn();
			this.Column11 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.dgvTT = new DataGridView();
			this.panel2 = new Panel();
			this.label16 = new Label();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.dgvTT).BeginInit();
			base.SuspendLayout();
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.dtpnNLPN);
			this.panel1.Controls.Add(this.txtTrangThai);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.txtTenNXB);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtDiaChiNXB);
			this.panel1.Controls.Add(this.txtSDTNXB);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.txtIDNXB);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtIDPhieuNhap);
			this.panel1.Controls.Add(this.lblIDHD);
			this.panel1.Controls.Add(this.txtTongTien);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.txtThanhToanNXB);
			this.panel1.Controls.Add(this.txtGiam);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.dgvTT);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(980, 777);
			this.panel1.TabIndex = 0;
			this.dtpnNLPN.CustomFormat = "dd/MM/yyyy hh:mm:ss";
			this.dtpnNLPN.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtpnNLPN.Format = DateTimePickerFormat.Custom;
			this.dtpnNLPN.Location = new Point(242, 62);
			this.dtpnNLPN.Name = "dtpnNLPN";
			this.dtpnNLPN.Size = new Size(192, 29);
			this.dtpnNLPN.TabIndex = 180;
			this.dtpnNLPN.TabStop = false;
			this.txtTrangThai.BackColor = SystemColors.ControlLightLight;
			this.txtTrangThai.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTrangThai.Location = new Point(767, 216);
			this.txtTrangThai.Name = "txtTrangThai";
			this.txtTrangThai.ReadOnly = true;
			this.txtTrangThai.Size = new Size(192, 29);
			this.txtTrangThai.TabIndex = 178;
			this.txtTrangThai.TabStop = false;
			this.txtTrangThai.WordWrap = false;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(579, 224);
			this.label5.Name = "label5";
			this.label5.Size = new Size(170, 21);
			this.label5.TabIndex = 177;
			this.label5.Text = "Trạng thái phiếu nhập";
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(585, 110);
			this.label7.Name = "label7";
			this.label7.Size = new Size(145, 21);
			this.label7.TabIndex = 176;
			this.label7.Text = "SDT nhà xuất bản";
			this.txtTenNXB.BackColor = SystemColors.ControlLightLight;
			this.txtTenNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTenNXB.Location = new Point(767, 60);
			this.txtTenNXB.Name = "txtTenNXB";
			this.txtTenNXB.ReadOnly = true;
			this.txtTenNXB.Size = new Size(192, 29);
			this.txtTenNXB.TabIndex = 175;
			this.txtTenNXB.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(585, 59);
			this.label1.Name = "label1";
			this.label1.Size = new Size(138, 21);
			this.label1.TabIndex = 174;
			this.label1.Text = "Tên nhà xuất bản";
			this.txtDiaChiNXB.BackColor = SystemColors.ControlLightLight;
			this.txtDiaChiNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDiaChiNXB.Location = new Point(767, 162);
			this.txtDiaChiNXB.Name = "txtDiaChiNXB";
			this.txtDiaChiNXB.ReadOnly = true;
			this.txtDiaChiNXB.Size = new Size(192, 29);
			this.txtDiaChiNXB.TabIndex = 173;
			this.txtDiaChiNXB.TabStop = false;
			this.txtDiaChiNXB.WordWrap = false;
			this.txtSDTNXB.BackColor = SystemColors.ControlLightLight;
			this.txtSDTNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNXB.Location = new Point(767, 110);
			this.txtSDTNXB.Name = "txtSDTNXB";
			this.txtSDTNXB.ReadOnly = true;
			this.txtSDTNXB.Size = new Size(192, 29);
			this.txtSDTNXB.TabIndex = 172;
			this.txtSDTNXB.TabStop = false;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label13.Location = new Point(585, 168);
			this.label13.Name = "label13";
			this.label13.Size = new Size(164, 21);
			this.label13.TabIndex = 171;
			this.label13.Text = "Địa chỉ nhà xuất bản";
			this.txtIDNXB.BackColor = SystemColors.ControlLightLight;
			this.txtIDNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNXB.Location = new Point(767, 9);
			this.txtIDNXB.Name = "txtIDNXB";
			this.txtIDNXB.ReadOnly = true;
			this.txtIDNXB.Size = new Size(192, 29);
			this.txtIDNXB.TabIndex = 170;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(585, 17);
			this.label2.Name = "label2";
			this.label2.Size = new Size(128, 21);
			this.label2.TabIndex = 169;
			this.label2.Text = "ID nhà xuất bản";
			this.txtIDPhieuNhap.BackColor = SystemColors.ControlLightLight;
			this.txtIDPhieuNhap.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDPhieuNhap.Location = new Point(242, 9);
			this.txtIDPhieuNhap.Name = "txtIDPhieuNhap";
			this.txtIDPhieuNhap.ReadOnly = true;
			this.txtIDPhieuNhap.Size = new Size(192, 29);
			this.txtIDPhieuNhap.TabIndex = 168;
			this.txtIDPhieuNhap.TabStop = false;
			this.txtIDPhieuNhap.WordWrap = false;
			this.lblIDHD.AutoSize = true;
			this.lblIDHD.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblIDHD.Location = new Point(17, 17);
			this.lblIDHD.Name = "lblIDHD";
			this.lblIDHD.Size = new Size(115, 21);
			this.lblIDHD.TabIndex = 167;
			this.lblIDHD.Text = "ID phiếu nhập";
			this.txtTongTien.BackColor = SystemColors.ControlLightLight;
			this.txtTongTien.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTongTien.Location = new Point(242, 107);
			this.txtTongTien.Name = "txtTongTien";
			this.txtTongTien.ReadOnly = true;
			this.txtTongTien.Size = new Size(192, 29);
			this.txtTongTien.TabIndex = 166;
			this.txtTongTien.TabStop = false;
			this.txtTongTien.WordWrap = false;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(17, 113);
			this.label6.Name = "label6";
			this.label6.Size = new Size(81, 21);
			this.label6.TabIndex = 165;
			this.label6.Text = "Tổng tiền";
			this.txtThanhToanNXB.BackColor = SystemColors.ControlLightLight;
			this.txtThanhToanNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtThanhToanNXB.Location = new Point(242, 216);
			this.txtThanhToanNXB.Name = "txtThanhToanNXB";
			this.txtThanhToanNXB.ReadOnly = true;
			this.txtThanhToanNXB.Size = new Size(192, 29);
			this.txtThanhToanNXB.TabIndex = 164;
			this.txtThanhToanNXB.TabStop = false;
			this.txtGiam.BackColor = SystemColors.ControlLightLight;
			this.txtGiam.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtGiam.Location = new Point(242, 162);
			this.txtGiam.Name = "txtGiam";
			this.txtGiam.ReadOnly = true;
			this.txtGiam.Size = new Size(192, 29);
			this.txtGiam.TabIndex = 163;
			this.txtGiam.TabStop = false;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(17, 219);
			this.label4.Name = "label4";
			this.label4.Size = new Size(170, 21);
			this.label4.TabIndex = 162;
			this.label4.Text = "Thanh toán cho NXB";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(17, 168);
			this.label3.Name = "label3";
			this.label3.Size = new Size(102, 21);
			this.label3.TabIndex = 161;
			this.label3.Text = "Số tiền giảm";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(17, 70);
			this.label8.Name = "label8";
			this.label8.Size = new Size(162, 21);
			this.label8.TabIndex = 160;
			this.label8.Text = "Ngày lập phiếu nhập";
			this.Column10.DataPropertyName = "TenNXB";
			this.Column10.HeaderText = "Tên nhà xuất bản";
			this.Column10.Name = "Column10";
			this.Column10.Visible = false;
			this.Column10.Width = 124;
			this.Column5.DataPropertyName = "TenTG";
			this.Column5.HeaderText = "Tên tác giả";
			this.Column5.Name = "Column5";
			this.Column5.Width = 88;
			this.Column12.DataPropertyName = "IDPN";
			this.Column12.HeaderText = "ID phiếu nhập";
			this.Column12.Name = "Column12";
			this.Column12.Visible = false;
			this.Column12.Width = 128;
			this.Column11.DataPropertyName = "ThanhTienN";
			this.Column11.HeaderText = "Thành tiền";
			this.Column11.Name = "Column11";
			this.Column11.Width = 104;
			this.Column4.DataPropertyName = "SoLuongN";
			this.Column4.HeaderText = "Số lượng nhập";
			this.Column4.Name = "Column4";
			this.Column4.Width = 132;
			this.Column6.DataPropertyName = "GiaNhap";
			this.Column6.HeaderText = "Giá nhập";
			this.Column6.Name = "Column6";
			this.Column6.Width = 94;
			this.Column7.DataPropertyName = "GiaNhapGanNhat";
			this.Column7.HeaderText = "Giá nhập gần nhất";
			this.Column7.Name = "Column7";
			this.Column7.Width = 126;
			this.Column3.DataPropertyName = "GiaBan";
			this.Column3.HeaderText = "Giá Bán";
			this.Column3.Name = "Column3";
			this.Column3.Visible = false;
			this.Column3.Width = 95;
			this.Column2.DataPropertyName = "TenSach";
			dataGridViewCellStyle.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Column2.DefaultCellStyle = dataGridViewCellStyle;
			this.Column2.FillWeight = 200f;
			this.Column2.HeaderText = "Tên Sách";
			this.Column2.Name = "Column2";
			this.Column2.Width = 97;
			this.Column1.DataPropertyName = "IDSach";
			this.Column1.HeaderText = "ID Sách";
			this.Column1.Name = "Column1";
			this.Column1.Width = 88;
			this.Column8.DataPropertyName = "NXB";
			this.Column8.HeaderText = "Năm xuất bản";
			this.Column8.Name = "Column8";
			this.Column8.Width = 102;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			this.dgvTT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvTT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvTT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvTT.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvTT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvTT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTT.Columns.AddRange(new DataGridViewColumn[]
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
			this.dgvTT.Cursor = Cursors.Default;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Window;
			dataGridViewCellStyle4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
			this.dgvTT.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvTT.Location = new Point(-2, 296);
			this.dgvTT.Margin = new Padding(2);
			this.dgvTT.Name = "dgvTT";
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.Control;
			dataGridViewCellStyle5.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			this.dgvTT.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvTT.RowHeadersWidth = 62;
			this.dgvTT.RowTemplate.Height = 50;
			this.dgvTT.Size = new Size(980, 479);
			this.dgvTT.TabIndex = 159;
			this.dgvTT.TabStop = false;
			this.panel2.BackColor = Color.Black;
			this.panel2.Location = new Point(3, 251);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(977, 4);
			this.panel2.TabIndex = 181;
			this.label16.AutoSize = true;
			this.label16.BackColor = Color.Transparent;
			this.label16.Font = new Font("Times New Roman", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label16.ForeColor = SystemColors.Desktop;
			this.label16.Location = new Point(18, 268);
			this.label16.Name = "label16";
			this.label16.Size = new Size(169, 26);
			this.label16.TabIndex = 182;
			this.label16.Text = "Danh sách sách";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.InactiveBorder;
			base.ClientSize = new Size(981, 777);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NXB_XemChiTietPhieuNhap";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "XEM CHI TIẾT PHIẾU NHẬP";
			base.Load += new EventHandler(this.XemChiTietPhieuNhap_Load);
			base.KeyUp += new KeyEventHandler(this.XemChiTietPhieuNhap_KeyUp);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((ISupportInitialize)this.dgvTT).EndInit();
			base.ResumeLayout(false);
		}
	}
}
