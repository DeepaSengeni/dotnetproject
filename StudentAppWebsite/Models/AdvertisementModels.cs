using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentAppWebsite.Models
{
    public class AdvertisementModels
    {
        public int adcreationId { get; set; }
        public int pageId { get; set; }
        public int bookId { get; set; }
        public int uploadtype { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Headline cannot be longer than 40 characters.")]
        public string headline { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Features cannot be longer than 100 characters.")]
        public string Features { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Headline cannot be longer than 150 characters.")]
        public string description { get; set; }

        //[RegularExpression(@"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$", ErrorMessage = "Please specify complete url address.The correct format is http://domain.com")]
        [RegularExpression(@"^[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$", ErrorMessage = "Please specify complete url address.The correct format is 'domain.com'")]
        public string urladdress { get; set; }
        [Required]
        public string price { get; set; }
        [Required]
        public string startdate { get; set; }
        [Required]
        public string enddate { get; set; }

        public List<Country> Countrylist { get; set; }
        public List<City> citylist { get; set; }
        public List<State> statelist { get; set; }
        public List<Categories> CategoryList { get; set; }
        public List<PaypalResponse> PaypalResponseList { get; set; }

        [Required(ErrorMessage = "Advertiser's Email Id is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        public string AdvertiserEmialId { get; set; }
        [Required(ErrorMessage = "Advertiser's Mobile Number is required")]
        public string AdvertiserMobileNumber { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int Country { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Category is required")]
        public string CategoryName { get; set; }

        public string NumberOfDays { get; set; }
        public decimal AmountPaid { get; set; }

        public decimal AmountToBePaid { get; set; }
        public string PurchasedCategory { get; set; }

        public IEnumerable<SelectListItem> CategoryListItem { get; set; }
        public string MobileNumber { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Account number must be a number")]
        [Required(ErrorMessage = "Account Number is required")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "IFSC code is required")]
        public string IFSCCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Currency { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public List<AdvertisementModels> PaymentList { get; set; }
        public int Status { get; set; }
        public DateTime RequestDate { get; set; }

        public string EmailId { get; set; }
        public int ClicksCount { get; set; }

        public decimal AmountRequested { get; set; }

        public int Id { get; set; }
        public string Categories { get; set; }

        [Required(ErrorMessage = "Account Holder Name is required")]
        public string AccountHolderName { get; set; }

        public List<AdvertisementModels> AdvertismentList { get; set; }
        
        public decimal WalletAmount { get; set; }
        public string ClickDate { get; set; }
        public string ClickedBy { get; set; }
        public string ClickTime { get; set; }
        public string ClickedOn { get; set; }
        public decimal UnitPrice { get; set; }
        public List<AdvertisementModels> AdvertiseList = new List<AdvertisementModels>();
        public List<AdvertisementModels> PageListClick = new List<AdvertisementModels>();
        
    }

    public class PicuploadedModel
    {
        public HttpPostedFileBase[] fileuploader { get; set; }
        public string[] FileUploadedPath { get; set; }
    }
}
