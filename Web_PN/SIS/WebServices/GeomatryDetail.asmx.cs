using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections.Specialized;

namespace SIS.Pages
{
    /// <summary>
    /// Summary description for GeomatryDetail
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GeomatryDetail : System.Web.Services.WebService
    {

        [WebMethod]
        public CascadingDropDownNameValue[] GetCountry(string knownCategoryValues, string category)
        {

            List<Entity.GeographyDDMenu.CountryDetail> countryList = PopulateCountry();

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (Entity.GeographyDDMenu.CountryDetail dr in countryList)
            {
                string make = (string)dr.Name;
                Guid makeId = (Guid)dr.CountryId;
                values.Add(new CascadingDropDownNameValue(make, makeId.ToString()));
            }
            return values.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetState(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string CountryId;
            if (!kv.ContainsKey("Country") )
            {
                return null;
            }
            else
            {
                CountryId = (string)kv["Country"];
            }


            List<Entity.GeographyDDMenu.StateDetail> StateList  = GetStateList(CountryId);

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (Entity.GeographyDDMenu.StateDetail dr in StateList)
            {
                values.Add(new CascadingDropDownNameValue((string)dr.Name, dr.StateId.ToString()));
            }
            return values.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetDistrict(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string DistrictId;
            if (!kv.ContainsKey("State"))
            {
                return null;
            }
            else
            {
                DistrictId = (string)kv["State"];
            }
            List<Entity.GeographyDDMenu.DistrictDetail> DistrictList = GetDistrictList(DistrictId);

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (Entity.GeographyDDMenu.DistrictDetail dr in DistrictList)
            {
                values.Add(new CascadingDropDownNameValue((string)dr.Name, dr.DistrictId.ToString()));
            }
            return values.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetCity(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string CityId;
            if (!kv.ContainsKey("District"))
            {
                return null;
            }
            else
            {
                CityId = (string)kv["District"];
            }
            List<Entity.GeographyDDMenu.CityDetail> CityList = GetCityList(CityId);

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach (Entity.GeographyDDMenu.CityDetail dr in CityList)
            {
                values.Add(new CascadingDropDownNameValue((string)dr.Name, dr.CityId.ToString()));
            }
            return values.ToArray();
        }

        private List<Entity.GeographyDDMenu.CountryDetail> PopulateCountry()
        {
          
            List<Entity.GeographyDDMenu.CountryDetail> countryList = SIS.Services.Geography.Geography.GetCountryList();
            return countryList;
        }

        private List<Entity.GeographyDDMenu.StateDetail> GetStateList(string countryid)
        {

            List<Entity.GeographyDDMenu.StateDetail> StateList = SIS.Services.Geography.Geography.GetStateList(countryid);
            return StateList;
        }

        private List<Entity.GeographyDDMenu.DistrictDetail> GetDistrictList(string Districtid)
        {

            List<Entity.GeographyDDMenu.DistrictDetail> DistrictList = SIS.Services.Geography.Geography.GetDistrictList(Districtid);
            return DistrictList;
        }

        private List<Entity.GeographyDDMenu.CityDetail> GetCityList(string Cityid)
        {

            List<Entity.GeographyDDMenu.CityDetail> CityList = SIS.Services.Geography.Geography.GetCityList(Cityid);
            return CityList;
        }
    }
}
