using STA.DataLayer.CommonMethods;
using STU.BaseLayer;
using STU.BaseLayer.Common;
using STU.BaseLayer.User;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.ActionLayer.Common
{
    public class CommonAction
    {
        #region Declaration
        CommonDL commonDL;
        ActionResult actionResult;
        #endregion

        #region Countries_LoadAll
        public ActionResult Countries_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Countries_LoadAll();
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

        #region States_LoadBy_CountryId
        public ActionResult States_LoadBy_CountryId(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.States_LoadBy_CountryId(commonBase);
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

        #region Cities_LoadBy_StateId
        public ActionResult Cities_LoadBy_StateId(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Cities_LoadBy_StateId(commonBase);
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

        #region Notesbook_Load_ById
        public ActionResult Notesbook_Load_ById(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Notesbook_Load_ById(commonBase);
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

        #region EntranceExam_LoadAll
        public ActionResult EntranceExam_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.EntranceExam_LoadAll();
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

        #region ExamStream_LoadAll
        public ActionResult ExamStream_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.ExamStream_LoadAll();
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

        #region Subjects_LoadAll
        public ActionResult Subjects_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Subjects_LoadAll();
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

        #region Streams_LoadAll
        public ActionResult Streams_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Streams_LoadAll();
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

        #region Chapters_LoadAll
        public ActionResult Chapters_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Chapters_LoadAll();
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

        #region Notesbook_LoadAll
        public ActionResult Notesbook_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Notesbook_LoadAll();
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


        

        #region Colleges_LoadAll
        public ActionResult Colleges_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Colleges_LoadAll();
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

        #region Categories_LoadAll
        public ActionResult Categories_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Categories_LoadAll();
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

        #region Topics_LoadAll
        public ActionResult Topics_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Topics_LoadAll();
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

        #region Masters_InsertUpdate
        public ActionResult Masters_InsertUpdate(CommonMastersBase commonMasterBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Masters_InsertUpdate(commonMasterBase);
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

        #region Subjects_LoadById
        public ActionResult Subjects_LoadById(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Subjects_LoadById(common);
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

        #region Chapter_LoadById
        public ActionResult Chapter_LoadById(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Chapter_LoadById(common);
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

        #region Institute_LoadById
        public ActionResult Institute_LoadById(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Institute_LoadById(common);
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

        #region Institute_LoadById
        public ActionResult Institute_LoadByInstituteId(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Institute_LoadByInstituteId(common);
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

        #region Institute_LoadAll
        public ActionResult Institute_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Institute_LoadAll();
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

        #region Institutes_LoadByCityId
        public ActionResult Institutes_LoadByCityId(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Institutes_LoadByCityId(common);
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



        #region Stream_LoadById
        public ActionResult Stream_LoadById(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Stream_LoadById(common);
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

        #region Category_LoadById
        public ActionResult Category_LoadById(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Category_LoadById(common);
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

        #region Category_InsertUpdate
        public ActionResult Category_InsertUpdate(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Category_InsertUpdate(common);
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


        #region Update_StatusByID
        public ActionResult Update_StatusByID(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Update_StatusByID(common);
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

        #region Stream_InsertUpdate
        public ActionResult Stream_InsertUpdate(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Stream_InsertUpdate(common);
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


        #region Institute_InsertUpdate
        public ActionResult Institute_InsertUpdate(CommonBase common)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Institute_InsertUpdate(common);
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


        #region Subject_InsertUpdate
        public ActionResult Subject_InsertUpdate(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Subject_InsertUpdate(commonBase);
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

        #region Submitter_Reader_Count
        public ActionResult Submitter_Reader_Count(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Submitter_Reader_Count(commonBase);
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

        #region UserInfo_LoadById
        public ActionResult UserInfo_LoadById(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.UserInfo_LoadById(commonBase);
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


        #region NotebookDetails_Insert
        public ActionResult NotebookDetails_Insert(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.NotebookDetails_Insert(commonBase);
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

        #region NotebookDetails_Update
        public ActionResult NotebookDetails_Update(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.NotebookDetails_Update(commonBase);
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

        #region NotebookDetails_Delete
        public ActionResult NotebookDetails_Delete(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.NotebookDetails_Delete(commonBase);
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

        #region NotebookLoadByUserID
        public ActionResult NotebookLoadByUserID(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.NotebookLoadByUserID(commonBase);
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

        #region NotebookLoadById
        public ActionResult NotebookLoadById(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = commonDL.NotebookLoadById(commonBase);
                if (actionResult.dsResult != null && actionResult.dsResult.Tables.Count > 0)
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

        #region UpdateUsersInfoByUserId
        public ActionResult UpdateUsersInfoByUserId(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.UpdateUsersInfoByUserId(commonBase);
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


        #region UsersDetails
        public ActionResult UsersDetails(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.UsersDetails(commonBase);
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

        #region UpdateUserStatusById
        public ActionResult UpdateUserStatusById(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.UpdateUserStatusById(commonBase);
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


        #region UsersInfo_LoadBy_Id
        public ActionResult UsersInfo_LoadBy_Id(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.UsersInfo_LoadBy_Id(commonBase);
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

        #region SearchBooksByName
        public ActionResult SearchBooksByName(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.SearchBooksByName(commonBase);
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

        #region SearchBooksByNameAndroid
        public ActionResult SearchBooksByNameAndroid(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.SearchBooksByNameAndroid(commonBase);
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


        #region SearchBooksByUserText
        public ActionResult SearchBooksByUserText(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.SearchBooksByUserText(commonBase);
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

        
        #region FriendList_LoadByUserId
        public ActionResult FriendList_LoadByUserId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.FriendList_LoadByUserId(commonBase);
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

        #region FriendRequest_LoadByUserId
        public ActionResult FriendRequest_LoadByUserId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.FriendRequest_LoadByUserId(commonBase);
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

        #region BookContentLoadByBookId
        public ActionResult BookContentLoadByBookId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.BookContentLoadByBookId(commonBase);
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

        #region StreamsLoadByCategoryID
        public ActionResult StreamsLoadByCategoryID(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.StreamsLoadByCategoryID(commonBase);
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

        #region InstitutesLoadByStreamID
        public ActionResult InstitutesLoadByStreamID(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.InstitutesLoadByStreamID(commonBase);
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

        //   #region InstitutesLoadByStreamID
        //public ActionResult SearchBookByCategory(CommonBase commonBase)
        //{
        //    CommonDL CommonDL = new CommonDL();
        //    actionResult = new ActionResult();
        //    try
        //    {
        //        actionResult.dtResult = CommonDL.SearchBookByCategory(commonBase);
        //        if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
        //            actionResult.IsSuccess = true;
        //        else
        //            actionResult.IsError = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorReporting.WebApplicationError(ex);
        //    }
        //    return actionResult;
        //}
        //#endregion

        #region SubjectLoadByStreamId
        public ActionResult SubjectLoadByStreamId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.SubjectLoadByStreamId(commonBase);
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

        #region SearchBookByCatStrInsSub
        public ActionResult SearchBookByCatStrInsSub(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.SearchBookByCatStrInsSub(commonBase);
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

        #region SearchBookByCatStrInsSub_ByOFFSET
        public ActionResult SearchBookByCatStrInsSub_ByOFFSET(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.SearchBookByCatStrInsSub_ByOFFSET(commonBase);
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

        #region GetBooksByAllAndroid
        public ActionResult GetBooksByAllAndroid(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.GetBooksByAllAndroid(commonBase);
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

        
        //#region SearchBooksByCollege
        //public ActionResult SearchBooksByCollege(CommonBase commonBase)
        //{
        //    CommonDL CommonDL = new CommonDL();
        //    actionResult = new ActionResult();
        //    try
        //    {
        //        actionResult.dtResult = CommonDL.SearchBooksByCollege(commonBase);
        //        if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
        //            actionResult.IsSuccess = true;
        //        else
        //            actionResult.IsError = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorReporting.WebApplicationError(ex);
        //    }
        //    return actionResult;
        //}
        //#endregion

        //#region SearchBooksBySubject
        //public ActionResult SearchBooksBySubject(CommonBase commonBase)
        //{
        //    CommonDL CommonDL = new CommonDL();
        //    actionResult = new ActionResult();
        //    try
        //    {
        //        actionResult.dtResult = CommonDL.SearchBooksBySubject(commonBase);
        //        if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
        //            actionResult.IsSuccess = true;
        //        else
        //            actionResult.IsError = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorReporting.WebApplicationError(ex);
        //    }
        //    return actionResult;
        //}
        //#endregion


        #region NotificationsCount

        public ActionResult NotificationsCount(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = CommonDL.NotificationsCount(commonBase);
                if (actionResult.dsResult != null && actionResult.dsResult.Tables.Count > 0)
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




        #region Message_InsertUpdate

        public ActionResult Message_InsertUpdate(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = CommonDL.Message_InsertUpdate(commonBase);
                if (actionResult.dsResult != null && actionResult.dsResult.Tables.Count > 0)
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

        #region Message_Load

        public ActionResult Message_Load(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Message_Load(commonBase);
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

        #region CityPricing_InsertUpdate

        public ActionResult CityPricing_InsertUpdate(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = CommonDL.CityPricing_InsertUpdate(commonBase);
                if (actionResult.dsResult != null && actionResult.dsResult.Tables.Count > 0)
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

        #region Master_Categories_LoadAllPrice 
        public ActionResult Master_Categories_LoadAllPrice()
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Master_Categories_LoadAllPrice();
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

        #region Notesbook_LoadBy_OFFSET
        public ActionResult Notesbook_LoadBy_OFFSET(int PageNo,int offset, int userid)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Notesbook_LoadBy_OFFSET(PageNo, offset,userid);
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


        #region GetUsersList_ByCityId

        public ActionResult GetUsersList_ByCityId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.GetUsersList_ByCityId(commonBase);
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

        #region CurrencyList_LoadAll
        public ActionResult CurrencyList_LoadAll()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.CurrencyList_LoadAll();
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

        #region CurrencyRate_Update

        public ActionResult CurrencyRate_Update(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = CommonDL.CurrencyRate_Update(commonBase);
                if (actionResult.dsResult != null && actionResult.dsResult.Tables.Count > 0)
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

        #region Get_users_Country_CurrencyCodeandRate
        public ActionResult Get_users_Country_CurrencyCodeandRate(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Get_users_Country_CurrencyCodeandRate(commonBase);
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

        #region Paypaldetails
        public ActionResult Paypaldetails(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Paypaldetails(commonBase);
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
        #region Update_Wallet_ByuserId
        public ActionResult Update_Wallet_ByuserId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Update_Wallet_ByuserId(commonBase);
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

        #region Response_PaymentRequest
        public ActionResult Response_PaymentRequest(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Response_PaymentRequest(commonBase);
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


        #region Get_Country_CurrencyCode_Rate_by_CountryId
        public ActionResult Get_Country_CurrencyCode_Rate_by_CountryId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.Get_Country_CurrencyCode_Rate_by_CountryId(commonBase);
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

        #region Setting
        public ActionResult Setting(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Setting(commonBase);
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

        #region DeleteAccount
        public ActionResult DeleteAccount(CommonBase commonBase)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.Deleteaccount(commonBase);
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

        #region RemoveUnpiadAdd
        public ActionResult RemoveUnpiadAdd()
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.RemoveUnpiadAdd();
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
        #region CityNameByID
        public ActionResult CityNameByID( int id)
        {
            commonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = commonDL.CityNameByID(id);
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

        #region GetUPIDetails_ByuserId
        public ActionResult GetUPIDetails_ByuserId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.GetUPIDetails(commonBase);
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

        #region GetBankDetails_ByuserId
        public ActionResult GetBankDetails_ByuserId(CommonBase commonBase)
        {
            CommonDL CommonDL = new CommonDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = CommonDL.GetBankDetails(commonBase);
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

