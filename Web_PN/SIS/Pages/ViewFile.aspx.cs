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
    public partial class ViewFile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void dlresultlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Guid Id = Guid.Parse(grdfiles.DataKeys[e.RowIndex].Values["Id"].ToString());

            string res = Convert.ToString(SIS.HelperClass.FileInfo.DeleteFileInfo(Id));

            if (!string.IsNullOrEmpty(res))
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            grdfiles.DataSource = SIS.HelperClass.FileInfo.GetList();
            grdfiles.DataBind();
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txttag.Text) && fudocs.HasFile)
            {
                string contentType = fudocs.PostedFile.ContentType;

                // Get the bytes from the uploaded file
                byte[] fileData = new byte[fudocs.PostedFile.InputStream.Length];
                fudocs.PostedFile.InputStream.Read(fileData, 0, fileData.Length);

                // Get the name without folder information from the uploaded file.
                string originalName = Path.GetFileName(fudocs.PostedFile.FileName);

                // Create a new instance of the File class based on the uploaded file.
                SIS.HelperClass.File myFile = new SIS.HelperClass.File(txttag.Text, contentType, originalName, fileData);

                // Save the file, and tell the Save method what data store to use.
                switch (AppConfiguration.DataStoreType)
                {
                    case DataStoreType.Database:
                        myFile.Save();
                        BindGrid();
                        break;
                    case DataStoreType.FileSystem:
                        myFile.Save(Server.MapPath(Path.Combine(AppConfiguration.UploadsFolder, myFile.FileUrl)));
                        BindGrid();
                        break;
                }

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('You must specify tag in order to upload documents.');", true);
        }



    }
}