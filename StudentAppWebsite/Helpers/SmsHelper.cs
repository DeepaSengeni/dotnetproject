using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;

namespace StudentAppWebsite.Helpers
{
    public class SmsHelper
    {
        #region Declarations
        private static string apiKEY = ConfigurationManager.AppSettings["apiKEY"].ToString();
        private static string apiSENDERID = ConfigurationManager.AppSettings["apiSENDERID"].ToString();
        private static string apiSECRET = ConfigurationManager.AppSettings["apiSECRET"].ToString();
        private static string isdCode = ConfigurationManager.AppSettings["isdCode"].ToString();
        #endregion

        #region Method SendSMSToPhone
        public static string SendSMSToPhone(string mobileNumber, string messageBody)
        {
            string apiURI = ConfigurationManager.AppSettings["apiURI"].ToString();
            var jsonResponse = "";
            try
            {
                if (mobileNumber != string.Empty)
                {
                    mobileNumber = isdCode + Regex.Replace(mobileNumber, @"[^\d]", "");
                    apiURI += "?api_key={0}&api_secret={1}&from={2}&to={3}&text={4}";
                    apiURI = string.Format(apiURI, apiKEY, apiSECRET, apiSENDERID, mobileNumber, messageBody);
                    jsonResponse = new WebClient().DownloadString(apiURI);
                }
            }
            catch (Exception ex)
            {
            }
            return jsonResponse;
        }
        #endregion

        #region Method SendOTP
        public static string SendOTP(string mobileNumber, string messageBody)
        {
            string apiURI = ConfigurationManager.AppSettings["apiOTPURI"].ToString();

            var jsonResponse = "";
            try
            {
                if (mobileNumber != string.Empty)
                {
                    mobileNumber = isdCode + Regex.Replace(mobileNumber, @"[^\d]", "");
                    apiURI += "?api_key={0}&api_secret={1}&number={2}&brand={3}&pin_expiry={4}";
                    apiURI = string.Format(apiURI, apiKEY, apiSECRET, mobileNumber, messageBody, "60");
                    jsonResponse = new WebClient().DownloadString(apiURI);
                }
            }
            catch (Exception ex)
            {
            }
            return jsonResponse;
        }
        #endregion

        #region Method VerifyOTP
        public static string VerifyOTP(string OTP, string requestId)
        {
            string apiURI = ConfigurationManager.AppSettings["apiVerifyURI"].ToString();

            var jsonResponse = "";
            try
            {
                if (requestId != string.Empty)
                {
                    apiURI += "?api_key={0}&api_secret={1}&request_id={2}&code={3}";
                    apiURI = string.Format(apiURI, apiKEY, apiSECRET, requestId, OTP);
                    jsonResponse = new WebClient().DownloadString(apiURI);
                }
            }
            catch (Exception ex)
            {
            }
            return jsonResponse;
        }
        #endregion

        #region Method ResendOTP
        public static string ResendOTP(string cmd, string requestId)
        {
            string apiURI = ConfigurationManager.AppSettings["apiControlURI"].ToString();

            var jsonResponse = "";
            try
            {
                if (requestId != string.Empty)
                {
                    apiURI += "?api_key={0}&api_secret={1}&request_id={2}&cmd={3}";
                    apiURI = string.Format(apiURI, apiKEY, apiSECRET, requestId, cmd);
                    jsonResponse = new WebClient().DownloadString(apiURI);
                }
            }
            catch (Exception ex)
            {
            }
            return jsonResponse;
        }
        #endregion

        #region Method CancelOTP
        public static string CancelOTP(string requestId)
        {
            string apiURI = "https://api.nexmo.com/verify/control/xml";

            var jsonResponse = "";
            try
            {
                if (requestId != string.Empty)
                {
                    apiURI += "?api_key={0}&api_secret={1}&request_id={2}&cmd={3}";
                    apiURI = string.Format(apiURI, apiKEY, apiSECRET, requestId, "cancel");
                    jsonResponse = new WebClient().DownloadString(apiURI);
                }
            }
            catch (Exception ex)
            {
            }
            return jsonResponse;
        }
        #endregion

    }
}