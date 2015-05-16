using System;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using SIS.HelperClass;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls;

namespace SIS.Reports
{
    public partial class ContactList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindLookupInfo();
        }
        #region "Control Events"
        private void BindLookupInfo()
        {

            GeneralMethods.BindDropdownFromLookup(chkcategory, "ContactListType");


        }
        private string GetCheckBoxListSelections()
        {

            string[] cblItems;
            ArrayList cblSelections = new ArrayList();
            foreach (ListItem item in chkcategory.Items)
            {
                if (item.Selected)
                {
                    cblSelections.Add(item.Value);
                }
            }

            cblItems = (string[])cblSelections.ToArray(typeof(string));
            return string.Join(",", cblItems);
        }
        protected void btnshowrpt_Click(object sender, EventArgs e)
        {
            string selectedcategory = GetCheckBoxListSelections();

            //if (!string.IsNullOrWhiteSpace(selectedcategory))
            //{
                if (Convert.ToInt32(ddltype.SelectedValue) == 0)
                {

                    rptXetraWise.ServerReport.ReportServerCredentials = new ReportCredentials();
                    rptXetraWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);
                    ReportParameter rptpost = new ReportParameter("PostType", ddlpostal.SelectedValue);
                    ReportParameter rptCategory = new ReportParameter("Category", selectedcategory);
                    ReportParameter[] rpArray;
                    rpArray = new ReportParameter[] { rptpost, rptCategory };
                    rptXetraWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "ContactList";

                    rptXetraWise.ServerReport.SetParameters(rpArray);
                    rptXetraWise.ServerReport.Refresh();
                }
                else
                {
                    rptXetraWise.ServerReport.ReportServerCredentials = new ReportCredentials();
                    rptXetraWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);
                    ReportParameter rptpost = new ReportParameter("PostType", ddlpostal.SelectedValue);
                    ReportParameter rptCategory = new ReportParameter("Category", selectedcategory);
                    ReportParameter[] rpArray;
                    rpArray = new ReportParameter[] { rptpost, rptCategory };
                    rptXetraWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AddressPrint3X8_Contact";

                    rptXetraWise.ServerReport.SetParameters(rpArray);
                    rptXetraWise.ServerReport.Refresh();
                }
            //}
        }
        #endregion


    }
}