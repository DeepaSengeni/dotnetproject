using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STU.ActionLayer.Questions;
using STU.BaseLayer.Questions;
using StudentAppWebsite.Models;
using STU.BaseLayer.Answers;
using STU.ActionLayer.Answers;
using StudentAppWebsite.Filters;
using STU.ActionLayer.Common;
using STU.BaseLayer.Common;
using System.Configuration;
using STU.BaseLayer.Book;
using STU.ActionLayer.Book;
using System.Web.Hosting;
using STU.ActionLayer.Invitation;
using STU.BaseLayer.Invitations;
using STU.Utility;
using STU.BaseLayer.Pages;
using STU.ActionLayer.Pages;
using STU.BaseLayer.Advertisement;
using STU.ActionLayer.Advertisement;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Collections;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.NetworkInformation;
using STU.BaseLayer.User;
using System.Globalization;
using System.Web.Caching;
using System.Web.Helpers;
using STU.Utility;


namespace StudentAppWebsite.Controllers
{

    public class HomeController : Controller
    {
        Cache HomeCache = new Cache();
        STU.BaseLayer.ActionResult actionResult;
        QuestionsBase questionBase = new QuestionsBase();
        QuestionsAction questionsAction = new QuestionsAction();
        AnswersBase answersBase = new AnswersBase();
        AnswerAction answerAction = new AnswerAction();
        CommonAction commonAction = new CommonAction();
        CommonBase commonBase = new CommonBase();
        BookAction bookAction = new BookAction();
        BooksRatingBase bookbase = new BooksRatingBase();
        InvitationListAction invitationListAction = new InvitationListAction();
        InvitationListBase invitationListBase = new InvitationListBase();
        static string strSalt = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey"].ToString();

        static string key = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey1"].ToString();

        static string GCMKey = System.Configuration.ConfigurationManager.AppSettings["GCMServerKey"].ToString();

        #region Encryption Extensions

        #region Encrypt
        public static string Encode(string TextToBeEncrypted)
        {
            // string strSalt = ConfigurationSettings.AppSettings["encryptionSalt"].ToString();

            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(strSalt.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(strSalt, Salt);

            //Creates a symmetric encryptor object.
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;

        }
        #endregion

        #region Decrypt
        public static string Decode(string textToBeDecrypted)
        {
            string DecryptedData = string.Empty;
            if (string.IsNullOrEmpty(textToBeDecrypted) == false)
            {
                textToBeDecrypted = HttpUtility.UrlDecode(textToBeDecrypted);
                //string strSalt = ConfigurationSettings.AppSettings["encryptionSalt"].ToString();
                textToBeDecrypted = textToBeDecrypted.Replace(" ", "+");
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] EncryptedData = Convert.FromBase64String(textToBeDecrypted);
                byte[] Salt = Encoding.ASCII.GetBytes(strSalt.Length.ToString());
                //Making of the key for decryption
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(strSalt, Salt);
                //Creates a symmetric Rijndael decryptor object.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();
                //Converting to string
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);

            }
            return DecryptedData;


        }
        #endregion

        #endregion

        public Cache GetCacheObject()
        {
            return HomeCache;
        }

