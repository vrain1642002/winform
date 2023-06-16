using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
namespace bansach
{
	[Serializable]
	internal class CXuLyLichSuHD
	{
		private Dictionary<string, CLichSuHD> dsLSHD;
		public CXuLyLichSuHD()
		{
			this.dsLSHD = new Dictionary<string, CLichSuHD>();
		}
		public List<CLichSuHD> getDSLSHD()
		{
			return this.dsLSHD.Values.ToList<CLichSuHD>();
		}
		public CLichSuHD tim(string IDLSHD)
		{
			CLichSuHD result;
			try
			{
				result = this.dsLSHD[IDLSHD];
			}
			catch (Exception var_1_11)
			{
				result = null;
			}
			return result;
		}
		public bool them(CLichSuHD a)
		{
			CLichSuHD cLichSuHD = this.tim(a.IDLSHD);
			bool flag = cLichSuHD == null;
			bool result;
			if (flag)
			{
				this.dsLSHD.Add(a.IDLSHD, a);
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
				this.dsLSHD = (binaryFormatter.Deserialize(fileStream) as Dictionary<string, CLichSuHD>);
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
				binaryFormatter.Serialize(fileStream, this.dsLSHD);
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
