using marthaLibrary.CoreData.Base;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class BorrowedBook : BaseEntity<long>
    {
        public Guid UserId { get; set; }
        public long BookId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
