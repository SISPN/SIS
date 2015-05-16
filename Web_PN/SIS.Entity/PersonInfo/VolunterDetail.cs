using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Entity.PersonInfo
{
    public class VolunterDetail
    {
        public Guid VoluntierId { get; set; }

        public string Name { get; set; }

        public string FamilyId { get; set; }

        public string PersonId { get; set; }

        public string Designation { get; set; }

        public string MandalOwn { get; set; }        
    
        public Guid CreatedBy { get; set; }

        public string Mobile { get; set; }

        public int Age { get; set; }

        public DateTime? ToDate { get; set; }

        public DateTime? FromDate { get; set; }

        public string Note { get; set; }

        public string Skill { get; set; }

        public Guid SevakId { get; set; }

        public string Gender { get; set; }

        public string UserId { get; set; }
    }
}
