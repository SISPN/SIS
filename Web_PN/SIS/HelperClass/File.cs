using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace SIS.HelperClass
{
    /// <summary>
    /// The File class abstracts behavior for uploaded files that are stored in a datastore.
    /// It allows you to save an uploaded file in the datastore and retrieve it again.
    /// </summary>
    [DataObject()]
    public class File
    {

        #region Private Variables

        private Guid id;
        private string tag;
        private string fileUrl;
        private byte[] fileData;
        private string contentType;
        private string originalName;
        private DateTime dateCreated;
        private bool containsFile;

        #endregion

        #region Public Properties

        public string Tag { get; set; }

        /// <summary>
        /// Gets the unique id of the uploaded file.
        /// This ID is used as the file name when files are stored in the file system.
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

        /// <summary>
        /// Gets the virtual URL of the file.
        /// When this property does not contain data, then <see cref="FileData"/> contains
        /// a byte array with the actual file.
        /// </summary>
        public string FileUrl
        {
            get
            {
                return fileUrl;
            }
        }

        /// <summary>
        /// Gets the file data.
        /// When this property does not contain data, then <see cref="FileUrl"/> contains
        /// the virtual path to the file starting from the Uploads folder.
        /// </summary>
        public byte[] FileData
        {
            get
            {
                return fileData;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance contains the actual file data.
        /// When ContainsFile is true, it means the actual file is held in <see cref="FileData"/>.
        /// When ContainsFile is false, then <see cref="FileUrl"/> contains the virtual path
        /// to the file on disk.
        /// </summary>
        public bool ContainsFile
        {
            get
            {
                return containsFile;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a file from the datastore.
        /// </summary>
        /// <param name="fileId">The ID of the file.</param>
        public static File GetItem(Guid fileId)
        {
            File myFile = null;
            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand("sprocFilesSelectSingleItem", mySqlConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter prmId = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
                prmId.Value = fileId;
                myCommand.Parameters.Add(prmId);

                mySqlConnection.Open();
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myFile = new File(myReader);
                    }
                    myReader.Close();
                }
                mySqlConnection.Close();
            }
            return myFile;
        }

        /// <summary>
        /// Saves a file to the database.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        public bool Save()
        {
            return Save(DataStoreType.Database, String.Empty);
        }

        /// <summary>
        /// Saves a file to the file system.
        /// This method also saves the meta data of the file to the database.
        /// </summary>
        /// <param name="filePath">The location and name of the file that is to be saved.</param>
        /// <returns>
        /// Returns true when the file was stored succesfully, or false otherwise.
        /// </returns>
        public bool Save(string filePath)
        {
            return Save(DataStoreType.FileSystem, filePath);
        }

        /// <summary>
        /// Saves a file to the database and optionally to disk.
        /// </summary>
        /// <returns>Returns true when the file was stored succesfully, or false otherwise.</returns>
        private bool Save(DataStoreType dataStoreType, string filePath)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                // Set up the Command object
                SqlCommand myCommand = new SqlCommand("sprocFilesInsertSingleItem", mySqlConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                // Set up the ID parameter
                SqlParameter prmId = new SqlParameter("@id", SqlDbType.UniqueIdentifier);

                prmId.Value = id;
                myCommand.Parameters.Add(prmId);

                // Set up the ID parameter
                SqlParameter prmtag = new SqlParameter("@tag", SqlDbType.VarChar);

                prmtag.Value = tag;
                myCommand.Parameters.Add(prmtag);

                // Set up the FileUrl parameter
                SqlParameter prmFileUrl = new SqlParameter("@fileUrl", SqlDbType.NVarChar, 255);

                // If we need to store the file on disk, save the fileUrl.
                if (dataStoreType == DataStoreType.FileSystem)
                {
                    prmFileUrl.Value = fileUrl;
                }
                else
                {
                    prmFileUrl.Value = DBNull.Value;
                }
                myCommand.Parameters.Add(prmFileUrl);

                // Set up the FileData parameter
                SqlParameter prmFileData = new SqlParameter("@fileData ", SqlDbType.VarBinary);

                // If we need to store the file in the database, 
                // pass in the actual file bytes.
                if (dataStoreType == DataStoreType.Database)
                {
                    prmFileData.Value = fileData;
                    prmFileData.Size = fileData.Length;
                }
                else
                {
                    prmFileData.Value = DBNull.Value;
                }
                myCommand.Parameters.Add(prmFileData);

                // Set up the OriginalName parameter
                SqlParameter prmOriginalName = new SqlParameter("@originalName", SqlDbType.NVarChar, 50);
                prmOriginalName.Value = originalName;
                myCommand.Parameters.Add(prmOriginalName);

                // Set up the ContentType parameter
                SqlParameter prmContentType = new SqlParameter("@contentType", SqlDbType.NVarChar, 50);
                prmContentType.Value = contentType;
                myCommand.Parameters.Add(prmContentType);

                // Execute the command, and clean up.
                mySqlConnection.Open();
                bool result = myCommand.ExecuteNonQuery() > 0;
                mySqlConnection.Close();

                // Database update is done; now store the file on disk if we need to.
                if (dataStoreType == DataStoreType.FileSystem)
                {
                    const int myBufferSize = 1024;
                    Stream myInputStream = new MemoryStream(fileData);
                    Stream myOutputStream = System.IO.File.OpenWrite(filePath);

                    byte[] buffer = new Byte[myBufferSize];
                    int numbytes;
                    while ((numbytes = myInputStream.Read(buffer, 0, myBufferSize)) > 0)
                    {
                        myOutputStream.Write(buffer, 0, numbytes);
                    }
                    myInputStream.Close();
                    myOutputStream.Close();
                }

                return result;
            }
        }
        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class with the data from the SqlDataReader.
        /// </summary>
        /// <param name="myReader">A SqlDataReader that contains the data for this file.</param>
        public File(SqlDataReader myReader)
        {
            id = myReader.GetGuid(myReader.GetOrdinal("Id"));
            tag = myReader.GetString(myReader.GetOrdinal("Tag"));
            dateCreated = myReader.GetDateTime(myReader.GetOrdinal("DateCreated"));
            originalName = myReader.GetString(myReader.GetOrdinal("OriginalName"));
            contentType = myReader.GetString(myReader.GetOrdinal("ContentType"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("FileData")))
            {
                fileData = (byte[])myReader[myReader.GetOrdinal("FileData")];
                containsFile = true;
            }
            else
            {
                fileUrl = myReader.GetString(myReader.GetOrdinal("FileUrl"));
                containsFile = false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the File class with the data from the incoming parameters.
        /// </summary>
        /// <param name="contentType">The content type of the file, like image/pjpeg or image/gif.</param>
        /// <param name="originalName">The original name of the uploaded file.</param>
        /// <param name="fileData">A byte array with the actual file data.</param>
        public File(string tags, string contentType, string originalName, byte[] fileData)
        {
            this.id = Guid.NewGuid();
            this.tag = tags;
            this.contentType = contentType;
            this.fileData = fileData;
            this.originalName = originalName;

            string extension = Path.GetExtension(originalName);
            string fileName = this.Id.ToString() + extension;
            this.fileUrl = fileName;
        }

        #endregion


    }
}