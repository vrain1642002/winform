using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
namespace bansach
{
	[Serializable]
	internal class CXuLyPhieuNhap
	{
		private Dictionary<string, CPhieuNhap> dsPN;
		public CXuLyPhieuNhap()
		{
			this.dsPN = new Dictionary<string, CPhieuNhap>();
		}
		public List<CPhieuNhap> getDSPhieuNhap()
		{
			return this.dsPN.Values.ToList<CPhieuNhap>();
		}
		public CPhieuNhap tim(string IDPN)
		{
			CPhieuNhap result;
			try
			{
				result = this.dsPN[IDPN];
			}
			catch (Exception var_1_11)
			{
				result = null;
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
		public bool them(CPhieuNhap a)
		{
			CPhieuNhap cPhieuNhap = this.tim(a.IDPN);
			bool flag = cPhieuNhap == null;
			bool result;
			if (flag)
			{
				this.dsPN.Add(a.IDPN, a);
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
				this.dsPN = (binaryFormatter.Deserialize(fileStream) as Dictionary<string, CPhieuNhap>);
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
				binaryFormatter.Serialize(fileStream, this.dsPN);
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
