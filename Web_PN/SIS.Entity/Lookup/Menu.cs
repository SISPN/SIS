using SIS.Entity.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Entity.Lookup
{

    public class Menu : CommonInfo
    {
        #region Properties
        /// <summary>
        /// Gets or sets the LookupDetailId value.
        /// </summary>

        public Guid MenuId { get; set; }

        /// <summary>
        /// Gets or sets the LookupMasterId value.
        /// </summary>

        public Guid? ParentMenuId { get; set; }

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>

        public string Url { get; set; }

        public List<string> Roles{ get; set; }

        #endregion
    }

}
