using System;
using System.Data;

namespace SIS.Entity.PersonalInfo
{
	#region Comments
	/// <summary>
	/// SatsangInfo Class.
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
	/// 		<description>11-02-2012</description>
	/// 		<description>Created</description>
	/// 	</item>
	/// </list>
	/// </remarks>
	#endregion

	[Serializable]
	public class SatsangInfo
	{
		#region Construction
		/// <summary>
		/// Initializes a new (no-args) instance of the SatsangInfo class.
		/// </summary>
		public SatsangInfo()
		{
		}

	
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the SId value.
		/// </summary>
		public Guid SId { get; set; }

		/// <summary>
		/// Gets or sets the PId value.
		/// </summary>
		public Guid PId { get; set; }

		/// <summary>
		/// Gets or sets the SatsangCategory value.
		/// </summary>
		public String SatsangCategory { get; set; }

		/// <summary>
		/// Gets or sets the Pooja value.
		/// </summary>
		public string Pooja { get; set; }

		/// <summary>
		/// Gets or sets the Sabha value.
		/// </summary>
		public string Sabha { get; set; }

        /// <summary>
        /// Gets or sets the ParaSabha value.
        /// </summary>
        public Boolean ParaSabha { get; set; }

		/// <summary>
		/// Gets or sets the Prakash value.
		/// </summary>
        public DateTime? Prakash { get; set; }

        /// <summary>
        /// Gets or sets the Prakash value.
        /// </summary>
        public DateTime? Premvati { get; set; }

        /// <summary>
        /// Gets or sets the Prakash value.
        /// </summary>
        public DateTime? Bliss { get; set; }

        /// <summary>
        /// Gets or sets the Prakash value.
        /// </summary>
        public DateTime? BalPrakash { get; set; }

		/// <summary>
		/// Gets or sets the Gharsabha value.
		/// </summary>
		public Boolean Gharsabha { get; set; }

		/// <summary>
		/// Gets or sets the TilakChandalo value.
		/// </summary>
		public Boolean TilakChandalo { get; set; }

		/// <summary>
		/// Gets or sets the SatasangExam value.
		/// </summary>
		public String SatasangExam { get; set; }

		/// <summary>
		/// Gets or sets the GharMandir value.
		/// </summary>
		public Boolean GharMandir { get; set; }

		/// <summary>
		/// Gets or sets the SatasangActivity value.
		/// </summary>
		public String SatasangActivity { get; set; }

		/// <summary>
		/// Gets or sets the DoSatasangActivity value.
		/// </summary>
		public Boolean DoSatasangActivity { get; set; }

		/// <summary>
		/// Gets or sets the Saint1 value.
		/// </summary>
		public String Saint1 { get; set; }

		/// <summary>
		/// Gets or sets the Saint2 value.
		/// </summary>
		public String Saint2 { get; set; }

		/// <summary>
		/// Gets or sets the CreatedDate value.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// Gets or sets the UpdateDate value.
		/// </summary>
		public DateTime UpdateDate { get; set; }

		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public Guid CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the UpdatedBy value.
		/// </summary>
		public Guid UpdatedBy { get; set; }
		#endregion



        public bool SatasangExamShield { get; set; }

        public string SatsangFrom { get; set; }

        public bool Chesta { get; set; }

        public string MandirDarshan { get; set; }

        public string Belivein { get; set; }

        public bool OSFood { get; set; }

        public bool TVFilm { get; set; }

        public string SPCONo { get; set; }
    }
}