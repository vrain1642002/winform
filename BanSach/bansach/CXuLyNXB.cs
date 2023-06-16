using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
namespace bansach
{
	[Serializable]
	internal class CXuLyNXB
	{
		private Dictionary<string, CNhaXuatBan> dsNXB;
		public CXuLyNXB()
		{
			this.dsNXB = new Dictionary<string, CNhaXuatBan>();
		}
		public List<CNhaXuatBan> getDSNXB()
		{
			return this.dsNXB.Values.ToList<CNhaXuatBan>();
		}
		public CNhaXuatBan tim(string IDNXB)
		{
			CNhaXuatBan result;
			try
			{
				result = this.dsNXB[IDNXB];
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
		public bool Them(CNhaXuatBan a)
		{
			CNhaXuatBan cNhaXuatBan = this.tim(a.IDNXB);
			bool flag = cNhaXuatBan == null;
			bool result;
			if (flag)
			{
				this.dsNXB.Add(a.IDNXB, a);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public bool Xoa(string IDNXB)
		{
			return this.dsNXB.Remove(IDNXB);
		}
		public bool Sua(CNhaXuatBan a)
		{
			CNhaXuatBan cNhaXuatBan = this.tim(a.IDNXB);
			bool flag = cNhaXuatBan != null;
			bool result;
			if (flag)
			{
				cNhaXuatBan.IDNXB = a.IDNXB;
				cNhaXuatBan.TenNXB = a.TenNXB;
				cNhaXuatBan.MatKhauNXB = a.MatKhauNXB;
				cNhaXuatBan.SDTNXB = a.SDTNXB;
				cNhaXuatBan.DiaChiNXB = a.DiaChiNXB;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public CNhaXuatBan timTenNXB(string TenNXB)
		{
			CNhaXuatBan result;
			foreach (CNhaXuatBan current in this.dsNXB.Values)
			{
				bool flag = current.TenNXB == TenNXB;
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
				string s2 = s.Substring(3, 7);
				bool flag2 = s.StartsWith("NXB") && this.toanSo(s2);
				result = flag2;
			}
			return result;
		}
		public string CapIDNXB()
		{
			string text = "";
			string result;
			for (int i = 1; i < 9999999; i++)
			{
				text = i.ToString();
				while (text.Length < 7)
				{
					text = "0" + text;
				}
				text = "NXB" + text;
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
				this.dsNXB = (binaryFormatter.Deserialize(fileStream) as Dictionary<string, CNhaXuatBan>);
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
				binaryFormatter.Serialize(fileStream, this.dsNXB);
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
