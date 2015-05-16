using System;

namespace SIS.Entity.Generic
{
    public class CommonInfo
    {
        /// <summary>
        /// Gets or sets the CreatedDate value.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy value.
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate value.
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedBy value.
        /// </summary>
        public Guid UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted value.
        /// </summary>
        public Boolean IsDeleted { get; set; }
    }
}
