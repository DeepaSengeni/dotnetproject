using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.Book
{
   public class BookBase
   {
       #region Declaration
       private int _countryId = 0;
       private int _stateId = 0;
       private int _chapterId = 0;
       private int _entranceExamId = 0;
       private int _examStreamId = 0;
       private int _subjectId = 0;
       private int _pageno = 0;
       private Int64 _id = 0;
       private Int64 _bookid = 0;
       private Int64 _userId = 0;
       private int _totalPages = 0;
       private string _bookType = string.Empty;
       private string _studentName = string.Empty;
       private string _teachersName = string.Empty;
       private string _chapterName = string.Empty;
       private string _content = string.Empty;
       private bool _isHtml = false;
       private string _screenShot = string.Empty;

       private string _backPageImage = string.Empty;
       private string _bookTitle = string.Empty;
       private string _coverPageImage = string.Empty;
       private string _createdDate = string.Empty;
       private string _modifiedDate = string.Empty;
        private string _device = string.Empty;
       public int TotalPages { get { return _totalPages; } set { _totalPages = value; } }
       public string BookType { get { return _bookType; } set { _bookType = value; } }
       public string StudentName { get { return _studentName; } set { _studentName = value; } }
       public string TeachersName { get { return _teachersName; } set { _teachersName = value; } }
       public string Content { get { return _content; } set { _content = value; } }
       public string ChapterName { get { return _chapterName; } set { _chapterName = value; } }

      

       #endregion

       #region Properties
       public int CountryId { get { return _countryId; } set { _countryId = value; } }
       public int StateId { get { return _stateId; } set { _stateId = value; } }
        public int ChapterId { get { return _chapterId; } set { _chapterId = value; } }
        public int EntranceExamId { get { return _entranceExamId; } set { _entranceExamId = value; } }
        public int ExamStreamId { get { return _examStreamId; } set { _examStreamId = value; } }
        public int SubjectId { get { return _subjectId; } set { _subjectId = value; } }
        public Int64 Id { get { return _id; } set { _id = value; } }
        public Int64 BookId { get { return _bookid; } set { _bookid = value; } }
        public int PageNumber { get { return _pageno; } set { _pageno = value; } }
        public Int64 UserId { get { return _userId; } set { _userId = value; } }
        public string BackPageImage { get { return _backPageImage; } set { _backPageImage = value; } }
        public string BookTitle { get { return _bookTitle; } set { _bookTitle = value; } }
        public string CoverPageImage { get { return _coverPageImage; } set { _coverPageImage = value; } }
        public string CreatedDate { get { return _createdDate; } set { _createdDate = value; } }
        public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
        public bool IsHtml { get { return _isHtml; } set { _isHtml = value; } }
        public string ScreenShot { get { return _screenShot; } set { _screenShot = value; } }
        public string Device { get { return _device; } set { _device = value; } }
        public string PageType { get; set; }
       #endregion
   }

   public class BooksRatingBase
   {
       #region Declaration
       private float _rate = 0;
       private Int64 _bookId = 0;
       private Int64 _id = 0;
       private Int64 _userId = 0;
       private string _comment = string.Empty;
       private string _createdDate = string.Empty;
       private string _modifiedDate = string.Empty;
       private string _action = string.Empty;
       #endregion

       #region Properties
       public float Rate { get { return _rate; } set { _rate = value; } }
       public Int64 BookId { get { return _bookId; } set { _bookId = value; } }
       public Int64 Id { get { return _id; } set { _id = value; } }
       public Int64 UserId { get { return _userId; } set { _userId = value; } }
       public string Comment { get { return _comment; } set { _comment = value; } }
       public string CreatedDate { get { return _createdDate; } set { _createdDate = value; } }
       public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
       public string Action { get { return _action; } set { _action = value; } }
       #endregion
   }


   public class checkoutbase
   {
       public int AdId { get; set; }
       private string _Deliveryaddress = string.Empty;

       public string Deliveryaddress
       {
           get { return _Deliveryaddress; }
           set { _Deliveryaddress = value; }
       }

       private string _Deliverycontact = string.Empty;

       public string Deliverycontact
       {
           get { return _Deliverycontact; }
           set { _Deliverycontact = value; }
       }

       private string _status = string.Empty;

       private string _response = string.Empty;

       public string Status
       {
           get { return _status; }
           set { _status = value; }
       }
       private string _payeremail = string.Empty;

       public string Payeremail
       {
           get { return _payeremail; }
           set { _payeremail = value; }
       }
       private string _apiId = string.Empty;

       public string ApiId
       {
           get { return _apiId; }
           set { _apiId = value; }
       }

       public string reciephtml { get; set; }

       public string partialreciephtml { get; set; }

       private string _products = string.Empty;
       private DateTime _expiryDate;

       public DateTime ExpiryDate
       {
           get { return _expiryDate; }
           set { _expiryDate = value; }
       }
       private string _cVV = string.Empty;
       private string _createDate = string.Empty;
       private string _cardNumber = string.Empty;
       private int _userId = 0;
       private string _transactionId = string.Empty;
       private decimal _totalAmount = 0;
       private string _xmlString = string.Empty;
       private string _selectedBooks = string.Empty;

       public decimal TotalAmount
       {
           get { return _totalAmount; }
           set { _totalAmount = value; }
       }
       public string Products { get { return _products; } set { _products = value; } }
       public string Response { get { return _response; } set { _response = value; } }
       public string CVV { get { return _cVV; } set { _cVV = value; } }
       public string CreateDate { get { return _createDate; } set { _createDate = value; } }
       public string CardNumber { get { return _cardNumber; } set { _cardNumber = value; } }
       public int UserId { get { return _userId; } set { _userId = value; } }
       public string TransactionId { get { return _transactionId; } set { _transactionId = value; } }
       public string XmlString { get { return _xmlString; } set { _xmlString = value; } }
       public string SelectedBooks { get { return _selectedBooks; } set { _selectedBooks = value; } }

       private string _customerName = string.Empty;
       private string _zipCode = string.Empty;
       private int _city = 0;
       private int _state = 0;
       public string CustomerName { get { return _customerName; } set { _customerName = value; } }
       public string ZipCode { get { return _zipCode; } set { _zipCode = value; } }
       public int City { get { return _city; } set { _city = value; } }
       public int State { get { return _state; } set { _state = value; } }

       public string OrderId { get; set; }
        

   }

}
