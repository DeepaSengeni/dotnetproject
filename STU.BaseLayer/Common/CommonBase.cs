using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.Common
{
    public class CommonBase
    {
        #region Declaration
        private int _id = 0;
        private int _ID = 0;
        private int _userid = 0;
        private string _password = string.Empty;
        private string _chapterId = string.Empty;
        private int _streamId = 0;
        private int _categoryId = 0;
        private int _countryId = 0;
        private int _stateId = 0;
        private string _categoryName = string.Empty;
        private bool _Status = false;
        private string _action = string.Empty;
        private string _streamCategory = string.Empty;
        private string _streamName = string.Empty;
        private string _streamIcon = string.Empty;
        private string _subjectName = string.Empty;
        private string _details = string.Empty;
        private int _NotebookId = 0;
        private string _Address = string.Empty;
        private string _Email = string.Empty;
        private string _ContactNo = string.Empty;
        private string _isdCode = string.Empty;
        private string _zipcode = string.Empty;
        private string _AlternateContactNo = string.Empty;
        private string _Website = string.Empty;
        private string _FaxNo = string.Empty;
        private string _InstituteId = string.Empty;
        private string _SubjectId = string.Empty;
        private decimal _price = 0;
        private string _cvv = string.Empty;
        private string _expiryMonth = string.Empty;
        private string _expiryYear = string.Empty;
        private decimal _Rate = 0;
        //private int _pageNo = 0;
        private int _offset = 0;
        private string _tittle = string.Empty;
        private string _description = string.Empty;
        //private string _paymentId = string.Empty;
        //private string _totalammount = string.Empty;
        //private string _Currency = string.Empty;
        //private string _Payer_id = string.Empty;
        //private string _intent = string.Empty;
        //private string _state = string.Empty;
        #endregion

        #region Properties
        public int Id { get { return _id; } set { _id = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string ChapterId { get { return _chapterId; } set { _chapterId = value; } }
        public int UserId { get { return _userid; } set { _userid = value; } }
        public int CountryId { get { return _countryId; } set { _countryId = value; } }
        public int StateId { get { return _stateId; } set { _stateId = value; } }
        public int SteamId { get { return _streamId; } set { _streamId = value; } }
        public int NotebookId { get { return _NotebookId; } set { _NotebookId = value; } }
        public int CategoryId { get { return _categoryId; } set { _categoryId = value; } }
        public string CategoryName { get { return _categoryName; } set { _categoryName = value; } }
        public bool Status { get { return _Status; } set { _Status = value; } }
        public string StreamCategory { get { return _streamCategory; } set { _streamCategory = value; } }
        public string StreamName { get { return _streamName; } set { _streamName = value; } }
        public string StreamIcon { get { return _streamIcon; } set { _streamIcon = value; } }
        public string Action { get { return _action; } set { _action = value; } }
        public string SubjectName { get { return _subjectName; } set { _subjectName = value; } }
        public string Details { get { return _details; } set { _details = value; } }
        public string InstituteName { get; set; }
        public string InstituteIcon { get; set; }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string ContactNo { get { return _ContactNo; } set { _ContactNo = value; } }
        public string ISD_Code { get { return _isdCode; } set { _isdCode = value; } }
        public string Zipcode { get { return _zipcode; } set { _zipcode = value; } }
        public string AlternateContactNo { get { return _AlternateContactNo; } set { _AlternateContactNo = value; } }
        public string FaxNo { get { return _FaxNo; } set { _FaxNo = value; } }
        public string Website { get { return _Website; } set { _Website = value; } }
        public string InstituteId { get { return _InstituteId; } set { _InstituteId = value; } }
        public string SubjectId { get { return _SubjectId; } set { _SubjectId = value; } }
        public decimal Price { get { return _price; } set { _price = value; } }
        
        public int ID { get { return _ID; } set { _ID = value; } }
        public decimal Rate { get { return _Rate; }set { _Rate = value; } }
        public int? CityId { get; set; }
        public int StreamId { get; set; }
        //public int NotebookId { get; set; }

        public string Type { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime StartDate { get; set; }
        public string ChapterName { get; set; }
        public string TeacherName { get; set; }
        public string Text { get; set; }
        public int PageNo { get; set; }

        public string CVV { get { return _cvv; } set { _cvv = value; } }
        public string ExpiryYear { get { return _expiryYear; } set { _expiryYear = value; } }
        public string ExpiryMonth { get { return _expiryMonth; } set { _expiryMonth = value; } }
        public int Innovation_Investment { get; set; }
        public int Visible_Hidden { get; set; }
        public int MonetoryAdvantages { get; set; }

        //public int PageNo { get { return _pageNo; } set { _pageNo = value; } }
        public int Offset { get { return _offset; } set { _offset = value; } }
        //public string paymentId { get { return _paymentId; } set { _paymentId = value; } }
        //public string totalammount { get { return _totalammount; } set { _totalammount = value; } }
        //public string Currency { get { return _Currency; } set { _Currency = value; } }
        //public string Payer_id { get { return _Payer_id; } set { _Payer_id = value; } }
        //public string intent { get { return _intent; } set { _intent = value; } }
        //public string state { get { return _state; } set { _state = value; } }
        #endregion
        public string Tittle { get { return _tittle; } set { _tittle = value; } }
        public string Description { get { return _description; } set { _description = value; } }
    }

    public class CommonMastersBase
    {
        #region Declaration

        private int _id = 0;
        private string _name = string.Empty;
        private string _type = string.Empty;
        #endregion

        #region Properties

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Type { get { return _type; } set { _type = value; } }

        #endregion
    }


}
