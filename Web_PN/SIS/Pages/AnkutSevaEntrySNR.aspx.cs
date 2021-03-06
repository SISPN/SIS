﻿using SIS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.UI;

namespace SIS.Pages
{
    public partial class AnkutSevaEntrySNR : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GeneralMethods.BindDropdownFromLookup(ddlankutGroup, "AnkutGroup", true);
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

        private void SetData(string thisPid)
        {

            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new SIS.Entity.PersonalInfo.PersonalInfo();
            PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetthisUserPersonalInfo(thisPid);

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
                if (!string.IsNullOrWhiteSpace(txtamount.Text) && int.TryParse(txtamount.Text, out resl))
                    Sevainfo.Amount = Convert.ToInt32(txtamount.Text);

                Sevainfo.Mandal = Convert.ToString(ddlMandal.SelectedValue);

                Sevainfo.IsSantPadhramni = chksant.Checked;
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
            if (ddlname.SelectedItem != null)
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlname.SelectedItem)) && Convert.ToString(ddlname.SelectedItem) != "--Select--")// || !string.IsNullOrWhiteSpace(txtResidence.Text))
                {

                    List<Entity.PersonalInfo.PersonalInfo> PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetPerson(Convert.ToString(ddlname.SelectedItem));

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
            else if (ddlak.SelectedItem != null)
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlak.SelectedItem)) && Convert.ToString(ddlak.SelectedItem) != "--Select--")// || !string.IsNullOrWhiteSpace(txtResidence.Text))
                {

                    List<Entity.PersonalInfo.PersonalInfo> PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetPerson(Convert.ToString(ddlak.SelectedItem));

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
            else if (ddlgroupperson.SelectedItem != null)
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlgroupperson.SelectedItem)) && Convert.ToString(ddlgroupperson.SelectedItem) != "--Select--")// || !string.IsNullOrWhiteSpace(txtResidence.Text))
                {

                    List<Entity.PersonalInfo.PersonalInfo> PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetPerson(Convert.ToString(ddlgroupperson.SelectedItem));

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

        protected void ddlisankutsevak_SelectedIndexChanged(object sender, EventArgs e)
        {
           List<Entity.PersonalInfo.AnkutPersonDetails> lstankutperson =   SIS.Services.PersonInfo.PersonInfo.GetGroupDetails(Convert.ToString( ddlankutGroup.SelectedValue));
           ddlgroupperson.DataSource = lstankutperson;
           ddlgroupperson.DataTextField = "FullName";
           ddlgroupperson.DataValueField = "PersonalID";
           ddlgroupperson.DataBind();
        }

        protected void ddlgroupperson_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entity.PersonalInfo.AnkutPersonDetails> lstankutperson = SIS.Services.PersonInfo.PersonInfo.GetAKDetails(Convert.ToString("AK"),Convert.ToString(ddlgroupperson.SelectedValue));
            ddlak.DataSource = lstankutperson;
            ddlak.DataTextField = "FullName";
            ddlak.DataValueField = "PersonalID";
            ddlak.DataBind();
        }

        protected void ddlak_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entity.PersonalInfo.AnkutPersonDetails> lstankutperson = SIS.Services.PersonInfo.PersonInfo.GetAKDetails(Convert.ToString("AS"), Convert.ToString(ddlak.SelectedValue));
            ddlname.DataSource = lstankutperson;
            ddlname.DataTextField = "FullName";
            ddlname.DataValueField = "PersonalID";
            ddlname.DataBind();
        }


      
    }
}