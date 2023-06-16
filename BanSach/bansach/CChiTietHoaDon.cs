using System;
namespace bansach
{
	[Serializable]
	internal class CChiTietHoaDon
	{
		private CSach m_Sach;
		private int m_SoLuongB;
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
		public int SoLuongB
		{
			get
			{
				return this.m_SoLuongB;
			}
			set
			{
				this.m_SoLuongB = value;
			}
		}
		public CChiTietHoaDon()
		{
			this.Sach = new CSach();
			this.m_SoLuongB = 0;
		}
		public CChiTietHoaDon(CSach sach, int soluongB)
		{
			this.Sach = sach;
			this.m_SoLuongB = soluongB;
		}
		public int thanhTien()
		{
			return this.SoLuongB * this.Sach.GiaBan;
		}
	}
}
