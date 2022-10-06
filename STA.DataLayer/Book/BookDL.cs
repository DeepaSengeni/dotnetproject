using STU.BaseLayer.Book;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.DataLayer.Book
{
    public class BookDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion

        #region Books_InsertUpdate
        public DataTable Books_InsertUpdate(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@Id",bookBase.Id),
                                            new MyParameter("@BookTitle",bookBase.BookTitle),
                                            new MyParameter("@CoverPageImage",bookBase.CoverPageImage),
                                            new MyParameter("@BackPageImage",bookBase.BackPageImage),
                                            new MyParameter("@ExamStreamId",bookBase.ExamStreamId),
                                            new MyParameter("@EntranceExamId",bookBase.EntranceExamId),
                                            new MyParameter("@StudentName",bookBase.StudentName),
                                            new MyParameter("@TeachersName",bookBase.TeachersName),
                                            new MyParameter("@TotalPages",bookBase.TotalPages),
                                            new MyParameter("@BookType",bookBase.BookType),
                                            new MyParameter("@SubjectId",bookBase.SubjectId),
                                            new MyParameter("@ChapterId",bookBase.ChapterId),
                                            new MyParameter("@UserId",bookBase.UserId),

                               };
                Common.Set_Procedures("USP_IU_Books");
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

        #region Books_LoadAll
        public DataTable Books_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                               };
                Common.Set_Procedures("USP_S_Books_LoadAll");
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

        #region Books_LoadBy_Id
        public DataTable Books_LoadBy_Id(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@Id",bookBase.Id)
                               };
                Common.Set_Procedures("USP_S_Books_LoadBy_Id");
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

        #region Books_LoadBy_UserId
        public DataTable Books_LoadBy_UserId(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@UserId",bookBase.UserId)
                               };
                Common.Set_Procedures("USP_S_Books_LoadBy_UserId");
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

        #region Books_LoadBy_Filter
        public DataTable Books_LoadBy_Filter(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@CountryId",bookBase.CountryId),
                                            new MyParameter("@StateId",bookBase.StateId),
                                            new MyParameter("@StreamId",bookBase.ExamStreamId),
                                            new MyParameter("@EntranceExamId",bookBase.EntranceExamId),
                                            new MyParameter("@SubjectId",bookBase.SubjectId),
                                            new MyParameter("@ChapterId",bookBase.ChapterId)
                               };
                Common.Set_Procedures("USP_S_Books_LoadBy_Filter");
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

        #region Books_Delete_By_Id
        public DataTable Books_Delete_By_Id(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@Id",bookBase.Id)
                               };
                Common.Set_Procedures("USP_D_Books");
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

        #region BooksRating_InsertUpdate
        public DataTable BooksRating_InsertUpdate(BooksRatingBase bookRating)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@Id",bookRating.Id),
                                            new MyParameter("@BookId",bookRating.BookId),
                                            new MyParameter("@UserId",bookRating.UserId),
                                            new MyParameter("@Rating",bookRating.Rate),
                                            new MyParameter("@Comment",bookRating.Comment)
                               };
                Common.Set_Procedures("USP_IU_BooksRating");
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

        #region BooksRating_LoadAll
        public DataTable BooksRating_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                               };
                Common.Set_Procedures("USP_S_BooksRating_LoadAll");
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

        #region method BooksRating_LoadBy_BookId
        public DataTable BooksRating_LoadBy_BookId(BooksRatingBase bookRatingBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@BookId",bookRatingBase.BookId)
                               };
                Common.Set_Procedures("USP_S_BooksRating_LoadBy_BookId");
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

        #region method BooksRating_LoadBy_UserId
        public DataTable BooksRating_LoadBy_UserId(BooksRatingBase bookRatingBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@UserId",bookRatingBase.UserId)
                               };
                Common.Set_Procedures("USP_S_BooksRating_LoadBy_UserId");
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

        #region BooksContent_InsertUpdate
        public DataTable BooksContent_InsertUpdate(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@Id",bookBase.Id),
                                            new MyParameter("@BookId",bookBase.BookId),
                                            new MyParameter("@PageNo",bookBase.PageNumber),
                                            new MyParameter("@ChpaterName",bookBase.ChapterName),
                                            new MyParameter("@Content",bookBase.Content),
                                            new MyParameter("@IsHtml",bookBase.IsHtml),
                                            new MyParameter("@ScreenShot",bookBase.ScreenShot),
                                            new MyParameter("@PageType",bookBase.PageType)
                               };
                Common.Set_Procedures("BookContent_InsertUpdate");
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

        #region CheckPageExistence
        public DataTable CheckPageExistence(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@BookId",bookBase.BookId),
                                              new MyParameter("@PageId",bookBase.PageNumber),
                                               new MyParameter("@ChapterName",bookBase.ChapterName)

                               };
                Common.Set_Procedures("CheckIfExist_PageChapter");
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

        #region GetPageDetails_ByBookId
        public DataTable GetPageDetails_ByBookId(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@BookId",bookBase.BookId)


                               };
                Common.Set_Procedures("GetPageDetails_ByBookId");
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

        #region GetPageContent_ByPageId
        public DataTable GetPageContent_ByPageId(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                            new MyParameter("@PageId",bookBase.PageNumber)
                               };
                Common.Set_Procedures("GetPageContent_ByPageId");
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

        #region GetpageIds
        public DataTable GetpageIds(int bookid)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={

                                            new MyParameter("@bookId",bookid)


                               };
                Common.Set_Procedures("GetPagesIds_byBookId");
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

        #region PageSocialDetails_insertView
        public DataTable PageSocialDetails_insertView(int PageId, string userid, string action)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={

                                            new MyParameter("@pageId",PageId),
                                            new MyParameter("@userId",userid),
                                             new MyParameter("@action",action)
                               };
                Common.Set_Procedures("PageSocialDetails_Insert");
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

        #region insertpageclick
        public DataTable insertpageclick(BookBase bookBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@pageId",bookBase.PageNumber),
                                            new MyParameter("@userId",bookBase.UserId),
                                             new MyParameter("@device",bookBase.Device)
                               };
                Common.Set_Procedures("Insert_PageClick_Details");
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
