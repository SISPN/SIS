using System.Data;
using System;

namespace SIS.Services.Menu
{
    public class MenuDetail
    {

        public static DataSet GetMenuInfo(String[] UserRoleName)
        {
            return Data.Menu.MenuDetail.GetMenuInfo(UserRoleName);
        }
    }
}
