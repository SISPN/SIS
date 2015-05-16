using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using SIS.Entity.Xetra;
using System.Collections.Specialized;

namespace SIS.Pages
{
    /// <summary>
    /// Summary description for XetraMandal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class XetraMandal : System.Web.Services.WebService
    {

        [WebMethod]
        public CascadingDropDownNameValue[] GetXetra(string knownCategoryValues, string category)
        {

            List<XetraInfo> XetraList = GetXetraList();

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (XetraInfo dr in XetraList)
            {
                string XetraName = (string)dr.Name;
                string XetraCode = (string)dr.Code;
                values.Add(new CascadingDropDownNameValue(XetraName, XetraCode.ToString()));
            }
            return values.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetMandalFromMapId(string knownCategoryValues, string category, string contextKey)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string XetraId;
            if (!kv.ContainsKey("Xetra"))
            {
                return null;
            }
            else
            {
                XetraId = (string)kv["Xetra"];
            }
            //List<MandalInfo> MandalInfoList = GetMandalList();
            if (XetraId == "2")
                XetraId = "250";
            List<MandalInfo> tempMandalList = GetMandalNameList(XetraId);
            List<MandalInfo> MandalList = new List<MandalInfo>();

            if (!string.IsNullOrWhiteSpace(contextKey) && (contextKey.Split(':')[0]).ToUpper() != "ADMIN")
            {
                string[] mandalcodes = (contextKey.Split(':')[1]).Split(',');


                for (int i = 0; i < tempMandalList.Count; i++)
                {
                    if (mandalcodes.Contains(Convert.ToString( tempMandalList[i].Name)) || tempMandalList[i].Code == "-1")
                    {
                        MandalList.Add(tempMandalList[i]);
                    }
                }
            }
            else
                MandalList = tempMandalList;

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (MandalInfo dr in MandalList)
            {
                string Name = (string)dr.Name;
                int MandalId = (int)dr.MandalId;
                values.Add(new CascadingDropDownNameValue(Name, MandalId.ToString()));
            }
            return values.ToArray();
        }


        [WebMethod]
        public CascadingDropDownNameValue[] GetMandal(string knownCategoryValues, string category, string contextKey)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string XetraId;
            if (!kv.ContainsKey("Xetra"))
            {
                return null;
            }
            else
            {
                XetraId = (string)kv["Xetra"];
            }


            List<MandalInfo> tempMandalList = GetMandalList(XetraId);
            List<MandalInfo> MandalList = new List<MandalInfo>();


            if (!string.IsNullOrWhiteSpace(contextKey) && (contextKey.Split(':')[0]).ToUpper() != "ADMIN")
            {
                string[] mandalcodes = (contextKey.Split(':')[1]).Split(',');


                for (int i = 0; i < tempMandalList.Count; i++)
                {
                    if (mandalcodes.Contains(tempMandalList[i].Code) || tempMandalList[i].Code == "-1")
                    {
                        MandalList.Add(tempMandalList[i]);
                    }
                }
            }
            else
                MandalList = tempMandalList;

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (MandalInfo dr in MandalList)
            {
                values.Add(new CascadingDropDownNameValue((string)dr.Name, dr.Code.ToString()));
            }
            return values.ToArray();
        }

        //[WebMethod]
        //public CascadingDropDownNameValue[] GetMandal(string knownCategoryValues, string category)
        //{
        //    StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    string XetraId;
        //    if (!kv.ContainsKey("Xetra"))
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        XetraId = (string)kv["Xetra"];
        //    }

        //    List<MandalInfo> MandalList = GetMandalList(XetraId);

        //    List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //    foreach (MandalInfo dr in MandalList)
        //    {
        //        values.Add(new CascadingDropDownNameValue((string)dr.Name, dr.Code.ToString()));
        //    }
        //    return values.ToArray();
        //}

        [WebMethod]
        public CascadingDropDownNameValue[] GetNameFromMandal(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string MandalId;
            if (!kv.ContainsKey("Mandal"))
            {
                return null;
            }
            else
            {
                MandalId = (string)kv["Mandal"];
            }

            List<MandalInfo> MandalList = GetNameListFromMandal(MandalId);

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (MandalInfo dr in MandalList)
            {
                values.Add(new CascadingDropDownNameValue((string)dr.Name, dr.Code.ToString()));
            }
            return values.ToArray();
        }

        private List<MandalInfo> GetNameListFromMandal(string MandalId)
        {
            List<MandalInfo> mandalList = SIS.Services.Xetra.XetraMandal.GetNameListFromMandal(MandalId);
            return mandalList;
        }

        private List<XetraInfo> GetXetraList()
        {

            List<XetraInfo> xetraList = SIS.Services.Xetra.XetraMandal.GetXetraList();
            return xetraList;
        }

        private List<MandalInfo> GetMandalList(string XetraCode)
        {

            List<MandalInfo> mandalList = SIS.Services.Xetra.XetraMandal.GetMandalList(XetraCode);
            return mandalList;
        }


        private List<MandalInfo> GetMandalNameList(string xetra)
        {

            List<MandalInfo> mandalList = SIS.Services.Xetra.XetraMandal.GetMandalNameList(xetra);
            return mandalList;
        }
    }
}
