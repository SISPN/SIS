using System;
using System.Data;

namespace SIS.Entity.PersonalInfo
{
	#region Comments
	/// <summary>
	/// AnkutSevaDetails Class.
	/// </summary>
	/// <remarks>
	/// <h3>Changes</h3>
	/// <list type="table">
	/// 	<listheader>
	/// 		<th>Author</th>
	/// 		<th>Date</th>
	/// 		<th>Details</th>
	/// 	</listheader>
	/// 	<item>
	/// 		<term>PARTH A TRIVEDI</term>
	/// 		<description>01-08-2014</description>
	/// 		<description>Created</description>
	/// 	</item>
	/// </list>
	/// </remarks>
	#endregion

	[Serializable]
	public class AnkutSevaDetails
	{
		
		#region Properties
		/// <summary>
		/// Gets or sets the AnkutSankalpID value.
		/// </summary>
		public Guid AnkutSankalpID { get; set; }

		/// <summary>
		/// Gets or sets the PersonalID value.
		/// </summary>
		public String PersonalID { get; set; }


        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public string Category { get; set; }


        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public string ParentPersonId { get; set; }

		/// <summary>
		/// Gets or sets the Year value.
		/// </summary>
		public Decimal Year { get; set; }

		/// <summary>
		/// Gets or sets the CreatedDate value.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public Guid CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the UpdateDate value.
		/// </summary>
		public DateTime UpdateDate { get; set; }

		/// <summary>
		/// Gets or sets the UpdatedBy value.
		/// </summary>
		public Guid UpdatedBy { get; set; }

		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public Boolean IsDeleted { get; set; }
		#endregion


        public int Sankalap { get; set; }

        public string AnkutGroup { get; set; }

        public int AnkutKaryakar { get; set; }

        public int AnkutSevak { get; set; }
    }

    public class AnkutPersonDetails
    {
        /// <summary>
        /// Gets or sets the PersonalID value.
        /// </summary>
        public String PersonalID { get; set; }


        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public string FullName { get; set; }


    }
}