using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using System.Net;
using System.Configuration;

namespace SIS.HelperClass
{
    [Serializable]
    public class ReportCredentials : IReportServerCredentials
    {
        #region IReportServerCredentials Members
        private string _UserName;
        private string _PassWord;
        private string _DomainName;

        public ReportCredentials()
        {
        }

        public ReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = password = authority = null;
            return false;
        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public ICredentials NetworkCredentials
        {
            //get { return new NetworkCredential(_UserName, _PassWord, _DomainName); }
            get { return ReportConfigurations.NetworkCred; }
        }

        #endregion


    }

    public class ReportConfigurations
    {
        public enum ReportsName
        {
            ChartReport
        }

        public static NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["ReportServerUserName"],
                                                   ConfigurationManager.AppSettings["ReportServerPwd"],
                                                   ConfigurationManager.AppSettings["ReportServerDomain"]);
        public static string strReportExecutionServiceURL = ConfigurationManager.AppSettings["ReportExecutionServiceURL"];
        public static string strReportServerPath = ConfigurationManager.AppSettings["ReportServerPath"];
        public static string strTargetReportFolder = ConfigurationManager.AppSettings["TargetReportFolder"];
        //public static string strTargetReportFolderForDW = ConfigurationManager.AppSettings["TargetReportFolderForDW"];
    }
}