using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Web.Security;

namespace SIS.Account
{
    public partial class UnLockUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UnlockUserButton_Click(object sender, EventArgs e)
        {           
            if (chkunlock.Checked == true)
            {
                MembershipUser user = Membership.GetUser(UserName.Text);
                if (user.Email.Equals(Email.Text))
                {
                    user.UnlockUser();                
                }
            }
        }
    }
}
