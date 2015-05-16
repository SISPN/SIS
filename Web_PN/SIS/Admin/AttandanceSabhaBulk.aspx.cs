using System;
using System.Web.UI.WebControls;
using System.Data;
using SIS.HelperClass;

namespace SIS.Admin
{
    public partial class AttandanceSabhaBulk : System.Web.UI.Page
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
            SIS.Entity.PersonalInfo.PersonalInfo userinfo = new Entity.PersonalInfo.PersonalInfo();

            userinfo.PersonId = Convert.ToString(txtstudentid.Text.Trim());
            userinfo.FamilyId = Convert.ToString(txtfamilyid.Text.Trim());
            
            userinfo.FirstName = txtFName.Text;
            userinfo.MiddleName = txtmiddle.Text;
            userinfo.LastName = txtLastName.Text;

            if (datepicker.Text != "")
                userinfo.DOB = Convert.ToDateTime(datepicker.Text);
            else
                userinfo.DOB = null;

            userinfo.MobilePhone = txtMobile.Text;
            userinfo.HomePhone = txtResidence.Text;
            userinfo.Email = txtEmailAddress.Text;


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

            HiddenField hdnlstupdate = (HiddenField)e.Item.FindControl("hdnlstupdatedate");

            if (!string.IsNullOrWhiteSpace(Convert.ToString(hdnlstupdate.Value)))
            {
                DateTime dt = Convert.ToDateTime(hdnlstupdate.Value);
                if (DateTime.Now.AddMonths(-3) >= dt)
                {
                    Image img = (Image)e.Item.FindControl("imgneedupdate");
                    img.ImageUrl = "~/Images/needupdate.png";
                }
            }
            else
            {
                Image img = (Image)e.Item.FindControl("imgneedupdate");
                img.ImageUrl = "~/Images/needupdate.png";
            }

            Label lblDob = (Label)e.Item.FindControl("lblDob");
            if (lblDob != null && !lblDob.Text.Equals(string.Empty))
                lblDob.Text = string.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(lblDob.Text));
        }
    }
}