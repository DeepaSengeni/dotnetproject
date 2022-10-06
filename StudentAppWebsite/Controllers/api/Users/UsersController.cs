using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppWebsite.Models;
using Newtonsoft.Json;
using STU.BaseLayer.User;
using STU.ActionLayer.User;
using System.Data;
using System.Collections;
using STU.BaseLayer.Common;
using STU.ActionLayer.Common;
using System.Web;
using System.IO;
using System.Globalization;

namespace StudentAppWebsite.Controllers.api.Users
{
    public class UsersController : ApiController
    {
        ApiResponseModel resmodel = new ApiResponseModel();
        UserAction UserActions = new UserAction();
        CommonBase common = new CommonBase();
        CommonAction commonAction = new CommonAction();
        

        #region Update Users Detail
        [HttpPost]
        public ApiResponseModel UpdateUserDetail(UsersInfoBase usersinfo)
        {
            try
            {
                resmodel = new ApiResponseModel();
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = usersinfo.Id;
                usersInfoBase.FirstName = usersinfo.FirstName;
                usersInfoBase.LastName = usersinfo.LastName;
                usersInfoBase.CountryId = usersinfo.CountryId;
                usersInfoBase.StateId = usersinfo.StateId;
                usersInfoBase.CityId = usersinfo.CityId;
                usersInfoBase.Gender = usersinfo.Gender;
                usersInfoBase.DOB = usersinfo.DOB;
                usersInfoBase.DOB = Convert.ToDateTime(usersinfo.DOB, CultureInfo.CurrentUICulture).ToString();
               
                usersInfoBase.IsActive = true;
                var data = UserActions.UsersInfo_InsertUpdate(usersInfoBase);
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
                    resmodel.Message = "Failure";
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

        #region Update_CoverPic
        [HttpPost]
        public ApiResponseModel Update_CoverPic(int id, string coverimage)
        {
            try
            {
                resmodel = new ApiResponseModel();
                string position = "";
                var data = UserActions.USP_U_UsersCoverPic(new UsersInfoBase { Id = id, CoverImage = coverimage, Position = position });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
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

        #region Remove_ProfilePic
        [HttpDelete]
        public ApiResponseModel Remove_ProfilePic(int userid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = UserActions.USP_Remove_UsersProfilePic(new UsersInfoBase { Id = userid });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(userid);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Failure";
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

        #region FindFriend
        [HttpPost]
        public ApiResponseModel findfriend(string data,int userid)
        {
            ApiResponseModel resmodel = new ApiResponseModel();
            string[] query = data.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            CommonBase common = new CommonBase();        
            try
            {
                DataTable dt = new DataTable();
                for (int i = 0; i <= query.Length - 1; i++)
                {
                    STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                    var basel = new STU.BaseLayer.ActionResult();
                    basel = UserAction.SearchStudent(query[i]);
                    if (i == 0) dt = basel.dtResult.Clone();
                    foreach (DataRow row in basel.dtResult.Rows)
                    {
                        dt.Rows.Add(row.ItemArray);
                    }
                }
                RemoveDuplicateRows(dt, "Id");
                Profile profileModel = new Profile();
                List<Profile> lstprofileModel = new List<Profile>();
                List<NotebookForm> lstNotebookModel = new List<NotebookForm>();
                List<Friend> FriendList = new List<Friend>();
                List<Friend> FriendRequests = new List<Friend>();

                if (dt.Rows.Count > 0)
                {

                    FriendList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(dt);
                    var friendls = FriendList;
                    common.Id = userid;
                    var friendrequest = commonAction.FriendRequest_LoadByUserId(common);
                    if (friendrequest.IsSuccess)
                    {
                        FriendRequests = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(friendrequest.dtResult);
                    }
                    string FriendRequest = string.Empty;
                    string Friendlist = string.Empty;
                    string json = string.Empty;
                    FriendRequest = Newtonsoft.Json.JsonConvert.SerializeObject(FriendRequests);
                    Friendlist = Newtonsoft.Json.JsonConvert.SerializeObject(FriendList);

                    json = "{\"Status\":\"1\",\"FriendRequest\":" + FriendRequest + ",\"Profile\":" + Friendlist + "}";
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
                    resmodel.ResponseData = json;

                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex) {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        #region Search_Student
        [HttpGet]
        public ApiResponseModel SearchStudent(string data)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var comp = UserActions.SearchStudent(data);
                if (comp.IsSuccess == true)
                {
                        resmodel.IsError = false;
                        resmodel.IsSuccess = true;
                        resmodel.Message = "Successful";
                        resmodel.ResponseData = JsonConvert.SerializeObject(comp.dtResult);
                    }
                    else
                    {
                        resmodel.IsError = true;
                        resmodel.IsSuccess = false;
                        resmodel.Message = "Failure";
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


        #region RemoveDuplicateRows
        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }
        #endregion

        #region New_Sub_Col_Cat_Strm_Insert
        [HttpPost]
        public ApiResponseModel New_Sub_Col_Cat_Strm_Insert(UsersInfoBase usersinfo)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = UserActions.New_Sub_Col_Cat_Strm_Insert(usersinfo);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
                else
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return resmodel;
        }

        #endregion

        #region Invitation_FriendRequest_Notification_List_IsRead_Update
        //type=invitationLi || notificationLi || friendLi
        [HttpPost]
        public ApiResponseModel Invitation_FriendRequest_Notification_List_IsRead_Update(int userid, string type)
        {
            try
            {
                string json = string.Empty;
                resmodel = new ApiResponseModel();
                CommonBase commonBase = new CommonBase();
                commonBase.UserId = Convert.ToInt32(userid);
                commonBase.Type = type;
                var data = UserActions.Invitation_FriendRequest_Notification_List_IsRead_Update(commonBase);
                if (data.IsSuccess == true)
                {
                    json = "{\"IsRead\":\"1\"}";
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(json);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Failure";
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

        #region RemoveFriend
        [HttpPost]
        public ApiResponseModel RemoveFriend(int ID)
        {
            try
            {
                resmodel = new ApiResponseModel();
                string json = string.Empty;
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = ID;
                UserActions = new UserAction();
                var data = UserActions.RemoveFriend(usersInfoBase);
                if (data.IsSuccess == true)
                { 
                json = "{\"Status\":\"1\"}";
                resmodel.IsError = false;
                resmodel.IsSuccess = true;
                resmodel.Message = "Unfriend Successfully";
                resmodel.ResponseData = JsonConvert.SerializeObject(data.dtResult);
            }
                else
                {
                    json = "{\"Status\":\"-1\"}";
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Error Please try again later";
                    resmodel.ResponseData ="[]";
                }
                    
            }
            catch(Exception ex)
            {
                throw (ex);
            }

            

            return resmodel;
        }
        #endregion

        [HttpPost]
        public HttpResponseMessage Update_Picture(string filename)
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                var postedFile = httpRequest.Files[0];
                string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + postedFile.FileName;
                //var fileName = Path.GetFileName(FileDataContent.FileName);
                //if (uploadedfilename.Contains(" "))
                //{
                //    uploadedfilename.Replace(" ", "_");
                //}
                var file = filename.Split('.');

                string tempGuid = Guid.NewGuid().ToString().Substring(0, 5) + "_" + filename;
                DirectoryInfo dinfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Content/Uploads/Users/"));
                    if (!dinfo.Exists)
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Uploads/Users/"));
                    }
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Uploads/Users/"+ tempGuid));
                    var returnpath = Path.Combine(("/Content/Uploads/Users/" + tempGuid));
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                    result = Request.CreateResponse(HttpStatusCode.Created, returnpath);        
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return result;
        }
        [HttpPost]
        public ApiResponseModel USP_U_UsersProfilePic(int userid,string ProfileImage)
        {
            try
            {
                resmodel = new ApiResponseModel();
                UsersInfoBase usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = userid;
                usersInfoBase.ProfileImage = ProfileImage;
                var data = UserActions.USP_U_UsersProfilePic(usersInfoBase);
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
                    resmodel.Message = "Failure";
                    resmodel.ResponseData = "[]";
                }
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return resmodel;
        }


    }
}
