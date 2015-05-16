using System;
using System.Configuration;

namespace SIS.HelperClass
{
    /// <summary>
    /// The AppConfiguration contains static read-only properties that map to settings in the web.config file.
    /// </summary>
    public static class AppConfiguration
    {
        /// <summary>
        /// Gets the type of data store to use. Valid options come from the <see cref="DataStoreType"/> 
        /// enumeration and currently include Database and FileSystem.
        /// </summary>
        /// <value>The type of the data store.</value>
        public static DataStoreType DataStoreType
        {
            get
            {
                return (DataStoreType)Enum.Parse(typeof(DataStoreType), ConfigurationManager.AppSettings.Get("DataStoreType"), true);
            }
        }

        /// <summary>
        /// Gets the virtual path to the Uploads folder.
        /// </summary>
        public static string UploadsFolder
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("UploadsFolder");
            }
        }

        /// <summary>
        /// Gets the connection string for the application.
        /// </summary>
        /// <value>The connection string.</value>
        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            }
        }
    }
}