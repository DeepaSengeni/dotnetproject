using Newtonsoft.Json;
using STU.ActionLayer.Answers;
using STU.ActionLayer.Book;
using STU.ActionLayer.Common;
using STU.ActionLayer.Invitation;
using STU.ActionLayer.Pages;
using STU.ActionLayer.Questions;
using STU.ActionLayer.User;
using STU.BaseLayer;
using STU.BaseLayer.Answers;
using STU.BaseLayer.Book;
using STU.BaseLayer.Common;
using STU.BaseLayer.Invitations;
using STU.BaseLayer.Pages;
using STU.BaseLayer.Questions;
using STU.BaseLayer.User;
using STU.Utility;
using StudentAppWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace StudentAppWebsite.WebServices
{
    /// <summary>
    /// Summary description for BooksService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class BooksService : System.Web.Services.WebService
    {
        string siteUrl = System.Configuration.ConfigurationManager.AppSettings["site"].ToString();

        #region Answers Related Methods

        AnswersBase answersBase;
        AnswerAction answerAction = new AnswerAction();
        ActionResult actionResult;

        #region Answers_InsertUpdate
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Answers_InsertUpdate(Int64 Id, Int64 QuestionId, string Answer, string AnswerImage, Int64 UserId)
        {
            string uploadedFileName = string.Empty;
            string json = string.Empty;

            answersBase = new AnswersBase();
            actionResult = new ActionResult();
            try
            {
                // byte[] bytes = Convert.FromBase64String(AnswerImage);//  System.Text.Encoding.ASCII.GetBytes(AnswerImage);
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(AnswerImage);

                if (!System.IO.Directory.Exists(Server.MapPath("/Content/Uploads/AnswerImages/")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("/Content/Uploads/AnswerImages/"));
                }
                // Read the byte array and save this to folder
                MemoryStream ms = new MemoryStream(bytes);

                if (AnswerImage != null && AnswerImage.Length > 0)
                {
                    uploadedFileName = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), "_AnswerImage.png");
                    FileStream fs = new FileStream(Server.MapPath("/Content/Uploads/AnswerImages/") + uploadedFileName, FileMode.Create);

                    // write the memory stream containing the original
                    ms.WriteTo(fs);

                    // clean up
                    ms.Close();
                    fs.Close();
                    fs.Dispose();
                }


                answersBase.Id = Id;
                answersBase.QuestionId = QuestionId;
                answersBase.Answer = Answer;
                if (!String.IsNullOrEmpty(uploadedFileName))
                    answersBase.AnswerImage = siteUrl + "/Content/Uploads/AnswerImages/" + uploadedFileName;
                answersBase.UserId = UserId;
                actionResult = answerAction.Answers_InsertUpdate(answersBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Answers_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Answers_LoadAll()
        {
            string json = string.Empty;

            answersBase = new AnswersBase();
            actionResult = new ActionResult();
            try
            {
                actionResult = answerAction.Answers_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Record Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Answers_LoadBy_UserId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Answers_LoadBy_UserId(Int64 UserId)
        {
            string uploadedFileName = string.Empty;
            string json = string.Empty;

            answersBase = new AnswersBase();
            actionResult = new ActionResult();
            try
            {
                answersBase.UserId = UserId;
                actionResult = answerAction.Answers_LoadBy_UserId(answersBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Answers_LoadBy_QuestionId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Answers_LoadBy_QuestionId(Int64 QuestionId)
        {
            string uploadedFileName = string.Empty;
            string json = string.Empty;

            answersBase = new AnswersBase();
            actionResult = new ActionResult();
            try
            {
                answersBase.QuestionId = QuestionId;
                actionResult = answerAction.Answers_LoadBy_QuestionId(answersBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion



        //#region Answers_LoadBy_QuestionId
        //[WebMethod]
        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        //public void Answers_LoadBy_QuestionId(Int64 QuestionId)
        //{
        //    string uploadedFileName = string.Empty;
        //    string json = string.Empty;

        //    answersBase = new AnswersBase();
        //    actionResult = new ActionResult();
        //    try
        //    {
        //        answersBase.QuestionId = QuestionId;
        //        actionResult = answerAction.LoadAllNotifications(answersBase);
        //        if (actionResult.IsSuccess)
        //            json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
        //        else
        //            json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
        //    }
        //    catch (Exception ex)
        //    {
        //        json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
        //        ErrorReporting.WebApplicationError(ex);
        //    }
        //    WriteDataToHttpResponse(json);
        //}
        //#endregion





        #region Answers_Delete_By_Id
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Answers_Delete_By_Id(Int64 Id)
        {
            string uploadedFileName = string.Empty;
            string json = string.Empty;

            answersBase = new AnswersBase();
            actionResult = new ActionResult();
            try
            {
                answersBase.Id = Id;
                actionResult = answerAction.Answers_Delete_By_Id(answersBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\"}";
            WriteDataToHttpResponse(json);
        }
        #endregion



        #region UsersInfo_Load_AllFriends
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UsersInfo_Load_AllFriends(int UserId ,int offset, int limit)
        {
            string uploadedFileName = string.Empty;
            string json = string.Empty;

            usersInfoBase = new UsersInfoBase();
            actionResult = new ActionResult();
            commonBase = new CommonBase();
            try
            {
                commonBase.Id = UserId;
                actionResult = commonAction.FriendList_LoadByUserId(commonBase);
                DataTable table = (from c in actionResult.dtResult.AsEnumerable()  select c).Skip(offset).Take(limit).CopyToDataTable();
                if (actionResult.IsSuccess)
                    json = JsonConvert.SerializeObject(table, Formatting.Indented);
                //json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion




        #region InvitationList_UpdateStatus
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void InvitationList_UpdateStatus(int Id, int requestStatus, int type)//Id=invitationListId/FriendRequestId,Status=1(Accept)/2(Reject),type=2
        {
            string uploadedFileName = string.Empty;
            string json = string.Empty;

            UsersInfoBase usersInfoBase = new UsersInfoBase();
            usersInfoBase.Id = Id;
            usersInfoBase.TopicId = type;
            usersInfoBase.RequestStatus = requestStatus;
            actionResult = new ActionResult();
            UserAction userAction = new UserAction();
            try
            {
                actionResult = userAction.InvitationList_UpdateStatus(usersInfoBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\"}";
            WriteDataToHttpResponse(json);
        }
        #endregion

        #endregion

        #region Books Related Methods
        BookBase bookBase;
        BookAction bookAction = new BookAction();

        #region Books_InsertUpdate
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Books_InsertUpdate(Int64 Id, string BookTitle, string CoverPageImage, string BackPageImage, int ExamStreamId, int EntranceExamId,
            string StudentName, string TeachersName, int TotalPages, string BookType, int SubjectId, int ChapterId, Int64 UserId)
        {
            string uploadedCoverPageImageName = string.Empty;
            string json = string.Empty;

            bookBase = new BookBase();
            actionResult = new ActionResult();
            try
            {
                byte[] bytes = Convert.FromBase64String(CoverPageImage);// System.Text.Encoding.ASCII.GetBytes(CoverPageImage);
                byte[] bytes1 = Convert.FromBase64String(BackPageImage);// System.Text.Encoding.ASCII.GetBytes(BackPageImage);

                if (!System.IO.Directory.Exists(Server.MapPath("/Content/Uploads/BooksImages/")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("/Content/Uploads/BooksImages/"));
                }
                // Read the byte array and save this to folder
                MemoryStream ms = new MemoryStream(bytes);

                if (CoverPageImage != null && CoverPageImage.Length > 0)
                {
                    uploadedCoverPageImageName = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), "_BookCoverPageImage.png");
                    FileStream fs = new FileStream(Server.MapPath("/Content/Uploads/BooksImages/") + uploadedCoverPageImageName, FileMode.Create);

                    // write the memory stream containing the original
                    ms.WriteTo(fs);

                    // clean up
                    ms.Close();
                    fs.Close();
                    fs.Dispose();
                }


                string uploadedBackPageImage = string.Empty;

                // Read the byte array and save this to folder
                MemoryStream ms1 = new MemoryStream(bytes1);

                if (BackPageImage != null && BackPageImage.Length > 0)
                {
                    uploadedBackPageImage = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), "_BookBackPageImage.png");

                    FileStream fs1 = new FileStream(Server.MapPath("/Content/Uploads/BooksImages/") + uploadedBackPageImage, FileMode.Create);

                    // write the memory stream containing the original
                    ms1.WriteTo(fs1);

                    // clean up
                    ms1.Close();
                    fs1.Close();
                    fs1.Dispose();
                }

                bookBase.Id = Id;
                bookBase.BookTitle = BookTitle;
                if (!String.IsNullOrEmpty(uploadedCoverPageImageName))
                    bookBase.CoverPageImage = siteUrl + "/Content/Uploads/BooksImages/" + uploadedCoverPageImageName;
                if (!String.IsNullOrEmpty(uploadedBackPageImage))
                    bookBase.BackPageImage = siteUrl + "/Content/Uploads/BooksImages/" + uploadedBackPageImage;
                bookBase.ExamStreamId = ExamStreamId;
                bookBase.EntranceExamId = EntranceExamId;
                bookBase.StudentName = StudentName;
                bookBase.TeachersName = TeachersName;
                bookBase.TotalPages = TotalPages;
                bookBase.BookType = BookType;
                bookBase.SubjectId = SubjectId;
                bookBase.ChapterId = ChapterId;
                bookBase.UserId = UserId;
                actionResult = bookAction.Books_InsertUpdate(bookBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\",\"Message\":\"Error in saving the book record. Please try again later\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }

        #endregion

        #region Books_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Books_LoadAll(int offset, int limit)
        {
            string json = string.Empty;

            actionResult = new ActionResult();
            try
            {
                actionResult = bookAction.Books_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult.Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable()), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Books_LoadBy_Id
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Books_LoadBy_Id(Int64 Id)
        {
            string json = string.Empty;
            bookBase = new BookBase();
            actionResult = new ActionResult();
            try
            {
                bookBase.Id = Id;
                actionResult = bookAction.Books_LoadBy_Id(bookBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Books_LoadBy_UserId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Books_LoadBy_UserId(Int64 UserId)
        {
            string json = string.Empty;
            bookBase = new BookBase();
            actionResult = new ActionResult();
            try
            {
                bookBase.UserId = UserId;
                actionResult = bookAction.Books_LoadBy_UserId(bookBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Books_LoadBy_Filter
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Books_LoadBy_Filter(int CountryId, int StateId, int StreamId, int EntranceExamId, int SubjectId, int ChapterId)
        {
            string json = string.Empty;
            bookBase = new BookBase();
            actionResult = new ActionResult();
            try
            {

                bookBase.CountryId = CountryId;
                bookBase.StateId = StateId;
                bookBase.ExamStreamId = StreamId;
                bookBase.EntranceExamId = EntranceExamId;
                bookBase.SubjectId = SubjectId;
                bookBase.ChapterId = ChapterId;

                actionResult = bookAction.Books_LoadBy_Filter(bookBase);

                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Record Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Books_Delete_By_Id
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Books_Delete_By_Id(Int64 Id)
        {
            string json = string.Empty;
            bookBase = new BookBase();
            actionResult = new ActionResult();
            try
            {
                bookBase.Id = Id;
                actionResult = bookAction.Books_Delete_By_Id(bookBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\",\"Message\":\"Error in deleting the record.\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region NoteBooks_InsertUpdate
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void NoteBooks_InsertUpdate(int Id, string ChapterName, string SubjectName, string TeachersName, string CollegeName, string CategoryName, string StreamName, DateTime Date, string BookType, string CardHolderName, string CardNumber, DateTime ExpiryDate, int UserId)
        {
            string uploadedCoverPageImageName = string.Empty;
            string json = string.Empty;

            CommonBase bookBase = new CommonBase();
            actionResult = new ActionResult();
            try
            {


                bookBase.Id = Id;
                bookBase.ChapterId = (!string.IsNullOrEmpty(ChapterName) ? ChapterName.Split(',')[0] : "");
                bookBase.ChapterName = ChapterName;
                bookBase.InstituteName = CollegeName;
                bookBase.CategoryName = CategoryName;
                bookBase.StreamName = StreamName;
                bookBase.StartDate = Date;
                bookBase.CardHolderName = CardHolderName;
                bookBase.CardNumber = CardNumber;
                bookBase.ExpirationDate = ExpiryDate;
                bookBase.TeacherName = TeachersName;
                bookBase.Type = BookType;
                bookBase.SubjectName = SubjectName;
                bookBase.ChapterName = ChapterName;
                bookBase.UserId = UserId;
                actionResult = commonAction.NotebookDetails_Insert(bookBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\",\"result\":" + actionResult.dtResult.Rows[0][0] + "}" : "{\"Status\":\"Error\",\"Message\":\"Error in saving the notebook record. Please try again later\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }

        #endregion

        #endregion

        #region Book Rating Related Methods
        BooksRatingBase bookRatingBase;

        #region BooksRating_InsertUpdate

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void BooksRating_InsertUpdate(Int64 Id, Int64 BookId, Int64 UserId, float Rate, string Comment)
        {
            bookRatingBase = new BooksRatingBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                bookRatingBase.Id = Id;
                bookRatingBase.BookId = BookId;
                bookRatingBase.UserId = UserId;
                bookRatingBase.Rate = Rate;
                bookRatingBase.Comment = Comment;
                actionResult = bookAction.BooksRating_InsertUpdate(bookRatingBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\",\"Message\":\"Error in book rating\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #region BooksRating_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void BooksRating_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = bookAction.BooksRating_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region BooksRating_LoadBy_BookId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void BooksRating_LoadBy_BookId(Int64 BookId)
        {
            bookRatingBase = new BooksRatingBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                bookRatingBase.BookId = BookId;
                actionResult = bookAction.BooksRating_LoadBy_BookId(bookRatingBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region BooksRating_LoadBy_UserId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void BooksRating_LoadBy_UserId(Int64 UserId)
        {
            bookRatingBase = new BooksRatingBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                bookRatingBase.UserId = UserId;
                actionResult = bookAction.BooksRating_LoadBy_UserId(bookRatingBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #endregion

        #region Common Tasks Related Methods

        CommonBase commonBase;
        CommonAction commonAction = new CommonAction();

        #region Countries_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Countries_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.Countries_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region States_LoadBy_CountryId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void States_LoadBy_CountryId(int CountryId)
        {
            actionResult = new ActionResult();
            commonBase = new CommonBase();
            string json = string.Empty;
            try
            {
                commonBase.CountryId = CountryId;
                actionResult = commonAction.States_LoadBy_CountryId(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Cities_LoadBy_StateId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Cities_LoadBy_StateId(int StateId)
        {
            actionResult = new ActionResult();
            commonBase = new CommonBase();
            string json = string.Empty;
            try
            {
                commonBase.StateId = StateId;
                actionResult = commonAction.Cities_LoadBy_StateId(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region EntranceExam_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void EntranceExam_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.EntranceExam_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region ExamStream_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ExamStream_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.ExamStream_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Subjects_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Subjects_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.Subjects_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Streams_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Streams_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.Streams_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Chapters_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Chapters_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.Chapters_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Colleges_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Colleges_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.Colleges_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Categories_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Categories_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.Categories_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Record Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Topics_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Topics_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                actionResult = commonAction.Topics_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Record Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Masters_InsertUpdate
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Masters_InsertUpdate(int Id, string Name, string Type)
        {
            CommonMastersBase commonMastersBase = new CommonMastersBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                commonMastersBase.Id = Id;
                commonMastersBase.Name = Name;
                commonMastersBase.Type = Type;

                actionResult = commonAction.Masters_InsertUpdate(commonMastersBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\",\"Message\":\"Error in saving the record.\"}";

            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Subjects_LoadById
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Subjects_LoadById(Int64 id)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.Id = Convert.ToInt32(id);
                actionResult = commonAction.Subjects_LoadById(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion


        #region Subjects_LoadByStreamId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Subjects_LoadByStreamId(Int64 id)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.SteamId = Convert.ToInt32(id);
                actionResult = commonAction.SubjectLoadByStreamId(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Chapter_LoadById
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Chapter_LoadById(Int64 id)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.Id = Convert.ToInt32(id);
                actionResult = commonAction.Chapter_LoadById(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Institute_LoadById
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Institute_LoadById(Int64 streamId, Int64 categoryId)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.CategoryId = Convert.ToInt32(categoryId);
                commonBase.SteamId = Convert.ToInt32(streamId);
                actionResult = commonAction.Institute_LoadById(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Stream_LoadById
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Stream_LoadById(Int64 id)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.Id = Convert.ToInt32(id);
                actionResult = commonAction.Stream_LoadById(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region StreamsLoadByCategoryID
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void StreamsLoadByCategoryID(Int64 id)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.Id = Convert.ToInt32(id);
                actionResult = commonAction.StreamsLoadByCategoryID(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion



        #region Category_LoadById
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Category_LoadById(Int64 id)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.Id = Convert.ToInt32(id);
                actionResult = commonAction.Category_LoadById(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #endregion

        #region Invitation Related Methods

        InvitationListBase invitationListBase;
        InvitationListAction invitationListAction = new InvitationListAction();

        #region InvitationList_InsertUpdate

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void InvitationList_InsertUpdate(int UserId, int InvitedUserId, int pageId)
        {
            invitationListBase = new InvitationListBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                               
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = UserId;
                usersInfoBase.InvitedUserId = InvitedUserId;
                usersInfoBase.TopicId = pageId;
                userAction = new UserAction();
                actionResult = new STU.BaseLayer.ActionResult();
                actionResult = userAction.InvitationList_InsertUpdate(usersInfoBase);
                if (actionResult.IsSuccess)
                    json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\",\"Message\":\"Error in inviting the user.\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region InvitationList_LoadBy_UserId

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void InvitationList_LoadBy_UserId(int UserId, int offset, int limit)
        {
            //invitationListBase = new InvitationListBase();
            //actionResult = new ActionResult();
            //string json = string.Empty;
            //try
            //{
            //    invitationListBase.UserId = UserId;
            //    actionResult = invitationListAction.InvitationList_LoadBy_UserId(invitationListBase);
            //    if (actionResult.IsSuccess)
            //        json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
            //    else
            //        json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            //}
            //catch (Exception ex)
            //{
            //    json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
            //    ErrorReporting.WebApplicationError(ex);
            //}
            //WriteDataToHttpResponse(json);




            //try
            //{
            //    invitationListBase.UserId = UserId;
            //    actionResult = invitationListAction.InvitationList_LoadBy_UserId(invitationListBase);
            //    if (actionResult.IsSuccess)
            //    {
            //        //  string json = string.Empty;
            //        foreach (System.Data.DataRow dr in actionResult.dtResult.Rows)
            //        {
            //            json += "{\"Id\":\"" + dr["Id"].ToString() + "\",\"UserId\":\"" + dr["UserId"].ToString() + "\",\"InvitedUserId\":\"" +
            //                    dr["InvitedUserId"].ToString() + "\",\"InvitedUser\":\"" + dr["InvitedUser"].ToString() + "\",\"InvitedProfileImage\":\"" +
            //                    dr["InvitedProfileImage"].ToString() + "\"," + "\"submittedBy\":\"" + dr["submittedBy"].ToString() + "\"," + "\"pageTitle\":\"" + dr["pageTitle"].ToString() + "\"," + "\"StudentName\":\"" + dr["StudentName"].ToString() + "\", \"ProfileImage\":\"" + dr["ProfileImage"].ToString() + "\",\"CreatedDate\":\"" + dr["CreatedDate"].ToString() + "\",\"ModifiedDate\":\"" + dr["ModifiedDate"].ToString() + "\",\"EntranceExamName\":\"" + dr["EntranceExamName"].ToString() + "\",\"ExamName\":\"" + dr["ExamName"].ToString() + "\",\"StreamName\":\"" + dr["StreamName"].ToString() + "\"},";


            //        }


            //        string _str = json.Remove(json.LastIndexOf(','));

            //        json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":[", _str, "]}");
            //    }
            //    else
            //        json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            //}
            //catch (Exception ex)
            //{
            //    json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
            //    ErrorReporting.WebApplicationError(ex);
            //}

            //WriteDataToHttpResponse(json);

            questionBase = new QuestionsBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedFileName = string.Empty;


            commonBase = new CommonBase();
            try
            {
                commonBase.UserId = UserId;
                actionResult = commonAction.NotificationsCount(commonBase);

                if (actionResult.IsSuccess)
                {
                    //json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                     string data = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[0].Rows.Count > 0 ? actionResult.dsResult.Tables[0].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[0]));
                    //string notifications = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[1].Rows.Count > 0 ? actionResult.dsResult.Tables[1].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[1]));
                    // string friendRequests = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[2].Rows.Count > 0 ? actionResult.dsResult.Tables[2].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[2]));

                    json = "{\"Status\":\"1\",\"Invitations\":" + data + "}";
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"Invitations\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"Invitations\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);

        }
        #endregion

        #endregion

        #region Pages Related Methods
        PagesBase pagesBase;
        PagesAction pagesAction = new PagesAction();

        #region Pages_InsertUpdate
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Pages_InsertUpdate(Int64 Id, Int64 BookId, string PageImage, string PageTitle, int DisplayOrder, string ChapterName)
        {
            pagesBase = new PagesBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedFileName = string.Empty;
            try
            {
                // byte[] bytes =Convert.FromBase64String(PageImage);// System.Text.Encoding.ASCII.GetBytes(PageImage);
                //byte[] bytes = System.Text.Encoding.ASCII.GetBytes(PageImage);

                //if (!System.IO.Directory.Exists(Server.MapPath("/Content/Uploads/book_page/")))
                //{
                //    System.IO.Directory.CreateDirectory(Server.MapPath("/Content/Uploads/book_page/"));
                //}
                //// Read the byte array and save this to folder
                //MemoryStream ms = new MemoryStream(bytes);

                //uploadedFileName = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), "_PagesImage.png");

                //if (PageImage != null && PageImage.Length > 0)
                //{
                //    FileStream fs = new FileStream(Server.MapPath("/Content/Uploads/book_page/") + uploadedFileName, FileMode.Create);

                //    // write the memory stream containing the original
                //    ms.WriteTo(fs);

                //    // clean up
                //    ms.Close();
                //    fs.Close();
                //    fs.Dispose();
                //}

                pagesBase.Id = Id;
                pagesBase.BookId = BookId;
                pagesBase.PageImage = PageImage;
                pagesBase.PageTitle = PageTitle;
                pagesBase.DisplayOrder = DisplayOrder;
                pagesBase.ChapterName = ChapterName;
                actionResult = pagesAction.Pages_InsertUpdate(pagesBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\",\"Message\":\"Error in saving the page.\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Pages_LoadBy_BookId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Pages_LoadBy_BookId(Int64 BookId)
        {
            pagesBase = new PagesBase();
            actionResult = new ActionResult();
            string json = string.Empty;

            try
            {

                pagesBase.BookId = BookId;

                actionResult = pagesAction.Pages_LoadBy_BookId(pagesBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Pages_LoadBy_Id
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Pages_LoadBy_Id(Int64 Id)
        {
            pagesBase = new PagesBase();
            actionResult = new ActionResult();
            string json = string.Empty;

            try
            {

                pagesBase.Id = Id;

                actionResult = pagesAction.Pages_LoadBy_Id(pagesBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #endregion

        #region Questions Related Methods

        QuestionsBase questionBase;
        QuestionsAction questionsAction = new QuestionsAction();

        #region Questions_InsertUpdate
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Questions_InsertUpdate(Int64 Id, Int64 PageId, string QuestionTitle, string QuestionImage, Int64 UserId)
        {
            questionBase = new QuestionsBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedFileName = string.Empty;
            try
            {
                // byte[] bytes = Convert.FromBase64String(QuestionImage);//System.Text.Encoding.ASCII.GetBytes(QuestionImage);

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(QuestionImage);

                if (!System.IO.Directory.Exists(Server.MapPath("/Content/Uploads/QuestionImages/")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("/Content/Uploads/QuestionImages/"));
                }
                // Read the byte array and save this to folder
                MemoryStream ms = new MemoryStream(bytes);

                if (QuestionImage != null && QuestionImage.Length > 0)
                {
                    uploadedFileName = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), "_QuestionImage.png");
                    FileStream fs = new FileStream(Server.MapPath("/Content/Uploads/QuestionImages/") + uploadedFileName, FileMode.Create);

                    // write the memory stream containing the original
                    ms.WriteTo(fs);

                    // clean up
                    ms.Close();
                    fs.Close();
                    fs.Dispose();
                }

                questionBase.Id = Id;
                questionBase.PageId = PageId;
                questionBase.QuestionTitle = QuestionTitle;
                if (!String.IsNullOrEmpty(uploadedFileName))
                    questionBase.QuestionImage = siteUrl + "/Content/Uploads/QuestionImages/" + uploadedFileName;
                questionBase.UserId = UserId;
                actionResult = questionsAction.Questions_InsertUpdate(questionBase);
                json = actionResult.IsSuccess ? "{\"Status\":\"Success\"}" : "{\"Status\":\"Error\",\"Message\":\"Error in saving the question.\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Questions_LoadBy_PageId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Questions_LoadBy_PageId(Int64 PageId)
        {
            questionBase = new QuestionsBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedFileName = string.Empty;
            try
            {
                questionBase.PageId = PageId;
                actionResult = questionsAction.Questions_LoadBy_PageId(questionBase);
                if (actionResult.IsSuccess)
                {
                    string quesStr = string.Empty;
                    foreach (System.Data.DataRow dr in actionResult.dtResult.Rows)
                    {
                        quesStr += "{\"Id\":\"" + dr["Id"].ToString() + "\",\"PageId\":\"" + dr["PageID"].ToString() + "\",\"QuestionImage\":\"" +
                                dr["QuestionImage"].ToString() + "\",\"UserId\":\"" + dr["UserId"].ToString() + "\",\"CreatedDate\":\"" +
                                dr["CreatedDate"].ToString() + "\"," + "\"ModifiedDate\":\"" + dr["ModifiedDate"].ToString() + "\"," + "\"QuestionTitle\":\"" + dr["QuestionTitle"].ToString() + "\"," + "\"StudentName\":\"" + dr["StudentName"].ToString() + "\", \"ProfileImage\":\"" + dr["ProfileImage"].ToString() + "\",\"isLogedin\":\"" + dr["isLogedin"].ToString() + "\"";

                        answersBase = new AnswersBase();
                        ActionResult actionResultAnswers = new ActionResult();
                        string answerStr = string.Empty;

                        answersBase.QuestionId = Convert.ToInt32(dr["Id"]);
                        actionResultAnswers = answerAction.Answers_LoadBy_QuestionId(answersBase);

                        foreach (System.Data.DataRow drAns in actionResultAnswers.dtResult.Rows)
                        {
                            answerStr = "{\"answerID\":\"" + drAns["answerID"].ToString() + "\",\"Answer\":\"" + drAns["Answer"].ToString() + "\",\"AnswerImage\":\"" +
                                drAns["AnswerImage"].ToString() + "\",\"answerUserID\":\"" + drAns["answerUserID"].ToString() + "" +
                                "\",\"CreatedDate\":\"" + drAns["CreatedDate"].ToString() + "\",\"ModifiedDate\":\"" + drAns["ModifiedDate"].ToString() + "\",\"isBlock\":\"" + drAns["isBlock"].ToString() + "\",\"QuestionID\":\"" + drAns["QuestionID"].ToString() + "\",\"QuestionTitle\":\"" + drAns["QuestionTitle"].ToString() + "\",\"QuestionImage\":\"" + drAns["QuestionImage"].ToString() + "\",\"ProfileImage\":\"" + drAns["ProfileImage"].ToString() + "\",\"StudentName\":\"" + drAns["StudentName"].ToString() + "\",\"isLogedin\":\"" + drAns["isLogedin"].ToString() + "\"},";
                        }
                        quesStr += ",\"Answers\":[" + answerStr.Trim(',') + "]},";

                    }
                    //,\"isBlock\":\"" + drAns["isBlock"].ToString() + "\",\"QuestionID\":\"" + drAns["QuestionID"].ToString() + "\",\"QuestionTitle\":\"" + drAns["QuestionTitle"].ToString() + "\",\"QuestionImage\":\"" + drAns["QuestionImage"].ToString() + "\"}
                    //json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");

                    string _str = quesStr.Remove(quesStr.LastIndexOf(','));

                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":[", _str, "]}");
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion


        #region Questions_LoadBy_Id
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Questions_LoadBy_Id(Int64 Id)
        {
            questionBase = new QuestionsBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedFileName = string.Empty;
            try
            {
                questionBase.Id = Id;
                actionResult = questionsAction.Questions_LoadBy_Id(questionBase);

                if (actionResult.IsSuccess)
                {
                    string quesStr = string.Empty;
                    foreach (System.Data.DataRow dr in actionResult.dtResult.Rows)
                    {
                        quesStr += "{\"Id\":\"" + dr["Id"].ToString() + "\",\"PageId\":\"" + dr["QuestionTitle"].ToString() + "\",\"QuestionImage\":\"" +
                                dr["QuestionImage"].ToString() + "\",\"UserId\":\"" + dr["UserId"].ToString() + "\",\"CreatedDate\":\"" +
                                dr["CreatedDate"].ToString() + "\"," + "\"ModifiedDate\":\"" + dr["ModifiedDate"].ToString() + "\"";

                        answersBase = new AnswersBase();
                        ActionResult actionResultAnswers = new ActionResult();
                        string answerStr = string.Empty;

                        answersBase.QuestionId = Convert.ToInt32(dr["Id"]);
                        actionResultAnswers = answerAction.Answers_LoadBy_QuestionId(answersBase);

                        foreach (System.Data.DataRow drAns in actionResultAnswers.dtResult.Rows)
                        {
                            answerStr = "{\"Id\":\"" + drAns["Id"].ToString() + "\",\"QuestionId\":\"" + drAns["Answer"].ToString() + "\",\"QuestionImage\":\"" +
                                drAns["AnswerImage"].ToString() + "\",\"UserId\":\"" + drAns["UserId"].ToString() + "" +
                                "\",\"CreatedDate\":\"" + drAns["CreatedDate"].ToString() + "\",\"ModifiedDate\":\"" + drAns["ModifiedDate"].ToString() + "\"},";
                        }
                        quesStr += ",\"Answers\":[" + answerStr.Trim(',') + "]}";
                    }
                    //json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", quesStr, "}");
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #endregion

        #region Users Related Methods
        UsersInfoBase usersInfoBase;
        UserAction userAction = new UserAction();

        #region UsersInfo_InsertUpdate
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UsersInfo_InsertUpdate(Int64 Id, int UserRole, string StudentName, string ProfileImage, string TeachersName, int ChapterId, int SubjectId, int CollegeId,
            int TopicId, int EntranceExamId, int ExamStreamId, int StreamId, int CategoryId, int CountryId, int StateId, int CityId, string NoteBooksFrontCoverImage, string Date, string ATMNumber, string NameOnATMCard,
            string MobileNumber, string EmailId, string Password, bool IsActive)
        {
            usersInfoBase = new UsersInfoBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedProfileImageName = string.Empty;
            try
            {

                //byte[] bytes = Convert.FromBase64String(ProfileImage); //System.Text.Encoding.ASCII.GetBytes(ProfileImage);
                //byte[] bytes1 = System.Text.Encoding.ASCII.GetBytes(NoteBooksFrontCoverImage);

                //if (!System.IO.Directory.Exists(Server.MapPath("/Content/Uploads/Users/")))
                //{
                //    System.IO.Directory.CreateDirectory(Server.MapPath("/Content/Uploads/Users/"));
                //}

                //if (!System.IO.Directory.Exists(Server.MapPath("/Content/Uploads/BooksImages/")))
                //{
                //    System.IO.Directory.CreateDirectory(Server.MapPath("/Content/Uploads/BooksImages/"));
                //}
                // Read the byte array and save this to folder 
                //MemoryStream ms = new MemoryStream(bytes);

                //if (ProfileImage != null && ProfileImage.Length > 0)
                //{
                //    uploadedProfileImageName = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), "_UserImage.png");

                //}
                //    FileStream fs = new FileStream(Server.MapPath("/Content/Uploads/Users/") + uploadedProfileImageName, FileMode.Create);

                //    // write the memory stream containing the original
                //    ms.WriteTo(fs);

                //    // clean up
                //    ms.Close();
                //    fs.Close();
                //    fs.Dispose();
                //}

                string uploadedNoteBooksFrontCoverImage = string.Empty;

                // Read the byte array and save this to folder
                // MemoryStream ms1 = new MemoryStream(bytes1);

                //if (NoteBooksFrontCoverImage != null && NoteBooksFrontCoverImage.Length > 0)
                //{
                //    uploadedNoteBooksFrontCoverImage = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), "_BookBackPageImage.png");

                //    FileStream fs1 = new FileStream(Server.MapPath("/Content/Uploads/BooksImages/") + uploadedNoteBooksFrontCoverImage, FileMode.Create);

                //    // write the memory stream containing the original
                //    ms1.WriteTo(fs1);

                //    // clean up
                //    ms1.Close();
                //    fs1.Close();
                //    fs1.Dispose();
                //}

                usersInfoBase.Id = Id;
                usersInfoBase.UserRole = UserRole;
                usersInfoBase.StudentName = StudentName;
                //  if (!String.IsNullOrEmpty(uploadedProfileImageName))
                usersInfoBase.ProfileImage = ProfileImage;
                usersInfoBase.TeacherName = TeachersName;
                usersInfoBase.ChapterId = ChapterId;
                usersInfoBase.SubjectId = SubjectId;
                usersInfoBase.CollegeId = CollegeId;

                usersInfoBase.TopicId = TopicId;
                usersInfoBase.EntranceExamId = EntranceExamId;
                usersInfoBase.ExamStreamId = ExamStreamId;

                usersInfoBase.StreamId = StreamId;
                usersInfoBase.CategoryId = CategoryId;
                usersInfoBase.CountryId = CountryId;
                usersInfoBase.StateId = StateId;
                usersInfoBase.CityId = CityId;
                //if (!String.IsNullOrEmpty(uploadedNoteBooksFrontCoverImage))
                usersInfoBase.NoteBooksFrontCoverImage = NoteBooksFrontCoverImage;
                usersInfoBase.Date = Date;
                usersInfoBase.ATMNumber = ATMNumber;
                usersInfoBase.NameOnATMCard = NameOnATMCard;
                usersInfoBase.MobileNumber = MobileNumber;
                usersInfoBase.EmailId = EmailId.Trim();
                usersInfoBase.Password = Password.Trim();
                usersInfoBase.IsActive = IsActive;
                actionResult = userAction.UsersInfo_InsertUpdate(usersInfoBase);

                if (actionResult.IsSuccess)
                {
                    if (Convert.ToInt64(actionResult.dtResult.Rows[0][0]) > 0)
                        //json = "{\"Status\":\"Success\"}";
                        UsersInfo_Login(usersInfoBase.EmailId, usersInfoBase.Password);
                    else if (Convert.ToInt64(actionResult.dtResult.Rows[0][0]) == -10)
                        json = "{\"Status\":\"Error\",\"Message\":\"Email address already exists. Please choose a different email address.\"}";
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"Error in saving the data. Please try again later !\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region UsersInfo_ForgotPassword
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UsersInfo_ForgotPassword(string EmailId, string PasswordResetToken)
        {
            usersInfoBase = new UsersInfoBase();
            actionResult = new ActionResult();
            string json = string.Empty;

            try
            {
                usersInfoBase.EmailId = EmailId.Trim();
                usersInfoBase.PasswordResetToken = PasswordResetToken;
                actionResult = userAction.UsersInfo_ForgotPassword(usersInfoBase);
                if (actionResult.IsSuccess)
                {
                    if (Convert.ToInt32(actionResult.dtResult.Rows[0][0]) > 0)
                        json = "{\"Status\":\"Success\"}";
                    else if (Convert.ToInt32(actionResult.dtResult.Rows[0][0]) == -10)
                        json = "{\"Status\":\"Error\",\"Message\":\"Email does not exist.\"}";
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"Error in forgot password.\"}";

            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #region UsersInfo_ResetPassword
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UsersInfo_ResetPassword(string PasswordResetToken, string Password)
        {
            usersInfoBase = new UsersInfoBase();
            actionResult = new ActionResult();
            string json = string.Empty;

            try
            {
                usersInfoBase.Password = Password.Trim();
                usersInfoBase.PasswordResetToken = PasswordResetToken;
                actionResult = userAction.UsersInfo_ResetPassword(usersInfoBase);
                if (actionResult.IsSuccess)
                {
                    if (Convert.ToInt32(actionResult.dtResult.Rows[0][0]) > 0)
                        json = "{\"Status\":\"Success\"}";
                    else if (Convert.ToInt32(actionResult.dtResult.Rows[0][0]) == -10)
                        json = "{\"Status\":\"Error\",\"Message\":\"The reset password link has expired\"}";
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"Error in reset password.\"}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\"}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #region UsersInfo_LoadBy_Id
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UsersInfo_LoadBy_Id(Int64 Id)
        {
            usersInfoBase = new UsersInfoBase();
            actionResult = new ActionResult();
            string json = string.Empty;

            try
            {
                usersInfoBase.Id = Id;
                actionResult = userAction.UsersInfo_LoadBy_Id(usersInfoBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region UsersInfo_LoadAll
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UsersInfo_LoadAll()
        {
            actionResult = new ActionResult();
            string json = string.Empty;

            try
            {
                actionResult = userAction.UsersInfo_LoadAll();
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }

            WriteDataToHttpResponse(json);
        }
        #endregion

        #region UsersInfo_Login
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UsersInfo_Login(string EmailId, string Password)
        {
            usersInfoBase = new UsersInfoBase();
            actionResult = new ActionResult();
            string json = string.Empty;

            try
            {
                usersInfoBase.EmailId = EmailId.Trim();
                usersInfoBase.Password = Password.Trim();
                actionResult = userAction.UsersInfo_Login(usersInfoBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Record Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }

            //WriteDataToHttpResponse(json);
            WriteDataToHttpResponse(json);
        }
        #endregion

        #endregion

        public void WriteDataToHttpResponse(string data)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                //HttpContext.Current.Response.ContentType = "text/string";
                //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;
                //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName + ".csv");
                HttpContext.Current.Response.Write(data);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            finally
            {
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }


        #region NotificationByUserId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void NotificationByUserId(int Id, int offset, int limit)
        {
            questionBase = new QuestionsBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedFileName = string.Empty;


            commonBase = new CommonBase();
            try
            {
                commonBase.UserId = Id;
                actionResult = commonAction.NotificationsCount(commonBase);

                if (actionResult.IsSuccess)
                {
                    //json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                   // string data = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[0].Rows.Count > 0 ? actionResult.dsResult.Tables[0].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[0]));
                    string notifications = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[1].Rows.Count > 0 ? actionResult.dsResult.Tables[1].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[1]));
                   // string friendRequests = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[2].Rows.Count > 0 ? actionResult.dsResult.Tables[2].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[2]));

                    json = "{\"Status\":\"1\",\"notifications\":" + notifications + "}";
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"notifications\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"notifications\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion



        #region SetLoginStatus
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SetLoginStatus(Int64 Id)
        {
            actionResult = new ActionResult();
            UsersInfoBase usersInfoBase = new UsersInfoBase();
            bookBase = new BookBase();
            try
            {
                usersInfoBase.Id = Id;
                actionResult = userAction.SetLoginStatus(usersInfoBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }

        }
        #endregion


        #region SearchBooksByUsertext
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SearchBooksByUsertext(string Text, int offset, int limit) //, int PageNo = 0--- int offset, int limit
        {
            CommonBase commonBase = new CommonBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                //commonBase.PageNo = PageNo;
                //commonBase.Text = Text;
                //actionResult = commonAction.SearchBooksByUserText(commonBase);
                commonBase.Text = Text;
                actionResult = commonAction.SearchBooksByName(commonBase);

                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult.Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable()), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region SearchBookByCatStrInsSub
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SearchBookByCatStrInsSub(int CategoryID = 0, int StreamID = 0, int InstituteID = 0, string SubjectID = "", int PageNo = 0)
        {
            CommonBase commonBase = new CommonBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                commonBase.CategoryId = Convert.ToInt32(CategoryID);
                commonBase.StreamId = Convert.ToInt32(StreamID);
                commonBase.InstituteId = Convert.ToString(InstituteID);
                commonBase.SubjectId = Convert.ToString(SubjectID);
                commonBase.PageNo = Convert.ToInt32(PageNo);

                actionResult = commonAction.GetBooksByAllAndroid(commonBase);

                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region Message_LoadByUserId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Message_LoadByUserId(int UserId)
        {
            CommonBase commonBase = new CommonBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                commonBase.Id = UserId;

                actionResult = commonAction.Message_Load(commonBase);

                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region FriendList_LoadByUserId
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void FriendList_LoadByUserId(int id)
        {
            actionResult = new ActionResult();
            string json = string.Empty;
            try
            {
                CommonBase commonBase = new CommonBase();
                commonBase.Id = Convert.ToInt32(id);
                actionResult = commonAction.FriendList_LoadByUserId(commonBase);
                if (actionResult.IsSuccess)
                    json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"data\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"data\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void FriendRequestByUserId(int Id, int offset, int limit)
        {
            questionBase = new QuestionsBase();
            actionResult = new ActionResult();
            string json = string.Empty;
            string uploadedFileName = string.Empty;


            commonBase = new CommonBase();
            try
            {
                commonBase.UserId = Id;
                actionResult = commonAction.NotificationsCount(commonBase);

                if (actionResult.IsSuccess)
                {
                    //json = String.Format("{0}{1}{2}", "{\"Status\": \"Success\",\"data\":", Newtonsoft.Json.JsonConvert.SerializeObject(actionResult.dtResult), "}");
                    // string data = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[0].Rows.Count > 0 ? actionResult.dsResult.Tables[0].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[0]));
                    //string notifications = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[1].Rows.Count > 0 ? actionResult.dsResult.Tables[1].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[1]));
                     string friendRequests = Newtonsoft.Json.JsonConvert.SerializeObject((actionResult.dsResult.Tables[2].Rows.Count > 0 ? actionResult.dsResult.Tables[2].Rows.Cast<System.Data.DataRow>().Skip(offset).Take(limit).CopyToDataTable() : actionResult.dsResult.Tables[2]));

                    json = "{\"Status\":\"1\",\"friendRequests\":" + friendRequests + "}";
                }
                else
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"friendRequests\":[]}";
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"friendRequests\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void RemoveFriendById(int Id)
        {          
            string json = string.Empty;
             try
            {
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = Id;
                userAction = new UserAction();
                actionResult = new STU.BaseLayer.ActionResult();
                actionResult = userAction.RemoveFriend(usersInfoBase);
                if (actionResult.dtResult.Rows.Count>0)
                    json = "{\"Status\":\"1\"}";
                else
                    json = "{\"Status\":\"0\"}";

            }
            catch(Exception ex)
            {
                json = "{\"Status\":\"0\"}";
            }
            WriteDataToHttpResponse(json);
        }

        #region UserNotificationList
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UserNotificationList(int UserId)
        {
            questionBase = new QuestionsBase();
            actionResult = new ActionResult();

            commonBase = new CommonBase();

            string json = string.Empty;

            try
            {
               // commonBase.UserId = Convert.ToInt32(Session["UserId"]);
                commonBase.UserId = UserId;
                actionResult = commonAction.NotificationsCount(commonBase);

                if (actionResult.IsSuccess)
                {
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
                {
                    json = "{\"Status\":\"Error\",\"Message\":\"No Records Found\",\"notifications\":[]}";
                }
            }
            catch (Exception ex)
            {
                json = "{\"Status\":\"Error\",\"Message\":\"" + ex.Message + "\",\"notifications\":[]}";
                ErrorReporting.WebApplicationError(ex);
            }
            WriteDataToHttpResponse(json);
        }
        #endregion

        #region GCMNotification_IU
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GCMNotification_IU(string UserId, string AndroidDeviceId, string RegistrationToken)
        {
            string list = string.Empty;
            string json = string.Empty;

            try
            {
                int userId = 0;
                if (string.IsNullOrEmpty(UserId))
                { throw new Exception("UserId is required."); }

                if (!int.TryParse(UserId, out userId) || userId < 1)
                { throw new Exception("UserId is invalid."); }

                if (string.IsNullOrEmpty(AndroidDeviceId))
                { throw new Exception("AndroidDeviceId is required."); }


                if (string.IsNullOrEmpty(RegistrationToken))
                { throw new Exception("RegistrationToken is required."); }



                actionResult = new ActionResult();
                UsersInfoBase userInfoBase = new UsersInfoBase();
                userAction = new UserAction();
                userInfoBase.Id = userId;
                userInfoBase.RegistrationToken = RegistrationToken;
                userInfoBase.AndroidDeviceId = AndroidDeviceId;

                actionResult = userAction.GCMNotification_IU(userInfoBase);
                if (actionResult.IsSuccess)
                {
                    if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];

                        int result = actionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(Convert.ToInt32(dr[0])) : 0;
                        if (result >= 1)
                        {
                            json = "{\"data\": [],";
                            json += "\"message\":\"Registration token saved successfully.\",";
                            json += "\"Status\": \"1\"}";
                        }
                        else
                        {
                            json = "{\"data\": [],";
                            json += "\"message\":\"Error in Request.\",";
                            json += "\"Status\": \"-1\" }";
                        }
                    }
                }
                else
                {
                    json = "{\"data\": [],";
                    json += "\"message\":\"Error in Request.\",";
                    json += "\"Status\": \"-1\"}";
                }
            }
            catch (Exception ex)
            {
                json = "{\"data\": [ \"" + ex.Message + "\"],";
                json += "\"message\":\"Error in Request \",";
                json += "\"Status\": \"-1\"}";

            }
            finally
            {
                WriteDataToHttpResponse(json);
            }
        }
        #endregion
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UploadMultipleFiles(string uploadedImages,string userId)
        {
            string json = string.Empty;
            try {
                var JsonData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FileUpload>>(uploadedImages);
                int i = 0;
                string[] SavedPaths=null;
                SavedPaths = new string[JsonData.Count];
                foreach (var item in JsonData)
                {
                    
                    byte[] bytes = Convert.FromBase64String(item.ImageData);
                    //Read the byte array and save this to folder
                    MemoryStream ms = new MemoryStream(bytes);

                    if (item.ImageData != null && item.ImageData.Length > 0)
                    {
                        item.ImageName = String.Format("{0}{1}", Guid.NewGuid().ToString().Substring(0, 5), item.ImageName);
                    }
                    string path =Server.MapPath("~/Content/Uploads/Ads/" + userId);
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    FileStream fs = new FileStream(Path.Combine(path, item.ImageName), FileMode.Create);
                    // write the memory stream containing the original
                    ms.WriteTo(fs);

                    // clean up
                    ms.Close();
                    fs.Close();
                    fs.Dispose();
                    SavedPaths[i] = "/Content/Uploads/Ads/" + userId + "/" + item.ImageName;
                    i++;
                }
                

                json = "{\"data\": \""+ String.Join(",", SavedPaths) + "\",";
                json += "\"message\":\"File uploaded successfully.\",";
                json += "\"Status\": \"1\"}";
            }
            catch (Exception ex)
            {
                json = "{\"data\": [ \"" + ex.Message + "\"],";
                json += "\"message\":\"Error in Request \",";
                json += "\"Status\": \"-1\"}";

            }
            finally
            {
                WriteDataToHttpResponse(json);
            }

        }

    
    }
}
