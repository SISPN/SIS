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
    public partial class ContactList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] RolesforCurrentUser = Roles.GetRolesForUser();
                if (RolesforCurrentUser.Length > 0 && RolesforCurrentUser[0].ToLower().Equals("admin"))
                {
                    btnexportdata.Visible = true;
                }
                else
                {
                    btnexportdata.Visible = false;
                }

                if (RolesforCurrentUser.Length > 0 && !RolesforCurrentUser[0].ToLower().Equals("admin"))
                {
                    ddlsatsangcategory.SelectedValue = "GUNBHAVI";
                    ddlsatsangcategory.Enabled = false;
                }


                GeneralMethods.BindDropdownFromLookup(ddlsatsangcategory, "ContactListType", true);
                ResetForm();
                txtbringname.Text = "";
                hfbringperson.Value = string.Empty;

            }

        }



        protected void btnsave_Click(object sender, EventArgs e)
        {
            string BringpersonId = Request.Form[hfbringperson.UniqueID];

            string res = SaveData();
            if (!string.IsNullOrWhiteSpace(res))
            {
                lblstatus.Text = "Last Person ID : " + res;
                ResetForm();
                txtbringname.Text = "";
                hfbringperson.Value = string.Empty;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data Added successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Application Error Contact Admin.');", true);
            }

        }



        protected void ResetForm()
        {
            txtmasterid.Text = "";
            myTextBox.Text = "";
            txtbringmobile.Text = "";
            txtFName.Text = "";
            txtMiddelName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtVillage.Text = "";
            txtPin.Text = "";
            txtMobile.Text = "";
            txtEmailAddress.Text = "";
            ddlsatsangcategory.SelectedValue = "-1";
            ddlgender.SelectedValue = "Male";
            ddlsatsangcategory.SelectedValue = "GUNBHAVI";
        }

        protected void EnableDisableForm(bool flag)
        {
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
        }

        private string SaveData()
        {
            try
            {
                string res = "";

                SIS.Entity.PersonalInfo.SevaInfo Sevainfo = new SIS.Entity.PersonalInfo.SevaInfo();

                string BringpersonId = Request.Form[hfbringperson.UniqueID];
                Sevainfo.SevaBringPersonId = Convert.ToString(BringpersonId);
                Sevainfo.SevaBringMobile = Convert.ToString(txtbringmobile.Text);
                Sevainfo.SevaBringName = Convert.ToString(txtbringname.Text);

                if (!string.IsNullOrWhiteSpace(txtmasterid.Text))
                    Sevainfo.ID = Convert.ToInt32(txtmasterid.Text);

                Sevainfo.PersonMandal = "-1";
                Sevainfo.PersonXetra = "-1";
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

                Sevainfo.PostCategory = Convert.ToString(ddlpostal.SelectedValue);
                Sevainfo.Category = Convert.ToString(ddlsatsangcategory.SelectedValue);
                Sevainfo.IsActive = Convert.ToInt32(1);

                MembershipUser myObject = Membership.GetUser();
                Sevainfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));
                Sevainfo.UpdatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

                res = SIS.Services.PersonInfo.PersonInfo.InsertContactInfo(Sevainfo);

                return res;
            }
            catch
            {
                return "";
            }
        }

        protected void btnexportdata_Click(object sender, EventArgs e)
        {
            DataSet ds = SIS.Services.PersonInfo.PersonInfo.GetContactInfo();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                ExcelHelper.ToExcel(ds, "ContactDetails_" + DateTime.Now.ToShortDateString() + ".xls", Page.Response);
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('No Data to export.');", true);
            }
        }

        protected void hfbringperson_ValueChanged(object sender, EventArgs e)
        {
            txtMobile.Text = "test";
        }

        protected void lnkgetId_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Convert.ToString(Request.Form[hfPersonId.UniqueID])))
                SetData(Convert.ToString(Request.Form[hfPersonId.UniqueID]));
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Please enter data to search.');", true);
        }


        private void SetData(string thisPid)
        {
            SIS.Entity.PersonalInfo.SevaInfo Sevainfo = new SIS.Entity.PersonalInfo.SevaInfo();
            Sevainfo = SIS.Services.PersonInfo.PersonInfo.GetthisUserInfoForSeva(thisPid);

            txtmasterid.Text = thisPid;
            ddlgender.SelectedValue = Sevainfo.Gender;
            txtFName.Text = Sevainfo.FName;
            txtMiddelName.Text = Sevainfo.MName;
            txtLastName.Text = Sevainfo.LName;
            hfPersonId.Value = Convert.ToString(thisPid);

            txtAddress.Text = Sevainfo.Address;
            txtVillage.Text = Sevainfo.Area;


            if (Sevainfo.Country != Guid.Empty)
                cddCountry.SelectedValue = Convert.ToString(Sevainfo.Country);
            else
                cddCountry.SelectedValue = "-1";


            if (Sevainfo.State != Guid.Empty)
                cddState.SelectedValue = Convert.ToString(Sevainfo.State);
            else
                cddState.SelectedValue = "-1";


            if (Sevainfo.District != Guid.Empty)
                cddDistrict.SelectedValue = Convert.ToString(Sevainfo.District);
            else
                cddDistrict.SelectedValue = "-1";


            if (Sevainfo.Taluko != Guid.Empty)
                cddCity.SelectedValue = Convert.ToString(Sevainfo.Taluko);
            else
                cddCity.SelectedValue = "-1";

            if (Sevainfo.Pin != null && Sevainfo.Pin.Equals(0))
                txtPin.Text = "0";
            else
                txtPin.Text = Convert.ToString(Sevainfo.Pin);


            txtMobile.Text = Sevainfo.Mobile;
            txtEmailAddress.Text = Sevainfo.Email;


            if (Sevainfo.Category == "-1")
                ddlsatsangcategory.SelectedValue = "GUNBHAVI";
            else
                ddlsatsangcategory.SelectedValue = Sevainfo.Category;

            ddlpostal.SelectedValue = Sevainfo.PostCategory;

            if (!string.IsNullOrWhiteSpace(Sevainfo.SevaBringName))
            {
                txtbringname.Text = Convert.ToString(Sevainfo.SevaBringName);
                txtbringmobile.Text = Convert.ToString(Sevainfo.SevaBringMobile);
                hfbringperson.Value = Convert.ToString(Sevainfo.SevaBringPersonId);
            }
            else
            {
                txtbringname.Text = "";
                txtbringmobile.Text = "";
                hfbringperson.Value = "";
            }
            hfPersonId.Value = Convert.ToString(Sevainfo.PersonId);

        }




    }
}