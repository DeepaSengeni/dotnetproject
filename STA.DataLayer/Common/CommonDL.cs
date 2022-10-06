using STU.BaseLayer.Common;
using STU.BaseLayer.User;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace STA.DataLayer.CommonMethods
{
    public class CommonDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion

        #region FindCititesByCountry
        public DataTable FindCititesByCountry(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                    new MyParameter("@CountryID",commonBase.CountryId)
                                         };
                Common.Set_Procedures("USP_Find_Cities_By_CountryId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region FindCititesByState
        public DataTable FindCititesByState(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                    new MyParameter("@StateID",commonBase.StateId)
                                         };
                Common.Set_Procedures("USP_Find_Cities_By_StateId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region FindCititesIDByCountry
        public DataTable FindCititesIDByCountry(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                    new MyParameter("@CountryID",commonBase.CountryId)
                                         };
                Common.Set_Procedures("USP_Find_Cities_ID_By_CountryId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region FindCititesIDByState
        public DataTable FindCititesIDByState(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                    new MyParameter("@StateID",commonBase.StateId)
                                         };
                Common.Set_Procedures("USP_Find_Cities_ID_By_StateId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region Countries_LoadAll
        public DataTable Countries_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          
                                         };
                Common.Set_Procedures("USP_S_Master_Countries_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region States_LoadBy_CountryId
        public DataTable States_LoadBy_CountryId(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@CountryID",commonBase.CountryId)
                                         };
                Common.Set_Procedures("USP_S_Master_States_LoadBy_CountryId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Cities_LoadBy_StateId
        public DataTable Cities_LoadBy_StateId(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@StateId",commonBase.StateId)
                                         };
                Common.Set_Procedures("USP_S_Master_Cities_LoadBy_StateId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Notesbook_Load_ById
        public DataTable Notesbook_Load_ById(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@Id",commonBase.NotebookId)
                                         };
                Common.Set_Procedures("Notesbook_Load_ById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region EntranceExam_LoadAll
        public DataTable EntranceExam_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_EntranceExam_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region ExamStream_LoadAll
        public DataTable ExamStream_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_ExamStream_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Subjects_LoadAll
        public DataTable Subjects_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_Subjects_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Streams_LoadAll
        public DataTable Streams_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_Streams_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Chapters_LoadAll
        public DataTable Chapters_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_Chapters_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Notesbook_LoadAll
        public DataTable Notesbook_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("Notesbook_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Notesbook_LoadBy_OFFSET
        public DataTable Notesbook_LoadBy_OFFSET(int pageNo, int offset, int userid)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@pageNo",pageNo),
                                         new MyParameter("@OFFSET",offset),
                                         new MyParameter("@userid",userid)
                                         };
                Common.Set_Procedures("Notesbook_LoadBy_OFFSET");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        

        #region Colleges_LoadAll
        public DataTable Colleges_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_Colleges_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Categories_LoadAll
        public DataTable Categories_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_Categories_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Topics_LoadAll
        public DataTable Topics_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_Topics_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Masters_InsertUpdate
        public DataTable Masters_InsertUpdate(CommonMastersBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@Id",commonBase.Id),
                                         new MyParameter("@Name",commonBase.Name),
                                         new MyParameter("@type",commonBase.Type)
                                         };
                Common.Set_Procedures("USP_IU_Masters");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Subjects_LoadById
        public DataTable Subjects_LoadById(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@id",common.Id)
                                         };
                Common.Set_Procedures("USP_S_Master_Subjects_LoadById");
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

        #region Chapter_LoadById
        public DataTable Chapter_LoadById(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@id",common.Id)
                                         };
                Common.Set_Procedures("USP_S_Master_Chapters_LoadById");
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

        #region Institute_LoadById
        public DataTable Institute_LoadById(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@streamId",common.SteamId),
                                         new MyParameter("@categoryId",common.CategoryId)
                                         };
                Common.Set_Procedures("USP_S_Master_Institute_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Institute_LoadByInstituteId
        public DataTable Institute_LoadByInstituteId(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@Id",common.Id) 
                                         };
                Common.Set_Procedures("InstituteLoadByInstituteId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Institute_LoadAll
        public DataTable Institute_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         
                                         };
                Common.Set_Procedures("USP_S_Master_Institute_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region Institutes_LoadByCityId
        public DataTable Institutes_LoadByCityId(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@CityId",common.CityId)
                                        
                                         };
                Common.Set_Procedures("Institute_LoadByCityId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Stream_LoadById
        public DataTable Stream_LoadById(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@id",common.Id)
                                         };
                Common.Set_Procedures("USP_S_Master_Streams_LoadById");
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

        #region Category_LoadById
        public DataTable Category_LoadById(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@id",common.Id)
                                         };
                Common.Set_Procedures("USP_S_Master_Categories_LoadById");
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

        #region Category_InsertUpdate
        public DataTable Category_InsertUpdate(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            
                                         new MyParameter("@id",common.Id),
                                         new MyParameter("@CategoryName",common.CategoryName),
                                          new MyParameter("@Price",common.Price),
                                         new MyParameter("@Status",common.Status),
                                         new MyParameter("@Action",common.Action)
                                         };
                Common.Set_Procedures("Master_Category_InsertUpdate");
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

        #region Update_StatusByID
        public DataTable Update_StatusByID(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            
                                         new MyParameter("@id",common.Id),
                                         
                                         new MyParameter("@Status",common.Status),
                                          new MyParameter("@Action",common.Action)
                                        
                                         };
                Common.Set_Procedures("Update_StatusByID");
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
        #region Stream_InsertUpdate
        public DataTable Stream_InsertUpdate(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            
                                         new MyParameter("@id",common.Id),
                                         new MyParameter("@StreamCategory",common.StreamCategory),
                                          new MyParameter("@StreamName",common.StreamName),
                                           new MyParameter("@StreamIcon",common.StreamIcon),
                                         new MyParameter("@Status",common.Status),
                                         new MyParameter("@Action",common.Action),
                                         new MyParameter("@Details",common.Details)
                                         };
                Common.Set_Procedures("Master_Stream_InsertUpdate");
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

        #region Subject_InsertUpdate
        public DataTable Subject_InsertUpdate(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Id",commonBase.Id),
                                             new MyParameter("@StreamId",commonBase.SteamId),
                                             new MyParameter("@SubjectName",commonBase.SubjectName),
                                             new MyParameter("@Details",commonBase.Details),
                                             new MyParameter("@Status",commonBase.Status)
                                         
                                         };
                Common.Set_Procedures("Subject_InsertUpdate");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Institute_InsertUpdate
        public DataTable Institute_InsertUpdate(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            
                                         new MyParameter("@id",common.Id),
                                         new MyParameter("@InstituteIcon",common.InstituteIcon),
                                          new MyParameter("@InstituteName",common.InstituteName),
                                          
                                         new MyParameter("@StreamId",common.StreamId),
                                         new MyParameter("@CountryId",common.CountryId),
                                         new MyParameter("@StateId",common.StateId),
                                         new MyParameter("@Cityid",common.CityId),
                                         new MyParameter("@Email",common.Email),
                                         new MyParameter("@Website",common.Website),
                                         new MyParameter("@Address",common.Address),
                                         new MyParameter("@ContactNo",common.ContactNo),
                                         new MyParameter("@Status",common.Status),
                                         new MyParameter("@Action",common.Action),
                                          new MyParameter("@Zipcode",common.Zipcode),
                                         new MyParameter("@AlternateContactNo",common.AlternateContactNo),
                                         new MyParameter("@FaxNo",common.FaxNo)
                                         };
                Common.Set_Procedures("Master_Institute_InsertUpdate");
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

        #region Submitter_Reader_Count
        public DataTable Submitter_Reader_Count(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                       };
                Common.Set_Procedures("Submitter_Reader_Count");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region UserInfo_LoadById
        public DataTable UserInfo_LoadById(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Id",commonBase.Id)
                                       };
                Common.Set_Procedures("USP_S_UsersInfo_LoadBy_Id");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion


        #region NotebookDetails_Insert
        public DataTable NotebookDetails_Insert(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@ChapterId",commonBase.ChapterId),
                                             new MyParameter("@ChapterName",commonBase.ChapterName),
                                             new MyParameter("@SubjectName",commonBase.SubjectName),
                                             new MyParameter("@TeacherName",commonBase.TeacherName),
                                             new MyParameter("@CollegeName",commonBase.InstituteName),
                                             new MyParameter("@CategoryName",commonBase.CategoryName),
                                             new MyParameter("@StreamName",commonBase.StreamName),
                                             new MyParameter("@Type",commonBase.Type),
                                             new MyParameter("@StartDate",commonBase.StartDate),
                                              new MyParameter("@UserId",commonBase.UserId),
                                              new MyParameter("@monetaryAdvantages",commonBase.MonetoryAdvantages),
                                              new MyParameter("@Innovation_Investment",commonBase.Innovation_Investment),
                                              new MyParameter("@Visible_Hidden",commonBase.Visible_Hidden)
                                            
                                       };
                Common.Set_Procedures("NotebookDetails_Insert");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region NotebookDetails_Update
        public DataTable NotebookDetails_Update(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@ChapterId",commonBase.ChapterId),
                                             new MyParameter("@ChapterName",commonBase.ChapterName),
                                             new MyParameter("@SubjectName",commonBase.SubjectName),
                                             new MyParameter("@TeacherName",commonBase.TeacherName),
                                             new MyParameter("@CollegeName",commonBase.InstituteName),
                                             new MyParameter("@CategoryName",commonBase.CategoryName),
                                             new MyParameter("@StreamName",commonBase.StreamName),
                                             new MyParameter("@Type",commonBase.Type),
                                             new MyParameter("@StartDate",commonBase.StartDate),
                                              new MyParameter("@UserId",commonBase.UserId),
                                              new MyParameter("@monetaryAdvantages",commonBase.MonetoryAdvantages),
                                              new MyParameter("@BookId",commonBase.Id),
                                              new MyParameter("@Innovation_Investment",commonBase.Innovation_Investment),
                                               new MyParameter("@Visible_Hidden",commonBase.Visible_Hidden)
                                              

                                       };
                Common.Set_Procedures("NotebookDetails_Update");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region NotebookDetails_Delete
        public DataTable NotebookDetails_Delete(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                              new MyParameter("@UserId",commonBase.UserId),
                                              new MyParameter("@BookId",commonBase.Id)
                                            
                                       };
                Common.Set_Procedures("NotebookDetails_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region NotebookLoadByUserID
        public DataTable NotebookLoadByUserID(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             
                                               new MyParameter("@UserId",commonBase.Id)

                                       };
                Common.Set_Procedures("NotebookLoadByUserID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region NotebookLoadByID
        public DataSet NotebookLoadById(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                             
                                               new MyParameter("@UserId",commonBase.UserId),
                                               new MyParameter("@BookId",commonBase.Id)

                                       };
                Common.Set_Procedures("NotebookLoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dsContainer;
        }

        #endregion

        #region UpdateUsersInfoByUserId
        public DataTable UpdateUsersInfoByUserId(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             
                                               new MyParameter("@UserId",commonBase.UserId),
                                                 new MyParameter("@CardHolderName",commonBase.CardHolderName),
                                              new MyParameter("@CardNumber",commonBase.CardNumber),
                                               new MyParameter("@ExpirationDate",commonBase.ExpirationDate),
                                               new MyParameter("@CVV",commonBase.CVV),
                                               new MyParameter("@ExpiryMonth",commonBase.ExpiryMonth),
                                               new MyParameter("@ExpiryYear",commonBase.ExpiryYear)
                                       };
                Common.Set_Procedures("UpdateUsersInfoByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion


        #region UsersDetails
        public DataTable UsersDetails(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             
                                               //new MyParameter("@RoleId",commonBase.Id),
                                               
                                       };
                Common.Set_Procedures("UsersDetails");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region UpdateUserStatusById
        public DataTable UpdateUserStatusById(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Status",commonBase.Status),
                                               new MyParameter("@UserId",commonBase.Id)
                                               
                                       };
                Common.Set_Procedures("UpdateUserStatusById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region UsersInfo_LoadBy_Id
        public DataTable UsersInfo_LoadBy_Id(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",CommonBase.Id),
                                         };
                Common.Set_Procedures("USP_S_UsersInfo_LoadBy_Id");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SearchBooksByName
        public DataTable SearchBooksByName(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Text",CommonBase.Text),
                                             new MyParameter("@Country",CommonBase.CountryId),
                                               new MyParameter("@state",CommonBase.StateId),
                                                  new MyParameter("@city",CommonBase.CityId),
                                                    new MyParameter("@subject",CommonBase.SubjectId),
                                                    new MyParameter("@userID",CommonBase.UserId)
                                         };
                Common.Set_Procedures("SearchBooksByName_Location");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                if (dsContainer != null)
                {
                dtContainer = dsContainer.Tables[0];    
                }
                
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region SearchBooksByNameAndroid
        public DataTable SearchBooksByNameAndroid(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Text",CommonBase.Text),
                                           new MyParameter("@pageNo",CommonBase.PageNo)
                                         };
                Common.Set_Procedures("SearchBooksByNameAndroid");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region SearchBooksByUserText
        public DataTable SearchBooksByUserText(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Text",CommonBase.Text),
                                           new MyParameter("@PageNo",CommonBase.PageNo)
                                         };
                Common.Set_Procedures("SearchBooksByUserText");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region FriendList_LoadByUserId
        public DataTable FriendList_LoadByUserId(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",CommonBase.Id),
                                         };
                Common.Set_Procedures("FriendList_LoadByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region FriendRequest_LoadByUserId
        public DataTable FriendRequest_LoadByUserId(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",CommonBase.Id),
                                         };
                Common.Set_Procedures("FriendRequest_LoadByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        

        #region BookContentLoadByBookId
        public DataTable BookContentLoadByBookId(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@BookId",CommonBase.Id),
                                         };
                Common.Set_Procedures("BookContentLoadByBookId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region StreamsLoadByCategoryID
        public DataTable StreamsLoadByCategoryID(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",CommonBase.Id),
                                         };
                Common.Set_Procedures("StreamsLoadByCategoryID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region InstitutesLoadByStreamID
        public DataTable InstitutesLoadByStreamID(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",CommonBase.Id),
                                            new MyParameter("@CityId",CommonBase.CityId)
                                         };
                Common.Set_Procedures("InstitutesLoadByStreamID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SearchBookByCatStrInsSub
        public DataTable SearchBookByCatStrInsSub(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@CategoryId",CommonBase.CategoryId),
                                           new MyParameter("@StreamId",CommonBase.SteamId),
                                           new MyParameter("@InstituteId",CommonBase.InstituteId),

                                           new MyParameter("@SubjectId",CommonBase.SubjectId),
                                         };
                Common.Set_Procedures("USP_S_getBooksByAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SearchBookByFilters
        public DataTable SearchBookByFilters(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@CountryId",CommonBase.CountryId),
                                           new MyParameter("@StateId",CommonBase.StateId),
                                           new MyParameter("@CityId",CommonBase.CityId),

                                           new MyParameter("@SubjectId",CommonBase.SubjectId),
                                         };
                Common.Set_Procedures("USP_S_getBooksByAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region SearchBookByCatStrInsSub_ByOFFSET
        public DataTable SearchBookByCatStrInsSub_ByOFFSET(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@CategoryId",CommonBase.CategoryId),
                                           new MyParameter("@StreamId",CommonBase.SteamId),
                                           new MyParameter("@InstituteId",CommonBase.InstituteId),
                                           new MyParameter("@SubjectId",CommonBase.SubjectId),
                                           new MyParameter("@OFFSET",CommonBase.Offset),
                                           new MyParameter("@pageNo",CommonBase.PageNo)
                                         };
                Common.Set_Procedures("USP_S_getBooksByAll_ByOFFSET");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region GetBooksByAllAndroid
        public DataTable GetBooksByAllAndroid(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@CategoryId",CommonBase.CategoryId),
                                           new MyParameter("@StreamId",CommonBase.SteamId),
                                           new MyParameter("@InstituteId",CommonBase.InstituteId),
                                           new MyParameter("@SubjectId",CommonBase.SubjectId),
                                           new MyParameter("@PageNo",CommonBase.PageNo)
                                         };
                Common.Set_Procedures("USP_S_getBooksByAllAndroid");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        //#region SearchBooksByStream
        //public DataTable SearchBooksByStream(CommonBase CommonBase)
        //{
        //    dsContainer = new DataSet();
        //    dtContainer = new DataTable();
        //    try
        //    {
        //        MyParameter[] myParams = {
        //                                   new MyParameter("@Id",CommonBase.Id),
        //                                 };
        //        Common.Set_Procedures("SearchBooksByStream");
        //        Common.Set_ParameterLength(myParams.Length);
        //        Common.Set_Parameters(myParams);
        //        dsContainer = Common.Execute_Procedures_Select();
        //        dtContainer = dsContainer.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorReporting.DataLayerError(ex);
        //    }
        //    return dtContainer;
        //}
        //#endregion

        //#region SearchBooksByCollege
        //public DataTable SearchBooksByCollege(CommonBase CommonBase)
        //{
        //    dsContainer = new DataSet();
        //    dtContainer = new DataTable();
        //    try
        //    {
        //        MyParameter[] myParams = {
        //                                   new MyParameter("@Id",CommonBase.Id),
        //                                 };
        //        Common.Set_Procedures("SearchBooksByCollege");
        //        Common.Set_ParameterLength(myParams.Length);
        //        Common.Set_Parameters(myParams);
        //        dsContainer = Common.Execute_Procedures_Select();
        //        dtContainer = dsContainer.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorReporting.DataLayerError(ex);
        //    }
        //    return dtContainer;
        //}
        //#endregion

        //#region SearchBooksBySubject
        //public DataTable SearchBooksBySubject(CommonBase CommonBase)
        //{
        //    dsContainer = new DataSet();
        //    dtContainer = new DataTable();
        //    try
        //    {
        //        MyParameter[] myParams = {
        //                                   new MyParameter("@Id",CommonBase.Id),
        //                                 };
        //        Common.Set_Procedures("SearchBooksBySubject");
        //        Common.Set_ParameterLength(myParams.Length);
        //        Common.Set_Parameters(myParams);
        //        dsContainer = Common.Execute_Procedures_Select();
        //        dtContainer = dsContainer.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorReporting.DataLayerError(ex);
        //    }
        //    return dtContainer;
        //}
        //#endregion

        #region SubjectLoadByStreamId
        public DataTable SubjectLoadByStreamId(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@id",CommonBase.SteamId),
                                         };
                Common.Set_Procedures("SubjectLoadByStreamId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region NotificationsCount
        public DataSet NotificationsCount(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@UserId",CommonBase.UserId),
                                         };
                Common.Set_Procedures("NotificationCount");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                //dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion


        #region Message_InsertUpdate
        public DataSet Message_InsertUpdate(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",CommonBase.Id),
                                           new MyParameter("@Message",CommonBase.Text),

                                         };
                Common.Set_Procedures("Message_InsertUpdate");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                //dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion 

        #region Message_Load
        public DataTable Message_Load(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@userId",commonBase.Id)
                                          };
                Common.Set_Procedures("Message_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region CityPricing_InsertUpdate
        public DataSet CityPricing_InsertUpdate(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@CityId",CommonBase.CityId),
                                           new MyParameter("@Price",CommonBase.Price),

                                         };
                Common.Set_Procedures("CityPrice_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                //dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region Master_Categories_LoadAllPrice
        public DataTable Master_Categories_LoadAllPrice()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                              
                                          };
                Common.Set_Procedures("Master_Categories_LoadAllPrice");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region GetUsersList_ByCityId
        public DataTable GetUsersList_ByCityId(CommonBase CommonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@CityId",CommonBase.CityId)

                                         };
                Common.Set_Procedures("Sp_getUserList_ByCityId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Master_Currency
        public DataTable CurrencyList_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("USP_S_Master_Currency_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region CurrencyRate_Update
        public DataSet CurrencyRate_Update(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Id",commonBase.ID),
                                             new MyParameter("@Rate",commonBase.Rate),
                                         };
                Common.Set_Procedures("CurrencyRate_Update");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region GetCurrency_Code
        public DataTable Get_users_Country_CurrencyCodeandRate(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                               new MyParameter("@UserId",commonBase.Id)

                                       };
                Common.Set_Procedures("Get_users_Country_CurrencyCodeandRate");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region Paypaldetails
        public DataTable Paypaldetails(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                               new MyParameter("@UserId",commonBase.Id)

                                       };
                Common.Set_Procedures("Paypaldetails");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region Update_Wallet_ByuserId
        public DataTable Update_Wallet_ByuserId(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                            new MyParameter("@UserId",commonBase.Id),
                                         };
                Common.Set_Procedures("Update_Wallet_ByuserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region Response_PaymentRequest
        public DataTable Response_PaymentRequest(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("Response_PaymentRequest");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Get_Country_CurrencyCode_Rate_by_CountryId
        public DataTable Get_Country_CurrencyCode_Rate_by_CountryId(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                              new MyParameter("@countryid",commonBase.CountryId),
                                         };
                Common.Set_Procedures("getCountryCodeByID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Setting
        public DataTable Setting(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@userid",commonBase.UserId),
                                             new MyParameter("@emailId",commonBase.Email),
                                             new MyParameter("@password",commonBase.Password),
                                             new MyParameter("@mobileno",commonBase.ContactNo),
                                             new MyParameter("@ISD_Code",commonBase.ISD_Code)
                                       };
                Common.Set_Procedures("Setting");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region Delete_Account
        public DataTable Deleteaccount(CommonBase commonBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Id",commonBase.UserId),
                                          
                                       };
                Common.Set_Procedures("DeleteUserDetails");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }

        #endregion

        #region removeUnpaidAdd
        public DataTable RemoveUnpiadAdd()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                       };
                Common.Set_Procedures("deleteUnpaidAdd");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region CityNameByID
        public DataTable CityNameByID( int id)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                      new MyParameter("@ID",id),
                                       };
                Common.Set_Procedures("CityNameByID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Hiring
        public DataTable Get_Admin_Hiring(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          
                                         };
                Common.Set_Procedures("USP_Get_Admin_Hiring");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        public DataTable Hiring_LoadById(CommonBase common)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         new MyParameter("@id",common.Id)
                                         };
                Common.Set_Procedures("USP_S_Master_Hiring_LoadById");
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
        public DataTable Hiring_InsertUpdate(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Id",commonBase.Id),
                                             new MyParameter("@Tittle",commonBase.Tittle),
                                             new MyParameter("@Description",commonBase.Description)

                                         };
                Common.Set_Procedures("Hirirng_InsertUpdate");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return dtContainer;
        }
        public DataTable Hiring_LoadActive()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("USP_S_User_Hiring_LoadActive");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
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
