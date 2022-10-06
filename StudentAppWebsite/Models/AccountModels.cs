using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace StudentAppWebsite.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        [Required(ErrorMessage = "Username is required ")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }

    public class StudentRegistration
    {

        [Required(ErrorMessage = "Student Name is required")]
        public string StudentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Picture is required")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Teacher Name is required")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "College Name is required")]
        public int CollegeName { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public int Country { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Stream is required")]
        public string Stream { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "Subjects is required")]
        public string Subjects { get; set; }

        [Required(ErrorMessage = "Chapters is required")]
        public string Chapters { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Email ID is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string OTP { get; set; }
        public List<Country> Countrylist { get; set; }
        public List<City> citylist { get; set; }
        public List<State> statelist { get; set; }
        public List<College> CollegeList { get; set; }
        public List<Institute> InstituteList { get; set; }
        public List<Stream> StreamList { get; set; }
        public List<Subjects> SubjectsList { get; set; }
        public List<Chapters> ChaptersList { get; set; }
        public List<Categories> CategoryList { get; set; }
        public List<NotebookForm> NotebookFormList { get; set; }
        public List<CurrencyRate> currencyRates { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public int NotebookId { get; set; }
        public List<StudentRegistration> DownloadedDataList { get; set; }
        public string Content { get; set; }
        public string InstituteName { get; set; }
        // public bool IsChecked { get; set; }
        public List<HomeModel> HomeList { get; set; }
        public List<InstituteModel> instituteNewList { get; set; }
        public string PageImage { get; set; }
        public bool IsHtml { get; set; }
        public bool Status { get; set; }
        public string SubjectName { get; set; }
        public string SubmitterPic { get; set; }
    }


    public class SubmitterRegistration
    {

        [Required(ErrorMessage = "Student Name is required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Picture is required")]
        public string Picture { get; set; }



        [Required(ErrorMessage = "Country is required")]
        public int Country { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        // [RegularExpression(@"^[0-9]", ErrorMessage = "Please enter only digits")]
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Email ID is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$", ErrorMessage = "EmailID is not in correct format")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "ISD Code is required")]
        public string ISD_Code { get; set; }
      
      
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string OTP { get; set; }
        [Required]
        public string Address { get; set; }
        public List<Country> Countrylist { get; set; }
        public List<City> citylist { get; set; }
        public List<State> statelist { get; set; }
        public List<College> CollegeList { get; set; }
        public List<InstituteModel> InstituteModelList { get; set; }
        public List<Stream> StreamList { get; set; }
        public List<Gender> GenderList { get; set; }
        public List<PayPalEmail> PayPalEmailList { get; set; }
        public List<Wallet> WalletList { get; set; }
        public List<AddList> AddLists { get; set; }


        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        [Required(ErrorMessage = "Username is required ")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        public string DOB { get; set; }
        [Required(ErrorMessage = "College is required")]
        public int CollegeID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool Rememberme { get; set; }

    }
    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
    public class ResetPassword
    {
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        [Required(ErrorMessage = "Email ID is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password and confirmation password do not match.")]
        [Required(ErrorMessage = "New Password is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
        public string Guid { get; set; }
    }
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string currencycode { get; set; }
    }

    public class State
    {
        public int ID { get; set; }
        public string StateName { get; set; }
    }
    public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public bool IsChecked { get; set; }
        public decimal Price { get; set; }


    }

    public class College
    {
        public int ID { get; set; }
        public string CollegeName { get; set; }
        public bool Status { get; set; }
    }

    public class Chapters
    {
        public int ID { get; set; }
        public string ChapterName { get; set; }
        public bool IsChecked { get; set; }
    }


    public class HomeModel
    {
        public int Id { get; set; }
        public string StreamName { get; set; }
        public bool Status { get; set; }
    }

    public class InstituteModel
    {
        public int Id { get; set; }
        public string InstituteName { get; set; }
        public bool Status { get; set; }
    }
    public class Gender
    {
        public int ID { get; set; }
        public string GenderName { get; set; }
    }
    public class CurrencyRate
    {
        public int ID { get; set; } 
        public string CurrencyCode { get; set; }       
        public decimal Rate { get; set; }
        public string Country { get; set; }
        public string code { get; set; }
        public string symbol { get; set; }
        public string currency_symbole { get; set; }
        public int Countryunicode { get; set; }
    }
    public class PayPalEmail
    {
        public int UserId { get; set; }
        public string PaypalEmail { get; set; }
    }
    public class Wallet
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set;}
        public int ClickCount { get; set; }
    }
    public class AddList
    {
        public int CityId { get; set; }
        public string Startdate { get; set; }
        public string Enddate { get; set; }

    }

    

}
