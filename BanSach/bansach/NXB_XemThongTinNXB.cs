using bansach.Properties;
using CustomButton;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class NXB_XemThongTinNXB : Form
	{
		private CXuLyNXB xulyNXB;
		private IContainer components = null;
		private Panel panel1;
		private GroupBox groupBox4;
		private CheckBox chkHien;
		private TextBox txtMKNL;
		private Label label18;
		private Label label21;
		private TextBox txtMKHT;
		private Label label19;
		private TextBox txtMKM;
		private GroupBox groupBox3;
		private Label label20;
		private TextBox txtDCNXBM;
		private TextBox txtSDTNXBM;
		private Label label22;
		private GroupBox groupBox2;
		private Label label1;
		private TextBox txtTENNXB;
		private Label label15;
		private TextBox txtDiaChiNXB;
		private TextBox txtSDTNXB;
		private Label label16;
		private TextBox txtIDNXB;
		private Label label17;
		private VBButton btndoiTT;
		private VBButton btndoiMK;
		public NXB_XemThongTinNXB()
		{
			this.InitializeComponent();
		}
		private void Xemnxb_Load(object sender, EventArgs e)
		{
			this.xulyNXB = new CXuLyNXB();
			bool flag = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.txtIDNXB.Text = CConst.NhaXuatBan.IDNXB;
			this.txtTENNXB.Text = CConst.NhaXuatBan.TenNXB;
			this.txtSDTNXB.Text = CConst.NhaXuatBan.SDTNXB;
			this.txtDiaChiNXB.Text = CConst.NhaXuatBan.DiaChiNXB;
			base.KeyPreview = true;
		}
		private void txtSDTNXBM_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void chkHien_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.chkHien.Checked;
			if (flag)
			{
				this.txtMKHT.UseSystemPasswordChar = true;
				this.txtMKM.UseSystemPasswordChar = true;
				this.txtMKNL.UseSystemPasswordChar = true;
			}
			else
			{
				this.txtMKHT.UseSystemPasswordChar = false;
				this.txtMKM.UseSystemPasswordChar = false;
				this.txtMKNL.UseSystemPasswordChar = false;
			}
		}
		private void btndoiTT_Click(object sender, EventArgs e)
		{
			bool flag = this.txtDCNXBM.Text == "" && this.txtSDTNXBM.Text == "";
			if (flag)
			{
				MessageBox.Show("Bạn chưa điền dữ liệu thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtSDTNXBM.Text != "";
				if (flag2)
				{
					bool flag3 = this.txtSDTNXBM.Text.ToString().Length < 10;
					if (flag3)
					{
						MessageBox.Show("Số điện thoại sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					this.xulyNXB.tim(this.txtIDNXB.Text).SDTNXB = this.txtSDTNXBM.Text;
					this.xulyNXB.ghiFile("DSNhaXuatBan.dat");
					this.txtSDTNXB.Text = this.xulyNXB.tim(this.txtIDNXB.Text).SDTNXB;
					CConst.NhaXuatBan = this.xulyNXB.tim(this.txtIDNXB.Text);
					this.txtSDTNXBM.Text = "";
				}
				bool flag4 = this.txtDCNXBM.Text != "";
				if (flag4)
				{
					this.xulyNXB.tim(this.txtIDNXB.Text).DiaChiNXB = this.txtDCNXBM.Text;
					this.xulyNXB.ghiFile("DSNhaXuatBan.dat");
					this.txtDiaChiNXB.Text = this.xulyNXB.tim(this.txtIDNXB.Text).DiaChiNXB;
					CConst.NhaXuatBan = this.xulyNXB.tim(this.txtIDNXB.Text);
					this.txtDCNXBM.Text = "";
				}
			}
		}
		private void btndoiMK_Click(object sender, EventArgs e)
		{
			bool flag = this.txtMKHT.Text == "" || this.txtMKM.Text == "" || this.txtMKNL.Text == "";
			if (flag)
			{
				MessageBox.Show("Bạn chưa điền đủ dữ liệu thay đổi  mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.txtMKHT.Text != CConst.NhaXuatBan.MatKhauNXB;
				if (flag2)
				{
					MessageBox.Show("Bạn đã nhập sai mật khẩu hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					bool flag3 = this.txtMKM.Text == CConst.NhaXuatBan.MatKhauNXB;
					if (flag3)
					{
						MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.txtMKM.Text = "";
					}
					else
					{
						bool flag4 = this.txtMKM.Text.Length < 10 || !this.xulyNXB.coSo(this.txtMKM.Text) || !this.xulyNXB.cochu(this.txtMKM.Text);
						if (flag4)
						{
							MessageBox.Show("Mật khẩu mới không đủ an toàn,Mật khẩu phải vừa có số lượng kí tự>9,vừa phải bao gồm chữ và số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.txtMKM.Text = "";
						}
						else
						{
							bool flag5 = this.txtMKNL.Text != this.txtMKM.Text;
							if (flag5)
							{
								MessageBox.Show("Mật khẩu nhắc lại không trùng với mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								this.txtMKNL.Text = "";
							}
							else
							{
								MessageBox.Show("Đã đổi thành công mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								this.xulyNXB.tim(this.txtIDNXB.Text).MatKhauNXB = this.txtMKM.Text;
								this.xulyNXB.ghiFile("DSNhaXuatBan.dat");
								CConst.NhaXuatBan = this.xulyNXB.tim(this.txtIDNXB.Text);
								this.txtMKHT.Text = "";
								this.txtMKM.Text = "";
								this.txtMKNL.Text = "";
							}
						}
					}
				}
			}
		}
		private void Xemnxb_KeyUp(object sender, KeyEventArgs e)
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
		private void Xemnxb_FormClosed(object sender, FormClosedEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NXB_XemThongTinNXB));
			this.panel1 = new Panel();
			this.groupBox4 = new GroupBox();
			this.btndoiMK = new VBButton();
			this.chkHien = new CheckBox();
			this.txtMKNL = new TextBox();
			this.label18 = new Label();
			this.label21 = new Label();
			this.txtMKHT = new TextBox();
			this.label19 = new Label();
			this.txtMKM = new TextBox();
			this.groupBox3 = new GroupBox();
			this.btndoiTT = new VBButton();
			this.label20 = new Label();
			this.txtDCNXBM = new TextBox();
			this.txtSDTNXBM = new TextBox();
			this.label22 = new Label();
			this.groupBox2 = new GroupBox();
			this.label1 = new Label();
			this.txtTENNXB = new TextBox();
			this.label15 = new Label();
			this.txtDiaChiNXB = new TextBox();
			this.txtSDTNXB = new TextBox();
			this.label16 = new Label();
			this.txtIDNXB = new TextBox();
			this.label17 = new Label();
			this.panel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Location = new Point(1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(748, 750);
			this.panel1.TabIndex = 0;
			this.groupBox4.BackColor = Color.LightSkyBlue;
			this.groupBox4.Controls.Add(this.btndoiMK);
			this.groupBox4.Controls.Add(this.chkHien);
			this.groupBox4.Controls.Add(this.txtMKNL);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label21);
			this.groupBox4.Controls.Add(this.txtMKHT);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.txtMKM);
			this.groupBox4.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox4.Location = new Point(60, 537);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(634, 182);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Đổi mật khẩu";
			this.btndoiMK.BackColor = Color.DeepSkyBlue;
			this.btndoiMK.BackgroundColor = Color.DeepSkyBlue;
			this.btndoiMK.BorderColor = Color.PaleVioletRed;
			this.btndoiMK.BorderRadius = 5;
			this.btndoiMK.BorderSize = 0;
			this.btndoiMK.FlatAppearance.BorderSize = 0;
			this.btndoiMK.FlatStyle = FlatStyle.Flat;
			this.btndoiMK.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btndoiMK.ForeColor = Color.Black;
			this.btndoiMK.Image = Resources.circle_edit_outline_icon_1397991;
			this.btndoiMK.ImageAlign = ContentAlignment.MiddleLeft;
			this.btndoiMK.Location = new Point(486, 64);
			this.btndoiMK.Name = "btndoiMK";
			this.btndoiMK.Size = new Size(105, 60);
			this.btndoiMK.TabIndex = 8;
			this.btndoiMK.Text = "  Đổi";
			this.btndoiMK.TextColor = Color.Black;
			this.btndoiMK.UseVisualStyleBackColor = false;
			this.btndoiMK.Click += new EventHandler(this.btndoiMK_Click);
			this.chkHien.AutoSize = true;
			this.chkHien.Location = new Point(117, 4);
			this.chkHien.Name = "chkHien";
			this.chkHien.Size = new Size(15, 14);
			this.chkHien.TabIndex = 4;
			this.chkHien.UseVisualStyleBackColor = true;
			this.chkHien.CheckedChanged += new EventHandler(this.chkHien_CheckedChanged);
			this.txtMKNL.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMKNL.Location = new Point(207, 131);
			this.txtMKNL.Name = "txtMKNL";
			this.txtMKNL.Size = new Size(243, 29);
			this.txtMKNL.TabIndex = 7;
			this.txtMKNL.UseSystemPasswordChar = true;
			this.label18.AutoSize = true;
			this.label18.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label18.ForeColor = Color.Black;
			this.label18.Location = new Point(9, 86);
			this.label18.Name = "label18";
			this.label18.Size = new Size(112, 21);
			this.label18.TabIndex = 180;
			this.label18.Text = "Mật khẩu mới";
			this.label21.AutoSize = true;
			this.label21.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label21.ForeColor = Color.Black;
			this.label21.Location = new Point(11, 139);
			this.label21.Name = "label21";
			this.label21.Size = new Size(143, 21);
			this.label21.TabIndex = 175;
			this.label21.Text = "Nhập lại mât khẩu";
			this.txtMKHT.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMKHT.Location = new Point(207, 20);
			this.txtMKHT.Name = "txtMKHT";
			this.txtMKHT.Size = new Size(243, 29);
			this.txtMKHT.TabIndex = 5;
			this.txtMKHT.UseSystemPasswordChar = true;
			this.label19.AutoSize = true;
			this.label19.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label19.ForeColor = Color.Black;
			this.label19.Location = new Point(9, 28);
			this.label19.Name = "label19";
			this.label19.Size = new Size(136, 21);
			this.label19.TabIndex = 173;
			this.label19.Text = "Mật khẩu hiện tại";
			this.txtMKM.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMKM.Location = new Point(207, 78);
			this.txtMKM.Name = "txtMKM";
			this.txtMKM.Size = new Size(243, 29);
			this.txtMKM.TabIndex = 6;
			this.txtMKM.UseSystemPasswordChar = true;
			this.groupBox3.BackColor = Color.LightSkyBlue;
			this.groupBox3.Controls.Add(this.btndoiTT);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.txtDCNXBM);
			this.groupBox3.Controls.Add(this.txtSDTNXBM);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox3.Location = new Point(60, 363);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(628, 119);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Đổi sdt,địa chỉ";
			this.groupBox3.UseCompatibleTextRendering = true;
			this.btndoiTT.BackColor = Color.DeepSkyBlue;
			this.btndoiTT.BackgroundColor = Color.DeepSkyBlue;
			this.btndoiTT.BorderColor = Color.PaleVioletRed;
			this.btndoiTT.BorderRadius = 5;
			this.btndoiTT.BorderSize = 0;
			this.btndoiTT.FlatAppearance.BorderSize = 0;
			this.btndoiTT.FlatStyle = FlatStyle.Flat;
			this.btndoiTT.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btndoiTT.ForeColor = Color.Black;
			this.btndoiTT.Image = Resources.circle_edit_outline_icon_1397991;
			this.btndoiTT.ImageAlign = ContentAlignment.MiddleLeft;
			this.btndoiTT.Location = new Point(486, 31);
			this.btndoiTT.Name = "btndoiTT";
			this.btndoiTT.Size = new Size(105, 60);
			this.btndoiTT.TabIndex = 3;
			this.btndoiTT.Text = "  Đổi";
			this.btndoiTT.TextColor = Color.Black;
			this.btndoiTT.UseVisualStyleBackColor = false;
			this.btndoiTT.Click += new EventHandler(this.btndoiTT_Click);
			this.label20.AutoSize = true;
			this.label20.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label20.ForeColor = Color.Black;
			this.label20.Location = new Point(9, 31);
			this.label20.Name = "label20";
			this.label20.Size = new Size(145, 21);
			this.label20.TabIndex = 172;
			this.label20.Text = "SDT nhà xuất bản";
			this.txtDCNXBM.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDCNXBM.Location = new Point(210, 70);
			this.txtDCNXBM.Name = "txtDCNXBM";
			this.txtDCNXBM.Size = new Size(243, 29);
			this.txtDCNXBM.TabIndex = 2;
			this.txtDCNXBM.WordWrap = false;
			this.txtSDTNXBM.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNXBM.Location = new Point(210, 23);
			this.txtSDTNXBM.MaxLength = 10;
			this.txtSDTNXBM.Name = "txtSDTNXBM";
			this.txtSDTNXBM.Size = new Size(243, 29);
			this.txtSDTNXBM.TabIndex = 1;
			this.txtSDTNXBM.KeyPress += new KeyPressEventHandler(this.txtSDTNXBM_KeyPress);
			this.label22.AutoSize = true;
			this.label22.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label22.ForeColor = Color.Black;
			this.label22.Location = new Point(12, 78);
			this.label22.Name = "label22";
			this.label22.Size = new Size(164, 21);
			this.label22.TabIndex = 167;
			this.label22.Text = "Địa chỉ nhà xuất bản";
			this.groupBox2.BackColor = SystemColors.ActiveCaption;
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txtTENNXB);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.txtDiaChiNXB);
			this.groupBox2.Controls.Add(this.txtSDTNXB);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.txtIDNXB);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.Location = new Point(49, 63);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(634, 246);
			this.groupBox2.TabIndex = 185;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.ForeColor = Color.Black;
			this.label1.Location = new Point(7, 135);
			this.label1.Name = "label1";
			this.label1.Size = new Size(145, 21);
			this.label1.TabIndex = 162;
			this.label1.Text = "SDT nhà xuất bản";
			this.txtTENNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtTENNXB.Location = new Point(216, 84);
			this.txtTENNXB.Name = "txtTENNXB";
			this.txtTENNXB.ReadOnly = true;
			this.txtTENNXB.Size = new Size(243, 29);
			this.txtTENNXB.TabIndex = 161;
			this.txtTENNXB.TabStop = false;
			this.label15.AutoSize = true;
			this.label15.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label15.ForeColor = Color.Black;
			this.label15.Location = new Point(7, 84);
			this.label15.Name = "label15";
			this.label15.Size = new Size(138, 21);
			this.label15.TabIndex = 160;
			this.label15.Text = "Tên nhà xuất bản";
			this.txtDiaChiNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtDiaChiNXB.Location = new Point(216, 185);
			this.txtDiaChiNXB.Name = "txtDiaChiNXB";
			this.txtDiaChiNXB.ReadOnly = true;
			this.txtDiaChiNXB.Size = new Size(243, 29);
			this.txtDiaChiNXB.TabIndex = 159;
			this.txtDiaChiNXB.TabStop = false;
			this.txtDiaChiNXB.WordWrap = false;
			this.txtSDTNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtSDTNXB.Location = new Point(216, 135);
			this.txtSDTNXB.Name = "txtSDTNXB";
			this.txtSDTNXB.ReadOnly = true;
			this.txtSDTNXB.Size = new Size(243, 29);
			this.txtSDTNXB.TabIndex = 158;
			this.txtSDTNXB.TabStop = false;
			this.label16.AutoSize = true;
			this.label16.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label16.ForeColor = Color.Black;
			this.label16.Location = new Point(7, 193);
			this.label16.Name = "label16";
			this.label16.Size = new Size(164, 21);
			this.label16.TabIndex = 157;
			this.label16.Text = "Địa chỉ nhà xuất bản";
			this.txtIDNXB.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtIDNXB.Location = new Point(216, 23);
			this.txtIDNXB.Name = "txtIDNXB";
			this.txtIDNXB.ReadOnly = true;
			this.txtIDNXB.Size = new Size(243, 29);
			this.txtIDNXB.TabIndex = 156;
			this.txtIDNXB.TabStop = false;
			this.label17.AutoSize = true;
			this.label17.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label17.ForeColor = Color.Black;
			this.label17.Location = new Point(7, 31);
			this.label17.Name = "label17";
			this.label17.Size = new Size(128, 21);
			this.label17.TabIndex = 155;
			this.label17.Text = "ID nhà xuất bản";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(749, 753);
			base.Controls.Add(this.panel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NXB_XemThongTinNXB";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "XEM VÀ ĐỔI TT NXB";
			base.FormClosed += new FormClosedEventHandler(this.Xemnxb_FormClosed);
			base.Load += new EventHandler(this.Xemnxb_Load);
			base.KeyUp += new KeyEventHandler(this.Xemnxb_KeyUp);
			this.panel1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
