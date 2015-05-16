using System;

namespace SIS.Entity.PersonalInfo
{
	#region Comments
	/// <summary>
	/// PersonalInfo Class.
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
	public class PersonalInfo
	{
		#region Construction
		/// <summary>
		/// Initializes a new (no-args) instance of the PersonalInfo class.
		/// </summary>
		public PersonalInfo()
		{
		}

	
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the PId value.
		/// </summary>
		public Guid PId { get; set; }

		/// <summary>
		/// Gets or sets the Grade value.
		/// </summary>
		public String Grade { get; set; }

		/// <summary>
		/// Gets or sets the PersonId value.
		/// </summary>
		public String PersonId { get; set; }

        /// <summary>
        /// Gets or sets the PersonId value.
        /// </summary>
        public String ParentPersonId { get; set; }

		/// <summary>
		/// Gets or sets the FamilyId value.
		/// </summary>
		public String FamilyId { get; set; }

		/// <summary>
		/// Gets or sets the IsMainPerson value.
		/// </summary>
		public Boolean IsMainPerson { get; set; }

		/// <summary>
		/// Gets or sets the PersonStausFlag value.
		/// </summary>
		public String PersonStausFlag { get; set; }

		/// <summary>
		/// Gets or sets the CurrentStatus value.
		/// </summary>
		public String CurrentStatus { get; set; }

		/// <summary>
		/// Gets or sets the FirstName value.
		/// </summary>
		public String FirstName { get; set; }

		/// <summary>
		/// Gets or sets the LastName value.
		/// </summary>
		public String LastName { get; set; }

		/// <summary>
		/// Gets or sets the MiddleName value.
		/// </summary>
		public String MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the FullName value.
        /// </summary>
        public String FullName { get; set; }

		/// <summary>
		/// Gets or sets the NickName value.
		/// </summary>
		public String NickName { get; set; }

		/// <summary>
		/// Gets or sets the Gender value.
		/// </summary>
		public String Gender { get; set; }

		/// <summary>
		/// Gets or sets the DOB value.
		/// </summary>
        public DateTime? DOB  { get; set; }

		/// <summary>
		/// Gets or sets the Xetra value.
		/// </summary>
		public String Xetra { get; set; }

		/// <summary>
		/// Gets or sets the Mandal value.
		/// </summary>
		public String Mandal { get; set; }

		/// <summary>
		/// Gets or sets the PAddress value.
		/// </summary>
		public String PAddress { get; set; }

		/// <summary>
		/// Gets or sets the PCountry value.
		/// </summary>
		public Guid PCountry { get; set; }

		/// <summary>
		/// Gets or sets the PState value.
		/// </summary>
		public Guid PState { get; set; }

		/// <summary>
		/// Gets or sets the PDistrict value.
		/// </summary>
		public Guid PDistrict { get; set; }

		/// <summary>
		/// Gets or sets the PTaluko value.
		/// </summary>
		public Guid PTaluko { get; set; }

		/// <summary>
		/// Gets or sets the PVillage value.
		/// </summary>
		public String PVillage { get; set; }

		/// <summary>
		/// Gets or sets the PPin value.
		/// </summary>
		public String PPin { get; set; }

		/// <summary>
		/// Gets or sets the NativePlace value.
		/// </summary>
		public String NativePlace { get; set; }

		/// <summary>
		/// Gets or sets the CAddress value.
		/// </summary>
		public String CAddress { get; set; }

		/// <summary>
		/// Gets or sets the CCountry value.
		/// </summary>
		public Guid CCountry { get; set; }

		/// <summary>
		/// Gets or sets the CState value.
		/// </summary>
		public Guid CState { get; set; }

		/// <summary>
		/// Gets or sets the CDistrict value.
		/// </summary>
		public Guid CDistrict { get; set; }

		/// <summary>
		/// Gets or sets the CTauko value.
		/// </summary>
		public Guid CTauko { get; set; }

		/// <summary>
		/// Gets or sets the CVillage value.
		/// </summary>
		public String CVillage { get; set; }

