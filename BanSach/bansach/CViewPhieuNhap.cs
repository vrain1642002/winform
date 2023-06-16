using System;
using System.Collections.Generic;
namespace bansach
{
	[Serializable]
	internal class CViewPhieuNhap
	{
		public string IDSach
		{
			get;
			set;
		}
		public string TenSach
		{
			get;
			set;
		}
		public int GiaBan
		{
			get;
			set;
		}
		public string TenNXB
		{
			get;
			set;
		}
		public string TenTG
		{
			get;
			set;
		}
		public int NXB
		{
			get;
			set;
		}
		public int GiaNhapGanNhat
		{
			get;
			set;
		}
		public int GiaNhap
		{
			get;
			set;
		}
		public int SoluongN
		{
			get;
			set;
		}
		public string IDPN
		{
			get;
			set;
		}
		public string ThanhTienN
		{
			get;
			set;
		}
		public static List<CViewPhieuNhap> chuyenDoi(CPhieuNhap pn)
		{
			List<CViewPhieuNhap> list = new List<CViewPhieuNhap>();
			foreach (CChiTietPhieuNhap current in pn.ChiTietPhieuNhap)
			{
				list.Add(new CViewPhieuNhap
				{
					IDSach = current.Sach.IDSach,
					TenSach = current.Sach.TenSach,
					GiaBan = current.Sach.GiaBan,
					TenNXB = current.Sach.TenNXB,
					TenTG = current.Sach.TenTG,
					NXB = current.Sach.NXB,
					GiaNhapGanNhat = current.Sach.GiaNhapGanNhat,
					SoluongN = current.SoLuongN,
					GiaNhap = current.GiaNhap,
					ThanhTienN = current.thanhTienNhap().ToString()
				});
			}
			return list;
		}
	}
}
