using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.Questions
{
    public class QuestionsBase
    {
        private Int64 _id = 0;
        private Int64 _pageId = 0;
        private Int64 _userId = 0;
        private Int64 _bookId = 0;
        private string _createdDate = string.Empty;
        private string _modifiedDate = string.Empty;
        private string _questionImage = string.Empty;
        private string _questionTitle = string.Empty; 


        public Int64 Id { get { return _id; } set { _id = value; } }
        public Int64 PageId { get { return _pageId; } set { _pageId = value; } }
        public Int64 UserId { get { return _userId; } set { _userId = value; } }
        public Int64 BookId { get { return _bookId; } set { _bookId = value; } }
        public string CreatedDate { get { return _createdDate; } set { _createdDate = value; } }
        public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
        public string QuestionImage { get { return _questionImage; } set { _questionImage = value; } }
        public string QuestionTitle { get { return _questionTitle; } set { _questionTitle = value; } }
        
    }
}
