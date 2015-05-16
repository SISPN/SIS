using System.Collections.Generic;
using SIS.Entity.Xetra;

namespace SIS.Services.Xetra
{
   public class XetraMandal
    {
       public static List<XetraInfo> GetXetraList()
       {
          List<XetraInfo> xetraList =  Data.Xetra.XetraMandal.GetXetraList();
           XetraInfo xetraInfo = new XetraInfo();
           xetraInfo.Name = "---Select---";
           xetraInfo.Code = "-1";
           xetraList.Insert(0, xetraInfo);

           return xetraList;

       }

       public static List<MandalInfo> GetMandalList(string xetraCode)
       {
           List<MandalInfo> mandalList = Data.Xetra.XetraMandal.GetMandalList(xetraCode);
           
           MandalInfo mandalInfo = new MandalInfo();
           mandalInfo.Name = "---Select---";
           mandalInfo.Code = "-1";
           mandalList.Insert(0, mandalInfo);
           return mandalList;
       }



       public static List<MandalInfo> GetMandalNameList(string xetra)
       {
           List<MandalInfo> mandalList = Data.Xetra.XetraMandal.GetMandalNameList(xetra);
           MandalInfo mandalInfo = new MandalInfo();
           mandalInfo.Name = "---Select---";
           mandalInfo.MandalId = -1;
           mandalList.Insert(0, mandalInfo);
           return mandalList;
       }

       public static List<MandalInfo> GetNameListFromMandal(string MandalId)
       {
           List<MandalInfo> mandalList = Data.Xetra.XetraMandal.GetNameListFromMandal(MandalId);
           MandalInfo mandalInfo = new MandalInfo();
           mandalInfo.Name = "---Select---";
           mandalInfo.Code = "-1";
           mandalList.Insert(0, mandalInfo);
           return mandalList;
       }
    }
}
