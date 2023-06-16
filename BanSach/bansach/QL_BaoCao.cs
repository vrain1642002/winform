using bansach.Properties;
using CustomButton;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class QL_BaoCao : Form
	{
		private CXuLyPhieuNhap xulyPhieuNhap;
		private CXuLyHoaDon xulyHoaDon;
		private CXuLyNV xulyNV;
		private IContainer components = null;
		private Panel panel1;
		private GroupBox groupBox9;
		private Label label30;
		private TextBox txtBS;
		private TextBox txtTN;
		private Label label32;
		private Label label31;
		private TextBox txtTL;
		private GroupBox groupBox8;
		private Label label28;
		private NumericUpDown nudBST;
		private TextBox txtBST;
		private TextBox txtTNT;
		private Label label29;
		private NumericUpDown nudNST;
		private VBButton btnxuatTNT;
		private VBButton btnBST;
		private VBButton btnXuatTL;
		private VBButton btnXuatNS;
		private VBButton btnXuatBS;
		public QL_BaoCao()
		{
			this.InitializeComponent();
		}
		private void QL_BaoCao_Load(object sender, EventArgs e)
		{
			this.xulyNV = new CXuLyNV();
			bool flag = !this.xulyNV.docFile("DSNhanVien.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhanVien.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.xulyPhieuNhap = new CXuLyPhieuNhap();
			bool flag2 = !this.xulyPhieuNhap.docFile("DSPhieuNhap.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSPhieuNhap.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.xulyHoaDon = new CXuLyHoaDon();
			bool flag3 = !this.xulyHoaDon.docFile("LichSuHD.dat");
			if (flag3)
			{
				MessageBox.Show("Không đọc được dữ liệu fie LichSuHD.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			base.KeyPreview = true;
		}
		private void btnxuatTNT_Click(object sender, EventArgs e)
		{
			long num = 0L;
			foreach (CPhieuNhap current in this.xulyPhieuNhap.getDSPhieuNhap())
			{
				bool flag = current.NgayTaoPN.Month == int.Parse(this.nudNST.Text) && current.TrangThai == "Đồng ý";
				if (flag)
				{
					num += (long)current.ThanhToanNXB;
				}
			}
			this.txtTNT.Text = num.ToString();
		}
		private void btnBST_Click(object sender, EventArgs e)
		{
			this.xulyHoaDon = new CXuLyHoaDon();
			this.xulyHoaDon.docFile("DSHoaDon.dat");
			long num = 0L;
			foreach (CHoaDon current in this.xulyHoaDon.getDSHoaDon())
			{
				bool flag = current.NgayTaoHD.Month == int.Parse(this.nudBST.Text);
				if (flag)
				{
					num += (long)current.ThanhToan;
				}
			}
			this.txtBST.Text = num.ToString();
		}
		private void btnXuatTL_Click(object sender, EventArgs e)
		{
			double num = 0.0;
			foreach (CNhanVien current in this.xulyNV.getDSNV())
			{
				num += (double)current.LuongCoBanNV;
			}
			this.txtTL.Text = num.ToString();
		}
		private void btnXuatNS_Click(object sender, EventArgs e)
		{
			long num = 0L;
			foreach (CPhieuNhap current in this.xulyPhieuNhap.getDSPhieuNhap())
			{
				bool flag = current.TrangThai == "Đồng ý";
				if (flag)
				{
					num += (long)current.ThanhToanNXB;
				}
			}
			this.txtTN.Text = num.ToString();
		}
		private void btnXuatBS_Click_1(object sender, EventArgs e)
		{
			this.xulyHoaDon = new CXuLyHoaDon();
			this.xulyHoaDon.docFile("DSHoaDon.dat");
			long num = 0L;
			foreach (CHoaDon current in this.xulyHoaDon.getDSHoaDon())
			{
				num += (long)current.ThanhToan;
			}
			this.txtBS.Text = num.ToString();
		}
		private void QL_BaoCao_KeyUp(object sender, KeyEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QL_BaoCao));
			this.panel1 = new Panel();
			this.groupBox9 = new GroupBox();
			this.label30 = new Label();
			this.txtBS = new TextBox();
			this.txtTN = new TextBox();
			this.label32 = new Label();
			this.label31 = new Label();
			this.txtTL = new TextBox();
			this.groupBox8 = new GroupBox();
			this.label28 = new Label();
			this.nudBST = new NumericUpDown();
			this.txtBST = new TextBox();
			this.txtTNT = new TextBox();
			this.label29 = new Label();
			this.nudNST = new NumericUpDown();
			this.btnXuatTL = new VBButton();
			this.btnXuatNS = new VBButton();
			this.btnXuatBS = new VBButton();
			this.btnBST = new VBButton();
			this.btnxuatTNT = new VBButton();
			this.panel1.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((ISupportInitialize)this.nudBST).BeginInit();
			((ISupportInitialize)this.nudNST).BeginInit();
			base.SuspendLayout();
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.groupBox9);
			this.panel1.Controls.Add(this.groupBox8);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(956, 469);
			this.panel1.TabIndex = 5;
			this.groupBox9.BackColor = SystemColors.GradientActiveCaption;
			this.groupBox9.Controls.Add(this.btnXuatTL);
			this.groupBox9.Controls.Add(this.btnXuatNS);
			this.groupBox9.Controls.Add(this.btnXuatBS);
			this.groupBox9.Controls.Add(this.label30);
			this.groupBox9.Controls.Add(this.txtBS);
			this.groupBox9.Controls.Add(this.txtTN);
			this.groupBox9.Controls.Add(this.label32);
			this.groupBox9.Controls.Add(this.label31);
			this.groupBox9.Controls.Add(this.txtTL);
			this.groupBox9.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox9.Location = new Point(479, -2);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new Size(470, 463);
			this.groupBox9.TabIndex = 176;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Từ trước đến nay";
			this.groupBox9.UseCompatibleTextRendering = true;
			this.label30.AutoSize = true;
			this.label30.Location = new Point(24, 328);
			this.label30.Margin = new Padding(2, 0, 2, 0);
			this.label30.Name = "label30";
			this.label30.Size = new Size(225, 21);
			this.label30.TabIndex = 171;
			this.label30.Text = "Tổng số tiền  thu (bán sách) ";
			this.txtBS.AcceptsReturn = true;
			this.txtBS.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtBS.Location = new Point(151, 383);
			this.txtBS.Name = "txtBS";
			this.txtBS.ReadOnly = true;
			this.txtBS.Size = new Size(265, 35);
			this.txtBS.TabIndex = 169;
			this.txtTN.Font = new Font("Times New Roman", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTN.Location = new Point(151, 243);
			this.txtTN.Name = "txtTN";
			this.txtTN.ReadOnly = true;
			this.txtTN.Size = new Size(265, 39);
			this.txtTN.TabIndex = 167;
			this.txtTN.TabStop = false;
			this.label32.AutoSize = true;
			this.label32.Location = new Point(24, 208);
			this.label32.Margin = new Padding(2, 0, 2, 0);
			this.label32.Name = "label32";
			this.label32.Size = new Size(233, 21);
			this.label32.TabIndex = 166;
			this.label32.Text = "Tổng số tiền chi ( nhập sách) ";
			this.label31.AutoSize = true;
			this.label31.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label31.Location = new Point(24, 66);
			this.label31.Name = "label31";
			this.label31.Size = new Size(172, 21);
			this.label31.TabIndex = 157;
			this.label31.Text = "Tổng lương nhân viên";
			this.txtTL.Font = new Font("Times New Roman", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTL.Location = new Point(151, 118);
			this.txtTL.Name = "txtTL";
			this.txtTL.ReadOnly = true;
			this.txtTL.Size = new Size(265, 32);
			this.txtTL.TabIndex = 156;
			this.txtTL.TabStop = false;
			this.groupBox8.BackColor = SystemColors.ActiveBorder;
			this.groupBox8.Controls.Add(this.btnBST);
			this.groupBox8.Controls.Add(this.btnxuatTNT);
			this.groupBox8.Controls.Add(this.label28);
			this.groupBox8.Controls.Add(this.nudBST);
			this.groupBox8.Controls.Add(this.txtBST);
			this.groupBox8.Controls.Add(this.txtTNT);
			this.groupBox8.Controls.Add(this.label29);
			this.groupBox8.Controls.Add(this.nudNST);
			this.groupBox8.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox8.Location = new Point(-2, -2);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new Size(480, 463);
			this.groupBox8.TabIndex = 1;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Theo tháng";
			this.label28.AutoSize = true;
			this.label28.Location = new Point(30, 328);
			this.label28.Margin = new Padding(2, 0, 2, 0);
			this.label28.Name = "label28";
			this.label28.Size = new Size(313, 21);
			this.label28.TabIndex = 163;
			this.label28.Text = "Xuất số tiền  thu (bán sách)  trong tháng:";
			this.nudBST.Location = new Point(360, 320);
			this.nudBST.Margin = new Padding(2);
			NumericUpDown arg_889_0 = this.nudBST;
			int[] expr_87F = new int[4];
			expr_87F[0] = 12;
			arg_889_0.Maximum = new decimal(expr_87F);
			NumericUpDown arg_8A4_0 = this.nudBST;
			int[] expr_89B = new int[4];
			expr_89B[0] = 1;
			arg_8A4_0.Minimum = new decimal(expr_89B);
			this.nudBST.Name = "nudBST";
			this.nudBST.Size = new Size(57, 29);
			this.nudBST.TabIndex = 3;
			NumericUpDown arg_8F2_0 = this.nudBST;
			int[] expr_8E9 = new int[4];
			expr_8E9[0] = 1;
			arg_8F2_0.Value = new decimal(expr_8E9);
			this.txtBST.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtBST.Location = new Point(152, 383);
			this.txtBST.Name = "txtBST";
			this.txtBST.ReadOnly = true;
			this.txtBST.Size = new Size(265, 35);
			this.txtBST.TabIndex = 55;
			this.txtBST.TabStop = false;
			this.txtTNT.Font = new Font("Times New Roman", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTNT.Location = new Point(152, 118);
			this.txtTNT.Name = "txtTNT";
			this.txtTNT.ReadOnly = true;
			this.txtTNT.Size = new Size(265, 35);
			this.txtTNT.TabIndex = 159;
			this.txtTNT.TabStop = false;
			this.label29.AutoSize = true;
			this.label29.Location = new Point(30, 66);
			this.label29.Margin = new Padding(2, 0, 2, 0);
			this.label29.Name = "label29";
			this.label29.Size = new Size(311, 21);
			this.label29.TabIndex = 61;
			this.label29.Text = "Xuất số tiền chi (nhập sách) trong tháng:";
			this.nudNST.Location = new Point(360, 58);
			this.nudNST.Margin = new Padding(2);
			NumericUpDown arg_ACB_0 = this.nudNST;
			int[] expr_AC1 = new int[4];
			expr_AC1[0] = 12;
			arg_ACB_0.Maximum = new decimal(expr_AC1);
			NumericUpDown arg_AE6_0 = this.nudNST;
			int[] expr_ADD = new int[4];
			expr_ADD[0] = 1;
			arg_AE6_0.Minimum = new decimal(expr_ADD);
			this.nudNST.Name = "nudNST";
			this.nudNST.Size = new Size(57, 29);
			this.nudNST.TabIndex = 1;
			NumericUpDown arg_B34_0 = this.nudNST;
			int[] expr_B2B = new int[4];
			expr_B2B[0] = 1;
			arg_B34_0.Value = new decimal(expr_B2B);
			this.btnXuatTL.BackColor = SystemColors.ButtonHighlight;
			this.btnXuatTL.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnXuatTL.BorderColor = Color.PaleVioletRed;
			this.btnXuatTL.BorderRadius = 5;
			this.btnXuatTL.BorderSize = 0;
			this.btnXuatTL.FlatAppearance.BorderSize = 0;
			this.btnXuatTL.FlatStyle = FlatStyle.Flat;
			this.btnXuatTL.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXuatTL.ForeColor = Color.Black;
			this.btnXuatTL.Image = Resources.arrow_forward_119427;
			this.btnXuatTL.ImageAlign = ContentAlignment.MiddleRight;
			this.btnXuatTL.Location = new Point(28, 101);
			this.btnXuatTL.Name = "btnXuatTL";
			this.btnXuatTL.Size = new Size(98, 60);
			this.btnXuatTL.TabIndex = 5;
			this.btnXuatTL.Text = "Xuất";
			this.btnXuatTL.TextAlign = ContentAlignment.MiddleLeft;
			this.btnXuatTL.TextColor = Color.Black;
			this.btnXuatTL.UseVisualStyleBackColor = false;
			this.btnXuatTL.Click += new EventHandler(this.btnXuatTL_Click);
			this.btnXuatNS.BackColor = SystemColors.ButtonHighlight;
			this.btnXuatNS.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnXuatNS.BorderColor = Color.PaleVioletRed;
			this.btnXuatNS.BorderRadius = 5;
			this.btnXuatNS.BorderSize = 0;
			this.btnXuatNS.FlatAppearance.BorderSize = 0;
			this.btnXuatNS.FlatStyle = FlatStyle.Flat;
			this.btnXuatNS.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXuatNS.ForeColor = Color.Black;
			this.btnXuatNS.Image = Resources.arrow_forward_119427;
			this.btnXuatNS.ImageAlign = ContentAlignment.MiddleRight;
			this.btnXuatNS.Location = new Point(28, 232);
			this.btnXuatNS.Name = "btnXuatNS";
			this.btnXuatNS.Size = new Size(98, 60);
			this.btnXuatNS.TabIndex = 6;
			this.btnXuatNS.Text = "Xuất";
			this.btnXuatNS.TextAlign = ContentAlignment.MiddleLeft;
			this.btnXuatNS.TextColor = Color.Black;
			this.btnXuatNS.UseVisualStyleBackColor = false;
			this.btnXuatNS.Click += new EventHandler(this.btnXuatNS_Click);
			this.btnXuatBS.BackColor = SystemColors.ButtonHighlight;
			this.btnXuatBS.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnXuatBS.BorderColor = Color.PaleVioletRed;
			this.btnXuatBS.BorderRadius = 5;
			this.btnXuatBS.BorderSize = 0;
			this.btnXuatBS.FlatAppearance.BorderSize = 0;
			this.btnXuatBS.FlatStyle = FlatStyle.Flat;
			this.btnXuatBS.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnXuatBS.ForeColor = Color.Black;
			this.btnXuatBS.Image = Resources.arrow_forward_119427;
			this.btnXuatBS.ImageAlign = ContentAlignment.MiddleRight;
			this.btnXuatBS.Location = new Point(28, 366);
			this.btnXuatBS.Name = "btnXuatBS";
			this.btnXuatBS.Size = new Size(98, 60);
			this.btnXuatBS.TabIndex = 7;
			this.btnXuatBS.Text = "Xuất";
			this.btnXuatBS.TextAlign = ContentAlignment.MiddleLeft;
			this.btnXuatBS.TextColor = Color.Black;
			this.btnXuatBS.UseVisualStyleBackColor = false;
			this.btnXuatBS.Click += new EventHandler(this.btnXuatBS_Click_1);
			this.btnBST.BackColor = SystemColors.ButtonHighlight;
			this.btnBST.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnBST.BorderColor = Color.PaleVioletRed;
			this.btnBST.BorderRadius = 5;
			this.btnBST.BorderSize = 0;
			this.btnBST.FlatAppearance.BorderSize = 0;
			this.btnBST.FlatStyle = FlatStyle.Flat;
			this.btnBST.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnBST.ForeColor = Color.Black;
			this.btnBST.Image = Resources.arrow_forward_119427;
			this.btnBST.ImageAlign = ContentAlignment.MiddleRight;
			this.btnBST.Location = new Point(34, 366);
			this.btnBST.Name = "btnBST";
			this.btnBST.Size = new Size(98, 60);
			this.btnBST.TabIndex = 4;
			this.btnBST.Text = "Xuất";
			this.btnBST.TextAlign = ContentAlignment.MiddleLeft;
			this.btnBST.TextColor = Color.Black;
			this.btnBST.UseVisualStyleBackColor = false;
			this.btnBST.Click += new EventHandler(this.btnBST_Click);
			this.btnxuatTNT.BackColor = SystemColors.ButtonHighlight;
			this.btnxuatTNT.BackgroundColor = SystemColors.ButtonHighlight;
			this.btnxuatTNT.BorderColor = Color.PaleVioletRed;
			this.btnxuatTNT.BorderRadius = 5;
			this.btnxuatTNT.BorderSize = 0;
			this.btnxuatTNT.FlatAppearance.BorderSize = 0;
			this.btnxuatTNT.FlatStyle = FlatStyle.Flat;
			this.btnxuatTNT.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnxuatTNT.ForeColor = Color.Black;
			this.btnxuatTNT.Image = Resources.arrow_forward_119427;
			this.btnxuatTNT.ImageAlign = ContentAlignment.MiddleRight;
			this.btnxuatTNT.Location = new Point(34, 107);
			this.btnxuatTNT.Name = "btnxuatTNT";
			this.btnxuatTNT.Size = new Size(98, 60);
			this.btnxuatTNT.TabIndex = 2;
			this.btnxuatTNT.Text = "Xuất";
			this.btnxuatTNT.TextAlign = ContentAlignment.MiddleLeft;
			this.btnxuatTNT.TextColor = Color.Black;
			this.btnxuatTNT.UseVisualStyleBackColor = false;
			this.btnxuatTNT.Click += new EventHandler(this.btnxuatTNT_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.InactiveBorder;
			base.ClientSize = new Size(952, 463);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "QL_BaoCao";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "BÁO CÁO";
			base.Load += new EventHandler(this.QL_BaoCao_Load);
			base.KeyUp += new KeyEventHandler(this.QL_BaoCao_KeyUp);
			this.panel1.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			((ISupportInitialize)this.nudBST).EndInit();
			((ISupportInitialize)this.nudNST).EndInit();
			base.ResumeLayout(false);
		}
	}
}
