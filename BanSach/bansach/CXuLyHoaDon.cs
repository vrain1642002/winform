using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
namespace bansach
{
	[Serializable]
	internal class CXuLyHoaDon
	{
		private Dictionary<string, CHoaDon> dsHD;
		public CXuLyHoaDon()
		{
			this.dsHD = new Dictionary<string, CHoaDon>();
		}
		public List<CHoaDon> getDSHoaDon()
		{
			return this.dsHD.Values.ToList<CHoaDon>();
		}
		public CHoaDon tim(string IDHoaDon)
		{
			CHoaDon result;
			try
			{
				result = this.dsHD[IDHoaDon];
			}
			catch (Exception var_1_11)
			{
				result = null;
			}
			return result;
		}
		public bool them(CHoaDon a)
		{
			CHoaDon cHoaDon = this.tim(a.IDHoaDon);
			bool flag = cHoaDon == null;
			bool result;
			if (flag)
			{
				this.dsHD.Add(a.IDHoaDon, a);
				result = true;
			}
			else
			{
				result = false;
			}
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
		public bool docFile(string tenfile)
		{
			bool result;
			try
			{
				FileStream fileStream = new FileStream(tenfile, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				this.dsHD = (binaryFormatter.Deserialize(fileStream) as Dictionary<string, CHoaDon>);
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
				binaryFormatter.Serialize(fileStream, this.dsHD);
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
