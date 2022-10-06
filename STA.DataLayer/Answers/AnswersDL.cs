using STU.BaseLayer.Answers;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.DataLayer.Answers
{
    public class AnswersDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion

        #region Answers_InsertUpdate
        public DataTable Answers_InsertUpdate(AnswersBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={  
                                            new MyParameter("@Id",answersBase.Id),
                                            new MyParameter("@QuestionId",answersBase.QuestionId),
                                            new MyParameter("@Answer",answersBase.Answer),
                                            new MyParameter("@AnswerImage",answersBase.AnswerImage),
                                            new MyParameter("@UserId",answersBase.UserId),
                                             new MyParameter("@PageId",answersBase.PageID),
                                             new MyParameter("@ReplyAnswerId",answersBase.ReplyAnswerId)
                                             
                               };
                Common.Set_Procedures("USP_IU_Answers");
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

        #region Answers_LoadAll
        public DataTable Answers_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={  
                               };
                Common.Set_Procedures("USP_S_Answers_LoadAll");
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

        #region Answers_LoadBy_UserId
        public DataTable Answers_LoadBy_UserId(AnswersBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={  
                                            new MyParameter("@UserId",answersBase.UserId)
                               };
                Common.Set_Procedures("USP_S_Answers_LoadBy_UserId");
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

        #region Answers_LoadBy_QuestionId
        public DataTable Answers_LoadBy_QuestionId(AnswersBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={  
                                            new MyParameter("@QuestionId",answersBase.QuestionId)
                               };
                Common.Set_Procedures("USP_S_Answers_LoadBy_QuestionId");
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


        #region Answers_LoadBy_QuestionId_Services
        public DataTable Answers_LoadBy_QuestionId_Services(AnswersBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={  
                                            new MyParameter("@QuestionId",answersBase.QuestionId)
                               };
                Common.Set_Procedures("USP_S_Answers_LoadBy_QuestionId_Services");
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

       
        #region LoadAllNotifications
        public DataTable LoadAllNotifications(AnswersBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={  
                                            new MyParameter("@TopicID",answersBase.QuestionId),
                                             new MyParameter("@userID",answersBase.UserId)
                               };
                Common.Set_Procedures("LoadAllNotifications");
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



        #region Answers_Delete_By_Id
        public DataTable Answers_Delete_By_Id(AnswersBase answersBase)
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
        #endregion


        #region USP_S_Answers_Load
        public DataTable USP_S_Answers_Load(AnswersBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={  
                                            new MyParameter("@answerId",answersBase.Id)
                               };
                Common.Set_Procedures("USP_S_Answers_Load");
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

        #region USP_S_Answers_Load_Services
        public DataTable USP_S_Answers_Load_Services(AnswersBase answersBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={  
                                            new MyParameter("@answerId",answersBase.Id)
                               };
                Common.Set_Procedures("USP_S_Answers_Load_Services");
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
