using SIS.Entity.Generic;
using System;

namespace SIS.Entity.Xetra
{
    public class MandalInfo : CommonInfo
    {       
        #region Properties

        /// <summary>
        /// Gets or sets the MandalId value.
        /// </summary>
        public Int32 MandalId { get; set; }

        /// <summary>
        /// Gets or sets the XetraId value.
        /// </summary>
        public Int32 XetraId { get; set; }

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the Code value.
        /// </summary>
        public String Code { get; set; }
                
        #endregion
    }
}
