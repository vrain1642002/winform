using System;
namespace bansach
{
	[Serializable]
	internal class CNhaXuatBan
	{
		private string m_IDNXB;
		private string m_MatKhauNXB;
		private string m_TenNXB;
		private string m_DiaChiNXB;
		private string m_SDTNXB;
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
		public string MatKhauNXB
		{
			get
			{
				return this.m_MatKhauNXB;
			}
			set
			{
				this.m_MatKhauNXB = value;
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
		public string DiaChiNXB
		{
			get
			{
				return this.m_DiaChiNXB;
			}
			set
			{
				this.m_DiaChiNXB = value;
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
		public CNhaXuatBan()
		{
			this.m_IDNXB = "";
			this.m_MatKhauNXB = "";
			this.m_TenNXB = "";
			this.m_DiaChiNXB = "";
			this.m_SDTNXB = "";
		}
		public CNhaXuatBan(string IDNXB, string MatKhauNXB, string TenNXB, string DiaChiNXB, string SDTNXB)
		{
			this.m_IDNXB = IDNXB;
			this.m_MatKhauNXB = MatKhauNXB;
			this.m_TenNXB = TenNXB;
			this.m_DiaChiNXB = DiaChiNXB;
			this.m_SDTNXB = SDTNXB;
		}
		public CNhaXuatBan(CNhaXuatBan a)
		{
			this.m_IDNXB = a.IDNXB;
			this.m_MatKhauNXB = a.MatKhauNXB;
			this.m_TenNXB = a.TenNXB;
			this.m_DiaChiNXB = a.DiaChiNXB;
			this.m_SDTNXB = a.m_SDTNXB;
		}
	}
}
