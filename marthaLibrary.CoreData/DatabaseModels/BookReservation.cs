using marthaLibrary.CoreData.Base;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class BookReservation: BaseEntity<long>
    {
        public Guid UserId { get; set; }
        public long BookId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
