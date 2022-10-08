using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using STU.BaseLayer.Questions;
using System.ComponentModel.DataAnnotations;

namespace StudentAppWebsite.Models
{
    public class QuestionModel : QuestionsBase
    {
        public List<QuestionModel> QuestionsList { get; set; }
        public List<AnswerModel> AnswersList { get; set; }
        public List<AnswerModel> ReplyAnswersList { get; set; }

        public List<Friend> FriendRequests = new List<Friend>();
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int UserId { get; set; }
        public string ProfileImage { get; set; }
        public string Answer { get; set; }
        public int RepliedUserId { get; set; }
        public string RepliedUserImage { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "EmailID is not in correct format")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public int PageId { get; set; }
        public string EditQuestion { get; set; }
        public string StudentName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 IsOnline { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int32 AnswerParentId { get; set; }
        public Int32 Answerid { get; set; }
    }
}