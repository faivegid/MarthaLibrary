using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.NotificationRepo
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetUnNotifiedNotifcations(long bookId);
    }
}