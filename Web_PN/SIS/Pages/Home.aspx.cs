using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                SIS.Entity.PersonInfo.VolunterDetail objvolnterinfo = new SIS.Entity.PersonInfo.VolunterDetail();

                string username = HttpContext.Current.User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    MembershipUser user = Membership.GetUser(username);

                    if (user == null)
                    {
                        throw new ArgumentNullException("User");
                    }

                    objvolnterinfo.UserId = Convert.ToString(user.UserName);
                    Entity.PersonalInfo.UserInfo UserInfo = SIS.Services.PersonInfo.PersonInfo.GetVolunterInfo(objvolnterinfo);
                    UserInfo.UserId = Convert.ToString(user.UserName);
                    UserInfo.Role = Roles.GetRolesForUser()[0];

                    Session["UserInfo"] = UserInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}