using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SIS.HelperClass
{
    public static class Utility
    {
        public static SIS.Entity.PersonalInfo.UserInfo GetUserInfo()
        {
            try
            {
                Entity.PersonalInfo.UserInfo UserInfo = new Entity.PersonalInfo.UserInfo();
                SIS.Entity.PersonInfo.VolunterDetail objvolnterinfo = new SIS.Entity.PersonInfo.VolunterDetail();

                MembershipUser user = Membership.GetUser();

                if (user == null)
                {
                    throw new ArgumentNullException("User");
                }

                objvolnterinfo.UserId = Convert.ToString(user.UserName);
                UserInfo = SIS.Services.PersonInfo.PersonInfo.GetVolunterInfo(objvolnterinfo);
                UserInfo.UserId = Convert.ToString(user.UserName);
                UserInfo.Role = Roles.GetRolesForUser()[0];

                return UserInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}