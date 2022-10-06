using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using STU.ActionLayer.Common;
using StudentAppWebsite.Models;
using Newtonsoft.Json;
using STU.BaseLayer.Common;
using STU.ActionLayer.User;
using STU.BaseLayer.User;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using STU.ActionLayer.Advertisement;
using System.Text;
using System.Globalization;
using STU.ActionLayer.Book;
using STU.BaseLayer.Book;
using STU.BaseLayer.Advertisement;
using WebMatrix.WebData;
using NReco.PdfGenerator;

namespace StudentAppWebsite.Controllers.api.Common
{
    public class CommonController : ApiController
    {
        ApiResponseModel resmodel = new ApiResponseModel();
        CommonAction commonAction = new CommonAction();
        CommonBase commonBase = new CommonBase();
        UserAction UserActions = new UserAction();
        BookAction bookAction = new BookAction();
        BookBase bookBase = new BookBase();
        AdvertisementAction advertisementaction = new AdvertisementAction();
        static string GCMKey = System.Configuration.ConfigurationManager.AppSettings["GCMServerKey"].ToString();


        #region GetCountryDetail
        [HttpGet]
        public ApiResponseModel GetCountryDetail(int userid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<CurrencyRate> CurrencyList = new List<CurrencyRate>();
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = userid;
                var Ratedata = UserActions.GetCountryDetail(usersInfoBase);
                if (Ratedata.IsSuccess == true)
                {
                    CurrencyList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<CurrencyRate>(Ratedata.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "success";
                    resmodel.ResponseData = JsonConvert.SerializeObject(CurrencyList);
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

        #region Load Country
        [HttpGet]
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
        #endregion

        #region LoadStateByCountryId
        [HttpGet]
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

        #endregion

        #region LoadCityByStateId
        [HttpGet]
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
        #endregion

        #region Notesbook_Pages
        [HttpGet]
        public ApiResponseModel Notesbook_Pages(int BookId)
        {
            try
            {
                List<NotebookForm> NotebookFormList = new List<NotebookForm>();

                var data = commonAction.Notesbook_Load_ById(new CommonBase { NotebookId = BookId });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
               //     var Bookdata = bookAction.GetPageDetails_ByBookId(new BookBase { BookId = BookId });

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

        #region SubjectLoad
        [HttpGet]
        public ApiResponseModel SubjectLoad()
        {
            try
            {
                List<Subjects> Subjectslist = new List<Subjects>();
                var data = commonAction.Subjects_LoadAll();
                if (data.IsSuccess == true)
                {
                    Subjectslist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(data.dtResult);
                    Subjectslist.Where(m => m.Status == true).ToList();
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(Subjectslist);
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

        #region Streams_LoadAll
        [HttpGet]
        public ApiResponseModel StreamLoad()
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<StudentAppWebsite.Models.Stream> Streamlist = new List<StudentAppWebsite.Models.Stream>();
                var data = commonAction.Streams_LoadAll();
                if (data.IsSuccess == true)
                {
                    Streamlist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<StudentAppWebsite.Models.Stream>(data.dtResult);
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(Streamlist);
                }
                else
                {
                    resmodel.IsSuccess = false;
                    resmodel.IsError = true;
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

        #region ChaptersLoad

        [HttpGet]
        public ApiResponseModel ChaptersLoad()
        {
            try
            {
                resmodel = new ApiResponseModel();

                var data = commonAction.Chapters_LoadAll();
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
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return resmodel;
        }
        #endregion

        #region Notesbook_LoadAll
        [HttpGet]
        public ApiResponseModel Notesbook_LoadAll()
        {
            try
            {
                resmodel = new ApiResponseModel();

                var data = commonAction.Notesbook_LoadAll();
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
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return resmodel;
        }

        #endregion

        #region Colleges_LoadAll
        [HttpGet]
        public ApiResponseModel Colleges_LoadAll()
        {
            try
            {
                resmodel = new ApiResponseModel();

                var data = commonAction.Colleges_LoadAll();
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
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return resmodel;
        }


        #endregion

        #region Category_Loadall
        [HttpGet]
        public ApiResponseModel CategoryLoad()
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<Categories> CategoryList = new List<Categories>();
                var data = commonAction.Categories_LoadAll();
                if (data.IsSuccess)
                {
                    CategoryList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Categories>(data.dtResult);
                    CategoryList = CategoryList.Where(m => m.Status = true).ToList();
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(CategoryList);
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

        #region Institutes_LoadByCityId
        [HttpGet]
        public ApiResponseModel Institutes_LoadByCityId(int cityId)
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<Categories> CategoryList = new List<Categories>();
                var data = commonAction.Institutes_LoadByCityId(new CommonBase { CityId = cityId });
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

        #region UserInfo_LoadById
        [HttpGet]
        public ApiResponseModel UserProfile(int id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.UserInfo_LoadById(new CommonBase { Id = id });
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

        #region NotebookDetails_Insert
        [HttpPost]
        public ApiResponseModel NotebookDetails_Insert(NoteBookModels NoteBook)
        {
            try
            {
                resmodel = new ApiResponseModel();
                if (string.IsNullOrEmpty(NoteBook.SubjectName))
                {
                    commonBase.StreamId = 53;
                    commonBase.SubjectName = NoteBook.NewSubject;
                    var subjectdata = commonAction.Subject_InsertUpdate(commonBase);
                    string Newsubjectid = Convert.ToString(subjectdata.dtResult.Rows[0].ItemArray[0]);
                    commonBase.SubjectName = Newsubjectid;
                }
                else
                {
                    commonBase.SubjectName = NoteBook.SubjectName;
                }
                commonBase.UserId = NoteBook.UserId;
               
                commonBase.MonetoryAdvantages = NoteBook.MonetoryAdvantages;
                commonBase.Innovation_Investment = NoteBook.Innovation_Investment;
                // DateTime dt = DateTime.ParseExact(Convert.ToString(NoteBook.StartDate), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                commonBase.StartDate = NoteBook.StartDate;
                commonBase.Visible_Hidden = NoteBook.Visible_Hidden;
                var data = commonAction.NotebookDetails_Insert(commonBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Submmited";
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

        #region NotebookDetails_Update
        [HttpPost]
        public ApiResponseModel NotebookDetails_Update(NoteBookModels NoteBook)
        {
            try
            {
                resmodel = new ApiResponseModel();
                if (string.IsNullOrEmpty(NoteBook.SubjectName))
                {
                    commonBase.StreamId = 53;
                    commonBase.SubjectName = NoteBook.NewSubject;
                    var subjectdata = commonAction.Subject_InsertUpdate(commonBase);
                    string Newsubjectid = Convert.ToString(subjectdata.dtResult.Rows[0].ItemArray[0]);
                    commonBase.SubjectName = Newsubjectid;
                }
                else
                {
                    commonBase.SubjectName = NoteBook.SubjectName;
                }
                commonBase.MonetoryAdvantages = NoteBook.MonetoryAdvantages;
                commonBase.Innovation_Investment = NoteBook.Innovation_Investment;
                commonBase.Visible_Hidden = NoteBook.Visible_Hidden;
                commonBase.StartDate = NoteBook.StartDate;
                commonBase.Id = NoteBook.BookId;
                commonBase.UserId = NoteBook.UserId;                
               var data = commonAction.NotebookDetails_Update(commonBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Submmited";
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

        #region Delete_NotebookForm
        [HttpGet]
        public ApiResponseModel Delete_NotebookForm(int id, int bookid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.NotebookDetails_Delete(new CommonBase { UserId = id, Id = bookid });
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

        # region NotebookLoadById
        [HttpGet]
        public ApiResponseModel NotebookLoadById(int Userid, int id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.NotebookLoadById(new CommonBase { UserId = Userid, Id = id });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dsResult.Tables[1]);
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

        #region SearchBooksByName
        [HttpGet]
        public ApiResponseModel SearchBooksByName(string Text)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.SearchBooksByName(new CommonBase { Text = Text });
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

        #region SearchBooksByName
        [HttpGet]
        public ApiResponseModel SearchBooksByUserText(string Text, int pageno)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.SearchBooksByUserText(new CommonBase { Text = Text, PageNo = pageno });
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

        #region FriendList_LoadByUserId
        [HttpGet]
        public ApiResponseModel FriendListLoadByUserId(int userid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.FriendList_LoadByUserId(new CommonBase { Id = userid });
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

        #region FriendRequest_LoadByUserId
        [HttpGet]
        public ApiResponseModel FriendRequest_LoadByUserId(int userid)
        {

            try
            {
                List<Friend> FriendRequests = new List<Friend>();
                List<Friend> FriendList = new List<Friend>();
                resmodel = new ApiResponseModel();
                var data = commonAction.FriendRequest_LoadByUserId(new CommonBase { Id = userid });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                    //FriendRequests = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(data.dtResult);
                    //int count = FriendRequests.Count;
                    //int[] CurrentUserfriendIds = new int[count];
                    //int[] CurrentUserFriendRequestIds = new int[count];
                    //string[] friendStatus = new string[count];
                    //int PageId = 230337;
                    //if (FriendRequests.Count > 0)
                    //{
                    //    int i = 0;
                    //    foreach (var item in FriendRequests)
                    //    {
                    //        CurrentUserfriendIds[i] = ((item.id) > 0) ? Convert.ToInt32(item.id) : 0;
                    //        CurrentUserFriendRequestIds[i] = ((item.FriendRequestId) > 0) ? Convert.ToInt32(item.FriendRequestId) : 0;
                    //        friendStatus[i] = (!String.IsNullOrEmpty(item.Status) ? (item.Status).ToString() : "");
                    //        i++;
                    //    }
                    //}

                    //var index1 = Array.IndexOf(CurrentUserfriendIds, 0);
                    //var status1 = "";
                    //var friendRequestId1 = 0;
                    //if (index1 > -1)
                    //{
                    //    status1 = friendStatus[index1];
                    //    friendRequestId1 = CurrentUserFriendRequestIds[index1];
                    //}
                    //var fri = commonAction.FriendList_LoadByUserId(new CommonBase { Id = userid });
                    //FriendList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(fri.dtResult);
                    //foreach (var item in FriendList)
                    //{
                    //    if (item.id != Convert.ToInt32(userid))
                    //    {
                    //        var index2 = Array.IndexOf(CurrentUserfriendIds, item.id);
                    //        int CurrentUserFriendRequestIds2 = 0;
                    //        if (index2 > -1)
                    //        {
                    //            CurrentUserFriendRequestIds2 = CurrentUserFriendRequestIds[index2];
                    //        }

                    //        if (PageId != 0)
                    //        {
                    //            string[] blank = { };
                    //            var PageIds = String.IsNullOrEmpty(item.PageId) ? blank : item.PageId.Split(',');
                    //            var index = Array.IndexOf(PageIds, PageId);
                    //            if (index > -1)
                    //            {

                    //                Console.WriteLine(" Invitation sent");


                    //            }
                    //            else
                    //            {
                    //                Console.WriteLine(" Send invitation");

                    //            }
                    //        }
                    //        else
                    //        {
                    //            var index = Array.IndexOf(CurrentUserfriendIds, item.id);
                    //            if (index > -1)
                    //            {
                    //                var status = friendStatus[index];
                    //                var CurrentUserFriendRequestIds1 = CurrentUserFriendRequestIds[index];
                    //                if (status == "1")
                    //                {
                    //                    Console.WriteLine("Unfriend");
                    //                }
                    //                else
                    //                {
                    //                    if (status == "2")
                    //                    {
                    //                        Console.WriteLine("Send friend request");
                    //                    }
                    //                    else
                    //                    {
                    //                        Console.WriteLine("Friend request sent");
                    //                    }

                    //                }
                    //            }
                    //            else
                    //            {
                    //                Console.WriteLine("Send friend request");
                    //            }

                    //        }

                    //    }

                    //}
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

        #region BookContentLoadByBookId
        [HttpGet]
        public ApiResponseModel BookContentLoadByBookId(int bookid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.BookContentLoadByBookId(new CommonBase { Id = bookid });
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

        [System.Web.Http.HttpPost]
        public ApiResponseModel convertpdf([FromBody]HtmlToPdf htmlTopdf)
        {
            string html = htmlTopdf.html; string filename = htmlTopdf.filename; string cover = htmlTopdf.cover;
            string filePath = HttpContext.Current.Server.MapPath("~/Content/" + filename + ".pdf");
            string path = HttpContext.Current.Server.MapPath("~/Content/" + filename + ".html");
            try
            {
                resmodel = new ApiResponseModel();
               
                // Create the file.
                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        try
                        {
                            System.IO.File.Delete(path);
                            try { if (System.IO.File.Exists(filePath)) { System.IO.File.Delete(filePath); } }
                            catch (Exception ex) { }
                        }
                        catch (Exception ex)
                        {
                            //Do something
                        }
                    }
                    //Create the file.
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(html);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                    }

                    //var styles = "p.MsoFooter, li.MsoFooter, div.MsoFooter{margin:0in; margin-bottom:.0001pt; mso-pagination:widow-orphan;  tab-stops:center 3.0in right 6.0in; font-size:12.0pt;}</style><style><!-- / Style Definitions /@page Section1{ size:8.5in 11.0in; margin:1.0in 1.0in 1.0in 1.0in;  mso-header-margin:.5in;  mso-footer-margin:.5in;  mso-title-page:yes;  mso-header: h1;   mso-footer: f1;   mso-first-header: fh1;   mso-first-footer: ff1;  mso-paper-source:0;} div.Section1{ page:Section1; } table#hrdftrtbl{ margin:0in 0in 0in 900in; width:1px; height:1px; overflow:hidden;}--></style>";
                    var coverHTML =  cover;
                    //var headerHtml = "<div style='text-align: center;'><div style='color: #B22222; font-family: calibri (body); font-size: 20pt; font-weight: bold;'><div style='min-height:500px'></div>COMMERCIAL-IN-CONFIDENCE</div></div><div>&nbsp</div>";
                    var htmlContent = String.Format(html,
        DateTime.Now);
                    //var footerHtml = "<table style='width: 100%;margin-bottom:25px'><tr><td><div style='float: left;margin-left:0px;'><img alt='' src='" + HttpContext.Current.Server.MapPath("/Content/images/logo-small.jpg") + "' style='height: 25px; width: 100px' /></div></td><td  style='text-align: right'><span style='mso-tab-count: 2'></span><div style='text-align:right'>Page <span class='page'></span> of <span class='topage'> </span> </div></td></tr></table>";
                    //var footerHtml = " <p><img alt='' src='" + ReportingSection + "/Content/images/logo-small.jpg' style='height: 20px; width: 90px' text-align:left; /><span style='mso-tab-count: 2'></span><div style='text-align:right'>Page <span class='page'></span> of <span class='topage'></span></div></div></p>";
                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();

                    //htmlToPdf.CustomWkHtmlArgs = "toc-header-font-size 35";
                    //htmlToPdf.TocHeaderText = "Contents";

                    //// various parameters get set here
                    //htmlToPdf.PageHeaderHtml = html;

                    htmlToPdf.GenerateToc = false;
                    var margins = new NReco.PdfGenerator.PageMargins();

                    margins.Top = 15;
                    margins.Bottom = 15;
                    margins.Left = 20;
                    margins.Right = 20;

                    htmlToPdf.Margins = margins;
                    //htmlToPdf.GeneratePdfFromFile(path, coverHTML, filePath);
                    var pdfBytes = htmlToPdf.GeneratePdf(htmlContent,cover);
                    if (System.IO.File.Exists(filePath))
                    {
                        FileInfo myFile = new FileInfo(filePath);
                        myFile.IsReadOnly = false;
                    }
                    System.IO.FileStream file = System.IO.File.Create(filePath);
                    file.Write(pdfBytes, 0, pdfBytes.Length);
                    file.Close();
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = "/Content/" + filename + ".pdf";
                    return resmodel;
                    //return File(filePath, contentType, "ProcheckupReport.pdf");
                   
                }
                catch (Exception ex)
                {
                }
            }
            catch(Exception ex)
            {

            }
           
                return resmodel;
        }
        #region StreamsLoadByCategoryId
        [HttpGet]
        public ApiResponseModel StreamsLoadByCategoryId(int CategoryID)
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<HomeModel> StreamList = new List<HomeModel>();
                var data = commonAction.StreamsLoadByCategoryID(new CommonBase { Id = CategoryID });
                if (data.IsSuccess == true)
                {
                    StreamList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<HomeModel>(data.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(StreamList);
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

        #region InstitutesLoadByStreamID
        [HttpGet]
        public ApiResponseModel InstitutesLoadByStreamID(int StreamId, int? CityId)
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<InstituteModel> instituteNewList = new List<InstituteModel>();
                List<Subjects> SubjectList = new List<Subjects>();
                commonBase.Id = StreamId;
                commonBase.CityId = CityId;
                var data = commonAction.InstitutesLoadByStreamID(commonBase);
                if (data.IsSuccess == true)
                {
                    instituteNewList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InstituteModel>(data.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(instituteNewList);
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

        #region FriendrequestList
        [HttpGet]
        public ApiResponseModel FriendRequestList(int id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.NotificationsCount(new CommonBase { UserId = id });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dsResult.Tables[2]);
                }
                else
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
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

        #region NotificationsCount1
        [HttpGet]
        public ApiResponseModel NotificationList1(int id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                CommonBase commonBase = new CommonBase();
                commonBase.UserId = id;
                var data = commonAction.NotificationsCount(commonBase);

                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dsResult.Tables[1]);
                }
                else
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
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

        #region NotificationsCount
        [HttpGet]
        public ApiResponseModel NotificationList(int id)
        {
            try
            {

                resmodel = new ApiResponseModel();
                var data = commonAction.NotificationsCount(new CommonBase { UserId = id });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                   
                    string data1 = string.Empty;
                    string notifications = string.Empty;
                    string friendRequests = string.Empty;
                    string json = string.Empty;

                    if (data.dsResult.Tables.Count > 0)
                        data1 = Newtonsoft.Json.JsonConvert.SerializeObject((data.dsResult.Tables[0].Rows.Count > 0 ? data.dsResult.Tables[0].Rows.Cast<System.Data.DataRow>().Take(5).CopyToDataTable() : data.dsResult.Tables[0]));

                    if (data.dsResult.Tables.Count > 1)
                        notifications = Newtonsoft.Json.JsonConvert.SerializeObject((data.dsResult.Tables[1].Rows.Count > 0 ? data.dsResult.Tables[1].Rows.Cast<System.Data.DataRow>().Take(5).CopyToDataTable() : data.dsResult.Tables[1]));

                    if (data.dsResult.Tables.Count > 2)
                        friendRequests = Newtonsoft.Json.JsonConvert.SerializeObject((data.dsResult.Tables[2].Rows.Count > 0 ? data.dsResult.Tables[2].Rows.Cast<System.Data.DataRow>().Take(5).CopyToDataTable() : data.dsResult.Tables[2]));

                    json = "{\"Status\":\"1\",\"data\":" + data1 + ",\"notifications\":" + notifications + ",\"friendRequests\":" + friendRequests + "}";

                    resmodel.ResponseData = json;
                 
                }
                else
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
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

        #region Send message
        [HttpPost]
        public ApiResponseModel SendMessages(int pageno, int bookid, int userid, string Student_Name)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var Subject = "";
                var Submitter = "";
                var Inviter = "";
                var url = ConfigurationManager.AppSettings["site"].ToString() + "/Home/Index?PageId=" + pageno + "&BookId=" + bookid + "";
                // url = "http://www.notetor.com/Home/Index?PageId=" + pageno + "&BookId=" + bookid + "";
                url = HttpUtility.UrlEncode(url);
                //var url = "<a href=\"" + url1 + "\">" + url1 + "</a>";
                Messages model = new Messages();
                CommonBase commonBase = new CommonBase();
                commonBase.Id = userid;
                Inviter = Student_Name;
                commonBase.NotebookId = bookid;
                var data = commonAction.Notesbook_Load_ById(commonBase);
                var data1 = commonAction.Message_Load(commonBase);
                if (data.IsSuccess == true && data1.IsSuccess == true)
                {
                    Subject = Convert.ToString(data.dtResult.Rows[0]["SubjectName"]);
                    Submitter = Convert.ToString(data.dtResult.Rows[0]["StudentName"]);
                    model.Message = string.Format(Convert.ToString(data1.dtResult.Rows[0]["Message"]), Inviter, Subject, Submitter, url);
                    model.Id = Convert.ToInt32(data1.dtResult.Rows[0]["Id"]);
                    model.count = data1.dtResult.Rows.Count > 1 ? Convert.ToInt32(data1.dtResult.Rows[1]["MessageCount"]) : 0;
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(model);
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

        #region Master_Categories_LoadAllPrice

        [HttpGet]
        public ApiResponseModel Master_Categories_LoadAllPrice()
        {
            try
            {
                resmodel = new ApiResponseModel();

                var data = commonAction.Master_Categories_LoadAllPrice();
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

        #region Notesbooks_Bind
        [HttpGet]
        public ApiResponseModel Notesbooks_Bind(int pageno, int userid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                List<NotebookForm> NotebookFormlist = new List<NotebookForm>();
                int PageNo = pageno;
                int Offset = 5;
                var data = commonAction.Notesbook_LoadBy_OFFSET(PageNo, Offset, userid);
                if (data.IsSuccess == true)
                {
                    NotebookFormlist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(data.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "success";
                    resmodel.ResponseData = JsonConvert.SerializeObject(NotebookFormlist);
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

        #region GetUsersList_ByCityId

        [HttpGet]
        public ApiResponseModel GetUsersList_ByCityId(int cityid)
        {
            try
            {
                resmodel = new ApiResponseModel();

                var data = commonAction.GetUsersList_ByCityId(new CommonBase { CityId = cityid });
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

        #region uploadPic
        public HttpResponseMessage uploadPic()

        {

            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)

            {

                var docfiles = new List<string>();

                foreach (string file in httpRequest.Files)

                {

                    var postedFile = httpRequest.Files[file];

                    var filePath = HttpContext.Current.Server.MapPath("~/Content/Uploads/Ads/" + postedFile.FileName);

                    postedFile.SaveAs(filePath);



                    docfiles.Add(filePath);

                }

                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);

            }

            else

            {

                result = Request.CreateResponse(HttpStatusCode.BadRequest);

            }

            return result;

        }
        #endregion

        #region Method SendSMSToPhone
        [HttpPost]
        public string SendSMSToPhone(string mobileNumbers, string messageBody, int messageCount)
        {

            var jsonResponce = "";
            ///////////new sms api 
            //Your authentication key
            string authKey = ConfigurationManager.AppSettings["authkey"].ToString();
            //Multiple mobiles numbers separated by comma
            string mobileNumber = Convert.ToString(mobileNumbers);
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = ConfigurationManager.AppSettings["senderId"].ToString();
            //Your message to send, Add URL encoding here.
            string message = "StudentsNoteBooks " + HttpUtility.UrlEncode(messageBody);
            var jsonResponse = "";

            try
            {
               
                jsonResponse = Helpers.TwilioHelper.SendSms(mobileNumber, messageBody, "+15163622226");
                //resmodel = new ApiResponseModel();
                ////Call Send SMS API

                //// *Changes URL*
                ////string sendSMSUri = "http://sms.tejarat.in/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

                //// **New Url**
                //string sendSMSUri = "http://dndsms.dit.asia/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";


                ////Create HTTPWebrequest
                //HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);

                ////Specify post method
                //httpWReq.Method = "GET";

                ////Get the response
                //HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                //StreamReader reader = new StreamReader(response.GetResponseStream());
                //string responseString = reader.ReadToEnd();
                //jsonResponce = responseString;

                ////Close the response
                //reader.Close();
                //response.Close();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message.ToString());
                // ErrorReporting.WebApplicationError(ex);
                throw (ex);
            }
            return jsonResponse;
        }

        #endregion

        #region AdBulkSmsSend_ForAd
        [HttpPost]
        public string AdBulkSmsSend_ForAd(string mobileNumbers, int messageCount)
        {
            var jsonResponse = "";
            for (int i = 0; i < messageCount; i++)
            {
                var messageBody = "Hello hy  " + ConfigurationManager.AppSettings["site"].ToString() + "";
               
                //string authKey = ConfigurationManager.AppSettings["authkey"].ToString();
                //Multiple mobiles numbers separated by comma
                string mobileNumber = mobileNumbers;
                ////Sender ID,While using route4 sender id should be 6 characters long.
                //string senderId = ConfigurationManager.AppSettings["senderId"].ToString();
                ////Your message to send, Add URL encoding here.
                //string message = HttpUtility.UrlEncode(messageBody);


                try
                {
                    
                    jsonResponse = Helpers.TwilioHelper.SendSms(mobileNumber, messageBody, "+15163622226");
                    ////Call Send SMS API
                    ////string sendSMSUri = "http://sms.tejarat.in/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

                    //string sendSMSUri = "http://dndsms.dit.asia/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

                    ////Create HTTPWebrequest
                    //HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);

                    ////Specify post method
                    //httpWReq.Method = "GET";

                    ////Get the response
                    //HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                    //StreamReader reader = new StreamReader(response.GetResponseStream());
                    //string responseString = reader.ReadToEnd();
                    ////Close the response
                    //res = responseString;
                    //reader.Close();
                    //response.Close();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message.ToString());
                    // ErrorReporting.WebApplicationError(ex);
                    throw (ex);
                }
            }
            return jsonResponse;

        }
        #endregion

        #region Method CheckCardNumber
        [HttpGet]
        public bool CheckCardNumber(string cardNumber)
        {
            try
            {
                string exp = "^[0-9]{1,20}$";
                Regex expRegex = new Regex(exp);
                if (expRegex.IsMatch(cardNumber))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
                //ErrorReporting.WebApplicationError(ex);
            }
            return false;
        }
        #endregion

        #region Method CheckCardExpiration
        [HttpGet]
        private bool CheckCardExpiration(int slectedYear, int selectedMonth)
        {
            try
            {
                int month = Convert.ToInt32(System.DateTime.Today.Month.ToString());
                int year = Convert.ToInt32(System.DateTime.Today.Year.ToString());

                if (slectedYear < year)
                {
                    return false;

                }
                else if (slectedYear == year)
                {
                    if (selectedMonth < month)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }
        #endregion
        
        #region AccountSettings

        [HttpGet]
        public ApiResponseModel GetPageList_ByUserId(int userid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = advertisementaction.GetPageList_ByUserId(new STU.BaseLayer.Advertisement.AdvertisementBase { userId = userid });
                if (data.IsSuccess == true)
                {
                    //var page = data.dsResult.Tables[0];
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dsResult.Tables[0]);
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

        #region SendPushNotification
        public static void SendPushNotification(string token, string message, string type, string bookId = "0", string pageId = "0")
        {
            try
            {
                var postData = "{\"data\" : {\"title\" : \"" + message + "\",\"type\":\"" + type + "\",\"bookId\":\"" + bookId + "\",\"pageId\":\"" + pageId + "\"},\"registration_ids\":[" + token + "]}";

                var data = Encoding.ASCII.GetBytes(postData);

                var request = (HttpWebRequest)WebRequest.Create("https://gcm-http.googleapis.com/gcm/send");

                request.Headers.Add(string.Format("Authorization: key=" + GCMKey + ""));

                request.Method = "POST";
                request.ContentType = "application/json;";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //TempData["SuccessMessage"] = "Push notification sent to the selected customers.";
            }
            catch (Exception ex)
            {
                //TempData["ErrorMessage"] = "Some error occured. Please try again.";
            }
        }
        #endregion

        #region LoadAll Currency_List

        [HttpGet]
        public ApiResponseModel CurrencyList_LoadAll()
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.CurrencyList_LoadAll();
                if (data.IsSuccess == true)
                {
                    //var page = data.dsResult.Tables[0];
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

        #region CurrencyCode_LoadByUserId
        [HttpGet]
        public ApiResponseModel CurrencyCode_LOadByUserId(int id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = commonAction.Get_users_Country_CurrencyCodeandRate(new CommonBase { Id = id });
                if (data.IsSuccess == true)
                {
                    //var page = data.dsResult.Tables[0];
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

        #region Paypaldetails
        [HttpGet]
        public ApiResponseModel Paypaldetails(int userId)
        {
            resmodel = new ApiResponseModel();
            commonBase.Id = userId;
            var Data = commonAction.Paypaldetails(commonBase);
            if (Data.IsSuccess == true)
            {
                resmodel.IsSuccess = true;
                resmodel.IsError = false;
                resmodel.Message = "Success";
                resmodel.ResponseData = JsonConvert.SerializeObject(Data.dtResult);
            }
            else
            {
                resmodel.IsSuccess = false;
                resmodel.IsError = true;
                resmodel.Message = "Failure";
                resmodel.ResponseData = "[]";
            }
            return resmodel;

        }
        #endregion

        #region Wallet_ByuserId
        [HttpGet]
        public ApiResponseModel Wallet_ByuserId(int userId)
        {
            resmodel = new ApiResponseModel();
            commonBase.Id = userId;
            var Data = commonAction.Update_Wallet_ByuserId(commonBase);
            if (Data.IsSuccess == true)
            {
                resmodel.IsSuccess = true;
                resmodel.IsError = false;
                resmodel.Message = "Success";
                resmodel.ResponseData = JsonConvert.SerializeObject(Data.dtResult);
            }
            else
            {
                resmodel.IsSuccess = false;
                resmodel.IsError = true;
                resmodel.Message = "Failure";
                resmodel.ResponseData = "[]";
            }
            return resmodel;

        }
        #endregion

        #region Wallet_ByuserId
        [HttpGet]
        public ApiResponseModel ShowpaypalEmail_IU(int userId)
        {
            resmodel = new ApiResponseModel();
            commonBase.Id = userId;

            var Data = commonAction.Paypaldetails(commonBase);
            if (Data.IsSuccess == true)
            {
                resmodel.IsSuccess = true;
                resmodel.IsError = false;
                resmodel.Message = "Success";
                resmodel.ResponseData = JsonConvert.SerializeObject(Data.dtResult);
            }
            else
            {
                resmodel.IsSuccess = false;
                resmodel.IsError = true;
                resmodel.Message = "Failure";
                resmodel.ResponseData = "[]";
            }
            return resmodel;

        }
        #endregion

        #region Paypaldetails_Insert_Update
        [HttpPost]
        public ApiResponseModel Paypaldetails_Insert_Update(int userId,string EmailId)
        {
            resmodel = new ApiResponseModel();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.userId = userId;
            advertisementbase.EmailId = EmailId;
            var Data = advertisementaction.Paypaldetails_Insert_Update(advertisementbase);
            if (Data.IsSuccess == true)
            {
                resmodel.IsSuccess = true;
                resmodel.IsError = false;
                resmodel.Message = " Successfully Saved PayPal-Email.";
                resmodel.ResponseData = JsonConvert.SerializeObject(Data.dtResult);
            }
            else
            {
                resmodel.IsSuccess = false;
                resmodel.IsError = true;
                resmodel.Message = "Error in saving your PayPal-Email. Please try again later.";
                resmodel.ResponseData = "[]";
            }
            return resmodel;

        }
        #endregion

        #region LoadPaymentRequestList
        [HttpGet]
        public ApiResponseModel LoadPaymentRequestList(int userId)
        {
            resmodel = new ApiResponseModel();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            advertisementbase.userId = userId;
            var Data = advertisementaction.PaymentRequest_LoadByUserId(advertisementbase);
            if (Data.IsSuccess == true)
            {
                resmodel.IsSuccess = true;
                resmodel.IsError = false;
                resmodel.Message = "Success";
                resmodel.ResponseData = JsonConvert.SerializeObject(Data.dtResult);
            }
            else
            {
                resmodel.IsSuccess = false;
                resmodel.IsError = true;
                resmodel.Message = "Failure";
                resmodel.ResponseData = "[]";
            }
            return resmodel;

        }
        #endregion

        #region Method SendSMSToMobile
        [HttpGet]
        public ApiResponseModel  SendSMSToMobile(string mobileNumbers, string messageBody, string messageCount)
        {
            resmodel = new ApiResponseModel();
            var jsonResponce = "";
            ///////////new sms api 
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
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        [HttpGet]
        public ApiResponseModel StatusFriendRequest_LoadByUserId(int userid,int Id)
        {

            try
            {
                var PageId = "0";
                ManageProfile model = new ManageProfile();
                List<Friend> FriendRequests = new List<Friend>();
                List<Friend> FriendList = new List<Friend>();
                commonBase.Id = Convert.ToInt32(Id) == 0 ? userid : Convert.ToInt32(Id); ;
                resmodel = new ApiResponseModel();
                var frienddata = commonAction.FriendList_LoadByUserId(commonBase);
                if (frienddata.IsSuccess)
                {
                    FriendList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(frienddata.dtResult);
                }
                model.lstFriends = FriendList;
                commonBase.Id = userid;
                var FriendRequestdata = commonAction.FriendRequest_LoadByUserId(commonBase);
                if (FriendRequestdata.IsSuccess)
                {
                    FriendRequests = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(FriendRequestdata.dtResult);
                }
                model.FriendRequests = FriendRequests;
                if (model.lstFriends != null || model.FriendRequests != null)
                {
                    int count = model.FriendRequests.Count;
                    int[] CurrentUserfriendIds = new int[count];
                    int[] CurrentUserFriendRequestIds = new int[count];
                    string[] friendStatus = new string[count];

                    if (model.FriendRequests.Count > 0)
                    {
                        int i = 0;
                        foreach (var item in model.FriendRequests)
                        {
                            CurrentUserfriendIds[i] = ((item.id) > 0) ? Convert.ToInt32(item.id) : 0;
                            CurrentUserFriendRequestIds[i] = ((item.FriendRequestId) > 0) ? Convert.ToInt32(item.FriendRequestId) : 0;
                            friendStatus[i] = (!String.IsNullOrEmpty(item.Status) ? (item.Status).ToString() : "");
                            i++;
                        }
                    }

                    var index1 = Array.IndexOf(CurrentUserfriendIds, userid);
                    var status1 = "";
                    var friendRequestId1 = 0;
                    if (index1 > -1)
                    {
                        status1 = friendStatus[index1];
                        friendRequestId1 = CurrentUserFriendRequestIds[index1];
                    }
                    if (model.lstFriends.Count > 0)
                    {
                        foreach (var item in model.lstFriends)
                        {
                            if (item.id != userid)
                            {
                                var index2 = Array.IndexOf(CurrentUserfriendIds, item.id);
                                int CurrentUserFriendRequestIds2 = 0;
                                if (index2 > -1)
                                {
                                    CurrentUserFriendRequestIds2 = CurrentUserFriendRequestIds[index2];
                                }

                            }

                            if (PageId != "0")
                            {
                                string[] blank = { };
                                var PageIds = String.IsNullOrEmpty(item.PageId) ? blank : item.PageId.Split(',');
                                var index = Array.IndexOf(PageIds, PageId);
                                if (index > -1)
                                {
                                    Console.WriteLine("Invitation sent");
                                }
                                else
                                {
                                    Console.WriteLine("Send invitation");
                                }
                            }
                            else
                            {
                                var index = Array.IndexOf(CurrentUserfriendIds, item.id);

                                if (index > -1)
                                {
                                    var status = friendStatus[index];
                                    var CurrentUserFriendRequestIds1 = CurrentUserFriendRequestIds[index];
                                    if (status == "1")
                                    {
                                        resmodel.Message = "Unfriend";
                                    }
                                    else
                                    {
                                        if (status == "2")
                                        {
                                            resmodel.Message = " Send friend request";
                                        }
                                        else
                                        {
                                            resmodel.Message = "  Friend request sent";
                                        }
                                    }
                                }
                                else
                                {
                                    resmodel.Message = " Send friend request ";
                                }
                            }
                            //message
                        }
                    }
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

          #region Setting
        [HttpPost]
        public ApiResponseModel Setting(int userId,string Email,string Password, string contact)
        {
            resmodel = new ApiResponseModel();
            commonBase.UserId = userId;
            commonBase.Email = Email;
            commonBase.Password = Password;
            commonBase.ContactNo = contact;
            var Data = commonAction.Setting(commonBase);
            if (Data.IsSuccess == true)
            {
                resmodel.IsSuccess = true;
                resmodel.IsError = false;
                resmodel.Message = "Success";
                resmodel.ResponseData = "Profile Updated";
            }
            else
            {
                resmodel.IsSuccess = false;
                resmodel.IsError = true;
                resmodel.Message = "Failure";
                resmodel.ResponseData = "Failed to Update Profile ";
            }
            return resmodel;

        }
        #endregion

        #region DeleteAccount
        [HttpPost]
        public ApiResponseModel DeleteAccount(int userId)
        {
            resmodel = new ApiResponseModel();
            commonBase.UserId = userId;
            var Data = commonAction.DeleteAccount(commonBase);
            if (Data.IsSuccess == true)
            {
                resmodel.IsSuccess = true;
                resmodel.IsError = false;
                resmodel.Message = "Success";
                resmodel.ResponseData = "Deleted";
            }
            else
            {
                resmodel.IsSuccess = false;
                resmodel.IsError = true;
                resmodel.Message = "Failure";
                resmodel.ResponseData = "Failed to Delete Profile ";
            }
            return resmodel;

        }
        #endregion


    }

}

