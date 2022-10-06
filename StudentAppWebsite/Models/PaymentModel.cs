using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentAppWebsite.Models
{
    public class PaymentModel
    {
        //public PaymentModel()
        //{
        //    MonthList = new List<SelectListItem>();
        //    YearList = new List<SelectListItem>();
        //}

        [DisplayName("Month")]
        public List<SelectListItem> MonthList
        {
            get;
            set;
        }

        [Display(Name = "Months")]
        public string MonthLable { get; set; }

        public string Month { get; set; }
        public string Year { get; set; }

        [Display(Name = "Year")]
        public string YearLabel { get; set; }
        //public class Month
        //{
        //    public int ID { get; set; }
        //    public string MonthName { get; set; }
        //}
    }

}
