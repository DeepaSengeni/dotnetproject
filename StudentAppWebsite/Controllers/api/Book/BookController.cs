using STU.ActionLayer.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAppWebsite.Models;
using STU.BaseLayer.Book;
using Newtonsoft.Json;
using STU.BaseLayer.Common;
using STU.ActionLayer.Common;
using System.Data;
using System.Collections;
using System.Web;
using System.IO;
using STU.Utility;
using System.Text;
using System.Threading.Tasks;

namespace StudentAppWebsite.Controllers.api.Book
{
    public class BookController : ApiController
    {
        BookAction bookAction = new BookAction();
        ApiResponseModel resmodel = new ApiResponseModel();
        BookBase bookBase = new BookBase();
        CommonAction commonAction = new CommonAction();
        CommonBase commonBase = new CommonBase();
     

        #region Insert_Book_Rating
        [HttpPost]
        public ApiResponseModel InsertBooksRating(int id, int Rate, int BookId, int UserId, string comment)
        {
            try
            {
                resmodel = new ApiResponseModel();
               // bookAction = new BookAction();
                var data = bookAction.BooksRating_InsertUpdate(new BooksRatingBase {Id=id,  Rate = Rate, BookId = BookId, UserId = UserId,Comment=comment });
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
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


        #region Update_Book_Rating
        [HttpPut]
        public ApiResponseModel UpdateBooksRating(int id,int Rate, int BookId, int UserId,string comment )
        {
            try
            {
                resmodel = new ApiResponseModel();
                BooksRatingBase booksbaserate = new BooksRatingBase();
                booksbaserate.Id = id;
                booksbaserate.Rate = Rate;
                booksbaserate.BookId = BookId;
                booksbaserate.UserId = UserId;
                booksbaserate.Comment = comment;
                var data = bookAction.BooksRating_InsertUpdate(booksbaserate);
                if(data.IsSuccess==true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
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
            catch(Exception ex)
            {
                throw (ex);
            }
            return resmodel;
        }
        #endregion

        public static string ImageToBase64(string _imagePath)
        {
            string _base64String = null;

            using (System.Drawing.Image _image = System.Drawing.Image.FromFile(_imagePath))
            {
                using (MemoryStream _mStream = new MemoryStream())
                {
                    _image.Save(_mStream, _image.RawFormat);
                    byte[] _imageBytes = _mStream.ToArray();
                    _base64String = Convert.ToBase64String(_imageBytes);

                    return "data:image/jpg;base64," + _base64String;
                }
            }
        }
        #region Add Notebook_Content

        [HttpPost]
        public ApiResponseModel AddNotebook(NotebookForm model, string screenshot, string hdnPageType, string src)
        {
           try
            {
                resmodel = new ApiResponseModel();
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                bookBase.ChapterName = model.ChapterName;
                bookBase.ScreenShot = (Convert.ToString(screenshot) != null && Convert.ToString(screenshot) != "") ? Convert.ToString(screenshot) : "";
                bookBase.IsHtml = (Convert.ToString(hdnPageType) == "Test") ? true : false;
                bookBase.PageType = Convert.ToString(hdnPageType);

                //if (bookBase.PageType == "Image")
                //{
                //  var imagecontent = ImageToBase64(src);
                //  bookBase.Content = imagecontent;
                //}
                //else if (bookBase.PageType == "Audio")
                //{
                //    bookBase.Content = Convert.ToString(src);
                //}
                //else if (bookBase.PageType == "Video")
                //{
                //    bookBase.Content = Convert.ToString(src);
                //}
                //else
                //{
                    
                //}
                bookBase.Content = HttpUtility.HtmlDecode(model.Content);
                bookBase.Id = model.Id;
                bookBase.BookId = Convert.ToInt64(model.NotebookId);
                bookBase.PageNumber = model.PageNumber;

                var data = bookAction.BooksContent_InsertUpdate(bookBase);

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

        #region CheckPageExistence
        [HttpGet]
        public ApiResponseModel CheckPageExistence(int bookId, int pageNo, string ChapterName)
        {
            string result = string.Empty;
            try
            {
                resmodel = new ApiResponseModel();
                BookBase bookBase = new BookBase();
                BookAction bookAction = new BookAction();
                bookBase.ChapterName = ChapterName;
                bookBase.BookId = Convert.ToInt64(bookId);
                bookBase.PageNumber = pageNo;


                var data = bookAction.CheckPageExistence(bookBase);

                if (data.IsSuccess == true)
                {
                    result = "{\"status\":\"" + data.dtResult.Rows[0][0] + "\"}";
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Page Exist ";
                    resmodel.ResponseData = JsonConvert.SerializeObject(result);
                }
                else
                {
                    resmodel.IsError = true;
                    resmodel.IsSuccess = false;
                    resmodel.Message = "Failure";
                    resmodel.ResponseData ="[]";
                }
            }
            catch (Exception ex)
            {


            }
            return resmodel;
        }
        #endregion

        #region GetPageDetails_ByBookId
        [HttpGet]
        public ApiResponseModel GetPageDetails_ByBookId(int bookId)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = bookAction.GetPageDetails_ByBookId(new BookBase { BookId= bookId });

                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
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


            }
            return resmodel;
        }
        #endregion
        
        #region  GetPageContent_ByPageId
        [HttpGet]
        public ApiResponseModel GetPageContent_ByPageId(int pageid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = bookAction.GetPageContent_ByPageId(new BookBase { PageNumber = pageid });

                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
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

        #region  GetpageIds
        [HttpGet]
        public ApiResponseModel GetpageIds(int pageid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = bookAction.GetpageIds(pageid);

                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
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

        #region  PageSocialDetails_insertView
        [HttpGet]
        public ApiResponseModel PageSocialDetails_insertView(int PageId, string userid, string action)
        {
            try
            {
                resmodel = new ApiResponseModel();
                var data = bookAction.PageSocialDetails_insertView(PageId,userid,action);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
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


            }
            return resmodel;
        }
        #endregion

        #region  insertpageclick
        [HttpPost]
        public ApiResponseModel insertpageclick(int PageId, int userid, string device)
        {
            try
            {
                resmodel = new ApiResponseModel();
                bookBase.PageNumber = PageId;
                bookBase.UserId = userid;
                bookBase.Device = device;
                var data = bookAction.insertpageclick(bookBase);
                if (data.IsSuccess == true)
                {
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Success";
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

        #region NotebookListLoadByUserId
        [HttpGet]
        public ApiResponseModel NotebookListLoadByUserId(int userid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                BookAction bookaction = new BookAction();
                var data = bookaction.Books_LoadBy_UserId(new STU.BaseLayer.Book.BookBase { UserId = userid });
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

        #region NoteBook load by subjectId
        [HttpGet]
        public ApiResponseModel NotebookLoadBySubjectId(int Subjectid)
        {
            try
            {
                resmodel = new ApiResponseModel();
                BookAction bookaction = new BookAction();
                var data = commonAction.SearchBookByCatStrInsSub(new CommonBase { SubjectId = Convert.ToString(Subjectid) });
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

        #region SearchBooksByName
        [HttpPost]
        public ApiResponseModel SearchBooksByName(string name, string country, string state, string city)
        {
            try
            {
                int countryId, stateId, cityId;
                resmodel = new ApiResponseModel();
              //  string[] query = name.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
              //  name = string.Join(" ", query);
                List<NotebookForm> NotebookFormList = new List<NotebookForm>();
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(country))
                {
                    countryId = 0;
                }
                else
                {
                    countryId = Convert.ToInt32(country);
                }
                if (string.IsNullOrEmpty(state))
                {
                    stateId = 0;
                }
                else
                {
                    stateId = Convert.ToInt32(state);
                }
                if (string.IsNullOrEmpty(city))
                {
                    cityId = 0;
                }

                else
                {
                    cityId = Convert.ToInt32(city);
                }

                if (!string.IsNullOrEmpty(name))
                {
                    string[] query = name.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    name = string.Join(" ", query);
                    //StudentRegistration model = new StudentRegistration();



                    for (int i = 0; i <= query.Length - 1; i++)
                    {
                        commonBase.Text = query[i];
                        commonBase.CountryId = countryId;
                        commonBase.StateId = stateId;
                        commonBase.CityId = cityId;
                        var data = commonAction.SearchBooksByName(commonBase);
                        if (i == 0) dt = data.dtResult.Clone();
                        foreach (DataRow row in data.dtResult.Rows)
                        {
                            dt.Rows.Add(row.ItemArray);
                        }
                    }
                }
                else
                {
                    commonBase.Text = "";
                    commonBase.CountryId = countryId;
                    commonBase.StateId = stateId;
                    commonBase.CityId = cityId;
                    var data = commonAction.SearchBooksByName(commonBase);
                    dt = data.dtResult.Clone();
                    foreach (DataRow row in data.dtResult.Rows)
                    {
                        dt.Rows.Add(row.ItemArray);
                    }
                }
                RemoveDuplicateRows(dt, "Id");
                string jsonString = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    NotebookFormList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(dt);
                    jsonString = "{\"Status\":\"1\"}";
                    resmodel.IsError = false;
                    resmodel.IsSuccess = true;
                    resmodel.Message = "Successful";
                    resmodel.ResponseData = JsonConvert.SerializeObject(NotebookFormList);
                }
                else
                {
                    jsonString = "{\"Status\":\"-1\"}";
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

        #region       
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UploadPic()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                var postedFile = httpRequest.Files[0];
                string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + postedFile.FileName;             
                if (uploadedfilename.Contains(" "))
                {
                    uploadedfilename.Replace(" ", "_");
                }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/User/PageImages")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/User/PageImages"));
                    }
                    string Pic_Path = HttpContext.Current.Server.MapPath("~/Content/User/PageImages/" + uploadedfilename);
                    postedFile.SaveAs(Pic_Path);
                    docfiles.Add(Pic_Path);
                    result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return result;
        }
        #endregion  

        # region pageimageupload
        [System.Web.Http.HttpPost]
        public HttpResponseMessage pageimageupload(string filename,string PageType)
        {
         //   string filename = "Page_ScreenShot.png";
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;      
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                System.IO.Stream fs =  httpRequest.Files[0].InputStream; 
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                var bfile = "data:image/jpg;base64," + base64String;
                string converted = bfile.Replace('-', '+');
                converted = converted.Replace('_', '/');
                string json = string.Empty;
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                var file = filename.Split('.');

                string tempGuid = Guid.NewGuid().ToString().Substring(0, 5) + "_" + filename;

                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/User/PageImages")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/User/PageImages"));
                }
                string Pic_Path = HttpContext.Current.Server.MapPath("~/Content/User/PageImages/" + tempGuid);
                string pathreturn = Path.Combine(("/Content/User/PageImages/"), tempGuid);
                httpRequest.Files[0].SaveAs(Pic_Path);
                docfiles.Add(Pic_Path);
                if (PageType == "Image")
                {
                    result = Request.CreateResponse(HttpStatusCode.Created, Pic_Path);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.Created, pathreturn);
                }
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return result;
        }
        #endregion


        #region UploadAudioFile
        [HttpPost]
        public HttpResponseMessage UploadAudioFile()
        {
            HttpResponseMessage result = null;
            string[] jsonArr = new string[2];
            var docfiles = new List<string>();           
            var httpRequest = HttpContext.Current.Request;
            foreach (string file in httpRequest.Files)
            {
                var FileDataContent = httpRequest.Files[file];
                string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + FileDataContent.FileName;
                if (uploadedfilename != null)
                {
                    var stream = FileDataContent.InputStream;
                    var fileName = Path.GetFileName(uploadedfilename);
                    if (fileName.Contains(" "))
                    {
                        fileName.Replace(" ", "_");
                    }
                    DirectoryInfo dinfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Content/User/PageAudio"));
                    if (!dinfo.Exists)
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/User/PageAudio"));
                    }
                    string pathreturn = Path.Combine(("/Content/User/PageAudio/"), fileName);
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/User/PageAudio/"), fileName);
                    FileDataContent.SaveAs(path);
                    docfiles.Add(path);
                    result = Request.CreateResponse(HttpStatusCode.Created, pathreturn);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);

                }
            }
            return result;
        }
        #endregion

        #region UploadVideoFile
        [HttpPost]
        public HttpResponseMessage UploadVideoFile()
        {
            HttpResponseMessage result = null;
            string[] jsonArr = new string[2];
            var docfiles = new List<string>();
            var httpRequest = HttpContext.Current.Request;
            foreach (string file in httpRequest.Files)
            {
                var FileDataContent = httpRequest.Files[file];
                string uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + FileDataContent.FileName;
                if (uploadedfilename != null)
                {
                    var stream = FileDataContent.InputStream;
                    var fileName = Path.GetFileName(uploadedfilename);
                    if (fileName.Contains(" "))
                    {
                        fileName.Replace(" ", "_");
                    }
                    DirectoryInfo dinfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Content/User/PageVideo"));
                    if (!dinfo.Exists)
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/User/PageVideo"));
                    }
                    string pathreturn = Path.Combine(("/Content/User/PageVideo/"), fileName);
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/User/PageVideo/"), fileName);
                    FileDataContent.SaveAs(path);
                    docfiles.Add(path);
                    result = Request.CreateResponse(HttpStatusCode.Created, pathreturn);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);

                }
            }
            return result;
        }
        #endregion

    }


}
