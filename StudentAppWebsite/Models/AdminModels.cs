using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace StudentAppWebsite.Models
{
    public class AdminModels
    {



    } 

    public class Categories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public string MobileNumber { get; set; }

        public int adcreationId { get; set; }
        public int aduploadedId { get; set; }
        public int Type { get; set; } 
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FileUploaded { get; set; }
        public string FileName { get; set; }
        public string StudentName { get; set; }
        public string Headline { get; set; }

        public string Description { get; set; }
        public string Features { get; set; }
        public string UrlAddress { get; set; }
        public int UserId { get; set; }

        public List<Categories> CategoryList { get; set; }
    }
    public class Stream
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string StreamCategory { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Stream Name is Required")]
        public string StreamName { get; set; }
        public string Details { get; set; }

        [Required(ErrorMessage = "Picture is required")]
        public string StreamIcon { get; set; }
        public bool Status { get; set; }
        public List<Stream> CategoryList { get; set; }
        public List<Stream> StreamList { get; set; }
    }

    public class Institute
    {
        private string _Address = string.Empty;
        private string _Email = string.Empty;
        private string _ContactNo = string.Empty;
        private string _zipcode = string.Empty;
        private string _AlternateContactNo = string.Empty;
        private string _Website = string.Empty;
        private string _FaxNo = string.Empty;
        private string _InstituteLogo = string.Empty;
        


        public int Id { get; set; }
        [Required(ErrorMessage = "Institute Name is Required")]
        public string InstituteName { get; set; }

        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Stream Name is Required")]
        public string StreamName { get; set; }


        public string InstituteLogo { get { return _InstituteLogo; } set { _InstituteLogo = value; } }



        public string Address { get { return _Address; } set { _Address = value; } }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        public string Email { get { return _Email; } set { _Email = value; } }
        public string ContactNo { get { return _ContactNo; } set { _ContactNo = value; } }
        public string Zipcode { get { return _zipcode; } set { _zipcode = value; } }
        public string AlternateContactNo { get { return _AlternateContactNo; } set { _AlternateContactNo = value; } }
        public string FaxNo { get { return _FaxNo; } set { _FaxNo = value; } }
        [Required(ErrorMessage = "Website is Required")]
        [RegularExpression(@"((www\.|(http|https|ftp|news|file|)+\:\/\/)?[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", ErrorMessage = "website is not in correct format")]
        public string Website { get { return _Website; } set { _Website = value; } }



        public bool Status { get; set; }



        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public List<Institute> CategoryList { get; set; }
        public List<Institute> StreamList { get; set; }
        public List<Institute> InstituteList { get; set; }
        public List<Country> Countrylist { get; set; }
        public List<City> citylist { get; set; }
        public List<State> statelist { get; set; }
    }

    public class Subjects
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please choose a stream.")]
        public int StreamId { get; set; }
        public string StreamName { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        public string SubjectName { get; set; }
        public string Details { get; set; }
        public bool Status { get; set; }
        public bool IsChecked { get; set; }
    }

    public class Submitter
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public List<Submitter> SubmitterList { get; set; }

        public string RegistrationToken { get; set; }

        public string BookSubmitter { get; set; }

        public string BookName { get; set; }
    }


    public class Reader
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public List<Reader> ReaderList { get; set; }

    }

    public class Messages
    {
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        [RegularExpression(@"^(\+91|0|91)?\d{10}$", ErrorMessage = "Please Enter valid Phone number")]
        [Required(ErrorMessage = "Mobile No is required")]
        public string MobileNo { get; set; }
        public int Id { get; set; }

        public List<Messages> MessageList { get; set; }
        public int count { get; set; }

    }
    public class PaypalResponse
    {
        public int userId { get; set; }
        public string Add_Id { get; set; }
        public decimal amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public string paymentId { get; set; }
        public string totalammount { get; set; }
        public string Currency { get; set; }
        public string Payer_id { get; set; }
        public string intent { get; set; }
        public string state { get; set; }

        public List<PaypalResponse> PaypalResponseList { get; set; }
    }
}