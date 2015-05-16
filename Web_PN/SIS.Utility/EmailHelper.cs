using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SIS.Utility
{
    public class EmailHelper
    {

        public static bool SendEmail(string SMTPServerName, int SMTPPortNumber, string SMTPUserName, string SMTPPwd, string EmailFrom, string EmailTo, string Subject, string Body, string AttachImage)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.EnableSsl = true;
            client.Host = SMTPServerName;
            client.Port = SMTPPortNumber;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(SMTPUserName, SMTPPwd);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(EmailFrom);
            msg.To.Add(new MailAddress(EmailTo));
            msg.Subject = Subject;
            msg.IsBodyHtml = true;
            msg.Body = string.Format(Body);

            //then we create the Html part
            //to embed images, we need to use the prefix 'cid' in the img src value
            //the cid value will map to the Content-Id of a Linked resource.
            //thus <img src='cid:AttachImage'> will map to a LinkedResource with a ContentId of 'AttachImage'
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");

            //create the LinkedResource (embedded image)
            LinkedResource ObjAttachImage = new LinkedResource(AttachImage);
            ObjAttachImage.ContentId = "AttachImage";
            //add the LinkedResource to the appropriate view
            htmlView.LinkedResources.Add(ObjAttachImage);

            //add the views
            msg.AlternateViews.Add(htmlView);

            try
            {
                client.Send(msg);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
    }
}