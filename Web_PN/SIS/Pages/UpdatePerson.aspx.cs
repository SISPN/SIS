using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIS.HelperClass;
using System.Web.Security;
using System.Data;

namespace SIS.Pages
{
    public partial class UpdatePerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLookupInfo();

                if (Request.QueryString.Count > 0)
                {
                    if (Convert.ToString(Request.QueryString.Get(0)) != "")
                    {
                        //string[] RolesforCurrentUser = Roles.GetRolesForUser();
                        //if (RolesforCurrentUser.Length > 0 && RolesforCurrentUser[0].ToLower().Equals("ck"))
                        //{
                        //    ddlsatsangcategory.Visible = false;
                        //    lblcategory.Visible = false;
                        //}
                        SetData(Convert.ToString(Request.QueryString.Get(0)));
                    }
                }
                else
                    ResetForm();
            }
        }

        private void SetData(string thisPid)
        {

            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new SIS.Entity.PersonalInfo.PersonalInfo();
            PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetthisUserPersonalInfo(thisPid);

            SIS.Entity.PersonalInfo.SatsangInfo SatsangInfo = new SIS.Entity.PersonalInfo.SatsangInfo();
            SatsangInfo = SIS.Services.PersonInfo.PersonInfo.GetthisUserSatsangInfo(thisPid);

            SIS.Entity.PersonalInfo.SkillInfo SkillInfo = new SIS.Entity.PersonalInfo.SkillInfo();
            SkillInfo = SIS.Services.PersonInfo.PersonInfo.GetthisUserSkillInfo(thisPid);


            txtDId.Text = Convert.ToString(PersonalInfo.DId);


            ddlactive.SelectedValue = Convert.ToString(PersonalInfo.IsActive);
            ddldnd.SelectedValue = Convert.ToString(PersonalInfo.IsDND);

            ddlkaryakar.SelectedValue = PersonalInfo.Samparkkaryakar;

            if (PersonalInfo.IsActive == 1)
                ddcurrentstate.SelectedValue = "1";
            else
                ddcurrentstate.SelectedValue = "2";

            ddlkaryakar.SelectedValue = PersonalInfo.Samparkkaryakar;

            ddcurrentstate.SelectedValue = PersonalInfo.CurrentStatus;

            if (PersonalInfo.IsMainPerson)
                ddlMainPerson.SelectedValue = "1";
            else
                ddlMainPerson.SelectedValue = "0";

            try
            {

                if (!string.IsNullOrEmpty(PersonalInfo.Xetra))
                    ccdXetra.SelectedValue = PersonalInfo.Xetra;
                else
                    ccdXetra.SelectedValue = "-1";


                if (!string.IsNullOrEmpty(PersonalInfo.Mandal))
                    ccdMandal.SelectedValue = PersonalInfo.Mandal;
                else
                    ccdMandal.SelectedValue = "-1";
            }
            catch { }

            cmbbloodgrp.SelectedValue = PersonalInfo.BloodGroup;


            txtFName.Text = PersonalInfo.FirstName;
            txtMiddelName.Text = PersonalInfo.MiddleName;
            txtLastName.Text = PersonalInfo.LastName;

            if (PersonalInfo.DOB != null)
                datepicker.Text = Convert.ToString(string.Format("{0:dd/MM/yyyy}", PersonalInfo.DOB));

            ddlgender.SelectedValue = PersonalInfo.Gender;
            txttwowheler.Text = Convert.ToString(PersonalInfo.NoOfTwoWlr);
            txtfourwheler.Text = Convert.ToString(PersonalInfo.NoOfFourWlr);
            ddcactstudydid.SelectedValue = Convert.ToString(PersonalInfo.Study);


            txtAddress.Text = PersonalInfo.CAddress;
            txtVillage.Text = PersonalInfo.CVillage;


            if (PersonalInfo.CCountry != Guid.Empty)
                cddCountry.SelectedValue = Convert.ToString(PersonalInfo.CCountry);
            else
                cddCountry.SelectedValue = "-1";


            if (PersonalInfo.CState != Guid.Empty)
                cddState.SelectedValue = Convert.ToString(PersonalInfo.CState);
            else
                cddState.SelectedValue = "-1";


            if (PersonalInfo.CDistrict != Guid.Empty)
                cddDistrict.SelectedValue = Convert.ToString(PersonalInfo.CDistrict);
            else
                cddDistrict.SelectedValue = "-1";


            if (PersonalInfo.CTauko != Guid.Empty)
                cddCity.SelectedValue = Convert.ToString(PersonalInfo.CTauko);
            else
                cddCity.SelectedValue = "-1";

            if (PersonalInfo.CPin != null && PersonalInfo.CPin.Equals(0))
                txtPin.Text = "0";
            else
                txtPin.Text = Convert.ToString(PersonalInfo.CPin);

            txtPermanentAddress.Text = PersonalInfo.PAddress;
            txtPVillage.Text = PersonalInfo.PVillage;


            if (PersonalInfo.PCountry != Guid.Empty)
                ccdPCountry.SelectedValue = Convert.ToString(PersonalInfo.PCountry);
            else
                ccdPCountry.SelectedValue = "-1";


            if (PersonalInfo.PState != Guid.Empty)
                ccdPState.SelectedValue = Convert.ToString(PersonalInfo.PState);
            else
                ccdPState.SelectedValue = "-1";


            if (PersonalInfo.PDistrict != Guid.Empty)
                ccdPDistrict.SelectedValue = Convert.ToString(PersonalInfo.PDistrict);
            else
                ccdPDistrict.SelectedValue = "-1";


            if (PersonalInfo.PTaluko != Guid.Empty)
                ccdPCity.SelectedValue = Convert.ToString(PersonalInfo.PTaluko);
            else
                ccdPCity.SelectedValue = "-1";

            if (PersonalInfo.PPin != null && PersonalInfo.PPin.Equals(0))
                txtPPin.Text = "";
            else
                txtPPin.Text = Convert.ToString(PersonalInfo.PPin);

            txtnative.Text = PersonalInfo.NativePlace;
            txtMobile.Text = PersonalInfo.MobilePhone;
            txtMobile2.Text = PersonalInfo.MobilePhone2;
            txtMobile3.Text = PersonalInfo.MobilePhone3;
            txtResidence.Text = PersonalInfo.HomePhone;
            txtResidence2.Text = PersonalInfo.HomePhone2;
            txtEmailAddress.Text = PersonalInfo.Email;
            txtaltemail.Text = PersonalInfo.AltEmail;
            txtaltemail2.Text = PersonalInfo.AltEmail2;


            ddcOccupation.SelectedValue = PersonalInfo.Job;
            ddctypeofserv.SelectedValue = PersonalInfo.TypeOfService;
            txtDesignation.Text = PersonalInfo.Designation;
            txtofficename.Text = PersonalInfo.CompanyName;
            txtOfficeAddress.Text = PersonalInfo.JobAddress;

            if (PersonalInfo.JCountry != Guid.Empty)
                ccdOCoutry.SelectedValue = Convert.ToString(PersonalInfo.JCountry);
            else
                ccdOCoutry.SelectedValue = "-1";

            if (PersonalInfo.JState != Guid.Empty)
                ccdOState.SelectedValue = Convert.ToString(PersonalInfo.JState);
            else
                ccdOState.SelectedValue = "-1";


            if (PersonalInfo.JDistrict != Guid.Empty)
                ccdODistrict.SelectedValue = Convert.ToString(PersonalInfo.JDistrict);
            else
                ccdODistrict.SelectedValue = "-1";


            if (PersonalInfo.JTaluko != Guid.Empty)
                ccdOCity.SelectedValue = Convert.ToString(PersonalInfo.JTaluko);
            else
                ccdOCity.SelectedValue = "-1";

            txtOVillage.Text = PersonalInfo.JVillage;

            if (PersonalInfo.JPin != null && PersonalInfo.JPin.Equals(0))
                txtOPin.Text = "";
            else
                txtOPin.Text = Convert.ToString(PersonalInfo.JPin);

            txtOfficePhone.Text = PersonalInfo.JobPhone;
            txtofficefax.Text = PersonalInfo.JFax;

            if (PersonalInfo.Category != null)
            {
                string[] categories = PersonalInfo.Category.Split(',');

                foreach (string item in categories)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        lstcategory.Items.FindByText(item).Selected = true;
                    }
                }
            }

            if (SatsangInfo.BalPrakash != null)
                datepickerbalprakash.Text = Convert.ToString(string.Format("{0:dd/MM/yyyy}", SatsangInfo.BalPrakash));

            if (SatsangInfo.Bliss != null)
                datepickerbliss.Text = Convert.ToString(string.Format("{0:dd/MM/yyyy}", SatsangInfo.Bliss));

            if (SatsangInfo.Premvati != null)
                datepickerpremvati.Text = Convert.ToString(string.Format("{0:dd/MM/yyyy}", SatsangInfo.Premvati));

            if (SatsangInfo.Prakash != null)
                datepickerprakash.Text = Convert.ToString(string.Format("{0:dd/MM/yyyy}", SatsangInfo.Prakash));

            cmbpooja.SelectedValue = SatsangInfo.Pooja;
            chkTilakChandlo.Checked = SatsangInfo.TilakChandalo;
            cmbsabha.SelectedValue = SatsangInfo.Sabha;
            chkGharSabha.Checked = SatsangInfo.Gharsabha;
            chkGharMandir.Checked = SatsangInfo.GharMandir;
            cmbcExam.SelectedValue = SatsangInfo.SatasangExam;
            cmbcLocalActivity.SelectedValue = SatsangInfo.SatasangActivity;
            chkdolocalsatsangactivity.Checked = SatsangInfo.DoSatasangActivity;
            ddlsatsangcategory.SelectedValue = SatsangInfo.SatsangCategory;
            txtno.Text = SatsangInfo.SPCONo;
            txtsatsangfrom.Text = Convert.ToString(SatsangInfo.SatsangFrom);
            chkChesta.Checked = SatsangInfo.Chesta;
            chkshield.Checked = SatsangInfo.SatasangExamShield;
            chkosfood.Checked = SatsangInfo.OSFood;
            chktvfilm.Checked = SatsangInfo.TVFilm;
            cmbdarshan.SelectedValue = SatsangInfo.MandirDarshan;
            txtbelivein.Text = Convert.ToString(SatsangInfo.Belivein);

            chksing.Checked = SkillInfo.Singing;
            txtvadan.Text = SkillInfo.Vadan;
            chkpainting.Checked = SkillInfo.Painting;
            chkdecoration.Checked = SkillInfo.Decoration;
            chkmsoffice.Checked = SkillInfo.MSOffice;
            chkdance.Checked = SkillInfo.Dance;
            chkdrama.Checked = SkillInfo.Drama;
            chkspeach.Checked = SkillInfo.Speach;
            chktailor.Checked = SkillInfo.Tailor;
            chkcarpainter.Checked = SkillInfo.CarPainter;
            chkplumbing.Checked = SkillInfo.Plumbing;
            chkWelding.Checked = SkillInfo.Welding;
            chkdesigning.Checked = SkillInfo.Desingning;
            chkcomputer.Checked = SkillInfo.Computer;
            chkcardriving.Checked = SkillInfo.CarDriving;
            chkelectric.Checked = SkillInfo.Electric;
            chkConstruction.Checked = SkillInfo.Construction;
            chksound.Checked = SkillInfo.Sound;
            chkmedical.Checked = SkillInfo.Medical;
            chkcooking.Checked = SkillInfo.Cooking;

            chkphotography.Checked = SkillInfo.Photography;
            chkhousekeeping.Checked = SkillInfo.Housekeeping;
            chkvedio.Checked = SkillInfo.Vedio;
            chkvedioediting.Checked = SkillInfo.VedioEditing;
            chkphotoediting.Checked = SkillInfo.PhotoEditing;
            chkgujtype.Checked = SkillInfo.GujaratiTyping;
            chkgardning.Checked = SkillInfo.Gardening;
            chkpr.Checked = SkillInfo.PR;
            txtother.Text = SkillInfo.OtherSkill;
            chkpasti.Checked = SkillInfo.Pasti;




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
            txtAddress.Text = "";
            txtVillage.Text = "";

            txtPin.Text = "";
            txtPermanentAddress.Text = "";
            txtPVillage.Text = "";

            txtPPin.Text = "";
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

            txtnative.Text = string.Empty;
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




        private string SaveData()
        {
            string personid = string.Empty;
            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new SIS.Entity.PersonalInfo.PersonalInfo();

            PersonalInfo.PersonId = Convert.ToString(Request.QueryString.Get(0));

            if (!string.IsNullOrWhiteSpace(txtDId.Text.Trim()))
                PersonalInfo.DId = Convert.ToString(txtDId.Text.Trim());

            PersonalInfo.CurrentStatus = ddcurrentstate.SelectedValue;

            PersonalInfo.IsActive = Convert.ToInt32(ddlactive.SelectedValue);
            PersonalInfo.IsDND = Convert.ToInt32(ddldnd.SelectedValue);

            PersonalInfo.Samparkkaryakar = ddlkaryakar.SelectedValue;

            if (Convert.ToInt32(ddlMainPerson.SelectedValue) == 1)
                PersonalInfo.IsMainPerson = Convert.ToBoolean(true);
            else
                PersonalInfo.IsMainPerson = Convert.ToBoolean(false);

            PersonalInfo.Xetra = ddlXetra.SelectedValue;
            PersonalInfo.Mandal = ddlMandal.SelectedValue;
            PersonalInfo.BloodGroup = cmbbloodgrp.SelectedValue;
            PersonalInfo.FirstName = txtFName.Text;
            PersonalInfo.MiddleName = txtMiddelName.Text;
            PersonalInfo.LastName = txtLastName.Text;

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


            //if (Request.QueryString.HasKeys() == false)
            //{
            personid = Convert.ToString(SIS.Services.PersonInfo.PersonInfo.UpdatePersonalInfo(PersonalInfo, SatsangInfo, SkillInfo));
            //}
            //else
            //{

            //}

            return PersonalInfo.PersonId;

        }

        protected void ddlisankutsevak_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}