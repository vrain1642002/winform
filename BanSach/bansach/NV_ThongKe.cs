using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace bansach
{
	public class NV_ThongKe : Form
	{
		private CXuLyNXB xulyNXB;
		private CXuLySach xulySach;
		private IContainer components = null;
		private DataGridView dgvSach;
		private RadioButton rdbHet;
		private DataGridViewTextBoxColumn Column15;
		private DataGridViewTextBoxColumn Column16;
		private DataGridViewTextBoxColumn Column17;
		private DataGridViewTextBoxColumn Column18;
		private DataGridViewTextBoxColumn Column19;
		private DataGridViewTextBoxColumn Column20;
		private DataGridViewTextBoxColumn Column21;
		private DataGridViewTextBoxColumn Column22;
		private DataGridViewTextBoxColumn Column23;
		private TextBox txtMin;
		private Label label2;
		private TextBox txtMax;
		private ComboBox cbxNXB;
		private ComboBox cbxSach;
		private RadioButton rdbTenSach;
		private RadioButton rdbTenNXB;
		private RadioButton rdbKG;
		private GroupBox groupBox2;
		private Panel panel1;
		private Panel panel2;
		private Label label1;
		private RadioButton rdbTang;
		private RadioButton rdbGiam;
		private RadioButton rdbCon;
		public NV_ThongKe()
		{
			this.InitializeComponent();
		}
		private void hienthiComboBoxNXB(List<CNhaXuatBan> ds)
		{
			this.cbxNXB.DisplayMember = "TenNXB";
			this.cbxNXB.ValueMember = "TenNXB";
			this.cbxNXB.DataSource = ds;
		}
		private void hienthiComboBoxSach(List<CSach> ds)
		{
			this.cbxSach.DisplayMember = "TenSach";
			this.cbxSach.ValueMember = "TenSach";
			this.cbxSach.DataSource = ds;
		}
		private void hienthiSach(List<CSach> dmSach)
		{
			bool flag = !this.rdbTang.Checked && this.rdbGiam.Checked && !this.rdbCon.Checked && !this.rdbHet.Checked && !this.rdbTenSach.Checked && !this.rdbTenNXB.Checked && !this.rdbKG.Checked;
			if (flag)
			{
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = dmSach;
				this.dgvSach.DataSource = bindingSource;
			}
			bool @checked = this.rdbCon.Checked;
			if (@checked)
			{
				List<CSach> list = new List<CSach>();
				foreach (CSach current in dmSach)
				{
					bool flag2 = current.SoLuongT > 0;
					if (flag2)
					{
						list.Add(current);
					}
				}
				BindingSource bindingSource2 = new BindingSource();
				bindingSource2.DataSource = list;
				this.dgvSach.DataSource = bindingSource2;
				bool flag3 = list.Count == 0;
				if (flag3)
				{
					MessageBox.Show("Không có sách nào thoả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool checked2 = this.rdbTang.Checked;
			if (checked2)
			{
				List<CSach> list2 = new List<CSach>();
				foreach (CSach current2 in dmSach)
				{
					list2.Add(current2);
				}
				for (int i = 0; i < list2.Count; i++)
				{
					for (int j = list2.Count - 1; j > i; j--)
					{
						bool flag4 = list2[j - 1].GiaBan > list2[j].GiaBan;
						if (flag4)
						{
							CSach value = list2[j - 1];
							list2[j - 1] = list2[j];
							list2[j] = value;
						}
					}
				}
				BindingSource bindingSource3 = new BindingSource();
				bindingSource3.DataSource = list2;
				this.dgvSach.DataSource = bindingSource3;
			}
			bool checked3 = this.rdbGiam.Checked;
			if (checked3)
			{
				List<CSach> list3 = new List<CSach>();
				foreach (CSach current3 in dmSach)
				{
					list3.Add(current3);
				}
				for (int k = 0; k < list3.Count; k++)
				{
					for (int l = list3.Count - 1; l > k; l--)
					{
						bool flag5 = list3[l - 1].GiaBan < list3[l].GiaBan;
						if (flag5)
						{
							CSach value2 = list3[l - 1];
							list3[l - 1] = list3[l];
							list3[l] = value2;
						}
					}
				}
				BindingSource bindingSource4 = new BindingSource();
				bindingSource4.DataSource = list3;
				this.dgvSach.DataSource = bindingSource4;
			}
			bool checked4 = this.rdbHet.Checked;
			if (checked4)
			{
				List<CSach> list4 = new List<CSach>();
				foreach (CSach current4 in dmSach)
				{
					bool flag6 = current4.SoLuongT == 0;
					if (flag6)
					{
						list4.Add(current4);
					}
				}
				BindingSource bindingSource5 = new BindingSource();
				bindingSource5.DataSource = list4;
				this.dgvSach.DataSource = bindingSource5;
				bool flag7 = list4.Count == 0;
				if (flag7)
				{
					MessageBox.Show("Không có sách nào thoả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool checked5 = this.rdbTenSach.Checked;
			if (checked5)
			{
				List<CSach> list5 = new List<CSach>();
				foreach (CSach current5 in dmSach)
				{
					bool flag8 = current5.TenSach == this.cbxSach.Text;
					if (flag8)
					{
						list5.Add(current5);
					}
				}
				BindingSource bindingSource6 = new BindingSource();
				bindingSource6.DataSource = list5;
				this.dgvSach.DataSource = bindingSource6;
				bool flag9 = list5.Count == 0;
				if (flag9)
				{
					MessageBox.Show("Không có sách nào thoả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool checked6 = this.rdbTenNXB.Checked;
			if (checked6)
			{
				List<CSach> list6 = new List<CSach>();
				foreach (CSach current6 in dmSach)
				{
					bool flag10 = current6.TenNXB == this.cbxNXB.Text;
					if (flag10)
					{
						list6.Add(current6);
					}
				}
				BindingSource bindingSource7 = new BindingSource();
				bindingSource7.DataSource = list6;
				this.dgvSach.DataSource = bindingSource7;
				bool flag11 = list6.Count == 0;
				if (flag11)
				{
					MessageBox.Show("Không có sách nào thoả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool checked7 = this.rdbKG.Checked;
			if (checked7)
			{
				bool flag12 = this.txtMin.Text == "" || this.txtMax.Text == "";
				if (flag12)
				{
					MessageBox.Show("Chưa nhập khoảng giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					List<CSach> list7 = new List<CSach>();
					foreach (CSach current7 in dmSach)
					{
						bool flag13 = int.Parse(this.txtMin.Text) <= current7.GiaBan && current7.GiaBan <= int.Parse(this.txtMax.Text);
						if (flag13)
						{
							list7.Add(current7);
						}
					}
					BindingSource bindingSource8 = new BindingSource();
					bindingSource8.DataSource = list7;
					this.dgvSach.DataSource = bindingSource8;
					bool flag14 = list7.Count == 0;
					if (flag14)
					{
						MessageBox.Show("Không có sách nào thoả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}
		private void ThongKe_Load(object sender, EventArgs e)
		{
			this.xulyNXB = new CXuLyNXB();
			bool flag = !this.xulyNXB.docFile("DSNhaXuatBan.dat");
			if (flag)
			{
				MessageBox.Show("Không đọc được dữ liệu file DSNhaXuatBan.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiComboBoxNXB(this.xulyNXB.getDSNXB());
			}
			this.xulySach = new CXuLySach();
			bool flag2 = !this.xulySach.docFile("DanhMucSach.dat");
			if (flag2)
			{
				MessageBox.Show("Không đọc được dữ liệu file DanhMucSach.dat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.hienthiSach(this.xulySach.getDSSach());
				this.hienthiComboBoxSach(this.xulySach.getDSSach());
			}
			base.KeyPreview = true;
		}
		private void ThongKe_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Hide();
			MainNV mainNV = new MainNV();
			mainNV.ShowDialog();
			base.Close();
		}
		private void rdbHet_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void txtMin_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void txtMax_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
			if (flag)
			{
				e.Handled = true;
			}
		}
		private void rdbTang_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void rdbGiam_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void rdbTenSach_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void rdbTenNXB_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void rdbCon_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void rdbKG_CheckedChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void cbxSach_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void cbxNXB_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.xulySach = new CXuLySach();
			bool flag = this.xulySach.docFile("DanhMucSach.dat");
			if (flag)
			{
				this.hienthiSach(this.xulySach.getDSSach());
			}
		}
		private void txtMin_TextChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void txtMax_TextChanged(object sender, EventArgs e)
		{
			this.hienthiSach(this.xulySach.getDSSach());
		}
		private void ThongKe_KeyUp(object sender, KeyEventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NV_ThongKe));
			this.dgvSach = new DataGridView();
			this.Column15 = new DataGridViewTextBoxColumn();
			this.Column16 = new DataGridViewTextBoxColumn();
			this.Column17 = new DataGridViewTextBoxColumn();
			this.Column18 = new DataGridViewTextBoxColumn();
			this.Column19 = new DataGridViewTextBoxColumn();
			this.Column20 = new DataGridViewTextBoxColumn();
			this.Column21 = new DataGridViewTextBoxColumn();
			this.Column22 = new DataGridViewTextBoxColumn();
			this.Column23 = new DataGridViewTextBoxColumn();
			this.rdbHet = new RadioButton();
			this.txtMin = new TextBox();
			this.label2 = new Label();
			this.txtMax = new TextBox();
			this.cbxNXB = new ComboBox();
			this.cbxSach = new ComboBox();
			this.rdbTenSach = new RadioButton();
			this.rdbTenNXB = new RadioButton();
			this.rdbKG = new RadioButton();
			this.groupBox2 = new GroupBox();
			this.rdbTang = new RadioButton();
			this.rdbGiam = new RadioButton();
			this.rdbCon = new RadioButton();
			this.panel1 = new Panel();
			this.label1 = new Label();
			this.panel2 = new Panel();
			((ISupportInitialize)this.dgvSach).BeginInit();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.dgvSach.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Times New Roman", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSach.Columns.AddRange(new DataGridViewColumn[]
			{
				this.Column15,
				this.Column16,
				this.Column17,
				this.Column18,
				this.Column19,
				this.Column20,
				this.Column21,
				this.Column22,
				this.Column23
			});
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Times New Roman", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dgvSach.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvSach.Location = new Point(-1, 276);
			this.dgvSach.Name = "dgvSach";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Times New Roman", 12.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dgvSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvSach.RowTemplate.Height = 50;
			this.dgvSach.Size = new Size(944, 568);
			this.dgvSach.TabIndex = 4;
			this.dgvSach.TabStop = false;
			this.Column15.DataPropertyName = "IDSach";
			this.Column15.HeaderText = "ID sách";
			this.Column15.Name = "Column15";
			this.Column15.Width = 79;
			this.Column16.DataPropertyName = "TenSach";
			this.Column16.HeaderText = "Tên sách";
			this.Column16.Name = "Column16";
			this.Column16.Width = 86;
			this.Column17.DataPropertyName = "SoLuongT";
			this.Column17.HeaderText = "Số lượng tồn";
			this.Column17.Name = "Column17";
			this.Column17.Width = 111;
			this.Column18.DataPropertyName = "GiaNhapGanNhat";
			this.Column18.HeaderText = "Giá nhập gần nhất";
			this.Column18.Name = "Column18";
			this.Column18.Visible = false;
			this.Column18.Width = 152;
			this.Column19.DataPropertyName = "GiaBan";
			this.Column19.HeaderText = "Giá bán";
			this.Column19.Name = "Column19";
			this.Column19.Width = 58;
			this.Column20.DataPropertyName = "TenNXB";
			this.Column20.HeaderText = "Tên nhà xuất bản";
			this.Column20.Name = "Column20";
			this.Column20.Width = 112;
			this.Column21.DataPropertyName = "IDNXB";
			this.Column21.HeaderText = "ID nhà xuất bản";
			this.Column21.Name = "Column21";
			this.Column21.Width = 105;
			this.Column22.DataPropertyName = "NXB";
			this.Column22.HeaderText = "Năm xuất bản";
			this.Column22.Name = "Column22";
			this.Column22.Width = 94;
			this.Column23.DataPropertyName = "TenTG";
			this.Column23.HeaderText = "Tên tác giả";
			this.Column23.Name = "Column23";
			this.Column23.Width = 80;
			this.rdbHet.AutoSize = true;
			this.rdbHet.ForeColor = Color.Black;
			this.rdbHet.Location = new Point(16, 109);
			this.rdbHet.Name = "rdbHet";
			this.rdbHet.Size = new Size(212, 25);
			this.rdbHet.TabIndex = 2;
			this.rdbHet.Text = "Danh sách sách hết hàng";
			this.rdbHet.UseVisualStyleBackColor = true;
			this.rdbHet.CheckedChanged += new EventHandler(this.rdbHet_CheckedChanged);
			this.txtMin.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMin.Location = new Point(613, 105);
			this.txtMin.Name = "txtMin";
			this.txtMin.Size = new Size(136, 29);
			this.txtMin.TabIndex = 8;
			this.txtMin.TextChanged += new EventHandler(this.txtMin_TextChanged);
			this.txtMin.KeyPress += new KeyPressEventHandler(this.txtMin_KeyPress_1);
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.ForeColor = Color.Black;
			this.label2.Location = new Point(755, 111);
			this.label2.Name = "label2";
			this.label2.Size = new Size(41, 21);
			this.label2.TabIndex = 176;
			this.label2.Text = "Đến";
			this.label2.TextAlign = ContentAlignment.BottomRight;
			this.txtMax.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtMax.Location = new Point(802, 105);
			this.txtMax.Name = "txtMax";
			this.txtMax.Size = new Size(136, 29);
			this.txtMax.TabIndex = 9;
			this.txtMax.TextChanged += new EventHandler(this.txtMax_TextChanged);
			this.txtMax.KeyPress += new KeyPressEventHandler(this.txtMax_KeyPress_1);
			this.cbxNXB.FormattingEnabled = true;
			this.cbxNXB.Location = new Point(613, 171);
			this.cbxNXB.Name = "cbxNXB";
			this.cbxNXB.Size = new Size(243, 29);
			this.cbxNXB.TabIndex = 6;
			this.cbxNXB.SelectedIndexChanged += new EventHandler(this.cbxNXB_SelectedIndexChanged);
			this.cbxSach.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbxSach.FormattingEnabled = true;
			this.cbxSach.Location = new Point(155, 174);
			this.cbxSach.Name = "cbxSach";
			this.cbxSach.Size = new Size(243, 29);
			this.cbxSach.TabIndex = 4;
			this.cbxSach.SelectedIndexChanged += new EventHandler(this.cbxSach_SelectedIndexChanged);
			this.rdbTenSach.AutoSize = true;
			this.rdbTenSach.ForeColor = Color.Black;
			this.rdbTenSach.Location = new Point(16, 178);
			this.rdbTenSach.Name = "rdbTenSach";
			this.rdbTenSach.Size = new Size(133, 25);
			this.rdbTenSach.TabIndex = 3;
			this.rdbTenSach.Text = "Theo tên sách";
			this.rdbTenSach.UseVisualStyleBackColor = true;
			this.rdbTenSach.CheckedChanged += new EventHandler(this.rdbTenSach_CheckedChanged);
			this.rdbTenNXB.AutoSize = true;
			this.rdbTenNXB.ForeColor = Color.Black;
			this.rdbTenNXB.Location = new Point(435, 175);
			this.rdbTenNXB.Name = "rdbTenNXB";
			this.rdbTenNXB.Size = new Size(137, 25);
			this.rdbTenNXB.TabIndex = 5;
			this.rdbTenNXB.Text = "Theo tên NXB";
			this.rdbTenNXB.UseVisualStyleBackColor = true;
			this.rdbTenNXB.CheckedChanged += new EventHandler(this.rdbTenNXB_CheckedChanged);
			this.rdbKG.AutoSize = true;
			this.rdbKG.ForeColor = Color.Black;
			this.rdbKG.Location = new Point(435, 111);
			this.rdbKG.Name = "rdbKG";
			this.rdbKG.Size = new Size(172, 25);
			this.rdbKG.TabIndex = 7;
			this.rdbKG.Text = "Theo khoảng giá từ";
			this.rdbKG.UseVisualStyleBackColor = true;
			this.rdbKG.CheckedChanged += new EventHandler(this.rdbKG_CheckedChanged);
			this.groupBox2.BackColor = SystemColors.ActiveCaption;
			this.groupBox2.Controls.Add(this.rdbTang);
			this.groupBox2.Controls.Add(this.rdbGiam);
			this.groupBox2.Controls.Add(this.rdbCon);
			this.groupBox2.Controls.Add(this.rdbKG);
			this.groupBox2.Controls.Add(this.rdbHet);
			this.groupBox2.Controls.Add(this.rdbTenNXB);
			this.groupBox2.Controls.Add(this.rdbTenSach);
			this.groupBox2.Controls.Add(this.cbxSach);
			this.groupBox2.Controls.Add(this.cbxNXB);
			this.groupBox2.Controls.Add(this.txtMax);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtMin);
			this.groupBox2.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.Location = new Point(-1, -2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(944, 229);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thống kê";
			this.rdbTang.AutoSize = true;
			this.rdbTang.ForeColor = Color.Black;
			this.rdbTang.Location = new Point(435, 28);
			this.rdbTang.Name = "rdbTang";
			this.rdbTang.Size = new Size(161, 25);
			this.rdbTang.TabIndex = 178;
			this.rdbTang.Text = "Theo giá tăng dần";
			this.rdbTang.UseVisualStyleBackColor = true;
			this.rdbTang.CheckedChanged += new EventHandler(this.rdbTang_CheckedChanged);
			this.rdbGiam.AutoSize = true;
			this.rdbGiam.ForeColor = Color.Black;
			this.rdbGiam.Location = new Point(435, 69);
			this.rdbGiam.Name = "rdbGiam";
			this.rdbGiam.Size = new Size(165, 25);
			this.rdbGiam.TabIndex = 177;
			this.rdbGiam.Text = "Theo giá giảm dần";
			this.rdbGiam.UseVisualStyleBackColor = true;
			this.rdbGiam.CheckedChanged += new EventHandler(this.rdbGiam_CheckedChanged);
			this.rdbCon.AutoSize = true;
			this.rdbCon.Checked = true;
			this.rdbCon.ForeColor = Color.Black;
			this.rdbCon.Location = new Point(16, 46);
			this.rdbCon.Name = "rdbCon";
			this.rdbCon.Size = new Size(218, 25);
			this.rdbCon.TabIndex = 1;
			this.rdbCon.TabStop = true;
			this.rdbCon.Text = "Danh sách sách còn hàng";
			this.rdbCon.UseVisualStyleBackColor = true;
			this.rdbCon.CheckedChanged += new EventHandler(this.rdbCon_CheckedChanged);
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panel1.BackColor = Color.Black;
			this.panel1.Location = new Point(-1, 226);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(944, 4);
			this.panel1.TabIndex = 5;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Times New Roman", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = SystemColors.Desktop;
			this.label1.Location = new Point(10, 247);
			this.label1.Name = "label1";
			this.label1.Size = new Size(167, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Danh mục sách";
			this.panel2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel2.BackColor = Color.White;
			this.panel2.BorderStyle = BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Controls.Add(this.dgvSach);
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Location = new Point(1, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(950, 809);
			this.panel2.TabIndex = 6;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.InactiveBorder;
			base.ClientSize = new Size(950, 809);
			base.Controls.Add(this.panel2);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "NV_ThongKe";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "THỐNG KÊ";
			base.FormClosed += new FormClosedEventHandler(this.ThongKe_FormClosed);
			base.Load += new EventHandler(this.ThongKe_Load);
			base.KeyUp += new KeyEventHandler(this.ThongKe_KeyUp);
			((ISupportInitialize)this.dgvSach).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
