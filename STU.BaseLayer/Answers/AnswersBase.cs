using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.Answers
{
    public class AnswersBase
    {

        private Int64 _id = 0;
        private Int64 _questionId = 0;
        private Int64 _userId = 0;
        private string _answer = string.Empty;
        private string _answerImage = string.Empty;
        private string _createdDate = string.Empty;
        private string _modifiedDate = string.Empty;
        private string _questionTitle = string.Empty;
        public int _PageId = 0;
        public int _replyanswerid = 0;


        public Int64 Id { get { return _id; } set { _id = value; } }
        public Int64 QuestionId { get { return _questionId; } set { _questionId = value; } }
        public Int64 UserId { get { return _userId; } set { _userId = value; } }
        public string Answer { get { return _answer; } set { _answer = value; } }
        public string AnswerImage { get { return _answerImage; } set { _answerImage = value; } }
        public string CreatedDate { get { return _createdDate; } set { _createdDate = value; } }
        public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
        public string QuestionTitle { get { return _questionTitle; } set { _questionTitle = value; } }
        public int PageID{ get { return _PageId; } set { _PageId = value; } }
        public int ReplyAnswerId { get { return _replyanswerid; } set { _replyanswerid = value; } }
    }
}
