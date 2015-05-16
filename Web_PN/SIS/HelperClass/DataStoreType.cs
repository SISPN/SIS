namespace SIS.HelperClass
{
    /// <summary>
    /// The DataStoreType enumeration determines the type of 
    /// data store to use for storing uploaded files.
    /// </summary>
    public enum DataStoreType
    {
        /// <summary>
        /// Indicates that files should be stored in the database.
        /// </summary>
        Database = 0,
        /// <summary>
        /// Indicates that files should be stored in the file system.
        /// </summary>
        FileSystem = 1
    }
}