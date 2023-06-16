using System;
using System.Collections.Generic;
namespace bansach
{
	[Serializable]
	internal class CPhieuNhap
	{
		private string m_IDPN;
		private string m_IDNXB;
		private string m_TenNXB;
		private string m_SDTNXB;
		private DateTime m_NgayTaoPN;
		private int m_ThanhTienN;
		private int m_NXBGiam;
		private int m_ThanhToanNXB;
		private string m_TrangThai;
		private List<CChiTietPhieuNhap> m_ChiTietPhieuNhap;
		public string IDPN
		{
			get
			{
				return this.m_IDPN;
			}
			set
			{
				this.m_IDPN = value;
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
		public string SDTNXB
		{
			get
			{
				return this.m_SDTNXB;
			}
			set
			{
				this.m_SDTNXB = value;
			}
		}
		public DateTime NgayTaoPN
		{
			get
			{
				return this.m_NgayTaoPN;
			}
			set
			{
				this.m_NgayTaoPN = value;
			}
		}
		public int ThanhTienN
		{
			get
			{
				return this.m_ThanhTienN;
			}
			set
			{
				this.m_ThanhTienN = value;
			}
		}
		public int NXBGiam
		{
			get
			{
				return this.m_NXBGiam;
			}
			set
			{
				this.m_NXBGiam = value;
			}
		}
		public int ThanhToanNXB
		{
			get
			{
				return this.m_ThanhToanNXB;
			}
			set
			{
				this.m_ThanhToanNXB = value;
			}
		}
		public List<CChiTietPhieuNhap> ChiTietPhieuNhap
		{
			get
			{
				return this.m_ChiTietPhieuNhap;
			}
		}
		public string TrangThai
		{
			get
			{
				return this.m_TrangThai;
			}
			set
			{
				this.m_TrangThai = value;
			}
		}
		public CPhieuNhap()
		{
			this.m_IDPN = "";
			this.m_IDNXB = "";
			this.m_TenNXB = "";
			this.m_SDTNXB = "";
			this.m_NgayTaoPN = DateTime.Now;
			this.m_ThanhTienN = 0;
			this.m_NXBGiam = 0;
			this.m_ThanhToanNXB = 0;
			this.m_ChiTietPhieuNhap = new List<CChiTietPhieuNhap>();
			this.m_TrangThai = "chờ xác nhận";
		}
		public CPhieuNhap(string IDPN, string IDNXB, string TENNXB, string SDTNXB, DateTime NgayTaoPN, int ThanhTienN, int NXBGiam, int ThanhToanNXB, string TrangThai)
		{
			this.m_IDPN = IDPN;
			this.m_IDNXB = IDNXB;
			this.m_TenNXB = TENNXB;
			this.m_SDTNXB = SDTNXB;
			this.m_NgayTaoPN = NgayTaoPN;
			this.m_ThanhTienN = ThanhTienN;
			this.m_NXBGiam = NXBGiam;
			this.m_ThanhToanNXB = ThanhToanNXB;
			this.m_ChiTietPhieuNhap = new List<CChiTietPhieuNhap>();
			this.m_TrangThai = TrangThai;
		}
		public CPhieuNhap(CPhieuNhap a)
		{
			this.m_IDPN = a.m_IDPN;
			this.m_IDNXB = a.m_IDNXB;
			this.m_TenNXB = a.m_TenNXB;
			this.m_SDTNXB = a.m_SDTNXB;
			this.m_NgayTaoPN = a.m_NgayTaoPN;
			this.m_ThanhTienN = a.m_ThanhTienN;
			this.m_NXBGiam = a.m_NXBGiam;
			this.m_ThanhToanNXB = a.m_ThanhToanNXB;
			this.m_ChiTietPhieuNhap = new List<CChiTietPhieuNhap>();
			this.m_TrangThai = a.m_TrangThai;
		}
		public int tinhTienNhap()
		{
			int num = 0;
			foreach (CChiTietPhieuNhap current in this.ChiTietPhieuNhap)
			{
				num += current.thanhTienNhap();
			}
			return num;
		}
	}
}
