using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.UI;

namespace SIS.Pages
{
    public partial class AnkutSevaEntry : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToString(ConfigurationManager.AppSettings["CenterCode"]).ToLower().Equals("sn"))
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["AUId"] != null && Convert.ToString(Request.QueryString.Get(0)) != "")
                        {
                            SetData(Convert.ToString(Request.QueryString.Get(0)), true);
                        }
                        else
                            SetData(Convert.ToString(Request.QueryString.Get(0)), false);

                    }
                    else
                        ResetForm();
                }
            }
            else
                Response.Redirect("Home.aspx");
        }

        private void SetData(string thisPid, bool isauid)
        {

            if (isauid == false)
            {
                SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new SIS.Entity.PersonalInfo.PersonalInfo();
                PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetthisUserPersonalInfo(thisPid);

                try
                {

                    if (!string.IsNullOrEmpty(PersonalInfo.Xetra))
                    {
                        ddlXetra0_CascadingDropDown.SelectedValue = PersonalInfo.Xetra;
                        //ddlPersonXetra.SelectedValue = PersonalInfo.Xetra;
                    }
                    else
                    {
                        ddlXetra0_CascadingDropDown.SelectedValue = "-1";
                        //ddlPersonXetra.SelectedValue = "-1";
                    }

                    if (!string.IsNullOrEmpty(PersonalInfo.Mandal))
                    {
                        ddlMandal0_CascadingDropDown.SelectedValue = PersonalInfo.Mandal;
                        //  ddlPersonMandal.SelectedValue = PersonalInfo.Mandal; 
                    }
                    else
                    {
                        ddlMandal0_CascadingDropDown.SelectedValue = "-1";
                        //ddlPersonMandal.SelectedValue = "-1";
                    }


                }
                catch { }
                try
                {


                    ccdXetra.SelectedValue = "-1";


                    ccdMandal.SelectedValue = "-1";

                }
                catch { }

                txtFName.Text = PersonalInfo.FirstName;
                txtMiddelName.Text = PersonalInfo.MiddleName;
                txtLastName.Text = PersonalInfo.LastName;
                txtmasterdataid.Text = Convert.ToString(thisPid);

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


                txtMobile.Text = PersonalInfo.MobilePhone;

                txtResidence.Text = PersonalInfo.HomePhone;

                txtEmailAddress.Text = PersonalInfo.Email;
                txtaltemail.Text = PersonalInfo.AltEmail;
            }
            else
            {
                SIS.Entity.PersonalInfo.SevaInfo PersonalInfo = new SIS.Entity.PersonalInfo.SevaInfo();

                PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetAnkutInfo(thisPid);

                try
                {

                    if (!string.IsNullOrEmpty(PersonalInfo.PersonXetra))
                    {
                        ddlXetra0_CascadingDropDown.SelectedValue = PersonalInfo.PersonXetra;
                        //ddlPersonXetra.SelectedValue = PersonalInfo.PersonXetra;
                    }
                    else
                    {
                        ddlXetra0_CascadingDropDown.SelectedValue = PersonalInfo.PersonXetra;
                        //    ddlPersonXetra.SelectedValue = "-1"; 
                    }


                    if (!string.IsNullOrEmpty(PersonalInfo.PersonMandal))
                    {
                        ddlMandal0_CascadingDropDown.SelectedValue = PersonalInfo.PersonMandal;
                        //  ddlPersonMandal.SelectedValue = PersonalInfo.PersonMandal; 
                    }
                    else
                    {
                        ddlMandal0_CascadingDropDown.SelectedValue = "-1";
                        //ddlPersonMandal.SelectedValue = "-1";
                    }
                }
                catch { }





                txtFName.Text = PersonalInfo.FName;
                txtMiddelName.Text = PersonalInfo.MName;
                txtLastName.Text = PersonalInfo.LName;
                txtmasterdataid.Text = Convert.ToString(PersonalInfo.PersonId);

                txtAddress.Text = PersonalInfo.Address;
                txtVillage.Text = PersonalInfo.Area;


                if (PersonalInfo.Country != Guid.Empty)
                    cddCountry.SelectedValue = Convert.ToString(PersonalInfo.Country);
                else
                    cddCountry.SelectedValue = "-1";


                if (PersonalInfo.State != Guid.Empty)
                    cddState.SelectedValue = Convert.ToString(PersonalInfo.State);
                else
                    cddState.SelectedValue = "-1";


                if (PersonalInfo.District != Guid.Empty)
                    cddDistrict.SelectedValue = Convert.ToString(PersonalInfo.District);
                else
                    cddDistrict.SelectedValue = "-1";


                if (PersonalInfo.Taluko != Guid.Empty)
                    cddCity.SelectedValue = Convert.ToString(PersonalInfo.Taluko);
                else
                    cddCity.SelectedValue = "-1";

                if (PersonalInfo.Pin != null && PersonalInfo.Pin.Equals(0))
                    txtPin.Text = "0";
                else
                    txtPin.Text = Convert.ToString(PersonalInfo.Pin);


                txtMobile.Text = PersonalInfo.Mobile;

                txtResidence.Text = PersonalInfo.Resident;

                txtEmailAddress.Text = PersonalInfo.Email;
                txtaltemail.Text = PersonalInfo.AltEmail;
                chksant.Checked = PersonalInfo.IsSantPadhramni;
                if (Convert.ToString(PersonalInfo.SantPadharamaniDate) != "01/01/0001 00:00:00")
                    datepicker.Text = Convert.ToString(PersonalInfo.SantPadharamaniDate);
                txtamount.Text = Convert.ToString(PersonalInfo.Amount);
                txtbook.Text = Convert.ToString(PersonalInfo.BookNo);
                txtreciept.Text = Convert.ToString(PersonalInfo.RecieptNo);


                try
                {

                    if (!string.IsNullOrEmpty(PersonalInfo.Xetra))
                    {
                        ccdXetra.SelectedValue = PersonalInfo.Xetra;
                        //ddlXetra.SelectedValue = PersonalInfo.Xetra;
                    }
                    else
                    {
                        ccdXetra.SelectedValue = "-1";
                        //ddlXetra.SelectedValue = "-1";
                    }


                    if (!string.IsNullOrEmpty(PersonalInfo.Mandal))
                    {
                        ccdMandal.SelectedValue = PersonalInfo.Mandal;
                        // ddlPersonMandal.SelectedValue = PersonalInfo.Mandal;
                    }
                    else
                    {
                        ccdMandal.SelectedValue = "-1";
                        //ddlPersonMandal.SelectedValue = "-1";
                    }
                }
                catch { }


                txtBringFName1.Text = PersonalInfo.BringFName;
                txtBringMiddelName1.Text = PersonalInfo.BringMName;
                txtBringLastName.Text = PersonalInfo.BringLName;

                txtbringemail.Text = PersonalInfo.SevaBringEmail;
                txtbringaltemail.Text = PersonalInfo.SevaBringAltEmail;
                txtbringMobile.Text = PersonalInfo.SevaBringMobile;

                txtbringresident.Text = PersonalInfo.SevaBringResident;
            }
        }


        protected void ResetForm()
        {
            txtaltemail.Text = "";
            txtFName.Text = "";
            txtMiddelName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtVillage.Text = "";
            txtPin.Text = "";
            txtMobile.Text = "";
            txtResidence.Text = "";
            txtEmailAddress.Text = "";
            txtmasterdataid.Text = "";
            txtbringaltemail.Text = "";
            txtbringemail.Text = "";
            txtbringMobile.Text = "";
            txtbringresident.Text = "";
        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            string res = SaveData();
            if (!string.IsNullOrWhiteSpace(res))
            {
                lblstatus.Text = "Last Person ID : " + res;
                lblavailabilitystate.Text = "";
                txtmasterdataid.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data Added successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Application Error Contact Admin.');", true);
            }
        }


        private string SaveData()
        {
            try
            {
                string res = "";

                SIS.Entity.PersonalInfo.SevaInfo Sevainfo = new SIS.Entity.PersonalInfo.SevaInfo();

                if (Convert.ToString(ddlPersonMandal.SelectedValue) != string.Empty)
                    Sevainfo.PersonMandal = Convert.ToString(ddlPersonMandal.SelectedValue);
                else
                    Sevainfo.PersonMandal = "-1";

                if (Convert.ToString(ddlPersonXetra.SelectedValue) != string.Empty)
                    Sevainfo.PersonXetra = Convert.ToString(ddlPersonXetra.SelectedValue);
                else
                    Sevainfo.PersonXetra = "-1";

                Sevainfo.FName = txtFName.Text;
                Sevainfo.MName = txtMiddelName.Text;
                Sevainfo.LName = txtLastName.Text;

                Sevainfo.Address = txtAddress.Text;
                Sevainfo.Area = txtVillage.Text;

                Guid ccity = new Guid(Convert.ToString(cmbcity.SelectedValue).ToLower());

                if (ccity != Guid.Empty || ccity != null)
                    Sevainfo.Taluko = ccity;
                else
                    Sevainfo.Taluko = Guid.Empty;

                Guid cDistrict = new Guid(Convert.ToString(cmbDistrict.SelectedValue).ToLower());

                if (cDistrict != Guid.Empty || cDistrict != null)
                    Sevainfo.District = cDistrict;
                else
                    Sevainfo.District = Guid.Empty;

                Guid cstate = new Guid(Convert.ToString(cmbstate.SelectedValue).ToLower());

                if (cstate != Guid.Empty || cstate != null)
                    Sevainfo.State = cstate;
                else
                    Sevainfo.State = Guid.Empty;

                Guid ccountry = new Guid(Convert.ToString(cmbcountry.SelectedValue).ToLower());

                if (ccountry != Guid.Empty || ccountry != null)
                    Sevainfo.Country = ccountry;
                else
                    Sevainfo.Country = Guid.Empty;

                Sevainfo.Pin = txtPin.Text;
                Sevainfo.Mobile = txtMobile.Text;
                Sevainfo.Resident = txtResidence.Text;
                Sevainfo.Email = txtEmailAddress.Text;
                Sevainfo.AltEmail = txtaltemail.Text;

                if (ddlname.Text != "-1")
                {
                    Sevainfo.BringFName = ddlname.Text.Split(' ')[0].Length > 0 ? ddlname.Text.Split(' ')[0] : "";
                    Sevainfo.BringMName = ddlname.Text.Split(' ')[1].Length > 0 ? ddlname.Text.Split(' ')[1] : "";
                    Sevainfo.BringLName = ddlname.Text.Split(' ')[2].Length > 0 ? ddlname.Text.Split(' ')[2] : "";
                }
                else
                {
                    Sevainfo.BringFName = txtBringFName1.Text;
                    Sevainfo.BringMName = txtBringMiddelName1.Text;
                    Sevainfo.BringLName = txtBringLastName.Text;
                }


                Sevainfo.SevaBringMobile = txtbringMobile.Text;
                Sevainfo.SevaBringResident = txtbringresident.Text;
                Sevainfo.SevaBringEmail = txtbringemail.Text;
                Sevainfo.SevaBringAltEmail = txtbringaltemail.Text;

                Sevainfo.PersonId = txtmasterdataid.Text.Trim();

                int resl;
                decimal re;
                if (!string.IsNullOrWhiteSpace(txtamount.Text) && decimal.TryParse(txtamount.Text, out re))
                    Sevainfo.Amount = Convert.ToDecimal(txtamount.Text);
                if (!string.IsNullOrWhiteSpace(txtamount.Text) && int.TryParse(txtamount.Text, out resl))
                    Sevainfo.Amount = Convert.ToInt32(txtamount.Text);


                Sevainfo.Mandal = Convert.ToString(ddlMandal.SelectedValue);

                Sevainfo.IsSantPadhramni = chksant.Checked;
                if (!string.IsNullOrWhiteSpace(datepicker.Text))
                    Sevainfo.SantPadharamaniDate = Convert.ToDateTime(datepicker.Text);

                Sevainfo.BookNo = Convert.ToString(txtbook.Text);
                Sevainfo.RecieptNo = Convert.ToString(txtreciept.Text);
                Sevainfo.Xetra = Convert.ToString(ddlXetra.SelectedValue);
                Sevainfo.Mandal = Convert.ToString(ddlMandal.SelectedValue);

                MembershipUser myObject = Membership.GetUser();
                Sevainfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));
                Sevainfo.UpdatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));



                if (Request.QueryString.GetKey(0) == "PersonId")
                {
                    res = SIS.Services.PersonInfo.PersonInfo.InsertAnkkutInfo(Sevainfo);
                }
                else if (Request.QueryString.GetKey(0) == "AUId")
                {
                    Sevainfo.ID = Convert.ToInt32(Request.QueryString.Get(0));
                    res = SIS.Services.PersonInfo.PersonInfo.UpdateAnkkutInfo(Sevainfo);
                }

                return res;
            }
            catch
            {
                return "";
            }
        }

        protected void lnkimportxls_Click(object sender, EventArgs e)
        {
        }


        protected void lnkgetId_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMobile.Text))// || !string.IsNullOrWhiteSpace(txtResidence.Text))
            {
                List<Entity.PersonalInfo.PersonalInfo> PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetPersonId(txtMobile.Text, txtResidence.Text);

                if (PersonalInfo.Count > 0)
                {
                    //if (PersonalInfo[0].Mandal != string.Empty)
                    //    ddlMandal0.SelectedValue = Convert.ToString(PersonalInfo[0].Mandal);
                    //else
                    //    ddlMandal0.SelectedValue = "-1";

                    //if (PersonalInfo[0].Xetra != string.Empty)
                    //    ddlXetra0.SelectedValue = Convert.ToString(PersonalInfo[0].Xetra);
                    //else
                    //    ddlXetra0.SelectedValue = "-1";

                    txtmasterdataid.Text = PersonalInfo[0].PersonId;
                    txtFName.Text = PersonalInfo[0].FirstName;
                    txtMiddelName.Text = PersonalInfo[0].MiddleName;
                    txtLastName.Text = PersonalInfo[0].LastName;

                    txtAddress.Text = PersonalInfo[0].CAddress;
                    txtVillage.Text = PersonalInfo[0].CVillage;

                    if (PersonalInfo[0].CCountry != Guid.Empty)
                        cddCountry.SelectedValue = Convert.ToString(PersonalInfo[0].CCountry);
                    else
                        cddCountry.SelectedValue = "-1";


                    if (PersonalInfo[0].CState != Guid.Empty)
                        cddState.SelectedValue = Convert.ToString(PersonalInfo[0].CState);
                    else
                        cddState.SelectedValue = "-1";


                    if (PersonalInfo[0].CDistrict != Guid.Empty)
                        cddDistrict.SelectedValue = Convert.ToString(PersonalInfo[0].CDistrict);
                    else
                        cddDistrict.SelectedValue = "-1";


                    if (PersonalInfo[0].CTauko != Guid.Empty)
                        cddCity.SelectedValue = Convert.ToString(PersonalInfo[0].CTauko);
                    else
                        cddCity.SelectedValue = "-1";

                    if (PersonalInfo[0].CPin != null && PersonalInfo[0].CPin.Equals(0))
                        txtPin.Text = "0";
                    else
                        txtPin.Text = Convert.ToString(PersonalInfo[0].CPin);

                    txtMobile.Text = PersonalInfo[0].MobilePhone;
                    txtResidence.Text = PersonalInfo[0].HomePhone;
                    txtEmailAddress.Text = PersonalInfo[0].Email;
                    txtaltemail.Text = PersonalInfo[0].AltEmail;


                    lblavailabilitystate.Text = "";
                }
                else
                {
                    lblavailabilitystate.Text = "No Data found based on Mobile Number";
                }
            }
        }



        protected void lnkgetId0_Click(object sender, EventArgs e)
        {
            if (ddlname.SelectedValue != null)
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlname.SelectedValue)) && Convert.ToString(ddlname.SelectedValue) != "-1")// || !string.IsNullOrWhiteSpace(txtResidence.Text))
                {

                    List<Entity.PersonalInfo.PersonalInfo> PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetPerson(Convert.ToString(ddlname.SelectedValue));

                    if (PersonalInfo.Count > 0)
                    {
                        txtbringaltemail.Text = PersonalInfo[0].AltEmail;
                        txtbringemail.Text = PersonalInfo[0].Email;
                        txtbringMobile.Text = PersonalInfo[0].MobilePhone;
                        txtbringresident.Text = PersonalInfo[0].HomePhone;

                        lblavailabilitystateSevabring.Text = "Data Found";
                    }
                    else
                    {
                        txtbringaltemail.Text = "";
                        txtbringemail.Text = "";
                        txtbringMobile.Text = "";
                        txtbringresident.Text = "";
                        lblavailabilitystateSevabring.Text = "No Data found based on Person Name";
                    }
                }
            }
        }

        protected void chksant_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}