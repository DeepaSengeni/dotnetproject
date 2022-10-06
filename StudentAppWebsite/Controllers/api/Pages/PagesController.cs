using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppWebsite.Models;
using STU.ActionLayer.Pages;
using Newtonsoft.Json;
using STU.ActionLayer.Book;
using STU.BaseLayer.Book;
using System.Configuration;
using System.Web;
using System.Text;
using System.IO;
using STU.Utility;
using STU.BaseLayer.Common;
using STU.ActionLayer.Common;

namespace StudentAppWebsite.Controllers.api.Pages
{
    
    public class PagesController : ApiController
    {
        ApiResponseModel resmodel = new ApiResponseModel();
        PagesAction pages = new PagesAction();
        BookAction bookAction = new BookAction();
        BookBase bookBase = new BookBase();
        CommonBase commonBase = new CommonBase();
        CommonAction commonAction = new CommonAction();

        #region RemovePageById

        [HttpGet]
        public ApiResponseModel RemovePageById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string[] Id = id.Split(',');

                try
                {
                    resmodel = new ApiResponseModel();
                    foreach (var item in Id)
                    {
                        var data = pages.RemovePageById(new STU.BaseLayer.Pages.PagesBase { PageTitle = item });
                        if (data.IsSuccess == true)
                        {
                            resmodel.IsError = false;
                            resmodel.IsSuccess = true;
                            resmodel.Message = "Successful";
                            resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                        }
                        else
                        {
                            resmodel.IsError = true;
                            resmodel.IsSuccess = false;
                            resmodel.Message = "failure";
                            resmodel.ResponseData = "[]";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());
            }
            else
            {
                resmodel.IsError = true;
                resmodel.IsSuccess = false;
                resmodel.Message = "failure";
                resmodel.ResponseData = "[]";
            }

            return resmodel;
        }
        #endregion

        #region page like
        [HttpPost]
        public ApiResponseModel pagelike(int PageId,string userid,string action)
        {
            try
            {
               var data= bookAction.PageSocialDetails_insertView(PageId, userid, action);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        #region  insertpageclick
        [HttpPost]
        public ApiResponseModel insertpageclick(int PageId, int userid, string device)
        {
            try
            {
                resmodel = new ApiResponseModel();
                bookBase.PageNumber = PageId;
                bookBase.UserId = userid;
                bookBase.Device = device;
                var data = bookAction.insertpageclick(bookBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        #region Method SendSMSToMobile
        
        public ApiResponseModel SendSMSToMobile(string mobileNumbers, string messageBody, string messageCount)
        {
            resmodel = new ApiResponseModel();
            var jsonResponce = "";

            //Your authentication key
            string authKey = ConfigurationManager.AppSettings["authkey"].ToString();
            //Multiple mobiles numbers separated by comma
            string mobileNumber = Convert.ToString(mobileNumbers);
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = ConfigurationManager.AppSettings["senderId"].ToString();
            //Your message to send, Add URL encoding here.
            string message = HttpUtility.HtmlEncode(messageBody);

            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "2");
            sbPostData.AppendFormat("&country={0}", "0");


            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://dndsms.dit.asia/api/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (System.IO.Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();
                jsonResponce = responseString;
                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return resmodel;
        }
        #endregion

        [HttpGet]
        public ApiResponseModel Message_Load(int userid,int bookid,int pageno, string name)
        {
            var Subject = "";
            var Submitter = "";
            var Inviter = name;
            var url = ConfigurationManager.AppSettings["site"].ToString() + "/Home/Index?PageId=" + pageno + "&BookId=" + bookid + "";
            resmodel = new ApiResponseModel();
            CommonAction commonAction = new CommonAction();
           var notebookdata= commonAction.Notesbook_Load_ById(new CommonBase { NotebookId = bookid });
            if (notebookdata.IsSuccess == true)
            {
                Subject = Convert.ToString(notebookdata.dtResult.Rows[0]["SubjectName"]);
                Submitter = Convert.ToString(notebookdata.dtResult.Rows[0]["StudentName"]);
            }
            try
            {
                commonBase.Id = userid;
                var data = commonAction.Message_Load(commonBase);
               var Message = HttpUtility.HtmlDecode(string.Format(Convert.ToString(data.dtResult.Rows[0]["Message"]), Inviter, Subject, Submitter, url));
               
                if (data.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = Message;
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;

        }

    }
}
