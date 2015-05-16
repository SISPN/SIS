using System.Collections.Generic;
using System.Data;
using SIS.Utility;
using System;

namespace SIS.Data.Lookup
{
    public class Common
    {
        public static List<Entity.Lookup.Lookup> GetLookup()
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_Lookup_Select");
            if (iReader == null) new List<Entity.Lookup.Lookup>();

            List<Entity.Lookup.Lookup> lookupDetails = new List<Entity.Lookup.Lookup>();
            try
            {
                while (iReader.Read())
                {
                    lookupDetails.Add(FillLookup(iReader));
                }
            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                {
                    iReader.Close();
                    iReader.Dispose();
                }
            }
            return lookupDetails;
        }

        private static Entity.Lookup.Lookup FillLookup(IDataReader iReader)
        {
            Entity.Lookup.Lookup lookup = new Entity.Lookup.Lookup();
            lookup.Name = iReader["Name"].ConvetToString();
            lookup.DisplayText = iReader["DisplayText"].ConvetToString();
            lookup.Value = iReader["Value"].ConvetToString();

            return lookup;
        }

        public static List<Entity.Lookup.Lookup> GetAllLookupName()
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_LookupMaster_Select");
            if (iReader == null) new List<Entity.Lookup.Lookup>();

            List<Entity.Lookup.Lookup> lookupDetails = new List<Entity.Lookup.Lookup>();
            try
            {
                while (iReader.Read())
                {
                    lookupDetails.Add(FillLookupMaster(iReader));
                }
            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                {
                    iReader.Close();
                    iReader.Dispose();
                }
            }
            return lookupDetails;
        }

        private static Entity.Lookup.Lookup FillLookupMaster(IDataReader iReader)
        {
            Entity.Lookup.Lookup lookup = new Entity.Lookup.Lookup();
            lookup.Name = iReader["Name"].ConvetToString();
            lookup.LookupMasterId = (iReader["LookupMasterId"]) != DBNull.Value ? Convert.ToInt32(iReader["LookupMasterId"].ConvetToString()) : 0;
            lookup.DisplayText = iReader["Description"].ConvetToString();

            return lookup;
        }


        public static List<Entity.Lookup.Lookup> GetParentMenu()
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("sp_menu_select");
            if (iReader == null) new List<Entity.Lookup.Lookup>();

            List<Entity.Lookup.Lookup> lookupDetails = new List<Entity.Lookup.Lookup>();
            try
            {
                while (iReader.Read())
                {
                    lookupDetails.Add(FillLookup(iReader));
                }
            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                {
                    iReader.Close();
                    iReader.Dispose();
                }
            }
            return lookupDetails;
        }
    }
}
