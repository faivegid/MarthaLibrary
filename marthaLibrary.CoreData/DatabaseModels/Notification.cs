using marthaLibrary.CoreData.Base;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class Notification: BaseEntity<long>
    {
        public long StoredId { get; set; }
        public bool IsReservation { get; set; }
        public Guid UserId { get; set; }
        public long BookId { get; set; }
    }
}
