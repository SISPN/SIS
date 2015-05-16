using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace SIS.Utility
{
    public class Helper
    {

    

        public static void WriteToLogFile(string logMessage, string strLogFile)
        {           
            string strLogMessage = string.Format("{0}\t{1}", DateTime.Now, logMessage);
            try
            {
                File.AppendAllText(strLogFile, strLogMessage + "\r\n");                
            }
            catch 
            { 
            
            }
        }

        public static bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
