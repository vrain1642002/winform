using System;
using System.Collections.Generic;
namespace bansach
{
	[Serializable]
	internal class CViewHoaDon
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
		public int SoluongB
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
		public string IDHD
		{
			get;
			set;
		}
		public string ThanhTien
		{
			get;
			set;
		}
		public static List<CViewHoaDon> chuyenDoi(CHoaDon hd)
		{
			List<CViewHoaDon> list = new List<CViewHoaDon>();
			foreach (CChiTietHoaDon current in hd.ChiTietHoaDon)
			{
				list.Add(new CViewHoaDon
				{
					IDSach = current.Sach.IDSach,
					TenSach = current.Sach.TenSach,
					GiaBan = current.Sach.GiaBan,
					TenNXB = current.Sach.TenNXB,
					TenTG = current.Sach.TenTG,
					SoluongB = current.SoLuongB,
					IDHD = hd.IDHoaDon,
					ThanhTien = current.thanhTien().ToString()
				});
			}
			return list;
		}
	}
}
