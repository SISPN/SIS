using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.Entity.Generic;

namespace SIS.Entity.Menu
{

    public class MenuRole : CommonInfo
	{
		#region Properties
		/// <summary>
		/// Gets or sets the MenuRoleId value.
		/// </summary>
		public Guid MenuRoleId { get; set; }

		/// <summary>
		/// Gets or sets the MenuId value.
		/// </summary>
		public Guid MenuId { get; set; }

		/// <summary>
		/// Gets or sets the RoleId value.
		/// </summary>
		public Guid RoleId { get; set; }

		#endregion

	}
}