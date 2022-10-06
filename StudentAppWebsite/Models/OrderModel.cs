using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAppWebsite.Models
{
    public class OrderModel
    {
        public string orderId { get; set; }
        public string razorpayKey { get; set; }
        public decimal amount { get; set; }
        public decimal amountc { get; set; }
        public string currency { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contactNumber { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string citynamedata { get; set; }
        public string dev_noofdays { get; set; }
        public string dev_invoiceid { get; set; }
        public string customer_id { get; set; }
    }
}