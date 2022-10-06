using STU.BaseLayer.Common;
using STU.BaseLayer.User;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace STA.DataLayer.User
{
    public class UserDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;

        #endregion

        #region UsersInfo_InsertUpdate
        public DataTable UsersInfo_InsertUpdate(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@Id",usersInfoBase.Id),
                                          new MyParameter("@UserRole",usersInfoBase.UserRole),
                                          new MyParameter("@StudentName",usersInfoBase.StudentName),
                                          new MyParameter("@FirstName",usersInfoBase.FirstName),
                                          new MyParameter("@LastName",usersInfoBase.LastName),
                                          new MyParameter("@ProfileImage",usersInfoBase.ProfileImage),
                                          //new MyParameter("@CoverImage",usersInfoBase.CoverImage),
                                          new MyParameter("@TeacherName",usersInfoBase.TeacherName),
                                          //new MyParameter("@ChapterId",usersInfoBase.ChapterId),
                                          //new MyParameter("@SubjectId",usersInfoBase.SubjectId),
                                          new MyParameter("@CollegeId",usersInfoBase.CollegeId),
                                          //new MyParameter("@TopicId",usersInfoBase.TopicId),
                                          //new MyParameter("@EntranceExamId",usersInfoBase.EntranceExamId),
                                          //new MyParameter("@ExamStreamId",usersInfoBase.ExamStreamId),
                                          //new MyParameter("@StreamId",usersInfoBase.StreamId),
                                          //new MyParameter("@CategoryId",usersInfoBase.CategoryId),
                                          new MyParameter("@CountryId",usersInfoBase.CountryId),
                                          new MyParameter("@StateId",usersInfoBase.StateId),
                                          new MyParameter("@CityId",usersInfoBase.CityId),
                                          //new MyParameter("@NoteBooksFrontCoverImage",usersInfoBase.NoteBooksFrontCoverImage),
                                          //new MyParameter("@Date",usersInfoBase.Date),
                                          //new MyParameter("@ATMNumber",usersInfoBase.ATMNumber),
                                          //new MyParameter("@NameOnATMCard",usersInfoBase.NameOnATMCard),
                                          new MyParameter("@MobileNumber",usersInfoBase.MobileNumber),
                                          new MyParameter("@EmailId",usersInfoBase.EmailId),
                                          new MyParameter("@Password",usersInfoBase.Password),
                                          new MyParameter("@IsActive",usersInfoBase.IsActive),
                                          new MyParameter("@DOB",usersInfoBase.DOB),
                                          new MyParameter("@Gender",usersInfoBase.Gender),
                                           new MyParameter("@CompleteAddress",usersInfoBase.Address),
                                             new MyParameter("@ISD_Code",usersInfoBase.ISD_Code),
                                         };
                Common.Set_Procedures("USP_IU_UsersInfo");
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


        #region USP_U_UsersCoverPic
        public DataTable USP_U_UsersCoverPic(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@Id",usersInfoBase.Id),

                                          new MyParameter("@CoverImage",usersInfoBase.CoverImage),

                                          new MyParameter("@Position",usersInfoBase.Position)
                                         };
                Common.Set_Procedures("USP_U_UsersCoverPic");
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

        public DataTable USP_U_UsersCustomerid(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@Id",usersInfoBase.Id),

                                          new MyParameter("@Customerid",usersInfoBase.Customerid)
                                         };
                Common.Set_Procedures("USP_U_Users_Customerid");
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

        #region USP_U_UsersProfilePic
        public DataTable USP_U_UsersProfilePic(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@Id",usersInfoBase.Id),

                                          new MyParameter("@ProfileImage",usersInfoBase.ProfileImage),


                                         };
                Common.Set_Procedures("USP_U_UsersProfilePic");
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


        #region USP_Remove_UsersProfilePic
        public DataTable USP_Remove_UsersProfilePic(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@Id",usersInfoBase.Id)

                                         };
                Common.Set_Procedures("USP_D_UsersProfilePic");
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



        #region UsersInfo_ForgotPassword
        public DataTable UsersInfo_ForgotPassword(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@EmailId",usersInfoBase.EmailId),
                                          new MyParameter("@PasswordResetToken",usersInfoBase.PasswordResetToken)
                                         };
                Common.Set_Procedures("USP_S_UsersInfo_ForgotPassword");
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

        #region UsersInfo_ResetPassword
        public DataTable UsersInfo_ResetPassword(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@PasswordResetToken",usersInfoBase.PasswordResetToken),
                                          new MyParameter("@Password",usersInfoBase.Password)
                                         };
                Common.Set_Procedures("USP_U_UsersInfo_ResetPassword");
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

        #region UsersInfo_LoadAll
        public DataTable UsersInfo_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("USP_S_UsersInfo_LoadAll");
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

        #region UsersInfo_LoadBy_Id
        public DataTable UsersInfo_LoadBy_Id(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",usersInfoBase.Id),
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


        #region UsersInfo_Login
        public DataTable UsersInfo_Login(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@EmailId",usersInfoBase.EmailId),
                                           new MyParameter("@Password",usersInfoBase.Password)
                                         };
                Common.Set_Procedures("USP_S_UsersInfo_Login");
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


        #region UsersInfo_Load_AllFriends
        public DataTable UsersInfo_Load_AllFriends(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@userID",usersInfoBase.Id),
                                         };
                Common.Set_Procedures("UsersInfo_Load_AllFriends");
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

        #region SearchStudent
        public DataTable SearchStudent(string data)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@data",data),
                                         };
                Common.Set_Procedures("SearchStudent");
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

        #region InvitationList_UpdateStatus
        public DataTable InvitationList_UpdateStatus(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                // string procedureName = usersInfoBase.TopicId == 1 ? "FriendRequests_StatusUpdate_ById" : "InvitationList_UpdateStatus";
                MyParameter[] myParams = {
                                           new MyParameter("@Id",usersInfoBase.Id),
                                           new MyParameter("@Status",usersInfoBase.RequestStatus)
                                         };
                if (usersInfoBase.TopicId == 1)
                {
                    Common.Set_Procedures("FriendRequests_StatusUpdate_ById");
                }
                else
                {
                    Common.Set_Procedures("InvitationList_UpdateStatus");
                }
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


        #region SetLoginStatus
        public bool SetLoginStatus(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            bool result = false;
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@userID",usersInfoBase.Id)
                                         };
                Common.Set_Procedures("SetLoginStatus");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                result = Common.Execute_Procedures_IUD(dsContainer);

            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return result;
        }
        #endregion


        #region ReaderDatails_Insert
        public DataTable ReaderDatails_Insert(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Id",usersInfoBase.Id),
                                          new MyParameter("@StudentName",usersInfoBase.StudentName),
                                            new MyParameter("@UserRole",usersInfoBase.UserRole),
                                          new MyParameter("@ProfileImage",usersInfoBase.ProfileImage),
                                          new MyParameter("@TeacherName",usersInfoBase.TeacherName),
                                          new MyParameter("@CollegeId",usersInfoBase.CollegeId),
                                          new MyParameter("@CountryId",usersInfoBase.CountryId),
                                          new MyParameter("@StateId",usersInfoBase.StateId),
                                          new MyParameter("@CityId ",usersInfoBase.CityId),

                                          new MyParameter("@MobileNumber",usersInfoBase.MobileNumber),
                                          new MyParameter("@EmailID",usersInfoBase.EmailId),
                                          new MyParameter("@Password",usersInfoBase.Password),
                                           new MyParameter("@IsActive",usersInfoBase.IsActive),


                                         };
                Common.Set_Procedures("USP_IU_UsersInfo");
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



        #region CheckEmailExist
        public DataTable CheckEmailExist(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@EmailID",usersInfoBase.EmailId)
                                          };
                Common.Set_Procedures("CheckEmailExist");
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


        #region CheckMobileExist
        public DataTable CheckMobileExist(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@PhoneNumber",usersInfoBase.MobileNumber)
                                          };
                Common.Set_Procedures("CheckPhoneExist");
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

        #region UpdateUsersInfo
        public DataTable UpdateUsersInfo(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@EmailID",usersInfoBase.EmailId),
                                           new MyParameter("@Guid",usersInfoBase.Guid)
                                          };
                Common.Set_Procedures("UpdatePasswordResetToken");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();

            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region UpdateUsersInfoPassword
        public DataTable UpdateUsersInfoPassword(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@Password",usersInfoBase.Password),
                                           new MyParameter("@Guid",usersInfoBase.Guid)
                                          };
                Common.Set_Procedures("UpdatePasswordByGuid");
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


        #region New_Sub_Col_Cat_Strm_Insert
        public DataSet New_Sub_Col_Cat_Strm_Insert(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@Collegename",usersInfoBase.InstituteName),
                                           new MyParameter("@Subjectname",usersInfoBase.SubjectName),
                                           new MyParameter("@Categoryname",usersInfoBase.CategoryName),
                                           new MyParameter("@Streamname",usersInfoBase.StreamName),
                                           new MyParameter("@Cat_Id",usersInfoBase.CategoryId),
                                           new MyParameter("@Stream_Id",usersInfoBase.StreamId),
                                            new MyParameter("@Subject_Id",usersInfoBase.SubjectId),
                                           new MyParameter("@Institute_Id",usersInfoBase.CollegeId),
                                           //new MyParameter("@InstituteType",usersInfoBase.InstituteType),
                                           //new MyParameter("@SubjectType",usersInfoBase.SubjectType),
                                           //new MyParameter("@CategoryType",usersInfoBase.CategoryType),
                                           //new MyParameter("@StreamType",usersInfoBase.StreamType)
                                          };
                Common.Set_Procedures("New_Sub_Col_Cat_Strm_Insert");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion



        #region Invitation_FriendRequest_Notification_List_IsRead_Update
        public DataSet Invitation_FriendRequest_Notification_List_IsRead_Update(CommonBase commonBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@UserId",commonBase.UserId),
                                          new MyParameter("@type",commonBase.Type)

                                          };
                Common.Set_Procedures("Invitation_FriendRequest_Notification_List_IsRead_Update");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion


        #region InvitationList_InsertUpdate
        public DataSet InvitationList_InsertUpdate(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@UserId",usersInfoBase.Id),
                                          new MyParameter("@InvitedUserId",usersInfoBase.InvitedUserId),
                                          new MyParameter("@PageId",usersInfoBase.TopicId),
                                          new MyParameter("@date",usersInfoBase.CreatedDate),
                                          };
                Common.Set_Procedures("InvitationList_InsertUpdate");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region RemoveFriend
        public DataSet RemoveFriend(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@Id",usersInfoBase.Id)
                                          };
                Common.Set_Procedures("FriendRequests_D_ById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region MessageCount_IU
        public DataTable MessageCount_IU(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@UserId",usersInfoBase.Id),
                                             new MyParameter("@Count",usersInfoBase.Counts)
                                          };
                Common.Set_Procedures("UserMessages_IU");
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


        #region UsersLoginInfo_Insert_Update
        public DataTable UsersLoginInfo_Insert_Update(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@UserId",usersInfoBase.Id),
                                             new MyParameter("@IsActive",usersInfoBase.IsActive)

                                          };
                Common.Set_Procedures("UsersLoginInfo_I_U");
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


        #region GCMNotification_IU
        public DataTable GCMNotification_IU(UsersInfoBase userBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@UserId", userBase.Id),
                                            new MyParameter("@AndroidDeviceId", userBase.AndroidDeviceId),
                                            new MyParameter("@RegistrationToken", userBase.RegistrationToken)
                                         };
                Common.Set_Procedures("sp_GCMNotification_IU");
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

        #region CountryExistance
        public DataSet CountryExistance(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@countryname",usersInfoBase.countryname),
                                           new MyParameter("@countryid",usersInfoBase.CountryId),

                                          };
                Common.Set_Procedures("CountryExistance");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region StateExistance
        public DataSet StateExistance(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@statename",usersInfoBase.statename),
                                           new MyParameter("@Countryid",usersInfoBase.CountryId),
                                           new MyParameter("@stateid",usersInfoBase.StateId),

                                          };
                Common.Set_Procedures("StateExistance");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region StateExistance
        public DataSet CityExistance(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@cityname",usersInfoBase.cityname),
                                           new MyParameter("@cityid",usersInfoBase.CityId),
                                           new MyParameter("@stateid",usersInfoBase.StateId),
                                          };
                Common.Set_Procedures("CityExistance");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion



        #region GetCountryDetail
        public DataTable GetCountryDetail(UsersInfoBase usersInfoBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Userid",usersInfoBase.Id)
                                         };
                Common.Set_Procedures("GetCountryDetail");
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
