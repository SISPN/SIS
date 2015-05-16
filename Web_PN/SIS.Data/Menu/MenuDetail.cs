using System.Data;
using System;

namespace SIS.Data.Menu
{
    public class MenuDetail
    {
        public static DataSet GetMenuInfo(String[] UserRoleName)
        {
            DataSet dsMenu = new DataSet();

            DataTable ParentDetail = new DataTable();
            DataTable ChildDetail = new DataTable();

            Guid RoleId  =  GetRoleId(UserRoleName[0]);

            if (RoleId != Guid.Empty)
            {
                dsMenu = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_Menu_SelectMenuDetail", RoleId);
                dsMenu.Tables[0].TableName = "ParentDetail";
                dsMenu.Tables[1].TableName = "ChildDetail";

                dsMenu.Relations.Add("Menu_Role", dsMenu.Tables["ParentDetail"].Columns["MenuId"], dsMenu.Tables["ChildDetail"].Columns["ParentMenuId"]);

            }

            return dsMenu;
        }

        public static Guid GetRoleId(string UserRoleName)
        {
            IDataReader iReader = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetRoleGUID", UserRoleName);
            Guid RoleId = new Guid();
            RoleId = Guid.Empty;
            try
            {
                if (iReader == null) return RoleId;

                while (iReader.Read())
                {
                    RoleId =new Guid(Convert.ToString( iReader["RoleId"]));                   
                }

            }
            finally
            {
                if (iReader != null && !iReader.IsClosed)
                    iReader.Close();
                iReader.Dispose();
            }
            return RoleId;
        }
    }
}
