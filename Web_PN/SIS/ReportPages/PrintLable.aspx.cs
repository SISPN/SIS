using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using SIS.HelperClass;
using SIS.Entity.Xetra;
using SIS.Utility;
using System.Data;
using System.Collections;


namespace SIS.Reports
{
    public partial class PrintLable : System.Web.UI.Page
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
                BindLookupInfo();
            }
        }

        #region "Contraol Events"
        private void BindLookupInfo()
        {

            GeneralMethods.BindDropdownFromLookup(chkcategory, "SatsangCategory");


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

            rptPrintLable.ServerReport.ReportServerCredentials = new ReportCredentials();
            rptPrintLable.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);
            ReportParameter[] rpArray;

            string reportName = "AddressPrint3X8";
            string selectedcategory = GetCheckBoxListSelections();


            if (Convert.ToString(ConfigurationManager.AppSettings["CenterCode"]).ToLower().Equals("sn"))
            {
                reportName = "AddressPrint3X8SNR";
                ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
                ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);

                rpArray = new ReportParameter[] { rptMandalId, rptXetraId };
            }
            else
            {
                ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
                ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);
                ReportParameter rptCategory = new ReportParameter("SatsangCategory", selectedcategory);

              
                rpArray = new ReportParameter[] { rptMandalId, rptXetraId, rptCategory };

            }

            rptPrintLable.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + reportName;

            //if (Convert.ToInt32(ddlreporttype.SelectedValue) == 2)
            //{

            rptPrintLable.ServerReport.SetParameters(rpArray);
            //}

            rptPrintLable.ServerReport.Refresh();
        }
        #endregion "Contraol Events"
    }
}