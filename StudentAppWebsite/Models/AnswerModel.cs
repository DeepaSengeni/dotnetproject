using STU.BaseLayer.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAppWebsite.Models
{
    public class AnswerModel : AnswersBase
    {
        public List<AnswerModel> AnswersList { get; set; }
        public string StudentName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 IsOnline { get; set; }
        public Int32 UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int32 AnswerParentId { get; set; }

    }
   
}