//using PayPal.Api;
using CCA.Util;
using PayPal.Api;
using STU.ActionLayer.Advertisement;
using STU.ActionLayer.Book;
using STU.ActionLayer.Common;
using STU.ActionLayer.Questions;
using STU.ActionLayer.User;
using STU.BaseLayer.Advertisement;
using STU.BaseLayer.Book;
using STU.BaseLayer.Common;
using STU.BaseLayer.Questions;
using STU.BaseLayer.User;
using STU.Utility;
using StudentAppWebsite.Filters;
using StudentAppWebsite.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace StudentAppWebsite.Controllers
{
    [CheckLogin]
    public class UserController : Controller
    {
        //
        // GET: /User/
        HomeController home = new HomeController();
        CommonBase commonBase = new CommonBase();
        CommonAction commonAction = new CommonAction();
        UserAction userAction = new UserAction();
        UsersInfoBase usersInfoBase = new UsersInfoBase();
        CCA.Util.CCACrypto ccaCrypto = new CCA.Util.CCACrypto();
        STU.BaseLayer.ActionResult ActionResult = new STU.BaseLayer.ActionResult();
        QuestionsAction questionsAction = new QuestionsAction();

        string workingKey = "" + ConfigurationManager.AppSettings["WorkingKey"];
        string ccaRequest = "";
        public string strMerchantId = "" + ConfigurationManager.AppSettings["MerchantId"];
        public string strEncRequest = "";
        public string strAccessCode = "" + ConfigurationManager.AppSettings["access_code"];
        public string RedirectURL = "" + ConfigurationManager.AppSettings["RedirectURL"];
        public string CancelURL = "" + ConfigurationManager.AppSettings["CancelURL"];
        static string strSalt = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey"].ToString();

        static string key = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey1"].ToString();
        CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
        public ActionResult Index()
        {
            return View();
        }
        #region Encryption Extensions

        #region Encrypt
        public static string Encode(string TextToBeEncrypted)
        {
            // string strSalt = ConfigurationSettings.AppSettings["encryptionSalt"].ToString();

            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(strSalt.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(strSalt, Salt);

            //Creates a symmetric encryptor object.
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;

        }
        #endregion

        #region Decrypt
        public string Decode(string textToBeDecrypted)
        {
            textToBeDecrypted = Server.UrlDecode(textToBeDecrypted);
            //string strSalt = ConfigurationSettings.AppSettings["encryptionSalt"].ToString();
            textToBeDecrypted = textToBeDecrypted.Replace(" ", "+");
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] EncryptedData = Convert.FromBase64String(textToBeDecrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(strSalt.Length.ToString());
            //Making of the key for decryption
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(strSalt, Salt);
            //Creates a symmetric Rijndael decryptor object.
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            //Defines the cryptographics stream for decryption.THe stream contains decrpted data
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            byte[] PlainText = new byte[EncryptedData.Length];
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
            memoryStream.Close();
            cryptoStream.Close();
            //Converting to string
            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            return DecryptedData;
        }
        #endregion

        #endregion

        [HttpGet]
        public ActionResult Delete_NotebookForm(int BookId = 0)
        {
            try
            {
                if (BookId > 0)
                {
                    commonBase.Id = BookId;
                    commonBase.UserId = Convert.ToInt32(Session["UserId"]);
                    ActionResult = commonAction.NotebookDetails_Delete(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        return RedirectToAction("Home", "Home");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "You can't delete this book";
                        return RedirectToAction("NoteBookDetails", "Home", new { bookId = BookId });

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);

            }
            return View();

        }

        public NotebookForm SetControls(NotebookForm model)
        {
            try
            {
                List<Subjects> SubjectList = new List<Subjects>();
                List<Institute> InstituteList = new List<Institute>();
                List<Categories> CategoryList = new List<Categories>();
                List<SelectListItem> ExpMonthList = new List<SelectListItem>();
                ExpMonthList.Add(new SelectListItem { Text = "01", Value = "1" });
                ExpMonthList.Add(new SelectListItem { Text = "02", Value = "2" });
                ExpMonthList.Add(new SelectListItem { Text = "03", Value = "3" });
                ExpMonthList.Add(new SelectListItem { Text = "04", Value = "4" });
                ExpMonthList.Add(new SelectListItem { Text = "05", Value = "5" });
                ExpMonthList.Add(new SelectListItem { Text = "06", Value = "6" });
                ExpMonthList.Add(new SelectListItem { Text = "07", Value = "7" });
                ExpMonthList.Add(new SelectListItem { Text = "08", Value = "8" });
                ExpMonthList.Add(new SelectListItem { Text = "09", Value = "9" });
                ExpMonthList.Add(new SelectListItem { Text = "10", Value = "10" });
                ExpMonthList.Add(new SelectListItem { Text = "11", Value = "11" });
                ExpMonthList.Add(new SelectListItem { Text = "12", Value = "12" });
                ViewBag.ExpMonthList = ExpMonthList;

                List<SelectListItem> ExpYearList = new List<SelectListItem>();
                ExpYearList.Add(new SelectListItem { Text = "2016", Value = "2016" });
                ExpYearList.Add(new SelectListItem { Text = "2017", Value = "2017" });
                ExpYearList.Add(new SelectListItem { Text = "2018", Value = "2018" });
                ExpYearList.Add(new SelectListItem { Text = "2019", Value = "2019" });
                ExpYearList.Add(new SelectListItem { Text = "2020", Value = "2020" });
                ExpYearList.Add(new SelectListItem { Text = "2021", Value = "2021" });
                ExpYearList.Add(new SelectListItem { Text = "2022", Value = "2022" });
                ExpYearList.Add(new SelectListItem { Text = "2023", Value = "2023" });
                ExpYearList.Add(new SelectListItem { Text = "2024", Value = "2024" });
                ExpYearList.Add(new SelectListItem { Text = "2025", Value = "2025" });
                ExpYearList.Add(new SelectListItem { Text = "2026", Value = "2026" });
                ExpYearList.Add(new SelectListItem { Text = "2027", Value = "2027" });
                ExpYearList.Add(new SelectListItem { Text = "2028", Value = "2028" });
                ExpYearList.Add(new SelectListItem { Text = "2029", Value = "2029" });
                ExpYearList.Add(new SelectListItem { Text = "2030", Value = "2030" });
                ExpYearList.Add(new SelectListItem { Text = "2031", Value = "2031" });
                ExpYearList.Add(new SelectListItem { Text = "2032", Value = "2032" });
                ExpYearList.Add(new SelectListItem { Text = "2033", Value = "2033" });
                ExpYearList.Add(new SelectListItem { Text = "2034", Value = "2034" });
                ExpYearList.Add(new SelectListItem { Text = "2035", Value = "2035" });
                ExpYearList.Add(new SelectListItem { Text = "2036", Value = "2036" });

                ViewBag.ExpYearList = ExpYearList;

                List<StudentAppWebsite.Models.Stream> StreamList = new List<StudentAppWebsite.Models.Stream>();
                model.CategoryList = CategoryList;
                model.StreamList = StreamList;
                model.SubjectList = SubjectList;
                model.InstituteList = InstituteList;
                ActionResult = commonAction.Categories_LoadAll();
                if (ActionResult.IsSuccess)
                {
                    CategoryList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Categories>(ActionResult.dtResult);
                }

                if (CategoryList.Count > 0)
                {
                    model.CategoryList = CategoryList.Where(m => m.Status == true).ToList();

                    if (model.CategoryId != 0)
                    {
                        commonBase.Id = model.CategoryId;
                    }
                    else
                    {
                        commonBase.Id = model.CategoryList.Select(m => m.Id).FirstOrDefault();
                    }
                    ActionResult = commonAction.StreamsLoadByCategoryID(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        StreamList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<StudentAppWebsite.Models.Stream>(ActionResult.dtResult);
                    }
                    model.StreamList = StreamList.Where(m => m.Status == true).ToList();
                }

                if (model.StreamList.Count > 0)
                {
                    if (model.StreamId != 0)
                    {
                        commonBase.Id = model.StreamId;
                        commonBase.SteamId = model.StreamId;
                    }
                    else
                    {
                        commonBase.Id = model.StreamList.Select(m => m.Id).FirstOrDefault();
                        commonBase.SteamId = model.StreamList.Select(m => m.Id).FirstOrDefault();
                    }
                    ActionResult = commonAction.InstitutesLoadByStreamID(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        InstituteList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Institute>(ActionResult.dtResult);
                    }
                    model.InstituteList = InstituteList.Where(m => m.Status == true).ToList();


                    ActionResult = commonAction.SubjectLoadByStreamId(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        SubjectList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(ActionResult.dtResult);
                    }
                    model.SubjectList = SubjectList.Where(m => m.Status == true).ToList();
                }

                //if (model.InstituteList.Count > 0)
                //{
                //    if (model.StreamId != 0)
                //    {
                //        commonBase.SteamId = model.StreamId;
                //    }
                //    else
                //    {
                //        commonBase.SteamId = model.StreamList.Select(m => m.Id).FirstOrDefault();
                //    }

                //    ActionResult = commonAction.SubjectLoadByStreamId(commonBase);
                //    if (ActionResult.IsSuccess)
                //    {
                //        SubjectList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Subjects>(ActionResult.dtResult);
                //    }
                //    model.SubjectList = SubjectList.Where(m => m.Status == true).ToList();
                //}
            }
            catch { }
            return model;
        }

        [HttpGet]
        public ActionResult NotebookForm(int BookId = 0)
        {
            NotebookForm model = new NotebookForm();
            List<SelectListItem> lstStream = new List<SelectListItem>();
            try
            {
                CommonBase commonBase = new CommonBase();

                if (Convert.ToString(Session["UserId"]) != null)
                {
                    commonBase.UserId = Convert.ToInt32(Session["UserId"]);
                    commonBase.Id = BookId;
                    ActionResult = commonAction.NotebookLoadById(commonBase);
                    //if (ActionResult.IsSuccess)
                    //{

                    if (ActionResult.dsResult.Tables.Count > 1 && ActionResult.dsResult.Tables[1].Rows.Count > 0)
                    {
                        int MonetoryAdvantages = 0;
                        int.TryParse(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["MonetoryAdvantages"]), out MonetoryAdvantages);
                        int Visible_Hidden = 0;
                        int.TryParse(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Visible_Hidden"]), out Visible_Hidden);
                        int Innovation_Investment = 0;
                        int.TryParse(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Innovation_Investment"]), out Innovation_Investment);

                        model.BookId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"]) : "";

                        model.CollegeId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"]) : "";
                        model.SubjectId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"]) : "";
                        model.CreatedDate = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"]) : "";
                        model.BookId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"]) : "";
                        model.InstituteName = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"]) : "";
                        model.SubjectName = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"]) : "";
                        model.CreatedDate = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"]) : "";
                        model.MonetoryAdvantages = MonetoryAdvantages;
                        model.Visible_Hidden = Visible_Hidden;
                        model.Innovation_Investment = Innovation_Investment;

                    }
                    else
                    {
                        if (BookId > 0)
                        {
                            TempData["ErrorMessage"] = "You can't update this book";
                            return RedirectToAction("NotebookForm", "User");

                        }
                    }
                    //  }
                    //else
                    //{
                    //    if (BookId > 0)
                    //    {
                    //        TempData["ErrorMessage"] = "You can't update this book";
                    //        return RedirectToAction("NotebookForm", "User");

                    //    }
                    //}
                }

                model = SetControls(model);

            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
            }
            return View("NotebookForm", model);
        }

        public ActionResult NotebookFormx(NotebookForm model, int BookId = 0)
        {
            // NotebookForm model = new NotebookForm();
            try
            {
                CommonBase commonBase = new CommonBase();

                try
                {
                    if (Convert.ToString(Session["UserId"]) != null)
                    {
                        commonBase.UserId = Convert.ToInt32(Session["UserId"]);
                        commonBase.Id = BookId;
                        ActionResult = commonAction.NotebookLoadById(commonBase);
                        if (ActionResult.IsSuccess)
                        {
                            if (ActionResult.dsResult.Tables.Count > 0)
                            {
                                try
                                {
                                    if (ActionResult.dsResult.Tables[0].Rows.Count > 0)
                                    {
                                        model.CardNumber = !String.IsNullOrEmpty(ActionResult.dsResult.Tables[0].Rows[0]["ATMNumber"].ToString()) ? Decode(Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0]["ATMNumber"])) : "";
                                        model.CVV = !String.IsNullOrEmpty(ActionResult.dsResult.Tables[0].Rows[0]["CVV"].ToString()) ? Decode(Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0]["CVV"].ToString())) : "";
                                    }
                                }
                                catch
                                {
                                    model.CardNumber = "";
                                    model.CVV = "";
                                }
                                if (ActionResult.dsResult.Tables[0].Rows.Count > 0)
                                {
                                    model.CardHolderName = ActionResult.dsResult.Tables[0].Rows[0]["NameOnATMCard"] != DBNull.Value ? Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0]["NameOnATMCard"]) : "";

                                    if ((ActionResult.dsResult.Tables[0].Rows[0]["ExpiryMonth"]) != DBNull.Value)
                                    {
                                        // model.ExpirationDate = Convert.ToDateTime(ActionResult.dtResult.Rows[0]["ExpirationDate"]);
                                        model.ExpiryMonth = Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0]["ExpiryMonth"]);
                                    }
                                    if ((ActionResult.dsResult.Tables[0].Rows[0]["ExpiryYear"]) != DBNull.Value)
                                    {
                                        // model.ExpirationDate = Convert.ToDateTime(ActionResult.dtResult.Rows[0]["ExpirationDate"]);
                                        model.ExpiryYear = Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0]["ExpiryYear"]);
                                    }
                                }
                            }
                            int CategoryId = 0;
                            int StreamId = 0;
                            if (ActionResult.dsResult.Tables.Count > 1 && ActionResult.dsResult.Tables[1].Rows.Count > 0)
                            {
                                int.TryParse(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CategoryName"]), out CategoryId);
                                int.TryParse(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["StreamId"]), out StreamId);
                                int MonetoryAdvantages = 0;
                                int.TryParse(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["MonetoryAdvantages"]), out MonetoryAdvantages);

                                model.BookId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"]) : "";
                                model.CategoryId = CategoryId;
                                model.StreamId = StreamId;
                                model.CollegeId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"]) : "";
                                model.SubjectId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"]) : "";
                                model.CreatedDate = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"]) : "";
                                model.BookId = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["Id"]) : "";

                                model.CategoryName = CategoryId.ToString();
                                model.StreamName = StreamId.ToString();
                                model.InstituteName = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CollegeId"]) : "";
                                model.SubjectName = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["SubjectId"]) : "";
                                model.CreatedDate = !String.IsNullOrEmpty(Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"])) ? Convert.ToString(ActionResult.dsResult.Tables[1].Rows[0]["CreatedDate"]) : "";
                                model.MonetoryAdvantages = MonetoryAdvantages;

                            }
                            else
                            {
                                int.TryParse(model.CategoryName, out CategoryId);
                                if (CategoryId > 0)
                                    model.CategoryId = CategoryId;

                                int.TryParse(model.StreamName, out StreamId);
                                if (StreamId > 0)
                                    model.StreamId = StreamId;

                                if (!String.IsNullOrEmpty(model.SubjectName))
                                    model.SubjectId = model.SubjectName;

                                if (BookId > 0)
                                {
                                    TempData["ErrorMessage"] = "You can't update this book";
                                    return RedirectToAction("NotebookForm", "User");

                                }
                            }
                        }
                        else
                        {
                            if (BookId > 0)
                            {
                                TempData["ErrorMessage"] = "You can't update this book";
                                return RedirectToAction("NotebookForm", "User");

                            }
                        }
                    }

                }
                catch { }

                model = SetControls(model);





            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
            }

            return View("NotebookForm", model);
        }


        public ActionResult NotebookForm(NotebookForm model, FormCollection fc)
        {
            int bookId = 0;
            try
            {
                //commonBase.ChapterId = (!string.IsNullOrEmpty(model.ChapterName) ? model.ChapterName.Split(',')[0] : "");
                //  commonBase.SteamId = model.StreamId;
                //  commonBase.ChapterId = "";
                //    commonBase.ChapterName = "";
                commonBase.SubjectName = model.SubjectName == "other" ? Convert.ToString(fc["Sub_other"]) : model.SubjectName;
                // commonBase.TeacherName = string.Empty;
                // commonBase.StreamName = model.StreamName == "other" ? Convert.ToString(fc["Strm_other"]) : model.StreamName;
                //commonBase.CategoryName = model.CategoryName == "other" ? Convert.ToString(fc["Cat_other"]) : model.CategoryName;
                //  commonBase.Type = string.Empty;
                //  commonBase.InstituteName = model.InstituteName == "other" ? Convert.ToString(fc["Ins_other"]) : model.InstituteName;
                commonBase.MonetoryAdvantages = Convert.ToInt32(fc["monetaryAdvantages"]);
                commonBase.Innovation_Investment = Convert.ToInt32(fc["Innovation_Investment"]);
                commonBase.Visible_Hidden = Convert.ToInt32(fc["Visible_Hidden"]);
                model.MonetoryAdvantages = commonBase.MonetoryAdvantages;
                model.Innovation_Investment = commonBase.Innovation_Investment;
                model.Visible_Hidden = commonBase.Visible_Hidden;
                try
                {
                    var data = Request.Form["CreatedDate"];
                    DateTime dt = DateTime.ParseExact(Request.Form["CreatedDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    commonBase.StartDate = dt;
                }
                catch (Exception ex)
                {
                    ErrorReporting.WebApplicationError(ex);
                }
                //  commonBase.CardHolderName = (Convert.ToString(model.CardHolderName) != null && Convert.ToString(model.CardHolderName) != "") ? model.CardHolderName.ToString() : "";
                //  commonBase.CVV = !String.IsNullOrEmpty(Convert.ToString(model.CVV)) ? Encode(Convert.ToString(model.CVV)) : "";
                //  commonBase.CardNumber = !String.IsNullOrEmpty(Convert.ToString(model.CardNumber)) ? Encode(Convert.ToString(model.CardNumber)) : "";
                //  commonBase.ExpirationDate = (model.ExpirationDate != null ? Convert.ToDateTime(model.ExpirationDate) : model.ExpirationDate);
                //  commonBase.ExpiryMonth = model.ExpiryMonth;
                //  commonBase.ExpiryYear = model.ExpiryYear;

                commonBase.UserId = Convert.ToInt32(Session["UserId"]);
                if (model.SubjectName == null)
                {
                    commonBase.SteamId = 53;
                    commonBase.SubjectName = Convert.ToString(fc["subnametxt"]);
                    ActionResult = commonAction.Subject_InsertUpdate(commonBase);
                    string idid = Convert.ToString(ActionResult.dtResult.Rows[0].ItemArray[0]);
                    commonBase.SubjectName = idid;

                }

                //if (model.CategoryName == "other" || model.StreamName == "other" || model.SubjectName == "other" || model.InstituteName == "other")
                //{
                //    usersInfoBase.CategoryName = Convert.ToString(fc["Cat_other"]);
                //    usersInfoBase.InstituteName = Convert.ToString(fc["Ins_other"]);
                //    usersInfoBase.StreamName = Convert.ToString(fc["Strm_other"]);
                //    usersInfoBase.SubjectName = Convert.ToString(fc["Sub_other"]);
                //    usersInfoBase.CategoryId = model.CategoryName == "other" ? 0 : Convert.ToInt32(model.CategoryName);
                //    usersInfoBase.StreamId = model.StreamName == "other" ? 0 : Convert.ToInt32(model.StreamName);
                //    usersInfoBase.CollegeId = model.InstituteName == "other" ? 0 : Convert.ToInt32(model.InstituteName);
                //    usersInfoBase.SubjectId = model.SubjectName == "other" ? 0 : Convert.ToInt32(model.SubjectName);


                //    ActionResult = userAction.New_Sub_Col_Cat_Strm_Insert(usersInfoBase);
                //    if (ActionResult.IsSuccess)
                //    {
                //        string duplicate = "";

                //        if (model.CategoryName == "other" && Convert.ToInt32(ActionResult.dsResult.Tables[0].Rows[0][0]) < 0)
                //            duplicate += "Category";
                //        if (model.StreamName == "other" && Convert.ToInt32(ActionResult.dsResult.Tables[0].Rows[0][1]) < 0)
                //            duplicate += " Stream";
                //        if (model.InstituteName == "other" && Convert.ToInt32(ActionResult.dsResult.Tables[0].Rows[0][2]) < 0)
                //            duplicate += " Institute";
                //        if (model.SubjectName == "other" && Convert.ToInt32(ActionResult.dsResult.Tables[0].Rows[0][3]) < 0)
                //            duplicate += " Subject";
                //        if (duplicate == "")
                //        {
                //            commonBase.CategoryName = Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0][0]);
                //            commonBase.StreamName = Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0][1]);
                //            commonBase.InstituteName = Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0][2]);
                //            commonBase.SubjectName = Convert.ToString(ActionResult.dsResult.Tables[0].Rows[0][3]);

                //            model.CategoryName = commonBase.CategoryName;
                //            model.StreamName = commonBase.StreamName;
                //            model.InstituteName = commonBase.InstituteName;
                //            model.SubjectName = commonBase.SubjectName;
                //        }
                //        else
                //        {
                //            TempData["ErrorMessage"] = "Duplicate entry for " + duplicate;
                //            return RedirectToAction("NotebookForm");
                //        }


                //    }
                //}

                int.TryParse(model.BookId, out bookId);
                if (bookId > 0)
                {
                    commonBase.Id = bookId;
                    ActionResult = commonAction.NotebookDetails_Update(commonBase);
                }
                else
                {
                    ActionResult = commonAction.NotebookDetails_Insert(commonBase);
                }
                if (ActionResult.IsSuccess)
                {
                    bookId = Convert.ToInt32(ActionResult.dtResult.Rows[0][0]);
                    //ActionResult = commonAction.UpdateUsersInfoByUserId(commonBase);
                    //if (ActionResult.IsSuccess)
                    //{
                    TempData["SuccessMessage"] = "Notebook Added SuccessFully";

                    //}
                    //else
                    //{
                    //    TempData["ErrorMessage"] = "Error in saving Notebook";
                    //    return RedirectToAction("NotebookForm");
                    //}
                }

                else
                {
                    TempData["ErrorMessage"] = "Error in saving Notebook";
                    return RedirectToAction("NotebookFormx", model);
                }
            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
                return RedirectToAction("NotebookForm");
            }
            if (!string.IsNullOrEmpty(model.BookId))
            {
                //In Update mode
                TempData["ErrorMessage"] = null;
                TempData["SuccessMessage"] = null;
                return RedirectToAction("NoteBookDetails", "Home", new { bookId = bookId });


            }
            else
                return RedirectToAction("AddNotebook", new { bookId = bookId });

        }


        #region UserProfile Get
        public ActionResult UserProfile(int? Id = 0, int FriendRequestId = 0, string pageId = "0", string tab = "profile")
        {
            ManageProfile model = new ManageProfile();
            Profile profileModel = new Profile();
            List<Profile> lstprofileModel = new List<Profile>();
            List<NotebookForm> lstNotebookModel = new List<NotebookForm>();
            List<Friend> FriendList = new List<Friend>();
            List<Friend> FriendRequests = new List<Friend>();
            commonBase.Id = Convert.ToInt32(Id) == 0 ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(Id);
            ActionResult = commonAction.UserInfo_LoadById(commonBase);
            if (ActionResult.IsSuccess)
            {
                lstprofileModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Profile>(ActionResult.dtResult);
                if (lstprofileModel.Count > 0)
                    profileModel = lstprofileModel.FirstOrDefault();
                profileModel.DOB = Convert.ToDateTime(profileModel.DOB, CultureInfo.CurrentUICulture).ToString("dd/MM/yyyy");
            }
            model.profile = profileModel;
            BookBase bookBase = new BookBase();
            bookBase.UserId = Convert.ToInt32(Id) == 0 ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(Id);
            BookAction bookAction = new BookAction();
            ActionResult = bookAction.Books_LoadBy_UserId(bookBase);
            if (ActionResult.IsSuccess)
            {
                lstNotebookModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(ActionResult.dtResult);
            }

            ViewBag.Tab = Convert.ToString(tab);
            ViewBag.Id = Convert.ToInt32(Id);
            ViewBag.PageId = (pageId).ToString();
            ViewBag.FriendRequestId = Convert.ToInt32(FriendRequestId);
            model.lstNotebooks = lstNotebookModel.OrderByDescending(m => m.Id).ToList();
            return View("Profile", model);
        }
        #endregion


        public ActionResult Update_UserProfile()
        {
            ManageProfile model = new ManageProfile();
            Profile profileModel = new Profile();
            List<Profile> lstprofileModel = new List<Profile>();
            List<NotebookForm> lstNotebookModel = new List<NotebookForm>();
            var country = CountryLoad();
            model.Countrylist = country;
            commonBase.Id = Convert.ToInt32(Session["UserId"]);
            ViewBag.UserId = commonBase.Id;
            ActionResult = commonAction.UserInfo_LoadById(commonBase);
            if (ActionResult.IsSuccess)
            {
                lstprofileModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Profile>(ActionResult.dtResult);
                if (lstprofileModel.Count > 0)
                    profileModel = lstprofileModel.FirstOrDefault();

            }
            model.profile = profileModel;
            model.statelist = StateLoad(profileModel.CountryId);
            model.citylist = CityLoad(profileModel.StateId);
            commonBase.CityId = model.profile.CityId;
            ActionResult = commonAction.Institutes_LoadByCityId(commonBase);
            model.InstituteModellist = new List<InstituteModel>();
            if (ActionResult.IsSuccess)
            {
                model.InstituteModellist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InstituteModel>(ActionResult.dtResult);

            }

            return View(model);
        }

        #region Update_UserProfile Post
        [HttpPost]
        public ActionResult Update_UserProfile(ManageProfile model)
        {
            string site = System.Configuration.ConfigurationManager.AppSettings["site"];
            userAction = new UserAction();
            usersInfoBase = new UsersInfoBase();
            usersInfoBase.StudentName = (model.profile.StudentName != null && model.profile.StudentName != "") ? model.profile.StudentName : "";
            usersInfoBase.LastName = model.profile.LastName;
            usersInfoBase.FirstName = model.profile.FirstName;

            usersInfoBase.ProfileImage = model.profile.ProfileImage;
            usersInfoBase.CoverImage = model.profile.CoverImage;
            usersInfoBase.CityId = model.profile.CityId;
            usersInfoBase.StateId = model.profile.StateId;
            usersInfoBase.CountryId = model.profile.CountryId;
            usersInfoBase.MobileNumber = model.profile.MobileNumber;
            usersInfoBase.Id = model.profile.Id;
            usersInfoBase.IsActive = true;

            usersInfoBase.CollegeId = model.profile.CollegeId;
            usersInfoBase.DOB = Convert.ToDateTime(model.profile.DOB, CultureInfo.CurrentUICulture).ToString();

            usersInfoBase.Gender = model.profile.Gender;

            ActionResult = userAction.UsersInfo_InsertUpdate(usersInfoBase);
            if (ActionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Profile updated successfully.";
                Session["ProfileImage"] = model.profile.ProfileImage;
            }
            else
                TempData["ErrorMessage"] = "Some error occured during updating your profile.";

            return RedirectToAction("Update_UserProfile");
        }
        #endregion

        public ActionResult Update_ProfilePic(string Position = null, string datastring = null, string filename = null)
        {
            string json = string.Empty;
            try
            {

                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                var file = filename.Split('.');

                string tempGuid = Guid.NewGuid().ToString().Substring(0, 5) + "_" + filename;


                if (!Directory.Exists(HttpContext.Server.MapPath("~/Content/Uploads/Users/")))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Uploads/Users/"));
                }
                string Pic_Path = HttpContext.Server.MapPath("~/Content/Uploads/Users/" + tempGuid);
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(datastring);
                        bw.Write(data);
                        bw.Close();
                    }
                    filename = tempGuid + "_" + file[0] + "." + file[1];
                    //json = site + "/Content/Uploads/Users/" + tempGuid;
                    json = "/Content/Uploads/Users/" + tempGuid;

                }

                userAction = new UserAction();
                usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = Convert.ToInt32(Session["UserId"]);
                usersInfoBase.CoverImage = json;
                usersInfoBase.Position = Position;
                ActionResult = userAction.USP_U_UsersCoverPic(usersInfoBase);

                if (ActionResult.IsSuccess)
                {
                    //TempData["SuccessMessage"] = "Profile updated successfully.";
                }
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("UserProfile");
        }

        public ActionResult Update_Picture(FormCollection fc)
        {
            string json = string.Empty;
            try
            {
                var filename = fc["avatar_data"].ToString();
                var datastring = fc["avatar_src"].ToString();
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                var file = filename.Split('.');

                string tempGuid = Guid.NewGuid().ToString().Substring(0, 5) + "_" + filename;


                if (!Directory.Exists(HttpContext.Server.MapPath("~/Content/Uploads/Users/")))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Uploads/Users/"));
                }
                string Pic_Path = HttpContext.Server.MapPath("~/Content/Uploads/Users/" + tempGuid);
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(datastring);
                        bw.Write(data);
                        bw.Close();
                    }
                    filename = tempGuid + "_" + file[0] + "." + file[1];
                    //json = site + "/Content/Uploads/Users/" + tempGuid;
                    json = "/Content/Uploads/Users/" + tempGuid;

                }

                userAction = new UserAction();
                usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = Convert.ToInt32(Session["UserId"]);
                usersInfoBase.ProfileImage = json;

                ActionResult = userAction.USP_U_UsersProfilePic(usersInfoBase);

                if (ActionResult.IsSuccess)
                {
                    Session["ProfileImage"] = json;
                    // TempData["SuccessMessage"] = "Profile Image updated successfully.";
                }
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("UserProfile");
        }


        public bool Remove_ProfilePic()
        {
            bool status = false;

            try
            {
                userAction = new UserAction();
                usersInfoBase = new UsersInfoBase();
                usersInfoBase.Id = Convert.ToInt32(Session["UserId"]);
                ActionResult = userAction.USP_Remove_UsersProfilePic(usersInfoBase);

                if (ActionResult.IsSuccess)
                {
                    status = true;

                }

            }
            catch (Exception ex)
            {


            }


            return status;
        }





        public List<Country> CountryLoad()
        {

            List<Country> Countrylist = new List<Country>();
            ActionResult = commonAction.Countries_LoadAll();
            if (ActionResult.IsSuccess)
            {
                Countrylist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Country>(ActionResult.dtResult);

            }
            return Countrylist;
        }

        public List<State> StateLoad(int country)
        {

            List<State> Statelist = new List<State>();
            commonBase.CountryId = country;
            ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
            if (ActionResult.IsSuccess)
            {
                Statelist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);

            }
            return Statelist;
        }


        public List<City> CityLoad(int state)
        {

            List<City> Citylist = new List<City>();
            commonBase.StateId = state;
            ActionResult = commonAction.Cities_LoadBy_StateId(commonBase);
            if (ActionResult.IsSuccess)
            {
                Citylist = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dtResult);
            }
            return Citylist;
        }


        public ActionResult AddNotebook(int bookId = 0, int pageId = 0)
        {
            NotebookForm model = new NotebookForm();
            BookBase bookBase = new BookBase();
            BookAction bookAction = new BookAction();
            List<NotebookForm> lstNotebook = new List<NotebookForm>();
            List<string> ChaptersList = new List<string>();
            string subjectName = "";
            string pageNumber = "";
            ViewBag.PageId = pageId;
            try
            {
                STU.ActionLayer.Common.CommonAction commonAction = new STU.ActionLayer.Common.CommonAction();
                STU.BaseLayer.Common.CommonBase commonBase = new STU.BaseLayer.Common.CommonBase();
                bookBase.PageNumber = pageId;
                commonBase.NotebookId = bookId;
                ActionResult = commonAction.Notesbook_Load_ById(commonBase);
                if (ActionResult.IsSuccess)
                {
                    pageNumber = Convert.ToString(ActionResult.dtResult.Rows[0]["LastPage"]);
                    subjectName = Convert.ToString(ActionResult.dtResult.Rows[0]["SubjectName"]);
                }
                ActionResult = bookAction.GetPageContent_ByPageId(bookBase);
                if (ActionResult.IsSuccess)
                {
                    lstNotebook = AccountingSoftware.Helpers.CommonMethods.ConvertTo<NotebookForm>(ActionResult.dtResult);
                    model.PageNumber = lstNotebook[0].PageNumber;
                }
                ViewBag.BookUserId = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0].UserId : 0);
                model = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0] : model);
                model.NotebookId = bookId.ToString();
                if (lstNotebook == null || lstNotebook.Count == 0)
                {
                    model.PageNumber = (!string.IsNullOrEmpty(pageNumber) ? Convert.ToInt32(pageNumber) : 0);
                }
                model.SubjectName = subjectName;
                if (lstNotebook == null || lstNotebook.Count == 0)
                {
                    model.IsHtml = false;
                }

                model.PageType = (lstNotebook != null && lstNotebook.Count > 0 ? lstNotebook[0].PageType : "Image");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            model.chaptersList = ChaptersList;
            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNotebook(NotebookForm model, FormCollection fc)
        {
            int bookId = 0; string subjectName = string.Empty;
            try
            {
                BookBase bookBase = new BookBase();
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                BookAction bookAction = new BookAction();
                bookBase.ChapterName = model.ChapterName;
                bookBase.ScreenShot = (Convert.ToString(fc["ScreenShot"]) != null && Convert.ToString(fc["ScreenShot"]) != "") ? Convert.ToString(fc["ScreenShot"]) : "";
                bookBase.IsHtml = (Convert.ToString(fc["hdnPageType"]) == "Test") ? true : false;
                subjectName = Convert.ToString(fc["hdnSubjectName"]);
                bookBase.PageType = Convert.ToString(fc["hdnPageType"]);

                if (bookBase.PageType == "Image")
                {
                    bookBase.Content = Convert.ToString(fc["ImageSrc"]);
                }
                else if (bookBase.PageType == "Audio")
                {

                    bookBase.Content = Convert.ToString(fc["AudioSrc"]);
                }
                else if (bookBase.PageType == "Video")
                {
                    bookBase.Content = Convert.ToString(fc["VideoSrc"]);
                }
                else if (bookBase.PageType == "Audio")
                {
                    bookBase.Content = Convert.ToString(fc["AudioSrc"]);
                }
                else
                {
                    bookBase.Content = model.Content;
                }

                bookBase.Id = model.Id;
                bookBase.BookId = Convert.ToInt64(model.NotebookId);
                bookBase.PageNumber = model.PageNumber;
                //bookBase.IsHtml = true;
                if (!string.IsNullOrEmpty(bookBase.Content))
                {
                    ActionResult = bookAction.BooksContent_InsertUpdate(bookBase);
                }
                if (ActionResult.IsSuccess)
                {
                    if (model.Id > 0)
                    {
                        TempData["SuccessMessage"] = "Page updated successfully";
                        return RedirectToAction("Index", "Home", new { pageId = model.Id, BookId = model.NotebookId });
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Added page saved successfully";
                    }
                }
                else
                {
                    if (model.Id > 0)
                    {
                        return RedirectToAction("Index", "Home", new { pageId = model.Id, BookId = model.NotebookId });
                    }
                }
            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
                //TempData["ErrorMessage"] = "Error in saving Record.Please try again";
                if (model.Id > 0)
                {

                    return RedirectToAction("Index", "Home", new { pageId = model.Id });
                }

            }
           // if (ActionResult.IsSuccess && ActionResult.dsResult != null)
          //  {
                model.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0][0].ToString());
                if (ActionResult.IsSuccess)
                {
                    DataTable freindDataTable = new DataTable();
                    commonBase.Id = Convert.ToInt32(Session["UserId"]);
                    ActionResult = commonAction.FriendList_LoadByUserId(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        Task.Run(() => AdBulkSmsSend_ForNewNoteBook(ActionResult.dtResult, subjectName));
                    }
                }
           // }
          
            //return RedirectToAction("AddNotebook", "User", new { bookId = model.NotebookId, pageId = model.Id });
            return RedirectToAction("AddNotebook", "User", new { bookId = model.NotebookId, pageId = 0 });
            //return RedirectToAction("AddNotebook", new { bookId = model.NotebookId });
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UpdateNotebookText(NotebookForm model, FormCollection fc)
        {
            int bookId = 0; string subjectName = string.Empty;
            int pageId = 0;
            try
            {
                BookBase bookBase = new BookBase();
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                BookAction bookAction = new BookAction();
                bookBase.ChapterName = model.ChapterName;
                bookBase.ScreenShot = (Convert.ToString(fc["ScreenShot"]) != null && Convert.ToString(fc["ScreenShot"]) != "") ? Convert.ToString(fc["ScreenShot"]) : "";
                bookBase.IsHtml = (Convert.ToString(fc["hdnPageType"]) == "Test") ? true : false;
                subjectName = Convert.ToString(fc["hdnSubjectName"]);
                bookBase.PageType = Convert.ToString(fc["hdnPageType"]);

                if (bookBase.PageType == "Image")
                {
                    bookBase.Content = Convert.ToString(fc["ImageSrc"]);
                }
                else if (bookBase.PageType == "Audio")
                {

                    bookBase.Content = Convert.ToString(fc["AudioSrc"]);
                }
                else if (bookBase.PageType == "Video")
                {
                    bookBase.Content = Convert.ToString(fc["VideoSrc"]);
                }
                else if (bookBase.PageType == "Audio")
                {
                    bookBase.Content = Convert.ToString(fc["AudioSrc"]);
                }
                else
                {
                    bookBase.Content = model.Content;
                }

                bookBase.Id = model.Id;
                bookBase.BookId = Convert.ToInt64(model.NotebookId);
                bookBase.PageNumber = model.PageNumber;
                if (!string.IsNullOrEmpty(bookBase.Content))
                {
                    ActionResult = bookAction.BooksContent_InsertUpdate(bookBase);
                    pageId = Convert.ToInt32(ActionResult.dtResult.Rows[0][0]);
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            model.Id = pageId;
            if (ActionResult.IsSuccess)
            {
                DataTable freindDataTable = new DataTable();
                commonBase.Id = Convert.ToInt32(Session["UserId"]);
                ActionResult = commonAction.FriendList_LoadByUserId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    Task.Run(() => AdBulkSmsSend_ForNewNoteBook(ActionResult.dtResult, subjectName));

                }
            }
            return Json(pageId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UploadPic(string imageData, string filename)
        {
            string json = string.Empty;
            string site = System.Configuration.ConfigurationManager.AppSettings["site"];
            var file = filename.Split('.');

            string tempGuid = Guid.NewGuid().ToString().Substring(0, 5) + "_" + filename;

            if (!Directory.Exists(HttpContext.Server.MapPath("~/Content/User/PageImages")))
            {
                Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/User/PageImages"));
            }
            string Pic_Path = HttpContext.Server.MapPath("~/Content/User/PageImages/" + tempGuid);
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
                filename = tempGuid; //  + "_" + file[0] + "." + file[1];
                json = "/Content/User/PageImages/" + tempGuid;
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult CheckPageExistence(int bookId, int pageNo, string ChapterName)
        {
            string result = string.Empty;
            try
            {
                BookBase bookBase = new BookBase();
                BookAction bookAction = new BookAction();
                bookBase.ChapterName = ChapterName;
                bookBase.BookId = Convert.ToInt64(bookId);
                bookBase.PageNumber = pageNo;


                ActionResult = bookAction.CheckPageExistence(bookBase);

                if (ActionResult.IsSuccess)
                {
                    result = "{\"status\":\"" + ActionResult.dtResult.Rows[0][0] + "\"}";
                }
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return Json(result);
        }


        public ActionResult Friendlist(int? Id = 0, int FriendRequestId = 0, string pageId = "0", string studentname = null)
        {
            ManageProfile model = new ManageProfile();
            Profile profileModel = new Profile();
            List<Profile> lstprofileModel = new List<Profile>();
            List<NotebookForm> lstNotebookModel = new List<NotebookForm>();
            List<Friend> FriendList = new List<Friend>();
            List<Friend> FriendRequests = new List<Friend>();
            commonBase.Id = Convert.ToInt32(Id) == 0 ? Convert.ToInt32(Session["UserId"]) : Convert.ToInt32(Id);
            ActionResult = commonAction.FriendList_LoadByUserId(commonBase);
            if (ActionResult.IsSuccess)
            {
                FriendList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(ActionResult.dtResult);
            }
            model.lstFriends = FriendList;
            commonBase.Id = Convert.ToInt32(Session["UserId"]);
            ActionResult = commonAction.FriendRequest_LoadByUserId(commonBase);
            if (ActionResult.IsSuccess)
            {
                FriendRequests = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(ActionResult.dtResult);
            }
            model.FriendRequests = FriendRequests;
            ViewBag.Id = Convert.ToInt32(Id);
            ViewBag.PageId = (pageId).ToString();
            ViewBag.FriendRequestId = Convert.ToInt32(FriendRequestId);
            model.profile = profileModel;
            model.profile.StudentName = studentname;
            return PartialView(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateNotebook(NotebookForm model)
        {
            int bookId = 0;
            try
            {
                BookBase bookBase = new BookBase();
                BookAction bookAction = new BookAction();
                bookBase.ChapterName = model.ChapterName;
                bookBase.Content = model.PageImage;
                bookBase.Id = 0;
                bookBase.BookId = Convert.ToInt32(model.BookId);
                bookBase.PageNumber = model.PageNumber;


                ActionResult = bookAction.BooksContent_InsertUpdate(bookBase);

                if (ActionResult.IsSuccess)
                {

                    TempData["SuccessMessage"] = "Record saved successfully";

                }

                else
                {
                    TempData["ErrorMessage"] = "Error in saving Record.Please try again";
                    return RedirectToAction("Index", "Home", new { bookId = model.BookId, pageId = model.Id });
                }
            }
            catch (Exception ex)
            {

                ErrorReporting.WebApplicationError(ex);
                TempData["ErrorMessage"] = "Error in saving Record.Please try again";
                return RedirectToAction("Index", "Home", new { bookId = model.BookId, pageId = model.Id });
            }
            return RedirectToAction("Index", "Home", new { bookId = model.BookId, pageId = model.Id });
        }

        #region InvitationList
        [HttpGet]
        public ActionResult InvitationList()
        {
            List<InvitationModel> lstInvitationModel = new List<InvitationModel>();
            CommonBase commonBase = new CommonBase();
            commonBase.UserId = Convert.ToInt32(Session["UserId"]);
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = commonAction.NotificationsCount(commonBase);
            if (ActionResult.IsSuccess)
            {
                lstInvitationModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InvitationModel>(ActionResult.dsResult.Tables[0]);
            }
            return View(lstInvitationModel);
        }
        #endregion

        #region NotificationList
        [HttpGet]
        public ActionResult NotificationList()
        {
            List<InvitationModel> lstInvitationModel = new List<InvitationModel>();
            CommonBase commonBase = new CommonBase();
            commonBase.UserId = Convert.ToInt32(Session["UserId"]);
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = commonAction.NotificationsCount(commonBase);
            if (ActionResult.IsSuccess)
            {
                lstInvitationModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InvitationModel>(ActionResult.dsResult.Tables[1]);
            }
            return View(lstInvitationModel);
        }
        #endregion

        #region NotificationList_Android
        [HttpGet]
        public ActionResult NotificationList_Android()
        {
            List<InvitationModel> lstInvitationModel = new List<InvitationModel>();
            CommonBase commonBase = new CommonBase();
            commonBase.UserId = Convert.ToInt32(Session["UserId"]);
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = commonAction.NotificationsCount(commonBase);
            if (ActionResult.IsSuccess)
            {
                lstInvitationModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InvitationModel>(ActionResult.dsResult.Tables[1]);
            }
            return View(lstInvitationModel);
        }
        #endregion


        #region Invitation_FriendRequest_Notification_List_IsRead_Update
        [HttpPost]
        public JsonResult Invitation_FriendRequest_Notification_List_IsRead_Update(string XML, string Type)
        {

            string json = string.Empty;
            CommonBase commonBase = new CommonBase();
            commonBase.UserId = Convert.ToInt32(Session["UserId"]);
            commonBase.Type = Type;
            userAction = new UserAction();
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = userAction.Invitation_FriendRequest_Notification_List_IsRead_Update(commonBase);
            json = "{\"Status\":\"1\"}";
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region InvitationList_UpdateStatus
        [HttpPost]
        public JsonResult InvitationList_UpdateStatus(int Id, int status, int type)
        {

            string json = string.Empty;
            UsersInfoBase usersInfoBase = new UsersInfoBase();
            usersInfoBase.Id = Id;
            usersInfoBase.TopicId = type;
            usersInfoBase.RequestStatus = status;
            userAction = new UserAction();
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = userAction.InvitationList_UpdateStatus(usersInfoBase);
            if (ActionResult.IsSuccess)
                json = "{\"Status\":\"1\"}";
            else
                json = "{\"Status\":\"-1\"}";
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region InvitationList_InsertUpdate
        [HttpPost]
        public JsonResult InvitationList_InsertUpdate(int InvitedUserId, int pageId)
        {

            string json = string.Empty;
            UsersInfoBase usersInfoBase = new UsersInfoBase();
            usersInfoBase.Id = Convert.ToInt32(Session["UserId"]);
            usersInfoBase.InvitedUserId = InvitedUserId;
            usersInfoBase.TopicId = pageId;
            userAction = new UserAction();
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = userAction.InvitationList_InsertUpdate(usersInfoBase);
            if (ActionResult.IsSuccess)
            {
                json = "{\"Status\":\"1\"}";
                try
                {
                    QuestionsBase questionBase = new QuestionsBase();
                    questionBase.PageId = pageId;
                    ActionResult = questionsAction.SendNotification(questionBase);
                    if (ActionResult.IsSuccess)
                    {
                        var SubmitterList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Submitter>(ActionResult.dtResult);
                        if (SubmitterList != null && SubmitterList.Count > 0 && !string.IsNullOrEmpty(SubmitterList[0].RegistrationToken))
                        {

                            String Message = Session["StudentName"].ToString() + " invites you for the discussion over " + SubmitterList[0].BookName + " created by " + SubmitterList[0].BookSubmitter;
                            HomeController.SendPushNotification(SubmitterList[0].RegistrationToken, Message, "3");
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
                json = "{\"Status\":\"-1\"}";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region RemoveFriend
        [HttpPost]
        public JsonResult RemoveFriend(int ID)
        {
            string json = string.Empty;
            UsersInfoBase usersInfoBase = new UsersInfoBase();
            usersInfoBase.Id = ID;
            userAction = new UserAction();
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = userAction.RemoveFriend(usersInfoBase);
            if (ActionResult.IsSuccess)
                json = "{\"Status\":\"1\"}";
            else
                json = "{\"Status\":\"-1\"}";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FriendRequestList
        [HttpGet]
        public ActionResult FriendRequestList()
        {
            List<InvitationModel> lstInvitationModel = new List<InvitationModel>();
            CommonBase commonBase = new CommonBase();
            commonBase.UserId = Convert.ToInt32(Session["UserId"]);
            ActionResult = new STU.BaseLayer.ActionResult();
            ActionResult = commonAction.NotificationsCount(commonBase);
            if (ActionResult.IsSuccess)
            {
                lstInvitationModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<InvitationModel>(ActionResult.dsResult.Tables[2]);
            }
            return View(lstInvitationModel);
        }
        #endregion

        public ActionResult SendMessages(int pageno, int bookid)
        {
            var Subject = "";
            var Submitter = "";
            var Inviter = "";
            var url = ConfigurationManager.AppSettings["site"].ToString() + "/Home/Index?PageId=" + pageno + "&BookId=" + bookid + "";
            // url = "http://www.notetor.com/Home/Index?PageId=" + pageno + "&BookId=" + bookid + "";
            url = HttpUtility.UrlEncode(url);
            //var url = "<a href=\"" + url1 + "\">" + url1 + "</a>";
            Messages model = new Messages();
            CommonBase commonBase = new CommonBase();
            commonBase.Id = Convert.ToInt32(Session["UserId"]);
            Inviter = Convert.ToString(Session["StudentName"]);
            commonBase.NotebookId = bookid;
            ActionResult = commonAction.Notesbook_Load_ById(commonBase);
            if (ActionResult.IsSuccess)
            {
                Subject = Convert.ToString(ActionResult.dtResult.Rows[0]["SubjectName"]);
                Submitter = Convert.ToString(ActionResult.dtResult.Rows[0]["StudentName"]);
            }

            ActionResult = commonAction.Message_Load(commonBase);
            if (ActionResult.IsSuccess)
            {
                model.Message = string.Format(Convert.ToString(ActionResult.dtResult.Rows[0]["Message"]), Inviter, Subject, Submitter, url);
                model.Id = Convert.ToInt32(ActionResult.dtResult.Rows[0]["Id"]);
                model.count = ActionResult.dtResult.Rows.Count > 1 ? Convert.ToInt32(ActionResult.dtResult.Rows[1]["MessageCount"]) : 0;
            }
            return View(model);
        }

        #region Method SendSMSToPhone
        [ValidateInput(false)]
        public static string SendSMSToPhone(string mobileNumbers, string messageBody, int messageCount)
        {
            var jsonResponse = "";
            string[] Numbers = mobileNumbers.Split(',');
            try
            {
                foreach (var number in Numbers)
                {
                    jsonResponse = Helpers.TwilioHelper.SendSms(number, messageBody, "+15163622226");
                }
            }
            catch (SystemException ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return jsonResponse;
            //var jsonResponce = "";
            /////////////new sms api 
            ////Your authentication key
            //string authKey = ConfigurationManager.AppSettings["authkey"].ToString();
            ////Multiple mobiles numbers separated by comma
            //string mobileNumber = Convert.ToString(mobileNumbers);
            ////Sender ID,While using route4 sender id should be 6 characters long.
            //string senderId = ConfigurationManager.AppSettings["senderId"].ToString();
            ////Your message to send, Add URL encoding here.
            //string message = "Notetor.com " + HttpUtility.UrlEncode(messageBody);


            //try
            //{
            //    //Call Send SMS API

            //    // *Changes URL*
            //    //string sendSMSUri = "http://sms.tejarat.in/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

            //    // **New Url**
            //    string sendSMSUri = "http://dndsms.dit.asia/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

            //    //Create HTTPWebrequest
            //    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);

            //    //Specify post method
            //    httpWReq.Method = "GET";

            //    //Get the response
            //    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    string responseString = reader.ReadToEnd();
            //    jsonResponce = responseString;
            //    //Close the response
            //    reader.Close();
            //    response.Close();
            //}
            //catch (SystemException ex)
            //{
            //    // MessageBox.Show(ex.Message.ToString());
            //    ErrorReporting.WebApplicationError(ex);
            //}
            //return jsonResponce;
        }
        #endregion

        #region HelpPage
        public ActionResult HelpPage()
        {
            return View();

        }
        #endregion

        [HttpGet]
        public ActionResult adcreation(int? adId = 0, int? PageId = 0, int? BookId = 0)
        {
            AdvertisementModels model = new AdvertisementModels();
            List<State> StateList = new List<State>();
            List<City> CityList = new List<City>();
            List<Categories> CategoryList = new List<Categories>();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();
            Categories category = new Categories();

            var country = CountryLoad();
            //Country con = new Country();
            //con.CountryName = "All";
            //con.ID = 0;
            //country.Add(con);
            country = country.OrderBy(c => c.ID).ToList();
            model.Countrylist = country;
            model.Country = 98;

            if (model.Countrylist != null && model.Countrylist.Count > 0)
            {
                int countryId = Convert.ToInt32(101);
                model.Country = countryId;
                commonBase.CountryId = countryId;
                ActionResult = commonAction.States_LoadBy_CountryId(commonBase);
                if (ActionResult.IsSuccess)
                {
                    StateList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<State>(ActionResult.dtResult);
                }
            }
            //State sta = new State();
            //sta.StateName = "All";
            //sta.ID = 0;
            //StateList.Add(sta);
            StateList = StateList.OrderBy(c => c.ID).ToList();
            model.statelist = StateList;


            if (model.statelist != null && model.statelist.Count > 0)
            {
                int StateID = Convert.ToInt32(38);
                model.state = Convert.ToString(StateID);
            }
            if (CityList != null)
            {
                model.citylist = CityList.OrderBy(m => m.CityName).ToList();
            }
            model.City = "2";

            model.CategoryListItem = listSelectListItems;

            model.CategoryList = CategoryList.Where(m => m.Status == true).ToList();
            category.CategoryName = "ALL";
            model.CategoryList.Insert(0, category);

            model.adcreationId = Convert.ToInt32(adId);
            model.pageId = Convert.ToInt32(PageId);
            model.bookId = Convert.ToInt32(BookId);

            if (adId > 0)
            {
                AdvertisementAction advertisementaction = new AdvertisementAction();
                AdvertisementBase advertisementbase = new AdvertisementBase();

                advertisementbase.adId = Convert.ToInt32(adId);
                ActionResult = advertisementaction.adcreation_LoadByAdId(advertisementbase);
                if (ActionResult.IsSuccess)
                {
                    model.uploadtype = ActionResult.dtResult.Rows[0]["Type"] != DBNull.Value ? Convert.ToInt32(ActionResult.dtResult.Rows[0]["Type"]) : 0;
                    ViewBag.AdType = model.uploadtype;
                    model.headline = Convert.ToString(ActionResult.dtResult.Rows[0]["Headline"]);
                    model.description = Convert.ToString(ActionResult.dtResult.Rows[0]["Description"]);
                    model.urladdress = Convert.ToString(ActionResult.dtResult.Rows[0]["UrlAddress"]);
                    model.price = Convert.ToString(ActionResult.dtResult.Rows[0]["Price"]);
                    model.startdate = Convert.ToString(ActionResult.dtResult.Rows[0]["StartDate"]);
                    model.enddate = Convert.ToString(ActionResult.dtResult.Rows[0]["EndDate"]);
                    model.AdvertiserEmialId = Convert.ToString(ActionResult.dtResult.Rows[0]["EmailId"]);
                    model.AdvertiserMobileNumber = Convert.ToString(ActionResult.dtResult.Rows[0]["MobileNumber"]);
                    model.Country = (ActionResult.dtResult.Rows[0]["CountryId"] != DBNull.Value ? Convert.ToInt32(ActionResult.dtResult.Rows[0]["CountryId"]) : 0);
                    model.state = Convert.ToString(ActionResult.dtResult.Rows[0]["StateId"]);
                    model.City = Convert.ToString(ActionResult.dtResult.Rows[0]["CityId"]);
                    model.PurchasedCategory = Convert.ToString(ActionResult.dtResult.Rows[0]["PurchasedCategory"]);
                    model.AmountPaid = Convert.ToDecimal(ActionResult.dtResult.Rows[0]["AmountToBePaid"]);
                }

                ViewBag.ButtonText = "Update";

            }
            else
            {
                ViewBag.ButtonText = "Place Order";
            }
            try
            {
                Profile profileModel = new Profile();
                List<Profile> lstprofileModel = new List<Profile>();
                commonBase.Id = Convert.ToInt32(Session["UserId"]);
                ActionResult = commonAction.UserInfo_LoadById(commonBase);
                if (ActionResult.IsSuccess)
                {

                    lstprofileModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Profile>(ActionResult.dtResult);
                    if (lstprofileModel.Count > 0)
                        profileModel = lstprofileModel.FirstOrDefault();

                    //var date = DateTime.TryParseExact(ActionResult.dtResult.Rows[0]["DOB"].ToString(), "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                    ViewBag.CountryCode = profileModel.CountryName;

                    string YourCountryName = profileModel.CountryName;
                    foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                    {
                        var country1 = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                        var cName = country1.DisplayName;

                        if (YourCountryName == cName)
                        {

                            ViewBag.CurrencySymbol = country1.CurrencySymbol;
                            ViewBag.ISOCurrencySymbol = country1.ISOCurrencySymbol;
                        }
                    }
                }
            }
            catch (Exception ex) { throw (ex); }
            return View(model);
        }

        [HttpPost]
        public ActionResult adcreation(AdvertisementModels advertisementmodels, PicuploadedModel picuploadedmodel, FormCollection fc)
        {
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            advertisementbase.uploadtype = advertisementmodels.uploadtype;
            advertisementbase.headline = advertisementmodels.headline;
            advertisementbase.description = advertisementmodels.description;
            advertisementbase.urladdress = advertisementmodels.urladdress;
            advertisementbase.price = advertisementmodels.price;
            advertisementbase.Features = advertisementmodels.Features;
            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            advertisementbase.EmailId = advertisementmodels.AdvertiserEmialId;
            advertisementbase.MobileNumber = advertisementmodels.AdvertiserMobileNumber;
            advertisementbase.CountryId = advertisementmodels.Country;
            advertisementbase.StateId = Convert.ToInt32(advertisementmodels.state);
            decimal amount = Convert.ToDecimal(fc["finalamount"] != "" ? Convert.ToDecimal(fc["finalamount"]) : 0);
            string Isocode = fc["countryIsocode"];
            decimal Totalamount = Convert.ToDecimal(fc["amountPaidLbl"] != "" ? Convert.ToDecimal(fc["amountPaidLbl"]) : 0);
            var d = amount;
            advertisementbase.CategoryIds = fc["hdnCategoryIds"] != "" ? fc["hdnCategoryIds"] : "";
            advertisementbase.adId = advertisementmodels.adcreationId;
            DataTable fileuploadTable = new DataTable();
            DataColumn column = new DataColumn();
            column.ColumnName = "FileUploaded";
            column.DataType = typeof(System.String);
            fileuploadTable.Columns.Add(column);
            string filePath = fc["hdnFilePath"];
            if (!string.IsNullOrEmpty(filePath))
            {
                var files = filePath.Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
                AdvertisementUploadingBase advertisementuploadingbase = new AdvertisementUploadingBase();
                DataRow row;
                foreach (var newFilePath in files)
                {
                    if (!string.IsNullOrEmpty(newFilePath))
                    {
                        row = fileuploadTable.NewRow();
                        row["FileUploaded"] = newFilePath;
                        fileuploadTable.Rows.Add(row);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("fileuploader", "Please upload atleast one file");
            }
            advertisementbase.fileuploadTable = fileuploadTable;
            if (advertisementmodels.adcreationId > 0)
            {
                ActionResult = advertisementaction.Advertisement_Update(advertisementbase);
                if (ActionResult.IsSuccess)
                {
                    return RedirectToAction("Index", "Home", new { PageId = advertisementmodels.pageId, BookId = advertisementmodels.bookId });
                }
            }
            else
            {
                try
                {
                    Session["startdate"] = advertisementmodels.startdate;
                    Session["enddate"] = advertisementmodels.enddate;
                    DateTime sdt = DateTime.ParseExact(advertisementmodels.startdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime edt = DateTime.ParseExact(advertisementmodels.enddate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    advertisementbase.startdate = sdt;
                    advertisementbase.enddate = edt;
                }
                catch (Exception ex)
                {
                    ErrorReporting.WebApplicationError(ex);
                }
                ActionResult = advertisementaction.Advertisement_Insert(advertisementbase);
                if (ActionResult.IsSuccess)
                {
                    var adid = "";
                    if (ActionResult.dtResult.Rows[0][0].ToString() != "" && ActionResult.dtResult.Rows[0][0].ToString() != null)
                    {
                        adid = ActionResult.dtResult.Rows[0][0].ToString();
                        string citydata = fc["citydata"];
                        Session["CityId"] = citydata;
                        var datacity = citydata.Split(',');
                        foreach (var item in datacity)
                        {
                            advertisementbase.adId = Convert.ToInt32(adid);
                            advertisementbase.CityId = Convert.ToInt32(item);
                            advertisementaction.cityId_Insert(advertisementbase);
                        }
                    }
                    TempData["Add_Id"] = adid;

                    Session["adTitle"] = advertisementbase.headline;
                    var data = ActionResult;

                    return RedirectToAction("PaymentWithPaypal", new { Cancel = "", paym = d, countrycode = Isocode });

                }
                else
                {
                    return View(advertisementbase);
                }
            }

            return View(advertisementbase);
        }

        public void AdBulkSmsSend_ForAd(DataTable dtrecord)
        {
            var jsonResponse = "";
            for (int i = 0; i < dtrecord.Rows.Count; i++)
            {
               
                //var messageBody = "Hello " + dtrecord.Rows[i]["username"].ToString() + ", "
                //+ "" + dtrecord.Rows[i]["name"].ToString() + " advertized " + dtrecord.Rows[i]["Headline"] + " for you. " + ConfigurationManager.AppSettings["site"].ToString() + "";
                var messageBody = dtrecord.Rows[i]["name"].ToString() + " advertized " + dtrecord.Rows[i]["Headline"] + " for you. " + ConfigurationManager.AppSettings["site"].ToString() + "";

                string authKey = ConfigurationManager.AppSettings["authkey"].ToString();
                //Multiple mobiles numbers separated by comma
                string mobileNumber = Convert.ToString(dtrecord.Rows[i]["MobileNumber"]);
                ////Sender ID,While using route4 sender id should be 6 characters long.
                //string senderId = ConfigurationManager.AppSettings["senderId"].ToString();
                ////Your message to send, Add URL encoding here.
                //string message = HttpUtility.UrlEncode(messageBody);


                try
                {                  

                    jsonResponse = Helpers.TwilioHelper.SendSms(mobileNumber, messageBody, "+15163622226");
                   
                    ////Call Send SMS API
                    ////string sendSMSUri = "http://sms.tejarat.in/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

                    //string sendSMSUri = "http://dndsms.dit.asia/api/sendhttp.php?authkey=" + authKey + "&mobiles=" + mobileNumber + "&message=" + message + "&sender=" + senderId + "&route=2&country=0";

                    ////Create HTTPWebrequest
                    //HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);

                    ////Specify post method
                    //httpWReq.Method = "GET";

                    ////Get the response
                    //HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                    //StreamReader reader = new StreamReader(response.GetResponseStream());
                    //string responseString = reader.ReadToEnd();
                    ////Close the response
                    //reader.Close();
                    //response.Close();
                }
                catch (SystemException ex)
                {
                    // MessageBox.Show(ex.Message.ToString());
                    ErrorReporting.WebApplicationError(ex);
                }                
            }
        }
        [HttpGet]
        public ActionResult MakePayment(int AdId)
        {
            MakePaymentModel model = new MakePaymentModel();

            var id = DateTime.Now.ToString("yyyyMMddHHmmss");
            Session["OrderId"] = id;

            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();

            advertisementbase.adId = AdId;
            advertisementbase.OrderId = id;
            ActionResult = advertisementaction.UpdateOtrdeId_ByAdId(advertisementbase);
            if (ActionResult.IsSuccess)
            {
                model.AmountPaid = (ActionResult.dtResult.Rows[0]["AmountToBePaid"] != DBNull.Value ? Convert.ToDecimal(ActionResult.dtResult.Rows[0]["AmountToBePaid"]) : 0);
                Session["Amount"] = model.AmountPaid;
            }
            model.RedirectUrl = RedirectURL;
            model.CancelUrl = CancelURL;
            model.MerchantId = strMerchantId;

            return View("Checkout", model);
        }

        [HttpPost]
        public ActionResult MakePayment(MakePaymentModel model)
        {
            return View("Checkout", model);
        }


        public ActionResult Checkout(MakePaymentModel model)
        {
            var id = DateTime.Now.ToString("yyyyMMddHHmmss");
            Session["OrderId"] = id;
            model.RedirectUrl = RedirectURL;
            model.CancelUrl = CancelURL;
            model.MerchantId = strMerchantId;

            return View("Checkout", model);

        }

        #region Method CheckCardNumber
        private bool CheckCardNumber(string cardNumber)
        {
            try
            {
                string exp = "^[0-9]{1,20}$";
                Regex expRegex = new Regex(exp);
                if (expRegex.IsMatch(cardNumber))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return false;
        }
        #endregion

        #region Method CheckCardExpiration
        private bool CheckCardExpiration(int slectedYear, int selectedMonth)
        {
            try
            {
                int month = Convert.ToInt32(System.DateTime.Today.Month.ToString());
                int year = Convert.ToInt32(System.DateTime.Today.Year.ToString());

                if (slectedYear < year)
                {
                    return false;

                }
                else if (slectedYear == year)
                {
                    if (selectedMonth < month)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return true;
        }
        #endregion

        public JsonResult CheckAvailability(string categoryIds, string startDate, string endDate)
        {
            AdvertisementModels model = new AdvertisementModels();
            List<Categories> CategoryList = new List<Categories>();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();

            try
            {
                DateTime sdt = DateTime.ParseExact(startDate, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                DateTime edt = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                advertisementbase.startdate = sdt;
                advertisementbase.enddate = edt;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            advertisementbase.CategoryIds = categoryIds;

            ActionResult = advertisementaction.CheckAvailability(advertisementbase);
            if (ActionResult.IsSuccess)
            {
                CategoryList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Categories>(ActionResult.dtResult);
            }
            model.CategoryList = CategoryList;
            return Json(model, JsonRequestBehavior.AllowGet);
            //return CategoryList;
        }

        public JsonResult CheckCityAvailability(string startDate, string endDate, string allcityId)
        {
            AdvertisementModels model = new AdvertisementModels();
            List<AdvertisementModels> advertisementList = new List<AdvertisementModels>();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            List<AddList> addLists = new List<AddList>();

            advertisementbase.MultiplecityId = allcityId;
            //  advertisementbase.Checkstartdate = startDate;
            advertisementbase.Checkstartdate = Convert.ToDateTime(startDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            //   advertisementbase.Checkenddate = endDate;
            advertisementbase.Checkenddate = Convert.ToDateTime(endDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);


            ActionResult = advertisementaction.CheckCityAd_Availability(advertisementbase);
            if (ActionResult.IsSuccess)
            {
                DataTable dt = new DataTable();
                addLists = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AddList>(ActionResult.dtResult);
                //   var sdate = ActionResult.dtResult.Rows[0].ItemArray[0];
                // string StartDate = Convert.ToDateTime(sdate).ToString("dd/MM/yyyy" , CultureInfo.InvariantCulture);
                // var edate = ActionResult.dtResult.Rows[0].ItemArray[0];
                // string EndDate = Convert.ToDateTime(edate).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                // var data = ActionResult.dtResult.Rows[0].ItemArray[2];
                // d =Convert.ToString(data);
            }

            return Json(addLists, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ResponseHandler()
        {
            int AdId = 0;
            try
            {
                CCACrypto ccaCrypto = new CCACrypto();
                string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
                NameValueCollection Params = new NameValueCollection();
                string[] segments = encResponse.Split('&');
                foreach (string seg in segments)
                {
                    string[] parts = seg.Split('=');
                    if (parts.Length > 0)
                    {
                        string Key = parts[0].Trim();
                        string Value = parts[1].Trim();
                        Params.Add(Key, Value);
                    }
                }
                string response = "";
                for (int i = 0; i < Params.Count; i++)
                {
                    // Here we get result of payments
                    //  Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                    response = response + Params.Keys[i] + " = " + Params[i] + "<br>";
                }


                checkoutbase basemodel = new checkoutbase();
                basemodel.TransactionId = Params[0];
                basemodel.Response = response;
                basemodel.Status = Params[3];

                AdvertisementAction advertisementaction = new AdvertisementAction();
                ActionResult = advertisementaction.Add_Transaction_Response(basemodel);
                if (ActionResult.IsSuccess)
                {
                    AdId = (ActionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(ActionResult.dtResult.Rows[0][0]) : 0);

                }
                if (Params[3] == "Success")
                {
                    TempData["SuccessMessage"] = "Thanks for creating Ad.Your ad is created successfully.";

                    CommonAction commonAction = new CommonAction();
                    string citydata = Convert.ToString(Session["CityId"]);
                    var datacity = citydata.Split(',');
                    foreach (var item in datacity)
                    {
                        commonBase.CityId = Convert.ToInt32(item);
                        ActionResult = commonAction.GetUsersList_ByCityId(commonBase);
                        if (ActionResult.IsSuccess)
                        {
                            var PhoneNumber = ActionResult.dtResult.Rows[0][0].ToString();
                            var adTitle = (Session["adTitle"] != null ? Session["adTitle"].ToString() : "");
                            var message = Session["UserName"].ToString() + " advertised '" + adTitle + "'  for you in http://Notetor.com";
                            SendSMSToPhone(PhoneNumber, message, 0);
                        }
                    }


                }
                else
                {
                    TempData["ErrorMessage"] = "An error occured, while processing your request.";
                }
            }
            catch (System.Exception ex)
            {
                //throw ex;
                TempData["ErrorMessage"] = "An error occured, while processing your request.";
                ErrorReporting.WebApplicationError(ex);
            }
            ViewBag.AdId = AdId;
            return View();


        }

        public ActionResult CCAVENUETest()
        {

            foreach (string name in Request.Form)
            {
                if (name != null)
                {
                    if (!name.StartsWith("_"))
                    {
                        ccaRequest = ccaRequest + name + "=" + Request.Form[name] + "&";

                    }
                }
            }
            ccaRequest = ccaRequest + "amount" + "=" + Session["Amount"].ToString() + "&";
            ccaRequest = ccaRequest.TrimEnd('&');
            ViewBag.strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
            //string data = ccaCrypto.Decrypt(ViewBag.strEncRequest, workingKey);
            ViewBag.strAccessCode = strAccessCode;
            return View();
        }



        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();
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
        public ActionResult Search(string data)
        {
            string[] query = data.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);


            ManageProfile model = new ManageProfile();
            model.FriendRequests = new List<Friend>();
            model.profile = new Profile();
            model.lstFriends = new List<Friend>();
            ViewBag.Data = data;
            try
            {
                DataTable dt = new DataTable();
                for (int i = 0; i <= query.Length - 1; i++)
                {
                    STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
                    ActionResult = new STU.BaseLayer.ActionResult();
                    ActionResult = UserAction.SearchStudent(query[i]);
                    if (i == 0) dt = ActionResult.dtResult.Clone();
                    foreach (DataRow row in ActionResult.dtResult.Rows)
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
                    model.lstFriends = FriendList;

                    commonBase.Id = Convert.ToInt32(Session["UserId"]);
                    ActionResult = commonAction.FriendRequest_LoadByUserId(commonBase);
                    if (ActionResult.IsSuccess)
                    {
                        FriendRequests = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Friend>(ActionResult.dtResult);
                    }
                    model.FriendRequests = FriendRequests;
                    model.profile = profileModel;
                    ViewBag.PageId = "0";
                    //return PartialView(model);

                }
            }
            catch (Exception ex) { throw (ex); }
            return View(model);
        }
        public ActionResult AccountSettings(int? adId = 0)
        {
            AdvertisementModels model = new AdvertisementModels();
            try
            {
                AdvertisementBase advertisementbase = new AdvertisementBase();
                AdvertisementAction advertisementaction = new AdvertisementAction();

                //List<AdvertisementModels> adsList = new List<AdvertisementModels>();

                List<AdvertisementModels> PageList = new List<AdvertisementModels>();
                advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
                ActionResult = advertisementaction.GetPageList_ByUserId(advertisementbase);

                if (ActionResult.IsSuccess)
                {
                    PageList = (from DataRow row in ActionResult.dsResult.Tables[0].Rows
                                select new AdvertisementModels
                                {
                                    ClickDate = row["ClickDate"] != DBNull.Value ? Convert.ToString(row["ClickDate"]) : "",
                                    ClickTime = row["ClickTime"] != DBNull.Value ? Convert.ToString(row["ClickTime"]) : "",
                                    ClickedBy = row["Name"] != DBNull.Value ? row["Name"].ToString() : "",
                                    ClickedOn = row["ClickedOn"] != DBNull.Value ? row["ClickedOn"].ToString() : "",
                                    UnitPrice = row["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(row["UnitPrice"]) : 0
                                }).ToList();

                    model.PageListClick = PageList;

                    if (ActionResult.dsResult.Tables[1].Rows.Count > 0)
                    {
                        DataRow dr = ActionResult.dsResult.Tables[1].Rows[0];
                        if (PageList != null && PageList.Count > 0)
                        {
                            model.WalletAmount = dr["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(dr["TotalAmount"]) : 0;
                            model.UnitPrice = dr["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(dr["UnitPrice"]) : 0;
                            model.ClicksCount = dr["ClickCount"] != DBNull.Value ? Convert.ToInt32(dr["ClickCount"]) : 0;
                        }
                        else
                        {
                            model.WalletAmount = 0;
                        }
                    }

                    //if (ActionResult.dsResult.Tables[2].Rows.Count > 0)
                    //{
                    //    DataRow drUnitPrice = ActionResult.dsResult.Tables[2].Rows[0];
                    //    model.UnitPrice = drUnitPrice["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(drUnitPrice["UnitPrice"]) : 0;
                    //}
                }


                //-----Comented by Zuber (Client Requirement)
                //  ActionResult = advertisementaction.GetAdsList_ByUserId(advertisementbase);
                //if (ActionResult.IsSuccess)
                //{
                //    adsList = (from DataRow row in ActionResult.dsResult.Tables[0].Rows
                //               select new AdvertisementModels
                //               {
                //                   adcreationId = row["adcreationId"] != DBNull.Value ? Convert.ToInt32(row["adcreationId"]) : 0,
                //                   ClickDate = row["ClickDate"] != DBNull.Value ? Convert.ToString(row["ClickDate"]) : "",
                //                   ClickedBy = row["ClickedBy"] != DBNull.Value ? row["ClickedBy"].ToString() : "",
                //                   ClickedOn = row["ClickedOn"] != DBNull.Value ? row["ClickedOn"].ToString() : "",
                //                   UnitPrice = row["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(row["UnitPrice"]) : 0
                //               }).ToList();

                //    model.AdvertiseList = adsList;

                //    if (ActionResult.dsResult.Tables[1].Rows.Count > 0)
                //    {
                //        DataRow dr = ActionResult.dsResult.Tables[1].Rows[0];
                //        if (adsList != null && adsList.Count > 0)
                //        {
                //            model.WalletAmount = dr["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(dr["TotalAmount"]) : 0;
                //            //   model.UnitPrice = dr["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(dr["UnitPrice"]) : 0;
                //            model.ClicksCount = dr["ClickCount"] != DBNull.Value ? Convert.ToInt32(dr["ClickCount"]) : 0;
                //        }
                //        else
                //        {
                //            model.WalletAmount = 0;
                //        }
                //    }

                //    if (ActionResult.dsResult.Tables[2].Rows.Count > 0)
                //    {
                //        DataRow drUnitPrice = ActionResult.dsResult.Tables[2].Rows[0];
                //        model.UnitPrice = drUnitPrice["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(drUnitPrice["UnitPrice"]) : 0;
                //    }
                //}

                List<AdvertisementModels> paymentList = new List<AdvertisementModels>();

                ActionResult = advertisementaction.PaymentRequest_LoadByUserId(advertisementbase);
                if (ActionResult.IsSuccess)
                {
                    paymentList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<AdvertisementModels>(ActionResult.dtResult);
                }
                model.PaymentList = paymentList;


                try
                {
                    Profile profileModel = new Profile();
                    List<Profile> lstprofileModel = new List<Profile>();
                    commonBase.Id = Convert.ToInt32(Session["UserId"]);
                    ActionResult = commonAction.UserInfo_LoadById(commonBase);
                    if (ActionResult.IsSuccess)
                    {

                        lstprofileModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Profile>(ActionResult.dtResult);
                        if (lstprofileModel.Count > 0)
                            profileModel = lstprofileModel.FirstOrDefault();
                        //DateTime dt;
                        //var date = DateTime.TryParseExact(ActionResult.dtResult.Rows[0]["DOB"].ToString(), "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                        ViewBag.CountryCode = profileModel.CountryName;

                        string YourCountryName = profileModel.CountryName;
                        foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                        {
                            var country1 = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                            var cName = country1.DisplayName;
                            if (YourCountryName == cName)
                            {
                                ViewBag.CurrencySymbol = country1.CurrencySymbol;
                            }

                        }


                    }
                }
                catch (Exception ex) { throw (ex); }





                //Get Ad detail by Ad Id
                //if (adId == 0)
                //{
                //    adId = (adsList != null && adsList.Count > 0 ? adsList[0].adcreationId : 0);
                //}
                //if (adId > 0)
                //{
                //    advertisementbase.adId = Convert.ToInt32(adId);
                //    model.adcreationId = Convert.ToInt32(adId);
                //    ActionResult = advertisementaction.GetClickCount_ByAdId(advertisementbase);
                //    if (ActionResult.IsSuccess)
                //    {
                //        model.ClicksCount = (ActionResult.dtResult.Rows[0][0] != DBNull.Value && ActionResult.dtResult.Rows[0][0] != string.Empty ? Convert.ToInt32(ActionResult.dtResult.Rows[0][0]) : 0);
                //        ViewBag.AmountPending = (ActionResult.dtResult.Rows[0][1] != DBNull.Value && ActionResult.dtResult.Rows[0][1] != string.Empty ? Convert.ToInt32(ActionResult.dtResult.Rows[0][1]) : 0);
                //    }
                //    ActionResult = advertisementaction.PriceTable_S();
                //    if (ActionResult.IsSuccess)
                //    {
                //        model.AmountPaid = (ActionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(ActionResult.dtResult.Rows[0][0]) : 0);
                //    }
                //    advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
                //    model.AmountRequested = (model.ClicksCount * model.AmountPaid);

                //    ActionResult = advertisementaction.getAccountDetails_ByUserId(advertisementbase);
                //    if (ActionResult.IsSuccess)
                //    {
                //        try
                //        {
                //            model.AccountNumber = ActionResult.dtResult.Rows[0][2] != DBNull.Value ? Decode(ActionResult.dtResult.Rows[0][2].ToString()) : "";
                //            model.IFSCCode = ActionResult.dtResult.Rows[0][6] != DBNull.Value ? Decode(ActionResult.dtResult.Rows[0][6].ToString()) : "";
                //            model.AccountHolderName = ActionResult.dtResult.Rows[0][8] != DBNull.Value ? Convert.ToString(ActionResult.dtResult.Rows[0][8]) : "";
                //        }
                //        catch (Exception ex)
                //        {
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return View(model);
        }

        #region Method SendSMSToMobile
        [ValidateInput(false)]
        public JsonResult SendSMSToMobile(string mobileNumbers, string messageBody, string messageCount)
        {
            var jsonResponse = "";
            string[] Numbers = mobileNumbers.Split(',');
            try
            {
                foreach (var number in Numbers)
                {
                    jsonResponse = Helpers.TwilioHelper.SendSms(number,HttpUtility.UrlDecode(messageBody), "+15163622226");
                }
            }
            catch (SystemException ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
            //var jsonResponce = "";

            //string authKey = ConfigurationManager.AppSettings["authkey"].ToString();

            //string mobileNumber = Convert.ToString(mobileNumbers);

            //string senderId = ConfigurationManager.AppSettings["senderId"].ToString();

            //string message = HttpUtility.HtmlEncode(messageBody);

            //StringBuilder sbPostData = new StringBuilder();
            //sbPostData.AppendFormat("authkey={0}", authKey);
            //sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            //sbPostData.AppendFormat("&message={0}", message);
            //sbPostData.AppendFormat("&sender={0}", senderId);
            //sbPostData.AppendFormat("&route={0}", "2");
            //sbPostData.AppendFormat("&country={0}", "0");
            //try
            //{

            //    string sendSMSUri = "http://dndsms.dit.asia/api/sendhttp.php";

            //    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);

            //    UTF8Encoding encoding = new UTF8Encoding();
            //    byte[] data = encoding.GetBytes(sbPostData.ToString());

            //    httpWReq.Method = "POST";
            //    httpWReq.ContentType = "application/x-www-form-urlencoded";
            //    httpWReq.ContentLength = data.Length;
            //    using (System.IO.Stream stream = httpWReq.GetRequestStream())
            //    {
            //        stream.Write(data, 0, data.Length);
            //    }
            //    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    string responseString = reader.ReadToEnd();
            //    jsonResponce = responseString;

            //    reader.Close();
            //    response.Close();
            //}
            //catch (SystemException ex)
            //{
            //    ErrorReporting.WebApplicationError(ex);
            //}
            //return Json(jsonResponce, JsonRequestBehavior.AllowGet);
        }

        #endregion

        public JsonResult AdDetails(string AdId)
        {
            AdvertisementModels model = new AdvertisementModels();
            List<Categories> CategoryList = new List<Categories>();
            STU.BaseLayer.Pages.PagesBase pageBase = new STU.BaseLayer.Pages.PagesBase();
            STU.ActionLayer.Pages.PagesAction pageAction = new STU.ActionLayer.Pages.PagesAction();
            pageBase.Id = Convert.ToInt64(AdId);
            ActionResult = pageAction.Ad_LoadBy_Id(pageBase);
            if (ActionResult.IsSuccess)
            {
                var cat = ActionResult.dtResult.Rows[0];
                Categories catModel = new Categories();
                catModel.adcreationId = Convert.ToInt32(cat["adcreationId"]);
                catModel.aduploadedId = Convert.ToInt32(cat["aduploadedId"]);
                catModel.UserId = Convert.ToInt32(cat["UserId"]);
                catModel.FileUploaded = cat["FileUploaded"].ToString();
                catModel.StudentName = cat["StudentName"].ToString();
                catModel.FileName = cat["FileName"].ToString();
                catModel.Headline = cat["Headline"].ToString();
                catModel.Description = cat["Description"].ToString();
                catModel.Price = Convert.ToDecimal(cat["Price"]);
                catModel.MobileNumber = cat["MobileNumber"].ToString();
                catModel.Type = Convert.ToInt32(cat["Type"]);
                catModel.UrlAddress = cat["UrlAddress"].ToString();

                CategoryList.Add(catModel);
            }
            model.CategoryList = CategoryList;
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult UploadAudioFile()
        {
            string[] jsonArr = new string[2];
            //   string OrignalfilePath = string.Empty;
            foreach (string file in Request.Files)
            {
                var FileDataContent = Request.Files[file];
                if (FileDataContent != null && FileDataContent.ContentLength > 0)
                {
                    // take the input stream, and save it to a temp folder using
                    // the original file.part name posted
                    var stream = FileDataContent.InputStream;
                    var fileName = Path.GetFileName(FileDataContent.FileName);
                    if (fileName.Contains(" "))
                    {
                        fileName.Replace(" ", "_");
                    }

                    DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/Content/User/PageAudio"));
                    if (!dinfo.Exists)
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Content/User/PageAudio"));
                    }
                    string path = Path.Combine(Server.MapPath("~/Content/User/PageAudio/"), fileName);
                    var orgnfileName = Request.Params["OrignalfileName"];
                    try
                    {
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        // Once the file part is saved, see if we have enough to merge it
                        ChunkFileUpload UT = new ChunkFileUpload();
                        bool uploadFile = UT.MergeFile(path);
                        jsonArr[0] = uploadFile.ToString();
                        if (uploadFile == true)
                        {
                            jsonArr[1] = Path.Combine(("/Content/User/PageAudio/"), orgnfileName.ToString());
                        }

                    }
                    catch (IOException ex)
                    {
                        throw ex;
                    }
                }
            }
            return Json(jsonArr);
        }

        [HttpPost]
        public ActionResult UploadVideoFile()
        {
            string[] jsonArr = new string[2];
            //   string OrignalfilePath = string.Empty;
            foreach (string file in Request.Files)
            {
                var FileDataContent = Request.Files[file];
                if (FileDataContent != null && FileDataContent.ContentLength > 0)
                {
                    // take the input stream, and save it to a temp folder using
                    // the original file.part name posted
                    var stream = FileDataContent.InputStream;
                    var fileName = Path.GetFileName(FileDataContent.FileName);
                    if (fileName.Contains(" "))
                    {
                        fileName.Replace(" ", "_");
                    }

                    DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/Content/User/PageVideo"));
                    if (!dinfo.Exists)
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Content/User/PageVideo"));
                    }

                    string path = Path.Combine(Server.MapPath("~/Content/User/PageVideo/"), fileName);
                    var orgnfileName = Request.Params["OrignalfileName"];
                    try
                    {
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        // Once the file part is saved, see if we have enough to merge it
                        ChunkFileUpload UT = new ChunkFileUpload();
                        bool uploadFile = UT.MergeFile(path);
                        jsonArr[0] = uploadFile.ToString();
                        if (uploadFile == true)
                        {
                            jsonArr[1] = Path.Combine(("/Content/User/PageVideo/"), orgnfileName.ToString());
                        }

                    }
                    catch (IOException ex)
                    {
                        // handle
                        throw (ex);
                    }
                }
            }
            return Json(jsonArr);
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            string json = string.Empty;
            foreach (string file in Request.Files)
            {
                var FileDataContent = Request.Files[file];
                if (FileDataContent != null && FileDataContent.ContentLength > 0)
                {
                    var stream = FileDataContent.InputStream;
                    var fileName = Path.GetFileName(FileDataContent.FileName);
                    if (fileName.Contains(" "))
                    {
                        fileName.Replace(" ", "_");
                    }
                    DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/Content/Uploads/Ads/" + Session["UserId"]));
                    if (!dinfo.Exists)
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Content/Uploads/Ads/" + Session["UserId"]));
                    }
                    string path = Path.Combine(Server.MapPath("~/Content/Uploads/Ads/" + Session["UserId"] + "/"), fileName);
                    var orgnfileName = Request.Params["OrignalfileName"];
                    try
                    {
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        ChunkFileUpload UT = new ChunkFileUpload();
                        bool uploadFile = UT.MergeFile(path);
                        if (uploadFile == true)
                        {
                            json = Path.Combine(("/Content/Uploads/Ads/" + Session["UserId"] + "/"), orgnfileName.ToString());
                        }
                    }
                    catch (IOException ex)
                    {
                        // handle
                        throw (ex);
                    }
                }
            }
            return Json(json);
        }

        public void AdBulkSmsSend_ForNewNoteBook(DataTable dtrecord, string subjectName)
        {
            for (int i = 0; i < ActionResult.dtResult.Rows.Count; i++)
            {
                SendSMSToPhone(Convert.ToString(ActionResult.dtResult.Rows[i]["MobileNumber"]), Convert.ToString(ActionResult.dtResult.Rows[i]["FirstName"]) + " " + Convert.ToString(ActionResult.dtResult.Rows[i]["LastName"]) + " added a new page in his notebook '" + subjectName + "' ", 0);
            }
        }


        public ActionResult PaymentWithPaypal(string Cancel = null, string paym = "", string countrycode = "")
        {
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            PaypalResponse respon = new PaypalResponse();
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            var ad = Convert.ToString(TempData["Add_Id"]);
            string da = paym;
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/User/PaymentWithPayPal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid, da, countrycode);
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

                    respon.userId = Convert.ToInt32(Session["UserId"]);
                    respon.Add_Id = Convert.ToString(TempData["Add_Id"]);
                    respon.paymentId = executedPayment.id;
                    respon.totalammount = executedPayment.transactions[0].amount.total;
                    respon.Currency = executedPayment.transactions[0].amount.currency;
                    respon.Payer_id = executedPayment.payer.payer_info.payer_id;
                    respon.intent = executedPayment.intent;
                    respon.state = executedPayment.transactions[0].related_resources[0].sale.state;
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return RedirectToAction("PaymentOnFailure", new { Adid = respon.Add_Id });
                    }
                }
            }
            catch (Exception ex)
            {
                var jobject = (((PayPal.ConnectionException)ex).Response).ToString();
                //    DeleteAddWhichIsnotPaid(Convert.ToInt32(ad), jobject);
                advertisementbase.Add_Creation_ID = ad != "" ? ad : "";
                advertisementbase.Currency = countrycode != "" ? countrycode : "";
                advertisementbase.totalammount = da != "" ? da : "";
                advertisementbase.Response = jobject != "" ? jobject : "";
                advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
                //   Convert.ToDecimal(fc["amountPaidLbl"] != "" ? Convert.ToDecimal(fc["amountPaidLbl"]) : 0);
                advertisementbase.headline = "";
                advertisementbase.ExchangeRate = Convert.ToDecimal(0);
                advertisementbase.paymentId = "";
                advertisementbase.Payer_id = "";
                advertisementbase.intent = "";
                advertisementbase.state = "";
                var d = advertisementaction.PaymentDetails_Insert(advertisementbase);
                return RedirectToAction("PaymentOnFailure", new { Adid = ad });
            }
            return RedirectToAction("PaymentOnSuccess", "User", respon);
        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string pay, string countrycode)
        {
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            itemList.items.Add(new Item()
            {
                name = "Item Name comes here",
                currency = countrycode,
                price = pay,
                quantity = "1",
                sku = "sku"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = pay
            };
            var amount = new Amount()
            {
                currency = countrycode,
                total = pay, // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<PayPal.Api.Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new PayPal.Api.Transaction()
            {
                description = "Transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            Console.WriteLine(apiContext);
            return this.payment.Create(apiContext);
        }
        public ActionResult PaymentOnSuccess()
        {
            AdvertisementModels model = new AdvertisementModels();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            string Email = Convert.ToString(Session["UserName"]);
            string FirstName = Convert.ToString(Session["FirstName"]);
            string LastName = Convert.ToString(Session["LastName"]);
            advertisementbase.headline = Convert.ToString(Session["adTitle"]);
            advertisementbase.userId = Convert.ToInt32(Session["UserId"]);
            advertisementbase.Add_Creation_ID = Request.QueryString["Add_Id"];
            advertisementbase.ExchangeRate = Convert.ToInt32(Session["Rate"]);
            advertisementbase.paymentId = Request.QueryString["paymentId"];
            advertisementbase.Currency = Request.QueryString["Currency"];
            advertisementbase.totalammount = Request.QueryString["totalammount"];
            advertisementbase.Payer_id = Request.QueryString["Payer_id"];
            advertisementbase.intent = Request.QueryString["intent"];
            advertisementbase.state = Request.QueryString["state"];
            string Fullname = FirstName + " " + LastName;
            AccountingSoftware.Helper.Email.SendPaymentRequestStatusUpdateEmail(Email, advertisementbase.totalammount, Fullname, advertisementbase.state);

            ActionResult = advertisementaction.PaymentDetails_Insert(advertisementbase);
            string citydata = Convert.ToString(Session["CityId"]);
            var datacity = citydata.Split(',');
            foreach (var item in datacity)
            {
                advertisementbase.CityId = Convert.ToInt32(item);
                var data = advertisementaction.FindusersDetailofCreatedForCity(advertisementbase);
                if (data.dtResult.Rows[0][1].ToString() != "" && data.dtResult.Rows[0][1].ToString() != null)
                {
                    Task.Run(() => AdBulkSmsSend_ForAd(data.dtResult));
                }
            }
            return View();
        }
        public ActionResult PaymentOnFailure(int Adid)
        {
            commonAction.RemoveUnpiadAdd();
            return View();
        }
        public JsonResult Payouts(string PaypalEmail, string value, string currency)
        {
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            string batch_Id;
            var apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                var payout = new Payout
                {
                    sender_batch_header = new PayoutSenderBatchHeader
                    {
                        sender_batch_id = "batch_" + System.Guid.NewGuid().ToString().Substring(0, 8),
                        email_subject = "You have a payment"
                    },
                    items = new List<PayoutItem>    {
                    new PayoutItem
                    {
                        recipient_type = PayoutRecipientType.EMAIL,
                        amount = new Currency
                        {
                            value= value,
                            currency = "USD"
                        },
                        receiver=PaypalEmail,
                        note = "Thank you.",
                        sender_item_id = Convert.ToString(Session["Payment_ID"]),
                    } }
                };
                var dt = payout.Create(apiContext, false);
                string res = dt.batch_header.batch_status;
                batch_Id = dt.batch_header.payout_batch_id;
                string Sender_batch_Id = dt.batch_header.sender_batch_header.sender_batch_id;
                var d = dt.batch_header;
                advertisementbase.Id = Convert.ToInt32(Session["Payment_ID"]);
                advertisementbase.payout_batch_id = batch_Id;
                advertisementbase.sender_batch_id = Sender_batch_Id;
                var data = advertisementaction.UpdatePaymentBatch_ID(advertisementbase);
                Session["BatchId"] = data.dtResult.Rows[0].ItemArray[0];
                var t = Convert.ToString(Session["BatchId"]);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Json("Done");
        }

        public ActionResult getpayout()
        {
            var apiContext = PaypalConfiguration.GetAPIContext();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();

            var payoutBatchId = Convert.ToString(Session["BatchId"]);
            if (!string.IsNullOrEmpty(payoutBatchId))
            {
                var payout = Payout.Get(apiContext, payoutBatchId);
                var final_Status = payout.items[0].transaction_status;
                advertisementbase.Id = Convert.ToInt32(Session["Payment_ID"]);
                advertisementbase.response_Status = Convert.ToString(final_Status);
                var data = advertisementaction.UpdatePaymentStatus_ByUserId(advertisementbase);
                var amount = payout.items[0].payout_item.amount.value;
                string Email = Convert.ToString(Session["UserName"]);
                string FirstName = Convert.ToString(Session["FirstName"]);
                string LastName = Convert.ToString(Session["LastName"]);
                string Fullname = Convert.ToString(Session["StudentName"]);
                AccountingSoftware.Helper.Email.SendPaymentRequestStatusUpdateEmail(Email, Convert.ToString(amount), Fullname, advertisementbase.response_Status);
            }
            return RedirectToAction("AccountSettings");
        }

        [HttpGet]
        public JsonResult Get_Country_CurrencyCode_Rate_by_CountryId(int CountryID)
        {
            StudentRegistration model = new StudentRegistration();
            //STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            //STU.BaseLayer.User.UsersInfoBase UserInfoBase = new STU.BaseLayer.User.UsersInfoBase();
            CommonBase commonBase = new CommonBase();
            List<CurrencyRate> CurrencyList = new List<CurrencyRate>();
            commonBase.CountryId = CountryID;
            var Ratedata = commonAction.Get_Country_CurrencyCode_Rate_by_CountryId(commonBase);
            if (Ratedata.IsSuccess)
            {
                CurrencyList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<CurrencyRate>(Ratedata.dtResult);
            }
            return Json(CurrencyList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteAddWhichIsnotPaid(int adid, string Response = "")
        {
            STU.ActionLayer.User.UserAction UserAction = new STU.ActionLayer.User.UserAction();
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            advertisementbase.adId = adid;
            advertisementbase.description = Response;
            ActionResult = advertisementaction.deleteaddwhichisnotpaidamount(advertisementbase);
            return View();
        }
        [HttpGet]
        public JsonResult GetCountryDetail()
        {
            UsersInfoBase usersInfoBase = new UsersInfoBase();
            usersInfoBase.Id = Convert.ToInt32(Session["UserId"]);
            List<CurrencyRate> CurrencyList = new List<CurrencyRate>();
            var Ratedata = userAction.GetCountryDetail(usersInfoBase);
            if (Ratedata.IsSuccess)
            {
                CurrencyList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<CurrencyRate>(Ratedata.dtResult);
            }

            return Json(CurrencyList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SumofAllCityPricing()
        {
            AdvertisementAction advertisementaction = new AdvertisementAction();
            AdvertisementBase advertisementbase = new AdvertisementBase();
            List<City> CityList = new List<City>();
            ActionResult = advertisementaction.SumofAllCityPricing();
            if (ActionResult.IsSuccess == true)
            {
                CityList = AccountingSoftware.Helpers.CommonMethods.ConvertTo<City>(ActionResult.dsResult.Tables[0]);
            }
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Setting()
        {
            SubmitterRegistration model = new SubmitterRegistration();
            Profile profileModel = new Profile();
            List<Profile> lstprofileModel = new List<Profile>();
            List<NotebookForm> lstNotebookModel = new List<NotebookForm>();
            commonBase.Id = Convert.ToInt32(Session["UserId"]);
            ViewBag.UserId = commonBase.Id;
            ActionResult = commonAction.UserInfo_LoadById(commonBase);
            if (ActionResult.IsSuccess)
            {
                lstprofileModel = AccountingSoftware.Helpers.CommonMethods.ConvertTo<Profile>(ActionResult.dtResult);
                if (lstprofileModel.Count > 0)
                    profileModel = lstprofileModel.FirstOrDefault();
            }
            model.EmailID = profileModel.EmailId;
            model.Password = profileModel.Password;
            model.ISD_Code = profileModel.ISD_Code;
            model.MobileNumber = profileModel.MobileNumber;
            if ( !(string.IsNullOrEmpty(model.ISD_Code)) && !(string.IsNullOrEmpty(model.MobileNumber)))
            {
                model.MobileNumber = model.ISD_Code + model.MobileNumber;
                model.MobileNumber = model.MobileNumber.Trim();
            }
               
            return View(model);
        }
        [HttpPost]
        public ActionResult Setting(FormCollection fc)
        {
            commonBase.UserId = Convert.ToInt32(Session["UserId"]);
            commonBase.Email = (Convert.ToString(fc["emailId"]) != null && Convert.ToString(fc["emailId"]) != "") ? Convert.ToString(fc["emailId"]) : "";
            commonBase.Password = (Convert.ToString(fc["hiddenpassword"]) != null && Convert.ToString(fc["hiddenpassword"]) != "") ? Convert.ToString(fc["hiddenpassword"]) : "";
            commonBase.ContactNo = (Convert.ToString(fc["MobileNumber"]) != null && Convert.ToString(fc["MobileNumber"]) != "") ? Convert.ToString(fc["MobileNumber"]) : "";
            commonBase.ISD_Code = (Convert.ToString(fc["isdCode"]) != null && Convert.ToString(fc["isdCode"]) != "") ? Convert.ToString(fc["isdCode"]) : "";           
            ActionResult = commonAction.Setting(commonBase);
            if (ActionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Profile Updated";
                return RedirectToAction("Setting");
            }
            else
            {
                TempData["ErrorMessage"] = "An error occured, while processing your request.";
                return RedirectToAction("Setting");
            }

        }

        [HttpPost]
        public ActionResult DeleteAccount()
        {
            commonBase.UserId = Convert.ToInt32(Session["UserId"]);
            ActionResult = commonAction.DeleteAccount(commonBase);
            if (ActionResult.IsSuccess)
            {
                return RedirectToAction("LogOff", "Account");
            }
            else
            {
                TempData["ErrorMessage"] = "An error occured, while processing your request.";
                return RedirectToAction("Setting");
            }

        }
        public ActionResult removeUnpaidAdd()
        {
            ActionResult = commonAction.RemoveUnpiadAdd();
            if (ActionResult.IsSuccess)
            {
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }
        [HttpGet]
        public JsonResult CityName(int Id)
        {
            string cityname = "";
            var name = commonAction.CityNameByID(Id);
            if (name.IsSuccess)
            {
                var l = name.dtResult.Rows[0]["cityname"];
                return Json(l, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(cityname, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
