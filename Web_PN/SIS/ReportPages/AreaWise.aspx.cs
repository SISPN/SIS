using System;
using Microsoft.Reporting.WebForms;
using SIS.HelperClass;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Security;

namespace SIS.Reports
{
    public partial class CityWise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLookupInfo();


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
            string selectedcategory = GetCheckBoxListSelections();

            if (!string.IsNullOrWhiteSpace(selectedcategory))
            {
                rptAreaWise.ServerReport.ReportServerCredentials = new ReportCredentials();
                rptAreaWise.ServerReport.ReportServerUrl = new Uri(ReportConfigurations.strReportServerPath);

                if(Convert.ToString( ddltype.SelectedValue)=="Full")
                    rptAreaWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "AreaWise";
                else
                    rptAreaWise.ServerReport.ReportPath = ReportConfigurations.strTargetReportFolder + "CompactContactList";

                ReportParameter rptMandalId = new ReportParameter("MandalId", ddlMandal.SelectedValue.Equals("-1") ? "0" : ddlMandal.SelectedValue);
                ReportParameter rptXetraId = new ReportParameter("XetraId", ddlXetra.SelectedValue.Equals("-1") ? "0" : ddlXetra.SelectedValue);
                ReportParameter rptCategory = new ReportParameter("SatsangCategory", selectedcategory);

                ReportParameter[] rpArray;
                rpArray = new ReportParameter[] { rptMandalId, rptXetraId, rptCategory };

                rptAreaWise.ServerReport.SetParameters(rpArray);
                rptAreaWise.ServerReport.Refresh();
            }
            else
                Label2.Text = "Please Select Category.";
        }
        #endregion



    }
}