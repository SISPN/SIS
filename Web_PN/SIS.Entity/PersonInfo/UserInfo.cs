using System;
using System.Collections.Generic;

namespace SIS.Entity.PersonalInfo
{

    public class UserInfo
    {
        public string UserId { get; set; }
        public string Role { get; set; }
        public List<string> MadalOwnCodes { get; set; }
        public string Designation { get; set; }

        public string[]  MandalOwn { get; set; }

        public string Gender { get; set; }
    }
}