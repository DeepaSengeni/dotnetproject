using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml;
using System.Web.Configuration;
using StudentAppWebsite.Filters;
using StudentAppWebsite.Models;
using STU.BaseLayer.Common;
using STU.ActionLayer.Common;
using System.Text;
using System.Data;
using STU.Utility;
using STU.BaseLayer.Advertisement;
using STU.ActionLayer.Advertisement;
using STU.BaseLayer.Pages;
using STU.ActionLayer.Pages;
using STU.ActionLayer.Admin;
using ClosedXML.Excel;

namespace StudentAppWebsite.Controllers
{
    [CheckLogin]
    [CheckRole]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        CommonBase commonBase = new CommonBase();
        CommonAction commonAction = new CommonAction();
        STU.BaseLayer.ActionResult ActionResult = new STU.BaseLayer.ActionResult();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            Categories model = new Categories();
            List<Categories> CategoryList = new List<Categories>();
            ActionResult = commonAction.Categories_LoadAll();
            if (ActionResult.IsSuccess)
            {
                CategoryList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Categories>(ActionResult.dtResult);
            }

            model.CategoryList = CategoryList;

            return View(model);
        }
        [HttpGet]
        public ActionResult EditCategories(int? Id = 0)
        {
            Categories model = new Categories();
            try
            {
                if (Id > 0)
                {
                    commonBase.Id = Convert.ToInt32(Id);
                    ActionResult = commonAction.Category_LoadById(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        model.CategoryName = Convert.ToString(ActionResult.dtResult.Rows[0]["CategoryName"]);
                        //model.Price = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Price"]);
                        model.Status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["Status"]);
                        model.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategories(Categories model)
        {

            try
            {
                commonBase.Id = model.Id;
                commonBase.Price = model.Price;
                commonBase.CategoryName = model.CategoryName;
                commonBase.Status = model.Status;

                if (model.Id > 0)
                {
                    commonBase.Action = "Update";
                    ActionResult = commonAction.Category_InsertUpdate(commonBase);
                    if (Convert.ToString(ActionResult.dtResult.Rows[0][0]) != "-1")
                    {
                        return RedirectToAction("Categories");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Category Name already exists please choose another";
                    }


                }
                else
                {
                    commonBase.Action = "Save";
                    ActionResult = commonAction.Category_InsertUpdate(commonBase);
                    if (Convert.ToString(ActionResult.dtResult.Rows[0][0]) != "-1")
                    {
                        return RedirectToAction("Categories");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Category Name already exists please choose another";
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return View(model);
        }



        public ActionResult UpdateCategoryStatusById(int id)
        {
            commonBase.Id = id;
            commonBase.Action = "Catagories";
            ActionResult = commonAction.Category_LoadById(commonBase);
            bool status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["Status"]);

            if (status == true)
            {
                commonBase.Status = false;
                ActionResult = commonAction.Update_StatusByID(commonBase);
            }
            else
            {
                commonBase.Status = true;
                ActionResult = commonAction.Update_StatusByID(commonBase);
            }

            return RedirectToAction("Categories");
        }


        public ActionResult Stream()
        {
            String StrCategory = string.Empty;
            Stream model = new Stream();
            List<Stream> streamList = new List<Stream>();
            ActionResult = commonAction.Streams_LoadAll();
            if (ActionResult.IsSuccess)
            {
                streamList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Stream>(ActionResult.dtResult);
            }

            model.StreamList = streamList;

            return View(model);
        }


        [HttpGet]
        public ActionResult EditStream(int? Id = 0)
        {
            Stream model = new Stream();
            try
            {

                List<Stream> CategoryList = new List<Stream>();
                ActionResult = commonAction.Categories_LoadAll();
                if (ActionResult.IsSuccess)
                {
                    CategoryList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Stream>(ActionResult.dtResult);
                }

                model.CategoryList = CategoryList;
                if (Id > 0)
                {
                    commonBase.Id = Convert.ToInt32(Id);
                    ActionResult = commonAction.Stream_LoadById(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        model.StreamIcon = Convert.ToString(ActionResult.dtResult.Rows[0]["StreamIcon"]);
                        model.StreamName = Convert.ToString(ActionResult.dtResult.Rows[0]["StreamName"]);
                        model.StreamCategory = Convert.ToString(ActionResult.dtResult.Rows[0]["StreamCategory"]);
                        model.Status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["Status"]);
                        model.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
                        model.Details = Convert.ToString(ActionResult.dtResult.Rows[0]["Details"]);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditStream(Stream model)
        {

            try
            {
                commonBase.Id = model.Id;
                commonBase.StreamCategory = model.StreamCategory;
                commonBase.StreamName = model.StreamName;
                //var Picture = (StreamIcon);
                //Picture = (Server.MapPath("~/Content/Uploads/Users/" + Picture));

                //var bytes = Encoding.UTF8.GetBytes(Picture);
                //var base64Picture = Convert.ToBase64String(bytes);

                //HttpPostedFileBase pfb = Request.Files["Picture"];
                //if (pfb != null && pfb.ContentLength > 0)
                //{
                //    var fileName = System.IO.Path.GetFileName(pfb.FileName);
                //    string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + fileName;
                //    string filePath = System.IO.Path.Combine(HttpContext.Server.MapPath("/Content/Uploads/Streams/"),
                //                       uploadedfilename);

                //    pfb.SaveAs(filePath);
                //    commonBase.StreamIcon = "/Content/Uploads/Users/" + uploadedfilename;

                //}
                //else
                //{
                //    commonBase.StreamIcon = model.StreamIcon;
                //}

                commonBase.StreamIcon = string.Empty;
                commonBase.Status = model.Status;
                //commonBase.Details = model.Details;
                commonBase.Details = string.Empty;
                if (model.Id > 0)
                {
                    commonBase.Action = "Update";
                    ActionResult = commonAction.Stream_InsertUpdate(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        if (Convert.ToString(ActionResult.dtResult.Rows[0][0]) != "-1")
                        {
                            TempData["SuccessMessage"] = "Stream Updated Succefully";
                            return RedirectToAction("Stream");
                        }
                        else
                        {
                            TempData["ExistingErrorMessage"] = "Stream Name already exists please choose another";
                        }


                    }
                    else
                    {

                        TempData["ErrorMessage"] = "Error in Updating Stream";
                    }



                }
                else
                {
                    commonBase.Action = "Save";

                    ActionResult = commonAction.Stream_InsertUpdate(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        if (Convert.ToString(ActionResult.dtResult.Rows[0][0]) != "-1")
                        {
                            TempData["SuccessMessage"] = "Stream added Succefully";
                            return RedirectToAction("Stream");

                        }

                        else
                        {
                            TempData["ExistingErrorMessage"] = "Stream Name already exists please choose another";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error in saving Stream";

                    }

                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("EditStream");
        }
        public ActionResult UpdateStreamStatusById(int id)
        {
            commonBase.Id = id;
            commonBase.Action = "Streams";
            ActionResult = commonAction.Stream_LoadById(commonBase);
            bool status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["Status"]);

            if (status == true)
            {
                commonBase.Status = false;
                ActionResult = commonAction.Update_StatusByID(commonBase);
            }
            else
            {
                commonBase.Status = true;
                ActionResult = commonAction.Update_StatusByID(commonBase);
            }

            return RedirectToAction("Stream");
        }


        public ActionResult Institutes()
        {
            String StrCategory = string.Empty;
            Institute model = new Institute();

            List<Institute> InstituteList = new List<Institute>();
            ActionResult = commonAction.Institute_LoadAll();
            if (ActionResult.IsSuccess)
            {
                InstituteList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Institute>(ActionResult.dtResult);

            }

            model.InstituteList = InstituteList;

            return View(model);
        }


        [HttpGet]
        public ActionResult EditInstitute(int? Id = 0)
        {
            Institute model = new Institute();
            List<State> StateList = new List<State>();
            List<City> CityList = new List<City>();
            try
            {
                StudentRegistration studentRegistration = new StudentRegistration();
                var country = CountryLoad();
                studentRegistration.statelist = new List<State>();

                studentRegistration.citylist = new List<City>();
                studentRegistration.Countrylist = country;

                model.Countrylist = country;
                model.Country = Convert.ToString(98);


                List<Institute> StreamList = new List<Institute>();
                ActionResult = commonAction.Streams_LoadAll();
                if (ActionResult.IsSuccess)
                {
                    StreamList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Institute>(ActionResult.dtResult);
                }
                model.statelist = new List<State>();

                model.citylist = new List<City>();
                //model.CategoryList = CategoryList;
                model.StreamList = StreamList;
                if (Id > 0)
                {
                    commonBase.Id = Convert.ToInt32(Id);
                    ActionResult = commonAction.Institute_LoadByInstituteId(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        model.InstituteLogo = Convert.ToString(ActionResult.dtResult.Rows[0]["InstituteLogo"]);
                        model.StreamName = Convert.ToString(ActionResult.dtResult.Rows[0]["StreamId"]);
                        model.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
                        // model.CategoryName = Convert.ToString(ActionResult.dtResult.Rows[0]["CategoryId"]);
                        model.InstituteName = Convert.ToString(ActionResult.dtResult.Rows[0]["InstituteName"]);
                        model.State = Convert.ToString(ActionResult.dtResult.Rows[0]["StateId"]);
                        model.City = Convert.ToString(ActionResult.dtResult.Rows[0]["CityId"]);
                        model.Country = Convert.ToString(ActionResult.dtResult.Rows[0]["CountryId"]);
                        model.Website = Convert.ToString(ActionResult.dtResult.Rows[0]["Website"]);
                        model.Email = Convert.ToString(ActionResult.dtResult.Rows[0]["Email"]);
                        model.Address = Convert.ToString(ActionResult.dtResult.Rows[0]["Address"]);
                        model.Status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["Status"]);
                        model.ContactNo = Convert.ToString(ActionResult.dtResult.Rows[0]["ContactNo"]);
                        model.FaxNo = Convert.ToString(ActionResult.dtResult.Rows[0]["FaxNo"]);
                        model.AlternateContactNo = Convert.ToString(ActionResult.dtResult.Rows[0]["AlternateContactNo"]);
                        model.Zipcode = Convert.ToString(ActionResult.dtResult.Rows[0]["Zipcode"]);

                    }
                }

                if (model.Countrylist != null && model.Countrylist.Count > 0)
                {

                    commonBase.CountryId = (model.Country != null && Convert.ToInt32(model.Country) > 0 ? Convert.ToInt32(model.Country) : model.Countrylist[0].ID);
                    ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        StateList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);
                    }


                }
                model.statelist = StateList;


                if (model.statelist != null && model.statelist.Count > 0)
                {


                    commonBase.StateId = (model.State != null && Convert.ToInt32(model.State) > 0 ? Convert.ToInt32(model.State) : model.statelist[0].ID);
                    ActionResult = commonAction.Cities_LoadBy_StateId(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        CityList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dtResult);
                    }
                }
                model.citylist = CityList;

            }


            catch (Exception ex)
            {
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditInstitute(Institute model)
        {

            try
            {
                commonBase.Id = model.Id;

                commonBase.StreamId = Convert.ToInt32(model.StreamName);
                commonBase.CountryId = Convert.ToInt32(model.Country);
                commonBase.StateId = Convert.ToInt32(model.State);
                commonBase.CityId = Convert.ToInt32(model.City);
                commonBase.Email = model.Email;
                commonBase.InstituteName = model.InstituteName;
                commonBase.Website = model.Website;
                commonBase.ContactNo = model.ContactNo;
                commonBase.Status = model.Status;

                //HttpPostedFileBase pfb = Request.Files["StreamIcon"];
                //if (pfb != null && pfb.ContentLength > 0)
                //{
                //    var fileName = System.IO.Path.GetFileName(pfb.FileName);
                //    string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + fileName;
                //    string filePath = System.IO.Path.Combine(HttpContext.Server.MapPath("/Content/Uploads/Institutes/"),
                //                       uploadedfilename);

                //    pfb.SaveAs(filePath);
                //    commonBase.InstituteIcon = "/Content/Uploads/Users/" + uploadedfilename;

                //}
                //else
                //{
                //    commonBase.InstituteIcon = model.InstituteLogo;
                //}


                // commonBase.InstituteIcon = model.InstituteLogo;
                commonBase.InstituteIcon = string.Empty;
                commonBase.Address = model.Address;
                commonBase.Zipcode = model.Zipcode;
                commonBase.AlternateContactNo = model.AlternateContactNo;
                commonBase.FaxNo = model.FaxNo;
                commonBase.Status = model.Status;



                if (model.Id > 0)
                {
                    commonBase.Action = "Update";
                    ActionResult = commonAction.Institute_InsertUpdate(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        if (Convert.ToString(ActionResult.dtResult.Rows[0][0]) != "-1")
                        {
                            TempData["SuccessMessage"] = "Institute Updated Successfully";
                            return RedirectToAction("Institutes");
                        }
                        else
                        {
                            TempData["ExistingErrorMessage"] = "Institute Name already exists please choose another";
                        }
                    }
                    else
                    {

                        TempData["ErrorMessage"] = "Error in updating Institute";
                    }


                }
                else
                {
                    commonBase.Action = "Save";
                    ActionResult = commonAction.Institute_InsertUpdate(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        if (Convert.ToString(ActionResult.dtResult.Rows[0][0]) != "-1")
                        {
                            TempData["SuccessMessage"] = "Institute Added Successfully";
                            return RedirectToAction("Institutes");

                        }
                        else
                        {
                            TempData["ExistingErrorMessage"] = "Institute Name already exists please choose another";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error in Saving Institute";

                    }

                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("EditInstitute");
        }

        public ActionResult UpdateInstituteStatusById(int id)
        {
            commonBase.Id = id;
            commonBase.Action = "Institutes";
            ActionResult = commonAction.Institute_LoadByInstituteId(commonBase);
            bool status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["Status"]);

            if (status == true)
            {
                commonBase.Status = false;
                ActionResult = commonAction.Update_StatusByID(commonBase);
            }
            else
            {
                commonBase.Status = true;
                ActionResult = commonAction.Update_StatusByID(commonBase);
            }

            return RedirectToAction("institutes");
        }
        [AllowAnonymous]
        public List<Country> CountryLoad()
        {

            List<Country> Countrylist = new List<Country>();

            StudentRegistration model = new StudentRegistration();

            ActionResult = commonAction.Countries_LoadAll();
            if (ActionResult.IsSuccess)
            {
                Countrylist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Country>(ActionResult.dtResult);

            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return Countrylist;
        }



        [AllowAnonymous]
        public JsonResult StateLoad(int CountryID)
        {
            string json = string.Empty;
            StudentRegistration model = new StudentRegistration();
            List<State> StateList = new List<State>();
            // model.Country = CountryID;
            commonBase.CountryId = CountryID;
            ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
            if (ActionResult.IsSuccess)
            {
                StateList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);
            }

            model.statelist = StateList;

            return Json(model, JsonRequestBehavior.AllowGet);
        }




        [AllowAnonymous]
        public JsonResult CityLoad(int StateID)
        {

            List<City> CityList = new List<City>();
            string json = string.Empty;

            StudentRegistration model = new StudentRegistration();


            commonBase.StateId = StateID;
            ActionResult = commonAction.Cities_LoadBy_StateId(commonBase);
            if (ActionResult.IsSuccess)
            {
                CityList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dtResult);
            }
            model.citylist = CityList;

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        #region SubjectsList
        [HttpGet]
        public ActionResult SubjectsList()
        {
            List<Subjects> lstSubject = new List<Subjects>();
            ActionResult = commonAction.Subjects_LoadAll();
            if (ActionResult.IsSuccess)
                lstSubject = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(ActionResult.dtResult);

            return View(lstSubject);
        }
        #endregion

        #region UpdateSubjectStatusById
        public ActionResult UpdateSubjectStatusById(int Id, bool Status)
        {
            commonBase.Id = Id;
            commonBase.Status = Status;
            commonBase.Action = "Subjects";
            ActionResult = commonAction.Update_StatusByID(commonBase);
            return RedirectToAction("SubjectsList");
        }
        #endregion

        #region AddSubject Get
        [HttpGet]
        public ActionResult AddSubject(int? Id = 0)
        {
            List<SelectListItem> lstStream = new List<SelectListItem>();
            Subjects model = new Subjects();
            ActionResult = commonAction.Streams_LoadAll();
            if (ActionResult.IsSuccess)
            {
                foreach (DataRow dr in ActionResult.dtResult.Rows)
                {
                    lstStream.Add(new SelectListItem
                    {
                        Text = Convert.ToString(dr["StreamName"]),
                        Value = Convert.ToString(dr["Id"])
                    }
                   );
                }

            }
            if (Id > 0)
            {
                commonBase.Id = Convert.ToInt32(Id);
                ActionResult = commonAction.Subjects_LoadById(commonBase);
                if (ActionResult.IsSuccess)
                {
                    model.StreamId = Convert.ToInt32(ActionResult.dtResult.Rows[0]["StreamId"]);
                    model.SubjectName = Convert.ToString(ActionResult.dtResult.Rows[0]["SubjectName"]);
                    model.Details = Convert.ToString(ActionResult.dtResult.Rows[0]["Details"]);
                    model.Status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["Status"]);
                }
            }
            ViewBag.StreamList = lstStream;
            return View(model);
        }
        #endregion

        #region AddSubject post
        [HttpPost]
        public ActionResult AddSubject(Subjects model)
        {
            string type = "save";
            commonBase.Id = model.Id;
            if (model.Id > 0)
                type = "update";
            commonBase.SteamId = model.StreamId;
            commonBase.SubjectName = model.SubjectName;
            commonBase.Status = model.Status;
            //commonBase.Details = model.Details;
            commonBase.Details = string.Empty;
            ActionResult = commonAction.Subject_InsertUpdate(commonBase);
            if (ActionResult.IsSuccess)
            {
                if (Convert.ToString(ActionResult.dtResult.Rows[0][0]) != "-10")
                    TempData["SuccessMessage"] = "Subject " + type + "d successfully.";
                else
                {
                    TempData["ErrorMessage"] = "Subject Name already exists, Please enter another.";
                    return RedirectToAction("AddSubject", model.Id);
                }

            }
            else
                TempData["ErrorMessage"] = "Some error occured during " + type.Substring(0, type.Length - 1) + "ing subject.";
            return RedirectToAction("SubjectsList");
        }
        #endregion

        #region Submitter_Reader_Count
        public JsonResult Submitter_Reader_Count()
        {
            string json = string.Empty;
            ActionResult = commonAction.Submitter_Reader_Count(commonBase);
            if (ActionResult.IsSuccess)
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(ActionResult.dtResult);
                json = "{\"Status\":\"1\",\"data\":" + data + "}";
            }
            else
                json = "{\"Status\":\"-1\",\"data\":\"0\"}";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion


        public ActionResult Submitter(bool? status)
        {
            Submitter model = new Submitter();
            try
            {
                List<Submitter> SubmitterList = new List<Submitter>();
                commonBase.Id = 2;
                ActionResult = commonAction.UsersDetails(commonBase);

                if (ActionResult.IsSuccess)
                {
                    SubmitterList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Submitter>(ActionResult.dtResult);
                }
                model.SubmitterList = SubmitterList;
                if (status == true)
                {

                    model.SubmitterList = SubmitterList.Where(m => m.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        public ActionResult UpdateSubmitterStatus(int id)
        {
            Submitter model = new Submitter();

            try
            {
                commonBase.Id = id;
                ActionResult = commonAction.UsersInfo_LoadBy_Id(commonBase);

                bool status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["IsActive"]);

                if (status == true)
                {
                    commonBase.Status = false;
                    ActionResult = commonAction.UpdateUserStatusById(commonBase);
                }
                else
                {
                    commonBase.Status = true;
                    ActionResult = commonAction.UpdateUserStatusById(commonBase);
                }

            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("Submitter");
        }




        public ActionResult Reader(bool? status)
        {
            Reader model = new Reader();
            try
            {
                List<Reader> ReaderList = new List<Reader>();
                commonBase.Id = 3;
                ActionResult = commonAction.UsersDetails(commonBase);

                if (ActionResult.IsSuccess)
                {
                    ReaderList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Reader>(ActionResult.dtResult);
                }
                model.ReaderList = ReaderList;

                if (status == true)
                {

                    model.ReaderList = ReaderList.Where(m => m.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
            }

            return View(model);
        }

        public ActionResult UpdateReaderStatus(int id)
        {
            Reader model = new Reader();
            try
            {

                commonBase.Id = id;
                ActionResult = commonAction.UsersInfo_LoadBy_Id(commonBase);
                bool status = Convert.ToBoolean(ActionResult.dtResult.Rows[0]["IsActive"]);

                if (status == true)
                {
                    commonBase.Status = false;
                    ActionResult = commonAction.UpdateUserStatusById(commonBase);
                }
                else
                {
                    commonBase.Status = true;
                    ActionResult = commonAction.UpdateUserStatusById(commonBase);
                }

            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
            }

            return RedirectToAction("Reader");
        }
        public ActionResult Message()
        {
            Messages model = new Messages();
            CommonBase commonBase = new CommonBase();
            commonBase.Id = 0;
            ActionResult = commonAction.Message_Load(commonBase);

            if (ActionResult.IsSuccess)
            {
                model.Message = Convert.ToString(ActionResult.dtResult.Rows[0]["Message"]);
                model.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Message(Messages model)
        {

            commonBase.Id = model.Id > 0 ? model.Id : 0;
            commonBase.Text = model.Message;
            ActionResult = commonAction.Message_InsertUpdate(commonBase);
            if (ActionResult.IsSuccess)
            {
                if (model.Id > 0)
                {
                    TempData["SuccessMessage"] = "Message Updated Successfully";
                }
                else
                {
                    TempData["SuccessMessage"] = "Message Saved Successfully";

                }
            }

            else
            {

                TempData["ErrorMessage"] = "Error in Saving Message";
            }
            return View();
        }

        [HttpGet]
        public ActionResult ManageCategoryPricing()
        {
            Categories model = new Categories();
            List<Categories> CategoryList = new List<Categories>();

            ActionResult = commonAction.Master_Categories_LoadAllPrice();
            if (ActionResult.IsSuccess)
            {
                CategoryList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Categories>(ActionResult.dtResult);
            }

            model.CategoryList = CategoryList;

            return View(model);
        }

        #region Method CityPricing_InsertUpdate
        public JsonResult CityPricing_InsertUpdate(string cityId, string price)
        {
            string jsonString = string.Empty;
            if (cityId != "" && price != "")
            {
                commonBase.CityId = Convert.ToInt32(cityId);
                commonBase.Price = Convert.ToDecimal(price);
                ActionResult = commonAction.CityPricing_InsertUpdate(commonBase);
                if (ActionResult.IsSuccess)
                {
                    jsonString = "{\"Status\":\"1\"}";
                }
                else
                {
                    jsonString = "{\"Status\":\"-1\"}";
                }
            }
            else
            {
                jsonString = "{\"Status\":\"-2\"}";
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion


        public ActionResult PaymentRequests()
        {
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementModels model = new AdvertisementModels();
            List<AdvertisementModels> paymentList = new List<AdvertisementModels>();

            ActionResult = advertisementaction.PaymentRequest_LoadAll();
            if (ActionResult.IsSuccess)
            {
                paymentList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AdvertisementModels>(ActionResult.dtResult);
            }

            model.PaymentList = paymentList;

            List<SelectListItem> StatusList = new List<SelectListItem> { new SelectListItem { Value = "1", Text = "Pending" }, new SelectListItem { Value = "2", Text = "Technical Issue" }, new SelectListItem { Value = "3", Text = "Payment Transfered" } };
            ViewBag.StatusList = StatusList;
            return View(model);
        }

        //public ActionResult UpdatePaymentStatusById(AdvertisementModels model,FormCollection fc)
        //{
        //    var i = Convert.ToInt32(fc["index"]);
        //    AdvertisementBase advertisementbase = new AdvertisementBase();
        //    AdvertisementAction advertisementaction = new AdvertisementAction();
        //    List<AdvertisementModels> paymentList = new List<AdvertisementModels>();
        //    if (model.PaymentList != null && model.PaymentList.Count > 0)
        //    {
        //        advertisementbase.Id = model.PaymentList[i].Id;
        //        advertisementbase.Status = model.PaymentList[i].Status;
        //        ActionResult = advertisementaction.UpdatePaymentStatus_ByUserId(advertisementbase);
        //        if (ActionResult.IsSuccess)
        //        {
        //            TempData["SuccessMessage"] = "Status updated successfully.";
        //            AccountingSoftware.Helper.Email.SendPaymentRequestStatusUpdateEmail(model.PaymentList[i].AdvertiserEmialId,
        //            (model.PaymentList[i].AmountRequested).ToString(), model.PaymentList[i].AccountNumber,model.PaymentList[i].Status.ToString());
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = "Error in updating status.";
        //        }
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Error in updating status.";
        //    }
        //    return RedirectToAction("PaymentRequests");
        //}


        public ActionResult SetPriceForAd()
        {
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementModels model = new AdvertisementModels();


            ActionResult = advertisementaction.PriceTable_S();
            if (ActionResult.IsSuccess)
            {
                model.AmountPaid = (ActionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(ActionResult.dtResult.Rows[0][0]) : 0);
            }



            return View(model);
        }


        public ActionResult UpdatePrice(AdvertisementModels model)
        {

            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();

            advertisementbase.AmountToBePaid = model.AmountPaid;

            ActionResult = advertisementaction.PriceTable_IU(advertisementbase);
            if (ActionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Price saved successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in saving price.";
            }

            return RedirectToAction("SetPriceForAd");
        }

        public ActionResult AdvertismentList()
        {
            AdvertisementModels model = new AdvertisementModels();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            List<AdvertisementModels> paymentList = new List<AdvertisementModels>();
            ActionResult = advertisementaction.GetAdList();
            model.PaymentList = paymentList;
            if (ActionResult.IsSuccess)
            {
                paymentList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AdvertisementModels>(ActionResult.dtResult);
                model.PaymentList = paymentList;
            }

            return View(model);
        }

        public ActionResult AdPreview(int AdId = 0)
        {
            ViewBag.Id = AdId;
            return View();
        }

        public JsonResult Ad_LoadBy_BookId(string bookId)
        {
            AdvertisementModels model = new AdvertisementModels();
            List<Categories> CategoryList = new List<Categories>();
            PagesBase pageBase = new PagesBase();
            PagesAction pageAction = new PagesAction();
            pageBase.Id = Convert.ToInt64(bookId);
            ActionResult = pageAction.Ad_LoadBy_Id(pageBase);
            if (ActionResult.IsSuccess)
            {
                var cat = ActionResult.dtResult.Rows[0];
                Categories catModel = new Categories();
                catModel.adcreationId = Convert.ToInt32(cat["adcreationId"]);
                catModel.aduploadedId = Convert.ToInt32(cat["aduploadedId"]);
                catModel.UserId = Convert.ToInt32(cat["UserId"]);
                catModel.FileUploaded = cat["FileUploaded"].ToString();
                catModel.StudentName = cat["StudentName"].ToString();
                catModel.FileName = cat["FileName"].ToString();
                catModel.Headline = cat["Headline"].ToString();
                catModel.Description = cat["Description"].ToString();
                catModel.Price = Convert.ToDecimal(cat["Price"]);
                catModel.MobileNumber = cat["MobileNumber"].ToString();
                catModel.Type = Convert.ToInt32(cat["Type"]);
                catModel.UrlAddress = cat["UrlAddress"].ToString();

                CategoryList.Add(catModel);
            }
            model.CategoryList = CategoryList;
            return Json(model, JsonRequestBehavior.AllowGet);
            //return CategoryList;
        }


        public ActionResult CityPricing()
        {
            StudentRegistration model = new StudentRegistration();
            try
            {
                var country = CountryLoad();
                model.Countrylist = country;
                model.Country = 101;
                commonBase = new CommonBase();
                commonBase.CountryId = model.Country;
                ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    model.statelist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);
                    if (model.statelist != null && model.statelist.Count > 0)
                    {
                        model.state = "38";
                        commonBase.StateId = 38;
                        ActionResult = commonAction.Cities_LoadBy_StateId(commonBase);
                        if (ActionResult.IsSuccess)
                        {
                            model.citylist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dtResult);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CountryCurrenyExRate()
        {
            StudentRegistration model = new StudentRegistration();
            var Currency = CurrencyLoadAll();
            model.currencyRates = Currency;
            return View(model);
        }

        [AllowAnonymous]
        public List<CurrencyRate> CurrencyLoadAll()
        {

            List<CurrencyRate> CurrencyList = new List<CurrencyRate>();

            StudentRegistration model = new StudentRegistration();

            ActionResult = commonAction.CurrencyList_LoadAll();
            if (ActionResult.IsSuccess)
            {
                CurrencyList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<CurrencyRate>(ActionResult.dtResult);

            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return CurrencyList;
        }

        #region Method CurrencyRate_Update
        public JsonResult CurrencyRate_Update(string Id, string price)
        {
            string jsonString = string.Empty;
            if (Id != "" && price != "")
            {
                commonBase.ID = Convert.ToInt32(Id);
                commonBase.Rate = Convert.ToDecimal(price);
                ActionResult = commonAction.CurrencyRate_Update(commonBase);
                if (ActionResult.IsSuccess)
                {
                    jsonString = "{\"Status\":\"1\"}";
                }
                else
                {
                    jsonString = "{\"Status\":\"-1\"}";
                }
            }
            else
            {
                jsonString = "{\"Status\":\"-2\"}";
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult getpaymentDetails_ByadID(int AdId)
        {
            AdvertisementModels model = new AdvertisementModels();
            List<PaypalResponse> PaypalResponseList = new List<PaypalResponse>();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.adId = AdId;
            ActionResult = advertisementaction.getpaymentDetails_ByadID(advertisementbase);
            if (ActionResult.IsSuccess)
            {
                PaypalResponseList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<PaypalResponse>(ActionResult.dtResult);
                model.PaypalResponseList = PaypalResponseList;
            }

            return View(new List<AdvertisementModels> { model });
        }

        public ActionResult PaymentList()
        {
            return View();
            //ViewBag.Id = AdId;
            //return View();
        }

        [HttpPost]
        public ActionResult GeneratePaymentlist(PaymentModel model)
        {
            string Month = model.Month;
            string Year = model.Year;
            DataTable datatablePaymentlist = new DataTable();
            //string sqlstr = "SELECT * FROM BankPaymentRequest BPR inner join [dbo].[UsersInfo] UI on  UI.ID=BPR.UserId WHERE MONTH(BPR.CreatedDate) = '" + Month + "' AND YEAR(BPR.CreatedDate) ='" + Year + "'";
            DataTable dt = new DataTable("BankPaymentrequest");
            dt.Columns.Add("RazorpayX Account Number");
            dt.Columns.Add("Payout Amount(in Rupees)");
            dt.Columns.Add("Payout Currency");
            dt.Columns.Add("Payout Mode");
            dt.Columns.Add("Payout Purpose");
            dt.Columns.Add("Fund Account Id");
            dt.Columns.Add("Fund Account Type");
            dt.Columns.Add("Fund Account Name");
            dt.Columns.Add("Fund Account Ifsc");
            dt.Columns.Add("Fund Account Number");
            dt.Columns.Add("Fund Account Vpa");
            dt.Columns.Add("Contact Name");
            dt.Columns.Add("Payout Narration");
            dt.Columns.Add("Payout Reference Id");
            dt.Columns.Add("Contact Type");
            dt.Columns.Add("Contact Email");
            dt.Columns.Add("Contact Mobile");
            dt.Columns.Add("Contact Reference Id");
            dt.Columns.Add("notes[place]");
            dt.Columns.Add("notes[code]");

            try
            {
                PaymentListAction paymentlistaction = new PaymentListAction();
                ActionResult = paymentlistaction.GetPaymentListforMonth(Month, Year);
                if (ActionResult.IsSuccess)
                {
                    datatablePaymentlist = ActionResult.dtResult;
                    if (datatablePaymentlist.Rows.Count > 0)
                    {
                        foreach (DataRow row in datatablePaymentlist.Rows)
                        {
                            DataRow dtrow;
                            dtrow = dt.NewRow();
                            dtrow["Payout Amount(in Rupees)"] = string.IsNullOrEmpty(row["AmountRequested"].ToString()) ? "" : row["AmountRequested"];
                            //dtrow["Payout Currency"] = string.IsNullOrEmpty(row["AmountCurrency"].ToString()) ? "" : row["AmountCurrency"];
                            dtrow["Payout Currency"] = "INR";
                            dtrow["Fund Account Name"] = string.IsNullOrEmpty(row["BankAccountHolderName"].ToString()) ? "" : row["BankAccountHolderName"];
                            dtrow["Fund Account Type"] = "Bank_Account";
                            dtrow["Fund Account Ifsc"] = string.IsNullOrEmpty(row["IFSCCode"].ToString()) ? "" : row["IFSCCode"];
                            dtrow["Fund Account Number"] = string.IsNullOrEmpty(row["BankAccountNumber"].ToString()) ? "" : row["BankAccountNumber"];
                            dtrow["Contact Email"] = string.IsNullOrEmpty(row["EmailId"].ToString()) ? "" : row["EmailId"];
                            dtrow["Contact Mobile"] = string.IsNullOrEmpty(row["MobileNumberUPI"].ToString()) ? "" : row["MobileNumberUPI"];
                            dtrow["RazorpayX Account Number"] = "7878780080749731";
                            dtrow["Payout Mode"] = "NEFT";
                            dtrow["Payout Purpose"] = "Salary";
                            dt.Rows.Add(dtrow);
                            //}
                        }
                        using (XLWorkbook wb = new XLWorkbook())
                        {

                            wb.Worksheets.Add(dt);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=BankPaymentList.xlsx");
                            using (System.IO.MemoryStream MyMemoryStream = new System.IO.MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                                //TempData["SuccessMessage"] = "Excel Sheet has been downloaded";
                                return File(MyMemoryStream.ToArray(), "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet");
                            }
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "There is no data in the selected month and year";
                        return RedirectToAction("PaymentList");
                    }

                }
                else
                {
                    TempData["ErrorMessage"] = "There is no data in the selected month and year";
                    return RedirectToAction("PaymentList");
                }
            }
            //DataTable datatable1 = ExecuteQuery_DataSet(sqlstr, "tbl");


            //try
            //{
            //PaymentListAction paymentlistaction = new PaymentListAction();
            //ActionResult = paymentlistaction.GetPaymentListforMonth();
            //    if (ActionResult.IsSuccess)
            //    {
            //        TempData["SuccessMessage"] = "Saved Bank Details successfully.";
            //    }
            //    else
            //    {
            //        TempData["ErrorMessage"] = "Error in saving your UPI Details. Please try again later.";
            //    }


            //}
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "There is no data in the selected month and year";
                //return RedirectToAction("PaymentList");
            }
            return RedirectToAction("PaymentList");
        }
    }
}
