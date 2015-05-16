using System;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using SIS.HelperClass;
using System.Configuration;

namespace SIS.Reports
{
    public partial class AnakutList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> ToYearList = new List<string>();

                ToYearList.Add("--Select--");

                for (long i = 2012; i <= DateTime.Now.Year; i++)
                    ToYearList.Add(i.ToString());

                ddlyear.DataSource = ToYearList;
                ddlyear.DataBind();

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
            if (Convert.ToInt32(ddlListtype.SelectedValue) == 1)
            {
                rptXetraWise.ServerReport.ReportServerCredentials = new ReportCredentials();
                rptXetraWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);
                ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
                ReportParameter rptyear = new ReportParameter("Year", ddlyear.SelectedValue.Equals("--Select--") ? "0" : ddlyear.Text);
                ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);

                ReportParameter[] rpArray;
                rpArray = new ReportParameter[] { rptMandalId, rptyear, rptXetraId };

                if (Convert.ToString(ConfigurationManager.AppSettings["CenterCode"]).ToLower().Equals("sn"))
                {
                    rptXetraWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AnnakutCardListSNR";
                }
                else
                {
                    rptXetraWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AnnakutCardList";
                }
                
                rptXetraWise.ServerReport.SetParameters(rpArray);
                rptXetraWise.ServerReport.Refresh();
            }
            else if (Convert.ToInt32(ddlListtype.SelectedValue) == 2)
            {
                rptXetraWise.ServerReport.ReportServerCredentials = new ReportCredentials();
                rptXetraWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);

                rptXetraWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AnakutListAreaWise";
                ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
                ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);
                ReportParameter[] rpArray;
                rpArray = new ReportParameter[] { rptMandalId, rptXetraId };


                rptXetraWise.ServerReport.SetParameters(rpArray);
                rptXetraWise.ServerReport.Refresh();
            }
        }
        #endregion


    }
}