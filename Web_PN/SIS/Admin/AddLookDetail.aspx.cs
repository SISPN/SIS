using System;
using System.Collections.Generic;
using SIS.Entity.Xetra;
using System.Web.Security;

namespace SIS.Admin
{
    public partial class AddLookDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                BindLookupInfo();
            }

            if (ddfield.Text.Trim().ToLower() == "7".ToLower())
            {
                lblRelatedValue.Visible = true;
                ddrelatedvalue.Visible = true;
            }
            else
            {
                lblRelatedValue.Visible = false;
                ddrelatedvalue.Visible = false ;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            SIS.Entity.Lookup.Lookup lkupinfo = new Entity.Lookup.Lookup();

            lkupinfo.LookupMasterId = Convert.ToInt32( ddfield.SelectedValue);
            lkupinfo.Value = txtvalue.Text;
            lkupinfo.DisplayText = txtDisplayText.Text;
            lkupinfo.RelatedFieldValue = ddrelatedvalue.Text;

            MembershipUser myObject = Membership.GetUser();
            lkupinfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));


            if (SIS.Services.Lookup.Lookup.InsertLookup(lkupinfo) == 0)
            {
                if (ddfield.Text.Trim().ToLower() == "12".ToLower())
                {
                    BindXetraInfo();
                }
                lblstatus.Text = "Lookup Detail Updated Successfully.";
            }
            else
            {
                lblstatus.Text = "System Error Contact System admin.";
            }
        }

        private void BindLookupInfo()
        {
            List<SIS.Entity.Lookup.Lookup> StudyInfo;
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            StudyInfo = lookup.GetAllLookupName();

            ddfield.DataSource = StudyInfo;
            ddfield.DataTextField = "Name";
            ddfield.DataValueField = "LookupMasterId";
            ddfield.DataBind();
            BindXetraInfo();
        }


        private void BindXetraInfo()
        {
            ddrelatedvalue.ClearSelection();
            List<XetraInfo> xetraList = SIS.Services.Xetra.XetraMandal.GetXetraList();
            ddrelatedvalue.DataSource = xetraList;
            ddrelatedvalue.DataTextField = "Name";
            ddrelatedvalue.DataValueField = "Code";
            ddrelatedvalue.DataBind();
            ddrelatedvalue.SelectedIndex = 0;         
        }
    }
}