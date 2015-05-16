using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jQueryFiveAjaxCalls
{
    public partial class Default : System.Web.UI.Page
    {
        List<CIS.Entity.Lookup> StudyInfo;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["Image"] = null;
                BindXetraInfo();
                BindLookupInfo();
                PopulateCountry();
                GetPCountry();
                GetOCountry();

                if (Request.QueryString.Count > 0)
                {
                    if (Convert.ToString(Request.QueryString.Get(0)) != "")
                    {
                        SetData(Convert.ToString(Request.QueryString.Get(0)));

                    }
                }
                else
                    ResetForm();
            }
        }



        private List<ChatralayaInfo> GetChatralayaList()
        {
            List<ChatralayaInfo> chatralayaList = new List<ChatralayaInfo>();
            foreach (ListViewDataItem item in lstvwChatralay.Items)
            {
                CheckBox chk = item.FindControl("chkChatralay") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    ChatralayaInfo chatralayaInfo = new ChatralayaInfo();
                    TextBox txtFrom = item.FindControl("txtFrom") as TextBox;

                    if (txtFrom != null && !txtFrom.Text.Trim().Equals(string.Empty))
                        chatralayaInfo.FromYear = txtFrom.Text.ConvetToInt32();

                    TextBox txtTo = item.FindControl("txtTo") as TextBox;
                    if (txtTo != null && !txtTo.Text.Trim().Equals(string.Empty))
                        chatralayaInfo.ToYear = txtTo.Text.ConvetToInt32();

                    HiddenField hdnChatralaya = item.FindControl("hdnChatralayaId") as HiddenField;
                    if (hdnChatralaya != null)
                        chatralayaInfo.ChatralayaId = hdnChatralaya.Value;

                    AjaxControlToolkit.ComboBox ddcStudy = item.FindControl("ddcstudy") as AjaxControlToolkit.ComboBox;
                    if (ddcStudy != null)
                        chatralayaInfo.Study = ddcStudy.SelectedValue;
                    chatralayaList.Add(chatralayaInfo);
                }
            }
            return chatralayaList;
        }

        private void SetData(string PId)
        {
            Guid thisPid = new Guid(PId);
            CIS.Entity.User userinfo = new Entity.User();


            userinfo = CIS.Services.User.GetthisUserInfo(thisPid);

            try
            {
                if (!string.IsNullOrEmpty(userinfo.City))
                    ddlXetra.SelectedValue = userinfo.City;
                else
                    ddlXetra.SelectedValue = "-1";

                GetMandalList();

                if (!string.IsNullOrEmpty(userinfo.City))
                    ddlMandal.SelectedValue = userinfo.Area;
                else
                    ddlMandal.SelectedValue = "-1";
            }
            catch { }

            txtaltemail.Text = userinfo.altEmailAddress;
            ddcurrentstate.SelectedValue = userinfo.CurrentStatus;
            cmbbloodgrp.SelectedValue = userinfo.BloodGroup;

            txtFName.Text = userinfo.FirstName;
            txtMiddelName.Text = userinfo.MiddleName;
            txtLastName.Text = userinfo.LastName;

            if (userinfo.DateOfBirth != null)
                datepicker.Text = Convert.ToString(string.Format("{0:dd/MM/yyyy}", userinfo.DateOfBirth));


            txtAddress.Text = userinfo.CurrentAddress;
            txtVillage.Text = userinfo.CurVillage;

            if (!string.IsNullOrEmpty(userinfo.CurTaluka))
                cmbcity.SelectedValue = userinfo.CurTaluka;
            else
                cmbcity.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.CurDistrict))
                cmbDistrict.SelectedValue = userinfo.CurDistrict;
            else
                cmbDistrict.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.CState))
                cmbstate.SelectedValue = userinfo.CState;
            else
                cmbstate.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.CCountry))
                cmbcountry.SelectedValue = userinfo.CCountry;
            else
                cmbcountry.SelectedValue = "-1";

            if (userinfo.CurPin == 0)
                txtPin.Text = "0";
            else
                txtPin.Text = Convert.ToString(userinfo.CurPin);

            txtPermanentAddress.Text = userinfo.PermanentAddress;
            txtPVillage.Text = userinfo.PerVillage;

            if (!string.IsNullOrEmpty(userinfo.PerTaluka))
                cmbPCity.SelectedValue = userinfo.PerTaluka;
            else
                cmbPCity.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.PerDistrict))
                cmbPDistrict.SelectedValue = userinfo.PerDistrict;
            else
                cmbPDistrict.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.PState))
                cmbpstate.SelectedValue = userinfo.PState;
            else
                cmbpstate.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.PCountry))
                cmbPCountry.SelectedValue = userinfo.PCountry;
            else
                cmbPCountry.SelectedValue = "-1";

            if (userinfo.PerPin == 0)
                txtPPin.Text = "";
            else
                txtPPin.Text = Convert.ToString(userinfo.PerPin);

            txtMobile.Text = userinfo.PhoneMobile;
            txtResidence.Text = userinfo.PhoneResidence;
            txtEmailAddress.Text = userinfo.EmailAddress;

            ddcOccupation.SelectedValue = userinfo.Occupation;
            ddctypeofserv.SelectedValue = userinfo.TypeOfService;
            txtDesignation.Text = userinfo.Designation;


            txtOfficeAddress.Text = userinfo.OfficeAddress;
            txtOVillage.Text = userinfo.OfficeVillage;

            if (!string.IsNullOrEmpty(userinfo.OfficeTaluka))
                cmbOCity.SelectedValue = userinfo.OfficeTaluka;
            else
                cmbOCity.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.OfficeDistrict))
                cmbODistrict.SelectedValue = userinfo.OfficeDistrict;
            else
                cmbODistrict.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.OState))
                cmbOstate.SelectedValue = userinfo.OState;
            else
                cmbOstate.SelectedValue = "-1";

            if (!string.IsNullOrEmpty(userinfo.OCountry))
                cmbOCountry.SelectedValue = userinfo.OCountry;
            else
                cmbOCountry.SelectedValue = "-1";

            if (userinfo.OfficePin == 0)
                txtOPin.Text = "";
            else
                txtOPin.Text = Convert.ToString(userinfo.OfficePin);
            txtOfficePhone.Text = userinfo.OfficePhone;


            ddcactstudydid.SelectedValue = userinfo.ActStudyFromChatralaya;

            chkPooja.Checked = userinfo.Pooja;
            chkTilakChandlo.Checked = userinfo.TilakChandlo;
            chkSabha.Checked = userinfo.Sabha;
            cmbcExam.SelectedValue = userinfo.Exam;
            chkSwaminarayanPrakash.Checked = userinfo.SwaminarayanPrakash;
            chkGharSabha.Checked = userinfo.GharSabha;
            chkGharMandir.Checked = userinfo.GharMandir;
            chkParentsInSatsang.Checked = userinfo.ParentsInSatsang;

            //chkParticipateInActivity.Checked = userinfo.ChatralayActivity;
            txtActivity.Text = userinfo.CActivity;

            chkExStudentActivity.Checked = userinfo.ExStudentActivity;
            chkActiveParticipation.Checked = userinfo.ParticipateActively;
            //chkResponsibilityInSatsang.Checked = userinfo.LocalSatsang;
            cmbcLocalActivity.SelectedValue = userinfo.LocalActivity;

            chkResponsibityInSatsang.Checked = userinfo.InterestInRespLocalSatsang;


            txtSaint1.Text = userinfo.KnownToLocalSaint1;
            txtSaint2.Text = userinfo.KnownToLocalSaint2;

            StudentPhoto.ImageUrl = "ImgHandler.ashx?Pid=" + Convert.ToString(userinfo.Pid);

            GetChatralayaListById(thisPid);
        }

        private void GetChatralayaListById(Guid thisPid)
        {
            List<ChatralayaInfo> lstChatralayaInfo = CIS.Services.User.GetChatralayaListById(thisPid);

            foreach (ListViewDataItem item in lstvwChatralay.Items)
            {
                HiddenField hdnChatralaya = item.FindControl("hdnChatralayaId") as HiddenField;
                foreach (ChatralayaInfo info in lstChatralayaInfo)
                {
                    if (hdnChatralaya.Value.Equals(info.ChatralayaId))
                    {
                        CheckBox chk = item.FindControl("chkChatralay") as CheckBox;
                        if (chk != null)
                            chk.Checked = true;

                        TextBox txtFrom = item.FindControl("txtFrom") as TextBox;
                        if (txtFrom != null)
                            txtFrom.Text = info.FromYear.ToString();

                        TextBox txtTo = item.FindControl("txtTo") as TextBox;
                        if (txtTo != null)
                            txtTo.Text = info.ToYear.ToString();

                        AjaxControlToolkit.ComboBox ddcStudy = item.FindControl("ddcstudy") as AjaxControlToolkit.ComboBox;
                        if (ddcStudy != null)
                            ddcStudy.SelectedValue = info.Study;
                        break;
                    }
                }
            }
        }

        private void BindLookupInfo()
        {
            StudyInfo = GeneralMethods.GetLookupList("Study", true);

            List<CIS.Entity.Lookup> lookupInfo = GeneralMethods.GetLookupList("Chattralaya", false);

            lstvwChatralay.DataSource = lookupInfo;
            lstvwChatralay.DataBind();

            GeneralMethods.BindDropdownFromLookup(cmbcExam, "SatsangExam", true);
            GeneralMethods.BindDropdownFromLookup(cmbcLocalActivity, "SatsangActivity", true);
            GeneralMethods.BindDropdownFromLookup(ddcOccupation, "Occupation", true);
            GeneralMethods.BindDropdownFromLookup(ddctypeofserv, "TypeOfService", true);
            GeneralMethods.BindDropdownFromLookup(ddcactstudydid, "ActualStudy", true);
            GeneralMethods.BindDropdownFromLookup(cmbbloodgrp, "BloodGroup", true);
            GeneralMethods.BindDropdownFromLookup(ddcurrentstate, "CurrentState", true);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CIS.Entity.User userinfo = new Entity.User();

            userinfo.Area = ddlMandal.SelectedValue;
            userinfo.City = ddlXetra.SelectedValue;

            userinfo.altEmailAddress = txtaltemail.Text;
            userinfo.CurrentStatus = ddcurrentstate.SelectedValue;
            userinfo.BloodGroup = cmbbloodgrp.SelectedValue;

            userinfo.ChatralayList = GetChatralayaList();

            userinfo.FirstName = txtFName.Text;
            userinfo.MiddleName = txtMiddelName.Text;
            userinfo.LastName = txtLastName.Text;


            if (string.IsNullOrWhiteSpace(datepicker.Text))
                userinfo.DateOfBirth = null;
            else
                userinfo.DateOfBirth = Convert.ToDateTime(datepicker.Text);



            userinfo.CurrentAddress = txtAddress.Text;
            userinfo.CurVillage = txtVillage.Text;

            if (!string.IsNullOrEmpty(cmbcity.SelectedValue))
                userinfo.CurTaluka = cmbcity.SelectedValue;
            else
                userinfo.CurTaluka = "-1";

            if (!string.IsNullOrEmpty(cmbDistrict.SelectedValue))
                userinfo.CurDistrict = cmbDistrict.SelectedValue;
            else
                userinfo.CurDistrict = "-1";

            if (!string.IsNullOrEmpty(cmbstate.SelectedValue))
                userinfo.CState = cmbstate.SelectedValue;
            else
                userinfo.CState = "-1";

            if (!string.IsNullOrEmpty(cmbcountry.SelectedValue))
                userinfo.CCountry = cmbcountry.SelectedValue;
            else
                userinfo.CCountry = "-1";


            if (txtPin.Text == "")
                userinfo.CurPin = 0;
            else
                userinfo.CurPin = Convert.ToInt32(txtPin.Text);


            userinfo.PermanentAddress = txtPermanentAddress.Text;
            userinfo.PerVillage = txtPVillage.Text;


            if (!string.IsNullOrEmpty(cmbPCity.SelectedValue))
                userinfo.PerTaluka = cmbPCity.SelectedValue;
            else
                userinfo.PerTaluka = "-1";

            if (!string.IsNullOrEmpty(cmbPDistrict.SelectedValue))
                userinfo.PerDistrict = cmbPDistrict.SelectedValue;
            else
                userinfo.PerDistrict = "-1";

            if (!string.IsNullOrEmpty(cmbpstate.SelectedValue))
                userinfo.PState = cmbpstate.SelectedValue;
            else
                userinfo.PState = "-1";

            if (!string.IsNullOrEmpty(cmbPCountry.SelectedValue))
                userinfo.PCountry = cmbPCountry.SelectedValue;
            else
                userinfo.PCountry = "-1";

            if (txtPPin.Text == "")
                userinfo.PerPin = 0;
            else
                userinfo.PerPin = Convert.ToInt32(txtPPin.Text);


            userinfo.PhoneMobile = txtMobile.Text;
            userinfo.PhoneResidence = txtResidence.Text;
            userinfo.EmailAddress = txtEmailAddress.Text;

            userinfo.Occupation = ddcOccupation.SelectedValue;
            userinfo.TypeOfService = ddctypeofserv.SelectedValue;
            userinfo.Designation = txtDesignation.Text;


            userinfo.OfficeAddress = txtOfficeAddress.Text;
            userinfo.OfficeVillage = txtOVillage.Text;

            if (!string.IsNullOrEmpty(cmbOCity.SelectedValue))
                userinfo.OfficeTaluka = cmbOCity.SelectedValue;
            else
                userinfo.OfficeTaluka = "-1";

            if (!string.IsNullOrEmpty(cmbODistrict.SelectedValue))
                userinfo.OfficeDistrict = cmbODistrict.SelectedValue;
            else
                userinfo.OfficeDistrict = "-1";

            if (!string.IsNullOrEmpty(cmbOstate.SelectedValue))
                userinfo.OState = cmbOstate.SelectedValue;
            else
                userinfo.OState = "-1";

            if (!string.IsNullOrEmpty(cmbOCountry.SelectedValue))
                userinfo.OCountry = cmbOCountry.SelectedValue;
            else
                userinfo.OCountry = "-1";

            if (txtOPin.Text == "")
                userinfo.OfficePin = 0;
            else
                userinfo.OfficePin = Convert.ToInt32(txtOPin.Text);
            userinfo.OfficePhone = txtOfficePhone.Text;

            userinfo.ActStudyFromChatralaya = ddcactstudydid.SelectedValue;

            userinfo.Pooja = chkPooja.Checked;
            userinfo.TilakChandlo = chkTilakChandlo.Checked;
            userinfo.Sabha = chkSabha.Checked;
            userinfo.Exam = cmbcExam.SelectedValue;
            userinfo.SwaminarayanPrakash = chkSwaminarayanPrakash.Checked;
            userinfo.GharSabha = chkGharSabha.Checked;
            userinfo.GharMandir = chkGharMandir.Checked;
            userinfo.ParentsInSatsang = chkParentsInSatsang.Checked;

            if (string.IsNullOrEmpty(txtActivity.Text))
                userinfo.ChatralayActivity = false;
            else
                userinfo.ChatralayActivity = true;

            userinfo.CActivity = txtActivity.Text;

            userinfo.ExStudentActivity = chkExStudentActivity.Checked;
            userinfo.ParticipateActively = chkActiveParticipation.Checked;

            if (string.IsNullOrEmpty(cmbcLocalActivity.SelectedValue))
                userinfo.LocalSatsang = false;
            else
                userinfo.LocalSatsang = true;

            userinfo.LocalActivity = cmbcLocalActivity.SelectedValue;

            userinfo.InterestInRespLocalSatsang = chkResponsibityInSatsang.Checked;


            userinfo.KnownToLocalSaint1 = txtSaint1.Text;
            userinfo.KnownToLocalSaint2 = txtSaint2.Text;


            MembershipUser myObject = Membership.GetUser();
            userinfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));
            userinfo.UpdatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));


            if (Session["Image"] != null)
            {
                userinfo.Photoimage = (byte[])Session["Image"];
            }
            else
            {

            }

            if (Request.QueryString.HasKeys() == false)
            {
                int UserCount = CIS.Services.User.GetExistUserInfo(userinfo);

                if (UserCount == 0)
                {
                    string ChatId = Convert.ToString(CIS.Services.User.InsertUserInfo(userinfo));

                    if (string.IsNullOrEmpty(ChatId) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data Saved for " + userinfo.FirstName + " at " + Convert.ToString(DateTime.Now) + " with Id :: " + ChatId + "');", true);
                        lblstatus.Text = "Last Record for " + userinfo.FirstName + " at " + Convert.ToString(DateTime.Now) + " with Id :: " + ChatId;
                        ResetForm();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Application Error Contact Admin..');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('We found " + UserCount + " much records. Do you still  want to add this record.');", true);
                }
            }
            else
            {

                if (Request.QueryString.Count > 0)
                {
                    if (Convert.ToString(Request.QueryString.Get(0)) != "")
                    {
                        userinfo.Pid = new Guid(Convert.ToString(Request.QueryString.Get(0)));

                        string ChatId = CIS.Services.User.UpdateUserInfo(userinfo);
                        if (string.IsNullOrEmpty(ChatId) == false)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "OnUpdate", "alert('Data Updated for " + userinfo.FirstName + " at " + Convert.ToString(DateTime.Now) + " with Id :: " + ChatId + "');", true);
                            lblstatus.Text = "Last Record Updated for " + userinfo.FirstName + " at " + Convert.ToString(DateTime.Now) + " with Id :: " + ChatId;
                            ResetForm();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "OnUpdate", "alert('Application Error Contact Admin..');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnUpdate", "alert('Application Not found Update Key. Contact Admin..');", true);
                }


            }

        }

        protected void ResetForm()
        {
            foreach (ListViewDataItem item in lstvwChatralay.Items)
            {
                CheckBox chk = item.FindControl("chkChatralay") as CheckBox;
                chk.Checked = false;
                TextBox txtFrom = item.FindControl("txtFrom") as TextBox;
                txtFrom.Text = "";
                TextBox txtTo = item.FindControl("txtTo") as TextBox;
                txtTo.Text = "";
                AjaxControlToolkit.ComboBox ddcStudy = item.FindControl("ddcstudy") as AjaxControlToolkit.ComboBox;
                ddcStudy.SelectedIndex = 0;
            }

            txtaltemail.Text = "";
            txtFName.Text = "";
            txtMiddelName.Text = "";
            txtLastName.Text = "";
            datepicker.Text = "";
            txtAddress.Text = "";
            txtVillage.Text = "";

            txtPin.Text = "";
            chkSameascurrent.Checked = false;
            txtPermanentAddress.Text = "";
            txtPVillage.Text = "";

            txtPPin.Text = "";
            txtMobile.Text = "";
            txtResidence.Text = "";
            txtEmailAddress.Text = "";
            ddcOccupation.SelectedIndex = 0;
            ddctypeofserv.SelectedIndex = 0;
            txtDesignation.Text = "";
            txtOfficeAddress.Text = "";
            txtOVillage.Text = "";

            txtOPin.Text = "";
            txtOfficePhone.Text = "";
            ddcactstudydid.SelectedIndex = 0;
            chkPooja.Checked = false;
            chkTilakChandlo.Checked = false;
            chkSabha.Checked = false;
            cmbcExam.SelectedIndex = 0;
            chkSwaminarayanPrakash.Checked = false;
            chkGharSabha.Checked = false;
            chkGharMandir.Checked = false;
            chkParentsInSatsang.Checked = false;
            //chkParticipateInActivity.Checked = false;
            txtActivity.Text = "";
            chkExStudentActivity.Checked = false;
            chkActiveParticipation.Checked = false;
            //chkResponsibilityInSatsang.Checked = false;
            cmbcLocalActivity.SelectedIndex = 0;
            chkResponsibityInSatsang.Checked = false;
            txtSaint1.Text = "";
            txtSaint2.Text = "";
        }

        protected void lstvwChatralay_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            AjaxControlToolkit.ComboBox ddcstudy = e.Item.FindControl("ddcstudy") as AjaxControlToolkit.ComboBox;
            ddcstudy.DataSource = StudyInfo;
            ddcstudy.DataTextField = "DisplayText";
            ddcstudy.DataValueField = "Value";
            ddcstudy.DataBind();
        }

        #region "Private Methods"
        private void PopulateCountry()
        {
            cmbcountry.ClearSelection();
            List<Entity.GeographyDDMenu.CountryDetail> countryList = CIS.Services.Geography.Geography.GetCountryList();
            cmbcountry.DataSource = countryList;
            cmbcountry.DataTextField = "Name";
            cmbcountry.DataValueField = "Code";
            cmbcountry.DataBind();
            cmbcountry.SelectedIndex = 0;

            cmbcountry1.DataSource = countryList;
            cmbcountry1.DataTextField = "Name";
            cmbcountry1.DataValueField = "Code";
            cmbcountry1.DataBind();
            cmbcountry1.SelectedIndex = 0;


            GetStateList();
        }

        private void GetPCountry()
        {
            List<Entity.GeographyDDMenu.CountryDetail> countryList = CIS.Services.Geography.Geography.GetCountryList();
            cmbPCountry.ClearSelection();
            cmbPCountry.DataSource = countryList;
            cmbPCountry.DataTextField = "Name";
            cmbPCountry.DataValueField = "Code";
            cmbPCountry.DataBind();
            cmbPCountry.SelectedIndex = 0;
            GetPStateList();
        }

        private void GetOCountry()
        {
            List<Entity.GeographyDDMenu.CountryDetail> countryList = CIS.Services.Geography.Geography.GetCountryList();
            cmbOCountry.ClearSelection();
            cmbOCountry.DataSource = countryList;
            cmbOCountry.DataTextField = "Name";
            cmbOCountry.DataValueField = "Code";
            cmbOCountry.DataBind();
            cmbOCountry.SelectedIndex = 0;
            GetOStateList();
        }

        private void GetStateList()
        {
            cmbstate.ClearSelection();
            cmbstate.Items.Clear();
            cmbstate.SelectedIndex = -1;

            List<Entity.GeographyDDMenu.StateDetail> StateList = CIS.Services.Geography.Geography.GetStateList(cmbcountry.SelectedValue);
            cmbstate.DataSource = StateList;
            cmbstate.DataTextField = "Name";
            cmbstate.DataValueField = "Code";
            cmbstate.DataBind();


            GetDistrictList();
        }

        private void GetPStateList()
        {

            List<Entity.GeographyDDMenu.StateDetail> StateList = CIS.Services.Geography.Geography.GetStateList(cmbPCountry.SelectedValue);

            cmbpstate.ClearSelection();
            cmbpstate.Items.Clear();
            cmbpstate.SelectedIndex = -1;
            cmbpstate.DataSource = StateList;
            cmbpstate.DataTextField = "Name";
            cmbpstate.DataValueField = "Code";
            cmbpstate.DataBind();

            GetPDistrictList();
        }

        private void GetOStateList()
        {

            List<Entity.GeographyDDMenu.StateDetail> StateList = CIS.Services.Geography.Geography.GetStateList(cmbOCountry.SelectedValue);

            cmbOstate.ClearSelection();
            cmbOstate.Items.Clear();
            cmbOstate.SelectedIndex = -1;
            cmbOstate.DataSource = StateList;
            cmbOstate.DataTextField = "Name";
            cmbOstate.DataValueField = "Code";
            cmbOstate.DataBind();

            GetODistrictList();
        }

        private void GetDistrictList()
        {
            cmbDistrict.ClearSelection();
            cmbDistrict.Items.Clear();
            cmbDistrict.SelectedIndex = -1;

            List<Entity.GeographyDDMenu.DistrictDetail> DistrictList = CIS.Services.Geography.Geography.GetDistrictList(cmbstate.SelectedValue);
            cmbDistrict.DataSource = DistrictList;
            cmbDistrict.DataTextField = "Name";
            cmbDistrict.DataValueField = "Code";
            cmbDistrict.DataBind();



            GetCityList();
        }

        private void GetPDistrictList()
        {

            List<Entity.GeographyDDMenu.DistrictDetail> DistrictList = CIS.Services.Geography.Geography.GetDistrictList(cmbpstate.SelectedValue);

            cmbPDistrict.ClearSelection();
            cmbPDistrict.Items.Clear();
            cmbPDistrict.SelectedIndex = -1;
            cmbPDistrict.DataSource = DistrictList;
            cmbPDistrict.DataTextField = "Name";
            cmbPDistrict.DataValueField = "Code";
            cmbPDistrict.DataBind();

            GetPCityList();
        }

        private void GetODistrictList()
        {

            List<Entity.GeographyDDMenu.DistrictDetail> DistrictList = CIS.Services.Geography.Geography.GetDistrictList(cmbOstate.SelectedValue);

            cmbODistrict.ClearSelection();
            cmbODistrict.Items.Clear();
            cmbODistrict.SelectedIndex = -1;
            cmbODistrict.DataSource = DistrictList;
            cmbODistrict.DataTextField = "Name";
            cmbODistrict.DataValueField = "Code";
            cmbODistrict.DataBind();

            GetOCityList();
        }

        private void GetCityList()
        {
            cmbcity.ClearSelection();
            cmbcity.Items.Clear();
            cmbcity.SelectedIndex = -1;

            List<Entity.GeographyDDMenu.CityDetail> cityList = CIS.Services.Geography.Geography.GetCityList(cmbDistrict.SelectedValue);
            cmbcity.DataSource = cityList;
            cmbcity.DataTextField = "Name";
            cmbcity.DataValueField = "Code";
            cmbcity.DataBind();

        }

        private void GetPCityList()
        {

            List<Entity.GeographyDDMenu.CityDetail> cityList = CIS.Services.Geography.Geography.GetCityList(cmbPDistrict.SelectedValue);

            cmbPCity.ClearSelection();
            cmbPCity.Items.Clear();
            cmbPCity.SelectedIndex = -1;
            cmbPCity.DataSource = cityList;
            cmbPCity.DataTextField = "Name";
            cmbPCity.DataValueField = "Code";
            cmbPCity.DataBind();
        }

        private void GetOCityList()
        {

            List<Entity.GeographyDDMenu.CityDetail> cityList = CIS.Services.Geography.Geography.GetCityList(cmbODistrict.SelectedValue);

            cmbOCity.ClearSelection();
            cmbOCity.Items.Clear();
            cmbOCity.SelectedIndex = -1;
            cmbOCity.DataSource = cityList;
            cmbOCity.DataTextField = "Name";
            cmbOCity.DataValueField = "Code";
            cmbOCity.DataBind();
        }

        private void BindXetraInfo()
        {
            ddlXetra.ClearSelection();
            List<XetraInfo> xetraList = CIS.Services.Xetra.XetraMandal.GetXetraList();
            ddlXetra.DataSource = xetraList;
            ddlXetra.DataTextField = "Name";
            ddlXetra.DataValueField = "Code";
            ddlXetra.DataBind();
            ddlXetra.SelectedIndex = 0;
            GetMandalList();
        }

        private void GetMandalList()
        {
            ddlMandal.ClearSelection();
            ddlMandal.Items.Clear();
            ddlMandal.SelectedIndex = -1;

            List<MandalInfo> mandalList = CIS.Services.Xetra.XetraMandal.GetMandalList(ddlXetra.SelectedValue);
            ddlMandal.DataSource = mandalList;
            ddlMandal.DataTextField = "Name";
            ddlMandal.DataValueField = "Code";
            ddlMandal.DataBind();
        }
        #endregion

        protected void cmbXetra_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMandalList();
        }

        protected void cmbcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStateList();
        }

        protected void cmbstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDistrictList();
        }

        protected void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCityList();
        }


        protected void cmbPCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPStateList();
        }

        protected void cmbpstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPDistrictList();
        }

        protected void cmbPDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPCityList();
        }

        protected void cmbOCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOStateList();
        }

        protected void cmbOstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetODistrictList();
        }

        protected void cmbODistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOCityList();
        }


        protected void btncheckavailability_Click1(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFName.Text) == false && string.IsNullOrEmpty(txtLastName.Text) == false && string.IsNullOrEmpty(datepicker.Text) == false)
            {
                CIS.Entity.User userinfo = new Entity.User();

                userinfo.FirstName = txtFName.Text;
                userinfo.MiddleName = txtMiddelName.Text;
                userinfo.LastName = txtLastName.Text;

                userinfo.DateOfBirth = Convert.ToDateTime(datepicker.Text);

                //calendarButtonExtender.Format

                int UserCount = CIS.Services.User.GetExistUserInfo(userinfo);

                if (UserCount > 0)
                    lblavailabilitystate.Text = "Student already exists. Please verify the detail.";
                else
                    lblavailabilitystate.Text = "Student does not exists.";
            }
            else
            {
                lblavailabilitystate.Text = "For Checking availability you must provide Student's First Name, Last Name and Date of Birth.";
            }
        }



        protected void AsyncFileUpload1_UploadedComplete1(object sender, AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                byte[] imgNew;
                imgNew = imageResize.ResizeFromStream(180, AsyncFileUpload1.PostedFile.InputStream, AsyncFileUpload1.PostedFile.FileName);

                //int len = imgNew.Length;
                //byte[] pic = new byte[len];
                //AsyncFileUpload1.PostedFile.InputStream.Read(pic, 0, len);

                Session["Image"] = imgNew;

                StudentPhoto.ImageUrl = "ImgHandler.ashx";

            }
        }

        protected void AsyncFileUpload1_UploadedFileError1(object sender, AsyncFileUploadEventArgs e)
        {
            return;

        }

    }
}
