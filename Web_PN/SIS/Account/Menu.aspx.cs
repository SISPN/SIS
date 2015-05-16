using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace SIS.Account
{
    public partial class Menu : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDMenu();
                BindGrid();
            }
        }

        private void BindGrid()
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            DataSet ds = lookup.GetMenu();
            dlresultlist.DataSource = ds;
            dlresultlist.DataBind();
        }

        private void BindDDMenu()
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            List<SIS.Entity.Lookup.Lookup> lookupInfo = lookup.GetParentMenu();

            SIS.Entity.Lookup.Lookup lookupSelect = new Entity.Lookup.Lookup();
            lookupSelect.DisplayText = "---Select---";
            lookupSelect.Value = "-1";
            lookupInfo.Insert(0, lookupSelect);

            ddlmenu.DataSource = lookupInfo;
            ddlmenu.DataTextField = "DisplayText";
            ddlmenu.DataValueField = "Value";
            ddlmenu.DataBind();

            BindRoles();
       
        }
        protected void dlresultlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Guid MenuId = Guid.Parse(dlresultlist.DataKeys[e.RowIndex].Values["MenuId"].ToString());
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            string res = Convert.ToString(lookup.DeleteMenu(MenuId));

            if (string.IsNullOrEmpty(res))
            {
                BindGrid();
            }
        }
        protected void dlresultlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //DropDownList ddList = (DropDownList)e.Row.FindControl("txtDesig");
                    ////bind dropdownlist

                    //ddList.DataSource = GeneralMethods.BindDropdownFromLookup("SatsangActivity"); ;
                    //ddList.DataTextField = "DisplayText";
                    //ddList.DataValueField = "Value";
                    //ddList.DataBind();

                    //DataRowView dr = e.Row.DataItem as DataRowView;
                    ////ddList.SelectedItem.Text = dr["category_name"].ToString();
                    //ddList.SelectedValue = dr["Designation"].ToString();
                }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            SIS.Entity.Lookup.Menu menu = new Entity.Lookup.Menu();
            menu.MenuId = Guid.NewGuid();
            menu.Name = txtname.Text;
            if (Convert.ToString(ddlmenu.SelectedValue) == "-1")
                menu.ParentMenuId = null;
            else
                menu.ParentMenuId = Guid.Parse(Convert.ToString(ddlmenu.SelectedValue));
            menu.Url = txturl.Text;

            MembershipUser myObject = Membership.GetUser();
            menu.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

            IEnumerable<string> CheckedItems = rdiolistofrole.Items.Cast<ListItem>()
                                    .Where(i => i.Selected)
                                    .Select(i => i.Value);
            menu.Roles = new List<string>();
            foreach (string i in CheckedItems)
                menu.Roles.Add(i);

            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            int res = lookup.InsertMenu(menu);
            BindGrid();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

        public void BindRoles()
        {
            SqlDataAdapter da = new SqlDataAdapter("select RoleId,RoleName from aspnet_Roles", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Roles");

            rdiolistofrole.DataSource = ds;
            rdiolistofrole.DataTextField = "RoleName";
            rdiolistofrole.DataValueField = "RoleId";
            rdiolistofrole.DataBind();

        }

    }

}
