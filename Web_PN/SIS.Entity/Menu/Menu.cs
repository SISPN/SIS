using System;
using SIS.Entity.Generic;

namespace SIS.Entity.Menu
{

    public class Menu : CommonInfo
	{
		#region Properties
		/// <summary>
		/// Gets or sets the MenuId value.
		/// </summary>
		public Guid MenuId { get; set; }

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the Url value.
		/// </summary>
		public String Url { get; set; }

		/// <summary>
		/// Gets or sets the ParentMenuId value.
		/// </summary>
		public Guid ParentMenuId { get; set; }

		
		#endregion
	}
}