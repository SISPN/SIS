using SIS.Utility;
using System;

namespace SIS.Data.Lookup
{
    public class Lookup
    {

        public static int InsertLookup(Entity.Lookup.Lookup LookupInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_Lookup_Insert", LookupInfo.LookupMasterId, LookupInfo.DisplayText, LookupInfo.Value, LookupInfo.RelatedFieldValue, LookupInfo.CreatedBy).ConvetToInt32();

        }

        public static int InsertMenu(Entity.Lookup.Menu menu)
        {
            string menuid= Data.Generic.Data.DBInstance.ExecuteScalar("sp_menu_insert", menu.Name, menu.Url,menu.ParentMenuId,menu.CreatedBy).ConvetToString();

            if (!string.IsNullOrWhiteSpace(menuid))
            {
                foreach (string item in menu.Roles)
                {
                    Data.Generic.Data.DBInstance.ExecuteScalar("sp_menurole_insert", Guid.Parse(menuid), Guid.Parse(item), menu.CreatedBy).ConvetToString();
                }
                return 1;
            }
            else
                return 0;
        }

        public static System.Data.DataSet GetMenu()
        {
            return Data.Generic.Data.DBInstance.ExecuteDataSet("sp_menu_selectall");

        }

        public static string DeleteMenu(Guid MenuId)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_menu_delete", MenuId).ConvetToString();
        }
    }
}
