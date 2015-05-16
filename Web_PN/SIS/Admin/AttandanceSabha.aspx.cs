using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIS.HelperClass;
using System.Web.Security;

namespace SIS.Admin
{
    public partial class AttandanceSabha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["personId"] == null || Request.QueryString["personId"] == "")
                contactExtender.ContextKey = "0";
            else
                contactExtender.ContextKey = Request.QueryString["personId"];


            if (!IsPostBack)
            {
                BindLookupInfo();
            }
        }

        protected void btnsaveandupdatebottom_Click(object sender, EventArgs e)
        {
            savedata();
        }


        protected void btnpresentandupdate_Click(object sender, EventArgs e)
        {
            savedata();
        }

        private void savedata()
        {
            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

            PersonalInfo.PersonId = Convert.ToString(hdnpersonid.Value);
            PersonalInfo.SabhaLookupId = Convert.ToString(ddlsabha.SelectedValue);

            PersonalInfo.Xetra = ddlXetra.SelectedValue;
            PersonalInfo.Mandal = ddlMandal.SelectedValue;

            if (string.IsNullOrWhiteSpace(datepicker.Text))
                PersonalInfo.SabhaDate = null;
            else
                PersonalInfo.SabhaDate = Convert.ToDateTime(datepicker.Text);


            PersonalInfo.CAddress = txtAddress.Text;
            PersonalInfo.CVillage = txtVillage.Text;

            Guid ccity = new Guid(Convert.ToString(cmbcity.SelectedValue).ToLower());

            if (ccity != Guid.Empty || ccity != null)
                PersonalInfo.CTauko = ccity;
            else
                PersonalInfo.CTauko = Guid.Empty;

            Guid cDistrict = new Guid(Convert.ToString(cmbDistrict.SelectedValue).ToLower());

            if (cDistrict != Guid.Empty || cDistrict != null)
                PersonalInfo.CDistrict = cDistrict;
            else
                PersonalInfo.CDistrict = Guid.Empty;

            Guid cstate = new Guid(Convert.ToString(cmbstate.SelectedValue).ToLower());

            if (cstate != Guid.Empty || cstate != null)
                PersonalInfo.CState = cstate;
            else
                PersonalInfo.CState = Guid.Empty;

            Guid ccountry = new Guid(Convert.ToString(cmbcountry.SelectedValue).ToLower());

            if (ccountry != Guid.Empty || ccountry != null)
                PersonalInfo.CCountry = ccountry;
            else
                PersonalInfo.CCountry = Guid.Empty;


            PersonalInfo.CPin = txtPin.Text;


            PersonalInfo.PAddress = txtPermanentAddress.Text;
            PersonalInfo.PVillage = txtPVillage.Text;

            Guid PCity = new Guid(Convert.ToString(cmbPCity.SelectedValue).ToLower());

            if (PCity != Guid.Empty || PCity != null)
                PersonalInfo.PTaluko = PCity;
            else
                PersonalInfo.PTaluko = Guid.Empty;


            Guid PDistrict = new Guid(Convert.ToString(cmbPDistrict.SelectedValue).ToLower());

            if (PDistrict != Guid.Empty || PDistrict != null)
                PersonalInfo.PDistrict = PDistrict;
            else
                PersonalInfo.PDistrict = Guid.Empty;


            Guid Pstate = new Guid(Convert.ToString(cmbpstate.SelectedValue).ToLower());

            if (Pstate != Guid.Empty || Pstate != null)
                PersonalInfo.PState = Pstate;
            else
                PersonalInfo.PState = Guid.Empty;



            Guid PCountry = new Guid(Convert.ToString(cmbPCountry.SelectedValue).ToLower());

            if (Pstate != Guid.Empty || Pstate != null)
                PersonalInfo.PCountry = PCountry;
            else
                PersonalInfo.PCountry = Guid.Empty;

            PersonalInfo.PPin = txtPPin.Text;
            PersonalInfo.NativePlace = txtnative.Text;
            PersonalInfo.MobilePhone = txtMobile.Text;
            PersonalInfo.HomePhone = txtResidence.Text;
            PersonalInfo.Email = txtEmailAddress.Text;
            PersonalInfo.AltEmail = txtaltemail.Text;

            PersonalInfo.Job = ddcOccupation.SelectedValue;
            PersonalInfo.TypeOfService = ddctypeofserv.SelectedValue;
            PersonalInfo.Designation = txtDesignation.Text;
            PersonalInfo.CompanyName = txtofficename.Text;
            PersonalInfo.JobAddress = txtOfficeAddress.Text;
            PersonalInfo.JVillage = txtOVillage.Text;

            Guid OCity = new Guid(Convert.ToString(cmbOCity.SelectedValue).ToLower());

            if (Pstate != Guid.Empty || Pstate != null)
                PersonalInfo.JTaluko = OCity;
            else
                PersonalInfo.JTaluko = Guid.Empty;


            Guid ODistrict = new Guid(Convert.ToString(cmbODistrict.SelectedValue).ToLower());

            if (ODistrict != Guid.Empty || ODistrict != null)
                PersonalInfo.JDistrict = ODistrict;
            else
                PersonalInfo.JDistrict = Guid.Empty;

            Guid OState = new Guid(Convert.ToString(cmbOstate.SelectedValue).ToLower());

            if (ODistrict != Guid.Empty || ODistrict != null)
                PersonalInfo.JState = OState;
            else
                PersonalInfo.JState = Guid.Empty;

            Guid OCountry = new Guid(Convert.ToString(cmbOCountry.SelectedValue).ToLower());

            if (OCountry != Guid.Empty || OCountry != null)
                PersonalInfo.JCountry = OCountry;
            else
                PersonalInfo.JCountry = Guid.Empty;

            PersonalInfo.JPin = txtOPin.Text;
            PersonalInfo.JobPhone = txtOfficePhone.Text;
            PersonalInfo.JFax = txtofficefax.Text;


            MembershipUser myObject = Membership.GetUser();
            PersonalInfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

            try
            {
                string result = SIS.Services.PersonInfo.PersonInfo.InsertAttandanceandContectInfo(PersonalInfo);
                if (result.Equals("-1"))
                    lblstatus.Text = "Attandance already done for " + PersonalInfo.PersonId;
                else
                    lblstatus.Text = "Attandance updated for " + PersonalInfo.PersonId;
            }
            catch
            {
                lblstatus.Text = "Error Contect admin";
            }
        }

        protected void btnpresent_Click(object sender, EventArgs e)
        {
            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

            PersonalInfo.PersonId = Convert.ToString(hdnpersonid.Value);
            PersonalInfo.SabhaDate = Convert.ToDateTime(datepicker.Text);
            PersonalInfo.SabhaLookupId = Convert.ToString(ddlsabha.SelectedValue);

            MembershipUser myObject = Membership.GetUser();
            PersonalInfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

            if (!string.IsNullOrEmpty(SIS.Services.PersonInfo.PersonInfo.InsertAttandanceInfo(PersonalInfo)))
            {
                lblstatus.Text = "Attandance updated for " + PersonalInfo.PersonId;
            }
            else
            {
                lblstatus.Text = "Error Contect admin";
            }
        }

        private void BindLookupInfo()
        {
            GeneralMethods.BindDropdownFromLookup(ddlsabha, "SabhaDetail", true);
            GeneralMethods.BindDropdownFromLookup(ddcOccupation, "Occupation", true);
            GeneralMethods.BindDropdownFromLookup(ddctypeofserv, "TypeOfService", true);
        }
    }
}