using System;
namespace bansach
{
	[Serializable]
	internal class CSach
	{
		private string m_IDSach;
		private string m_TenSach;
		private int m_SoLuongT;
		private int m_GiaNhapG;
		private int m_GiaBan;
		private string m_IDNXB;
		private string m_TenNXB;
		private int m_NXB;
		private string m_TenTG;
		public string IDSach
		{
			get
			{
				return this.m_IDSach;
			}
			set
			{
				this.m_IDSach = value;
			}
		}
		public string TenSach
		{
			get
			{
				return this.m_TenSach;
			}
			set
			{
				this.m_TenSach = value;
			}
		}
		public int SoLuongT
		{
			get
			{
				return this.m_SoLuongT;
			}
			set
			{
				this.m_SoLuongT = value;
			}
		}
		public int GiaBan
		{
			get
			{
				return this.m_GiaBan;
			}
			set
			{
				this.m_GiaBan = value;
			}
		}
		public int GiaNhapGanNhat
		{
			get
			{
				return this.m_GiaNhapG;
			}
			set
			{
				this.m_GiaNhapG = value;
			}
		}
		public string IDNXB
		{
			get
			{
				return this.m_IDNXB;
			}
			set
			{
				this.m_IDNXB = value;
			}
		}
		public string TenNXB
		{
			get
			{
				return this.m_TenNXB;
			}
			set
			{
				this.m_TenNXB = value;
			}
		}
		public int NXB
		{
			get
			{
				return this.m_NXB;
			}
			set
			{
				this.m_NXB = value;
			}
		}
		public string TenTG
		{
			get
			{
				return this.m_TenTG;
			}
			set
			{
				this.m_TenTG = value;
			}
		}
		public CSach()
		{
			this.m_IDSach = "";
			this.m_TenSach = "";
			this.m_IDNXB = "";
			this.m_TenNXB = "";
			this.m_NXB = 0;
			this.m_TenTG = "";
			this.m_SoLuongT = 0;
			this.m_GiaBan = 0;
			this.m_GiaNhapG = 0;
		}
		public CSach(string IDSach, string TenSach, int SoLuongT, int GiaBan, int GiaNhapG, string IDNXB, string TenNXB, int NamXB, string TenTG)
		{
			this.m_IDSach = IDSach;
			this.m_TenSach = TenSach;
			this.m_IDNXB = IDNXB;
			this.m_TenNXB = TenNXB;
			this.m_NXB = NamXB;
			this.m_TenTG = TenTG;
			this.m_SoLuongT = SoLuongT;
			this.m_GiaNhapG = GiaNhapG;
			this.m_GiaBan = GiaBan;
		}
		public CSach(CSach a)
		{
			this.m_IDSach = a.IDSach;
			this.m_TenSach = a.TenSach;
			this.m_IDNXB = a.IDNXB;
			this.m_TenNXB = a.TenNXB;
			this.m_NXB = a.NXB;
			this.m_TenTG = a.TenTG;
			this.m_SoLuongT = a.SoLuongT;
			this.m_GiaBan = a.m_GiaBan;
			this.m_GiaNhapG = a.m_GiaNhapG;
		}
	}
}
