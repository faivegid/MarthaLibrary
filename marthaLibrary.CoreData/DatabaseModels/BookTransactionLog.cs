using marthaLibrary.CoreData.Base;
using marthaLibrary.CoreData.Enums;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class BookTransactionLog : BaseEntity<long>
    {
        public TransactionType TransactionType { get; set; }
        public string UserEmail { get; set; }
        public long BookId { get; set; }
        public string BookName { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
