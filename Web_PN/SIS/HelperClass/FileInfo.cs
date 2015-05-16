using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
namespace SIS.HelperClass
{
    /// <summary>
    /// The FileInfo class contains summary information about uploaded files.
    /// </summary>
    [DataObject()]
    public class FileInfo
    {
        #region Private Variables

        private Guid id;
        private string contentType;
        private string originalName;
        private DateTime dateCreated;
        #endregion

        #region Public Properties

        public string Tag { get; set; }
        /// <summary>
        /// Gets the unique id of the uploaded file.
        /// </summary>
        public Guid Id
        {
            get
            {
                return id;
            }
        }


        /// <summary>
        /// Gets the date and time the file was uploaded.
        /// </summary>
        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
        }

        /// <summary>
        /// Gets the content type of the file.
        /// </summary>
        public string ContentType
        {
            get
            {
                return contentType;
            }
        }

        /// <summary>
        /// Gets the original name of the file.
        /// </summary>
        public string OriginalName
        {
            get
            {
                return originalName;
            }
        }
        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="FileInfo"/> class with the data from the SqlDataReader.
        /// </summary>
        public FileInfo(SqlDataReader myReader)
        {
            id = myReader.GetGuid(myReader.GetOrdinal("Id"));
            Tag = myReader.GetString(myReader.GetOrdinal("Tag"));
            dateCreated = myReader.GetDateTime(myReader.GetOrdinal("DateCreated"));
            originalName = myReader.GetString(myReader.GetOrdinal("OriginalName"));
            contentType = myReader.GetString(myReader.GetOrdinal("ContentType"));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a list with <see cref="FileInfo"/> objects.
        /// </summary>
        /// <returns>A list with <see cref="FileInfo"/> objects when the database contains any files, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<FileInfo> GetList()
        {
            List<FileInfo> myList = null;

            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand("sprocFileInfoSelectList", mySqlConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                mySqlConnection.Open();

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<FileInfo>();
                        while (myReader.Read())
                        {
                            myList.Add(new FileInfo(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }


        /// <summary>
        /// Gets a list with <see cref="FileInfo"/> objects.
        /// </summary>
        /// <returns>A list with <see cref="FileInfo"/> objects when the database contains any files, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static int DeleteFileInfo(Guid Id)
        {
            int res = 0;
            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand("sprocFileInfoDelete", mySqlConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                // Set up the ID parameter
                SqlParameter prmId = new SqlParameter("@id", SqlDbType.UniqueIdentifier);

                prmId.Value = Id;
                myCommand.Parameters.Add(prmId);

                mySqlConnection.Open();

                res = myCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
            return res;
        }
        #endregion


    }
}