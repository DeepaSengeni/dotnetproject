using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using StudentAppWebsite.Filters;
using StudentAppWebsite.Models;
using STU.BaseLayer.Common;
using STU.ActionLayer.Common;
using System.Text;
using STU.Utility;
using System.Web.Configuration;
using System.Drawing;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;
using TwoStepsAuthenticator;
using System.Net.Http;
using Newtonsoft.Json;

namespace StudentAppWebsite.Controllers
{


    public class AccountController : Controller
    {
        private static readonly UsedCodesManager usedCodesManager = new UsedCodesManager();
        string DubleAuthenticationKey = "" + ConfigurationManager.AppSettings["DubleAuthenticationKey"];
        //
        // GET: /Account/Login
        STUDENT_APP.BooksService studentService = new STUDENT_APP.BooksService();
        // UsersInfoBase userBase = new UsersInfoBase();
        CommonBase commonBase = new CommonBase();
        CommonAction commonAction = new CommonAction();
        STU.BaseLayer.ActionResult ActionResult = new STU.BaseLayer.ActionResult();


        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            SubmitterRegistration model = new SubmitterRegistration();
            List<State> StateList = new List<State>();
            List<City> CityList = new List<City>();
            List<SelectListItem> GenderList = new List<SelectListItem>();
            List<InstituteModel> InstituteModelList = new List<InstituteModel>();
            GenderList.Add(new SelectListItem { Text = "Male", Value = "Male" });
            GenderList.Add(new SelectListItem { Text = "Female", Value = "Female" });
            ViewBag.GenderList = GenderList;
            var country = CountryLoad();
            model.Countrylist = country;
            if (model.Countrylist != null && model.Countrylist.Count > 0)
            {
                int countryId = Convert.ToInt32(98);
                model.Country = countryId;
                commonBase.CountryId = countryId;
                ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    StateList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);
                }
            }
            //  model.Country = 98;
            model.statelist = StateList;


            if (model.statelist != null && model.statelist.Count > 0)
            {

                //int StateID = Convert.ToInt32(model.statelist[0].ID);
                int StateID = Convert.ToInt32(2338);
                model.state = Convert.ToString(StateID);
                commonBase.StateId = StateID;
                ActionResult = commonAction.Cities_LoadBy_StateId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    CityList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dtResult);
                }
            }
            model.citylist = CityList;
            model.City = "2";

            commonBase.CityId = 2;
            ActionResult = commonAction.Institutes_LoadByCityId(commonBase);
            if (ActionResult.IsSuccess)
            {
                InstituteModelList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InstituteModel>(ActionResult.dtResult);
            }
            model.InstituteModelList = InstituteModelList;


            return View(model);
        }

        //
        // POST: /Account/Login

        [HttpPost]
        public ActionResult Login(FormCollection fc, LoginModel model, string returnUrl)
        {
            try
            {
                STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                UserInfoBase.EmailId = fc["UserName"].ToString();
                UserInfoBase.Password = model.Password;
                ActionResult = UserAction.UsersInfo_Login(UserInfoBase);

                if (ActionResult.IsSuccess)
                {
                    if (Convert.ToBoolean(ActionResult.dtResult.Rows[0]["IsActive"]) == true)
                    {
                        Session["Role"] = ActionResult.dtResult.Rows[0]["RoleId"];
                        Session["StudentName"] = ActionResult.dtResult.Rows[0]["StudentFullName"];
                        Session["UserName"] = ActionResult.dtResult.Rows[0]["EmailId"];
                        Session["UserId"] = ActionResult.dtResult.Rows[0]["Id"];

                        Session["ProfileImage"] = ActionResult.dtResult.Rows[0]["ProfileImage"];

                        UserInfoBase.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
                        UserInfoBase.IsActive = false;
                        ActionResult = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);

                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            if (Convert.ToInt32(Session["Role"]) == 1)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                return RedirectToAction("Home", "Home");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(Session["Role"]) == 1)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                return RedirectToLocal(HttpUtility.UrlDecode(returnUrl));
                            }
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Your Account is not active. Please contact to administrator";
                    }


                }
                else
                {

                    TempData["ErrorMessage"] = "Invalid Email/Phone or Password";
                }
            }
            catch (Exception ex)
            {
            }
            return View(model);
        }

        //
        // POST: /Account/LogOff


        public ActionResult LogOff()
        {
            // WebSecurity.Logout();

            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            UserInfoBase.Id = Convert.ToInt32(Session["UserId"]);
            UserInfoBase.IsActive = true;
            ActionResult = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
            Session.Abandon();
            //
            if (Request.Cookies["StudentApp"] != null)
            {
                HttpCookie myCookie = new HttpCookie("StudentApp");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            //
            return RedirectToAction("SubmitterRegistration", "Account");
        }

        //
        // GET: /Account/Register


        public ActionResult Register(string inv)
        {
            List<State> StateList = new List<State>();
            List<City> CityList = new List<City>();
            StudentRegistration model = new StudentRegistration();
            var country = CountryLoad();
            model.Countrylist = country;
            model.Country = 98;
            model.EmailID = inv;
            var College = Colleges_LoadAll();
            model.CollegeList = College;
            if (model.Countrylist != null && model.Countrylist.Count > 0)
            {
                int countryId = Convert.ToInt32(98);
                model.Country = countryId;
                commonBase.CountryId = countryId;
                ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    StateList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);
                }
            }
            model.statelist = StateList;

            if (model.statelist != null && model.statelist.Count > 0)
            {

                int StateID = Convert.ToInt32(2338);
                model.state = Convert.ToString(StateID);
                commonBase.StateId = StateID;
                ActionResult = commonAction.Cities_LoadBy_StateId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    CityList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dtResult);
                }
            }
            model.citylist = CityList;

            return View(model);
        }

        //
        // POST: /Account/Register

        [HttpPost]

        public ActionResult Register(StudentRegistration studentRegistration)
        {
            try
            {
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();

                HttpPostedFileBase pfb = Request.Files["ProfilePicture"];
                if (pfb != null && pfb.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pfb.FileName);
                    string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + fileName;
                    string filePath = System.IO.Path.Combine(HttpContext.Server.MapPath("/Content/Uploads/Users/"),
                                       uploadedfilename);

                    pfb.SaveAs(filePath);
                    UserInfoBase.ProfileImage = site + "/Content/Uploads/Users/" + uploadedfilename;

                }



                UserInfoBase.StudentName = studentRegistration.StudentName;
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
                ActionResult = UserAction.UsersInfo_InsertUpdate(UserInfoBase);

                if (ActionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "User registered successfully.";

                    ActionResult = UserAction.UsersInfo_Login(UserInfoBase);
                    if (ActionResult.IsSuccess)
                    {
                        Session["Role"] = ActionResult.dtResult.Rows[0]["RoleId"];
                        Session["UserName"] = studentRegistration.EmailID;
                        Session["UserId"] = ActionResult.dtResult.Rows[0]["Id"];
                        Session["ProfileImage"] = ActionResult.dtResult.Rows[0]["ProfileImage"];
                        return RedirectToAction("Home", "Home");
                    }
                    else
                    {


                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Signup please Try Again";
                }


            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }


            return RedirectToAction("Register");
        }

        //


        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (UsersContext db = new UsersContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }
        public JsonResult GetCitiesByCountry(int CountryID)
        {
            string json = string.Empty;
            City model = new City();
            commonBase.CountryId = CountryID;
            ActionResult = commonAction.FindCitiesByCountry(commonBase);
            if (ActionResult.IsSuccess)
            {
                model.Price = Convert.ToDecimal(ActionResult.dtResult.Rows[0].Table.Rows[0].ItemArray[0].ToString());
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCitiesByState(int StateID)
        {
            string json = string.Empty;
            City model = new City();
            commonBase.StateId = StateID;
            ActionResult = commonAction.FindCitiesByState(commonBase);
            if (ActionResult.IsSuccess)
            {
                model.Price = Convert.ToDecimal(ActionResult.dtResult.Rows[0].Table.Rows[0].ItemArray[0].ToString());
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

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

        public JsonResult InstituteLoadByCity(int CityId)
        {
            List<InstituteModel> InstituteModelList = new List<InstituteModel>();
            string json = string.Empty;

            SubmitterRegistration model = new SubmitterRegistration();

            commonBase.CityId = CityId;
            ActionResult = commonAction.Institutes_LoadByCityId(commonBase);
            if (ActionResult.IsSuccess)
            {
                InstituteModelList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InstituteModel>(ActionResult.dtResult);
            }
            model.InstituteModelList = InstituteModelList;

            return Json(model, JsonRequestBehavior.AllowGet);
        }

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

            if (CityList != null)
            {
                model.citylist = CityList.OrderBy(m => m.CityName).ToList();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public List<College> Colleges_LoadAll()
        {
            StudentRegistration model = new StudentRegistration();
            List<College> CollegeList = new List<College>();
            ActionResult = commonAction.Colleges_LoadAll();
            if (ActionResult.IsSuccess)
            {
                CollegeList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<College>(ActionResult.dtResult);
            }

            return CollegeList;
        }

        public ActionResult SubmitterRegistration(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            SubmitterRegistration model = new SubmitterRegistration();
            List<State> StateList = new List<State>();
            List<City> CityList = new List<City>();
            List<SelectListItem> GenderList = new List<SelectListItem>();
            List<InstituteModel> InstituteModelList = new List<InstituteModel>();
            GenderList.Add(new SelectListItem { Text = "Male", Value = "Male" });
            GenderList.Add(new SelectListItem { Text = "Female", Value = "Female" });
            ViewBag.GenderList = GenderList;


            var country = CountryLoad();
            model.Countrylist = country;


            if (model.Countrylist != null && model.Countrylist.Count > 0)
            {

                int countryId = Convert.ToInt32(98);
                model.Country = countryId;
                commonBase.CountryId = countryId;
                ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    StateList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);
                }
            }
            //   model.Country = 98;
            model.statelist = StateList;


            if (model.statelist != null && model.statelist.Count > 0)
            {

                //int StateID = Convert.ToInt32(model.statelist[0].ID);
                int StateID = Convert.ToInt32(2338);
                model.state = Convert.ToString(StateID);
                commonBase.StateId = StateID;
                ActionResult = commonAction.Cities_LoadBy_StateId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    CityList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dtResult);
                }
            }
            model.citylist = CityList;
            model.City = "2";

            commonBase.CityId = 2;

            ActionResult = commonAction.Institutes_LoadByCityId(commonBase);
            if (ActionResult.IsSuccess)
            {
                InstituteModelList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InstituteModel>(ActionResult.dtResult);
            }
            model.InstituteModelList = InstituteModelList;
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://api.myip.com");
                HttpResponseMessage response = client.GetAsync("").Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                   ViewBag.ip =((dynamic)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result)).ip;
                }
            }
            model.Rememberme = true;
            return View(model);
        }
        [HttpPost]
        public ActionResult SubmitterRegistration(SubmitterRegistration model)
        {
            try
            {
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                HttpPostedFileBase pfb = Request.Files["ProfilePicture"];
                if (pfb != null && pfb.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pfb.FileName);
                    string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + fileName;
                    string filePath = System.IO.Path.Combine(HttpContext.Server.MapPath("/Content/Uploads/Users/"), uploadedfilename);
                    pfb.SaveAs(filePath);
                    UserInfoBase.ProfileImage = site + "/Content/Uploads/Users/" + uploadedfilename;

                }
                UserInfoBase.StudentName = model.StudentName != null ? model.StudentName : "";
                UserInfoBase.LastName = model.LastName;
                UserInfoBase.FirstName = model.FirstName;
                UserInfoBase.UserRole = 2;

                UserInfoBase.Address = model.Address;
                UserInfoBase.CollegeId = model.CollegeID;
                UserInfoBase.DOB = model.DOB;

                UserInfoBase.CountryId = model.Country;
                UserInfoBase.StateId = Convert.ToInt32(model.state);
                UserInfoBase.CityId = Convert.ToInt32(model.City);
                try
                {
                    //UserInfoBase.DOB = Convert.ToDateTime(model.DOB).ToString("dd/MM/yyyy");
                    DateTime dt = DateTime.ParseExact(model.DOB, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    UserInfoBase.DOB = dt.ToString();
                }
                catch (Exception ex)
                {
                    ErrorReporting.WebApplicationError(ex);
                }
                UserInfoBase.Gender = model.Gender;

                // UserInfoBase.TeacherName = model.TeacherName;
                //UserInfoBase.ProfileImage = model.Picture;


                //UserInfoBase.countryname=Request.Form["countryname"];
                //ActionResult = UserAction.CountryExistance(UserInfoBase);
                //UserInfoBase.CountryId = Convert.ToInt32(ActionResult.dsResult.Tables[0].Rows[0]["CountryId"]);
                //UserInfoBase.statename = Request.Form["statename"];
                //ActionResult = UserAction.StateExistance(UserInfoBase);
                //UserInfoBase.StateId=Convert.ToInt32(ActionResult.dsResult.Tables[0].Rows[0]["stateid"]);
                //UserInfoBase.cityname= Request.Form["cityname"];
                //ActionResult = UserAction.CityExistance(UserInfoBase);
                //UserInfoBase.CityId = Convert.ToInt32(ActionResult.dsResult.Tables[0].Rows[0]["CityId"]);

                UserInfoBase.MobileNumber = model.MobileNumber;
                UserInfoBase.ISD_Code = model.ISD_Code;
                UserInfoBase.Password = model.Password;
                UserInfoBase.EmailId = model.EmailID;
                UserInfoBase.IsActive = true;

                UserInfoBase.Id = 0;
                ActionResult = UserAction.UsersInfo_InsertUpdate(UserInfoBase);

                if (ActionResult.IsSuccess)
                {
                    //TempData["SuccessMessage"] = "User registered successfully.";

                    ActionResult = UserAction.UsersInfo_Login(UserInfoBase);
                    if (ActionResult.IsSuccess)
                    {
                        Session["Role"] = ActionResult.dtResult.Rows[0]["RoleId"];
                        Session["StudentName"] = ActionResult.dtResult.Rows[0]["StudentFullName"];


                        Session["UserName"] = ActionResult.dtResult.Rows[0]["EmailId"];
                        Session["UserId"] = ActionResult.dtResult.Rows[0]["Id"];
                        Session["ProfileImage"] = ActionResult.dtResult.Rows[0]["ProfileImage"];

                        UserInfoBase.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
                        UserInfoBase.IsActive = false;
                        ActionResult = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
                        return RedirectToAction("Home", "Home");
                    }
                    else
                    {


                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    //TempData["ErrorMessage"] = "Error in Signup please Try Again";
                }


            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SubmitterRegistration");
        }

        public ActionResult SubmitterLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitterLogin(FormCollection fc, SubmitterRegistration model, string returnUrl)
        {
            try
            {
                STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
                UserInfoBase.EmailId = (fc["UserName"] != null ? fc["UserName"].ToString() : (fc["UserName1"] != null ? fc["UserName1"].ToString() : ""));
                UserInfoBase.Password = (fc["LoginPassword"] != null ? fc["LoginPassword"].ToString() : (fc["LoginPassword1"] != null ? fc["LoginPassword1"].ToString() : ""));
                ActionResult = UserAction.UsersInfo_Login(UserInfoBase);
                if (ActionResult.IsSuccess)
                {
                    int response = (ActionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(ActionResult.dtResult.Rows[0][0]) : 0);
                    if (response == -1)
                    {
                        TempData["EmailError"] = "You have entered a wrong Email";
                        // TempData["EmailError"] = "You have entered a wrong Email/Phone";
                    }
                    else if (response == -2)
                    {
                        TempData["PasswordError"] = "You have entered a wrong password";
                    }
                    else if (Convert.ToBoolean(ActionResult.dtResult.Rows[0]["IsActive"]) == true)
                    {
                        Session["Role"] = ActionResult.dtResult.Rows[0]["RoleId"];
                        Session["StudentName"] = ActionResult.dtResult.Rows[0]["StudentFullName"];
                        Session["UserName"] = ActionResult.dtResult.Rows[0]["EmailId"];
                        Session["UserId"] = ActionResult.dtResult.Rows[0]["Id"];
                        Session["ProfileImage"] = ActionResult.dtResult.Rows[0]["ProfileImage"];
                        Session["CountryId"] = ActionResult.dtResult.Rows[0]["CountryId"];
                        Session["StateId"] = ActionResult.dtResult.Rows[0]["StateId"];
                        Session["CityId"] = ActionResult.dtResult.Rows[0]["CityId"];
                        Session["FirstName"] = ActionResult.dtResult.Rows[0]["FirstName"];
                        Session["LastName"] = ActionResult.dtResult.Rows[0]["LastName"];
                        var f = Convert.ToString(Session["FirstName"]);
                        var l = Convert.ToString(Session["LastName"]);
                        var t = Session["CountryId"];
                        UserInfoBase.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
                        UserInfoBase.IsActive = false;
                        ActionResult = UserAction.UsersLoginInfo_Insert_Update(UserInfoBase);
                        if (model.Rememberme)
                        {
                            HttpCookie cookie = new HttpCookie("StudentApp");
                            cookie.Values.Add("Role", Convert.ToString(Session["Role"]));
                            cookie.Values.Add("StudentName", Convert.ToString(Session["StudentName"]));
                            cookie.Values.Add("UserName", Convert.ToString(Session["UserName"]));
                            cookie.Values.Add("UserId", Convert.ToString(Session["UserId"]));
                            cookie.Values.Add("ProfileImage", Convert.ToString(Session["ProfileImage"]));
                            cookie.Expires = DateTime.Now.AddDays(15);
                            Response.Cookies.Add(cookie);
                        }

                        //
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            if (Convert.ToInt32(Session["Role"]) == 1)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                return RedirectToAction("Home", "Home");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(Session["Role"]) == 1)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                return RedirectToLocal(HttpUtility.UrlDecode(returnUrl));
                            }
                        }
                    }
                    else
                    {
                        //TempData["LoginErrorMessage"] = "Your Account is not active. Please contact to administrator";
                        // return RedirectToAction("SubmitterRegistration");
                    }

                }
                else
                {

                    // TempData["ErrorMessage"] = "Invalid Email/Phone or Password";test
                }


            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("SubmitterRegistration");
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }


        public ActionResult ForgotPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ResetPassword model)
        {
            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            String guid = Guid.NewGuid().ToString();
            AccountingSoftware.Helper.Email.SendForgotPasswordEmail(model.UserName, guid);
            UserInfoBase.Guid = guid;
            UserInfoBase.EmailId = model.UserName;
            ActionResult = UserAction.UpdateUsersInfo(UserInfoBase);
            TempData["SuccessMessage"] = "Password Reset link has been sent to your Email address.";
            return View();
        }


        public ActionResult ResetPassword(string id)
        {
            ResetPassword model = new ResetPassword();
            model.Guid = id;
            return View(model);
        }


        [HttpPost]
        public ActionResult ResetPassword(ResetPassword model)
        {
            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            UserInfoBase.Guid = model.Guid;
            UserInfoBase.Password = model.Password;
            ActionResult = UserAction.UpdateUsersInfoPassword(UserInfoBase);
            if (ActionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Your password has been changed successfully.";
                return RedirectToAction("SubmitterRegistration");
            }
            else
            {

                TempData["ErrorMessage"] = "Your link has been expired.";
                return View();
            }

        }

        public JsonResult CheckEmailExist(string email)
        {
            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            UserInfoBase.EmailId = email;


            ActionResult = UserAction.CheckEmailExist(UserInfoBase);
            string jsonString = string.Empty;
            if (ActionResult.dtResult.Rows.Count > 0)
            {
                //jsonString = "{\"Status\":\"1\"}";
                jsonString = "{\"Status\":\"1\"}";
            }
            else
            {
                jsonString = "{\"Status\":\"-1\"}";
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CheckMobileExist(string Mobile)
        {
            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            UserInfoBase.MobileNumber = Mobile;


            ActionResult = UserAction.CheckMobileExist(UserInfoBase);
            string jsonString = string.Empty;
            if (ActionResult.dtResult.Rows.Count > 0)
            {
                //jsonString = "{\"Status\":\"1\"}";
                jsonString = "{\"Status\":\"1\"}";
            }
            else
            {
                jsonString = "{\"Status\":\"-1\"}";
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }


        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }



        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion


        #region Method SendOTP
        public JsonResult SendOTP(string mobileNumber, string messageBody)
        {

            var jsonResponce = "";
            try
            {
                if (mobileNumber != string.Empty)
                {
                    var auth = new TwoStepsAuthenticator.TimeAuthenticator(usedCodeManager: usedCodesManager);
                    messageBody = auth.GetCode(DubleAuthenticationKey);

                    //jsonResponce = StudentAppWebsite.Controllers.UserController.SendSMSToPhone(mobileNumber, messageBody, 0);
                    jsonResponce = Helpers.TwilioHelper.SendSms(mobileNumber,string.Format("Dear customer, your OTP for registration is {0} .From http://notetor.com/", messageBody), "+15163622226");
                    if (jsonResponce != null && jsonResponce.Length > 0)
                    {
                        jsonResponce = "success";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonResponce, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendOTPEmail(string emailId, string messageBody)
        {

            var jsonResponce = "";
            try
            {
                if (emailId != string.Empty)
                {
                    var auth = new TwoStepsAuthenticator.TimeAuthenticator(usedCodeManager: usedCodesManager);
                    messageBody = auth.GetCode(DubleAuthenticationKey);

                    //jsonResponce = StudentAppWebsite.Controllers.UserController.SendSMSToPhone(mobileNumber, messageBody, 0);
                    string issendemail =  AccountingSoftware.Helper.Email.SendOTPEmail(emailId, messageBody);
                    if (issendemail == "true")
                    {
                        jsonResponce = "success";
                    }
                    else
                    {
                        jsonResponce = issendemail;
                    } 
                }
            }
            catch (Exception ex)
            {
                jsonResponce = ex.Message;
                // throw ex;
            }
            return Json(jsonResponce, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Method VerifyPhone
        public JsonResult VerifyPhone(string OTP)
        {

            var jsonResponce = "0";
            try
            {
                if (OTP != string.Empty)
                {
                    var auth = new TwoStepsAuthenticator.TimeAuthenticator(usedCodeManager: usedCodesManager);
                    if (auth.CheckCode(DubleAuthenticationKey, OTP))
                    {
                        jsonResponce = "1";
                    }
                    else
                    {
                        jsonResponce = "0";
                    }
                }
                else
                {
                    jsonResponce = "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonResponce, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}

