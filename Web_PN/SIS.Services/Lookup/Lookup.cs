
using System.Collections.Generic;
using System.Linq;

namespace SIS.Services.Lookup
{
    public class Lookup
    {
        public List<Entity.Lookup.Lookup> GetLookup(string lookupName)
        {
            List<Entity.Lookup.Lookup> lookup = Data.Lookup.Common.GetLookup();

            var query = (from lm in lookup
                         where lm.Name.ToUpper().Equals(lookupName.ToUpper())
                         select new Entity.Lookup.Lookup
                         {
                             DisplayText = lm.DisplayText,
                             Value = lm.Value
                         });

            return query.ToList();
        }

        public List<Entity.Lookup.Lookup> GetAllLookupName()
        {
            List<Entity.Lookup.Lookup> lookup = Data.Lookup.Common.GetAllLookupName();

            return lookup;
        }

        public static int InsertLookup(Entity.Lookup.Lookup LookupInfo)
        {
            return Data.Lookup.Lookup.InsertLookup(LookupInfo);
        }

        public List<Entity.Lookup.Lookup> GetParentMenu()
        {
            List<Entity.Lookup.Lookup> lookup = Data.Lookup.Common.GetParentMenu();

            return lookup;
        }

        public int InsertMenu(Entity.Lookup.Menu menu)
        {
            return Data.Lookup.Lookup.InsertMenu(menu);
        }

        public System.Data.DataSet GetMenu()
        {
            return Data.Lookup.Lookup.GetMenu();
        }

        public string DeleteMenu(System.Guid MenuId)
        {
            return Data.Lookup.Lookup.DeleteMenu(MenuId);
        }
    }
}