        public ActionResult _TextPage(int pageid)
        {
            BookBase bookBase = new BookBase();
            NotebookForm model = new NotebookForm();
            List<NotebookForm> lstNotebook = new List<NotebookForm>();
            bookBase.PageNumber = pageid;
            actionResult = bookAction.GetPageContent_ByPageId(bookBase);
            if (actionResult.IsSuccess)
            {
                lstNotebook = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);
                model.PageImage = HttpUtility.HtmlDecode(lstNotebook[0].PageImage);
            }
            model = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0] : model);
            return View(model);
        }


        public ActionResult _IndexPartial(int pageId)
        {

            //ViewBag.Book = bookId;
            // ViewBag.TotalPages = TotalPages;
            ViewBag.PageId = pageId;
            //ViewBag.LogedInUserId = Session["UserId"].ToString();
            BookBase bookBase = new BookBase();
            BookAction bookAction = new BookAction();
            NotebookForm model = new NotebookForm();
            List<NotebookForm> lstNotebook = new List<NotebookForm>();
            // bookBase.BookId = Convert.ToInt64(bookId);
            bookBase.PageNumber = pageId;
            actionResult = bookAction.GetPageContent_ByPageId(bookBase);
            if (actionResult.IsSuccess)
            {
                lstNotebook = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);
                model.PageImage = HttpUtility.HtmlDecode(lstNotebook[0].PageImage);
            }
            ViewBag.BookUserId = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0].UserId : 0);
            model = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0] : model);
            model.UserId = (Session["UserId"] != null ? Convert.ToInt32(Session["UserId"]) : 0);
            return PartialView(model);
        }


        [CheckLogin]
        public ActionResult Index(int? pageId = 0, int? bookId = 0) //int bookId,
        {
           
            ViewBag.Book = Convert.ToInt32(bookId);
            //ViewBag.TotalPages = pagecount;
            ViewBag.PageId = Convert.ToInt32(pageId);
            ViewBag.LogedInUserId = Session["UserId"].ToString();
            ViewBag.LogedInUserRole = Session["Role"].ToString();
            BookBase bookBase = new BookBase();
            BookAction bookAction = new BookAction();
            NotebookForm model = new NotebookForm();
            List<NotebookForm> lstNotebook = new List<NotebookForm>();
            //

            //bookBase.BookId = Convert.ToInt64(bookId);
            bookBase.PageNumber = Convert.ToInt32(pageId);
            actionResult = bookAction.GetPageContent_ByPageId(bookBase);

            if (actionResult.IsSuccess)
            { 
                lstNotebook = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);
                model.PageImage =   HttpUtility.HtmlDecode(lstNotebook[0].PageImage);
            }
            ViewBag.BookUserId = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0].UserId : 0);
            model = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0] : model);
            model.UserId = (Session["UserId"] != null ? Convert.ToInt32(Session["UserId"]) : 0);
            List<Int64> lstpageIds = new List<Int64>();
            actionResult = bookAction.GetpageIds(Convert.ToInt32(bookId));
            if (actionResult.IsSuccess)
            {
                // lstpageIds = AccountingSoftware.Helpers.CommonMethods.ConvertTo<int>(actionResult.dtResult);
                lstpageIds = actionResult.dtResult.AsEnumerable().Select(m => m.Field<Int64>("Id")).ToList();
            }
            model.lstpageIds = lstpageIds;
            //return View(model);
            ViewBag.PageId = Convert.ToInt32(pageId);
            return View(model);
        }

        public ActionResult Index_Android(int? userId = 0, int? pageId = 0)
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.UserId = userId;
            ViewBag.PageId = pageId;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [CheckLogin]
        public ActionResult Home_Mobile()
        {


            StudentRegistration model = new StudentRegistration();
            List<State> StateList = new List<State>();
            List<City> CityList = new List<City>();
            List<StudentAppWebsite.Models.Stream> StreamList = new List<StudentAppWebsite.Models.Stream>();
            List<Institute> InstituteList = new List<Institute>();
            List<Subjects> Subject = new List<Subjects>();
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            //var country = CountryLoad();

            model.Countrylist = new List<Country>();
            model.statelist = StateList;
            model.citylist = CityList;
            int UserId = Convert.ToInt32(Session["UserId"]);
            int PageNo = 0;
            int Offset = 5;
            actionResult = commonAction.Notesbook_LoadBy_OFFSET(PageNo, Offset, UserId);
            if (actionResult.IsSuccess)
            {
                model.NotebookFormList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);

            }
            ViewBag.Pageno = PageNo;

            var Category = CategoryLoad();
            model.CategoryList = Category;

            return View(model);
        }

        #region NoteBook_Load_By_Next_Prev
        public JsonResult NoteBook_Load_By_Next_Prev(int offset)
        {
            string json = string.Empty;
            try
            {
                int UserId = Convert.ToInt32(Session["UserId"]);
                actionResult = commonAction.Notesbook_LoadBy_OFFSET(offset, 12, UserId);
                if (actionResult.IsSuccess)
                {
                    string NotebookFormList = string.Empty;

                    NotebookFormList = Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult);
                    json = "{\"Status\":\"1\",\"NotebookFormList\":" + NotebookFormList + "}";
                }
                else
                {
                    json = "{\"Status\":\"-1\"}";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FAQ()
        {
            ViewBag.Message = "Your faq page.";

            return View();
        }
        public ActionResult Facebook_register()
        {

            return View();
        }
        public ActionResult AddQuestion(int? userID = 0, int? pageID = 0, int? questionID = 0)
        {
            QuestionModel qmodel = new QuestionModel();
            qmodel.PageId = pageID.Value;
            qmodel.UserId = userID.Value;
            questionBase.Id = questionID.Value;
            actionResult = questionsAction.Questions_LoadBy_PageId_Services(questionBase);
            //List<QuestionModel> questionList = new List<QuestionModel>();
            //if (actionResult.IsSuccess)
            //{

            //    questionList = (from DataRow dr in actionResult.dtResult.Rows
            //                    select new QuestionModel()
            //                    {
            //                        Id = Convert.ToInt32(dr["Id"]),
            //                        PageId = dr["PageId"] != DBNull.Value ? Convert.ToInt32(dr["PageId"]) : 0,
            //                        QuestionTitle = dr["QuestionTitle"].ToString(),
            //                        UserId = dr["UserId"] != DBNull.Value ? Convert.ToInt32(dr["UserId"]) : 0,
            //                    }).ToList();

            //}
            //else
            //{

            //}
            //qmodel.QuestionsList = questionList;

            return View(qmodel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddQuestion(int userID, int pageID, string data, int question)
        {
            string vps = string.Empty;
            vps = HttpUtility.UrlDecode(data);
            actionResult = new STU.BaseLayer.ActionResult();
            questionBase.Id = 0;
            questionBase.PageId = pageID;
            questionBase.UserId = userID;
            questionBase.QuestionTitle = vps;
            questionBase.Id = question;
            actionResult = questionsAction.Questions_InsertUpdate(questionBase);
            //int result = 0;
            //if (actionResult.IsSuccess)
            //{
            //    result = actionResult.RowsAffected;
            //}
            ////ShowQuestion(pageID);
            // return RedirectToAction("ShowQuestion", new { questionID = result });

            bool result = false;
            if (actionResult.IsSuccess)
            {
                result = true;
            }
            //return View(answerData);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveQuestion(FormCollection fc, int userID, int pageID, string data, int question, int replyanswer, int answer, bool? Editques)
        {
            //var newData = fc["data"];
            QuestionModel model = new QuestionModel();
            string vps = string.Empty;
            vps = data;
            actionResult = new STU.BaseLayer.ActionResult();
            questionBase.Id = question;
            questionBase.PageId = pageID;
            questionBase.UserId = userID;
            questionBase.QuestionTitle = vps;

            string v = model.EditQuestion;
            if (question > 0 && Editques != true)
            {
                answersBase.UserId = userID;
                answersBase.QuestionId = question;
                answersBase.PageID = pageID;
                answersBase.Id = answer;
                answersBase.Answer = vps;
                answersBase.ReplyAnswerId = replyanswer;
                actionResult = answerAction.Answers_InsertUpdate(answersBase);
                // ViewBag.AnswerId = actionResult.dtResult.Rows[0]["Column1"];
            }
            else
            {
                actionResult = questionsAction.Questions_InsertUpdate(questionBase);
            }
            //int result = 0;
            //if (actionResult.IsSuccess)
            //{
            //    result = actionResult.RowsAffected;
            //}
            ////ShowQuestion(pageID);
            // return RedirectToAction("ShowQuestion", new { questionID = result });

            bool result = false;
            if (actionResult.IsSuccess)
            {
                result = true;
                actionResult = questionsAction.SendNotification(questionBase);
                if (actionResult.IsSuccess)
                {
                    var SubmitterList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Submitter>(actionResult.dtResult);
                    if (SubmitterList != null && SubmitterList.Count > 0 && !string.IsNullOrEmpty(SubmitterList[0].RegistrationToken))
                    {

                        string Message = Session["StudentName"].ToString() + (question > 0 && Editques != true ? " answered on " : " commented on ") + SubmitterList[0].BookName + " Created by " + SubmitterList[0].BookSubmitter + " " + vps;
                        SendPushNotification(SubmitterList[0].RegistrationToken, Message, "1", fc["BookID"], pageID.ToString());
                    }
                }
            }



            return Json(new { success = result }, JsonRequestBehavior.AllowGet);

        }
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

        public ActionResult ShowQuestion(int? questionID = 0)
        {
            QuestionModel qmodel = new QuestionModel();
            questionBase.Id = questionID.Value;
            ViewBag.id = Session["UserId"];
            actionResult = questionsAction.Questions_LoadBy_Id_Services(questionBase);
            List<QuestionModel> questionList = new List<QuestionModel>();
            if (actionResult.IsSuccess)
            {

                questionList = (from DataRow dr in actionResult.dtResult.Rows
                                select new QuestionModel()
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    PageId = dr["PageId"] != DBNull.Value ? Convert.ToInt32(dr["PageId"]) : 0,
                                    QuestionTitle = dr["QuestionTitle"].ToString(),
                                    UserId = dr["UserId"] != DBNull.Value ? Convert.ToInt32(dr["UserId"]) : 0,
                                }).ToList();

            }
            else
            {

            }
            qmodel.QuestionsList = questionList;

            return View(qmodel);
        }
        public ActionResult AddAnswer(int? userID = 0, int? questionID = 0, int? answerID = 0)
        {
            AnswerModel ansModel = new AnswerModel();
            AnswersBase answersBase = new AnswersBase();
            answersBase.UserId = userID.Value;
            answersBase.Id = answerID.Value;
            answersBase.QuestionId = questionID.Value;
            actionResult = answerAction.Answers_LoadBy_QuestionId_Services(answersBase);
            //List<AnswerModel> AnswersList = new List<AnswerModel>();
            //if (actionResult.IsSuccess)
            //{
            //    AnswersList = (from DataRow dr in actionResult.dtResult.Rows
            //                   select new AnswerModel()
            //                   {
            //                       Id = Convert.ToInt32(dr["answerID"]),
            //                       QuestionId = dr["QuestionId"] != DBNull.Value ? Convert.ToInt32(dr["QuestionId"]) : 0,
            //                       UserId = dr["answerUserID"] != DBNull.Value ? Convert.ToInt32(dr["answerUserID"]) : 0,
            //                   }).ToList();

            //}
            //else
            //{

            //}
            ansModel.UserId = userID.Value;
            ansModel.Id = answerID.Value;
            ansModel.QuestionId = questionID.Value;
            // ansModel.AnswersList = AnswersList;

            return View(ansModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAnswer(int userID, int questionID, string data, int answerID, int replyanswerID)
        {

            string answerData = string.Empty;
            answerData = HttpUtility.UrlDecode(data);
            actionResult = new STU.BaseLayer.ActionResult();
            answersBase.UserId = userID;
            answersBase.QuestionId = questionID;
            answersBase.Id = answerID;
            answersBase.Answer = answerData;
            answersBase.ReplyAnswerId = answerID;
            actionResult = answerAction.Answers_InsertUpdate(answersBase);
            bool result = false;
            if (actionResult.IsSuccess)
            {
                result = true;
            }
            //return View(answerData);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowAnswer(int? answerID = 0)
        {
            AnswerModel ansModel = new AnswerModel();
            AnswersBase answersBase = new AnswersBase();
            answersBase.Id = answerID.Value;
            actionResult = answerAction.USP_S_Answers_Load_Services(answersBase);
            List<AnswerModel> AnswersList = new List<AnswerModel>();
            if (actionResult.IsSuccess)
            {

                AnswersList = (from DataRow dr in actionResult.dtResult.Rows
                               select new AnswerModel()
                               {
                                   Id = Convert.ToInt32(dr["Id"]),
                                   QuestionId = dr["QuestionID"] != DBNull.Value ? Convert.ToInt32(dr["QuestionID"]) : 0,
                                   Answer = dr["Answer"].ToString(),
                                   UserId = dr["UserId"] != DBNull.Value ? Convert.ToInt32(dr["UserId"]) : 0
                               }).ToList();

            }
            else
            {

            }
            ansModel.AnswersList = AnswersList;

            return View(ansModel);
        }


        public PartialViewResult _Editor(int pageId, int userId)
        {
            QuestionModel model = new QuestionModel();
            model.PageId = pageId;
            model.UserId = userId;
            return PartialView(model);
        }


        public PartialViewResult _Editor_Android(int? userId = 0, int? pageId = 0, int? question = 0, bool? Editques = false)
        {
            QuestionModel model = new QuestionModel();
            model.PageId = Convert.ToInt32(pageId);
            model.UserId = Convert.ToInt32(userId);
            model.Id = Convert.ToInt32(question);
            model.EditQuestion = Convert.ToString(Editques);

            return PartialView(model);
        }

        public ActionResult Editor_Android(int? UserId, int? PageId, int? QuestionId, bool? Editques)
        {
            QuestionModel model = new QuestionModel();
            ViewBag.UserId = UserId;
            ViewBag.PageId = PageId;
            ViewBag.QuestionId = QuestionId;
            ViewBag.Editques = Editques;
            questionBase.Id = Convert.ToInt32(QuestionId);
            actionResult = questionsAction.QuestionLoadByQuestionId(questionBase);
            if (actionResult.IsSuccess)
            {
                model.QuestionTitle = Convert.ToString(actionResult.dtResult.Rows[0]["QuestionTitle"]);

            }
            return View(model);
        }

        public PartialViewResult _QuestionList(int? userId = 0, int? pageId = 0)
        {

            questionBase.PageId = Convert.ToInt32(pageId);
            actionResult = questionsAction.Questions_LoadBy_PageId(questionBase);
            QuestionModel model = new QuestionModel();
            List<QuestionModel> lstQuestion = new List<QuestionModel>();
            List<AnswerModel> AnswersList = new List<AnswerModel>();

            if (actionResult.IsSuccess)
            {
                lstQuestion = AccountingSoftware.Helpers.CommonMethods.ConvertTo<QuestionModel>(actionResult.dtResult);

            }
            //
            List<Friend> FriendRequests = new List<Friend>();
            commonBase.Id = Convert.ToInt32(userId);
            actionResult = commonAction.FriendRequest_LoadByUserId(commonBase);
            if (actionResult.IsSuccess)
            {
                FriendRequests = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(actionResult.dtResult);
            }
            model.FriendRequests = FriendRequests;
            //
            actionResult = questionsAction.Answers_LoadBy_PageId(questionBase);

            if (actionResult.IsSuccess)
            {
                AnswersList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AnswerModel>(actionResult.dtResult);

            }



            model.QuestionsList = lstQuestion.OrderBy(m => m.Id).ToList();
            model.AnswersList = AnswersList.OrderBy(m => m.Id).ToList();
            model.UserId = Convert.ToInt32(userId);
            return PartialView(model);
        }

        public PartialViewResult _ReplyAnswerPartial(int? Answerid = 0)
        {
            answersBase.Id = Convert.ToInt32(Answerid);
            List<AnswerModel> ReplyAnswersList = new List<AnswerModel>();
            QuestionModel model = new QuestionModel();
            actionResult = questionsAction.ReplyAnswers_LoadBy_PageId(answersBase);

            if (actionResult.IsSuccess)
            {
                ReplyAnswersList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AnswerModel>(actionResult.dtResult);

            }

            model.ReplyAnswersList = ReplyAnswersList.OrderBy(m => m.Id).ToList();

            return PartialView(model);
        }

        public List<Country> CountryLoad()
        {
            string json = string.Empty;
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<Country> Countrylist = new List<Country>();

            StudentRegistration model = new StudentRegistration();

            actionResult = commonAction.Countries_LoadAll();
            if (actionResult.IsSuccess)
            {
                Countrylist.Add(new Country() { CountryName = "Select All", ID = 0 });
                Countrylist.AddRange(AccountingSoftware.Helpers.CommonMethods.ConvertTo<Country>(actionResult.dtResult));

            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return Countrylist;
        }

        public JsonResult CountryLoadAjax()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<Country> Countrylist = new List<Country>();

            StudentRegistration model = new StudentRegistration();

            actionResult = commonAction.Countries_LoadAll();
            if (actionResult.IsSuccess)
            {
                Countrylist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Country>(actionResult.dtResult);

            }
            model.Countrylist = Countrylist;
            if (Countrylist != null && Countrylist.Count > 0)
            {
                var index = model.Countrylist.FindIndex(x => x.ID == 100);
                var item = model.Countrylist[index];
                model.Countrylist[index] = model.Countrylist[0];
                model.Countrylist[0] = item;
            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StateLoad(int CountryID)
        {
            string json = string.Empty;
            StudentRegistration model = new StudentRegistration();
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<State> StateList = new List<State>();
            // model.Country = CountryID;
            commonBase.CountryId = CountryID;
            actionResult = commonAction.States_LoadBy_CountryId(commonBase);
            if (actionResult.IsSuccess)
            {
                StateList.Add(new State() { StateName = "Select All", ID = 0 });
                StateList.AddRange(AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(actionResult.dtResult));
            }

            model.statelist = StateList;

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CityLoad(int StateID)
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<City> CityList = new List<City>();
            string json = string.Empty;

            StudentRegistration model = new StudentRegistration();
            commonBase.StateId = StateID;
            actionResult = commonAction.Cities_LoadBy_StateId(commonBase);
            if (actionResult.IsSuccess)
            {
                CityList.Add(new City() { CityName = "Select All", ID = 0 });
                CityList.AddRange(AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(actionResult.dtResult));
            }
            model.citylist = CityList;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StreamsLoadByCategoryId(int CategoryID)
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<HomeModel> StreamList = new List<HomeModel>();
            string json = string.Empty;

            StudentRegistration model = new StudentRegistration();


            commonBase.Id = CategoryID;
            actionResult = commonAction.StreamsLoadByCategoryID(commonBase);
            if (actionResult.IsSuccess)
            {
                StreamList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<HomeModel>(actionResult.dtResult);
            }
            model.HomeList = StreamList.Where(m => m.Status == true).ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult InstitutesLoadByStreamID(int StreamId, int? CityId)
        //{
        //    STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
        //    STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
        //    List<InstituteModel> instituteNewList = new List<InstituteModel>();
        //    List<Subjects> SubjectList = new List<Subjects>();
        //    string json = string.Empty;

        //    StudentRegistration model = new StudentRegistration();

        //    commonBase.Id = StreamId;
        //    commonBase.CityId = CityId;
        //    actionResult = commonAction.InstitutesLoadByStreamID(commonBase);
        //    if (actionResult.IsSuccess)
        //    {
        //        instituteNewList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InstituteModel>(actionResult.dtResult);
        //    }
        //    model.instituteNewList = instituteNewList.Where(m => m.Status == true).ToList();

        //    commonBase.SteamId = StreamId;
        //    actionResult = commonAction.SubjectLoadByStreamId(commonBase);
        //    if (actionResult.IsSuccess)
        //    {
        //        SubjectList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(actionResult.dtResult);
        //    }
        //    model.SubjectsList = SubjectList.Where(m => m.Status == true).ToList();





        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        public List<College> Colleges_LoadAll()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            StudentRegistration model = new StudentRegistration();
            List<College> CollegeList = new List<College>();
            actionResult = commonAction.Colleges_LoadAll();
            if (actionResult.IsSuccess)
            {
                CollegeList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<College>(actionResult.dtResult);
            }

            return CollegeList;
        }

        [CheckLogin]
        public ActionResult Home()
        {
            var d = Session["Role"];
            if (Convert.ToString(d) == "")
            {
                return RedirectToAction("SubmitterRegistration", "Account");
            }
            if (Convert.ToInt32(Session["Role"]) == 1)
            {
                return RedirectToAction("Index", "Admin");
            }

            //if (Request.Browser.IsMobileDevice)
            //{
            //    Response.Redirect("/Home/Home_Mobile");
            //}
            StudentRegistration model = new StudentRegistration();
            List<State> StateList = new List<State>();
            List<City> CityList = new List<City>();
            List<StudentAppWebsite.Models.Stream> StreamList = new List<StudentAppWebsite.Models.Stream>();
            List<Institute> InstituteList = new List<Institute>();
            List<Subjects> Subject = new List<Subjects>();
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            var country = CountryLoad();
            model.Countrylist = country;


            //var College = Colleges_LoadAll();
            //model.CollegeList = College;
            if (model.Countrylist != null && model.Countrylist.Count > 0)
            {
                int countryId = Convert.ToInt32(0);
                model.Country = countryId;
                commonBase.CountryId = countryId;
                actionResult = commonAction.States_LoadBy_CountryId(commonBase);
                if (actionResult.IsSuccess)
                {
                    StateList.Add(new State() { StateName = "Select All", ID = 0 });
                    StateList.AddRange(AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(actionResult.dtResult));
                }
            }
            model.statelist = StateList;
            if (model.statelist != null && model.statelist.Count > 0)
            {
                int StateID = Convert.ToInt32(0);
                model.state = Convert.ToString(StateID);
                commonBase.StateId = StateID;
                actionResult = commonAction.Cities_LoadBy_StateId(commonBase);
                if (actionResult.IsSuccess)
                {
                    CityList.Add(new City() { CityName = "Select All", ID = 0 });
                    CityList.AddRange(AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(actionResult.dtResult));
                }
            }
            model.citylist = CityList;
            //if (model.citylist != null && model.citylist.Count > 0)
            //{
            //    var index = model.citylist.FindIndex(x => x.ID == 4933);
            //    var item = model.citylist[index];
            //    model.citylist[index] = model.citylist[0];
            //    model.citylist[0] = item;
            //}

            var NoteBookForm = NoteBookLoad();
            model.NotebookFormList = NoteBookForm;
            var Category = CategoryLoad();
            model.CategoryList = Category;
            if (model.CategoryList != null && model.CategoryList.Count > 0)
            {
                int CategoryID = model.CategoryList.Select(m => m.Id).FirstOrDefault();
                model.Category = Convert.ToString(CategoryID);
                commonBase.Id = CategoryID;
                actionResult = commonAction.StreamsLoadByCategoryID(commonBase);
                if (actionResult.IsSuccess)
                {
                    StreamList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<StudentAppWebsite.Models.Stream>(actionResult.dtResult);

                }
            }
            model.StreamList = StreamList;

            if (model.StreamList != null && model.StreamList.Count > 0)
            {
                model.StreamList = model.StreamList.Where(m => m.Status == true).ToList();
                int StreamId = model.StreamList.Select(m => m.Id).FirstOrDefault();
                model.Stream = Convert.ToString(StreamId);
                commonBase.Id = StreamId;
                actionResult = commonAction.InstitutesLoadByStreamID(commonBase);
                if (actionResult.IsSuccess)
                {
                    InstituteList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Institute>(actionResult.dtResult);
                }
                commonBase.StreamId = StreamId;

                actionResult = commonAction.SubjectLoadByStreamId(commonBase);

                if (actionResult.IsSuccess)
                {
                    Subject = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(actionResult.dtResult);
                }
            }

            model.SubjectsList = Subject;
            model.InstituteList = InstituteList;
            if (model.SubjectsList.Count > 0)
            {
                model.SubjectsList = model.SubjectsList.Where(m => m.Status == true).OrderBy(x => x.SubjectName).ToList();
            }
            if (model.InstituteList.Count > 0)
            {
                model.InstituteList = model.InstituteList.Where(m => m.Status == true).OrderBy(x => x.InstituteName).ToList();
            }

            return View(model);
        }

        public JsonResult DeleteAnswer_ById(int Id)
        {
            bool status = false;
            questionBase.Id = Id;
            actionResult = questionsAction.DeleteAnswer_ById(questionBase);
            if (actionResult.IsSuccess)
            {
                status = true;
            }
            return Json(status);
        }

        public JsonResult DeleteQuestions_ById(int Id)
        {
            bool status = false;
            questionBase.Id = Id;
            actionResult = questionsAction.Questions_Delete_By_Id(questionBase);
            if (actionResult.IsSuccess)
            {
                status = true;
            }
            return Json(status);
        }

        #region SendInvitation
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendInvitation(FormCollection fc, int? usersId = 0)
        {
            string userId = (Session["UserId"] != null ? Convert.ToString(Session["UserId"]) : usersId.ToString());
            if (userId != null && Convert.ToInt32(userId) > 0)
            {
                string Site = ConfigurationManager.AppSettings["site"].ToString();
                string pageType = !String.IsNullOrEmpty(fc["PageType"]) ? Convert.ToString(fc["PageType"]) : "";
                string mailto = !String.IsNullOrEmpty(fc["MailTo"]) ? Convert.ToString(fc["MailTo"]) : "";




                string userName = string.Empty;
                string InvitedUserId = string.Empty;
                string InvitedEmail = string.Empty;
                commonBase.Id = Convert.ToInt32(userId);
                commonBase.Email = mailto;
                // commonBase.
                actionResult = commonAction.UserInfo_LoadById(commonBase);
                if (actionResult.IsSuccess)
                {
                    userName = Convert.ToString(actionResult.dtResult.Rows[0]["StudentName"]);
                    InvitedEmail = Convert.ToString(actionResult.dtResult.Rows[0]["EmailId"]);
                    InvitedUserId = Convert.ToString(actionResult.dtResult.Rows[0]["Id"]);
                }
                string Message = "<html><body>Hi,<br/><br/>" + userName + " sent you invitation for adding in Notetor.com, Please register by clicking below link<br/><a href='" + Site + "/Account/Register?id=" + userId + "&inv=" + mailto + "'>Click Here</a><br/><br/>Thanks & Regards,<br/>" + userName + ".</body></html>";
                bool result = AccountingSoftware.Helper.Email.SendEmail(mailto, "Studentsnotebooks Invitation!", Message, true);
                // actionResult = commonAction.InvitationList_Email_Insert();
                if (result)
                {
                    TempData["SuccessMessage"] = "Invitation sent successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Some error has been occured during sending invitation.";
                }

                return Redirect(System.Web.HttpContext.Current.Request.UrlReferrer.ToString());
                //return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Login", "Account");

        }
        #endregion

        public List<StudentAppWebsite.Models.Stream> StreamLoad()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<StudentAppWebsite.Models.Stream> Streamlist = new List<StudentAppWebsite.Models.Stream>();

            StudentRegistration model = new StudentRegistration();

            actionResult = commonAction.Streams_LoadAll();
            if (actionResult.IsSuccess)
            {
                Streamlist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<StudentAppWebsite.Models.Stream>(actionResult.dtResult);

            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return Streamlist;
        }

        public List<Subjects> SubjectLoad()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<Subjects> Subjectslist = new List<Subjects>();

            StudentRegistration model = new StudentRegistration();

            actionResult = commonAction.Subjects_LoadAll();
            if (actionResult.IsSuccess)
            {
                Subjectslist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(actionResult.dtResult);

            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return Subjectslist.Where(m => m.Status == true).ToList();
        }



        public List<Categories> CategoryLoad()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<Categories> CategoryList = new List<Categories>();

            StudentRegistration model = new StudentRegistration();

            actionResult = commonAction.Categories_LoadAll();
            if (actionResult.IsSuccess)
            {
                CategoryList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Categories>(actionResult.dtResult);
                CategoryList = CategoryList.Where(m => m.Status = true).ToList();
            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return CategoryList;
        }

        public List<Chapters> ChaptersLoad()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<Chapters> Chapterslist = new List<Chapters>();

            StudentRegistration model = new StudentRegistration();

            actionResult = commonAction.Chapters_LoadAll();
            if (actionResult.IsSuccess)
            {
                Chapterslist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Chapters>(actionResult.dtResult);

            }
            //Countrylist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System.Web.Mvc.SelectListItem>>(studentService.Countries_LoadAll());


            return Chapterslist;
        }

        public List<NotebookForm> NoteBookLoad()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<NotebookForm> NotebookFormlist = new List<NotebookForm>();

            StudentRegistration model = new StudentRegistration();
            int PageNo = 0;
            int Offset = 12;
            int UserId = Convert.ToInt32(Session["UserId"]);
            actionResult = commonAction.Notesbook_LoadBy_OFFSET(PageNo, Offset, UserId);
            //actionResult = commonAction.Notesbook_LoadAll();
            if (actionResult.IsSuccess)
            {
                NotebookFormlist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);

            }
            return NotebookFormlist;
        }

        public ActionResult NoteBookDetails(int? BookId = 0)
        {

            ViewBag.BookId = BookId;
            NotebookForm model = new NotebookForm();
            List<NotebookForm> NotebookFormList = new List<NotebookForm>();

            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            commonBase.NotebookId = Convert.ToInt32(BookId);
            actionResult = commonAction.Notesbook_Load_ById(commonBase);
            if (actionResult.IsSuccess)
            {
                model.UserId = (actionResult.dtResult.Rows[0]["UserId"] != DBNull.Value ? Convert.ToInt32(actionResult.dtResult.Rows[0]["UserId"]) : 0);
                model.ChapterName = Convert.ToString(actionResult.dtResult.Rows[0]["ChapterName"]);
                model.SubjectName = Convert.ToString(actionResult.dtResult.Rows[0]["SubjectName"]);
                model.SubmitterPic = (actionResult.dtResult.Rows[0]["SubmitterPic"] != DBNull.Value ? Convert.ToString(actionResult.dtResult.Rows[0]["SubmitterPic"]) : "\\Images\\6GS4E2B.png");
                model.CategoryName = Convert.ToString(actionResult.dtResult.Rows[0]["CategoryName"]);
                model.Innovation_Investment = Convert.ToInt32(actionResult.dtResult.Rows[0]["Innovation_Investment"]);
                model.StudentName = Convert.ToString(actionResult.dtResult.Rows[0]["StudentName"]);
                model.StreamName = Convert.ToString(actionResult.dtResult.Rows[0]["StreamId"]);
                //model.TotalPages = Convert.ToString(actionResult.dtResult.Rows[0]["TotalPages"]);
                model.TeachereName = Convert.ToString(actionResult.dtResult.Rows[0]["TeachereName"]);
                model.CollegeId = Convert.ToString(actionResult.dtResult.Rows[0]["CollegeId"]);
                model.StartDate = Convert.ToString(actionResult.dtResult.Rows[0]["StartDate"]);
                model.Type = Convert.ToString(actionResult.dtResult.Rows[0]["Type"]);

                //model.Rate = (actionResult.dtResult.Rows[0]["Rate"] != DBNull.Value ? Convert.ToInt32(actionResult.dtResult.Rows[0]["Rate"]) : 0);
                //model.RatingId = Convert.ToString(actionResult.dtResult.Rows[0]["RatingId"]);
                model.Total_Number_of_Pages = Convert.ToInt32(actionResult.dtResult.Rows[0]["Total_Number_of_Pages"]);
                model.BookId = Convert.ToString(BookId);//Convert.ToString(actionResult.dtResult.Rows[0][""]);

            }

            return View(model);
        }

        #region UpdateRating
        public JsonResult UpdateRating(int Rate, int BookId, int UserId) //, int RatingId
        {

            string msg = "";
            bookbase.Rate = Rate;
            // bookbase.Id = RatingId;
            bookbase.BookId = BookId;
            bookbase.UserId = UserId;
            bookbase.Comment = "";
            if (Rate > 0)
            {
                bookbase.Action = "Update";
                actionResult = bookAction.BooksRating_InsertUpdate(bookbase);
                if (Convert.ToString(actionResult.dtResult.Rows[0][0]) != "-1")
                {
                    msg = "Update";
                }



            }
            else
            {
                bookbase.Action = "Save";
                actionResult = bookAction.BooksRating_InsertUpdate(bookbase);
                if (Convert.ToString(actionResult.dtResult.Rows[0][0]) != "-1")
                {
                    msg = "Save";
                }


            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        //public JsonResult SearchBooksByName(string Text)
        //{
        //    string[] query = Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        //    Text = string.Join(" ", query);
        //    //StudentRegistration model = new StudentRegistration();
        //    List<NotebookForm> NotebookFormList = new List<NotebookForm>();
        //    NotebookForm model = new NotebookForm();
        //    DataTable dt = new DataTable();
        //    for (int i = 0; i <= query.Length - 1; i++)
        //    {
        //        commonBase.Text = query[i];
        //        actionResult = commonAction.SearchBooksByName(commonBase);
        //        if (i == 0) dt = actionResult.dtResult.Clone();
        //        foreach (DataRow row in actionResult.dtResult.Rows)
        //        {

        //            dt.Rows.Add(row.ItemArray);
        //        }
        //    }

        //    RemoveDuplicateRows(dt, "Id");
        //    string jsonString = string.Empty;
        //    if (dt.Rows.Count > 0)
        //    {
        //        NotebookFormList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(dt);


        //        //jsonString = "{\"Status\":\"1\"}";
        //        jsonString = "{\"Status\":\"1\"}";
        //        model.NotebookFormList = NotebookFormList;
        //    }
        //    else
        //    {
        //        jsonString = "{\"Status\":\"-1\"}";
        //    }
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult SearchBooksByName(string Text, string country, string state, string city, string subject)
        {

            int countryId, stateId, cityId;
            string subjectId;
            List<NotebookForm> NotebookFormList = new List<NotebookForm>();
            NotebookForm model = new NotebookForm();
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(country))
            {
                countryId = 0;
            }
            else
            {
                countryId = Convert.ToInt32(country);
            }
            if (string.IsNullOrEmpty(state))
            {
                stateId = 0;
            }
            else
            {
                stateId = Convert.ToInt32(state);
            }
            if (string.IsNullOrEmpty(city))
            {
                cityId = 0;
            }

            else
            {
                cityId = Convert.ToInt32(city);
            }

            if (string.IsNullOrEmpty(subject))
            {
                subjectId = "";
            }

            else
            {
                subjectId = subject;
            }

            if (!string.IsNullOrEmpty(Text))
            {
                string[] query = Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Text = string.Join(" ", query);
                //StudentRegistration model = new StudentRegistration();



                for (int i = 0; i <= query.Length - 1; i++)
                {
                    commonBase.Text = query[i];
                    commonBase.CountryId = countryId;
                    commonBase.StateId = stateId;
                    commonBase.CityId = cityId;
                    commonBase.SubjectId = subjectId.ToString();
                    commonBase.UserId = (Session["UserId"] != null ? Convert.ToInt32(Session["UserId"]) : 0);
                    actionResult = commonAction.SearchBooksByName(commonBase);
                    if (i == 0) dt = actionResult.dtResult.Clone();
                    foreach (DataRow row in actionResult.dtResult.Rows)
                    {
                        dt.Rows.Add(row.ItemArray);
                    }
                }
            }
            else
            {
                commonBase.Text = "";
                commonBase.CountryId = countryId;
                commonBase.StateId = stateId;
                commonBase.CityId = cityId;
                commonBase.SubjectId = subjectId.ToString();
                commonBase.UserId = (Session["UserId"] != null ? Convert.ToInt32(Session["UserId"]) : 0);
                actionResult = commonAction.SearchBooksByName(commonBase);
                dt = actionResult.dtResult.Clone();
                foreach (DataRow row in actionResult.dtResult.Rows)
                {
                    dt.Rows.Add(row.ItemArray);
                }
            }
            RemoveDuplicateRows(dt, "Id");

            string jsonString = string.Empty;
            if (dt.Rows.Count > 0)
            {
                NotebookFormList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(dt);


                //jsonString = "{\"Status\":\"1\"}";
                jsonString = "{\"Status\":\"1\"}";
                model.NotebookFormList = NotebookFormList;
            }
            else
            {
                jsonString = "{\"Status\":\"-1\"}";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchBooksByNameAndroid(string Text, int? pageno)
        {
            //StudentRegistration model = new StudentRegistration();
            List<NotebookForm> NotebookFormList = new List<NotebookForm>();
            NotebookForm model = new NotebookForm();
            commonBase.Text = Text;
            commonBase.PageNo = Convert.ToInt32(pageno);
            actionResult = commonAction.SearchBooksByNameAndroid(commonBase);
            string jsonString = string.Empty;
            if (actionResult.dtResult.Rows.Count > 0)
            {
                NotebookFormList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);


                //jsonString = "{\"Status\":\"1\"}";
                jsonString = "{\"Status\":\"1\"}";
                model.NotebookFormList = NotebookFormList;
            }
            else
            {
                jsonString = "{\"Status\":\"-1\"}";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchBookByCatStrInsSub(int? CategoryID = 0, int? StreamID = 0, int? InstituteID = 0, string SubjectID = null)
        {
            //StudentRegistration model = new StudentRegistration();
            List<NotebookForm> NotebookFormList = new List<NotebookForm>();
            NotebookForm model = new NotebookForm();
            commonBase.CategoryId = Convert.ToInt32(CategoryID);
            commonBase.SteamId = Convert.ToInt32(StreamID);
            commonBase.InstituteId = Convert.ToString(InstituteID);
            commonBase.SubjectId = Convert.ToString(SubjectID);
            actionResult = commonAction.SearchBookByCatStrInsSub(commonBase);
            string jsonString = string.Empty;
            if (actionResult.IsSuccess == true && actionResult.dtResult.Rows.Count > 0)
            {
                NotebookFormList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);

                //jsonString = "{\"Status\":\"1\"}";
                jsonString = "{\"Status\":\"1\"}";
                model.NotebookFormList = NotebookFormList;
            }
            else
            {
                jsonString = "{\"Status\":\"-1\"}";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #region SearchBookByCatStrInsSub_ByOFFSET
        public JsonResult SearchBookByCatStrInsSub_ByOFFSET(int pageno, int? CategoryID = 0, int? StreamID = 0, int? InstituteID = 0, string SubjectID = null)
        {
            //StudentRegistration model = new StudentRegistration();
            List<NotebookForm> NotebookFormList = new List<NotebookForm>();
            NotebookForm model = new NotebookForm();
            commonBase.CategoryId = Convert.ToInt32(CategoryID);
            commonBase.SteamId = Convert.ToInt32(StreamID);
            commonBase.InstituteId = Convert.ToString(InstituteID);
            commonBase.SubjectId = Convert.ToString(SubjectID);
            commonBase.PageNo = pageno;
            commonBase.Offset = 5;
            actionResult = commonAction.SearchBookByCatStrInsSub_ByOFFSET(commonBase);
            string jsonString = string.Empty;
            if (actionResult.IsSuccess == true && actionResult.dtResult.Rows.Count > 0)
            {
                NotebookFormList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);

                //jsonString = "{\"Status\":\"1\"}";
                jsonString = "{\"Status\":\"1\"}";
                model.NotebookFormList = NotebookFormList;
            }
            else
            {
                jsonString = "{\"Status\":\"-1\"}";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server,Duration = 604800, VaryByParam = "bookId")]
        [CheckLogin]
        public ActionResult Notebook_Pages(int bookId)
        {
            var cacheKey = "Notebook_Pages_" + bookId;
            var viewbagCacheKey = "Viewbag_Notebook_Pages_" + bookId;

            Dictionary<string, string> viewbagdata = new Dictionary<string, string>();

            if (HomeCache.Get(cacheKey) != null && HomeCache.Get(viewbagCacheKey) != null)
            {
                viewbagdata = (Dictionary<string, string>)HomeCache.Get(viewbagCacheKey);

                foreach (KeyValuePair<string, string> ele in viewbagdata)
                {
                    if(ele.Key == "BookId")
                    {
                        ViewBag.BookId = Convert.ToInt64(ele.Value);
                    }
                    if (ele.Key == "BookCreator")
                    {
                        ViewBag.BookCreator = Convert.ToInt32(ele.Value);
                    }
                    if (ele.Key == "SubjectName")
                    {
                        ViewBag.SubjectName = Convert.ToString(ele.Value);
                    }
                }

                return View(HomeCache.Get(cacheKey));
            }

            BookBase bookBase = new BookBase();
            BookAction bookAction = new BookAction();
            NotebookForm model = new NotebookForm();
            List<NotebookForm> lstNotebook = new List<NotebookForm>();

            bookBase.BookId = Convert.ToInt64(bookId);
            ViewBag.BookId = Convert.ToInt64(bookId);

            viewbagdata.Add("BookId", bookId.ToString());

            commonBase.NotebookId = Convert.ToInt32(bookId);
            actionResult = commonAction.Notesbook_Load_ById(commonBase);
            if (actionResult.IsSuccess)
            {
                ViewBag.BookCreator = Convert.ToInt32(actionResult.dtResult.Rows[0]["UserId"]);
                ViewBag.SubjectName = Convert.ToString(actionResult.dtResult.Rows[0]["SubjectName"]);

                viewbagdata.Add("BookCreator", actionResult.dtResult.Rows[0]["UserId"].ToString());
                viewbagdata.Add("SubjectName", actionResult.dtResult.Rows[0]["SubjectName"].ToString());
            }

            actionResult = bookAction.GetPageDetails_ByBookId(bookBase);

            if (actionResult.IsSuccess)
            {
                lstNotebook = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);

            }

            HomeCache.Add(cacheKey, lstNotebook, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero, CacheItemPriority.High, null);
            HomeCache.Add(viewbagCacheKey, viewbagdata, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero, CacheItemPriority.High, null);
            return View(lstNotebook);
        }

        public JsonResult Downloadbook(int? BookId)
        {
            List<StudentRegistration> DownloadedDataList = new List<StudentRegistration>();
            StudentRegistration model = new StudentRegistration();
            string JsonString = string.Empty;
            string s = string.Empty;
            commonBase.Id = Convert.ToInt32(BookId);
            actionResult = commonAction.BookContentLoadByBookId(commonBase);
            if (actionResult.IsSuccess)
            {

                DownloadedDataList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<StudentRegistration>(actionResult.dtResult);
            }

            model.DownloadedDataList = DownloadedDataList;
            return Json(model.DownloadedDataList, JsonRequestBehavior.AllowGet);
        }

        #region FriendList_InsertUpdate
        [HttpGet]
        public JsonResult FriendList_InsertUpdate(int InvitedId, int PageId = 0)
        {
            string json = string.Empty;
            string result = string.Empty;
            invitationListBase = new InvitationListBase();
            invitationListBase.UserId = Convert.ToInt32(Session["UserId"]);
            invitationListBase.InvitedUserId = InvitedId;
            invitationListBase.PageId = PageId;
            DateTime localDateTime = DateTime.Now;
            string formattedDateTime = localDateTime.ToString("MMM dd yyyy hh:mm tt", CultureInfo.InvariantCulture);
            invitationListBase.CreatedDate = formattedDateTime;
            actionResult = invitationListAction.FriendList_InsertUpdate(invitationListBase);
            if (actionResult.IsSuccess)
            {
                result = Convert.ToString(actionResult.dtResult.Rows[0][0]);
                try
                {
                    var token = Convert.ToString(actionResult.dtResult.Rows[0][1]);
                    String Message = Session["StudentName"].ToString() + " has sent you a friend request";
                    SendPushNotification(token, Message, "2");
                }
                catch (Exception ex)
                {

                }
                json = "{\"Status\":\"1\",\"result\":\"" + result + "\"}";
                //json = "{\"Status\":" + result + "}";
            }
            else
            {
                json = "{\"Status\":\"-1\"}";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region insertView
        public JsonResult insertView(int Id, string action)
        {
            string json = string.Empty;
            bool status = false;
            int views = 0;
            int likes = 0;
            try
            {
                actionResult = bookAction.PageSocialDetails_insertView(Id, Session["UserId"].ToString(), action);
                if (actionResult.IsSuccess)
                {
                    status = Convert.ToBoolean((actionResult.dtResult.Rows[0]["status"] != DBNull.Value ? actionResult.dtResult.Rows[0]["status"] : "False"));
                    likes = Convert.ToInt32((actionResult.dtResult.Rows[0]["likes"] != DBNull.Value ? Convert.ToString(actionResult.dtResult.Rows[0]["likes"]) : "0"));
                    views = Convert.ToInt32((actionResult.dtResult.Rows[0]["views"] != DBNull.Value ? Convert.ToString(actionResult.dtResult.Rows[0]["views"]) : "0"));

                }



                json = "{\"status\":\"" + status + "\",\"likes\":" + likes + ",\"views\":" + views + "}";
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region insertpageclick
        public bool insertpageclick(int Id, string device)
        {
            bool status = false;
            BookBase bookBase = new BookBase();
            BookAction bookAction = new BookAction();

            bookBase.UserId = Convert.ToInt32(Session["UserId"].ToString());
            bookBase.PageNumber = Id;
            bookBase.Device = device;
            try
            {
                actionResult = bookAction.insertpageclick(bookBase);
                if (actionResult.IsSuccess)
                {
                    status = true;
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return status;

        }
        #endregion


        #region NotificationsCount
        public JsonResult NotificationsCount()
        {
            string json = string.Empty;
            string result = string.Empty;
            actionResult = new STU.BaseLayer.ActionResult();
            commonBase = new CommonBase();
            try
            {
                actionResult = new STU.BaseLayer.ActionResult();
                commonBase.UserId = Convert.ToInt32(Session["UserId"]);
                actionResult = commonAction.NotificationsCount(commonBase);

                if (actionResult.IsSuccess)
                {
                    //result = Convert.ToString(actionResult.dtResult.Rows[0][0]);
                    //json = "{\"Status\":\"1\",\"result\":\"" + result + "\"}";
                    string data = string.Empty;
                    string notifications = string.Empty;
                    string friendRequests = string.Empty;

                    if (actionResult.dsResult.Tables.Count > 0)
                        data = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[0].Rows.Count > 0 ? actionResult.dsResult.Tables[0].Rows.Cast<System.Data.DataRow>().Take(5).CopyToDataTable() : actionResult.dsResult.Tables[0]));

                    if (actionResult.dsResult.Tables.Count > 1)
                        notifications = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[1].Rows.Count > 0 ? actionResult.dsResult.Tables[1].Rows.Cast<System.Data.DataRow>().Take(5).CopyToDataTable() : actionResult.dsResult.Tables[1]));

                    if (actionResult.dsResult.Tables.Count > 2)
                        friendRequests = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[2].Rows.Count > 0 ? actionResult.dsResult.Tables[2].Rows.Cast<System.Data.DataRow>().Take(5).CopyToDataTable() : actionResult.dsResult.Tables[2]));

                    json = "{\"Status\":\"1\",\"data\":" + data + ",\"notifications\":" + notifications + ",\"friendRequests\":" + friendRequests + "}";
                }
                else
                    json = "{\"Status\":\"-1\"}";
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [CheckLogin]
        public ActionResult SubmittersProfile(int? UserId)
        {
            ManageProfile model = new ManageProfile();
            Profile profileModel = new Profile();
            List<Profile> lstprofileModel = new List<Profile>();
            List<NotebookForm> lstNotebookModel = new List<NotebookForm>();
            commonBase.Id = Convert.ToInt32(UserId);
            actionResult = commonAction.UserInfo_LoadById(commonBase);
            if (actionResult.IsSuccess)
            {
                lstprofileModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Profile>(actionResult.dtResult);
                if (lstprofileModel.Count > 0)
                    profileModel = lstprofileModel.FirstOrDefault();
            }
            model.profile = profileModel;
            BookBase bookBase = new BookBase();
            bookBase.UserId = Convert.ToInt32(UserId);
            BookAction bookAction = new BookAction();
            actionResult = bookAction.Books_LoadBy_UserId(bookBase);
            if (actionResult.IsSuccess)
            {

                lstNotebookModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(actionResult.dtResult);
            }
            model.lstNotebooks = lstNotebookModel.OrderByDescending(m => m.Id).ToList();
            return View("SubmittersProfile", model);


        }


        #region NotificationListMobile
        [HttpGet]

        public ActionResult NotificationListMobile(int userId)
        {
            List<InvitationModel> lstInvitationModel = new List<InvitationModel>();
            CommonBase commonBase = new CommonBase();
            commonBase.UserId = Convert.ToInt32(userId);
            actionResult = new STU.BaseLayer.ActionResult();
            actionResult = commonAction.NotificationsCount(commonBase);
            if (actionResult.IsSuccess)
            {
                lstInvitationModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InvitationModel>(actionResult.dsResult.Tables[1]);
            }
            return View(lstInvitationModel);
        }
        #endregion


        #region RemovePagesById
        public JsonResult RemovePagesById(string pageids,string BookId)
        {
            string json = string.Empty;
            PagesBase pageBase = new PagesBase();
            PagesAction pageAction = new PagesAction();
            pageids = pageids.TrimEnd(',');
            pageBase.PageTitle = pageids;
            actionResult = pageAction.RemovePageById(pageBase);
            if (actionResult.IsSuccess)
            {
                HomeController hc = new HomeController();
                Cache HomeCache = hc.GetCacheObject();
                HomeCache.Remove("Notebook_Pages_" + BookId);
                HomeCache.Remove("Viewbag_Notebook_Pages_" + BookId);

                json = "{\"Status\":\"1\"}";
            }
            else
            {
                json = "{\"Status\":\"-1\"}";
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult Ad_LoadBy_BookId(string bookId, string city)
        {
            AdvertisementModels model = new AdvertisementModels();
            List<Categories> CategoryList = new List<Categories>();
            PagesBase pageBase = new PagesBase();
            PagesAction pageAction = new PagesAction();
            pageBase.BookId = Convert.ToInt64(bookId);
            pageBase.UserId = Convert.ToInt32(Session["UserId"]);
            pageBase.CityName = city;
            actionResult = pageAction.Ad_LoadBy_BookId(pageBase);
            if (actionResult.IsSuccess)
            {
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    //var cat = actionResult.dtResult.Rows[0];
                    foreach (DataRow cat in actionResult.dtResult.Rows)
                    {
                        Categories catModel = new Categories();
                        catModel.adcreationId = Convert.ToInt32(cat["adcreationId"]);
                        catModel.aduploadedId = Convert.ToInt32(cat["aduploadedId"]);
                        catModel.UserId = Convert.ToInt32(cat["UserId"]);
                        catModel.FileUploaded = cat["FileUploaded"].ToString();
                        catModel.StudentName = cat["StudentName"].ToString();
                        catModel.FileName = cat["FileName"].ToString();
                        catModel.Headline = cat["Headline"].ToString();
                        catModel.Description = cat["Description"].ToString();
                        catModel.Features = cat["Features"].ToString();
                        catModel.Price = Convert.ToDecimal(cat["Price"]);
                        catModel.MobileNumber = cat["MobileNumber"].ToString();
                        catModel.Type = Convert.ToInt32(cat["Type"]);
                        catModel.UrlAddress = cat["UrlAddress"].ToString();
                        CategoryList.Add(catModel);
                    }

                }
            }
            model.CategoryList = CategoryList;
            return Json(model, JsonRequestBehavior.AllowGet);
            //return CategoryList;
        }

        public JsonResult RemoveAd(int AdId)
        {
            string message = "";

            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.adId = Convert.ToInt32(AdId);
            actionResult = advertisementaction.Advertisement_Delete(advertisementbase);
            if (actionResult.IsSuccess)
            {
                message = "success";
            }
            else
            {
                message = "failure";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateClickCount(int AdId, int userId, int BookId)
        {
            string message = "";

            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.adId = Convert.ToInt32(AdId);
            advertisementbase.BookId = BookId;
            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            actionResult = advertisementaction.saveAd_Clicks(advertisementbase);
            if (actionResult.IsSuccess)
            {
                message = "success";
            }
            else
            {
                message = "failure";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [CheckLogin]
        public ActionResult SubmittersAccount(int AdId)
        {
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementModels model = new AdvertisementModels();
            advertisementbase.adId = Convert.ToInt32(AdId);

            actionResult = advertisementaction.GetClickCount_ByAdId(advertisementbase);
            if (actionResult.IsSuccess)
            {
                model.ClicksCount = (actionResult.dtResult.Rows[0][0] != DBNull.Value && actionResult.dtResult.Rows[0][0] != string.Empty ? Convert.ToInt32(actionResult.dtResult.Rows[0][0]) : 0);
                ViewBag.AmountPending = (actionResult.dtResult.Rows[0][1] != DBNull.Value && actionResult.dtResult.Rows[0][1] != string.Empty ? Convert.ToInt32(actionResult.dtResult.Rows[0][1]) : 0);
            }
            actionResult = advertisementaction.PriceTable_S();
            if (actionResult.IsSuccess)
            {
                model.AmountPaid = (actionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(actionResult.dtResult.Rows[0][0]) : 0);
            }
            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            model.AmountRequested = (model.ClicksCount * model.AmountPaid);
            actionResult = advertisementaction.getAccountDetails_ByUserId(advertisementbase);
            if (actionResult.IsSuccess)
            {
                try
                {
                    //model.AccountNumber = actionResult.dtResult.Rows[0][2] != DBNull.Value ? Decode(actionResult.dtResult.Rows[0][2].ToString()) : "";
                    //model.IFSCCode = actionResult.dtResult.Rows[0][6] != DBNull.Value ? Decode(actionResult.dtResult.Rows[0][6].ToString()) : "";
                    model.AccountHolderName = actionResult.dtResult.Rows[0][8] != DBNull.Value ? Convert.ToString(actionResult.dtResult.Rows[0][8]) : "";
                }
                catch (Exception ex)
                {
                }
            }
            List<AdvertisementModels> paymentList = new List<AdvertisementModels>();

            actionResult = advertisementaction.PaymentRequest_LoadByUserId(advertisementbase);
            if (actionResult.IsSuccess)
            {
                paymentList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AdvertisementModels>(actionResult.dtResult);
            }

            model.PaymentList = paymentList;
            model.adcreationId = AdId;
            return View(model);
        }

        //[HttpPost]
        //public JsonResult SavePaymentRequest(AdvertisementModels model)
        //{
        //    AdvertisementBase advertisementbase = new AdvertisementBase();
        //    AdvertisementAction advertisementaction = new AdvertisementAction();

        //    advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
        //    //advertisementbase.AccountNumber = Encode(model.AccountNumber);
        //    //advertisementbase.IFSCCode = Encode(model.IFSCCode);
        //    advertisementbase.Currency = model.Currency;
        //    advertisementbase.ExchangeRate = model.ExchangeRate;
        //    advertisementbase.AmountRequested = Convert.ToDecimal(model.WalletAmount);
        //    //advertisementbase.AccountHolderName = model.AccountHolderName;
        //    advertisementbase.EmailId = model.EmailId;
        //    actionResult = advertisementaction.PaymentRequest_IU(advertisementbase);
        //    Session["Payment_ID"] = actionResult.dtResult.Rows[0].ItemArray[0];

        //    if (actionResult.IsSuccess)
        //    {
        //        TempData["SuccessMessage"] = "Your request has been saved successfully.";
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Error in saving your request. Please try again later.";
        //    }
        //    return Json("Success");
        //}



        [HttpGet]
        public JsonResult Get_users_Country_CurrencyCodeandRate()
        {
            StudentRegistration model = new StudentRegistration();

            List<CurrencyRate> CurrencyList = new List<CurrencyRate>();
            commonBase.Id = Convert.ToInt32(Session["UserId"]);
            var Ratedata = commonAction.Get_users_Country_CurrencyCodeandRate(commonBase);
            if (Ratedata.IsSuccess)
            {
                CurrencyList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<CurrencyRate>(Ratedata.dtResult);
                Session["Rate"] = CurrencyList[0].Rate;
            }

            return Json(CurrencyList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult subjectforautocomplete()
        {
            STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
            STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
            List<Subjects> Subjectslist = new List<Subjects>();

            StudentRegistration model = new StudentRegistration();

            actionResult = commonAction.Subjects_LoadAll();
            if (actionResult.IsSuccess)
            {
                Subjectslist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(actionResult.dtResult);

            }
            return Json(Subjectslist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ShowpaypalEmail_IU()
        {
            SubmitterRegistration model = new SubmitterRegistration();
            List<PayPalEmail> PayPalEmailList = new List<PayPalEmail>();
            commonBase.Id = Convert.ToInt32(Session["UserId"]);
            var data = commonAction.Paypaldetails(commonBase);
            if (data.IsSuccess)
            {
                PayPalEmailList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<PayPalEmail>(data.dtResult);
            }
            return Json(PayPalEmailList, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Paypaldetails_Insert_Update(AdvertisementModels model)
        {
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            advertisementbase.EmailId = model.AdvertiserEmialId;
            actionResult = advertisementaction.Paypaldetails_Insert_Update(advertisementbase);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Saved PayPalEmail successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in saving your PayPalEmail. Please try again later.";
            }
            return RedirectToAction("AccountSettings", "User");
        }

        public JsonResult Update_Wallet_ByuserId()
        {
            SubmitterRegistration model = new SubmitterRegistration();
            List<Wallet> WalletList = new List<Wallet>();
            commonBase.Id = Convert.ToInt32(Session["UserId"]);
            var data = commonAction.Update_Wallet_ByuserId(commonBase);

            if (data.IsSuccess)
            {
                WalletList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Wallet>(data.dtResult);
            }

            return Json(WalletList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ForConvertCurrency_GetPrimaryRate()
        {
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();

            List<CurrencyRate> CurrencyList = new List<CurrencyRate>();
            var Ratedata = advertisementaction.ForConvertCurrency_GetPrimaryRate(advertisementbase);
            if (Ratedata.IsSuccess)
            {
                CurrencyList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<CurrencyRate>(Ratedata.dtResult);
            }

            return Json(CurrencyList, JsonRequestBehavior.AllowGet);
        }

        ////[HttpGet]
        //[Route("User/AccountSettings")]
        //public ActionResult ShowUPIDetails()
        //{
        //    AdvertisementModels model = new AdvertisementModels();
        //    //List<UPIDetails> UPIDetailsList = new List<UPIDetails>();
        //    commonBase.Id = Convert.ToInt32(Session["UserId"]);
        //    var data = commonAction.GetUPIDetails_ByuserId(commonBase);
        //    if (data.IsSuccess)
        //    {
        //        model.BankAccountHolderName = data.dtResult.Rows[0].ItemArray[1].ToString();
        //        model.UPIId = data.dtResult.Rows[0].ItemArray[2].ToString();
        //        model.MobileNumberUPI = data.dtResult.Rows[0].ItemArray[3].ToString();
        //        //UPIDetailsList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<UPIDetails>(data.dtResult);
        //    }
        //    return View("~/Views/User/AccountSettings.cshtml", model);
        //}

        #region UPI Insert/Update
        public ActionResult UPIdetails_Insert_Update(AdvertisementModels model)
        {
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            advertisementbase.BankAccountHolderName = model.BankAccountHolderName;
            advertisementbase.UPIId = model.UPIId;
            advertisementbase.MobileNumberUPI = model.MobileNumberUPI;
            actionResult = advertisementaction.UPIdetails_Insert_Update(advertisementbase);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Saved UPI Details successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in saving your UPI Details. Please try again later.";
            }
            return RedirectToAction("AccountSettings", "User");
        }
        #endregion

        #region SavePaymentRequest
        [HttpPost]
        public JsonResult SavePaymentRequest(AdvertisementModels model)
        {
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();

            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            advertisementbase.BankAccountHolderName = model.BankAccountHolderName;
            advertisementbase.UPIId = model.UPIId;
            advertisementbase.MobileNumberUPI = model.MobileNumberUPI;
            advertisementbase.Currency = model.Currency;
            advertisementbase.AmountRequested = Convert.ToDecimal(model.WalletAmount);
            advertisementbase.EmailId = model.EmailId;
            actionResult = advertisementaction.PaymentRequest_UPI(advertisementbase);
            Session["Payment_ID"] = actionResult.dtResult.Rows[0].ItemArray[0];

            if (actionResult.IsSuccess)
            {
                string Attachment = SaveUPIDetailsinCSV(model);
                if (Attachment != "")
                {
                    AccountingSoftware.Helper.Email.SendUPIDetails(Attachment);
                }
                TempData["SuccessMessage"] = "Your request has been saved successfully. Your amount will be send at the end of this month";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in saving your request. Please try again later.";
            }
            return Json("Success");
        }
        #endregion

        #region Save in CSV
        public string SaveUPIDetailsinCSV(AdvertisementModels model)
        {
            try
            {
                List<string> list = new List<string>();
                
                list.Add(Session["FirstName"].ToString());
                list.Add(model.BankAccountHolderName);
                list.Add(model.UPIId);
                list.Add(model.MobileNumberUPI);
                list.Add(Convert.ToString(model.WalletAmount));
                string[] UPIDetails = list.ToArray();
                string UPItoCSV = Common.ConvertToCSV(UPIDetails);

                
                //File creation
                string MonthYear = DateTime.Today.Year.ToString();
                string Month = DateTime.Today.Month.ToString();
                StringBuilder str1 = new StringBuilder(Month);
                str1.Append(MonthYear);
                var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Excels");
                string pathString = System.IO.Path.Combine(path, str1.ToString());
                if (Directory.Exists(pathString))
                {
                    string fileName = "UPIDetails.csv";
                    // Use Combine again to add the file name to the path.
                    pathString = System.IO.Path.Combine(pathString, fileName);
                    //using (StreamWriter sw = new StreamWriter(System.IO.File.OpenWrite(pathString)))
                    //{
                    //    string text = "\r\n";
                    //    sw.Write(text + UPItoCSV);
                    //}
                    if (System.IO.File.Exists(pathString))
                    {
                        using (StreamWriter sw = System.IO.File.AppendText(pathString))
                        {
                            string text = "\r\n";
                            sw.Write(text + UPItoCSV);
                        }
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    string fileName = "UPIDetails.csv";
                    // Use Combine again to add the file name to the path.
                    pathString = System.IO.Path.Combine(pathString, fileName);
                    using (StreamWriter sw = new StreamWriter(System.IO.File.OpenWrite(pathString)))
                    {
                        string text = "\r\n";
                        sw.Write(text + UPItoCSV);
                    }
                }
                return pathString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Bank Insert/Update
        public ActionResult Bankdetails_Insert_Update(AdvertisementModels model)
        {
            AdvertisementBase advertisementbase = new AdvertisementBase();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            advertisementbase.BankAccountHolderName = model.BankAccountHolderName;
            advertisementbase.BankAccountNumber = model.BankAccountNumber;
            advertisementbase.BankIFSCCode = model.BankIFSCCode;
            advertisementbase.MobileNumberUPI = model.MobileNumberUPI;
            actionResult = advertisementaction.Bankdetails_Insert_Update(advertisementbase);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Saved Bank Details successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in saving your UPI Details. Please try again later.";
            }
            return RedirectToAction("AccountSettings", "User");
        }
        #endregion

        #region SavePaymentRequest
        [HttpPost]
        public JsonResult SavePaymentRequestBank(AdvertisementModels model)
        {
            try
            {
                AdvertisementBase advertisementbase = new AdvertisementBase();
                AdvertisementAction advertisementaction = new AdvertisementAction();

                advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
                advertisementbase.BankAccountHolderName = model.BankAccountHolderName;
                advertisementbase.BankAccountNumber = model.BankAccountNumber;
                advertisementbase.BankIFSCCode = model.BankIFSCCode;
                advertisementbase.MobileNumberUPI = model.MobileNumberUPI;
                advertisementbase.Currency = model.Currency;
                advertisementbase.AmountRequested = Convert.ToDecimal(model.WalletAmount);
                advertisementbase.EmailId = model.EmailId;
                actionResult = advertisementaction.PaymentRequest_Bank(advertisementbase);
                Session["Payment_ID"] = actionResult.dtResult.Rows[0].ItemArray[0];

                if (actionResult.IsSuccess)
                {
                    //string Attachment = SaveBankDetailsinCSV(model);
                    //if (Attachment != "")
                    //{
                    //AccountingSoftware.Helper.Email.SendUPIDetails(Attachment);
                    //}
                    TempData["SuccessMessage"] = "Your request has been saved successfully. Your amount will be send at the end of this month";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in saving your request. Please try again later.";
                }
            }
            catch(Exception e)
            {
                throw (e);
            }
            return Json("Success");
        }
        #endregion

        #region Save in CSV
        public string SaveBankDetailsinCSV(AdvertisementModels model)
        {
            try
            {
                List<string> list = new List<string>();

                list.Add(Session["FirstName"].ToString());
                list.Add(model.BankAccountHolderName);
                list.Add(model.BankAccountNumber);
                list.Add(model.BankIFSCCode);
                list.Add(model.MobileNumberUPI);
                list.Add(Convert.ToString(model.WalletAmount));
                string[] BankDetails = list.ToArray();
                string BanktoCSV = Common.ConvertToCSV(BankDetails);


                //File creation
                string MonthYear = DateTime.Today.Year.ToString();
                string Month = DateTime.Today.Month.ToString();
                StringBuilder str1 = new StringBuilder(Month);
                str1.Append(MonthYear);
                var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Excels");
                string pathString = System.IO.Path.Combine(path, str1.ToString());
                if (Directory.Exists(pathString))
                {
                    string fileName = "BankDetails.csv";
                    // Use Combine again to add the file name to the path.
                    pathString = System.IO.Path.Combine(pathString, fileName);
                    //using (StreamWriter sw = new StreamWriter(System.IO.File.OpenWrite(pathString)))
                    //{
                    //    string text = "\r\n";
                    //    sw.Write(text + UPItoCSV);
                    //}
                    if (System.IO.File.Exists(pathString))
                    {
                        using (StreamWriter sw = System.IO.File.AppendText(pathString))
                        {
                            string text = "\r\n";
                            sw.Write(text + BanktoCSV);
                        }
                    }
                    else 
                    {
                        using (StreamWriter sw = System.IO.File.AppendText(pathString))
                        {
                            sw.Write(BanktoCSV);
                        }
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    string fileName = "BankDetails.csv";
                    // Use Combine again to add the file name to the path.
                    pathString = System.IO.Path.Combine(pathString, fileName);
                    using (StreamWriter sw = new StreamWriter(System.IO.File.OpenWrite(pathString)))
                    {
                        string text = "\r\n";
                        sw.Write(text + BanktoCSV);
                    }
                }
                return pathString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}
