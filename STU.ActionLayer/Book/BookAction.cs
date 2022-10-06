using STA.DataLayer.Book;
using STU.BaseLayer;
using STU.BaseLayer.Book;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.ActionLayer.Book
{
    public class BookAction
    {
        #region Declaration
        BookDL bookDL = new BookDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Books_InsertUpdate
        public ActionResult Books_InsertUpdate(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.Books_InsertUpdate(bookBase);

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

        #region Books_LoadAll
        public ActionResult Books_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.Books_LoadAll();

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

        #region Books_LoadBy_Id
        public ActionResult Books_LoadBy_Id(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.Books_LoadBy_Id(bookBase);

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

        #region Books_Delete_By_Id
        public ActionResult Books_Delete_By_Id(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.Books_Delete_By_Id(bookBase);

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

        #region Books_LoadBy_UserId
        public ActionResult Books_LoadBy_UserId(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.Books_LoadBy_UserId(bookBase);

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

        #region Books_LoadBy_Filter
        public ActionResult Books_LoadBy_Filter(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.Books_LoadBy_Filter(bookBase);

                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region BooksRating_InsertUpdate
        public ActionResult BooksRating_InsertUpdate(BooksRatingBase bookRating)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.BooksRating_InsertUpdate(bookRating);

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

        #region method BooksRating_LoadAll
        public ActionResult BooksRating_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.BooksRating_LoadAll();

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

        #region method BooksRating_LoadBy_BookId
        public ActionResult BooksRating_LoadBy_BookId(BooksRatingBase bookRating)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.BooksRating_LoadBy_BookId(bookRating);

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

        #region method BooksRating_LoadBy_UserId
        public ActionResult BooksRating_LoadBy_UserId(BooksRatingBase bookRating)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.BooksRating_LoadBy_UserId(bookRating);

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

        #region BooksContent_InsertUpdate
        public ActionResult BooksContent_InsertUpdate(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.BooksContent_InsertUpdate(bookBase);

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

        #region method CheckPageExistence
        public ActionResult CheckPageExistence(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.CheckPageExistence(bookBase);

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

        #region method GetPageDetails_ByBookId
        public ActionResult GetPageDetails_ByBookId(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.GetPageDetails_ByBookId(bookBase);
                Console.Write(actionResult.dtResult);

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
                Console.WriteLine(ex.Message);

                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region method GetPageContent_ByPageId
        public ActionResult GetPageContent_ByPageId(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.GetPageContent_ByPageId(bookBase);

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


        #region method GetpageIds
        public ActionResult GetpageIds(int bookId)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.GetpageIds(bookId);

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


        


        #region PageSocialDetails_insertView

        public ActionResult PageSocialDetails_insertView(int PageId, string userid, string action)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.PageSocialDetails_insertView(PageId, userid, action);

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

        #region insertpageclick
        public ActionResult insertpageclick(BookBase bookBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = bookDL.insertpageclick(bookBase);

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
