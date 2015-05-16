using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIS.HelperClass;
using System.Web.Security;

namespace SIS.Pages
{
    public partial class FamilyMember : System.Web.UI.Page
    {
        string parentpersonid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLookupInfo();
                GetParentDetail();
            }
        }

        private void GetParentDetail()
        {
            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new SIS.Entity.PersonalInfo.PersonalInfo();

            if (Request.QueryString.Count > 0)
            {
                if (Convert.ToString(Request.QueryString.Get(0)) != "")
                {
                    PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetPersonalInfoForParent(Convert.ToString(Request.QueryString.Get(0)));
                    lblPersonid.Text = "Family Id : " + PersonalInfo.FamilyId + "  Main Person : " + PersonalInfo.FullName + "(" + PersonalInfo.PersonId + ")";
                    GetAllMembersDetails(PersonalInfo.FamilyId);
                }
            }
        }


        private void BindLookupInfo()
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            List<SIS.Entity.Lookup.Lookup> lookupInfo = SIS.Services.PersonInfo.PersonInfo.GetKaryakarInfo();

            SIS.Entity.Lookup.Lookup lookupSelect = new Entity.Lookup.Lookup();
            lookupSelect.DisplayText = "---Select---";
            lookupSelect.Value = "00000000-0000-0000-0000-000000000000";
            lookupInfo.Insert(0, lookupSelect);

            ddlkaryakar.DataSource = lookupInfo;
            ddlkaryakar.DataTextField = "DisplayText";
            ddlkaryakar.DataValueField = "Value";
            ddlkaryakar.DataBind();
            ddlkaryakar.SelectedIndex = 0;

            GeneralMethods.BindDropdownFromLookup(ddcurrentstate, "CurrentState", true);
            GeneralMethods.BindDropdownFromLookup(cmbbloodgrp, "BloodGroup", true);
            GeneralMethods.BindDropdownFromLookup(ddcactstudydid, "Study", true);
            GeneralMethods.BindDropdownFromLookup(ddcOccupation, "Occupation", true);
            GeneralMethods.BindDropdownFromLookup(ddctypeofserv, "TypeOfService", true);
            GeneralMethods.BindDropdownFromLookup(cmbcExam, "SatsangExam", true);
            GeneralMethods.BindDropdownFromLookup(cmbcLocalActivity, "SatsangActivity", true);
            GeneralMethods.BindDropdownFromLookup(ddlsatsangcategory, "SatsangCategory", true);
            GeneralMethods.BindDropdownFromLookup(cmbpooja, "Pooja", true);
            GeneralMethods.BindDropdownFromLookup(cmbsabha, "Sabha", true);
            GeneralMethods.BindDropdownFromLookup(cmbdarshan, "Darshan", true);
           
            lstcategory.DataSource = GeneralMethods.GetLookupList("Category", true);
            lstcategory.DataTextField = "DisplayText";
            lstcategory.DataValueField = "Value";
            
            lstcategory.DataBind();

            Entity.PersonalInfo.UserInfo UserInfo = SIS.HelperClass.Utility.GetUserInfo();

            ccdMandal.ContextKey = UserInfo.Role + ":" + String.Join(",", UserInfo.MadalOwnCodes);
        }

        protected void ResetForm()
        {

            txtaltemail.Text = "";
            txtFName.Text = "";
            txtMiddelName.Text = "";
            txtLastName.Text = "";
            datepicker.Text = "";

            txtMobile.Text = "";
            txtResidence.Text = "";
            txtEmailAddress.Text = "";

            txtDesignation.Text = "";
            txtOfficeAddress.Text = "";
            txtOVillage.Text = "";

            txtOPin.Text = "";
            txtOfficePhone.Text = "";

           
            chkTilakChandlo.Checked = false;
      

            chkGharSabha.Checked = false;
            chkGharMandir.Checked = false;


            ddcurrentstate.SelectedValue = "-1";
            ddcactstudydid.SelectedValue = "-1";
            cmbcExam.SelectedValue = "-1";
            cmbcLocalActivity.SelectedValue = "-1";

            ddcOccupation.SelectedValue = "-1";
            ddctypeofserv.SelectedValue = "-1";

            chktvfilm.Checked = false;
            chkosfood.Checked = false;
            chkshield.Checked = false;
            txtbelivein.Text = "";
            cmbdarshan.SelectedValue = "-1";
            cmbsabha.SelectedValue = "-1";
            cmbpooja.SelectedValue = "-1";
            txtsatsangfrom.Text = "";
            chkChesta.Checked = false;
            lblage.Text = "";
            datepickerprakash.Text = "";
            datepickerpremvati.Text = "";
            datepickerpremvati.Text = "";
            datepickerbliss.Text = "";
            txtaltemail.Text = "";
            txtaltemail2.Text = "";
            txtResidence2.Text = "";
            txtMobile2.Text = "";
            txtMobile3.Text = "";

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string personid = SaveData();
            if (string.IsNullOrEmpty(personid).Equals(false))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data Saved for " + txtFName.Text + " at " + Convert.ToString(DateTime.Now) + " with Id :: " + personid + "');", true);
                lblstatus.Text = "Last Record for " + txtFName.Text + " at " + Convert.ToString(DateTime.Now) + " with Id :: " + personid;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Application Error Contact Admin.');", true);
            }

        }

        protected void btnsaveandenterother_Click(object sender, EventArgs e)
        {
            string personid = SaveData();
            if (string.IsNullOrEmpty(personid).Equals(false))
            {
                Response.Redirect("FamilyMember.aspx?" + parentpersonid);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Application Error Contact Admin.');", true);
            }
        }

        private string SaveData()
        {

            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new SIS.Entity.PersonalInfo.PersonalInfo();

            if (Request.QueryString.Count > 0)
            {
                if (Convert.ToString(Request.QueryString.Get(0)) != "")
                {
                    PersonalInfo.ParentPersonId = Convert.ToString(Request.QueryString.Get(0));
                    parentpersonid = PersonalInfo.ParentPersonId;
                }
            }

           
            PersonalInfo.IsActive = Convert.ToInt32(ddlactive.SelectedValue);
            PersonalInfo.IsDND = Convert.ToInt32(ddldnd.SelectedValue);
            PersonalInfo.Samparkkaryakar = ddlkaryakar.SelectedValue;

            PersonalInfo.CurrentStatus = ddcurrentstate.SelectedValue;
            PersonalInfo.IsMainPerson = Convert.ToBoolean(false);
            PersonalInfo.Xetra =ddlXetra.SelectedValue;
            PersonalInfo.Mandal = ddlMandal.SelectedValue;
            PersonalInfo.BloodGroup = cmbbloodgrp.SelectedValue;
            PersonalInfo.FirstName = txtFName.Text;
            PersonalInfo.MiddleName = txtMiddelName.Text;
            PersonalInfo.LastName = txtLastName.Text;

            if (!string.IsNullOrWhiteSpace(txtDId.Text.Trim()))
                PersonalInfo.DId = Convert.ToString(txtDId.Text.Trim());

            string Categarys = string.Empty;
            foreach (int index in lstcategory.GetSelectedIndices())
            {
                if (!string.IsNullOrWhiteSpace(Categarys))
                {
                    Categarys = Categarys + "," + Convert.ToString(lstcategory.Items[index].Value);
                }
                else
                {
                    Categarys = Convert.ToString(lstcategory.Items[index].Value);
                }
            }

            PersonalInfo.Category = Categarys;

            if (string.IsNullOrWhiteSpace(datepicker.Text))
                PersonalInfo.DOB = null;
            else
                PersonalInfo.DOB = Convert.ToDateTime(datepicker.Text);

            PersonalInfo.Gender = ddlgender.SelectedValue;

            if (txttwowheler.Text == "")
                PersonalInfo.NoOfFourWlr = 0;
            else
                PersonalInfo.NoOfTwoWlr = Convert.ToInt32(txttwowheler.Text);

            if (txtfourwheler.Text == "")
                PersonalInfo.NoOfFourWlr = 0;
            else
                PersonalInfo.NoOfFourWlr = Convert.ToInt32(txtfourwheler.Text);

            PersonalInfo.Study = ddcactstudydid.SelectedValue;

            PersonalInfo.MobilePhone = txtMobile.Text;
            PersonalInfo.MobilePhone2 = txtMobile2.Text;
            PersonalInfo.MobilePhone3 = txtMobile3.Text;
            PersonalInfo.HomePhone = txtResidence.Text;
            PersonalInfo.HomePhone2 = txtResidence2.Text;
            PersonalInfo.Email = txtEmailAddress.Text;
            PersonalInfo.AltEmail = txtEmailAddress.Text;
            PersonalInfo.AltEmail2 = txtaltemail2.Text;

            PersonalInfo.Job = ddcOccupation.SelectedValue;
            PersonalInfo.TypeOfService = ddctypeofserv.SelectedValue;
            PersonalInfo.Designation = txtDesignation.Text;
            PersonalInfo.CompanyName = txtofficename.Text;
            PersonalInfo.JobAddress = txtOfficeAddress.Text;
            PersonalInfo.JVillage = txtOVillage.Text;

            Guid OCity = new Guid(Convert.ToString(cmbOCity.SelectedValue).ToLower());

            if (OCity != Guid.Empty || OCity != null)
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

            SIS.Entity.PersonalInfo.SatsangInfo SatsangInfo = new SIS.Entity.PersonalInfo.SatsangInfo();

            SatsangInfo.Pooja = Convert.ToString(cmbpooja.SelectedValue);
            SatsangInfo.SatsangFrom = Convert.ToString(txtsatsangfrom.Text);
            SatsangInfo.TilakChandalo = chkTilakChandlo.Checked;
            SatsangInfo.Chesta = chkChesta.Checked;
            SatsangInfo.Sabha = Convert.ToString(cmbsabha.SelectedValue);
            SatsangInfo.MandirDarshan = Convert.ToString(cmbdarshan.SelectedValue);
            SatsangInfo.Belivein = Convert.ToString(txtbelivein.Text);
            SatsangInfo.Gharsabha = chkGharSabha.Checked;
            SatsangInfo.GharMandir = chkGharMandir.Checked;
            SatsangInfo.SatasangExam = cmbcExam.SelectedValue;
            SatsangInfo.SatasangExamShield = chkshield.Checked;
            SatsangInfo.SPCONo = txtno.Text;
            SatsangInfo.SatasangActivity = cmbcLocalActivity.SelectedValue;
            SatsangInfo.DoSatasangActivity = chkdolocalsatsangactivity.Checked;
            SatsangInfo.SatsangCategory = ddlsatsangcategory.SelectedValue;
            SatsangInfo.OSFood = chkosfood.Checked;
            SatsangInfo.TVFilm = chktvfilm.Checked;

            if (string.IsNullOrWhiteSpace(datepickerprakash.Text))
                SatsangInfo.Prakash = null;
            else
                SatsangInfo.Prakash = Convert.ToDateTime(datepickerprakash.Text);

            if (string.IsNullOrWhiteSpace(datepickerpremvati.Text))
                SatsangInfo.Premvati = null;
            else
                SatsangInfo.Premvati = Convert.ToDateTime(datepickerpremvati.Text);

            if (string.IsNullOrWhiteSpace(datepickerbliss.Text))
                SatsangInfo.Bliss = null;
            else
                SatsangInfo.Bliss = Convert.ToDateTime(datepickerbliss.Text);

            if (string.IsNullOrWhiteSpace(datepickerbalprakash.Text))
                SatsangInfo.BalPrakash = null;
            else
                SatsangInfo.BalPrakash = Convert.ToDateTime(datepickerbalprakash.Text);



            SIS.Entity.PersonalInfo.SkillInfo SkillInfo = new SIS.Entity.PersonalInfo.SkillInfo();

            SkillInfo.Singing = chksing.Checked;
            SkillInfo.Vadan = txtvadan.Text;
            SkillInfo.Painting = chkpainting.Checked;
            SkillInfo.Decoration = chkdecoration.Checked;
            SkillInfo.MSOffice = chkmsoffice.Checked;
            SkillInfo.Dance = chkdance.Checked;
            SkillInfo.Drama = chkdrama.Checked;
            SkillInfo.Speach = chkspeach.Checked;
            SkillInfo.Tailor = chktailor.Checked;
            SkillInfo.CarPainter = chkcarpainter.Checked;
            SkillInfo.Plumbing = chkplumbing.Checked;
            SkillInfo.Welding = chkWelding.Checked;
            SkillInfo.Desingning = chkdesigning.Checked;
            SkillInfo.Computer = chkcomputer.Checked;
            SkillInfo.CarDriving = chkcardriving.Checked;
            SkillInfo.Electric = chkelectric.Checked;
            SkillInfo.Construction = chkConstruction.Checked;
            SkillInfo.Sound = chksound.Checked;
            SkillInfo.Medical = chkmedical.Checked;
            SkillInfo.Cooking = chkcooking.Checked;
            SkillInfo.Photography = chkphotography.Checked;
            SkillInfo.PhotoEditing = chkphotoediting.Checked;
            SkillInfo.Housekeeping = chkhousekeeping.Checked;
            SkillInfo.Vedio = chkvedio.Checked;
            SkillInfo.VedioEditing = chkvedioediting.Checked;
            SkillInfo.PR = chkpr.Checked;
            SkillInfo.Pasti = chkpasti.Checked;
            SkillInfo.OtherSkill = txtother.Text;

          

            MembershipUser myObject = Membership.GetUser();
            PersonalInfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));
            PersonalInfo.UpdatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

            string personid = string.Empty;
            personid = Convert.ToString(SIS.Services.PersonInfo.PersonInfo.InsertPersonalInfoForFamilymember(PersonalInfo, SatsangInfo, SkillInfo));

            return personid;

        }

        protected void dlresultlist_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblDob = (Label)e.Item.FindControl("lblDob");
            if (lblDob != null && !lblDob.Text.Equals(string.Empty))
                lblDob.Text = string.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(lblDob.Text));
        }


        private void GetAllMembersDetails(string familyid)
        {
            List<SIS.Entity.PersonalInfo.PersonalInfo> PersonalInfo = new List<SIS.Entity.PersonalInfo.PersonalInfo>();

            if (Request.QueryString.Count > 0)
            {
                if (Convert.ToString(Request.QueryString.Get(0)) != "")
                {
                    PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetAllMembersDetails(familyid);
                }
            }
            dlresultlist.DataSource = PersonalInfo;
            dlresultlist.DataBind();
        }

        protected void ddlisankutsevak_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}