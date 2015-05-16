using SIS.HelperClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.Security;
using System.Web.UI;

namespace SIS.Pages
{
    public partial class SevaEntry : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entity.PersonalInfo.UserInfo UserInfo = SIS.HelperClass.Utility.GetUserInfo();

                if (UserInfo.MandalOwn != null && UserInfo.MandalOwn.Length != 0 && !(UserInfo.MandalOwn.Length == 1 && string.IsNullOrWhiteSpace(UserInfo.MandalOwn[0])))
                {
                    ccdMandal.ContextKey = UserInfo.Role + ":" + String.Join(",", UserInfo.MandalOwn);
                }
                else
                {
                    ccdMandal.ContextKey = UserInfo.Role + ":";
                }

                string[] RolesforCurrentUser = Roles.GetRolesForUser();
                if (RolesforCurrentUser.Length > 0 && RolesforCurrentUser[0].ToLower().Equals("admin"))
                {
                    btnexportdata.Visible = true;
                }
                else
                {
                    btnexportdata.Visible = false;
                }
                GeneralMethods.BindDropdownFromLookup(ddlsatsangcategory, "SatsangCategory", true);
                ResetForm();
                txtbringname.Text = "";
                hfbringperson.Value = string.Empty;
                EnableDisableForm(false);
            }

        }



        protected void btnsave_Click(object sender, EventArgs e)
        {
            string BringpersonId = Request.Form[hfbringperson.UniqueID];

            //if (!string.IsNullOrWhiteSpace(BringpersonId))
            //{
            if (ValidData())
            {
                string res = SaveData();
                if (!string.IsNullOrWhiteSpace(res))
                {
                    lblstatus.Text = "Last Person ID : " + res;
                    EnableDisableForm(false);
                    ResetForm();
                    txtbringname.Text = "";
                    hfbringperson.Value = string.Empty;
                    txtmasterid.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data Added successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Application Error Contact Admin.');", true);
                    EnableDisableForm(false);
                }
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Please enter Seva Bring Person name in Master database.');", true);
            //}
        }

        private bool ValidData()
        {
            if (string.IsNullOrWhiteSpace(ddlMandal.SelectedValue) && Convert.ToString(ddlMandal.SelectedValue) == "-1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Please Select Xetra and Mandal.');", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtamount.Text) || string.IsNullOrWhiteSpace(txtprobableseva.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Please enter Seva Amount or Probable Seva.');", true);
                return false;
            }


            if (Convert.ToDecimal(txtamount.Text) <= 0 && Convert.ToInt32(txtprobableseva.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Please enter valid Amount or Probable Seva.');", true);
                return false;
            }


            if (ddlsatsangcategory.SelectedValue == "OldSila")
            {
                decimal amount = Math.Ceiling(Convert.ToDecimal(txtamount.Text));
                int sila = Convert.ToInt32(amount / 1100);
                int totalyajman = Convert.ToInt32(txtmale.Text) + Convert.ToInt32(txtfemale.Text);

                if (totalyajman > sila)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Total Male and Female yajaman must be in multiple of Sila Amount entered.');", true);
                    return false;
                }
                else
                    return true;
            }
            else
            {
                decimal amount = Math.Ceiling(Convert.ToDecimal(txtamount.Text));
                int sila = Convert.ToInt32(amount / 3000);
                int totalyajman = Convert.ToInt32(txtmale.Text) + Convert.ToInt32(txtfemale.Text);

                if (totalyajman > sila)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Total Male and Female yajaman must be in multiple of Sila Amount entered.');", true);
                    return false;
                }
                else
                    return true;
            }
        }


        protected void lnkgetId_Click(object sender, EventArgs e)
        {
            string personId = Request.Form[hfPersonId.UniqueID];
            if (!string.IsNullOrWhiteSpace(personId))
            {
                EnableDisableForm(true);
                SetData(personId);
                lblstatus.Text = "";
            }
            else
            {
                EnableDisableForm(true);
                lblstatus.Text = "No Data found based on Person";
                ResetForm();
            }


        }

        private void SetData(string thisPid)
        {
            SIS.Entity.PersonalInfo.PersonalInfo PersonalInfo = new SIS.Entity.PersonalInfo.PersonalInfo();
            PersonalInfo = SIS.Services.PersonInfo.PersonInfo.GetthisUserPersonalInfoForSeva(thisPid);

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

            ddlgender.SelectedValue = PersonalInfo.Gender;
            txtFName.Text = PersonalInfo.FirstName;
            txtMiddelName.Text = PersonalInfo.MiddleName;
            txtLastName.Text = PersonalInfo.LastName;
            txtmasterid.Text = Convert.ToString(thisPid);

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
            txtEmailAddress.Text = PersonalInfo.Email;


            if (PersonalInfo.SatsangCategory == "-1")
                ddlsatsangcategory.SelectedValue = "Sila";
            else
                ddlsatsangcategory.SelectedValue = PersonalInfo.SatsangCategory;

            txtprobableseva.Text = Convert.ToString(PersonalInfo.ProbableSeva);

            txtmale.Text = Convert.ToString(PersonalInfo.MaleYajman);
            txtfemale.Text = Convert.ToString(PersonalInfo.FemaleYajman);
            txtamount.Text = Convert.ToString(PersonalInfo.Amount);
            txtbook.Text = Convert.ToString(PersonalInfo.BookNo);
            txtreciept.Text = Convert.ToString(PersonalInfo.Reciept);

            if (!string.IsNullOrWhiteSpace(PersonalInfo.SevaBringName))
            {
                txtbringname.Text = Convert.ToString(PersonalInfo.SevaBringName);
                //txtbringname.Enabled = false;
                hfbringperson.Value = Convert.ToString(PersonalInfo.SevaBringPersonId);
            }
            else
            {
                txtbringname.Text = "";
                //txtbringname.Enabled = true;
                hfbringperson.Value = "";
            }
            hfPersonId.Value = Convert.ToString(PersonalInfo.PersonId);

        }

        protected void ResetForm()
        {

            txtFName.Text = "";
            txtMiddelName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtVillage.Text = "";
            txtPin.Text = "";
            txtMobile.Text = "";

            txtEmailAddress.Text = "";

            txtmasterid.Text = "";
            ddlsatsangcategory.SelectedValue = "-1";

            txtprobableseva.Text = "0";
            txtmale.Text = "0";
            txtfemale.Text = "0";
            txtamount.Text = "0";
            txtbook.Text = "";
            txtreciept.Text = "";
            chkself.Checked = false;

            ddlgender.SelectedValue = "Male";
            ddlsatsangcategory.SelectedValue = "Sila";

            hfPersonId.Value = string.Empty;
            myTextBox.Text = string.Empty;
        }

        protected void EnableDisableForm(bool flag)
        {
            chkself.Enabled = flag;
            cddCountry.Enabled = flag;
            cddState.Enabled = flag;
            cddDistrict.Enabled = flag;
            cddCity.Enabled = flag;

            txtFName.Enabled = flag;
            txtMiddelName.Enabled = flag;
            txtLastName.Enabled = flag;
            txtAddress.Enabled = flag;
            txtVillage.Enabled = flag;
            txtPin.Enabled = flag;
            txtMobile.Enabled = flag;

            txtEmailAddress.Enabled = flag;

            ddlsatsangcategory.Enabled = flag;

            ddlgender.Enabled = flag;
            txtprobableseva.Enabled = flag;
            txtmale.Enabled = flag;
            txtfemale.Enabled = flag;
            txtamount.Enabled = flag;
            txtbook.Enabled = flag;
            txtreciept.Enabled = flag;
            //txtbringname.Enabled = flag;

        }

        private string SaveData()
        {
            try
            {
                string res = "";

                SIS.Entity.PersonalInfo.SevaInfo Sevainfo = new SIS.Entity.PersonalInfo.SevaInfo();

                string personId = Request.Form[hfPersonId.UniqueID];
                Sevainfo.PersonId = Convert.ToString(txtmasterid.Text);

                if (chkself.Checked)
                    Sevainfo.SevaBringPersonId = Sevainfo.PersonId;
                else
                {
                    string BringpersonId = Request.Form[hfbringperson.UniqueID];
                    Sevainfo.SevaBringPersonId = Convert.ToString(BringpersonId);
                }

                Sevainfo.PersonMandal = ddlXetra.SelectedValue;
                Sevainfo.PersonXetra = ddlMandal.SelectedValue;
                Sevainfo.Gender = ddlgender.SelectedValue;
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
                Sevainfo.Resident = "";
                Sevainfo.Email = txtEmailAddress.Text;
                Sevainfo.AltEmail = "";


                int resl;
                decimal re;
                if (!string.IsNullOrWhiteSpace(txtamount.Text) && decimal.TryParse(txtamount.Text, out re))
                    Sevainfo.Amount = Convert.ToDecimal(txtamount.Text);
                if (!string.IsNullOrWhiteSpace(txtamount.Text) && int.TryParse(txtamount.Text, out resl))
                    Sevainfo.Amount = Convert.ToInt32(txtamount.Text);

                Sevainfo.BookNo = Convert.ToString(txtbook.Text);
                Sevainfo.RecieptNo = Convert.ToString(txtreciept.Text);

                Sevainfo.Category = Convert.ToString(ddlsatsangcategory.SelectedValue);
                Sevainfo.IsActive = Convert.ToInt32(1);
                if (!string.IsNullOrWhiteSpace(txtprobableseva.Text) && int.TryParse(txtprobableseva.Text, out resl))
                    Sevainfo.ProbableSeva = Convert.ToInt32(txtprobableseva.Text);
                if (!string.IsNullOrWhiteSpace(txtmale.Text) && int.TryParse(txtmale.Text, out resl))
                    Sevainfo.MaleYajman = Convert.ToInt32(txtmale.Text);
                if (!string.IsNullOrWhiteSpace(txtfemale.Text) && int.TryParse(txtfemale.Text, out resl))
                    Sevainfo.FemaleYajman = Convert.ToInt32(txtfemale.Text);


                MembershipUser myObject = Membership.GetUser();
                Sevainfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));
                Sevainfo.UpdatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

                res = SIS.Services.PersonInfo.PersonInfo.InsertSevaInfo(Sevainfo);

                return res;
            }
            catch
            {
                return "";
            }
        }

        protected void btnexportdata_Click(object sender, EventArgs e)
        {
            DataSet ds = SIS.Services.PersonInfo.PersonInfo.GetSevaInfo();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                ExcelHelper.ToExcel(ds, "SilaSeva_" + DateTime.Now.ToShortDateString() + ".xls", Page.Response);
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('No Data to export.');", true);
            }
        }





    }
}