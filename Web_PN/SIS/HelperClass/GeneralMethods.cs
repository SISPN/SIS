using System.Collections.Generic;

namespace SIS.HelperClass
{
    public class GeneralMethods
    {
        public static void BindDropdownFromLookup(System.Web.UI.WebControls.DropDownList ddl, string lookupName, bool isDefault)
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            List<SIS.Entity.Lookup.Lookup> lookupInfo = lookup.GetLookup(lookupName);

            if (isDefault)
            {
                SIS.Entity.Lookup.Lookup lookupSelect = new Entity.Lookup.Lookup();
                lookupSelect.DisplayText = "---Select---";
                lookupSelect.Value = "-1";
                lookupInfo.Insert(0, lookupSelect);
            }

            ddl.DataSource = lookupInfo;
            ddl.DataTextField = "DisplayText";
            ddl.DataValueField = "Value";
            ddl.DataBind();
            ddl.SelectedIndex = 0;
        }

        public static void BindDropdownFromLookup(System.Web.UI.WebControls.CheckBoxList ddl, string lookupName)
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            List<SIS.Entity.Lookup.Lookup> lookupInfo = lookup.GetLookup(lookupName);

            ddl.DataSource = lookupInfo;
            ddl.DataTextField = "DisplayText";
            ddl.DataValueField = "Value";
            ddl.DataBind();
            ddl.SelectedIndex = 0;
        }

        public static List<SIS.Entity.Lookup.Lookup> BindDropdownFromLookup(string lookupName)
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            List<SIS.Entity.Lookup.Lookup> lookupInfo = lookup.GetLookup(lookupName);

            return lookupInfo;
        }

        public static void BindDropdownFromLookup(AjaxControlToolkit.ComboBox ddl, string lookupName, bool isDefault)
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            List<SIS.Entity.Lookup.Lookup> lookupInfo = lookup.GetLookup(lookupName);

            if (isDefault)
            {
                SIS.Entity.Lookup.Lookup lookupSelect = new Entity.Lookup.Lookup();
                lookupSelect.DisplayText = "---Select---";
                lookupSelect.Value = "-1";
                lookupInfo.Insert(0, lookupSelect);
            }

            ddl.DataSource = lookupInfo;
            ddl.DataTextField = "DisplayText";
            ddl.DataValueField = "Value";
            ddl.DataBind();
            ddl.SelectedIndex = 0;
        }

        public static List<SIS.Entity.Lookup.Lookup> GetLookupList(string lookupName, bool isDefault)
        {
            SIS.Services.Lookup.Lookup lookup = new Services.Lookup.Lookup();
            List<SIS.Entity.Lookup.Lookup> lookupInfo = lookup.GetLookup(lookupName);

            if (isDefault)
            {
                SIS.Entity.Lookup.Lookup lookupSelect = new Entity.Lookup.Lookup();
                lookupSelect.DisplayText = "---Select---";
                lookupSelect.Value = "-1";
                lookupInfo.Insert(0, lookupSelect);
            }
            return lookupInfo;
        }
    }
}
