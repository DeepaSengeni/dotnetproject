using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppWebsite.Models;
using Newtonsoft.Json;
using STU.BaseLayer.Questions;
using STU.ActionLayer.Questions;
using STU.BaseLayer.Answers;

namespace StudentAppWebsite.Controllers.api.Questions
{
    public class QuestionController : ApiController
    {
        ApiResponseModel resmodel = new ApiResponseModel();
        QuestionsBase questionBase = new QuestionsBase();
        QuestionsAction questionsAction = new QuestionsAction();
        AnswersBase answersBase = new AnswersBase();



        #region Add Question
        [HttpPost]
        public ApiResponseModel AddQuestion(int userID, int pageID, string data)
        {
            try
            {
                resmodel = new ApiResponseModel();
                questionBase.Id = 0;
                questionBase.PageId = pageID;
                questionBase.UserId = userID;
                questionBase.QuestionTitle = data;
                var res = questionsAction.Questions_InsertUpdate(questionBase);
                if (res.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(res.dtResult);
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

        #region Questions_LoadBy_PageId
        [HttpGet]
        public ApiResponseModel Questions_LoadBy_PageId(int pageID)
        {
            try
            {
                resmodel = new ApiResponseModel();
               
                var res = questionsAction.Questions_LoadBy_PageId(new QuestionsBase { PageId=pageID} );
                if (res.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(res.dtResult);
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

        #region QuestionLoadByQuestionId
        [HttpGet]
        public ApiResponseModel QuestionLoadByQuestionId(int id)
        {
            try
            {
                resmodel = new ApiResponseModel();

                var res = questionsAction.QuestionLoadByQuestionId(new QuestionsBase { Id=id });
                if (res.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(res.dtResult);
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

        #region Questions_LoadBy_PageId_Services
        [HttpGet]
        public ApiResponseModel Questions_LoadBy_PageId_Services(int id)
        {
            try
            {
                resmodel = new ApiResponseModel();

                var res = questionsAction.Questions_LoadBy_PageId_Services(new QuestionsBase { PageId=id });
                if (res.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(res.dtResult);
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

        #region ShowQuestion
        [HttpGet]
        public ApiResponseModel ShowQuestion(int questionID )
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = questionsAction.Questions_LoadBy_Id_Services(new QuestionsBase { Id = questionID });
                if (data.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
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


        #region QuestionList
        [HttpGet]
        public ApiResponseModel Answers_LoadBy_PageId(int ID)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = questionsAction.Answers_LoadBy_PageId(new QuestionsBase { PageId = ID });
                if (data.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
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

       # region _ReplyAnswerPartial
        [HttpPost]
        public ApiResponseModel _ReplyAnswerPartial(int Answerid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                answersBase.Id = Convert.ToInt32(Answerid);
                List<AnswerModel> ReplyAnswersList = new List<AnswerModel>();
                QuestionModel model = new QuestionModel();
                var data = questionsAction.ReplyAnswers_LoadBy_PageId(answersBase);

                if (data.IsSuccess == true)
                {
                    ReplyAnswersList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AnswerModel>(data.dtResult);
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(ReplyAnswersList);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";

                }

                model.ReplyAnswersList = ReplyAnswersList.OrderBy(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }


            return resmodel;
        }
        #endregion

        #region DeleteQuestions_ById
        [HttpDelete]
        public ApiResponseModel DeleteQuestions_ById(int id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = questionsAction.Questions_Delete_By_Id(new QuestionsBase { Id = id });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Deleted";
                    resmodel.ResponseData = JsonConvert.SerializeObject(id);
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
            { throw (ex); }
            return resmodel;
        }
        #endregion

        #region DeleteAnswer_ById
        [HttpDelete]
        public ApiResponseModel DeleteAnswer_ById(int Id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data  = questionsAction.DeleteAnswer_ById(new QuestionsBase { Id = Id });
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
            { throw (ex); }
            return resmodel;
        }
        #endregion


        #region SendNotification
        [HttpPost]
        public ApiResponseModel SendNotification(int Id)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = questionsAction.SendNotification(new QuestionsBase { PageId = Id });
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
            { throw (ex); }
            return resmodel;
        }
        #endregion

        #region ReplyToAnswers_LoadBy_PageId
        [HttpGet]
        public ApiResponseModel ReplyToAnswers_LoadBy_PageId(int ID)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = questionsAction.ReplyToAnswers_LoadBy_PageId(new QuestionsBase { PageId = ID });
                if (data.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
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

    }
}
