using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAppWebsite.Models
{
    public class UserModels
    {
    }


    public class Profile
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string MobileNumber { get; set; }
        public string ISD_Code { get; set; }
        public string EmailId { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string CoverImage { get; set; }
        public string LastSeen { get; set; }
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; } 
        public int IsOnline { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InstituteName { get; set; }
        
    }

    public class Notebook
    {
        public string NotebookId { get; set; }
        public string NotebookName { get; set; }
        public string Subjects { get; set; }
        public string SubjectName { get; set; }
        public string Teacher { get; set; }
        public string TeachereName { get; set; }
        public string Coaching { get; set; }
        public string CollegeId { get; set; }
        public string TotalPages { get; set; }
        public string Type { get; set; }
        public string Pages { get; set; }
        public string Content { get; set; }
    }


    public class NotebookForm
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public string BookId { get; set; }
        public string NotebookId { get; set; }
        public string NotebookName { get; set; }
        public string SubjectId { get; set; }
        [Required(ErrorMessage = "Chapter Name is required")]
        public string ChapterName { get; set; }
        [Required(ErrorMessage = "Subject Name is required")]
        public string SubjectName { get; set; }
        public string Content { get; set; }
        [Required(ErrorMessage = "Teacher Name is required")]
        public string TeachereName { get; set; }
        public string TeachersName { get; set; }
       // [Required(ErrorMessage = "Institute Name is required")]
        public string InstituteName { get; set; }
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string CategoryName { get; set; }
        public int Visible_Hidden { get; set; }
        public int Innovation_Investment { get; set; }
        public string StartDate { get; set; }
        public string TotalPages { get; set; }
        [Required(ErrorMessage = "Stream is required")]
        public string StreamName { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public string CreatedDate { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        public string RatingId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Card Holder Name is required")]
        public string CardHolderName { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Card number must be a number")]
        [Required(ErrorMessage = "Card Number is required")]
        public string CardNumber { get; set; }
        public int Rate { get; set; }
        public string CollegeId { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        public DateTime? ExpirationDate { get; set; }
        public List<Subjects> SubjectList { get; set; }
        public List<Institute> InstituteList { get; set; }
        public List<Categories> CategoryList { get; set; }
        public List<Stream> StreamList { get; set; }
        public string SubmitterPic { get; set; }

        public List<NotebookForm> NotebookFormList { get; set; }
        public List<string> chaptersList { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [AllowHtml]
        public string PageImage { get; set; }

        public string PageNameV1 { get; set; }
        public string BookType { get; set; }
        public bool IsHtml { get; set; }
        public int Total_Number_of_Pages { get; set; }
        public string PageTitle { get; set; }
        public string nextPage { get; set; }
        public string prevPage { get; set; }
        public string ModifiedDate { get; set; }
        public List<Int64> lstpageIds = new List<Int64>();
      
        public string ScreenShot { get; set; }
        [RegularExpression(@"^\d{3}$", ErrorMessage = "CVV must be a 3 digit number")]
        public string CVV { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int TotalRows { get; set; }
        public int CategoryId { get; set; }
        public int StreamId { get; set; }
        public int MonetoryAdvantages { get; set; }
        public string PageType { get; set; }
        public string subnametxt { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public double StarRating { get; set; }
    }



    public class ManageProfile
    {
        public Profile profile { get; set; }
        public List<NotebookForm> lstNotebooks { get; set; }
        public List<Friend> lstFriends { get; set; }
        public List<Friend> FriendRequests { get; set; }
        public List<Country> Countrylist { get; set; }
        public List<City> citylist { get; set; }
        public List<State> statelist { get; set; }
        //public List<College> collegelist { get; set; }
        public List<InstituteModel> InstituteModellist { get; set; }
    }

    public class Friend
    {
        public int id { get; set; }
        public List<Friend> FriendList { get; set; }
        public string StudentName { get; set; }
        public string MobileNumber { get; set; }
        public string ProfileImage { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        [Required(ErrorMessage = "Email is required.")]
        public string EmailId { get; set; }
        public string Status { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public int InvitationListId { get; set; }
        public int FriendRequestId { get; set; }
        public string PageId { get; set; }
        public int Reciever { get; set; }
        public int Sender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    } 

    public class InvitationModel
    {
        public string Inviter { get; set; }
        public string BookName { get; set; }
        public int UnreadNotifications { get; set; }
        public int InvitationListId { get; set; }
        public int Status { get; set; }
        public int NotificationId { get; set; }
        public int PageId { get; set; }
        public string QuestionerName { get; set; }
        public string QuestionerImage { get; set; }
        public string BookSubmitter { get; set; }
        public string CreatedDate { get; set; }
        public string Question { get; set; }
        public int AnswerId { get; set; }
        public string DateAccepted { get; set; }
        public string InviterImage { get; set; }
        public string FriendRequestId { get; set; }
        public string Answer { get; set; }
        public int BookId { get; set; }

        public string createdon { get; set; }

    }

    public class MakePaymentModel
    {
        [Required(ErrorMessage = "First Name")]
        public string FristName { get; set; }
        [Required(ErrorMessage = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Credit Card Number")]
        public string CreditCardNumber { get; set; }
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Min 3 Digits or Max 4 Digits")]
        [Required(ErrorMessage = "CVV")]
        public string CVV { get; set; }
        public List<Month> Monthlist { get; set; }
        public List<Year> Yearlist { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal AmountPaid { get; set; }
        public string MerchantId { get; set; }
        public string RedirectUrl { get; set; }
        public string CancelUrl { get; set; }
       
        
    }

    public class Month
    {
        public int ID { get; set; }
        public string MonthName { get; set; }
    }
    public class Year
    {
        public int ID { get; set; }
        public string YearName { get; set; }
    }

    public class FileUpload
    {
        public string ImageName { get; set; }
        public string ImageData{ get; set; }
    }

}