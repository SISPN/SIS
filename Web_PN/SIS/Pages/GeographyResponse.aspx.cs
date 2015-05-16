using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CIS.Pages
{
    public partial class GeographyResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CountryID = Request.QueryString["CountryID"];

            if (CountryID != null)
            {

                List<Entity.GeographyDDMenu.StateDetail> stateList = CIS.Services.Geography.Geography.GetStateList(CountryID);
                StringBuilder strStates = new StringBuilder();

                //Convert StateList object to JSON Format
                strStates.Append("[");

                for (int i = 0; i < stateList.Count(); i++)
                {
                    strStates.Append("{");
                    strStates.Append("\"StateCode\":\"" + stateList[i].Code + "\",");
                    strStates.Append("\"StateName\":\"" + stateList[i].Name + "\"");
                    strStates.Append("},");
                }

                strStates.Append("]");

                var finalString = strStates.ToString().Substring(0, strStates.ToString().Length - 2) + "]";

                //Send the response to the client
                Response.ContentType = "application/json";
                Response.ContentEncoding = Encoding.UTF8;
                Response.Write(finalString.ToString());
                Response.End();
            }

        }
    }
}