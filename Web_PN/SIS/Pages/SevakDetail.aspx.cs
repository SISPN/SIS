using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIS.HelperClass;
using System.Web.Security;

namespace SIS.Pages
{
    public partial class SevakDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLookupInfo();
            }
        }

        private void BindLookupInfo()
        {

        }

        protected void btnsaveandenterother_Click(object sender, EventArgs e)
        {
          

                SIS.Entity.PersonInfo.VolunterDetail objvolnterinfo = new SIS.Entity.PersonInfo.VolunterDetail();


                objvolnterinfo.Name = Convert.ToString(txtfullname.Text);

                objvolnterinfo.Mobile = Convert.ToString(txtmobile.Text);

                objvolnterinfo.Age = Convert.ToInt32(txtage.Text);

                if (string.IsNullOrWhiteSpace(datepicker.Text))
                    objvolnterinfo.FromDate = null;
                else
                    objvolnterinfo.FromDate = Convert.ToDateTime(datepicker.Text);

                if (string.IsNullOrWhiteSpace(datepicker1.Text))
                    objvolnterinfo.ToDate = null;
                else
                    objvolnterinfo.ToDate = Convert.ToDateTime(datepicker1.Text);

                objvolnterinfo.Note = Convert.ToString(txtnotes.Text);
                objvolnterinfo.Gender = ddlgender.SelectedValue;
                objvolnterinfo.MandalOwn = Convert.ToString(ddlMandal.SelectedItem.Text);

                MembershipUser myObject = Membership.GetUser();
                objvolnterinfo.CreatedBy = Guid.Parse(Convert.ToString(myObject.ProviderUserKey));

                SIS.Entity.PersonalInfo.SkillInfo SkillInfo = new SIS.Entity.PersonalInfo.SkillInfo();

                SkillInfo.Singing = chksing.Checked;
                SkillInfo.Vadan = txtvadan.Text;
                SkillInfo.Painting = chkpainting.Checked;
                SkillInfo.Decoration = chkdecoration.Checked;
                SkillInfo.MSOffice = chkmsoffice.Checked;
                SkillInfo.Dance = chkdance.Checked;
                SkillInfo.Drama = chkdrama.Checked;
                SkillInfo.Speach = chkspeach.Checked;
                SkillInfo.Tailor = chktailor.Checked;
                SkillInfo.CarPainter = chkcarpainter.Checked;
                SkillInfo.Plumbing = chkplumbing.Checked;
                SkillInfo.Welding = chkWelding.Checked;
                SkillInfo.Desingning = chkdesigning.Checked;
                SkillInfo.Computer = chkcomputer.Checked;
                SkillInfo.CarDriving = chkcardriving.Checked;
                SkillInfo.Electric = chkelectric.Checked;
                SkillInfo.Construction = chkConstruction.Checked;
                SkillInfo.Sound = chksound.Checked;
                SkillInfo.Medical = chkmedical.Checked;
                SkillInfo.Cooking = chkcooking.Checked;
                SkillInfo.Photography = chkphotography.Checked;
                SkillInfo.PhotoEditing = chkphotoediting.Checked;
                SkillInfo.Housekeeping = chkhousekeeping.Checked;
                SkillInfo.Vedio = chkvedio.Checked;
                SkillInfo.VedioEditing = chkvedioediting.Checked;
                SkillInfo.PR = chkpr.Checked;
                SkillInfo.Pasti = chkpasti.Checked;
                SkillInfo.Account = chkaccount.Checked;
                SkillInfo.Architecture = chkarc.Checked;

                string res = SIS.Services.PersonInfo.PersonInfo.InsertSevakInfo(objvolnterinfo, SkillInfo);

                lblstatus.Text = "Svayam Sevak Detail Updated.";

                ResetForm();
                 
        }                                                                                                                                                                      

        private void ResetForm()
        {
            txtmobile.Text = "";
            txtfullname.Text = string.Empty;
            txtage.Text = "";
            datepicker.Text = "";
            datepicker1.Text = "";
           
            txtnotes.Text = "";
        }


    }
}