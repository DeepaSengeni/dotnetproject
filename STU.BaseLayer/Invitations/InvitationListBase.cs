using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.Invitations
{
    public class InvitationListBase
    {

        private Int64 _id = 0;
        private Int64 _invitedUserId = 0;
        private Int64 _userId = 0;
        private string _createdDate = string.Empty;
        private string _modifiedDate = string.Empty;
        private Int64 _questionID = 0;
        private int _pageId = 0;




        public Int64 Id { get { return _id; } set { _id = value; } }
        public Int64 InvitedUserId { get { return _invitedUserId; } set { _invitedUserId = value; } }
        public Int64 UserId { get { return _userId; } set { _userId = value; } }
        public string CreatedDate { get { return _createdDate; } set { _createdDate = value; } }
        public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
        public Int64 QuestionID { get { return _questionID; } set { _questionID = value; } }
        public int PageId { get { return _pageId; } set { _pageId = value; } }
        
        
    }
}
