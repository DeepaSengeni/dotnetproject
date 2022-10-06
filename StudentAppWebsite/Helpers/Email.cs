using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AccountingSoftware.Helper
{
    public class Email
    {
        #region Properties
        private static string userName = ConfigurationManager.AppSettings["userName"].ToString();
        private static string password = ConfigurationManager.AppSettings["password"].ToString();
        private static string mailFrom = ConfigurationManager.AppSettings["mailFrom"].ToString();
        private static string mailTo = ConfigurationManager.AppSettings["mailTo"].ToString();
        private static string bccAddress = ConfigurationManager.AppSettings["bccAddress"].ToString();
        private static string smtpServer = ConfigurationManager.AppSettings["smtpServer"].ToString();
        private static string testMode = ConfigurationManager.AppSettings["testMode"].ToString();
        private static string site = ConfigurationManager.AppSettings["site"].ToString();
        private static string commaDelimCCs = "";
        #endregion

        //const string fromaddr = "WeddingHelper@WeddingSent.com";
        static MailAddress frm = new MailAddress(mailFrom, "Notetor App");
        static string MainSection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
        public static bool SendConfirmationEmail(string emailId, string token, string name)
        {
            try
            {

                MailAddress toa = new MailAddress(emailId);
                MailMessage message = new MailMessage(frm, toa);
                message.IsBodyHtml = true;
                message.Subject = "Student App New User Registration";
                string content = ReadFile("AccountConfirmationEmailTemplate.txt",name,"",token);
                message.Body = content;
                // SmtpClient client = new SmtpClient();
                // client.Send(message);
                SetUserCredentialAndProcessMail(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string SendOTPEmail(string emailId,string messageBody)
        {
            try
            {

                MailAddress toa = new MailAddress(emailId);
                MailMessage message = new MailMessage(frm, toa);
                message.From = new MailAddress("info@notetor.com", "Notetor App");
                message.IsBodyHtml = true;

                message.Subject = "Your OTP for registration";
                string content = string.Format("Dear customer, your OTP for registration is {0} .From http://notetor.com/", messageBody);
                message.Body = content;
                 //SmtpClient client = new SmtpClient();
                 //client.Send(message);
                SetUserCredentialAndProcessMail(message);
                return "true";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool SendPaymentRequestStatusUpdateEmail(string emailId, string amount,string fullname, string type)
        {
            try
            {

                MailAddress toa = new MailAddress(emailId);
                MailMessage message = new MailMessage(frm, toa);
                message.IsBodyHtml = true;
                message.Subject = "Student App payment request status update";
                string content;
                if (type == "completed"||type== "SUCCESS" || type=="UNCLAIMED"||type=="3")
                {
                     content = ReadFile("AdvertismentPaymentRequestSuccessStatusEmailTemplate.txt",amount, fullname, type);
                }
                else
                {
                     content = ReadFile("AdvertismentPaymentRequestErrorStatusEmailTemplate.txt","","","");
                }

                    message.Body = content;
                // SmtpClient client = new SmtpClient();
                // client.Send(message);
                SetUserCredentialAndProcessMail(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SendForgotPasswordEmail(string emailid, string token)
        {
            try
            {
                MailAddress to = new MailAddress(emailid);
                MailMessage message = new MailMessage(frm, to);
                message.IsBodyHtml = true;
                message.Subject = "Forgot Password - Student App";
                string content = ReadFileForgot("ForgotPasswordEmailTemplate.txt", token);
                message.Body = content;
                SetUserCredentialAndProcessMail(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Method : SendEmail by Mohd
        public static bool SendEmail(string toMail, string subject, string message, bool isBodyHtml)
        {
          
            MailMessage msg = new MailMessage(mailFrom, toMail);
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = isBodyHtml;
            SetUserCredentialAndProcessMail(msg);
            return true;
        }
        #endregion
       
        #region Method SetUserCredentialAndProcessMail
        private static void SetUserCredentialAndProcessMail(MailMessage msg)
        {
            NetworkCredential cred = new NetworkCredential(userName, password);
            //SmtpClient mailClient = testMode == "1" ? new SmtpClient(smtpServer, 587) : new SmtpClient("relay-hosting.secureserver.net", 25);
            SmtpClient mailClient = testMode == "1" ? new SmtpClient(smtpServer, 587) : new SmtpClient("relay-hosting.secureserver.net", 25);
            //mailClient.EnableSsl = testMode == "1" ? true : false;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = cred;
            //Godaddy code 

            //SmtpClient mailClient = new SmtpClient();

            try
            {
                if (testMode == "1")
                {
                    mailClient.Send(msg);
                }
                else
                {
                    mailClient.Send(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        

        public static string ReadFile(string filename, string name,string fullname ,string token)
        {
            try
            {
                string abspath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Template/");
                string filepath = System.IO.Path.Combine(abspath, filename);
                string content = string.Empty;
                using (System.IO.StreamReader rdr = new System.IO.StreamReader(filepath))
                {
                    content = rdr.ReadToEnd();
                    content = content.Replace("@name", name);
                    content = content.Replace("@info", site); 
                    content = content.Replace("@fullname", fullname);
                    content = content.Replace("@token", token);
                    content = content.Replace("@servername", MainSection);
                }
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string ReadFileForgot(string filename, string token)
        {
            try
            {
                string abspath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Template/");
                string filepath = System.IO.Path.Combine(abspath, filename);
                string content = string.Empty;
                using (System.IO.StreamReader rdr = new System.IO.StreamReader(filepath))
                {
                    content = rdr.ReadToEnd();
                    content = content.Replace("@info", site);
                    content = content.Replace("@token", token);

                }
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string ReadFileComplaint(string email,string name,string message)
        {
            try
            {
                string abspath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Template/");
                string filepath = System.IO.Path.Combine(abspath, "ComplaintsFile.txt");
                string content = string.Empty;
                using (System.IO.StreamReader rdr = new System.IO.StreamReader(filepath))
                {
                    content = rdr.ReadToEnd();
                    content = content.Replace("@email", email);
                    content = content.Replace("@name", name);
                    content = content.Replace("@message", message);
                    content = content.Replace("@servername", MainSection);
                }
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static string ReadFileContact(string email, string name, string message,string monileno)
        {
            try
            {
                string abspath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Template/");
                string filepath = System.IO.Path.Combine(abspath, "ContactsFile.txt");
                string content = string.Empty;
                using (System.IO.StreamReader rdr = new System.IO.StreamReader(filepath))
                {
                    content = rdr.ReadToEnd();
                    content = content.Replace("@email", email);
                    content = content.Replace("@name", name);
                    content = content.Replace("@mobileno", monileno);
                    content = content.Replace("@message", message);
                    content = content.Replace("@servername", MainSection);
                }
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string ReadFileComplaintResponse(string email, string name, string message)
        {
            try
            {
                string abspath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Template/");
                string filepath = System.IO.Path.Combine(abspath, "ComplaintsResponseFile.txt");
                string content = string.Empty;
                using (System.IO.StreamReader rdr = new System.IO.StreamReader(filepath))
                {
                    content = rdr.ReadToEnd();
                    content = content.Replace("@email", email);
                    content = content.Replace("@name", name);
                    content = content.Replace("@message", message);
                    content = content.Replace("@servername", MainSection);
                }
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string ReadApplicationStatusMail(string email, string name, string message, string eventName,string seva=null)
        {
            try
            {
                string abspath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Template/");
                string filepath = System.IO.Path.Combine(abspath, "ApplicationStatusMail.txt");
                string content = string.Empty;
                using (System.IO.StreamReader rdr = new System.IO.StreamReader(filepath))
                {
                    content = rdr.ReadToEnd();
                    content = content.Replace("@email", email);
                    content = content.Replace("@name", name);
                    content = content.Replace("@message", message);
                    content = content.Replace("@eventName", eventName);
                    content = content.Replace("@seva", seva);

                    content = content.Replace("@servername", MainSection);
                }
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
      
    }

  
}