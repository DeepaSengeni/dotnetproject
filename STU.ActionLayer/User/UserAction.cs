using STA.DataLayer.User;
using STU.BaseLayer;
using STU.BaseLayer.Common;
using STU.BaseLayer.User;
using STU.Utility;
using System;

namespace STU.ActionLayer.User
{
    public class UserAction
    {
        #region Declaration
        UserDL userDl;
        ActionResult actionResult;
        #endregion

        #region UsersInfo_InsertUpdate
        public ActionResult UsersInfo_InsertUpdate(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersInfo_InsertUpdate(usersInfoBase);
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

        #region USP_U_UsersCoverPic
        public ActionResult USP_U_UsersCoverPic(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.USP_U_UsersCoverPic(usersInfoBase);
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

        #region USP_U_UsersProfilePic
        public ActionResult USP_U_UsersProfilePic(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.USP_U_UsersProfilePic(usersInfoBase);
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

        #region USP_Remove_UsersProfilePic
        public ActionResult USP_Remove_UsersProfilePic(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.USP_Remove_UsersProfilePic(usersInfoBase);
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

        #region UsersInfo_ForgotPassword
        public ActionResult UsersInfo_ForgotPassword(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersInfo_ForgotPassword(usersInfoBase);
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

        #region UsersInfo_ResetPassword
        public ActionResult UsersInfo_ResetPassword(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersInfo_ResetPassword(usersInfoBase);
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

        #region UsersInfo_LoadAll
        public ActionResult UsersInfo_LoadAll()
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersInfo_LoadAll();
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
        public ActionResult UsersInfo_LoadBy_Id(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersInfo_LoadBy_Id(usersInfoBase);
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

        #region InvitationList_UpdateStatus
        public ActionResult InvitationList_UpdateStatus(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.InvitationList_UpdateStatus(usersInfoBase);
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

        #region UsersInfo_Login
        public ActionResult UsersInfo_Login(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersInfo_Login(usersInfoBase);
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

        #region UsersInfo_Load_AllFriends
        public ActionResult UsersInfo_Load_AllFriends(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersInfo_Load_AllFriends(usersInfoBase);
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

        #region SearchStudent
        public ActionResult SearchStudent(string data)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.SearchStudent(data);
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

        #region SetLoginStatus
        public ActionResult SetLoginStatus(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.IsSuccess = userDl.SetLoginStatus(usersInfoBase);

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region ReaderDatails_Insert
        public ActionResult ReaderDatails_Insert(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.ReaderDatails_Insert(usersInfoBase);
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

        #region CheckEmailExist
        public ActionResult CheckEmailExist(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.CheckEmailExist(usersInfoBase);
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

        #region CheckMobileExist
        public ActionResult CheckMobileExist(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.CheckMobileExist(usersInfoBase);
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

        #region UpdateUsersInfo
        public ActionResult UpdateUsersInfo(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UpdateUsersInfo(usersInfoBase);
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

        #region UpdateUsersInfoPassword
        public ActionResult UpdateUsersInfoPassword(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UpdateUsersInfoPassword(usersInfoBase);
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

        #region New_Sub_Col_Cat_Strm_Insert
        public ActionResult New_Sub_Col_Cat_Strm_Insert(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = userDl.New_Sub_Col_Cat_Strm_Insert(usersInfoBase);
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

        //#region Readers_Login
        //public ActionResult Readers_Login(UsersInfoBase usersInfoBase)
        //{
        //    userDl = new UserDL();
        //    actionResult = new ActionResult();
        //    try
        //    {
        //        actionResult.dtResult = userDl.Readers_Login(usersInfoBase);
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

        #region Invitation_FriendRequest_Notification_List_IsRead_Update
        public ActionResult Invitation_FriendRequest_Notification_List_IsRead_Update(CommonBase commonBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = userDl.Invitation_FriendRequest_Notification_List_IsRead_Update(commonBase);
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

        #region InvitationList_InsertUpdate
        public ActionResult InvitationList_InsertUpdate(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = userDl.InvitationList_InsertUpdate(usersInfoBase);
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

        #region RemoveFriend
        public ActionResult RemoveFriend(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = userDl.RemoveFriend(usersInfoBase);
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

        #region MessageCount_IU
        public ActionResult MessageCount_IU(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.MessageCount_IU(usersInfoBase);
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

        #region UsersLoginInfo_Insert_Update
        public ActionResult UsersLoginInfo_Insert_Update(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.UsersLoginInfo_Insert_Update(usersInfoBase);
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

        #region GCMNotification_IU
        public ActionResult GCMNotification_IU(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.GCMNotification_IU(usersInfoBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region CountryExistance
        public ActionResult CountryExistance(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = userDl.CountryExistance(usersInfoBase);
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

        #region StateExistance
        public ActionResult StateExistance(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = userDl.StateExistance(usersInfoBase);
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

        #region CityExistance
        public ActionResult CityExistance(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = userDl.CityExistance(usersInfoBase);
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


        #region GetCountryDetail
        public ActionResult GetCountryDetail(UsersInfoBase usersInfoBase)
        {
            userDl = new UserDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = userDl.GetCountryDetail(usersInfoBase);
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
