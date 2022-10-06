using STU.BaseLayer.Answers;
using STU.BaseLayer.Questions;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.DataLayer.Questions
{
    public class QuestionDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion

        #region Questions_InsertUpdate
        public DataTable Questions_InsertUpdate(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",questionBase.Id),
                                            new MyParameter("@PageId",questionBase.PageId),
                                            new MyParameter("@QuestionTitle",questionBase.QuestionTitle),
                                            new MyParameter("@QuestionImage",questionBase.QuestionImage),
                                            new MyParameter("@UserId",questionBase.UserId)
                               };
                Common.Set_Procedures("USP_IU_Questions");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Questions_LoadBy_PageId
        public DataTable Questions_LoadBy_PageId(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@PageId",questionBase.PageId)
                               };
                Common.Set_Procedures("USP_S_Questions_LoadBy_PageId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region QuestionLoadByQuestionId
        public DataTable QuestionLoadByQuestionId(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@QuestionId",questionBase.Id)
                               };
                Common.Set_Procedures("QuestionLoadByQuestionId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region Questions_LoadBy_PageId_Services
        public DataTable Questions_LoadBy_PageId_Services(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@PageId",questionBase.PageId)
                               };
                Common.Set_Procedures("USP_S_Questions_LoadBy_PageId_Services");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region Questions_LoadBy_Id
        public DataTable Questions_LoadBy_Id(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",questionBase.Id)
                               };
                Common.Set_Procedures("USP_S_Questions_LoadBy_Id");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region Questions_LoadBy_Id
        public DataTable Questions_LoadBy_Id_Services(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",questionBase.Id)
                               };
                Common.Set_Procedures("USP_S_Questions_LoadBy_Id_Services");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region NotificationByUserId
        public DataTable NotificationByUserId(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",questionBase.Id)
                               };
                Common.Set_Procedures("USP_S_NotificationByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Answers_LoadBy_PageId
        public DataTable Answers_LoadBy_PageId(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Pageid",questionBase.PageId)
                               };
                Common.Set_Procedures("GetQuestion_AnswersList_ByPageId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region ReplyAnswers_LoadBy_PageId
        public DataTable ReplyAnswers_LoadBy_PageId(AnswersBase answersBase)
        {
            
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@PageId",answersBase.PageID),
                                            new MyParameter("@AnswerId",answersBase.Id)
                               };
                Common.Set_Procedures("[GetReply_AnswersList_ByPageId]");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Questions_Delete_By_Id
        public DataTable Questions_Delete_By_Id(QuestionsBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",answersBase.Id)
                               };
                Common.Set_Procedures("USP_D_QuestionsAnswers");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }

        public DataTable Questions_Remove_By_Id(QuestionsBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",answersBase.Id),
                                            new MyParameter("@isRemoveForYouOnly",answersBase.isRemoveForYouOnly),
                                            new MyParameter("@isRemoveForAll",answersBase.isRemoveForAll)
                               };
                Common.Set_Procedures("USP_D_QuestionsAnswers_Remove");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region DeleteAnswer_ById
        public DataTable DeleteAnswer_ById(QuestionsBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",answersBase.Id)
                               };
                Common.Set_Procedures("USP_D_Answers");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }

        public DataTable RemoveAnswer_ById(QuestionsBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Id",answersBase.Id),
                                            new MyParameter("@isRemoveForYouOnly",answersBase.isRemoveForYouOnly),
                                            new MyParameter("@isRemoveForAll",answersBase.isRemoveForAll)
                               };
                Common.Set_Procedures("USP_D_Answers_Remove");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SendNotification
        public DataTable SendNotification(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@PageId",questionBase.PageId)
                               };
                Common.Set_Procedures("SendNotification");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region ReplyToAnswers_LoadBy_PageId
        public DataTable ReplyToAnswers_LoadBy_PageId(QuestionsBase questionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@Pageid",questionBase.PageId)
                               };
                Common.Set_Procedures("GetAnswers_AnswersList_ByPageId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

    }
}
