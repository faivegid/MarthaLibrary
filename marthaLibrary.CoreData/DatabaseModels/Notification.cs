using marthaLibrary.CoreData.Base;
using marthaLibrary.CoreData.Enums;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class Notification: BaseEntity<long>
    {
        public string UserEmail { get; set; }
        public long BookId { get; set; }
        public string BookName { get; set; }
        public NotificationStatus NotificationStatus { get; set; }
    }
}