		/// <summary>
		/// Gets or sets the CPin value.
		/// </summary>
		public String CPin { get; set; }

		/// <summary>
		/// Gets or sets the HomePhone value.
		/// </summary>
		public String HomePhone { get; set; }

		/// <summary>
		/// Gets or sets the PTelephone value.
		/// </summary>
		public String PTelephone { get; set; }

		/// <summary>
		/// Gets or sets the MobilePhone value.
		/// </summary>
		public String MobilePhone { get; set; }

		/// <summary>
		/// Gets or sets the JobPhone value.
		/// </summary>
		public String JobPhone { get; set; }

		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public String Email { get; set; }

		/// <summary>
		/// Gets or sets the AltEmail value.
		/// </summary>
		public String AltEmail { get; set; }

		/// <summary>
		/// Gets or sets the BloodGroup value.
		/// </summary>
		public String BloodGroup { get; set; }

		/// <summary>
		/// Gets or sets the Study value.
		/// </summary>
		public String Study { get; set; }

		/// <summary>
		/// Gets or sets the Job value.
		/// </summary>
		public String Job { get; set; }

		/// <summary>
		/// Gets or sets the Designation value.
		/// </summary>
		public String Designation { get; set; }
        
        /// <summary>
        /// Gets or sets the CompanyName value.
        /// </summary>
        public string CompanyName { get; set; }

		/// <summary>
		/// Gets or sets the JobAddress value.
		/// </summary>
		public String JobAddress { get; set; }

		/// <summary>
		/// Gets or sets the JCountry value.
		/// </summary>
		public Guid JCountry { get; set; }

		/// <summary>
		/// Gets or sets the JDistrict value.
		/// </summary>
		public Guid JDistrict { get; set; }

		/// <summary>
		/// Gets or sets the JState value.
		/// </summary>
		public Guid JState { get; set; }

		/// <summary>
		/// Gets or sets the JTaluko value.
		/// </summary>
		public Guid JTaluko { get; set; }

		/// <summary>
		/// Gets or sets the JVillage value.
		/// </summary>
		public String JVillage { get; set; }

		/// <summary>
		/// Gets or sets the JPin value.
		/// </summary>
		public String JPin { get; set; }

		/// <summary>
		/// Gets or sets the JFax value.
		/// </summary>
		public String JFax { get; set; }

		/// <summary>
		/// Gets or sets the TypeOfService value.
		/// </summary>
		public String TypeOfService { get; set; }

		/// <summary>
		/// Gets or sets the NoOfTwoWlr value.
		/// </summary>
		public Int32 NoOfTwoWlr { get; set; }

		/// <summary>
		/// Gets or sets the NoOfFourWlr value.
		/// </summary>
		public Int32 NoOfFourWlr { get; set; }

		/// <summary>
		/// Gets or sets the IsImported value.
		/// </summary>
		public Boolean IsImported { get; set; }

		/// <summary>
		/// Gets or sets the ImportId value.
		/// </summary>
		public Guid ImportId { get; set; }

		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public String Remarks { get; set; }

		/// <summary>
		/// Gets or sets the UpdateComment value.
		/// </summary>
		public String UpdateComment { get; set; }

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

        public string SabhaLookupId { get; set; }

        public DateTime? SabhaDate { get; set; }

        public int IsActive { get; set; }



        public string Samparkkaryakar { get; set; }

        public string DId { get; set; }

        public string Category { get; set; }

        public string AltEmail2 { get; set; }

        public string HomePhone2 { get; set; }

        public string MobilePhone2 { get; set; }

        public string MobilePhone3 { get; set; }

        public string SatsangCategory { get; set; }

        public int ProbableSeva { get; set; }

        public string SevaBringPersonId { get; set; }

        public string BookNo{ get; set; }
        public string Reciept { get; set; }

        public int Amount { get; set; }

        public int FemaleYajman { get; set; }

        public int MaleYajman { get; set; }

        public string SevaBringName { get; set; }

        public int IsDND { get; set; }
    }
}