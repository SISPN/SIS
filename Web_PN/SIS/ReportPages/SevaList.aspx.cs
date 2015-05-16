using System;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using SIS.HelperClass;
using System.Configuration;

namespace SIS.Reports
{
    public partial class SevaList : System.Web.UI.Page
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

            }
        }
        #region "Control Events"
        protected void btnshowrpt_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddltype.SelectedValue) == 0)
            {

                rptXetraWise.ServerReport.ReportServerCredentials = new ReportCredentials();
                rptXetraWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);
                ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
                ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);
                ReportParameter rptfromamount = new ReportParameter("FromAmount", string.IsNullOrWhiteSpace(txtamountfrom.Text) ? "0" : txtamountfrom.Text);
                ReportParameter rpttoamount = new ReportParameter("ToAmount", string.IsNullOrWhiteSpace(txtamountto.Text) ? "0" : txtamountto.Text);

                ReportParameter[] rpArray;
                rpArray = new ReportParameter[] { rptMandalId, rptXetraId, rptfromamount, rpttoamount };
                rptXetraWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "SilaSeva";

                rptXetraWise.ServerReport.SetParameters(rpArray);
                rptXetraWise.ServerReport.Refresh();
            }
            else
            {
                rptXetraWise.ServerReport.ReportServerCredentials = new ReportCredentials();
                rptXetraWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);
                ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
                ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);
                ReportParameter rptfromamount = new ReportParameter("FromAmount", string.IsNullOrWhiteSpace(txtamountfrom.Text) ? "0" : txtamountfrom.Text);
                ReportParameter rpttoamount = new ReportParameter("ToAmount", string.IsNullOrWhiteSpace(txtamountto.Text) ? "0" : txtamountto.Text);

                ReportParameter[] rpArray;
                rpArray = new ReportParameter[] { rptMandalId, rptXetraId, rptfromamount, rpttoamount };
                rptXetraWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AddressPrint3X8_Sila";

                rptXetraWise.ServerReport.SetParameters(rpArray);
                rptXetraWise.ServerReport.Refresh();
            }

        }
        #endregion


    }
}