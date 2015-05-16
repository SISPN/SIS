// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


using System;
using System.Collections.Generic;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : WebService
{
    public AutoComplete()
    {
    }

    [WebMethod]
    public string[] GetContactList(string prefixText, int count)
    {
        List<string> items = new List<string>(count);
      
        List<SIS.Entity.PersonalInfo.SevaInfo> contacts = SIS.Services.PersonInfo.PersonInfo.GetContactDetails( prefixText);

        foreach (SIS.Entity.PersonalInfo.SevaInfo c in contacts)
        {
            string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(c.FName + " " + c.MName + " " + c.LName + "," + c.Mobile,Convert.ToString( c.ID));
            items.Add(item);
            
        }

        return items.ToArray();
    }


    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
       
        List<string> items = new List<string>(count);
       
        List<SIS.Entity.PersonalInfo.PersonalInfo> contacts = SIS.Services.PersonInfo.PersonInfo.GetContacts( prefixText);

        foreach (SIS.Entity.PersonalInfo.PersonalInfo c in contacts)
        {
            string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(c.FirstName + " " + c.MiddleName + " " + c.LastName + "," + c.MobilePhone + ", Status :" + c.CurrentStatus, c.PersonId);
            items.Add(item);
            
        }
        return items.ToArray();
    }


    [WebMethod]
    public string[] GetCompletionListwithEmail(string prefixText, int count)
    {

        List<string> items = new List<string>(count);

        List<SIS.Entity.PersonalInfo.PersonalInfo> contacts = SIS.Services.PersonInfo.PersonInfo.GetContacts(prefixText);

        foreach (SIS.Entity.PersonalInfo.PersonalInfo c in contacts)
        {
            string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(c.FirstName + " " + c.MiddleName + " " + c.LastName + "," + c.MobilePhone + ", Status :" + c.CurrentStatus , c.PersonId);
            items.Add(item);

        }
        return items.ToArray();
    }
}