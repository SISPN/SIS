using System;
using System.Collections.Generic;
using SIS.Utility;
using System.Data;
using System.Configuration;
using SIS.Entity.PersonalInfo;

namespace SIS.Data.PersonInfo
{
    public class PersonInfo
    {

        public static string InsertPersonalInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo, Entity.PersonalInfo.SatsangInfo SatsangInfo,
            Entity.PersonalInfo.SkillInfo SkillInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_Person_Insert", ConfigurationManager.AppSettings["CenterCode"].ToString(), PersonalInfo.Grade,
                PersonalInfo.IsMainPerson, PersonalInfo.IsDND, PersonalInfo.PersonStausFlag, PersonalInfo.IsActive,
                new Guid(Convert.ToString(PersonalInfo.Samparkkaryakar)), PersonalInfo.CurrentStatus,
                PersonalInfo.FirstName, PersonalInfo.LastName, PersonalInfo.MiddleName, PersonalInfo.NickName, PersonalInfo.Gender,
                PersonalInfo.DOB, PersonalInfo.Xetra, PersonalInfo.Mandal,
                PersonalInfo.PAddress, PersonalInfo.PCountry, PersonalInfo.PState, PersonalInfo.PDistrict, PersonalInfo.PTaluko, PersonalInfo.PVillage, PersonalInfo.PPin, PersonalInfo.NativePlace,
                PersonalInfo.CAddress, PersonalInfo.CCountry, PersonalInfo.CState, PersonalInfo.CDistrict, PersonalInfo.CTauko, PersonalInfo.CVillage, PersonalInfo.CPin,
                PersonalInfo.HomePhone, PersonalInfo.PTelephone, PersonalInfo.MobilePhone, PersonalInfo.JobPhone, PersonalInfo.Email, PersonalInfo.AltEmail, PersonalInfo.BloodGroup, PersonalInfo.Study,
                PersonalInfo.Job, PersonalInfo.Designation, PersonalInfo.CompanyName, PersonalInfo.JobAddress, PersonalInfo.JCountry, PersonalInfo.JState, PersonalInfo.JDistrict, PersonalInfo.JTaluko, PersonalInfo.JVillage, PersonalInfo.JPin,
                PersonalInfo.JFax, PersonalInfo.TypeOfService, PersonalInfo.NoOfTwoWlr, PersonalInfo.NoOfFourWlr, PersonalInfo.Remarks,
                SatsangInfo.SatsangCategory, SatsangInfo.Pooja, SatsangInfo.Sabha, SatsangInfo.ParaSabha, SatsangInfo.Prakash, SatsangInfo.Gharsabha, SatsangInfo.TilakChandalo, SatsangInfo.SatasangExam,
                SatsangInfo.GharMandir, SatsangInfo.SatasangActivity, SatsangInfo.DoSatasangActivity, SatsangInfo.Saint1, SatsangInfo.Saint2,
                SkillInfo.Singing, SkillInfo.Vadan, SkillInfo.Painting, SkillInfo.Construction, SkillInfo.Decoration, SkillInfo.MSOffice, SkillInfo.Dance, SkillInfo.Drama, SkillInfo.Speach,
                SkillInfo.Tailor, SkillInfo.CarPainter, SkillInfo.Plumbing, SkillInfo.Welding, SkillInfo.Desingning, SkillInfo.Computer, SkillInfo.CarDriving, SkillInfo.Electric,
                SkillInfo.Sound, SkillInfo.Medical, SkillInfo.Cooking, SkillInfo.Photography, SkillInfo.Housekeeping, SkillInfo.Vedio, SkillInfo.VedioEditing, SkillInfo.PhotoEditing,
                SkillInfo.GujaratiTyping, SkillInfo.Pasti, SkillInfo.Gardening, SkillInfo.PR, SkillInfo.Account, SkillInfo.OtherSkill, PersonalInfo.CreatedBy,
                PersonalInfo.Category, PersonalInfo.DId, PersonalInfo.MobilePhone2, PersonalInfo.MobilePhone3, PersonalInfo.HomePhone2, PersonalInfo.AltEmail2,
                 SatsangInfo.SatsangFrom, SatsangInfo.Chesta, SatsangInfo.MandirDarshan, SatsangInfo.Belivein, SatsangInfo.SatasangExamShield, SatsangInfo.OSFood, SatsangInfo.TVFilm,
                SatsangInfo.Premvati, SatsangInfo.Bliss, SatsangInfo.BalPrakash,SatsangInfo.SPCONo).ConvetToString();
            

        }

        public static string InsertPersonalInfoForFamilymember(Entity.PersonalInfo.PersonalInfo PersonalInfo, Entity.PersonalInfo.SatsangInfo SatsangInfo,
            Entity.PersonalInfo.SkillInfo SkillInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_PersonFamilymember_Insert", ConfigurationManager.AppSettings["CenterCode"].ToString(),
              PersonalInfo.ParentPersonId, PersonalInfo.Grade, PersonalInfo.IsMainPerson, PersonalInfo.PersonStausFlag, PersonalInfo.IsActive,
              new Guid(Convert.ToString(PersonalInfo.Samparkkaryakar)), PersonalInfo.CurrentStatus,
              PersonalInfo.FirstName, PersonalInfo.LastName, PersonalInfo.MiddleName, PersonalInfo.NickName, PersonalInfo.Gender, PersonalInfo.DOB,
              PersonalInfo.Xetra, PersonalInfo.Mandal,
              PersonalInfo.HomePhone, PersonalInfo.PTelephone, PersonalInfo.MobilePhone, PersonalInfo.JobPhone, PersonalInfo.Email, PersonalInfo.AltEmail,
              PersonalInfo.BloodGroup, PersonalInfo.Study,
              PersonalInfo.Job, PersonalInfo.Designation, PersonalInfo.CompanyName, PersonalInfo.JobAddress, PersonalInfo.JCountry, PersonalInfo.JState, PersonalInfo.JDistrict,
              PersonalInfo.JTaluko, PersonalInfo.JVillage, PersonalInfo.JPin,
              PersonalInfo.JFax, PersonalInfo.TypeOfService, PersonalInfo.NoOfTwoWlr, PersonalInfo.NoOfFourWlr, PersonalInfo.Remarks,
              SatsangInfo.SatsangCategory, SatsangInfo.Pooja, SatsangInfo.Sabha, SatsangInfo.ParaSabha, SatsangInfo.Prakash, SatsangInfo.Gharsabha,
              SatsangInfo.TilakChandalo, SatsangInfo.SatasangExam,
              SatsangInfo.GharMandir, SatsangInfo.SatasangActivity, SatsangInfo.DoSatasangActivity, SatsangInfo.Saint1, SatsangInfo.Saint2,
              SkillInfo.Singing, SkillInfo.Vadan, SkillInfo.Painting, SkillInfo.Construction, SkillInfo.Decoration, SkillInfo.MSOffice, SkillInfo.Dance, SkillInfo.Drama,
              SkillInfo.Speach,
              SkillInfo.Tailor, SkillInfo.CarPainter, SkillInfo.Plumbing, SkillInfo.Welding, SkillInfo.Desingning, SkillInfo.Computer, SkillInfo.CarDriving, SkillInfo.Electric,
              SkillInfo.Sound, SkillInfo.Medical, SkillInfo.Cooking, SkillInfo.Photography, SkillInfo.Housekeeping, SkillInfo.Vedio, SkillInfo.VedioEditing,
              SkillInfo.PhotoEditing,
              SkillInfo.GujaratiTyping, SkillInfo.Pasti, SkillInfo.Gardening, SkillInfo.PR, SkillInfo.Account, SkillInfo.OtherSkill, PersonalInfo.CreatedBy,
              PersonalInfo.Category, PersonalInfo.DId, PersonalInfo.MobilePhone2, PersonalInfo.MobilePhone3, PersonalInfo.HomePhone2, PersonalInfo.AltEmail2,
                 SatsangInfo.SatsangFrom, SatsangInfo.Chesta, SatsangInfo.MandirDarshan, SatsangInfo.Belivein, SatsangInfo.SatasangExamShield, SatsangInfo.OSFood,
                 SatsangInfo.TVFilm,
                SatsangInfo.Premvati, SatsangInfo.Bliss, SatsangInfo.BalPrakash, PersonalInfo.IsDND).ConvetToString();

        }

        public static Entity.PersonalInfo.PersonalInfo GetPersonalInfoForParent(string parentpersonid)
        {
            IDataReader dr;
            Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetPersonFamilymember", parentpersonid);

            if (dr.Read())
            {
                PersonalInfo.FullName = Convert.ToString(dr["FullName"]);
                PersonalInfo.PersonId = Convert.ToString(dr["PersonId"]);
                PersonalInfo.FamilyId = Convert.ToString(dr["FamilyId"]);
            }

            return PersonalInfo;
        }

        public static List<Entity.PersonalInfo.SevaInfo> GetContactDetails(string prefixText)
        {
            List<Entity.PersonalInfo.SevaInfo> items = new List<Entity.PersonalInfo.SevaInfo>();
            IDataReader dr;

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetContactInfobyPrefix", prefixText);

            while (dr.Read())
            {
                Entity.PersonalInfo.SevaInfo item = new Entity.PersonalInfo.SevaInfo();

                item.ID = Convert.ToInt32(dr["ID"]);
                item.FName = Convert.ToString(dr["FName"]);
                item.MName = Convert.ToString(dr["MName"]);
                item.LName = Convert.ToString(dr["LName"]);
                item.Mobile = Convert.ToString(dr["Mobile"]);

                items.Add(item);
            }

            return items;
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetContacts(string prefix)
        {
            List<Entity.PersonalInfo.PersonalInfo> items = new List<Entity.PersonalInfo.PersonalInfo>();
            IDataReader dr;

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetPersonalInfobyPrefix", prefix);

            while (dr.Read())
            {
                Entity.PersonalInfo.PersonalInfo item = new Entity.PersonalInfo.PersonalInfo();
                item = PersonalInfoModal(dr);
                items.Add(item);
            }

            return items;
        }


        public static List<string> GetSMSOtherContactGroupDetails(string othercontacts)
        {
            IDataReader dr;

            List<string> lstPersonalInfo = new List<string>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetSMSOtherContactGroupDetails", othercontacts);

            while (dr.Read())
            {


                //PersonalInfo.ID = Convert.ToString(dr["ID"]);
                //PersonalInfo.Name = Convert.ToString(dr["Name"]);

                lstPersonalInfo.Add(Convert.ToString(dr["MobilePhone"]));
            }

            return lstPersonalInfo;
        }

        public static List<string> GetSMSOtherGroupDetails(string othercategory)
        {
            IDataReader dr;

            List<string> lstPersonalInfo = new List<string>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetSMSOtherGroupsDetail", othercategory);

            while (dr.Read())
            {


                //PersonalInfo.ID = Convert.ToString(dr["ID"]);
                //PersonalInfo.Name = Convert.ToString(dr["Name"]);

                lstPersonalInfo.Add(Convert.ToString(dr["MobilePhone"]));
            }

            return lstPersonalInfo;
        }
        public static List<string> GetSMSGroupDetails(string groups, string MandalId,string XetraId)
        {
            IDataReader dr;

            List<string> lstPersonalInfo = new List<string>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetSMSGroupsDetail", groups, MandalId, XetraId);

            while (dr.Read())
            {


                //PersonalInfo.ID = Convert.ToString(dr["ID"]);
                //PersonalInfo.Name = Convert.ToString(dr["Name"]);

                lstPersonalInfo.Add(Convert.ToString(dr["MobilePhone"]));
            }

            return lstPersonalInfo;
        }
        public static List<Entity.PersonalInfo.PersonalInfo> GetAllMembersDetails(string familyid)
        {
            IDataReader dr;

            List<Entity.PersonalInfo.PersonalInfo> lstPersonalInfo = new List<Entity.PersonalInfo.PersonalInfo>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetAllFamilymembers", familyid);

            while (dr.Read())
            {
                Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

                PersonalInfo.PId = new Guid(Convert.ToString(dr["PId"]));
                PersonalInfo.PersonId = Convert.ToString(dr["PersonId"]);
                PersonalInfo.FamilyId = Convert.ToString(dr["FamilyId"]);
                PersonalInfo.IsMainPerson = Convert.ToBoolean(dr["IsMainPerson"]);
                PersonalInfo.FullName = Convert.ToString(dr["FullName"]);

                if (dr["DOB"] != DBNull.Value)
                    PersonalInfo.DOB = Convert.ToDateTime(dr["DOB"]);

                PersonalInfo.Xetra = Convert.ToString(dr["Xetra"]);
                PersonalInfo.Mandal = Convert.ToString(dr["Mandal"]);
                PersonalInfo.HomePhone = Convert.ToString(dr["HomePhone"]);
                PersonalInfo.MobilePhone = Convert.ToString(dr["MobilePhone"]);
                PersonalInfo.Email = Convert.ToString(dr["Email"]);
                lstPersonalInfo.Add(PersonalInfo);
            }

            return lstPersonalInfo;
        }

        public static DataTable GetUserInfo(Entity.PersonalInfo.PersonalInfo userinfo)
        {
            DataTable dt = new DataTable();                  

            dt = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_User_Search", userinfo.PersonId, userinfo.FamilyId, userinfo.FirstName, userinfo.MiddleName,
               userinfo.LastName, userinfo.MobilePhone, userinfo.HomePhone, userinfo.Email, userinfo.Gender,userinfo.Mandal).Tables[0];

            return dt;
        }

        public static DataTable GetPersonInfo(Entity.PersonalInfo.PersonalInfo userinfo)
        {
            DataTable dt = new DataTable();

            dt = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_Person_Search", userinfo.PersonId, userinfo.FamilyId, userinfo.FirstName, userinfo.MiddleName, userinfo.LastName, userinfo.DOB, userinfo.MobilePhone, userinfo.HomePhone, userinfo.Email).Tables[0];

            return dt;
        }

        public static Entity.PersonalInfo.PersonalInfo GetthisUserPersonalInfo(string thisPid)
        {
            IDataReader dr;

            Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetPersonalInfobyPId", thisPid);

            if (dr.Read())
            {
                PersonalInfo = PersonalInfoModal(dr);
            }

            IDataReader drcategory;
            drcategory = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetCategoryInfobyPId", PersonalInfo.PId);

            if (drcategory.Read())
            {
                PersonalInfo.Category = CategoryInfoModal(drcategory);
            }

            return PersonalInfo;
        }


        public static Entity.PersonalInfo.PersonalInfo GetthisUserPersonalInfo1(string thisPid)
        {
            IDataReader dr;

            Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetPersonalInfobyPIdForSeva", thisPid);

            if (dr.Read())
            {
                PersonalInfo = SevaInfoModal(dr);
            }



            return PersonalInfo;
        }


        private static string CategoryInfoModal(IDataReader drcategory)
        {
            try
            {
                string Category = string.Empty;
                do
                {
                    if (!string.IsNullOrWhiteSpace(Category))
                        Category = Category + "," + Convert.ToString(drcategory["CategoryName"]);
                    else
                        Category = Convert.ToString(drcategory["CategoryName"]);
                }
                while (drcategory.Read());

                return Category;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static Entity.PersonalInfo.SatsangInfo GetthisUserSatSangInfo(string thisPid)
        {
            IDataReader dr;

            Entity.PersonalInfo.SatsangInfo SatsangInfo = new Entity.PersonalInfo.SatsangInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetSatsangInfobyPId", thisPid);

            if (dr.Read())
            {
                SatsangInfo = SatsangInfoModal(dr);
            }

            return SatsangInfo;
        }

        public static Entity.PersonalInfo.SkillInfo GetthisUserSkillInfo(string thisPid)
        {
            IDataReader dr;

            Entity.PersonalInfo.SkillInfo SkillInfo = new Entity.PersonalInfo.SkillInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetSkillInfobyPId", thisPid);

            if (dr.Read())
            {
                SkillInfo = SkillInfoModal(dr);
            }

            return SkillInfo;
        }

        public static Entity.PersonalInfo.AnkutSevaDetails GetthisUserAnkutSevaInfo(string thisPid)
        {
            IDataReader dr;

            Entity.PersonalInfo.AnkutSevaDetails AnkutSevaInfo = new Entity.PersonalInfo.AnkutSevaDetails();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetAnkutSevaInfobyPId", thisPid);

            if (dr.Read())
            {
                AnkutSevaInfo = AnkutSevaInfoModal(dr);
            }

            return AnkutSevaInfo;
        }


        private static Entity.PersonalInfo.PersonalInfo SevaInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

            PersonalInfo.Xetra = Convert.ToString(dr["PersonXetra"]);
            PersonalInfo.Mandal = Convert.ToString(dr["PersonMandal"]);
            PersonalInfo.FirstName = Convert.ToString(dr["FName"]);
            PersonalInfo.LastName = Convert.ToString(dr["LName"]);
            PersonalInfo.MiddleName = Convert.ToString(dr["MName"]);

            PersonalInfo.CAddress = Convert.ToString(dr["Address"]);
            Guid id;
            if (dr["Country"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["Country"]), out id))
                PersonalInfo.CCountry = new Guid(Convert.ToString(dr["Country"]));

            if (dr["State"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["State"]), out id))
                PersonalInfo.CState = new Guid(Convert.ToString(dr["State"]));

            if (dr["District"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["District"]), out id))
                PersonalInfo.CDistrict = new Guid(Convert.ToString(dr["District"]));

            if (dr["Taluko"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["Taluko"]), out id))
                PersonalInfo.CTauko = new Guid(Convert.ToString(dr["Taluko"]));

            PersonalInfo.CVillage = Convert.ToString(dr["Area"]);
            PersonalInfo.CPin = Convert.ToString(dr["Pin"]);
            PersonalInfo.HomePhone = Convert.ToString(dr["Resident"]);
            PersonalInfo.MobilePhone = Convert.ToString(dr["Mobile"]);
            PersonalInfo.Email = Convert.ToString(dr["Email"]);
            PersonalInfo.AltEmail = Convert.ToString(dr["AltEmail"]);
            if (Helper.ColumnExists(dr, "SatsangCategory")
           && dr["SatsangCategory"] != DBNull.Value)
                PersonalInfo.SatsangCategory = Convert.ToString(dr["SatsangCategory"]);

            if (Helper.ColumnExists(dr, "Active")
          && dr["Active"] != DBNull.Value)
                PersonalInfo.IsActive = Convert.ToInt32(dr["Active"]);

            if (Helper.ColumnExists(dr, "ProbableSeva")
         && dr["ProbableSeva"] != DBNull.Value)
                PersonalInfo.ProbableSeva = Convert.ToInt32(dr["ProbableSeva"]);

            if (Helper.ColumnExists(dr, "MaleYajman")
         && dr["MaleYajman"] != DBNull.Value)
                PersonalInfo.MaleYajman = Convert.ToInt32(dr["MaleYajman"]);

            if (Helper.ColumnExists(dr, "FemaleYajman")
         && dr["FemaleYajman"] != DBNull.Value)
                PersonalInfo.FemaleYajman = Convert.ToInt32(dr["FemaleYajman"]);

            if (Helper.ColumnExists(dr, "Amount")
         && dr["Amount"] != DBNull.Value)
                PersonalInfo.Amount = Convert.ToInt32(dr["Amount"]);

            if (Helper.ColumnExists(dr, "BookNo")
         && dr["BookNo"] != DBNull.Value)
                PersonalInfo.BookNo = Convert.ToString(dr["BookNo"]);

            if (Helper.ColumnExists(dr, "RecieptNo")
         && dr["RecieptNo"] != DBNull.Value)
                PersonalInfo.Reciept = Convert.ToString(dr["RecieptNo"]);

            PersonalInfo.PersonId = Convert.ToString(dr["PersonId"]);

            if (Helper.ColumnExists(dr, "SevaBringPersonId")
         && dr["SevaBringPersonId"] != DBNull.Value)
                PersonalInfo.SevaBringPersonId = Convert.ToString(dr["SevaBringPersonId"]);
            if (Helper.ColumnExists(dr, "SevaBringName")
         && dr["SevaBringName"] != DBNull.Value)
                PersonalInfo.SevaBringName = Convert.ToString(dr["SevaBringName"]);

            return PersonalInfo;
        }

        private static Entity.PersonalInfo.PersonalInfo PersonalInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.PersonalInfo PersonalInfo = new Entity.PersonalInfo.PersonalInfo();

            PersonalInfo.PId = new Guid(Convert.ToString(dr["PId"]));
            if (Helper.ColumnExists(dr, "DId")
                && dr["DId"] != DBNull.Value)
                PersonalInfo.DId = Convert.ToString(dr["DId"]);
            if (Helper.ColumnExists(dr, "VolutorId")
              && dr["VolutorId"] != DBNull.Value)
                PersonalInfo.Samparkkaryakar = Convert.ToString(dr["VolutorId"]);
            if (Helper.ColumnExists(dr, "IsDND")
                && dr["IsDND"] != DBNull.Value)
                PersonalInfo.IsDND = Convert.ToInt32(dr["IsDND"]);

            if (Helper.ColumnExists(dr, "SatsangCategory")
             && dr["SatsangCategory"] != DBNull.Value)
                PersonalInfo.SatsangCategory = Convert.ToString(dr["SatsangCategory"]);

            PersonalInfo.IsActive = Convert.ToInt32(dr["IsActive"]);

            PersonalInfo.Grade = Convert.ToString(dr["Grade"]);
            PersonalInfo.PersonId = Convert.ToString(dr["PersonId"]);
            PersonalInfo.FamilyId = Convert.ToString(dr["FamilyId"]);
            PersonalInfo.IsMainPerson = Convert.ToBoolean(dr["IsMainPerson"]);
            PersonalInfo.PersonStausFlag = Convert.ToString(dr["PersonStausFlag"]);
            PersonalInfo.CurrentStatus = Convert.ToString(dr["CurrentStatus"]);
            PersonalInfo.FirstName = Convert.ToString(dr["FirstName"]);
            PersonalInfo.LastName = Convert.ToString(dr["LastName"]);
            PersonalInfo.MiddleName = Convert.ToString(dr["MiddleName"]);

            if (Helper.ColumnExists(dr, "FullName"))
                PersonalInfo.FullName = Convert.ToString(dr["FullName"]);

            PersonalInfo.NickName = Convert.ToString(dr["NickName"]);
            PersonalInfo.Gender = Convert.ToString(dr["Gender"]);

            if (dr["DOB"] != DBNull.Value)
                PersonalInfo.DOB = Convert.ToDateTime(dr["DOB"]);
            PersonalInfo.Xetra = Convert.ToString(dr["Xetra"]);
            PersonalInfo.Mandal = Convert.ToString(dr["Mandal"]);
            PersonalInfo.PAddress = Convert.ToString(dr["PAddress"]);

            Guid id;
            if (dr["PCountry"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["PCountry"]), out id))
                PersonalInfo.PCountry = new Guid(Convert.ToString(dr["PCountry"]));

            if (dr["PState"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["PState"]), out id))
                PersonalInfo.PState = new Guid(Convert.ToString(dr["PState"]));

            if (dr["PTaluko"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["PTaluko"]), out id))
                PersonalInfo.PDistrict = new Guid(Convert.ToString(dr["PTaluko"]));

            if (dr["PTaluko"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["PTaluko"]), out id))
                PersonalInfo.PTaluko = new Guid(Convert.ToString(dr["PTaluko"]));

            PersonalInfo.PVillage = Convert.ToString(dr["PVillage"]);
            PersonalInfo.PPin = Convert.ToString(dr["PPin"]);
            PersonalInfo.NativePlace = Convert.ToString(dr["NativePlace"]);
            PersonalInfo.CAddress = Convert.ToString(dr["CAddress"]);

            if (dr["CCountry"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["CCountry"]), out id))
                PersonalInfo.CCountry = new Guid(Convert.ToString(dr["CCountry"]));

            if (dr["CState"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["CState"]), out id))
                PersonalInfo.CState = new Guid(Convert.ToString(dr["CState"]));

            if (dr["CDistrict"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["CDistrict"]), out id))
                PersonalInfo.CDistrict = new Guid(Convert.ToString(dr["CDistrict"]));

            if (dr["CTauko"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["CTauko"]), out id))
                PersonalInfo.CTauko = new Guid(Convert.ToString(dr["CTauko"]));

            PersonalInfo.CVillage = Convert.ToString(dr["CVillage"]);
            PersonalInfo.CPin = Convert.ToString(dr["CPin"]);
            PersonalInfo.HomePhone = Convert.ToString(dr["HomePhone"]);
            PersonalInfo.HomePhone2 = Convert.ToString(dr["HomePhone2"]);

            PersonalInfo.PTelephone = Convert.ToString(dr["PTelephone"]);
            PersonalInfo.MobilePhone = Convert.ToString(dr["MobilePhone"]);
            PersonalInfo.MobilePhone2 = Convert.ToString(dr["MobilePhone2"]);
            PersonalInfo.MobilePhone3 = Convert.ToString(dr["MobilePhone3"]);
            PersonalInfo.JobPhone = Convert.ToString(dr["JobPhone"]);
            PersonalInfo.Email = Convert.ToString(dr["Email"]);
            PersonalInfo.AltEmail = Convert.ToString(dr["AltEmail"]);
            PersonalInfo.AltEmail2 = Convert.ToString(dr["AltEmail2"]);
            PersonalInfo.BloodGroup = Convert.ToString(dr["BloodGroup"]);
            PersonalInfo.Study = Convert.ToString(dr["Study"]);
            PersonalInfo.Job = Convert.ToString(dr["Job"]);
            PersonalInfo.Designation = Convert.ToString(dr["Designation"]);
            PersonalInfo.CompanyName = Convert.ToString(dr["CompanyName"]);
            PersonalInfo.JobAddress = Convert.ToString(dr["JobAddress"]);

            if (dr["JCountry"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["JCountry"]), out id))
                PersonalInfo.JCountry = new Guid(Convert.ToString(dr["JCountry"]));

            if (dr["JDistrict"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["JDistrict"]), out id))
                PersonalInfo.JDistrict = new Guid(Convert.ToString(dr["JDistrict"]));

            if (dr["JState"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["JState"]), out id))
                PersonalInfo.JState = new Guid(Convert.ToString(dr["JState"]));

            if (dr["JTaluko"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["JTaluko"]), out id))
                PersonalInfo.JTaluko = new Guid(Convert.ToString(dr["JTaluko"]));

            PersonalInfo.JVillage = Convert.ToString(dr["JVillage"]);
            PersonalInfo.JPin = Convert.ToString(dr["JPin"]);
            PersonalInfo.JFax = Convert.ToString(dr["JFax"]);

            if (dr["TypeOfService"] != DBNull.Value)
                PersonalInfo.TypeOfService = Convert.ToString(dr["TypeOfService"]);

            if (dr["NoOfTwoWlr"] != DBNull.Value)
                PersonalInfo.NoOfTwoWlr = Convert.ToInt32(dr["NoOfTwoWlr"]);

            if (dr["NoOfFourWlr"] != DBNull.Value)
                PersonalInfo.NoOfFourWlr = Convert.ToInt32(dr["NoOfFourWlr"]);

            if (dr["Remarks"] != DBNull.Value)
                PersonalInfo.Remarks = Convert.ToString(dr["Remarks"]);

            if (dr["UpdateComment"] != DBNull.Value)
                PersonalInfo.UpdateComment = Convert.ToString(dr["UpdateComment"]);

            return PersonalInfo;
        }

        private static Entity.PersonalInfo.SatsangInfo SatsangInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.SatsangInfo SatsangInfo = new Entity.PersonalInfo.SatsangInfo();

            SatsangInfo.SId = new Guid(Convert.ToString(dr["SId"]));

            SatsangInfo.SatsangCategory = Convert.ToString(dr["SatsangCategory"]);
            SatsangInfo.Pooja = Convert.ToString(dr["Pooja"]);
            SatsangInfo.Sabha = Convert.ToString(dr["Sabha"]);
            SatsangInfo.MandirDarshan = Convert.ToString(dr["MandirDarshan"]);
            SatsangInfo.ParaSabha = Convert.ToBoolean(dr["ParaSabha"]);

            SatsangInfo.SatsangFrom = Convert.ToString(dr["SatsangFrom"]);
            if (dr["SPCONo"] != DBNull.Value)
                SatsangInfo.SPCONo = Convert.ToString(dr["SPCONo"]);

            if (dr["Prakash"] != DBNull.Value)
                SatsangInfo.Prakash = Convert.ToDateTime(dr["Prakash"]);

            if (dr["Premvati"] != DBNull.Value)
                SatsangInfo.Premvati = Convert.ToDateTime(dr["Premvati"]);

            if (dr["Bliss"] != DBNull.Value)
                SatsangInfo.Bliss = Convert.ToDateTime(dr["Bliss"]);

            if (dr["BalPrakash"] != DBNull.Value)
                SatsangInfo.BalPrakash = Convert.ToDateTime(dr["BalPrakash"]);

            if (dr["SatasangExamShield"] != DBNull.Value)
                SatsangInfo.SatasangExamShield = Convert.ToBoolean(dr["SatasangExamShield"]);

            if (dr["SatasangExamShield"] != DBNull.Value)
                SatsangInfo.Chesta = Convert.ToBoolean(dr["Chesta"]);
            if (dr["TVFilm"] != DBNull.Value)
                SatsangInfo.TVFilm = Convert.ToBoolean(dr["TVFilm"]);
            if (dr["OSFood"] != DBNull.Value)
                SatsangInfo.OSFood = Convert.ToBoolean(dr["OSFood"]);
            if (dr["Belivein"] != DBNull.Value)
                SatsangInfo.Belivein = Convert.ToString(dr["Belivein"]);
            SatsangInfo.Gharsabha = Convert.ToBoolean(dr["Gharsabha"]);
            SatsangInfo.TilakChandalo = Convert.ToBoolean(dr["TilakChandalo"]);
            SatsangInfo.SatasangExam = Convert.ToString(dr["SatasangExam"]);
            SatsangInfo.GharMandir = Convert.ToBoolean(dr["GharMandir"]);
            SatsangInfo.SatasangActivity = Convert.ToString(dr["SatasangActivity"]);
            SatsangInfo.DoSatasangActivity = Convert.ToBoolean(dr["DoSatasangActivity"]);
            SatsangInfo.Saint1 = Convert.ToString(dr["Saint1"]);
            SatsangInfo.Saint2 = Convert.ToString(dr["Saint2"]);

            return SatsangInfo;
        }

        private static Entity.PersonalInfo.SkillInfo SkillInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.SkillInfo SkillInfo = new Entity.PersonalInfo.SkillInfo();


            SkillInfo.SFId = new Guid(Convert.ToString(dr["SFId"]));

            SkillInfo.Singing = Convert.ToBoolean(dr["Singing"]);
            SkillInfo.Vadan = Convert.ToString(dr["Vadan"]);
            SkillInfo.Painting = Convert.ToBoolean(dr["Painting"]);
            SkillInfo.Construction = Convert.ToBoolean(dr["Construction"]);
            SkillInfo.Decoration = Convert.ToBoolean(dr["Decoration"]);
            SkillInfo.MSOffice = Convert.ToBoolean(dr["MSOffice"]);
            SkillInfo.Dance = Convert.ToBoolean(dr["Dance"]);
            SkillInfo.Drama = Convert.ToBoolean(dr["Drama"]);
            SkillInfo.Speach = Convert.ToBoolean(dr["Speach"]);
            SkillInfo.Tailor = Convert.ToBoolean(dr["Tailor"]);
            SkillInfo.CarPainter = Convert.ToBoolean(dr["CarPainter"]);
            SkillInfo.Plumbing = Convert.ToBoolean(dr["Plumbing"]);
            SkillInfo.Welding = Convert.ToBoolean(dr["Welding"]);
            SkillInfo.Desingning = Convert.ToBoolean(dr["Desingning"]);
            SkillInfo.Computer = Convert.ToBoolean(dr["Computer"]);
            SkillInfo.CarDriving = Convert.ToBoolean(dr["CarDriving"]);
            SkillInfo.Electric = Convert.ToBoolean(dr["Electric"]);
            SkillInfo.Sound = Convert.ToBoolean(dr["Sound"]);
            SkillInfo.Medical = Convert.ToBoolean(dr["Medical"]);
            SkillInfo.Cooking = Convert.ToBoolean(dr["Cooking"]);
            SkillInfo.Photography = Convert.ToBoolean(dr["Photography"]);
            SkillInfo.Housekeeping = Convert.ToBoolean(dr["Housekeeping"]);
            SkillInfo.Vedio = Convert.ToBoolean(dr["Vedio"]);
            SkillInfo.VedioEditing = Convert.ToBoolean(dr["VedioEditing"]);
            SkillInfo.PhotoEditing = Convert.ToBoolean(dr["PhotoEditing"]);
            SkillInfo.GujaratiTyping = Convert.ToBoolean(dr["GujaratiTyping"]);
            SkillInfo.Pasti = Convert.ToBoolean(dr["Pasti"]);
            SkillInfo.Gardening = Convert.ToBoolean(dr["Gardening"]);
            SkillInfo.PR = Convert.ToBoolean(dr["PR"]);
            SkillInfo.Account = Convert.ToBoolean(dr["Account"]);
            SkillInfo.OtherSkill = Convert.ToString(dr["OtherSkill"]);

            return SkillInfo;
        }


        private static Entity.PersonalInfo.AnkutSevaDetails AnkutSevaInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.AnkutSevaDetails AnkutSevaInfo = new Entity.PersonalInfo.AnkutSevaDetails();

            AnkutSevaInfo.AnkutSankalpID = new Guid(Convert.ToString(dr["AnkutSevaId"]));
            AnkutSevaInfo.Year = Convert.ToInt32(dr["Year"]);
            AnkutSevaInfo.Sankalap = Convert.ToInt32(dr["Sankalap"]);
            if (dr["AnkutGroup"] != DBNull.Value)
                AnkutSevaInfo.AnkutGroup = Convert.ToString(dr["AnkutGroup"]);
            if (dr["AnkutKaryakar"] != DBNull.Value)
                AnkutSevaInfo.AnkutKaryakar = Convert.ToInt32(dr["AnkutKaryakar"]);
            if (dr["AnkutSevak"] != DBNull.Value)
                AnkutSevaInfo.AnkutSevak = Convert.ToInt32(dr["AnkutSevak"]);
            return AnkutSevaInfo;
        }

        public static bool UpdatePersonalInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo, Entity.PersonalInfo.SatsangInfo SatsangInfo,
            Entity.PersonalInfo.SkillInfo SkillInfo)
        {
            try
            {
                Data.Generic.Data.DBInstance.ExecuteScalar("proc_UpdatePersonalInfobyPId", PersonalInfo.Grade, PersonalInfo.PersonId, PersonalInfo.IsMainPerson, PersonalInfo.IsActive, PersonalInfo.Samparkkaryakar, PersonalInfo.PersonStausFlag, PersonalInfo.CurrentStatus,
                PersonalInfo.FirstName, PersonalInfo.LastName, PersonalInfo.MiddleName, PersonalInfo.NickName, PersonalInfo.Gender, PersonalInfo.DOB, PersonalInfo.Xetra, PersonalInfo.Mandal,
                PersonalInfo.PAddress, PersonalInfo.PCountry, PersonalInfo.PState, PersonalInfo.PDistrict, PersonalInfo.PTaluko, PersonalInfo.PVillage, PersonalInfo.PPin, PersonalInfo.NativePlace,
                PersonalInfo.CAddress, PersonalInfo.CCountry, PersonalInfo.CState, PersonalInfo.CDistrict, PersonalInfo.CTauko, PersonalInfo.CVillage, PersonalInfo.CPin,
                PersonalInfo.HomePhone, PersonalInfo.PTelephone, PersonalInfo.MobilePhone, PersonalInfo.JobPhone, PersonalInfo.Email, PersonalInfo.AltEmail, PersonalInfo.BloodGroup, PersonalInfo.Study,
                PersonalInfo.Job, PersonalInfo.Designation, PersonalInfo.CompanyName, PersonalInfo.JobAddress, PersonalInfo.JCountry, PersonalInfo.JDistrict, PersonalInfo.JState, PersonalInfo.JTaluko, PersonalInfo.JVillage, PersonalInfo.JPin,
                PersonalInfo.JFax, PersonalInfo.TypeOfService, PersonalInfo.NoOfTwoWlr, PersonalInfo.NoOfFourWlr, PersonalInfo.Remarks, PersonalInfo.UpdateComment, DateTime.Now.ToShortDateString(), PersonalInfo.CreatedBy, false,
                PersonalInfo.MobilePhone2, PersonalInfo.MobilePhone3, PersonalInfo.HomePhone2, PersonalInfo.AltEmail2, PersonalInfo.DId, PersonalInfo.IsDND).ConvetToString();


                Data.Generic.Data.DBInstance.ExecuteScalar("proc_UpdateSatsangInfobyPId", PersonalInfo.PersonId, SatsangInfo.SatsangCategory, SatsangInfo.Pooja, SatsangInfo.Sabha, SatsangInfo.ParaSabha, SatsangInfo.Prakash, SatsangInfo.Gharsabha, SatsangInfo.TilakChandalo, SatsangInfo.SatasangExam,
                SatsangInfo.GharMandir, SatsangInfo.SatasangActivity, SatsangInfo.DoSatasangActivity, SatsangInfo.Saint1, SatsangInfo.Saint2,
                DateTime.Now, PersonalInfo.CreatedBy, false, SatsangInfo.SatsangFrom, SatsangInfo.Chesta, SatsangInfo.MandirDarshan, SatsangInfo.Belivein, SatsangInfo.SatasangExamShield, SatsangInfo.OSFood, SatsangInfo.TVFilm,
                SatsangInfo.Premvati, SatsangInfo.Bliss, SatsangInfo.BalPrakash,SatsangInfo.SPCONo).ConvetToString();

                Data.Generic.Data.DBInstance.ExecuteScalar("proc_UpdateSkillInfobyPId", PersonalInfo.PersonId, SkillInfo.Singing, SkillInfo.Vadan, SkillInfo.Painting, SkillInfo.Construction, SkillInfo.Decoration, SkillInfo.MSOffice, SkillInfo.Dance, SkillInfo.Drama, SkillInfo.Speach,
                SkillInfo.Tailor, SkillInfo.CarPainter, SkillInfo.Plumbing, SkillInfo.Welding, SkillInfo.Desingning, SkillInfo.Computer, SkillInfo.CarDriving, SkillInfo.Electric,
                SkillInfo.Sound, SkillInfo.Medical, SkillInfo.Cooking, SkillInfo.Photography, SkillInfo.Housekeeping, SkillInfo.Vedio, SkillInfo.VedioEditing, SkillInfo.PhotoEditing,
                SkillInfo.GujaratiTyping, SkillInfo.Pasti, SkillInfo.Gardening, SkillInfo.PR, SkillInfo.Account, SkillInfo.OtherSkill, DateTime.Now, PersonalInfo.CreatedBy, false).ConvetToString();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static string InsertAttandanceInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_InsertAttandanceInfo", PersonalInfo.SabhaLookupId, PersonalInfo.SabhaDate, PersonalInfo.PersonId, PersonalInfo.CreatedBy).ConvetToString();

        }

        public static string InsertAttandanceandContectInfo(Entity.PersonalInfo.PersonalInfo PersonalInfo)
        {

            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_InsertAttandanceandUpdateContectInfo", PersonalInfo.SabhaLookupId, PersonalInfo.SabhaDate, PersonalInfo.PersonId,
                PersonalInfo.Xetra, PersonalInfo.Mandal,
                PersonalInfo.PAddress, PersonalInfo.PCountry, PersonalInfo.PState, PersonalInfo.PDistrict, PersonalInfo.PTaluko, PersonalInfo.PVillage, PersonalInfo.PPin, PersonalInfo.NativePlace,
                PersonalInfo.CAddress, PersonalInfo.CCountry, PersonalInfo.CState, PersonalInfo.CDistrict, PersonalInfo.CTauko, PersonalInfo.CVillage, PersonalInfo.CPin,
                PersonalInfo.HomePhone, PersonalInfo.MobilePhone, PersonalInfo.JobPhone, PersonalInfo.Email, PersonalInfo.AltEmail,
                PersonalInfo.Job, PersonalInfo.Designation, PersonalInfo.CompanyName, PersonalInfo.JobAddress, PersonalInfo.JCountry, PersonalInfo.JDistrict, PersonalInfo.JState, PersonalInfo.JTaluko, PersonalInfo.JVillage, PersonalInfo.JPin,
                PersonalInfo.JFax, PersonalInfo.TypeOfService, PersonalInfo.CreatedBy).ConvetToString();

        }

        public static List<Entity.Lookup.Lookup> GetKaryakarInfo()
        {
            IDataReader dr;

            List<Entity.Lookup.Lookup> LookupInfo = new List<Entity.Lookup.Lookup>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetKaryakarInfo");

            while (dr.Read())
            {
                LookupInfo.Add(KaryakarInfoModal(dr));
            }

            return LookupInfo;
        }

        private static Entity.Lookup.Lookup KaryakarInfoModal(IDataReader dr)
        {
            Entity.Lookup.Lookup lkup = new Entity.Lookup.Lookup();

            lkup.DisplayText = Convert.ToString(dr["Name"]);
            lkup.Value = Convert.ToString(dr["VoluntierId"]);

            return lkup;
        }

        public static string InsertVolunterInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo)
        {

            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_InsertVolunterInfo", objvolnterinfo.VoluntierId, objvolnterinfo.Name,
                objvolnterinfo.PersonId, objvolnterinfo.Designation, objvolnterinfo.MandalOwn, objvolnterinfo.Gender, objvolnterinfo.UserId, objvolnterinfo.CreatedBy).ConvetToString();

        }

        public static string InsertSevakInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo, SIS.Entity.PersonalInfo.SkillInfo SkillInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_sevakdetails_insert", objvolnterinfo.Name, objvolnterinfo.Gender,
               objvolnterinfo.Mobile, objvolnterinfo.Age, objvolnterinfo.FromDate, objvolnterinfo.ToDate, objvolnterinfo.Note, objvolnterinfo.MandalOwn, objvolnterinfo.CreatedBy,
                 SkillInfo.Singing, SkillInfo.Vadan, SkillInfo.Painting, SkillInfo.Construction, SkillInfo.Architecture, SkillInfo.Decoration, SkillInfo.MSOffice, SkillInfo.Dance, SkillInfo.Drama, SkillInfo.Speach,
                SkillInfo.Tailor, SkillInfo.CarPainter, SkillInfo.Plumbing, SkillInfo.Welding, SkillInfo.Desingning, SkillInfo.Computer, SkillInfo.CarDriving, SkillInfo.Electric,
                SkillInfo.Sound, SkillInfo.Medical, SkillInfo.Cooking, SkillInfo.Photography, SkillInfo.Housekeeping, SkillInfo.Vedio, SkillInfo.VedioEditing, SkillInfo.PhotoEditing,
                SkillInfo.GujaratiTyping, SkillInfo.Pasti, SkillInfo.Gardening, SkillInfo.PR, SkillInfo.Account
               ).ConvetToString();

        }

        public static string InsertAnkkutInfo(Entity.PersonalInfo.SevaInfo SevaInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_InsertAnkutdetail", SevaInfo.FName, SevaInfo.MName, SevaInfo.LName,
              SevaInfo.Address, SevaInfo.Country, SevaInfo.State, SevaInfo.District, SevaInfo.Taluko, SevaInfo.Area, SevaInfo.Pin,
              SevaInfo.Mobile, SevaInfo.Resident, SevaInfo.Email, SevaInfo.AltEmail, SevaInfo.Amount,
              SevaInfo.BringFName, SevaInfo.BringMName, SevaInfo.BringLName, SevaInfo.SevaBringResident, SevaInfo.SevaBringMobile, SevaInfo.BringArea, SevaInfo.SevaBringEmail,
              SevaInfo.SevaBringAltEmail, SevaInfo.PersonId, DateTime.Now, SevaInfo.CreatedBy, DateTime.Now.Year, SevaInfo.Mandal
              , SevaInfo.Xetra, SevaInfo.BookNo, SevaInfo.RecieptNo, SevaInfo.IsSantPadhramni, SevaInfo.PersonMandal, SevaInfo.PersonXetra, SevaInfo.DId
              , SevaInfo.SantPadharamaniDate).ConvetToString();

        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetPersonId(string Mobile, string ResidentPhone)
        {
            IDataReader dr;

            List<Entity.PersonalInfo.PersonalInfo> PersonInfo = new List<Entity.PersonalInfo.PersonalInfo>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetPersonIDByPhone", Mobile, ResidentPhone);

            while (dr.Read())
            {
                PersonInfo.Add(PersonalInfoModal(dr));
            }

            return PersonInfo;

        }

        public static string InsertSevaInfo(Entity.PersonalInfo.SevaInfo SevaInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_sevadetails_insert", SevaInfo.PersonMandal, SevaInfo.PersonXetra, SevaInfo.FName, SevaInfo.MName, SevaInfo.LName,
              SevaInfo.Address, SevaInfo.Country, SevaInfo.State, SevaInfo.District, SevaInfo.Taluko, SevaInfo.Area, SevaInfo.Pin,
              SevaInfo.Mobile, SevaInfo.Resident, SevaInfo.Email, SevaInfo.AltEmail, SevaInfo.Gender, SevaInfo.Category, SevaInfo.IsActive, SevaInfo.ProbableSeva,
              SevaInfo.MaleYajman, SevaInfo.FemaleYajman, SevaInfo.Amount, SevaInfo.BookNo, SevaInfo.RecieptNo, SevaInfo.PersonId, SevaInfo.SevaBringPersonId, SevaInfo.CreatedBy).ConvetToString();
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetPerson(string name)
        {

            IDataReader dr;

            List<Entity.PersonalInfo.PersonalInfo> PersonInfo = new List<Entity.PersonalInfo.PersonalInfo>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetPersonByName", name.Split(' ')[0].Length > 0 ? name.Split(' ')[0] : "",
                 name.Split(' ')[1].Length > 0 ? name.Split(' ')[1] : "", name.Split(' ')[2].Length > 0 ? name.Split(' ')[2] : "");

            while (dr.Read())
            {
                PersonInfo.Add(PersonalInfoModal(dr));
            }

            return PersonInfo;

        }

        public static DataSet GetAnkutList()
        {
            DataSet ds = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_GetAnkutKaryakarDetails");

            return ds;
        }

        public static List<Entity.PersonalInfo.PersonalInfo> GetSevaBringPerson(string did)
        {
            IDataReader dr;

            List<Entity.PersonalInfo.PersonalInfo> PersonInfo = new List<Entity.PersonalInfo.PersonalInfo>();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetAnkutSevaBringPersonByName", did);

            while (dr.Read())
            {
                PersonInfo.Add(PersonalInfoModal(dr));
            }

            return PersonInfo;
        }

        public static DataTable GetAnkutInfo(Entity.PersonalInfo.PersonalInfo userinfo)
        {
            DataTable dt = new DataTable();

            dt = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_Ankut_Search", userinfo.PersonId, userinfo.FirstName, userinfo.MiddleName, userinfo.LastName, userinfo.MobilePhone).Tables[0];

            return dt;
        }

        public static string DeleteAnkutDetails(int id)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_ankutdetail_delete", id).ConvetToString();
        }

        public static Entity.PersonalInfo.SevaInfo GetAnkutInfo(string thisPid)
        {
            IDataReader dr;

            Entity.PersonalInfo.SevaInfo PersonalInfo = new Entity.PersonalInfo.SevaInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetAnkutDetails", thisPid);

            if (dr.Read())
            {
                PersonalInfo = AnkutInfoModal(dr);
            }


            return PersonalInfo;
        }

        public static Entity.PersonalInfo.SevaInfo GetthisUserInfoForSeva(string thisPid)
        {
            IDataReader dr;

            Entity.PersonalInfo.SevaInfo PersonalInfo = new Entity.PersonalInfo.SevaInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetContactDetails", thisPid);


            if (dr.Read())
            {
                PersonalInfo = ContactInfoModal(dr);
            }


            return PersonalInfo;
        }

        private static Entity.PersonalInfo.SevaInfo ContactInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.SevaInfo PersonalInfo = new Entity.PersonalInfo.SevaInfo();

            PersonalInfo.ContactId = new Guid(Convert.ToString(dr["ContactId"]));

            PersonalInfo.ID = Convert.ToInt32(dr["ID"]);
            PersonalInfo.PersonMandal = Convert.ToString(dr["PersonMandal"]);
            PersonalInfo.PersonXetra = Convert.ToString(dr["PersonXetra"]);


            PersonalInfo.FName = Convert.ToString(dr["FName"]);

            PersonalInfo.MName = Convert.ToString(dr["MName"]);
            PersonalInfo.LName = Convert.ToString(dr["LName"]);
            PersonalInfo.Address = Convert.ToString(dr["Address"]);

            Guid id;
            if (dr["Country"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["Country"]), out id))
                PersonalInfo.Country = new Guid(Convert.ToString(dr["Country"]));

            if (dr["State"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["State"]), out id))
                PersonalInfo.State = new Guid(Convert.ToString(dr["State"]));

            if (dr["District"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["District"]), out id))
                PersonalInfo.District = new Guid(Convert.ToString(dr["District"]));

            if (dr["Taluko"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["Taluko"]), out id))
                PersonalInfo.Taluko = new Guid(Convert.ToString(dr["Taluko"]));


            PersonalInfo.Area = Convert.ToString(dr["Area"]);
            PersonalInfo.Pin = Convert.ToString(dr["Pin"]);
            PersonalInfo.Mobile = Convert.ToString(dr["Mobile"]);
            PersonalInfo.Resident = Convert.ToString(dr["Resident"]);
            PersonalInfo.Email = Convert.ToString(dr["Email"]);

            PersonalInfo.AltEmail = Convert.ToString(dr["AltEmail"]);
            PersonalInfo.Gender = Convert.ToString(dr["Gender"]);

            PersonalInfo.Category = Convert.ToString(dr["Category"]);
            PersonalInfo.IsActive = Convert.ToInt32(dr["Active"]);

            PersonalInfo.PersonId = Convert.ToString(dr["PersonId"]);
            PersonalInfo.SevaBringPersonId = Convert.ToString(dr["SevaBringPersonId"]);


            PersonalInfo.SevaBringName = Convert.ToString(dr["SevaBringName"]);
            PersonalInfo.SevaBringMobile = Convert.ToString(dr["SevaBringMobile"]);

            return PersonalInfo;
        }

        private static Entity.PersonalInfo.SevaInfo AnkutInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.SevaInfo PersonalInfo = new Entity.PersonalInfo.SevaInfo();

            PersonalInfo.AUId = new Guid(Convert.ToString(dr["AUId"]));
            if (dr["DId"] != DBNull.Value)
                PersonalInfo.DId = Convert.ToString(dr["DId"]);
            PersonalInfo.ID = Convert.ToInt32(dr["ID"]);
            PersonalInfo.FName = Convert.ToString(dr["FName"]);

            PersonalInfo.MName = Convert.ToString(dr["MName"]);
            PersonalInfo.LName = Convert.ToString(dr["LName"]);
            PersonalInfo.Address = Convert.ToString(dr["Address"]);

            Guid id;
            if (dr["Country"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["Country"]), out id))
                PersonalInfo.Country = new Guid(Convert.ToString(dr["Country"]));

            if (dr["State"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["State"]), out id))
                PersonalInfo.State = new Guid(Convert.ToString(dr["State"]));

            if (dr["District"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["District"]), out id))
                PersonalInfo.District = new Guid(Convert.ToString(dr["District"]));

            if (dr["Taluko"] != DBNull.Value && Guid.TryParse(Convert.ToString(dr["Taluko"]), out id))
                PersonalInfo.Taluko = new Guid(Convert.ToString(dr["Taluko"]));


            PersonalInfo.Area = Convert.ToString(dr["Area"]);
            PersonalInfo.Pin = Convert.ToString(dr["Pin"]);
            PersonalInfo.Mobile = Convert.ToString(dr["Mobile"]);
            PersonalInfo.Resident = Convert.ToString(dr["Resident"]);
            PersonalInfo.Email = Convert.ToString(dr["Email"]);

            PersonalInfo.AltEmail = Convert.ToString(dr["AltEmail"]);
            PersonalInfo.Amount = Convert.ToDecimal(dr["Amount"]);


            PersonalInfo.Xetra = Convert.ToString(dr["Xetra"]);
            PersonalInfo.Mandal = Convert.ToString(dr["Mandal"]);
            PersonalInfo.BringFName = Convert.ToString(dr["BringFName"]);



            PersonalInfo.BringMName = Convert.ToString(dr["BringMName"]);
            PersonalInfo.BringLName = Convert.ToString(dr["BringLName"]);
            PersonalInfo.SevaBringResident = Convert.ToString(dr["SevaBringResident"]);
            PersonalInfo.SevaBringMobile = Convert.ToString(dr["SevaBringMobile"]);

            PersonalInfo.BringArea = Convert.ToString(dr["BringArea"]);
            PersonalInfo.SevaBringEmail = Convert.ToString(dr["SevaBringEmail"]);
            PersonalInfo.SevaBringAltEmail = Convert.ToString(dr["SevaBringAltEmail"]);
            PersonalInfo.PersonId = Convert.ToString(dr["PersonId"]);

            PersonalInfo.AnkutYear = Convert.ToInt32(dr["AnkutYear"]);
            PersonalInfo.BookNo = Convert.ToString(dr["BookNo"]);
            PersonalInfo.RecieptNo = Convert.ToString(dr["RecieptNo"]);
            PersonalInfo.IsSantPadhramni = Convert.ToBoolean(dr["IsSantPadhramni"]);
            if (dr["SantPadharamaniDate"] != DBNull.Value)
                PersonalInfo.SantPadharamaniDate = Convert.ToDateTime(dr["SantPadharamaniDate"]);
            PersonalInfo.PersonMandal = Convert.ToString(dr["PersonMandal"]);
            PersonalInfo.PersonXetra = Convert.ToString(dr["PersonXetra"]);

            return PersonalInfo;
        }

        public static string UpdateAnkkutInfo(Entity.PersonalInfo.SevaInfo SevaInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("proc_Update_AnkutDetail", SevaInfo.ID, SevaInfo.FName, SevaInfo.MName, SevaInfo.LName,
           SevaInfo.Address, SevaInfo.Country, SevaInfo.State, SevaInfo.District, SevaInfo.Taluko, SevaInfo.Area, SevaInfo.Pin,
           SevaInfo.Mobile, SevaInfo.Resident, SevaInfo.Email, SevaInfo.AltEmail, SevaInfo.Amount,
           SevaInfo.BringFName, SevaInfo.BringMName, SevaInfo.BringLName, SevaInfo.SevaBringResident, SevaInfo.SevaBringMobile, SevaInfo.BringArea, SevaInfo.SevaBringEmail,
           SevaInfo.SevaBringAltEmail, SevaInfo.PersonId, DateTime.Now.ToShortDateString(), SevaInfo.CreatedBy, DateTime.Now.Year, SevaInfo.Mandal
           , SevaInfo.Xetra, SevaInfo.BookNo, SevaInfo.RecieptNo, SevaInfo.IsSantPadhramni, SevaInfo.SantPadharamaniDate, SevaInfo.PersonMandal, SevaInfo.PersonXetra, SevaInfo.DId
           ).ConvetToString();
        }

        public static DataTable GetLableInfo(string Xetra, string Mandal)
        {
            DataTable dt = new DataTable();

            dt = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_ReportGetMandalData", Mandal, Xetra).Tables[0];

            return dt;
        }

        public static DataSet GetSevaInfo()
        {
            DataSet dt = new DataSet();

            dt = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_GetSevaDetails");

            return dt;
        }

        public static string InsertContactInfo(Entity.PersonalInfo.SevaInfo SevaInfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_contactdetails_insert", SevaInfo.ID, SevaInfo.PersonMandal, SevaInfo.PersonXetra, SevaInfo.FName, SevaInfo.MName, SevaInfo.LName,
           SevaInfo.Address, SevaInfo.Country, SevaInfo.State, SevaInfo.District, SevaInfo.Taluko, SevaInfo.Area, SevaInfo.Pin,
           SevaInfo.Mobile, SevaInfo.Resident, SevaInfo.Email, SevaInfo.AltEmail, SevaInfo.Gender, SevaInfo.Category, SevaInfo.PostCategory, SevaInfo.IsActive,
           SevaInfo.PersonId, SevaInfo.SevaBringPersonId, SevaInfo.SevaBringName, SevaInfo.SevaBringMobile, SevaInfo.CreatedBy).ConvetToString();

        }

        public static DataSet GetContactInfo()
        {
            DataSet dt = new DataSet();

            dt = Data.Generic.Data.DBInstance.ExecuteDataSet("sp_contactdetails_select");

            return dt;
        }



        public static DataTable GetVolInfo()
        {
            DataTable dt = new DataTable();

            dt = Data.Generic.Data.DBInstance.ExecuteDataSet("proc_vol_Select").Tables[0];

            return dt;
        }

        public static string DeleteVolInfo(Guid VoluntierId)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_volutorinfo_delete", VoluntierId).ConvetToString();
        }

        public static string UpdateVolInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_volutorinfo_update", objvolnterinfo.VoluntierId, objvolnterinfo.Name,
                objvolnterinfo.PersonId, objvolnterinfo.Designation, objvolnterinfo.MandalOwn, objvolnterinfo.CreatedBy).ConvetToString();

        }



        public static UserInfo GetVolunterInfo(Entity.PersonInfo.VolunterDetail objvolnterinfo)
        {
            IDataReader dr;

            Entity.PersonalInfo.UserInfo UserInfo = new Entity.PersonalInfo.UserInfo();

            dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetVolunterDetails", objvolnterinfo.UserId);

            if (dr.Read())
            {
                UserInfo = VolunterInfoModal(dr);
            }

            UserInfo.MadalOwnCodes = new List<string>();

            if (UserInfo.MandalOwn != null && UserInfo.MandalOwn.Length > 0)
            {
                foreach (string item in UserInfo.MandalOwn)
                {
                    dr = Data.Generic.Data.DBInstance.ExecuteReader("proc_GetVolunterMandalOwnDetails", item);

                    if (dr.Read())
                    {
                        string AreaString = Convert.ToString(dr["AreaString"]);
                        string MandalId = Convert.ToString(dr["MandalId"]);
                        string[] Areas = AreaString.Split(',');

                        if (Areas != null && Areas.Length > 0)
                        {
                            foreach (string areacode in Areas)
                            {
                                UserInfo.MadalOwnCodes.Add(areacode);
                            }
                        }
                    }
                }
            }

            return UserInfo;
        }

        private static Entity.PersonalInfo.UserInfo VolunterInfoModal(IDataReader dr)
        {
            Entity.PersonalInfo.UserInfo PersonalInfo = new Entity.PersonalInfo.UserInfo();
            PersonalInfo.MandalOwn = Convert.ToString(dr["MandalOwn"]).Split(',');
            PersonalInfo.Gender = Convert.ToString(dr["Gender"]);
            if (PersonalInfo.Gender == null)
                PersonalInfo.Gender = "";
            return PersonalInfo;
        }

        public static string InsertPersonalInfo(DataRow item,Guid UpdatedBy)
        {
            return Data.Generic.Data.DBInstance.ExecuteScalar("sp_persondetails_Bulk_insert",
                Convert.ToString(item["PersonId"]),
                Convert.ToString(item["Xetra"]),
                 Convert.ToString(item["Mandal"]),               
                   Convert.ToString(item["MobilePhone"]),
                    Convert.ToString(item["HomePhone"]),
                     Convert.ToString(item["Email"]),
                    Convert.ToInt32(item["CurrentStatus"]),                  
                      Convert.ToString(item["Category"]),
                      UpdatedBy).ConvetToString();

        }

        
    }
}
