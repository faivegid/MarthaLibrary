using marthaLibrary.CoreData.Base;
using marthaLibrary.CoreData.Enums;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class Book : BaseEntity<long>
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public BookStatus Status { get; set; }
        public string FrontPagePicUrl { get; set; }
    }
}
