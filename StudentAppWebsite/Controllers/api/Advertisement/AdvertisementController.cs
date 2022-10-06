using Newtonsoft.Json;
using STU.ActionLayer.Advertisement;
using STU.ActionLayer.Common;
using STU.ActionLayer.Pages;
using STU.BaseLayer.Advertisement;
using STU.BaseLayer.Common;
using STU.BaseLayer.Pages;
using StudentAppWebsite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace StudentAppWebsite.Controllers.api.Advertisement
{

    public class AdvertisementController : ApiController
    {
        ApiResponseModel respmodel = new ApiResponseModel();
        AdvertisementAction advertise = new AdvertisementAction();
        CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

        #region Create Advertise
        [HttpPost]
        public ApiResponseModel Adcreation(AdvertisementModels advertisementmodels, string cityids, string hdnFilePath, int UserId)
        {
            respmodel = new ApiResponseModel();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            advertisementbase.uploadtype = advertisementmodels.uploadtype;
            advertisementbase.headline = advertisementmodels.headline;
            advertisementbase.description = advertisementmodels.description;
            advertisementbase.urladdress = advertisementmodels.urladdress;
            advertisementbase.price = advertisementmodels.price;
            advertisementbase.Features = advertisementmodels.Features;
            advertisementbase.userId = UserId;
            advertisementbase.EmailId = advertisementmodels.AdvertiserEmialId;
            advertisementbase.MobileNumber = advertisementmodels.AdvertiserMobileNumber;
            advertisementbase.CountryId = advertisementmodels.Country;
            advertisementbase.StateId = Convert.ToInt32(advertisementmodels.state);
            advertisementbase.adId = advertisementmodels.adcreationId;
            DataTable fileuploadTable = new DataTable();
            DataColumn column = new DataColumn();
            column.ColumnName = "FileUploaded";
            column.DataType = typeof(System.String);
            fileuploadTable.Columns.Add(column);

            string filePath = hdnFilePath;
            if (!string.IsNullOrEmpty(filePath))
            {
                var files = filePath.Split(',');
                AdvertisementUploadingBase advertisementuploadingbase = new AdvertisementUploadingBase();
                DataRow row;
                foreach (var newFilePath in files)
                {
                    if (!string.IsNullOrEmpty(newFilePath))
                    {
                        row = fileuploadTable.NewRow();
                        row["FileUploaded"] = newFilePath;
                        fileuploadTable.Rows.Add(row);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("fileuploader", "Please upload atleast one file");
            }
            advertisementbase.fileuploadTable = fileuploadTable;

            if (advertisementmodels.adcreationId > 0)
            {
                var data = advertisementaction.Advertisement_Update(advertisementbase);
            }
            else
            {
                try
                {
                    DateTime sdt = DateTime.ParseExact(advertisementmodels.startdate, "yyyy-MM-d", CultureInfo.InvariantCulture);
                    DateTime edt = DateTime.ParseExact(advertisementmodels.enddate, "yyyy-MM-d", CultureInfo.InvariantCulture);
                    advertisementbase.startdate = sdt;
                    advertisementbase.enddate = edt;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                var ad = advertisementaction.Advertisement_Insert(advertisementbase);
                var adid = "";
                if (ad.dtResult.Rows[0][0].ToString() != "" && ad.dtResult.Rows[0][0].ToString() != null)
                {
                    adid = ad.dtResult.Rows[0][0].ToString();
                    string citydata = cityids;
                    var datacity = citydata.Split(',');
                    foreach (var item in datacity)
                    {
                        advertisementbase.adId = Convert.ToInt32(adid);
                        advertisementbase.CityId = Convert.ToInt32(item);
                        advertisementaction.cityId_Insert(advertisementbase);
                    }
                }
                if (ad.IsSuccess == true)
                {
                    respmodel.IsError = false;
                    respmodel.IsSuccess = true;
                    respmodel.Message = adid;
                    respmodel.ResponseData = JsonConvert.SerializeObject(ad.dtResult);
                }
                else
                {
                    respmodel.IsError = true;
                    respmodel.IsSuccess = false;
                    respmodel.Message = "Failure";
                    respmodel.ResponseData = "[]";
                }
            }
            return respmodel;
        }
        #endregion

        #region Details Advertise

        [HttpPost]
        public ApiResponseModel AdDetails(int Advertisementid)
        {
            STU.ActionLayer.Pages.PagesAction pageAction = new STU.ActionLayer.Pages.PagesAction();
            try
            {
                respmodel = new ApiResponseModel();
                var data = pageAction.Ad_LoadBy_Id(new STU.BaseLayer.Pages.PagesBase { Id = Advertisementid });
                if (data.IsSuccess == true)
                {
                    respmodel.IsError = false;
                    respmodel.IsSuccess = true;
                    respmodel.Message = "Success";
                    respmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    respmodel.IsError = true;
                    respmodel.IsSuccess = false;
                    respmodel.Message = "failure";
                    respmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            { throw (ex); }
            return respmodel;
        }
        #endregion

        #region Delete Advertise
        [HttpDelete]
        public ApiResponseModel Delete_Add(int addid)
        {
            try
            {
                respmodel = new ApiResponseModel();
                var data = advertise.Advertisement_Delete(new AdvertisementBase { adId = addid });
                if (data.IsSuccess == true)
                {
                    respmodel.IsError = false;
                    respmodel.IsSuccess = true;
                    respmodel.Message = "AddDeleted";
                    respmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    respmodel.IsError = true;
                    respmodel.IsSuccess = false;
                    respmodel.Message = "Error";
                    respmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respmodel;
        }
        #endregion

        #region adcreation_LoadByAdId
        [HttpGet]
        public ApiResponseModel adcreation_LoadByAdId(int id)
        {
            try
            {
                respmodel = new ApiResponseModel();
                var data = advertise.adcreation_LoadByAdId(new AdvertisementBase { adId = id });
                if (data.IsSuccess == true)
                {
                    respmodel.IsError = false;
                    respmodel.IsSuccess = true;
                    respmodel.Message = "Successful";
                    respmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);

                }
                else
                {
                    respmodel.IsError = true;
                    respmodel.IsSuccess = false;
                    respmodel.Message = "failure";
                    respmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respmodel;
        }
        #endregion

        #region CheckCityAvailability
        [HttpGet]
        public ApiResponseModel CheckCityAvailability(string cityId, string startDate, string endDate)
        {
            try
            {
                respmodel = new ApiResponseModel();
                var data = advertise.CheckCityAd_Availability(new AdvertisementBase { MultiplecityId = cityId, Checkstartdate = startDate, Checkenddate = endDate });
                if (data.IsSuccess == true)
                {
                    respmodel.IsError = false;
                    respmodel.IsSuccess = true;
                    respmodel.Message = "Success";
                    respmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    respmodel.IsError = true;
                    respmodel.IsSuccess = false;
                    respmodel.Message = "failure";
                    respmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respmodel;
            // return CategoryList;


        }
        #endregion

        #region GetClickCount_ByAdId
        [HttpGet]
        public ApiResponseModel GetClickCount_ByAdId(int id)
        {
            try
            {
                respmodel = new ApiResponseModel();
                var data = advertise.GetClickCount_ByAdId(new AdvertisementBase { adId = id });
                if (data.IsSuccess == true)
                {
                    respmodel.IsError = false;
                    respmodel.IsSuccess = true;
                    respmodel.Message = "Success";
                    respmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    respmodel.IsError = true;
                    respmodel.IsSuccess = false;
                    respmodel.Message = "failure";
                    respmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respmodel;
        }
        #endregion

        #region AccountDetails_ByUserId
        [HttpGet]
        public ApiResponseModel AccountDetails_ByUserId(int id)
        {
            try
            {
                respmodel = new ApiResponseModel();
                var data = advertise.getAccountDetails_ByUserId(new AdvertisementBase { userId = id });
                if (data.IsSuccess == true)
                {
                    respmodel.IsError = false;
                    respmodel.IsSuccess = true;
                    respmodel.Message = "Success";
                    respmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    respmodel.IsError = true;
                    respmodel.IsSuccess = false;
                    respmodel.Message = "failure";
                    respmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respmodel;
        }
        #endregion

        #region UploadAdFile
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UploadAdFile(string userId)
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                var postedFile = httpRequest.Files[0];
                string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + postedFile.FileName;
                //var fileName = Path.GetFileName(FileDataContent.FileName);
                if (uploadedfilename.Contains(" "))
                {
                    uploadedfilename.Replace(" ", "_");
                }

                if (!(string.IsNullOrEmpty(userId)))
                {
                    DirectoryInfo dinfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Content/Uploads/Ads/" + userId));
                    if (!dinfo.Exists)
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Uploads/Ads/" + userId));
                    }
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Uploads/Ads/" + userId + "/"), uploadedfilename);
                    var returnpath = Path.Combine(("/Content/Uploads/Ads/" + userId + "/"), uploadedfilename);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                    result = Request.CreateResponse(HttpStatusCode.Created, returnpath);
                }
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return result;
        }
        #endregion

        #region Ad_LoadBy_BookId
        [HttpPost]
        public ApiResponseModel LoadAd(int userid)
        {
            respmodel = new ApiResponseModel();
            PagesBase pageBase = new PagesBase();
            PagesAction pageAction = new PagesAction();
            //  pageBase.BookId = Convert.ToInt64(bookId);
            pageBase.UserId = userid;
            pageBase.CityName = "";
            var addata = pageAction.Ad_LoadBy_BookId(pageBase);
            if (addata.IsSuccess)
            {
                if (addata.dtResult != null && addata.dtResult.Rows.Count > 0)
                {
                    respmodel.IsSuccess = true;
                    respmodel.IsError = false;
                    respmodel.Message = "Add Load";
                    respmodel.ResponseData = JsonConvert.SerializeObject(addata.dtResult);
                }
            }
            else
            {
                respmodel.IsSuccess = false;
                respmodel.IsError = true;
                respmodel.Message = "fail";
                respmodel.ResponseData = "[]";
            }

            return respmodel;

        }
        #endregion

        #region saveAd_Clicks
        [HttpPost]
        public ApiResponseModel AdClick_Update(int AdId, int userId, int BookId)
        {
            respmodel = new ApiResponseModel();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.adId = Convert.ToInt32(AdId);
            advertisementbase.BookId = BookId;
            advertisementbase.userId = userId;
            var clickcount = advertisementaction.saveAd_Clicks(advertisementbase);
            if (clickcount.IsSuccess)
            {
                respmodel.IsError = false;
                respmodel.Message = "Success";
                respmodel.IsSuccess = true;
                respmodel.ResponseData = "[]";

            }
            else
            {
                respmodel.IsError = true;
                respmodel.Message = "failure";
                respmodel.IsSuccess = false;
                respmodel.ResponseData = "[]";
            }
            return respmodel;
        }
        #endregion

        #region selectedCountryId
        [HttpPost]
        public ApiResponseModel selectedCountryId(int CountryID)
        {
            respmodel = new ApiResponseModel();
            CommonBase commonBase = new CommonBase();
            CommonAction commonAction = new CommonAction();
            commonBase.CountryId = CountryID;
            var Ratedata = commonAction.Get_Country_CurrencyCode_Rate_by_CountryId(commonBase);
            if (Ratedata.IsSuccess)
            {
                var country = AccountingSoftware.Helpers.CommonMethods.ConvertTo<CurrencyRate>(Ratedata.dtResult);
                respmodel.IsError = false;
                respmodel.Message = "Success";
                respmodel.IsSuccess = true;
                respmodel.ResponseData = JsonConvert.SerializeObject(country);

            }
            else
            {
                respmodel.IsError = true;
                respmodel.Message = "failure";
                respmodel.IsSuccess = false;
                respmodel.ResponseData = "[]";
            }
            return respmodel;
        }
        #endregion

        [HttpPost]
        public ApiResponseModel PaymentSuccess(string Email, string name, int userid, string title, int Adid, string paymentid, string Currency, string totalammount, string Payer_id, string intent, string state, string city_Id)
        {
            respmodel = new ApiResponseModel();
            AdvertisementModels model = new AdvertisementModels();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            advertisementbase.headline = Convert.ToString(title);
            advertisementbase.userId = Convert.ToInt32(userid);
            advertisementbase.Add_Creation_ID = Convert.ToString(Adid);
            advertisementbase.paymentId = paymentid;
            advertisementbase.Currency = Currency;
            advertisementbase.totalammount = totalammount;
            advertisementbase.Payer_id = Payer_id;
            advertisementbase.intent = intent;
            advertisementbase.state = state;

            AccountingSoftware.Helper.Email.SendPaymentRequestStatusUpdateEmail(Email, advertisementbase.totalammount, name, advertisementbase.state);

            var paymentdetail = advertisementaction.PaymentDetails_Insert(advertisementbase);
            //string citydata = Convert.ToString(city_Id);
            //var datacity = citydata.Split(',');
            //foreach (var item in datacity)
            //{
            //    advertisementbase.CityId = Convert.ToInt32(item);
            //    var data = advertisementaction.FindusersDetailofCreatedForCity(advertisementbase);
            //    if (data.dtResult.Rows[0][1].ToString() != "" && data.dtResult.Rows[0][1].ToString() != null)
            //    {
            respmodel.IsError = false;
            respmodel.IsSuccess = true;
            respmodel.Message = "Successful";
            respmodel.ResponseData = JsonConvert.SerializeObject(paymentdetail.dtResult);
            //    }
            //}

            return respmodel;
        }
        [HttpPost]
        public void AdBulkSmsSend_ForAd(int adid, int userid, string heading, string city_Id)
        {
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            advertisementbase.headline = Convert.ToString(heading);
            advertisementbase.userId = Convert.ToInt32(userid);
            advertisementbase.Add_Creation_ID = Convert.ToString(adid);
            string citydata = Convert.ToString(city_Id);
            var datacity = citydata.Split(',');
            foreach (var item in datacity)
            {
                advertisementbase.CityId = Convert.ToInt32(item);
                var data = advertisementaction.FindusersDetailofCreatedForCity(advertisementbase);
                if (data.dtResult.Rows[0][1].ToString() != "" && data.dtResult.Rows[0][1].ToString() != null)
                {
                    for (int i = 0; i < data.dtResult.Rows.Count; i++)
                    {
                        var messageBody = data.dtResult.Rows[i]["name"].ToString() + " advertized " + data.dtResult.Rows[i]["Headline"] + " for you. " + ConfigurationManager.AppSettings["site"].ToString() + "";
                        //string authKey = ConfigurationManager.AppSettings["authkey"].ToString();
                        string mobileNumber = Convert.ToString(data.dtResult.Rows[i]["MobileNumber"]);
                        //string senderId = ConfigurationManager.AppSettings["senderId"].ToString();
                        //string message = HttpUtility.UrlEncode(messageBody);

                        try
                        {
                            var jsonResponse = "";
                            jsonResponse = Helpers.TwilioHelper.SendSms(mobileNumber, messageBody, "+15163622226");
                            ////Call Send SMS API
                            ////string sendSMSUri = "http://sms.tejarat.in/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

                            //string sendSMSUri = "http://dndsms.dit.asia/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";


                            //HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                            //httpWReq.Method = "GET";

                            ////Get the response
                            //HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                            //StreamReader reader = new StreamReader(response.GetResponseStream());
                            //string responseString = reader.ReadToEnd();
                            ////Close the response
                            //reader.Close();
                            //response.Close();
                        }
                        catch (SystemException ex)
                        {
                            throw (ex);
                        }                       
                    }
                }

            }
        }

        [HttpPost]
        public ApiResponseModel paymentFailure(int adid, string response)
        {
            respmodel = new ApiResponseModel();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.adId = adid;
            advertisementbase.description = response;
            var Res = advertisementaction.deleteaddwhichisnotpaidamount(advertisementbase);


            return respmodel;

        }
    }
}







