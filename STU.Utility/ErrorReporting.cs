using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace STU.Utility
{
    public static class ErrorReporting
    {

        #region GetExceptionContent
        private static string GetExceptionContent(Exception appException)
        {
            //////////////// is it writing the exception object to file properly?
            string strExceptionContent = "\r\n ----------------------------------------------------------------------------- \r\n An error ocurred at " + DateTime.Now;
            strExceptionContent += "\r\n  Error Message: " + appException.Message + "\r\n  Stack Trace: " + appException.StackTrace;


            return strExceptionContent;
        }
        #endregion

        #region Log Error To File

        private static void LogErrorToFile(Exception appException)
        {
            try
            {
                string filePath = GetErrorLogFilePath();
                if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/Uploads/ErrorLogFiles")))
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Uploads/ErrorLogFiles"));
                }
                string strExceptionContent = GetExceptionContent(appException);
                LogException(filePath, strExceptionContent);

            }
            catch (Exception ex)
            {
                UtilityLayerError(ex);
            }

        }

        private static string GetErrorLogFilePath()
        {
            string fileName = "ErrorLog_" + System.DateTime.Now.Date.ToShortDateString();
            fileName = fileName.Replace("/", "-");
            string fileExtension = "txt";
            string filePath = HttpContext.Current.Server.MapPath("~/Content/Uploads/ErrorLogFiles") + "\\" + fileName + "." + fileExtension;

            return filePath;
        }

        private static void LogException(string filePath, string content)
        {
            FileStream fs;
            if (File.Exists(filePath))
            {
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            }
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(content);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        #endregion

        #region Send Error to Email
        private static void MailError(Exception appException)
        {
            try
            {
                bool isBodyHtml = true;
                string subject = ConfigurationManager.AppSettings["subject"].ToString() + " " + DateTime.Now;
                string message = GetExceptionContent(appException).Replace("\r\n", "<br />");
                ExcEMail.SendEmail(subject, message, isBodyHtml);
            }
            catch (Exception ex)
            {
                ErrorReporting.UtilityLayerError(ex);
                throw ex;
            }
        }
        #endregion

        #region Method RedirectToErrorPage
        private static void RedirectToErrorPage(Exception ex)
        {
            HttpContext.Current.Response.Redirect(ConfigurationManager.AppSettings["redirectPage"].ToString(), false);
        }
        #endregion

        #region ProcessException
        private static void ProcessException(Exception ex)
        {
            bool emailError = false;
            bool redirectToPage = false;
            bool logError = true;

            try
            {
                emailError = Convert.ToBoolean(ConfigurationManager.AppSettings["emailError"].ToString());
                //redirectToPage = Convert.ToBoolean(ConfigurationManager.AppSettings["redirectOnError"].ToString());
                //logError = Convert.ToBoolean(ConfigurationManager.AppSettings["logError"].ToString());

                if (emailError)
                    MailError(ex);

                if (logError)
                    LogErrorToFile(ex);

                if (redirectToPage)
                    RedirectToErrorPage(ex);
            }
            catch (Exception exx)
            {
                ErrorReporting.UtilityLayerError(exx);
               // throw exx;
            }
        }
        #endregion

        #region Method WebApplicationError
        public static void WebApplicationError(Exception appException)
        {
            //HttpContext.Current.Session["appException"] = appException;

            ProcessException(appException);

            //throw appException;
        }
        #endregion

        #region Method ActionLayerError
        public static void ActionLayerError(Exception actionException)
        {
            HttpContext.Current.Session["actionException"] = actionException;

            ProcessException(actionException);

            throw actionException;

        }
        #endregion

        #region Method DataLayerError
        public static void DataLayerError(Exception dlException)
        {
            HttpContext.Current.Session["dlException"] = dlException;

            ProcessException(dlException);

            throw dlException;

        }
        #endregion

        #region Method UtilityLayerError
        private static void UtilityLayerError(Exception appException)
        {

        }
        #endregion

    }
}
