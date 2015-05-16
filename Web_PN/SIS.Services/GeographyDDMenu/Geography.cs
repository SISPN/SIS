using System.Collections.Generic;
using SIS.Entity.GeographyDDMenu;
using System;
namespace SIS.Services.Geography
{
    public class Geography
    {
        public static List<Entity.GeographyDDMenu.CountryDetail> GetCountryList()
        {
            List<Entity.GeographyDDMenu.CountryDetail> countryList = Data.Geography.Geography.GetCountryList();
           CountryDetail countryInfo = new CountryDetail();
           countryInfo.Name = "---Select---";
           countryInfo.Code = "-1";
           countryInfo.CountryId = Guid.Empty;
           countryList.Insert(0, countryInfo);

           return countryList;
        }

      

        public static List<StateDetail> GetStateList(string CountryCode)
        {
            List<StateDetail> StateList =  new List<StateDetail>();
            if(CountryCode != "-1")
                StateList = Data.Geography.Geography.GetStateList(CountryCode);

            StateDetail StateInfo = new StateDetail();
            StateInfo.Name = "---Select---";
            StateInfo.Code = "-1";
            StateInfo.StateId = Guid.Empty;
            StateList.Insert(0, StateInfo);
            return StateList;
        }

        public static List<DistrictDetail> GetDistrictList(string StateCode)
        {
            List<DistrictDetail> DistrictList =new List<DistrictDetail>();
            if (StateCode != "-1")
                DistrictList = Data.Geography.Geography.GetDistrictList(StateCode);

            DistrictDetail DistrictInfo = new DistrictDetail();
            DistrictInfo.Name = "---Select---";
            DistrictInfo.Code = "-1";
            DistrictInfo.DistrictId = Guid.Empty;
            DistrictList.Insert(0, DistrictInfo);
            return DistrictList;
        }



        public static List<CityDetail> GetCityList(string DistrictCode)
        {
            List<CityDetail> CityList =new List<CityDetail>();
            if(DistrictCode !="-1")
                CityList  = Data.Geography.Geography.GetCityList(DistrictCode);

            CityDetail CityInfo = new CityDetail();
            CityInfo.Name = "---Select---";
            CityInfo.Code = "-1";
            CityInfo.CityId = Guid.Empty;
            CityList.Insert(0, CityInfo);
            return CityList;
        }
    }
}
