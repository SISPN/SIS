using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Utility
{
    public static class Extension
    {
        public static string ConvetToString(this object value)
        {
            if (value == null) return string.Empty;
            if (value == DBNull.Value) return string.Empty;
            return Convert.ToString(value);
        }

        public static int ConvetToInt32(this object value)
        {
            if (value == null) return 0;
            if (value == DBNull.Value) return 0;
            return Convert.ToInt32(value);
        }
    }
}
