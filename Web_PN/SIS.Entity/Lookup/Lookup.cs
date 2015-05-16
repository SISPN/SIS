using System.Runtime.Serialization;
using SIS.Entity.Generic;

namespace SIS.Entity.Lookup
{

    public class Lookup : CommonInfo
    {
        #region Properties
        /// <summary>
        /// Gets or sets the LookupDetailId value.
        /// </summary>
        
        public int LookupDetailId { get; set; }

        /// <summary>
        /// Gets or sets the LookupMasterId value.
        /// </summary>
        
        public int LookupMasterId { get; set; }

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the DisplayText value.
        /// </summary>
        
        public string DisplayText { get; set; }

        /// <summary>
        /// Gets or sets the Value value.
        /// </summary>
        
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the Related Field Value value.
        /// </summary>

        public string RelatedFieldValue { get; set; }

        /// <summary>
        /// Gets or sets the Sequence value.
        /// </summary>
        
        public int Sequence { get; set; }

        
        #endregion
    }


    public class SMSLookup
    {
        public string ID  { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
    
    }
}
