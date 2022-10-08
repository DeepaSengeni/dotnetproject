using STA.DataLayer.Invitation;
using STU.BaseLayer;
using STU.BaseLayer.Invitations;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.ActionLayer.Invitation
{
    public class InvitationListAction
    {
        #region Declaration
        InvitationListDL invitationListDL;
        ActionResult actionResult;
        #endregion

        #region InvitationList_InsertUpdate
        public ActionResult InvitationList_InsertUpdate(InvitationListBase invitationListBase)
        {
            invitationListDL = new InvitationListDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = invitationListDL.InvitationList_InsertUpdate(invitationListBase);
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

        #region InvitationList_LoadBy_UserId
        public ActionResult InvitationList_LoadBy_UserId(InvitationListBase invitationListBase)
        {
            invitationListDL = new InvitationListDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = invitationListDL.InvitationList_LoadBy_UserId(invitationListBase);
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


        #region FriendList_InsertUpdate
        public ActionResult FriendList_InsertUpdate(InvitationListBase invitationListBase)
        {
            actionResult = new ActionResult();
            invitationListDL = new InvitationListDL();
            try
            {
                actionResult.dtResult = invitationListDL.FriendList_InsertUpdate(invitationListBase);
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
