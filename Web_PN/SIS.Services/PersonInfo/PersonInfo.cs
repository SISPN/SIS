using System;
using System.Collections.Generic;
using System.Data;
using SIS.Entity;
using SIS.Entity.PersonalInfo;

namespace SIS.Services.PersonInfo
{
    public class PersonInfo
    {
        public static string InsertPersonalInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo, Entity.PersonalInfo.SatsangInfo SatsangInfo,
            Entity.PersonalInfo.SkillInfo SkillInfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertPersonalInfo(PersonalInfo, SatsangInfo, SkillInfo);
        }

        public static string InsertPersonalInfo(DataRow item, Guid UpdatedBy)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertPersonalInfo(item, UpdatedBy);
        }

        public static bool UpdatePersonalInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo, Entity.PersonalInfo.SatsangInfo SatsangInfo,
            Entity.PersonalInfo.SkillInfo SkillInfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.UpdatePersonalInfo(PersonalInfo, SatsangInfo, SkillInfo);
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetContacts( string prefix)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetContacts( prefix);
        }

        public static List<Entity.PersonalInfo.SevaInfo> GetContactDetails(string prefixText)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetContactDetails(prefixText);
        }

        public static string InsertPersonalInfoForFamilymember(Entity.PersonalInfo.PersonalInfo PersonalInfo, Entity.PersonalInfo.SatsangInfo SatsangInfo,
            Entity.PersonalInfo.SkillInfo SkillInfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertPersonalInfoForFamilymember(PersonalInfo, SatsangInfo, SkillInfo);
        }

        public static Entity.PersonalInfo.PersonalInfo GetPersonalInfoForParent(string parentpersonid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetPersonalInfoForParent(parentpersonid);
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetAllMembersDetails(string familyid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetAllMembersDetails(familyid);
        }

        public static DataTable GetUserInfo(Entity.PersonalInfo.PersonalInfo userinfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetUserInfo(userinfo);
        }

        public static DataTable GetPersonInfo(Entity.PersonalInfo.PersonalInfo userinfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetPersonInfo(userinfo);
        }


        public static Entity.PersonalInfo.PersonalInfo GetthisUserPersonalInfo(string thisPid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetthisUserPersonalInfo(thisPid);
        }

        public static Entity.PersonalInfo.SatsangInfo GetthisUserSatsangInfo(string thisPid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetthisUserSatSangInfo(thisPid);
        }

        public static Entity.PersonalInfo.SkillInfo GetthisUserSkillInfo(string thisPid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetthisUserSkillInfo(thisPid);
        }

        public static Entity.PersonalInfo.AnkutSevaDetails GetthisUserAnkutSevaInfo(string thisPid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetthisUserAnkutSevaInfo(thisPid);
        }

        public static string InsertAttandanceInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertAttandanceInfo(PersonalInfo);

        }

        public static string InsertAttandanceandContectInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertAttandanceandContectInfo(PersonalInfo);

        }

        public static List<SIS.Entity.Lookup.Lookup> GetKaryakarInfo()
        {
            return SIS.Data.PersonInfo.PersonInfo.GetKaryakarInfo();
        }

        public static string InsertVolunterInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertVolunterInfo(objvolnterinfo);
        }

        public static string InsertSevakInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo,SIS.Entity.PersonalInfo.SkillInfo skillinfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertSevakInfo(objvolnterinfo, skillinfo);
        }

        public static string InsertAnkkutInfo(Entity.PersonalInfo.SevaInfo SevaInfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertAnkkutInfo(SevaInfo);
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetPersonId(string Mobile, string ResidentPhone)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetPersonId(Mobile, ResidentPhone);
        }

        public static string InsertSevaInfo(Entity.PersonalInfo.SevaInfo Sevainfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertSevaInfo(Sevainfo);
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetPerson(string name)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetPerson(name);
        }

        public static List<Entity.PersonalInfo.AnkutPersonDetails> GetGroupDetails(string category)
        {
            DataSet ankut = GetAnkutList();
            DataRow[] dr = ankut.Tables[0].Select("Category = '" + category + "'");
            List<Entity.PersonalInfo.AnkutPersonDetails> lstankut = new List<Entity.PersonalInfo.AnkutPersonDetails>();

            Entity.PersonalInfo.AnkutPersonDetails ankpersontemp = new Entity.PersonalInfo.AnkutPersonDetails();
            ankpersontemp.FullName = "---Select---";
            ankpersontemp.PersonalID = "-1";
            lstankut.Insert(0, ankpersontemp);

            foreach (DataRow item in dr)
            {
                Entity.PersonalInfo.AnkutPersonDetails ankperson = new Entity.PersonalInfo.AnkutPersonDetails();
                string personid = Convert.ToString(item["PersonId"]);
                SIS.Entity.PersonalInfo.PersonalInfo lstperson = SIS.Services.PersonInfo.PersonInfo.GetthisUserPersonalInfo(personid);
                ankperson.FullName = lstperson.FullName;
                ankperson.PersonalID = lstperson.PersonId;
                lstankut.Add(ankperson);
            }

            return lstankut;
        }

        public static DataSet GetAnkutList()
        {

            DataSet ankutList = Data.PersonInfo.PersonInfo.GetAnkutList();

            return ankutList;
        }

        public static List<Entity.PersonalInfo.AnkutPersonDetails> GetAKDetails(string category, string pid)
        {
            DataSet ankut = GetAnkutList();
            DataRow[] dr = ankut.Tables[0].Select("Category = '" + category + "' AND ParentPersonId = '" + pid + "'");
            List<Entity.PersonalInfo.AnkutPersonDetails> lstankut = new List<Entity.PersonalInfo.AnkutPersonDetails>();

            Entity.PersonalInfo.AnkutPersonDetails ankpersontemp = new Entity.PersonalInfo.AnkutPersonDetails();
            ankpersontemp.FullName = "---Select---";
            ankpersontemp.PersonalID = "-1";
            lstankut.Insert(0, ankpersontemp);

            foreach (DataRow item in dr)
            {
                Entity.PersonalInfo.AnkutPersonDetails ankperson = new Entity.PersonalInfo.AnkutPersonDetails();
                string personid = Convert.ToString(item["PersonId"]);
                SIS.Entity.PersonalInfo.PersonalInfo lstperson = SIS.Services.PersonInfo.PersonInfo.GetthisUserPersonalInfo(personid);
                ankperson.FullName = lstperson.FullName;
                ankperson.PersonalID = lstperson.PersonId;
                lstankut.Add(ankperson);
            }

            return lstankut;
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetSevaBringPerson(string did)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetSevaBringPerson(did);
        }

        public static DataTable GetAnkutInfo(Entity.PersonalInfo.PersonalInfo userinfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetAnkutInfo(userinfo);
        }

        public static string DeleteAnkutDetails(int id)
        {
            return SIS.Data.PersonInfo.PersonInfo.DeleteAnkutDetails(id);
        }

        public static Entity.PersonalInfo.SevaInfo GetAnkutInfo(string thisPid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetAnkutInfo(thisPid);
        }

        public static string UpdateAnkkutInfo(Entity.PersonalInfo.SevaInfo Sevainfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.UpdateAnkkutInfo(Sevainfo);
        }

        public static Entity.PersonalInfo.PersonalInfo GetthisUserPersonalInfoForSeva(string thisPid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetthisUserPersonalInfo1(thisPid);
        }

        public static Entity.PersonalInfo.SevaInfo GetthisUserInfoForSeva(string thisPid)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetthisUserInfoForSeva(thisPid);
        }

        public static DataTable GetLableInfo(string Xetra, string Mandal)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetLableInfo(Xetra, Mandal);
        }

        public static DataSet GetSevaInfo()
        {
            return SIS.Data.PersonInfo.PersonInfo.GetSevaInfo();
        }

        public static string InsertContactInfo(Entity.PersonalInfo.SevaInfo Sevainfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.InsertContactInfo(Sevainfo);
        }

        public static DataSet GetContactInfo()
        {
            return SIS.Data.PersonInfo.PersonInfo.GetContactInfo();
        }




        public static List<string> GetSMSOtherContactGroupDetails(string othercontacts)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetSMSOtherContactGroupDetails(othercontacts);
        }


        public static List<string> GetSMSOtherGroupDetails(string othercategory)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetSMSOtherGroupDetails(othercategory);
        }

        public static List<string> GetSMSGroupDetails(string groups, string MandalId, string XetraId)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetSMSGroupDetails(groups, MandalId, XetraId);
        }

        public static DataTable GetVolInfo()
        {
            return SIS.Data.PersonInfo.PersonInfo.GetVolInfo();
        }

        public static string DeleteVolInfo(Guid VoluntierId)
        {
            return SIS.Data.PersonInfo.PersonInfo.DeleteVolInfo(VoluntierId);
        }

        public static string UpdateVolInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.UpdateVolInfo(objvolnterinfo);
        }



        public static UserInfo GetVolunterInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo)
        {
            return SIS.Data.PersonInfo.PersonInfo.GetVolunterInfo(objvolnterinfo);
        }

       
    }

}
