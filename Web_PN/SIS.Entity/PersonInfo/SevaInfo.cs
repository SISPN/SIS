
using System;
namespace SIS.Entity.PersonalInfo
{
    public class SevaInfo
    {
        #region Construction
		/// <summary>
		/// Initializes a new (no-args) instance of the AnkutDetail class.
		/// </summary>
		public SevaInfo()
		{
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the AUId value.
		/// </summary>
		public  Guid AUId { get; set; }

		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public  Int32 ID { get; set; }

		/// <summary>
		/// Gets or sets the FName value.
		/// </summary>
		public  String FName { get; set; }

		/// <summary>
		/// Gets or sets the MName value.
		/// </summary>
		public  String MName { get; set; }

		/// <summary>
		/// Gets or sets the LName value.
		/// </summary>
		public  String LName { get; set; }

		/// <summary>
		/// Gets or sets the Address value.
		/// </summary>
		public  String Address { get; set; }

		/// <summary>
		/// Gets or sets the Country value.
		/// </summary>
		public  Guid Country { get; set; }

		/// <summary>
		/// Gets or sets the State value.
		/// </summary>
		public  Guid State { get; set; }

		/// <summary>
		/// Gets or sets the District value.
		/// </summary>
		public  Guid District { get; set; }

		/// <summary>
		/// Gets or sets the Taluko value.
		/// </summary>
		public  Guid Taluko { get; set; }

		/// <summary>
		/// Gets or sets the Area value.
		/// </summary>
		public  String Area { get; set; }

		/// <summary>
		/// Gets or sets the Pin value.
		/// </summary>
		public  String Pin { get; set; }

		/// <summary>
		/// Gets or sets the Mobile value.
		/// </summary>
		public  String Mobile { get; set; }

		/// <summary>
		/// Gets or sets the Resident value.
		/// </summary>
		public  String Resident { get; set; }

		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public  String Email { get; set; }

		/// <summary>
		/// Gets or sets the AltEmail value.
		/// </summary>
		public  String AltEmail { get; set; }

		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public  Decimal Amount { get; set; }

		/// <summary>
		/// Gets or sets the BringFName value.
		/// </summary>
		public  String BringFName { get; set; }

		/// <summary>
		/// Gets or sets the BringMName value.
		/// </summary>
		public  String BringMName { get; set; }

		/// <summary>
		/// Gets or sets the BringLName value.
		/// </summary>
		public  String BringLName { get; set; }

		/// <summary>
		/// Gets or sets the SevaBringResident value.
		/// </summary>
		public  String SevaBringResident { get; set; }

		/// <summary>
		/// Gets or sets the SevaBringMobile value.
		/// </summary>
		public  String SevaBringMobile { get; set; }

		/// <summary>
		/// Gets or sets the BringArea value.
		/// </summary>
		public  String BringArea { get; set; }

		/// <summary>
		/// Gets or sets the SevaBringEmail value.
		/// </summary>
		public  String SevaBringEmail { get; set; }

		/// <summary>
		/// Gets or sets the SevaBringAltEmail value.
		/// </summary>
		public  String SevaBringAltEmail { get; set; }

		/// <summary>
		/// Gets or sets the PersonId value.
		/// </summary>
		public  String PersonId { get; set; }

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

        public string Mandal { get; set; }

        public string PANNo { get; set; }

        public string Festival { get; set; }

        public string Xetra { get; set; }

        public string RecieptNo { get; set; }

        public string BookNo { get; set; }

        public bool IsSantPadhramni { get; set; }

        public string PersonMandal { get; set; }

        public string PersonXetra { get; set; }

        public string DId { get; set; }

        public DateTime? SantPadharamaniDate { get; set; }

        public Int32 AnkutYear { get; set; }

        public int IsActive { get; set; }

        public string Category { get; set; }
        public int ProbableSeva { get; set; }

        public int FemaleYajman { get; set; }

        public int MaleYajman { get; set; }

        public string SevaBringPersonId { get; set; }

        public string Gender { get; set; }

        public string SevaBringName { get; set; }

        public Guid ContactId { get; set; }

        public string PostCategory { get; set; }
    }
}
