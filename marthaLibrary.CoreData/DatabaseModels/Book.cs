using marthaLibrary.CoreData.Base;
using marthaLibrary.CoreData.Enums;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class Book : BaseEntity<long>
    {
        public string BookName { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public BookStatus Status { get; set; }
        public string FrontPagePicUrl { get; set; }
        public int NoOfPages { get; set; }
        public string Langauge { get; set; }
        public string ISBN { get; set; }
        public string Format { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
