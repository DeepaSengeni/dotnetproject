using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAppWebsite.Models
{
    public class ApiResponseModel
    {
        public bool IsSuccess { get;set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public string ResponseData { get; set; }
        
    }
}