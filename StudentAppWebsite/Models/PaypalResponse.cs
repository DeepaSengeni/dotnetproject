using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAppWebsite.Models
{
    public class PaypalResponsenew
    {
        public int userId { get; set; }
        public string paymentId { get; set; }
        public string totalammount { get; set; }
        public string Currency { get; set; }
        public string Payer_id { get; set; }
        public string intent { get; set; }
        public string state { get; set; }
    }
}