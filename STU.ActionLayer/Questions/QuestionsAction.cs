using STA.DataLayer.Questions;
using STU.BaseLayer;
using STU.BaseLayer.Answers;
using STU.BaseLayer.Questions;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.ActionLayer.Questions
{
    public class QuestionsAction
    {
        #region Declaration
        QuestionDL questionDL;
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Questions_InsertUpdate
        public ActionResult Questions_InsertUpdate(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.Questions_InsertUpdate(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.RowsAffected = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Questions_LoadBy_PageId
        public ActionResult Questions_LoadBy_PageId(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.Questions_LoadBy_PageId(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region QuestionLoadByQuestionId
        public ActionResult QuestionLoadByQuestionId(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.QuestionLoadByQuestionId(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region Questions_LoadBy_PageId_Services
        public ActionResult Questions_LoadBy_PageId_Services(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.Questions_LoadBy_PageId_Services(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Questions_LoadBy_Id
        public ActionResult Questions_LoadBy_Id(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.Questions_LoadBy_Id(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Questions_LoadBy_Id_Services
        public ActionResult Questions_LoadBy_Id_Services(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.Questions_LoadBy_Id_Services(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region NotificationByUserId
        public ActionResult NotificationByUserId(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.NotificationByUserId(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Answers_LoadBy_PageId
        public ActionResult Answers_LoadBy_PageId(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.Answers_LoadBy_PageId(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region ReplyAnswers_LoadBy_PageId
        public ActionResult ReplyAnswers_LoadBy_PageId(AnswersBase answersBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.ReplyAnswers_LoadBy_PageId(answersBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion




        #region Questions_Delete_By_Id
        public ActionResult Questions_Delete_By_Id(QuestionsBase questionBase)
        {
            questionDL = new QuestionDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = questionDL.Questions_Delete_By_Id(questionBase);
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

        public ActionResult Questions_Remove_By_Id(QuestionsBase questionBase)
        {
            questionDL = new QuestionDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = questionDL.Questions_Remove_By_Id(questionBase);
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

        #region DeleteAnswer_ById
        public ActionResult DeleteAnswer_ById(QuestionsBase questionBase)
        {
            questionDL = new QuestionDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = questionDL.DeleteAnswer_ById(questionBase);
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

        public ActionResult RemoveAnswer_ById(QuestionsBase questionBase)
        {
            questionDL = new QuestionDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = questionDL.RemoveAnswer_ById(questionBase);
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


        #region SendNotification
        public ActionResult SendNotification(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.SendNotification(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region ReplyToAnswers_LoadBy_PageId
        public ActionResult ReplyToAnswers_LoadBy_PageId(QuestionsBase questionsBase)
        {
            actionResult = new ActionResult();
            questionDL = new QuestionDL();
            try
            {
                actionResult.dtResult = questionDL.ReplyToAnswers_LoadBy_PageId(questionsBase);

                if (actionResult.dtResult != null)
                {
                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        actionResult.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

    }
}
