using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppWebsite.Models;
using STU.BaseLayer.Answers;
using Newtonsoft.Json;
using STU.ActionLayer.Answers;

namespace StudentAppWebsite.Controllers.api.Answers
{
    public class AnswerController : ApiController
    {
        ApiResponseModel resmodel = new ApiResponseModel();
        AnswersBase answersBase = new AnswersBase();
        AnswerAction answerAction = new AnswerAction();
        STU.BaseLayer.ActionResult actionResult;


        #region Answer Insert
        [HttpPost]
        public ApiResponseModel InsertAnswer(int userID, int questionID, string data, int answerID)
        {
            try
            {
                resmodel = new ApiResponseModel();
                actionResult = new STU.BaseLayer.ActionResult();
                actionResult = answerAction.Answers_InsertUpdate(new AnswersBase { UserId = userID, QuestionId = questionID, Answer = data, ReplyAnswerId = answerID });
                if (actionResult.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(actionResult.dtResult);
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

        #region Answer Update
        [HttpPut]
        public ApiResponseModel UpdateAnswer(int id,int userID, int questionID, string data, int answerID)
        {
            try
            {
                resmodel = new ApiResponseModel();
                actionResult = new STU.BaseLayer.ActionResult();
                actionResult = answerAction.Answers_InsertUpdate(new AnswersBase {Id=id ,UserId=userID,QuestionId=questionID,Answer=data,ReplyAnswerId=answerID});
                if (actionResult.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(actionResult.dtResult);
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

        #region Answers_LoadBy_QuestionId_Services
        [HttpGet]
        public ApiResponseModel Answers_LoadBy_QuestionId_Services(int queid)
        { 
         try
            {
                resmodel = new ApiResponseModel();
        actionResult = new STU.BaseLayer.ActionResult();
                actionResult = answerAction.Answers_LoadBy_QuestionId_Services(new AnswersBase { QuestionId=queid});
                if (actionResult.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(actionResult.dtResult);
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

        #region USP_S_Answers_Load_Services
        [HttpGet]
        public ApiResponseModel USP_S_Answers_Load_Services(int Ansid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                actionResult = new STU.BaseLayer.ActionResult();
                actionResult = answerAction.USP_S_Answers_Load_Services(new AnswersBase {Id=Ansid});
                if (actionResult.IsSuccess == true)
                {
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(actionResult.dtResult);
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
    }
}
