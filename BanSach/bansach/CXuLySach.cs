using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
namespace bansach
{
	[Serializable]
	internal class CXuLySach
	{
		private Dictionary<string, CSach> dsSach;
		public CXuLySach()
		{
			this.dsSach = new Dictionary<string, CSach>();
		}
		public List<CSach> getDSSach()
		{
			return this.dsSach.Values.ToList<CSach>();
		}
		public CSach tim(string IDSach)
		{
			CSach result;
			try
			{
				result = this.dsSach[IDSach];
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
		public bool them(CSach a)
		{
			CSach cSach = this.tim(a.IDSach);
			bool flag = cSach == null;
			bool result;
			if (flag)
			{
				this.dsSach.Add(a.IDSach, a);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public bool xoa(string IDSach)
		{
			return this.dsSach.Remove(IDSach);
		}
		public bool sua(CSach a)
		{
			CSach cSach = this.tim(a.IDSach);
			bool flag = cSach != null;
			bool result;
			if (flag)
			{
				cSach.IDSach = a.IDSach;
				cSach.TenSach = a.TenSach;
				cSach.IDNXB = a.IDNXB;
				cSach.TenNXB = a.TenNXB;
				cSach.NXB = a.NXB;
				cSach.GiaBan = a.GiaBan;
				cSach.GiaNhapGanNhat = a.GiaNhapGanNhat;
				cSach.SoLuongT = a.SoLuongT;
				cSach.TenTG = a.TenTG;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public CSach timTenSach(string TenSach)
		{
			CSach result;
			foreach (CSach current in this.dsSach.Values)
			{
				bool flag = current.TenSach == TenSach;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
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
				string s2 = s.Substring(1, 9);
				bool flag2 = s.StartsWith("S") && this.toanSo(s2);
				result = flag2;
			}
			return result;
		}
		public string CapIDSach()
		{
			string text = "";
			string result;
			for (int i = 1; i < 9999999; i++)
			{
				text = i.ToString();
				while (text.Length < 9)
				{
					text = "0" + text;
				}
				text = "S" + text;
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
		public bool docFile(string tenfile)
		{
			bool result;
			try
			{
				FileStream fileStream = new FileStream(tenfile, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				this.dsSach = (binaryFormatter.Deserialize(fileStream) as Dictionary<string, CSach>);
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
				binaryFormatter.Serialize(fileStream, this.dsSach);
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
