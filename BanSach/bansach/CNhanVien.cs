using System;
namespace bansach
{
	[Serializable]
	internal class CNhanVien
	{
		private string m_IDNV;
		private string m_MatKhauNV;
		private string m_LoaiNV;
		private string m_TenNV;
		private string m_DiaChi;
		private string m_SDT;
		private string m_GioiTinh;
		private DateTime m_NgaySinh;
		private long m_LuongCoBan;
		public string IDNV
		{
			get
			{
				return this.m_IDNV;
			}
			set
			{
				this.m_IDNV = value;
			}
		}
		public string MatKhauNV
		{
			get
			{
				return this.m_MatKhauNV;
			}
			set
			{
				this.m_MatKhauNV = value;
			}
		}
		public string LoaiNV
		{
			get
			{
				return this.m_LoaiNV;
			}
			set
			{
				this.m_LoaiNV = value;
			}
		}
		public string TenNV
		{
			get
			{
				return this.m_TenNV;
			}
			set
			{
				this.m_TenNV = value;
			}
		}
		public string SDTNV
		{
			get
			{
				return this.m_SDT;
			}
			set
			{
				this.m_SDT = value;
			}
		}
		public string DiaChiNV
		{
			get
			{
				return this.m_DiaChi;
			}
			set
			{
				this.m_DiaChi = value;
			}
		}
		public string GioitinhNV
		{
			get
			{
				return this.m_GioiTinh;
			}
			set
			{
				this.m_GioiTinh = value;
			}
		}
		public DateTime NgaysinhNV
		{
			get
			{
				return this.m_NgaySinh;
			}
			set
			{
				this.m_NgaySinh = value;
			}
		}
		public long LuongCoBanNV
		{
			get
			{
				return this.m_LuongCoBan;
			}
			set
			{
				this.m_LuongCoBan = value;
			}
		}
		public CNhanVien()
		{
			this.m_IDNV = "";
			this.m_MatKhauNV = "";
			this.m_LoaiNV = "";
			this.m_TenNV = "";
			this.m_SDT = "";
			this.m_DiaChi = "";
			this.m_NgaySinh = DateTime.Now;
			this.m_GioiTinh = " ";
			this.m_LuongCoBan = 0L;
		}
		public CNhanVien(string IDNV, string matkhauNV, string TenNV, string loaiNV, string SDT, string diachi, string GioiTinh, DateTime NgaySinh, int LuongCoBan)
		{
			this.m_IDNV = IDNV;
			this.m_MatKhauNV = matkhauNV;
			this.m_LoaiNV = loaiNV;
			this.m_TenNV = TenNV;
			this.m_SDT = SDT;
			this.m_DiaChi = diachi;
			this.m_NgaySinh = DateTime.Now;
			this.m_GioiTinh = GioiTinh;
			this.m_LuongCoBan = (long)LuongCoBan;
		}
		public CNhanVien(CNhanVien a)
		{
			this.m_IDNV = a.IDNV;
			this.m_MatKhauNV = a.m_MatKhauNV;
			this.m_LoaiNV = a.m_LoaiNV;
			this.m_TenNV = a.m_TenNV;
			this.m_SDT = a.m_SDT;
			this.m_DiaChi = a.m_DiaChi;
			this.m_NgaySinh = a.m_NgaySinh;
			this.m_GioiTinh = a.m_GioiTinh;
			this.m_LuongCoBan = a.m_LuongCoBan;
		}
	}
}
