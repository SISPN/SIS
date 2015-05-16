using System;
using System.Data;

namespace SIS.Entity.GeographyDDMenu
{
	#region Comments
	/// <summary>
	/// StateDetail Class.
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
	/// 		<term>SIS</term>
	/// 		<description>8/11/2011</description>
	/// 		<description>Created</description>
	/// 	</item>
	/// </list>
	/// </remarks>
	#endregion

	[Serializable]
	public class StateDetail
	{
		#region Construction
		/// <summary>
		/// Initializes a new (no-args) instance of the StateDetail class.
		/// </summary>
		public StateDetail()
		{
		}

		/// <summary>
		/// Initializes a new instance of the StateDetail class.
		/// </summary>
		public StateDetail(Guid StateId,Guid CountryId, String Name, String Code, Guid CreatedBy, DateTime CreatedDate, Guid UpdatedBy, DateTime UpdatedDate, Boolean IsDeleted, String MapValue)
		{
			this.StateId = StateId;
            this.CountryId = CountryId;
			this.Name = Name;
			this.Code = Code;
			this.CreatedBy = CreatedBy;
			this.CreatedDate = CreatedDate;
			this.UpdatedBy = UpdatedBy;
			this.UpdatedDate = UpdatedDate;
			this.IsDeleted = IsDeleted;
			this.MapValue = MapValue;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the StateId value.
		/// </summary>
        public Guid StateId { get; set; }

        /// <summary>
        /// Gets or sets the CountryId value.
        /// </summary>
        public Guid CountryId { get; set; }

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the Code value.
		/// </summary>
		public String Code { get; set; }

		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public Guid CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the CreatedDate value.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// Gets or sets the UpdatedBy value.
		/// </summary>
		public Guid UpdatedBy { get; set; }

		/// <summary>
		/// Gets or sets the UpdatedDate value.
		/// </summary>
		public DateTime UpdatedDate { get; set; }

		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public Boolean IsDeleted { get; set; }

		/// <summary>
		/// Gets or sets the MapValue value.
		/// </summary>
		public String MapValue { get; set; }
		#endregion

		
	}
}