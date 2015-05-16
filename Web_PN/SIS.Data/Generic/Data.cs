using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIS.Data.Generic
{
    public class Data
    {
        public static Database db;

        private Data()
        {
        }

        public static Database DBInstance
        {
            get
            {
                if (db == null)
                    db = DatabaseFactory.CreateDatabase();
                return db;
            }
        }
        
    }
}
