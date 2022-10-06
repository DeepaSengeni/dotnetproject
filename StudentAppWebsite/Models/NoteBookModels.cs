using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAppWebsite.Models
{
    public class NoteBookModels
    {
        public int BookId { get; set; }
        public int StreamId { get; set; }
        public int UserId { get; set; }
        public int MonetoryAdvantages { get; set; }
        public int Innovation_Investment { get; set; }
        public int Visible_Hidden { get; set; }
        public string SubjectName { get; set; }
        public DateTime StartDate { get; set; }
        public string NewSubject { get; set; }

    }
}