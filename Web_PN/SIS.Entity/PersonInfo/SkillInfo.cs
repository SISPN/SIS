using System;
using System.Data;

namespace SIS.Entity.PersonalInfo
{
	#region Comments
	/// <summary>
	/// SkillInfo Class.
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
	public class SkillInfo
	{
		#region Construction
		/// <summary>
		/// Initializes a new (no-args) instance of the SkillInfo class.
		/// </summary>
		public SkillInfo()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SkillInfo class.
		/// </summary>
		public SkillInfo(Guid SFId, Guid PId, Boolean Singing, String Vadan, Boolean Painting, Boolean Construction, Boolean Decoration, Boolean MSOffice, Boolean Dance, Boolean Drama, Boolean Speach, Boolean Tailor, Boolean CarPainter, Boolean Plumbing, Boolean Welding, Boolean Desingning, Boolean Computer, Boolean CarDriving, Boolean Electric, Boolean Sound, Boolean Medical, Boolean Cooking, Boolean Photography, Boolean Housekeeping, Boolean Vedio, Boolean VedioEditing, Boolean PhotoEditing, Boolean GujaratiTyping, Boolean Pasti, Boolean Gardening, Boolean PR, Boolean Account, String OtherSkill, DateTime CreatedDate, Guid CreatedBy, DateTime UpdatedDate, Guid UpdatedBy, Boolean IsDeleted)
		{
			this.SFId = SFId;
			this.PId = PId;
			this.Singing = Singing;
			this.Vadan = Vadan;
			this.Painting = Painting;
			this.Construction = Construction;
			this.Decoration = Decoration;
			this.MSOffice = MSOffice;
			this.Dance = Dance;
			this.Drama = Drama;
			this.Speach = Speach;
			this.Tailor = Tailor;
			this.CarPainter = CarPainter;
			this.Plumbing = Plumbing;
			this.Welding = Welding;
			this.Desingning = Desingning;
			this.Computer = Computer;
			this.CarDriving = CarDriving;
			this.Electric = Electric;
			this.Sound = Sound;
			this.Medical = Medical;
			this.Cooking = Cooking;
			this.Photography = Photography;
			this.Housekeeping = Housekeeping;
			this.Vedio = Vedio;
			this.VedioEditing = VedioEditing;
			this.PhotoEditing = PhotoEditing;
			this.GujaratiTyping = GujaratiTyping;
			this.Pasti = Pasti;
			this.Gardening = Gardening;
			this.PR = PR;
			this.Account = Account;
			this.OtherSkill = OtherSkill;
			this.CreatedDate = CreatedDate;
			this.CreatedBy = CreatedBy;
			this.UpdatedDate = UpdatedDate;
			this.UpdatedBy = UpdatedBy;
			this.IsDeleted = IsDeleted;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the SFId value.
		/// </summary>
		public Guid SFId { get; set; }

		/// <summary>
		/// Gets or sets the PId value.
		/// </summary>
		public Guid PId { get; set; }

		/// <summary>
		/// Gets or sets the Singing value.
		/// </summary>
		public Boolean Singing { get; set; }

		/// <summary>
		/// Gets or sets the Vadan value.
		/// </summary>
		public String Vadan { get; set; }

		/// <summary>
		/// Gets or sets the Painting value.
		/// </summary>
		public Boolean Painting { get; set; }

		/// <summary>
		/// Gets or sets the Construction value.
		/// </summary>
		public Boolean Construction { get; set; }

		/// <summary>
		/// Gets or sets the Decoration value.
		/// </summary>
		public Boolean Decoration { get; set; }

		/// <summary>
		/// Gets or sets the MSOffice value.
		/// </summary>
		public Boolean MSOffice { get; set; }

		/// <summary>
		/// Gets or sets the Dance value.
		/// </summary>
		public Boolean Dance { get; set; }

		/// <summary>
		/// Gets or sets the Drama value.
		/// </summary>
		public Boolean Drama { get; set; }

		/// <summary>
		/// Gets or sets the Speach value.
		/// </summary>
		public Boolean Speach { get; set; }

		/// <summary>
		/// Gets or sets the Tailor value.
		/// </summary>
		public Boolean Tailor { get; set; }

		/// <summary>
		/// Gets or sets the CarPainter value.
		/// </summary>
		public Boolean CarPainter { get; set; }

		/// <summary>
		/// Gets or sets the Plumbing value.
		/// </summary>
		public Boolean Plumbing { get; set; }

		/// <summary>
		/// Gets or sets the Welding value.
		/// </summary>
		public Boolean Welding { get; set; }

		/// <summary>
		/// Gets or sets the Desingning value.
		/// </summary>
		public Boolean Desingning { get; set; }

		/// <summary>
		/// Gets or sets the Computer value.
		/// </summary>
		public Boolean Computer { get; set; }

		/// <summary>
		/// Gets or sets the CarDriving value.
		/// </summary>
		public Boolean CarDriving { get; set; }

		/// <summary>
		/// Gets or sets the Electric value.
		/// </summary>
		public Boolean Electric { get; set; }

		/// <summary>
		/// Gets or sets the Sound value.
		/// </summary>
		public Boolean Sound { get; set; }

		/// <summary>
		/// Gets or sets the Medical value.
		/// </summary>
		public Boolean Medical { get; set; }

		/// <summary>
		/// Gets or sets the Cooking value.
		/// </summary>
		public Boolean Cooking { get; set; }

		/// <summary>
		/// Gets or sets the Photography value.
		/// </summary>
		public Boolean Photography { get; set; }

		/// <summary>
		/// Gets or sets the Housekeeping value.
		/// </summary>
		public Boolean Housekeeping { get; set; }

		/// <summary>
		/// Gets or sets the Vedio value.
		/// </summary>
		public Boolean Vedio { get; set; }

		/// <summary>
		/// Gets or sets the VedioEditing value.
		/// </summary>
		public Boolean VedioEditing { get; set; }

		/// <summary>
		/// Gets or sets the PhotoEditing value.
		/// </summary>
		public Boolean PhotoEditing { get; set; }

		/// <summary>
		/// Gets or sets the GujaratiTyping value.
		/// </summary>
		public Boolean GujaratiTyping { get; set; }

		/// <summary>
		/// Gets or sets the Pasti value.
		/// </summary>
		public Boolean Pasti { get; set; }

		/// <summary>
		/// Gets or sets the Gardening value.
		/// </summary>
		public Boolean Gardening { get; set; }

		/// <summary>
		/// Gets or sets the PR value.
		/// </summary>
		public Boolean PR { get; set; }

		/// <summary>
		/// Gets or sets the Account value.
		/// </summary>
		public Boolean Account { get; set; }

		/// <summary>
		/// Gets or sets the OtherSkill value.
		/// </summary>
		public String OtherSkill { get; set; }

		/// <summary>
		/// Gets or sets the CreatedDate value.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public Guid CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the UpdatedDate value.
		/// </summary>
		public DateTime UpdatedDate { get; set; }

		/// <summary>
		/// Gets or sets the UpdatedBy value.
		/// </summary>
		public Guid UpdatedBy { get; set; }

		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public Boolean IsDeleted { get; set; }
		#endregion


        public bool Architecture { get; set; }
    }
}