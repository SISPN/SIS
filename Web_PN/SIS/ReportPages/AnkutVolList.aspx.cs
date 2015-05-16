using System;
using Microsoft.Reporting.WebForms;
using SIS.HelperClass;
using System.Collections.Generic;

namespace SIS.Reports
{
    public partial class AnkutVolList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GeneralMethods.BindDropdownFromLookup(ddlankutGroup, "AnkutGroup", true);
            }
        }
        #region "Contraol Events"


        protected void btnshowrpt_Click(object sender, EventArgs e)
        {

            rptAreaWise.ServerReport.ReportServerCredentials = new ReportCredentials();
            rptAreaWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);

            rptAreaWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AnkutVolDetails";
            ReportParameter rptCategory = null;

            if (Convert.ToString(ddlcategory.SelectedValue) != "-1")
            {
                rptCategory = new ReportParameter("CateGory", Convert.ToString(ddlcategory.SelectedValue));
            }
            else
            {
                rptCategory = new ReportParameter("CateGory", new string[] { null }, false);
            }
            ReportParameter rptPersonId = null;
           if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlak.SelectedValue)) && Convert.ToString(ddlak.SelectedValue) != "-1")
            {
                rptPersonId = new ReportParameter("PersonId", ddlak.SelectedValue);
            }
            else if (!string.IsNullOrWhiteSpace(Convert.ToString(ddlgroupperson.SelectedValue)) && Convert.ToString(ddlgroupperson.SelectedValue) != "-1")
            {
                rptPersonId = new ReportParameter("PersonId", ddlgroupperson.SelectedValue);
            }
            else
            { 
             rptPersonId = new ReportParameter("PersonId" ,"");
            }


            ReportParameter[] rpArray;
            rpArray = new ReportParameter[] { rptCategory, rptPersonId };

            rptAreaWise.ServerReport.SetParameters(rpArray);
            rptAreaWise.ServerReport.Refresh();
        }
        #endregion

        protected void ddlisankutsevak_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entity.PersonalInfo.AnkutPersonDetails> lstankutperson = SIS.Services.PersonInfo.PersonInfo.GetGroupDetails(Convert.ToString(ddlankutGroup.SelectedValue));
            ddlgroupperson.DataSource = lstankutperson;
            ddlgroupperson.DataTextField = "FullName";
            ddlgroupperson.DataValueField = "PersonalID";
            ddlgroupperson.DataBind();
           
        }

        protected void ddlgroupperson_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entity.PersonalInfo.AnkutPersonDetails> lstankutperson = SIS.Services.PersonInfo.PersonInfo.GetAKDetails(Convert.ToString("AK"), Convert.ToString(ddlgroupperson.SelectedValue));
            ddlak.DataSource = lstankutperson;
            ddlak.DataTextField = "FullName";
            ddlak.DataValueField = "PersonalID";
            ddlak.DataBind();
        }

       

    }
}