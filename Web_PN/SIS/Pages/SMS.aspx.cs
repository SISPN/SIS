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
    public partial class SMS : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiCheckCombo1.ClearAll();
                MultiCheckCombo1.AddItems(GeneralMethods.BindDropdownFromLookup("SatsangCategory"));

                chkkaryakar.DataSource = GeneralMethods.BindDropdownFromLookup("SatsangActivity");
                chkkaryakar.DataTextField = "DisplayText";
                chkkaryakar.DataValueField = "Value";
                chkkaryakar.DataBind();

                chkcontactlist.DataSource = GeneralMethods.BindDropdownFromLookup("ContactListType");
                chkcontactlist.DataTextField = "DisplayText";
                chkcontactlist.DataValueField = "Value";
                chkcontactlist.DataBind();

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



        protected void btnshowrpt_Click(object sender, EventArgs e)
        {
            List<string> lstsms = new List<string>();
            if (!string.IsNullOrWhiteSpace(Convert.ToString(mytextbox.Text.Trim())))
            {
                string mobiles = string.Empty;
                string othercategory = GetCheckBoxListSelections(chkkaryakar);
                if (!string.IsNullOrWhiteSpace(othercategory))
                {
                    lstsms = SIS.Services.PersonInfo.PersonInfo.GetSMSOtherGroupDetails(othercategory);
                    lstsms.RemoveAll(string.IsNullOrWhiteSpace);
                    mobiles = string.Join(",", lstsms);
                    txtmobile.Text = mobiles;
                }
                string othercontacts = GetCheckBoxListSelections(chkcontactlist);
                if (!string.IsNullOrWhiteSpace(othercontacts))
                {
                    lstsms = SIS.Services.PersonInfo.PersonInfo.GetSMSOtherContactGroupDetails(othercontacts);
                    lstsms.RemoveAll(string.IsNullOrWhiteSpace);
                    if (!string.IsNullOrWhiteSpace(mobiles))
                        mobiles = mobiles + "," + string.Join(",", lstsms);
                    else
                        mobiles = string.Join(",", lstsms);

                    txtmobile.Text = mobiles;
                }
                string category = Convert.ToString(MultiCheckCombo1.Text.Trim()).Replace(" ", "");
                if (!string.IsNullOrWhiteSpace(othercategory))
                {
                    lstsms = SIS.Services.PersonInfo.PersonInfo.GetSMSGroupDetails(category, ddlMandal.SelectedValue.Equals("-1") ? "0" : Convert.ToString(ddlMandal.SelectedValue), Convert.ToString(ddlXetra.SelectedValue));
                    lstsms.RemoveAll(string.IsNullOrWhiteSpace);
                    if (!string.IsNullOrWhiteSpace(mobiles))
                        mobiles = mobiles + "," + string.Join(",", lstsms);
                    else
                        mobiles = string.Join(",", lstsms);

                    txtmobile.Text = mobiles;
                }

                List<string> lstsmsfinal = new List<string>(mobiles.Split(','));

                if (lstsmsfinal.Count > 0)
                {
                  //  SendSMS(lstsmsfinal, Convert.ToString(mytextbox.Text.Trim()));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('SMS will send in some times to your selected group');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('No Mobiles Founds');", true);


            }
        }

        private void SendSMS(List<string> lstsms, string sms)
        {
            lstsms.RemoveAll(string.IsNullOrWhiteSpace);
            List<string> lsttemp = new List<string>();
            for (int i = 0; i <= lstsms.Count; i++)
            {
                if ((i + 200) > lstsms.Count)
                    lsttemp = lstsms.GetRange(i, lstsms.Count - i);
                else
                    lsttemp = lstsms.GetRange(i, 200);
                i += 199;


                string mobiles = string.Join(",", lsttemp);

                //mobiles = "7387115127";
                //Your authentication key
                //string authKey =   "74995A1rvZ1YLfhG54708e99";
                string authKey = txtkey.Text;
                //Multiple mobiles numbers separated by comma

                //Sender ID,While using route4 sender id should be 6 characters long.
                // string senderId = "BAPSPN";
                string senderId = txtSender.Text;
                //Your message to send, Add URL encoding here.
                string message = HttpUtility.UrlEncode(sms);
                //message = sms;
                //Prepare you post parameters
                StringBuilder sbPostData = new StringBuilder();


                sbPostData.AppendFormat("authkey={0}", authKey);
                sbPostData.AppendFormat("&mobiles={0}", mobiles);
                sbPostData.AppendFormat("&message={0}", sms);
                sbPostData.AppendFormat("&sender={0}", senderId);
                sbPostData.AppendFormat("&route={0}", "Template");
                sbPostData.AppendFormat("&unicode={0}", "1");
                try
                {
                    //Call Send SMS API
                    // string sendSMSUri = "https://control.msg91.com/sendhttp.php";
                    string sendSMSUri = txturl.Text.Trim();
                    //Create HTTPWebrequest
                    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                    //Prepare and Add URL Encoded data
                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] data = encoding.GetBytes(sbPostData.ToString());
                    //Specify post method
                    httpWReq.Method = "POST";
                    httpWReq.ContentType = "application/x-www-form-urlencoded";
                    httpWReq.ContentLength = data.Length;
                    using (Stream stream = httpWReq.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    //Get the response
                    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseString = reader.ReadToEnd();

                    //Close the response
                    reader.Close();
                    response.Close();
                }
                catch (SystemException ex)
                {

                }
            }
        }


        protected void btngetcnt_Click(object sender, EventArgs e)
        {
            List<string> lstsms = new List<string>();
            if (!string.IsNullOrWhiteSpace(Convert.ToString(mytextbox.Text.Trim())))
            {
                string mobiles = string.Empty;
                string othercategory = GetCheckBoxListSelections(chkkaryakar);
                if (!string.IsNullOrWhiteSpace(othercategory))
                {
                    lstsms = SIS.Services.PersonInfo.PersonInfo.GetSMSOtherGroupDetails(othercategory);
                    lstsms.RemoveAll(string.IsNullOrWhiteSpace);
                    mobiles = string.Join(",", lstsms);
                    txtmobile.Text = mobiles;
                }
                string othercontacts = GetCheckBoxListSelections(chkcontactlist);
                if (!string.IsNullOrWhiteSpace(othercontacts))
                {
                    lstsms = SIS.Services.PersonInfo.PersonInfo.GetSMSOtherContactGroupDetails(othercontacts);
                    lstsms.RemoveAll(string.IsNullOrWhiteSpace);
                    if (!string.IsNullOrWhiteSpace(mobiles))
                        mobiles = mobiles + "," + string.Join(",", lstsms);
                    else
                        mobiles = string.Join(",", lstsms);

                    txtmobile.Text = mobiles;
                }
                string category = Convert.ToString(MultiCheckCombo1.Text.Trim()).Replace(" ", "");
                if (!string.IsNullOrWhiteSpace(othercategory))
                {
                    lstsms = SIS.Services.PersonInfo.PersonInfo.GetSMSGroupDetails(category, ddlMandal.SelectedValue.Equals("-1") ? "0" : Convert.ToString(ddlMandal.SelectedValue), Convert.ToString(ddlXetra.SelectedValue));
                    lstsms.RemoveAll(string.IsNullOrWhiteSpace);
                    if (!string.IsNullOrWhiteSpace(mobiles))
                        mobiles = mobiles + "," + string.Join(",", lstsms);
                    else
                        mobiles = string.Join(",", lstsms);

                    txtmobile.Text = mobiles;
                }

                List<string> lstsmsfinal = new List<string>(mobiles.Split(','));

                if (lstsmsfinal.Count > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('Total Mobile Numbers Found - " + lstsmsfinal.Count + "');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OnSave", "alert('No Mobiles Founds');", true);
            }
        }



        private string GetCheckBoxListSelections(CheckBoxList chk)
        {

            string[] cblItems;
            ArrayList cblSelections = new ArrayList();
            foreach (ListItem item in chk.Items)
            {
                if (item.Selected)
                {
                    cblSelections.Add(item.Value);
                }
            }

            cblItems = (string[])cblSelections.ToArray(typeof(string));
            return string.Join(",", cblItems);
        }





    }
}