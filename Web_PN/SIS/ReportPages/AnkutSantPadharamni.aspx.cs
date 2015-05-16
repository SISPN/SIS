using System;
using Microsoft.Reporting.WebForms;
using SIS.HelperClass;

namespace SIS.Reports
{
    public partial class AnkutSantPadharamni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        #region "Contraol Events"
           

        protected void btnshowrpt_Click(object sender, EventArgs e)
        {

            rptAreaWise.ServerReport.ReportServerCredentials = new ReportCredentials();
            rptAreaWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);

            rptAreaWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AnkutSantPadharamani";
            ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
            ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);
            ReportParameter rptyear = new ReportParameter("AnkutYear", Convert.ToString( DateTime.Now.Year));
            ReportParameter[] rpArray;
            rpArray = new ReportParameter[] { rptMandalId, rptXetraId, rptyear };

            rptAreaWise.ServerReport.SetParameters(rpArray);
            rptAreaWise.ServerReport.Refresh();            
        }
        #endregion

      
        
    }
}