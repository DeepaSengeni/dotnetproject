using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using STU.ActionLayer;
using STU.BaseLayer;
using STU.Utility;
using StudentAppWebsite.Models;
using StudentAppWebsite.Properties;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using STU.BaseLayer.Common;
using STU.ActionLayer.Common;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Configuration;
using TwoStepsAuthenticator;

namespace StudentAppWebsite.Controllers.api
{
    public class AuthenticationController : ApiController
    {
        #region signup and login web apis

        private static readonly UsedCodesManager usedCodesManager = new UsedCodesManager();
        STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
        STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
        string DubleAuthenticationKey = "" + ConfigurationManager.AppSettings["DubleAuthenticationKey"];
        CommonBase commonBase = new CommonBase();
        CommonAction commonAction = new CommonAction();
        ApiResponseModel resmodel;

        [System.Web.Http.HttpPost]
        public ApiResponseModel Login(string UserName, string LoginPassword)
        {
            try
            {
                resmodel = new ApiResponseModel();
                STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                UserInfoBase.EmailId = UserName;
                UserInfoBase.Password = LoginPassword;
                var data = UserAction.UsersInfo_Login(UserInfoBase);
                if (data.IsSuccess == false)
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";
                }
                else
                {
                    int response = (data.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(data.dtResult.Rows[0][0]) : 0);
                    if (response == -1)
                    {
                        resmodel.IsError = true;
                        resmodel.IsSuccess = false;
                        resmodel.Message = "failure";
                        resmodel.ResponseData = "[]";
                    }
                    else if (response == -2)
                    {
                        resmodel.IsError = true;
                        resmodel.IsSuccess = false;
                        resmodel.Message = "failure";
                        resmodel.ResponseData = "[]";
                    }
                    else if (Convert.ToBoolean(data.dtResult.Rows[0]["IsActive"]) == true)
                    {
                        resmodel.IsError = false;
                        resmodel.IsSuccess = true;
                        resmodel.Message = "success";
                        resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }


        //UserInfoBase.Id =Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
        //UserInfoBase.IsActive = false;
        //ActionResult = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
        [System.Web.Http.HttpPost]
        public ApiResponseModel UsersLoginInfo_Insert_Update(int id)
        {
            resmodel = new ApiResponseModel();
            try
            {
                UserInfoBase.Id = id;
                UserInfoBase.IsActive = false;
                var data = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "success";
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

    [System.Web.Http.HttpGet]
        public ApiResponseModel LoadCountry()
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<Country> Countrylist = new List<Country>();
                StudentRegistration model = new StudentRegistration();
                var data = commonAction.Countries_LoadAll();
                if (data.IsSuccess == true)
                {
                    Countrylist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Country>(data.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "success";
                    resmodel.ResponseData = JsonConvert.SerializeObject(Countrylist);
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


        [System.Web.Http.HttpGet]
        public ApiResponseModel LoadStateByCountryId(int countryid)
        {

            try
            {
                resmodel = new ApiResponseModel();
                List<State> StateList = new List<State>();
                commonBase.CountryId = countryid;
                var data = commonAction.States_LoadBy_CountryId(commonBase);
                if (data.IsSuccess == true)
                {
                    StateList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(data.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "success";
                    resmodel.ResponseData = JsonConvert.SerializeObject(StateList);
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


        [System.Web.Http.HttpGet]
        public ApiResponseModel LoadCityByStateId(int stateid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<City> CityList = new List<City>();
                commonBase.StateId = stateid;
                var data = commonAction.Cities_LoadBy_StateId(commonBase);
                if (data.IsSuccess == true)
                {
                    CityList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(data.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "success";
                    resmodel.ResponseData = JsonConvert.SerializeObject(CityList);
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


        [System.Web.Http.HttpPost]
        public HttpResponseMessage UploadStudentProfilePic()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                var postedFile = httpRequest.Files[0];
                string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + postedFile.FileName;
                var filePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("/Content/Uploads/Users/"), uploadedfilename);
                var returnpath= Path.Combine(("/Content/Uploads/Users/"), uploadedfilename);
                postedFile.SaveAs(filePath);
                docfiles.Add(filePath);
                result = Request.CreateResponse(HttpStatusCode.Created, returnpath);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return result;
        }


        [System.Web.Http.HttpPost]
        public ApiResponseModel SignUp([FromBody]StudentRegistration studentRegistration)
        {
            try
            {
                resmodel = new ApiResponseModel();
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                UserInfoBase.StudentName = studentRegistration.StudentName;
                UserInfoBase.FirstName = studentRegistration.FirstName;
                UserInfoBase.LastName = studentRegistration.LastName;
                UserInfoBase.DOB = studentRegistration.DOB;
                UserInfoBase.Gender = studentRegistration.Gender;
                UserInfoBase.UserRole = 3;
                UserInfoBase.CountryId = studentRegistration.Country;
                UserInfoBase.CollegeId = studentRegistration.CollegeName;
                UserInfoBase.StateId = Convert.ToInt32(studentRegistration.state);
                UserInfoBase.TeacherName = "";
                UserInfoBase.MobileNumber = studentRegistration.MobileNumber;
                UserInfoBase.Password = studentRegistration.Password;
                UserInfoBase.EmailId = studentRegistration.EmailID;
                UserInfoBase.IsActive = true;
                UserInfoBase.CityId = Convert.ToInt32(studentRegistration.City);
                UserInfoBase.Id = 0;
                UserInfoBase.ProfileImage = studentRegistration.Picture;
                var data = UserAction.UsersInfo_InsertUpdate(UserInfoBase);
                if (data.IsSuccess == true)
                {
                    //var userinfo = UserAction.UsersInfo_Login(UserInfoBase);
                    //if (userinfo.IsSuccess)
                    //{
                        resmodel.IsError = false;
                        resmodel.IsSuccess = true;
                        resmodel.Message = "success";
                        resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);

                    //}
                    //else
                    //{
                    //    resmodel.IsError = true;
                    //    resmodel.IsSuccess = false;
                    //    resmodel.Message = "failure";
                    //    resmodel.ResponseData = "[]";
                    //}
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


        [System.Web.Http.HttpPost]
        public ApiResponseModel SendOTP(string mobileNumber ,string messageBody)
        {           
            resmodel = new ApiResponseModel();
            try
            {
                if (mobileNumber != string.Empty)
                {
                    var auth = new TwoStepsAuthenticator.TimeAuthenticator(usedCodeManager: usedCodesManager);
                    messageBody = auth.GetCode(DubleAuthenticationKey);

                    var data = StudentAppWebsite.Controllers.UserController.SendSMSToPhone(mobileNumber, messageBody, 0);
                    if (data != null && data.Length > 0)
                    {
                        data = "success";
                        resmodel.IsSuccess = true;
                        resmodel.IsError = false;
                        resmodel.Message = data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resmodel;

        }


        [System.Web.Http.HttpPost]
        public ApiResponseModel VerifyPhone(string OTP)
        {
            resmodel = new ApiResponseModel();         
            try
            {
                if (OTP != string.Empty)
                {
                    var auth = new TwoStepsAuthenticator.TimeAuthenticator(usedCodeManager: usedCodesManager);
                    if (auth.CheckCode(DubleAuthenticationKey, OTP))
                    {   resmodel.IsSuccess = true;
                        resmodel.IsError = false;
                        resmodel.Message = "success";
                        resmodel.ResponseData = "1";

                    }
                    else
                    {
                        resmodel.IsSuccess = false;
                        resmodel.IsError = true;
                        resmodel.Message = "failure";
                        resmodel.ResponseData = "0";
                    }
                }
                else
                {
                    resmodel.IsSuccess = false;
                    resmodel.IsError = true;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resmodel;
        }

        #region CheckEmailExist
        [System.Web.Http.HttpGet]
        public ApiResponseModel CheckEmailExist(string EmailID)
       {
            resmodel = new ApiResponseModel();
            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            UserInfoBase.EmailId = EmailID;
            try
            {
                var data = UserAction.CheckEmailExist(UserInfoBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Data Already Exist";
                    resmodel.ResponseData = "[]";
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Data doesn't Exist";
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

        #region CheckMobile Number Exist
        public ApiResponseModel CheckEmail(string Mobile)
        {
            resmodel = new ApiResponseModel();
            try
            {
                UserInfoBase.MobileNumber = Mobile;
                var data = UserAction.CheckMobileExist(UserInfoBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Data Already Exist";
                    resmodel.ResponseData = "[]";
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Data doesn't Exist";
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

        [System.Web.Http.HttpPost]
        public ApiResponseModel ForgotPassword(string Email)
        {
            resmodel = new ApiResponseModel();
           
            try
            {
                if (Email != string.Empty)
                {
                    
                    STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                    STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                    String guid = Guid.NewGuid().ToString();
                    UserInfoBase.EmailId = Email;
                    var data = UserAction.CheckEmailExist(UserInfoBase);
                    if (data.IsSuccess == true)
                    {
                        AccountingSoftware.Helper.Email.SendForgotPasswordEmail(Email, guid);
                        UserInfoBase.Guid = guid;
                        UserInfoBase.EmailId = Email;
                        var data1 = UserAction.UpdateUsersInfo(UserInfoBase);
                        if (data.IsSuccess == true)
                        {
                            resmodel.IsError = false;
                            resmodel.IsSuccess = true;
                            resmodel.Message = "Password Reset link has been sent to your Email address.";
                            resmodel.ResponseData = "[]";
                        }
                    }
                    else
                    {
                        resmodel.IsError = true;
                        resmodel.IsSuccess = false;
                        resmodel.Message = "Email doesn't Exist";
                        resmodel.ResponseData = "[]";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resmodel;

        }
        [System.Web.Http.HttpGet]
        public ApiResponseModel logoff(int userid)
        {
            resmodel = new ApiResponseModel();
            try
            {
                STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                UserInfoBase.Id = userid;
                UserInfoBase.IsActive = true;
                var data = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successfully logOff";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failed";
                    resmodel.ResponseData = "[]";
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }

    #endregion

}
}