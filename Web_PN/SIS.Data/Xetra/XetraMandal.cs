using System.Collections.Generic;
using SIS.Entity.Xetra;
using System.Data;
using SIS.Utility;

namespace SIS.Data.Xetra
{
    public class XetraMandal
    {
        public static List<XetraInfo> GetXetraList()
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_Xetra_Select");

            List<XetraInfo> xetraList = new List<XetraInfo>();
            try
            {
                if (iReader == null) return xetraList;

                while (iReader.Read())
                {
                    XetraInfo xetraInfo = new XetraInfo();
                    xetraInfo.XetraId = iReader["XetraId"].ConvetToInt32();
                    xetraInfo.Name = iReader["Name"].ConvetToString();
                    xetraInfo.Code = iReader["Code"].ConvetToString();
                    xetraInfo.MapValue = iReader["MapValue"].ConvetToString();
                    xetraList.Add(xetraInfo);
                }
                
            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return xetraList;
        }

        public static List<MandalInfo> GetMandalList(string xetraCode)
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_Mandal_SelectByXetra", xetraCode);

            List<MandalInfo> mandalList = new List<MandalInfo>();
            try
            {
                if (iReader == null) return mandalList;

                while (iReader.Read())
                {
                    MandalInfo mandalInfo = new MandalInfo();
                    mandalInfo.MandalId = iReader["MandalId"].ConvetToInt32();
                    mandalInfo.Name = iReader["Name"].ConvetToString();
                    mandalInfo.Code = iReader["Code"].ConvetToString();
                    mandalInfo.XetraId = iReader["XetraId"].ConvetToInt32();
                    mandalList.Add(mandalInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return mandalList;
        }


        public static List<MandalInfo> GetMandalNameList(string xetra)
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_Mandal_Select", xetra);

            List<MandalInfo> mandalList = new List<MandalInfo>();
            try
            {
                if (iReader == null) return mandalList;

                while (iReader.Read())
                {
                    MandalInfo mandalInfo = new MandalInfo();
                    mandalInfo.MandalId = iReader["MandalId"].ConvetToInt32();
                    mandalInfo.Name = iReader["MandalName"].ConvetToString();
                    mandalList.Add(mandalInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return mandalList;
        }

        public static List<MandalInfo> GetMandalList()
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_Mandal_Select");

            List<MandalInfo> mandalList = new List<MandalInfo>();
            try
            {
                if (iReader == null) return mandalList;

                while (iReader.Read())
                {
                    MandalInfo mandalInfo = new MandalInfo();
                    mandalInfo.MandalId = iReader["MandalId"].ConvetToInt32();
                    mandalInfo.Name = iReader["MandalName"].ConvetToString();
                    mandalList.Add(mandalInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return mandalList;
        }

        public static List<MandalInfo> GetNameListFromMandal(string MandalId)
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_NamebyMandal", MandalId);

            List<MandalInfo> mandalList = new List<MandalInfo>();
            try
            {
                if (iReader == null) return mandalList;

                while (iReader.Read())
                {
                    MandalInfo mandalInfo = new MandalInfo();
                    mandalInfo.Name = iReader["Name"].ConvetToString();
                    mandalInfo.Code = iReader["Code"].ConvetToString();
                    mandalList.Add(mandalInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return mandalList;
        }
    }
}
