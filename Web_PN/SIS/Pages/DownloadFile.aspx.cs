using SIS.HelperClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS.Pages
{
    public partial class DownloadFile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("Id") != null)
            {
                Response.Clear();

                Guid id = new Guid(Request.QueryString.Get("Id"));
                SIS.HelperClass.File myFile = SIS.HelperClass.File.GetItem(id);

                Response.ContentType = "application/x-unknown";
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + myFile.OriginalName + "\"");
                if (myFile.ContainsFile)
                {
                    Response.BinaryWrite(myFile.FileData);
                }
                else
                {
                    Response.WriteFile(Path.Combine(AppConfiguration.UploadsFolder, myFile.FileUrl));
                }
            }
            else
            {
                Response.Redirect("~/");
            }
        }


    }
}