using System.Collections.Generic;
using SIS.Entity.GeographyDDMenu;
using System.Data;
using SIS.Utility;
using System;

namespace SIS.Data.Geography
{
    public class Geography
    {
       
        public static List<CountryDetail> GetCountryList()
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_Country_Select");

            List<CountryDetail> countryList = new List<CountryDetail>();
            try
            {
                if (iReader == null) return countryList;

                while (iReader.Read())
                {
                    CountryDetail countryInfo = new CountryDetail();
                    countryInfo.CountryId = new Guid(Convert.ToString( iReader["CountryId"]));
                    countryInfo.Name = iReader["Name"].ConvetToString();
                    countryInfo.Code = iReader["Code"].ConvetToString();
                    countryInfo.MapValue = iReader["MapValue"].ConvetToString();
                    countryList.Add(countryInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return countryList;
        }

        public static List<StateDetail> GetStateList(string CountryCode)
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_State_SelectByCountry",new Guid( CountryCode));

            List<StateDetail> StateList = new List<StateDetail>();
            try
            {
                if (iReader == null) return StateList;

                while (iReader.Read())
                {
                    StateDetail StateInfo = new StateDetail();
                    StateInfo.StateId = new Guid(Convert.ToString( iReader["StateId"]));
                    StateInfo.Name = iReader["Name"].ConvetToString();
                    StateInfo.Code = iReader["Code"].ConvetToString();
                    StateInfo.CountryId = new Guid(Convert.ToString(iReader["CountryId"]));
                    StateList.Add(StateInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return StateList;
        }

        public static List<DistrictDetail> GetDistrictList(string StateCode)
        {
            
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_District_SelectByState",new Guid(  StateCode));

            List<DistrictDetail> DistrictList = new List<DistrictDetail>();
            try
            {
                if (iReader == null) return DistrictList;

                while (iReader.Read())
                {
                    DistrictDetail DistrictInfo = new DistrictDetail();
                    DistrictInfo.StateId = new Guid(Convert.ToString(iReader["StateId"]));
                    DistrictInfo.Name = iReader["Name"].ConvetToString();
                    DistrictInfo.Code = iReader["Code"].ConvetToString();
                    DistrictInfo.DistrictId = new Guid(Convert.ToString(iReader["DistrictId"]));
                    DistrictList.Add(DistrictInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return DistrictList;
        }

        public static List<CityDetail> GetCityList(string DistrictCode)
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_City_SelectByDistrict",new Guid(  DistrictCode));

            List<CityDetail> CityList = new List<CityDetail>();
            try
            {
                if (iReader == null) return CityList;

                while (iReader.Read())
                {
                    CityDetail CityInfo = new CityDetail();
                    CityInfo.CityId = new Guid(Convert.ToString(iReader["CityId"]));
                    CityInfo.Name = iReader["Name"].ConvetToString();
                    CityInfo.Code = iReader["Code"].ConvetToString();                  
                    CityList.Add(CityInfo);
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return CityList;
        }
    }
}
