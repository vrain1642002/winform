using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
namespace bansach
{
	[Serializable]
	internal class CXuLyNV
	{
		private Dictionary<string, CNhanVien> dsNV;
		public CXuLyNV()
		{
			this.dsNV = new Dictionary<string, CNhanVien>();
		}
		public List<CNhanVien> getDSNV()
		{
			return this.dsNV.Values.ToList<CNhanVien>();
		}
		public CNhanVien tim(string IDUses)
		{
			CNhanVien result;
			try
			{
				result = this.dsNV[IDUses];
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
		public bool timQl()
		{
			bool result;
			foreach (CNhanVien current in this.dsNV.Values)
			{
				bool flag = current.LoaiNV == "Quản Lý";
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public bool toanSo(string s)
		{
			int num = 1;
			for (int i = 0; i < s.Length; i++)
			{
				bool flag = s[i] >= '0' && s[i] <= '9';
				if (!flag)
				{
					num = 0;
					break;
				}
				num = 1;
			}
			return num == 1;
		}
		public bool coSo(string s)
		{
			bool result;
			for (int i = 0; i < s.Length; i++)
			{
				bool flag = s[i] >= '0' && s[i] <= '9';
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public bool cochu(string s)
		{
			string text = s.ToUpper();
			bool result;
			for (int i = 0; i < text.Length; i++)
			{
				bool flag = text[i] >= 'A' && text[i] <= 'Z';
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public bool toanChu(string s)
		{
			string text = s.ToUpper();
			int num = 1;
			for (int i = 0; i < text.Length; i++)
			{
				bool flag = text[i] >= 'A' && text[i] <= 'Z';
				if (!flag)
				{
					num = 0;
					break;
				}
				num = 1;
			}
			return num == 1;
		}
		public bool ktID(string s)
		{
			bool flag = s.Length != 10;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string s2 = s.Substring(2, 8);
				bool flag2 = s.StartsWith("NV") && this.toanSo(s2);
				result = flag2;
			}
			return result;
		}
		public string CapIDNV()
		{
			string text = "";
			string result;
			for (int i = 1; i < 99999999; i++)
			{
				text = i.ToString();
				while (text.Length < 8)
				{
					text = "0" + text;
				}
				text = "NV" + text;
				bool flag = this.tim(text) == null;
				if (flag)
				{
					result = text;
					return result;
				}
			}
			result = text;
			return result;
		}
		public bool them(CNhanVien a)
		{
			CNhanVien cNhanVien = this.tim(a.IDNV);
			bool flag = cNhanVien == null;
			bool result;
			if (flag)
			{
				this.dsNV.Add(a.IDNV, a);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public bool xoa(string IDNV)
		{
			return this.dsNV.Remove(IDNV);
		}
		public bool sua(CNhanVien a)
		{
			CNhanVien cNhanVien = this.tim(a.IDNV);
			bool flag = cNhanVien != null;
			bool result;
			if (flag)
			{
				cNhanVien.IDNV = a.IDNV;
				cNhanVien.TenNV = a.TenNV;
				cNhanVien.LoaiNV = a.LoaiNV;
				cNhanVien.MatKhauNV = a.MatKhauNV;
				cNhanVien.NgaysinhNV = a.NgaysinhNV;
				cNhanVien.GioitinhNV = a.GioitinhNV;
				cNhanVien.DiaChiNV = a.DiaChiNV;
				cNhanVien.SDTNV = a.SDTNV;
				cNhanVien.LuongCoBanNV = a.LuongCoBanNV;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public bool docFile(string tenfile)
		{
			bool result;
			try
			{
				FileStream fileStream = new FileStream(tenfile, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				this.dsNV = (binaryFormatter.Deserialize(fileStream) as Dictionary<string, CNhanVien>);
				fileStream.Close();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public bool ghiFile(string tenfile)
		{
			bool result;
			try
			{
				FileStream fileStream = new FileStream(tenfile, FileMode.Create);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, this.dsNV);
				fileStream.Close();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
