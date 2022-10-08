using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.User
{
    public class UsersInfoBase
    {

        private bool _isActive = false;
        private bool _isPasswordReset = false;
        private int _categoryId = 0;
        private int _chapterId = 0;
        private int _cityId = 0;
        private int _collegeId = 0;
        private int _countryId = 0;
        private int _stateId = 0;
        private int _requestStatus = 0;
        private int _counts = 0;

        private int _topicId = 0;
        private int _entranceExamId = 0;
        private int _examStreamId = 0;
        private string _position = string.Empty;
        private int _streamId = 0;
        private int _subjectId = 0;
        private Int64 _id = 0;
        private string _aTMNumber = string.Empty;
        private string _createdDate = string.Empty;
        private string _date = string.Empty;
        private string _emailId = string.Empty;
        private string _mobileNumber = string.Empty;
        private string _isdCode = string.Empty;
        private string _modifiedDate = string.Empty;
        private string _nameOnATMCard = string.Empty;
        private string _noteBooksFrontCoverImage = string.Empty;
        private string _password = string.Empty;
        private string _passwordResetToken = string.Empty;
        private string _profileImage = string.Empty;
        private string _coverImage = string.Empty;
        private string _studentName = string.Empty;
        private string _teacherName = string.Empty;
        private int _userRole = 0;
        private int _OTP = 0;

        private string _instituteName = string.Empty;
        private string _subjectName = string.Empty;
        private string _categoryName = string.Empty;
        private string _streamName = string.Empty;
        private int _invitedUserId = 0;
        private string _dOB = string.Empty;
        private string _gender = string.Empty;

        private string _instituteType = "old";
        private string _categoryType = "old";
        private string _streamType = "old";
        private string _subjectType = "old";
        private string _lastName = string.Empty;
        private string _firstName = string.Empty;
        private string _Address = string.Empty;
        private string _countryname = string.Empty;
        private string _statename = string.Empty;
        private string _cityname = string.Empty;

        public int Counts { get { return _counts; } set { _counts = value; } }
        public int InvitedUserId { get { return _invitedUserId; } set { _invitedUserId = value; } }
        public string StreamName { get { return _streamName; } set { _streamName = value; } }
        public string CategoryName { get { return _categoryName; } set { _categoryName = value; } }
        public string SubjectName { get { return _subjectName; } set { _subjectName = value; } }
        public string InstituteName { get { return _instituteName; } set { _instituteName = value; } }
        public string DOB { get { return _dOB; } set { _dOB = value; } }
        public string Gender { get { return _gender; } set { _gender = value; } }

        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public bool IsPasswordReset { get { return _isPasswordReset; } set { _isPasswordReset = value; } }
        public int CategoryId { get { return _categoryId; } set { _categoryId = value; } }
        public int ChapterId { get { return _chapterId; } set { _chapterId = value; } }
        public int CityId { get { return _cityId; } set { _cityId = value; } }
        public int CollegeId { get { return _collegeId; } set { _collegeId = value; } }
        public int CountryId { get { return _countryId; } set { _countryId = value; } }
        public int StateId { get { return _stateId; } set { _stateId = value; } }

        public int TopicId { get { return _topicId; } set { _topicId = value; } }
        public int EntranceExamId { get { return _entranceExamId; } set { _entranceExamId = value; } }
        public int ExamStreamId { get { return _examStreamId; } set { _examStreamId = value; } }


        public int StreamId { get { return _streamId; } set { _streamId = value; } }
        public int SubjectId { get { return _subjectId; } set { _subjectId = value; } }
        public Int64 Id { get { return _id; } set { _id = value; } }
        public string ATMNumber { get { return _aTMNumber; } set { _aTMNumber = value; } }
        public string CreatedDate { get { return _createdDate; } set { _createdDate = value; } }
        public string Date { get { return _date; } set { _date = value; } }
        public string EmailId { get { return _emailId; } set { _emailId = value; } }
        public string MobileNumber { get { return _mobileNumber; } set { _mobileNumber = value; } }
        public string ISD_Code { get { return _isdCode; } set { _isdCode = value; } }
        public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
        public string NameOnATMCard { get { return _nameOnATMCard; } set { _nameOnATMCard = value; } }
        public string NoteBooksFrontCoverImage { get { return _noteBooksFrontCoverImage; } set { _noteBooksFrontCoverImage = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string PasswordResetToken { get { return _passwordResetToken; } set { _passwordResetToken = value; } }
        public string ProfileImage { get { return _profileImage; } set { _profileImage = value; } }
        public string CoverImage { get { return _coverImage; } set { _coverImage = value; } }
        public string Position { get { return _position; } set { _position = value; } }
        public string StudentName { get { return _studentName; } set { _studentName = value; } }
        public int OTP { get { return _OTP; } set { _OTP = value; } }
        public string TeacherName { get { return _teacherName; } set { _teacherName = value; } }
        public int UserRole { get { return _userRole; } set { _userRole = value; } }
        public int RequestStatus { get { return _requestStatus; } set { _requestStatus = value; } }
        public string Guid { get; set; }
        public int userId { get; set; }

        public string InstituteType { get { return _instituteType; } set { _instituteType = value; } }
        public string CategoryType { get { return _categoryType; } set { _categoryType = value; } }
        public string StreamType { get { return _streamType; } set { _streamType = value; } }
        public string SubjectType { get { return _subjectType; } set { _subjectType = value; } }

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string RegistrationToken { get; set; }

        public string AndroidDeviceId { get; set; }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string countryname { get { return _countryname; }set { _countryname = value; } }
        public string statename { get { return _statename; } set { _statename = value; } }
          public string cityname { get { return _cityname; } set { _cityname = value; } }

    }


}
