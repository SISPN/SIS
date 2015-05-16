using System;
using System.Web.UI.WebControls;
using System.Data;
using SIS.HelperClass;
using System.Linq;
namespace SIS.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        Entity.PersonalInfo.UserInfo UserInfo = new Entity.PersonalInfo.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLookupInfo();
                ResetForm();



            }
        }

        protected void ResetForm()
        {
            txtFName.Text = "";
            datepicker.Text = "";
            txtMobile.Text = "";
            txtResidence.Text = "";
            txtEmailAddress.Text = "";
        }

        private void BindLookupInfo()
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            UserInfo = SIS.HelperClass.Utility.GetUserInfo();
            SIS.Entity.PersonalInfo.PersonalInfo userinfo = new Entity.PersonalInfo.PersonalInfo();

            userinfo.PersonId = Convert.ToString(txtstudentid.Text.Trim());
            userinfo.FamilyId = Convert.ToString(txtfamilyid.Text.Trim());

            userinfo.FirstName = txtFName.Text;
            userinfo.MiddleName = txtmiddle.Text;
            userinfo.LastName = txtLastName.Text;
            if (Convert.ToString(ddlMandal.SelectedValue) != "-1")
                userinfo.Mandal = Convert.ToString(ddlMandal.SelectedValue);
            else
                userinfo.Mandal = null;

            //if (Convert.ToInt32(ddlMainPerson.SelectedValue) == 1)
            //    userinfo.IsMainPerson = Convert.ToBoolean(true);
            //else
            //    userinfo.IsMainPerson = Convert.ToBoolean(false);

            if (string.IsNullOrWhiteSpace(txtdid.Text.Trim()))
                userinfo.DId = null;
            else
                userinfo.DId = Convert.ToString(txtdid.Text);


            //if (datepicker.Text != "")
            //    userinfo.DOB = Convert.ToDateTime(datepicker.Text);
            //else
            //    userinfo.DOB = null;

            userinfo.MobilePhone = txtMobile.Text;
            userinfo.HomePhone = txtResidence.Text;
            userinfo.Email = txtEmailAddress.Text;

            if (!UserInfo.Role.ToUpper().Equals("Admin".ToUpper()))
            {
                userinfo.Gender = UserInfo.Gender;
            }
            else
                userinfo.Gender = "";

            DataTable resultData = SIS.Services.PersonInfo.PersonInfo.GetUserInfo(userinfo);

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

        protected void dlresultlist_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblDob = (Label)e.Item.FindControl("lblDob");
            if (lblDob != null && !lblDob.Text.Equals(string.Empty))
                lblDob.Text = string.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(lblDob.Text));

            UserInfo = SIS.HelperClass.Utility.GetUserInfo();



            if (UserInfo.MandalOwn != null && UserInfo.MandalOwn.Length != 0 && !(UserInfo.MandalOwn.Length == 1 && string.IsNullOrWhiteSpace(UserInfo.MandalOwn[0])))
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    DataRowView dr = (DataRowView)(e.Item.DataItem);
                    if (!UserInfo.MandalOwn.Contains((string)dr.Row["Mandal"].ToString()))
                    {
                        HyperLink lnkaddmemberbtn = (HyperLink)e.Item.FindControl("hlnkaddmember");
                        lnkaddmemberbtn.Enabled = false;
                        HyperLink lnkeditmemberbtn = (HyperLink)e.Item.FindControl("hlnkedit");
                        lnkeditmemberbtn.Enabled = false;
                    }

                }
            }
        }
    }
}