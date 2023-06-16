using System;
namespace bansach
{
	[Serializable]
	internal class CChiTietPhieuNhap
	{
		private CSach m_Sach;
		private int m_GiaNhap;
		private int m_SoLuongN;
		public CSach Sach
		{
			get
			{
				return this.m_Sach;
			}
			set
			{
				this.m_Sach = value;
			}
		}
		public int GiaNhap
		{
			get
			{
				return this.m_GiaNhap;
			}
			set
			{
				this.m_GiaNhap = value;
			}
		}
		public int SoLuongN
		{
			get
			{
				return this.m_SoLuongN;
			}
			set
			{
				this.m_SoLuongN = value;
			}
		}
		public CChiTietPhieuNhap()
		{
			this.Sach = new CSach();
			this.m_GiaNhap = 0;
			this.m_SoLuongN = 0;
		}
		public CChiTietPhieuNhap(CSach sach, int GiaNhap, int SoLuongN)
		{
			this.Sach = sach;
			this.m_GiaNhap = GiaNhap;
			this.m_SoLuongN = SoLuongN;
		}
		public CChiTietPhieuNhap(CChiTietPhieuNhap a)
		{
			this.Sach = a.Sach;
			this.m_GiaNhap = a.GiaNhap;
			this.m_SoLuongN = a.SoLuongN;
		}
		public int thanhTienNhap()
		{
			return this.GiaNhap * this.SoLuongN;
		}
	}
}
