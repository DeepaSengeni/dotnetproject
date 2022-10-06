using STU.BaseLayer.Invitations;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.DataLayer.Invitation
{
    public class InvitationListDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion


        #region InvitationList_InsertUpdate
        public DataTable InvitationList_InsertUpdate(InvitationListBase invitationListBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",invitationListBase.Id),
                                           new MyParameter("@UserId",invitationListBase.UserId),
                                           new MyParameter("@InvitedUserId",invitationListBase.InvitedUserId),
                                           new MyParameter("@topicID",invitationListBase.QuestionID)
                                         };
                Common.Set_Procedures("USP_IU_InvitationList");
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

        #region InvitationList_LoadBy_UserId
        public DataTable InvitationList_LoadBy_UserId(InvitationListBase invitationListBase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@UserId",invitationListBase.UserId)
                                         };
                Common.Set_Procedures("USP_S_InvitationList_LoadBy_UserId");
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

        #region FriendList_InsertUpdate
        public DataTable FriendList_InsertUpdate(InvitationListBase invitationListBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@UserId",invitationListBase.UserId),
                                             new MyParameter("@InvitedUserId",invitationListBase.InvitedUserId),
                                              new MyParameter("@CreatDate",invitationListBase.CreatedDate.ToString())

                                         };
                Common.Set_Procedures("FriendRequests_I_U");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception Ex)
            {
                ErrorReporting.WebApplicationError(Ex);
            }
            return dtContainer;
        }
        #endregion

    }
}
