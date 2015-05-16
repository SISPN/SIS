using System;
using System.Web.UI.WebControls;
using System.Data;
using SIS.HelperClass;

namespace SIS.Pages
{
    public partial class SearchAnkutDetail : System.Web.UI.Page
    {
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
            txtstudentid.Text = "";
            txtFName.Text = "";
            txtmiddle.Text = "";
            txtLastName.Text = "";
            txtMobile.Text = "";
        }

        private void BindLookupInfo()
        {
           
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SIS.Entity.PersonalInfo.PersonalInfo userinfo = new Entity.PersonalInfo.PersonalInfo();

            userinfo.PersonId = Convert.ToString(txtstudentid.Text.Trim());
            userinfo.FirstName = txtFName.Text;
            userinfo.MiddleName = txtmiddle.Text;
            userinfo.LastName = txtLastName.Text;
            userinfo.MobilePhone = txtMobile.Text;
            userinfo.FamilyId = "";
            userinfo.HomePhone = "";
            userinfo.Email = "";

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

       
    }
}