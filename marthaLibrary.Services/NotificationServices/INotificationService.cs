using marthaLibrary.CoreData.DatabaseModels;

namespace marthaLibrary.Services.NotificationServices
{
    public interface INotificationService
    {
        void SendBulkNotifcation(IEnumerable<Notification> notifications);
        void SendSingleNotifcation(Notification notify);
    }
}