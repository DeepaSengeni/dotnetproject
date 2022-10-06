using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppWebsite.Models;
using STU.ActionLayer.Invitation;
using Newtonsoft.Json;
using STU.BaseLayer.User;
using STU.ActionLayer.User;

namespace StudentAppWebsite.Controllers.api.Invitation
{
    public class InvitationController : ApiController
    {
        ApiResponseModel resmodel = new ApiResponseModel();
        InvitationListAction Invitation = new InvitationListAction();

        #region Invitation Insert

        [HttpPost]
        public ApiResponseModel InvitationList_Insert( int userid, int inviteduserid, int pageId)
        {
            try
            {
                resmodel = new ApiResponseModel();
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                UserAction userAction = new UserAction();
                usersInfoBase.Id = userid;
                usersInfoBase.InvitedUserId = inviteduserid;
                usersInfoBase.TopicId = pageId;
                var data = userAction.InvitationList_InsertUpdate(usersInfoBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        #region Invitation Update

        [HttpPut]
        public ApiResponseModel InvitationList_Update(int id,int userid,int inviteduserid,int topicid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = Invitation.InvitationList_InsertUpdate(new STU.BaseLayer.Invitations.InvitationListBase { Id=id,UserId=userid,InvitedUserId=inviteduserid,QuestionID=topicid});
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        #region InvitationList_LoadBy_UserId

        [HttpGet]
        public ApiResponseModel InvitationList_LoadBy_UserId(int userid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = Invitation.InvitationList_LoadBy_UserId(new STU.BaseLayer.Invitations.InvitationListBase { UserId=userid});
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        #region FriendList_InsertUpdate

        [HttpPost]
        public ApiResponseModel FriendList_InsertUpdate(int userid,int invid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                DateTime CreateDate = System.DateTime.Now;
                var data = Invitation.FriendList_InsertUpdate(new STU.BaseLayer.Invitations.InvitationListBase { UserId = userid,InvitedUserId=invid , CreatedDate= CreateDate.ToString("MMM dd yyyy hh:mm tt") });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        #region InvitationList_UpdateStatus
        [HttpPost]
        public ApiResponseModel InvitationList_UpdateStatus(int Id, int status, int type)
        {
            resmodel = new ApiResponseModel();
            try
            {
                string json = string.Empty;
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = Id;
                usersInfoBase.TopicId = type;
                usersInfoBase.RequestStatus = status;
                UserAction userAction = new UserAction();
                var invitation = new STU.BaseLayer.ActionResult();
                invitation = userAction.InvitationList_UpdateStatus(usersInfoBase);
                if (invitation.IsSuccess)
                {

                    json = "{\"Status\":\"1\"}";
                    resmodel.IsSuccess = true;
                    resmodel.IsError = false;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = json;
                }
                else
                {
                    json = "{\"Status\":\"-1\"}";
                    resmodel.IsSuccess = false;
                    resmodel.IsError = true;
                    resmodel.Message = "fail";
                    resmodel.ResponseData = json;
                }
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return resmodel;
        }
        #endregion



    }
}
