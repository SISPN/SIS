using System;
using SIS.Entity.Generic;

namespace SIS.Entity.Xetra
{
    public class XetraInfo : CommonInfo
    {      
        #region Properties
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
       
        /// <summary>
        /// Gets or sets the MapValue value.
        /// </summary>
        public String MapValue { get; set; }
        #endregion
    }
}
