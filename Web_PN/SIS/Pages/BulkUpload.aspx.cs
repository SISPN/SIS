using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SIS.Pages
{
    public partial class BulkUpload : System.Web.UI.Page
    {
        Entity.PersonalInfo.UserInfo UserInfo = new Entity.PersonalInfo.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLookupInfo();
            }
        }


        private void BindLookupInfo()
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            ReadExcel();
        }

        private DataTable ReadExcel()
        {
            try
            {
                DataSet ds = new DataSet();
                if (fudata.FileContent.Length > 0 && Convert.ToInt32(ddlXetra.SelectedValue) > 0 && Convert.ToInt32(ddlMandal.SelectedValue) > 0)
                {
                    string fileExtension =
                                         System.IO.Path.GetExtension(fudata.FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + fudata.FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {

                            System.IO.File.Delete(fileLocation);
                        }
                        fudata.SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {

                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }


                    DataTable resultData = new DataTable();
                    resultData.Columns.Add("PersonId");
                    resultData.Columns.Add("Xetra");
                    resultData.Columns.Add("Mandal");
                    resultData.Columns.Add("Name");
                    resultData.Columns.Add("MobilePhone");
                    resultData.Columns.Add("HomePhone");
                    resultData.Columns.Add("Email");
                    resultData.Columns.Add("CurrentStatus");
                    resultData.Columns.Add("Karyakar");
                    resultData.Columns.Add("Category");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i >= 3)
                        {
                            DataRow dr = resultData.NewRow();

                            if (Convert.ToString(ds.Tables[0].Rows[i]["F4"]).Contains("PN/P"))
                                dr["PersonId"] = ds.Tables[0].Rows[i]["F4"];
                            else if (Convert.ToString(ds.Tables[0].Rows[i]["F6"]) != "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data not in Valid Format. Please correct it.');", true);
                                return null;
                            }
                            else if (Convert.ToString(ds.Tables[0].Rows[i]["F6"]) == "")
                                continue;

                            dr["Xetra"] = ddlXetra.SelectedValue;
                            dr["Mandal"] = ddlMandal.SelectedValue;
                            dr["Name"] = ds.Tables[0].Rows[i]["F6"];
                            dr["MobilePhone"] = ds.Tables[0].Rows[i]["F9"];
                            dr["HomePhone"] = ds.Tables[0].Rows[i]["F10"];
                            dr["Email"] = ds.Tables[0].Rows[i]["F12"];
                            dr["Karyakar"] = ds.Tables[0].Rows[i]["F13"];

                            if (Convert.ToString(ds.Tables[0].Rows[i]["F14"]) == "Yes")
                                dr["CurrentStatus"] = "1";
                            else if (Convert.ToString(ds.Tables[0].Rows[i]["F14"]) == "No")
                                dr["CurrentStatus"] = "0";
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data not in Valid Format. Please correct it.');", true);
                                return null;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["F15"]) == "S")
                                dr["Category"] = "Satsangi";
                            else if (Convert.ToString(ds.Tables[0].Rows[i]["F15"]) == "G VIP")
                                dr["Category"] = "GunbhaviVIP";
                            else if (Convert.ToString(ds.Tables[0].Rows[i]["F15"]) == "S VIP")
                                dr["Category"] = "SatsangiVIP";
                            else if (Convert.ToString(ds.Tables[0].Rows[i]["F15"]) == "G")
                                dr["Category"] = "Gunbhavi";
                            else if (Convert.ToString(ds.Tables[0].Rows[i]["F15"]) == "")
                                dr["Category"] = "";
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Data not in Valid Format. Please correct it.');", true);
                                return null;
                            }

                            resultData.Rows.Add(dr);
                        }
                    }


                    if (resultData.Rows.Count > 0)
                    {
                        dlresultlist.DataSource = resultData;
                        dlresultlist.DataBind();
                        lblnodata.Style.Add("display", "none");
                        return resultData;
                    }
                    else
                    {
                        dlresultlist.DataSource = new DataTable();
                        dlresultlist.DataBind();
                        lblnodata.Style.Add("display", "block");
                        return null;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('You must select all Xetra, Mandal and File.');", true);
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dlresultlist_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ReadExcel();


            if (dt != null && dt.Rows.Count > 0)
            {
                MembershipUser myObject = Membership.GetUser();

                foreach (DataRow item in dt.Rows)
                {
                     SIS.Services.PersonInfo.PersonInfo.InsertPersonalInfo(item,Guid.Parse(Convert.ToString(myObject.ProviderUserKey)));
                }
            }
        }
    }
}