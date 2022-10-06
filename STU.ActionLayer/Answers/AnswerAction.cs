using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STA.DataLayer.Answers;
using STU.BaseLayer;
using STU.BaseLayer.Answers;
using STU.Utility;

namespace STU.ActionLayer.Answers
{


    public class AnswerAction
    {
        #region Declaration
        AnswersDL answersDL;
        ActionResult actionResult;
        #endregion

        #region Answers_InsertUpdate
        public ActionResult Answers_InsertUpdate(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.Answers_InsertUpdate(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Answers_LoadAll
        public ActionResult Answers_LoadAll()
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.Answers_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Answers_LoadBy_UserId
        public ActionResult Answers_LoadBy_UserId(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.Answers_LoadBy_UserId(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Answers_LoadBy_QuestionId
        public ActionResult Answers_LoadBy_QuestionId(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.Answers_LoadBy_QuestionId(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion



        #region Answers_LoadBy_QuestionId_Services
        public ActionResult Answers_LoadBy_QuestionId_Services(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.Answers_LoadBy_QuestionId_Services(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region LoadAllNotifications
        public ActionResult LoadAllNotifications(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.LoadAllNotifications(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion




        #region Answers_Delete_By_Id
        public ActionResult Answers_Delete_By_Id(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.Answers_Delete_By_Id(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region USP_S_Answers_Load
        public ActionResult USP_S_Answers_Load(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.USP_S_Answers_Load(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion 
        

         #region USP_S_Answers_Load_Services
        public ActionResult USP_S_Answers_Load_Services(AnswersBase answersBase)
        {
            answersDL = new AnswersDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = answersDL.USP_S_Answers_Load_Services(answersBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion
        
        


      
    }
}
