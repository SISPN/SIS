using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rdiolistofrole.DataSource = Roles.GetAllRoles();
                rdiolistofrole.DataBind();
            }
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.CreateUser(UserName.Text, Password.Text, Email.Text);

            if (rdiolistofrole.SelectedValue == "CK")
            {
                string username = UserName.Text;
                Roles.AddUserToRole(username, "CK");
            }
            else if (rdiolistofrole.SelectedValue == "ADMIN")
            {
                string username = UserName.Text;
                Roles.AddUserToRole(username, "ADMIN");
            }
            else if (rdiolistofrole.SelectedValue == "SuperAdmin")
            {
                string username = UserName.Text;
                Roles.AddUserToRole(username, "SuperAdmin");
            }
        }

    }
}
