using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SIS.Services.Menu;
using System.Data;
using SIS.Utility;


namespace SIS
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptInclude("jQueryMin", ResolveUrl("~/Scripts/jquery-1.4.1.js"));
            lblbuildnumber.Text = String.Format("<b> Version </b>: {0} &nbsp;&nbsp;  <b> Dated </b>: {1}",
    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
    System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToShortDateString());

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();

                string[] RolesforCurrentUser = Roles.GetRolesForUser();

                if (RolesforCurrentUser.Length > 0)
                {
                    ds = MenuDetail.GetMenuInfo(RolesforCurrentUser);

                    //string currentUrl = Request.Url.ConvetToString();
                    //currentUrl = currentUrl.Substring(currentUrl.LastIndexOf("/"));
                    //int aspxIndex = currentUrl.IndexOf(".aspx", StringComparison.OrdinalIgnoreCase);

                    //if (aspxIndex == -1)
                    //    RedirectToLoginPage();

                    //currentUrl = currentUrl.Substring(0, aspxIndex + ".aspx".Length);

                    //DataRow[] dr = ds.Tables[0].Select("Url like  '%" + currentUrl + "%'");
                    //if (dr.Length == 0)
                    //{
                    //    dr = ds.Tables[1].Select("Url like '%" + currentUrl + "%'");
                    //    if (dr.Length == 0)
                    //        RedirectToLoginPage();
                    //}

                    foreach (DataRow parentItem in ds.Tables["ParentDetail"].Rows)
                    {
                        MenuItem categoryItem = new MenuItem((string)parentItem["Name"]);

                        if (parentItem["Url"] != DBNull.Value)
                            categoryItem.NavigateUrl = (string)parentItem["Url"];

                        NavigationMenu.Items.Add(categoryItem);

                        foreach (DataRow childItem in parentItem.GetChildRows("Menu_Role"))
                        {
                            MenuItem childrenItem = new MenuItem((string)childItem["Name"]);

                            if (childItem["Url"] != DBNull.Value)
                                childrenItem.NavigateUrl = (string)childItem["Url"];
                            categoryItem.ChildItems.Add(childrenItem);
                        }
                    }
                }
                else
                {
                    if (!Request.Url.ToString().Contains("Login.aspx"))
                        RedirectToLoginPage();
                }

            }
        }

        private void RedirectToLoginPage()
        {
            //Session.Abandon();
            //Session.RemoveAll();
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}
