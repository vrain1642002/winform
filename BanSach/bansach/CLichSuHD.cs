using System;
namespace bansach
{
	[Serializable]
	internal class CLichSuHD
	{
		private string m_IDLSHD;
		private string m_IDND;
		private string m_TenND;
		private DateTime m_NHoatDong;
		private string m_HoatDong;
		private string m_DoiTuong;
		private string m_IDDoiTuong;
		private string m_NoiDung;
		public string IDLSHD
		{
			get
			{
				return this.m_IDLSHD;
			}
			set
			{
				this.m_IDLSHD = value;
			}
		}
		public string IDND
		{
			get
			{
				return this.m_IDND;
			}
			set
			{
				this.m_IDND = value;
			}
		}
		public string TenND
		{
			get
			{
				return this.m_TenND;
			}
			set
			{
				this.m_TenND = value;
			}
		}
		public DateTime NHoatDong
		{
			get
			{
				return this.m_NHoatDong;
			}
			set
			{
				this.m_NHoatDong = value;
			}
		}
		public string HoatDong
		{
			get
			{
				return this.m_HoatDong;
			}
			set
			{
				this.m_HoatDong = value;
			}
		}
		public string DoiTuong
		{
			get
			{
				return this.m_DoiTuong;
			}
			set
			{
				this.m_DoiTuong = value;
			}
		}
		public string IDDoiTuong
		{
			get
			{
				return this.m_IDDoiTuong;
			}
			set
			{
				this.m_IDDoiTuong = value;
			}
		}
		public string NoiDung
		{
			get
			{
				return this.m_NoiDung;
			}
			set
			{
				this.m_NoiDung = value;
			}
		}
		public CLichSuHD()
		{
			this.m_IDLSHD = "";
			this.m_IDND = "";
			this.m_TenND = "";
			this.m_NHoatDong = DateTime.Now;
			this.m_HoatDong = "";
			this.m_DoiTuong = "";
			this.m_IDDoiTuong = "";
			this.m_NoiDung = "";
		}
	}
}
