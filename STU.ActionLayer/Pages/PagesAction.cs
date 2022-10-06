using STA.DataLayer.Pages;
using STU.BaseLayer;
using STU.BaseLayer.Pages;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.ActionLayer.Pages
{
    public class PagesAction
    {
        #region Declaration
        ActionResult actionResult;
        PagesDL pagesDL;
        #endregion

        #region Pages_InsertUpdate
        public ActionResult Pages_InsertUpdate(PagesBase pagesBase)
        {
            pagesDL = new PagesDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = pagesDL.Pages_InsertUpdate(pagesBase);
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

        #region Pages_LoadBy_BookId
        public ActionResult Pages_LoadBy_BookId(PagesBase pagesBase)
        {
            pagesDL = new PagesDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = pagesDL.Pages_LoadBy_BookId(pagesBase);
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

        #region Pages_LoadBy_Id
        public ActionResult Pages_LoadBy_Id(PagesBase pagesBase)
        {
            pagesDL = new PagesDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = pagesDL.Pages_LoadBy_Id(pagesBase);
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


        #region RemovePageById
        public ActionResult RemovePageById(PagesBase pagesBase)
        {
            pagesDL = new PagesDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = pagesDL.RemovePageById(pagesBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    if ((Convert.ToInt32(actionResult.dtResult.Rows[0][0]))>0)
                        actionResult.IsSuccess = true;
                    else
                        actionResult.IsError = false;
                else
                    actionResult.IsError = false;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Ad_LoadBy_BookId
        public ActionResult Ad_LoadBy_BookId(PagesBase pagesBase)
        {
            pagesDL = new PagesDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = pagesDL.Ad_LoadBy_BookId(pagesBase);
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


        #region Ad_LoadBy_Id
        public ActionResult Ad_LoadBy_Id(PagesBase pagesBase)
        {
            pagesDL = new PagesDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = pagesDL.Ad_LoadBy_Id(pagesBase);
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
