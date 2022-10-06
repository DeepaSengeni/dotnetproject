using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.Pages
{
    public class PagesBase
    {
        

        private int _displayOrder = 0;
       
        private Int64 _bookId = 0;
        private Int64 _id = 0;
        private string _pageTitle = string.Empty;
        
        private string _createdDate = string.Empty;
        private string _modifiedDate = string.Empty;
        private string _pageImage = string.Empty;
        private string _chapterName = string.Empty;

        public int DisplayOrder { get { return _displayOrder; } set { _displayOrder = value; } }
        
        public Int64 BookId { get { return _bookId; } set { _bookId = value; } }
        public Int64 Id { get { return _id; } set { _id = value; } }
        public string PageTitle { get { return _pageTitle; } set { _pageTitle = value; } }

        
        public string CreatedDate { get { return _createdDate; } set { _createdDate = value; } }
        public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
        public string PageImage { get { return _pageImage; } set { _pageImage = value; } }
        public string ChapterName { get { return _chapterName; } set { _chapterName = value; } }

      
        public string CountyName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public int UserId { get; set; }
    }
}
