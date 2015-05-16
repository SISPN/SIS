using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIS.HelperClass;
using System.Web.Security;
using SIS.Entity.Xetra;
using System.Data;
using System.Collections;

namespace SIS.Pages
{
    public partial class VolunterDetai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLookupInfo();
                BindGrid();
                rdiolistofrole.DataSource = Roles.GetAllRoles();
                rdiolistofrole.DataBind();

            }
        }

        private void BindLookupInfo()
        {
            GeneralMethods.BindDropdownFromLookup(cmbcLocalActivity, "SatsangActivity", true);
        }

        protected void btnsaveandenterother_Click(object sender, EventArgs e)
        {
            SIS.Entity.PersonInfo.VolunterDetail objvolnterinfo = new SIS.Entity.PersonInfo.VolunterDetail();

            objvolnterinfo.VoluntierId = Guid.NewGuid();
            objvolnterinfo.Name = Convert.ToString(myTextBox.Text);
            objvolnterinfo.PersonId = Convert.ToString(hfPersonId.Value);
            objvolnterinfo.Designation = Convert.ToString(cmbcLocalActivity.SelectedValue);
            objvolnterinfo.Gender = Convert.ToString(string.Empty);
         
            objvolnterinfo.UserId = Convert.ToString(UserName.Text);

            if (!string.IsNullOrWhiteSpace(lstmandal1.Text) && !lstmandal1.Text.Equals("---Select---"))
                objvolnterinfo.MandalOwn = Convert.ToString(lstmandal1.Text).Replace(", ",",");
            else
                objvolnterinfo.MandalOwn = string.Empty;

            MembershipUser myObject = Membership.GetUser();
            objvolnterinfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));
            string res = SIS.Services.PersonInfo.PersonInfo.InsertVolunterInfo(objvolnterinfo);

            if (!string.IsNullOrWhiteSpace(Convert.ToString(UserName.Text)) && !string.IsNullOrWhiteSpace(Convert.ToString(Password.Text)))
                CreateUserwithRole();

            BindGrid();
            lblstatus.Text = "Karyakar Detail Updated.";
            ResetForm();
        }

        private void CreateUserwithRole()
        {
            MembershipUser user = Membership.CreateUser(UserName.Text, Password.Text, "");

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
        }

        private void ResetForm()
        {
            myTextBox.Text = "";
            hfPersonId.Value = "";
        }

        protected void ddlXetra_SelectedIndexChanged(object sender, EventArgs e)
        {
            string XetraId = string.Empty;

            //List<MandalInfo> MandalInfoList = GetMandalList();
            if (Convert.ToString(ddlXetra.SelectedValue) == "2")
                XetraId = "250";
            else
                XetraId = Convert.ToString(ddlXetra.SelectedValue);

            List<MandalInfo> tempMandalList = SIS.Services.Xetra.XetraMandal.GetMandalNameList(Convert.ToString(ddlXetra.SelectedValue));
            List<MandalInfo> MandalList = new List<MandalInfo>();

            MandalList = tempMandalList;

            List<Entity.Lookup.Lookup> lst = new List<Entity.Lookup.Lookup>();
            foreach (MandalInfo item in MandalList)
            {
                Entity.Lookup.Lookup ls = new Entity.Lookup.Lookup();
                ls.DisplayText = item.Name;
                ls.Value = item.Code;
                lst.Add(ls);
            }

             lstmandal1.ClearAll();
             lstmandal1.AddItems(lst);

            //lstmandal.DataSource = MandalList;
            //lstmandal.DataTextField = "Name";
            //lstmandal.DataValueField = "Code";
            //lstmandal.DataBind();
        }

        private void BindGrid()
        {
            DataTable resultData = SIS.Services.PersonInfo.PersonInfo.GetVolInfo();

            if (resultData.Rows.Count > 0)
            {
                dlresultlist.DataSource = resultData;
                dlresultlist.DataBind();
                lblnodata.Style.Add("display", "none");

            }
            else
            {
                dlresultlist.DataSource = new DataTable();
                dlresultlist.DataBind();
                lblnodata.Style.Add("display", "block");
            }
        }


        protected void dlresultlist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dlresultlist.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void dlresultlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Guid VoluntierId = Guid.Parse(dlresultlist.DataKeys[e.RowIndex].Values["VoluntierId"].ToString());

            string res = Convert.ToString(Services.PersonInfo.PersonInfo.DeleteVolInfo(VoluntierId));



            if (string.IsNullOrEmpty(res))
            {
                BindGrid();
            }
        }

        protected void dlresultlist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SIS.Entity.PersonInfo.VolunterDetail objvolnterinfo = new SIS.Entity.PersonInfo.VolunterDetail();

            objvolnterinfo.VoluntierId = Guid.Parse(dlresultlist.DataKeys[e.RowIndex].Values["VoluntierId"].ToString());
            objvolnterinfo.Name = ((TextBox)dlresultlist.Rows[e.RowIndex].FindControl("txtName")).Text;
            objvolnterinfo.PersonId = ((TextBox)dlresultlist.Rows[e.RowIndex].FindControl("txtPersonId")).Text;
            objvolnterinfo.Designation = ((DropDownList)dlresultlist.Rows[e.RowIndex].FindControl("txtDesig")).SelectedValue;
            objvolnterinfo.MandalOwn = ((TextBox)dlresultlist.Rows[e.RowIndex].FindControl("txtMandal")).Text;
            MembershipUser myObject = Membership.GetUser();
            objvolnterinfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

            string res = Convert.ToString(Services.PersonInfo.PersonInfo.UpdateVolInfo(objvolnterinfo));

            if (string.IsNullOrEmpty(res))
            {
                dlresultlist.EditIndex = -1;
                BindGrid();
            }
        }

        protected void dlresultlist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dlresultlist.EditIndex = -1;
            BindGrid();

        }

        protected void dlresultlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("txtDesig");
                    //bind dropdownlist

                    ddList.DataSource = GeneralMethods.BindDropdownFromLookup("SatsangActivity"); ;
                    ddList.DataTextField = "DisplayText";
                    ddList.DataValueField = "Value";
                    ddList.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddList.SelectedValue = dr["Designation"].ToString();
                }
            }
        }

    }
}