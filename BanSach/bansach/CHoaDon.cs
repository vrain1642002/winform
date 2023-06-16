using System;
using System.Collections.Generic;
namespace bansach
{
	[Serializable]
	internal class CHoaDon
	{
		private string m_IDHoaDon;
		private DateTime m_NgayTaoHD;
		private int m_ThanhTien;
		private int m_Giam;
		private int m_ThanhToan;
		private string m_IDNT;
		private string m_TenNT;
		private string m_SDTNT;
		private string m_TenKH;
		private string m_SDTKH;
		private string m_DiaChiKH;
		private List<CChiTietHoaDon> m_ChiTietHoaDon;
		public string IDHoaDon
		{
			get
			{
				return this.m_IDHoaDon;
			}
			set
			{
				this.m_IDHoaDon = value;
			}
		}
		public DateTime NgayTaoHD
		{
			get
			{
				return this.m_NgayTaoHD;
			}
			set
			{
				this.m_NgayTaoHD = value;
			}
		}
		public int ThanhTien
		{
			get
			{
				return this.m_ThanhTien;
			}
			set
			{
				this.m_ThanhTien = value;
			}
		}
		public int Giam
		{
			get
			{
				return this.m_Giam;
			}
			set
			{
				this.m_Giam = value;
			}
		}
		public int ThanhToan
		{
			get
			{
				return this.m_ThanhToan;
			}
			set
			{
				this.m_ThanhToan = value;
			}
		}
		public string IDNguoiTao
		{
			get
			{
				return this.m_IDNT;
			}
			set
			{
				this.m_IDNT = value;
			}
		}
		public string TenNguoiTao
		{
			get
			{
				return this.m_TenNT;
			}
			set
			{
				this.m_TenNT = value;
			}
		}
		public string SDTNguoiTao
		{
			get
			{
				return this.m_SDTNT;
			}
			set
			{
				this.m_SDTNT = value;
			}
		}
		public string TenKH
		{
			get
			{
				return this.m_TenKH;
			}
			set
			{
				this.m_TenKH = value;
			}
		}
		public string SDTKH
		{
			get
			{
				return this.m_SDTKH;
			}
			set
			{
				this.m_SDTKH = value;
			}
		}
		public string DiaChiKH
		{
			get
			{
				return this.m_DiaChiKH;
			}
			set
			{
				this.m_DiaChiKH = value;
			}
		}
		public List<CChiTietHoaDon> ChiTietHoaDon
		{
			get
			{
				return this.m_ChiTietHoaDon;
			}
		}
		public CHoaDon()
		{
			this.m_IDHoaDon = "";
			this.m_NgayTaoHD = DateTime.Now;
			this.m_IDNT = "";
			this.m_TenNT = "";
			this.m_SDTNT = "";
			this.m_ChiTietHoaDon = new List<CChiTietHoaDon>();
			this.m_ThanhTien = 0;
			this.m_Giam = 0;
			this.m_ThanhToan = 0;
			this.m_TenKH = "";
			this.m_SDTKH = "";
			this.m_DiaChiKH = "";
		}
		public CHoaDon(string IDHoaDon, DateTime NgayTaoHD, string IDNT, string TenNT, string SDTNT, int ThanhTien, int Giam, int ThanhToan, string tenKH, string SDTKH, string DiaChiKH)
		{
			this.m_IDHoaDon = IDHoaDon;
			this.m_NgayTaoHD = NgayTaoHD;
			this.m_IDNT = IDNT;
			this.m_TenNT = TenNT;
			this.m_SDTNT = SDTNT;
			this.m_ChiTietHoaDon = new List<CChiTietHoaDon>();
			this.m_ThanhTien = ThanhTien;
			this.m_Giam = 0;
			this.m_ThanhToan = 0;
			this.m_TenKH = tenKH;
			this.m_SDTKH = SDTKH;
			this.m_DiaChiKH = DiaChiKH;
		}
		public CHoaDon(CHoaDon a)
		{
			this.m_IDHoaDon = a.IDHoaDon;
			this.m_NgayTaoHD = a.NgayTaoHD;
			this.m_IDNT = a.m_IDNT;
			this.m_TenNT = a.m_TenNT;
			this.m_SDTNT = a.m_SDTNT;
			this.m_ChiTietHoaDon = new List<CChiTietHoaDon>();
			this.m_ThanhTien = a.ThanhTien;
			this.m_Giam = 0;
			this.m_ThanhToan = 0;
			this.m_TenKH = a.m_TenKH;
			this.m_SDTKH = a.SDTKH;
			this.m_DiaChiKH = a.DiaChiKH;
		}
		public int tinhTien()
		{
			int num = 0;
			foreach (CChiTietHoaDon current in this.ChiTietHoaDon)
			{
				num += current.thanhTien();
			}
			return num;
		}
	}
}
