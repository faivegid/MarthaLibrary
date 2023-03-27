using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;
using Microsoft.EntityFrameworkCore;

namespace marthaLibrary.Repos.NotificationRepo
{
    internal class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetUnNotifiedNotifcations(long bookId)
        {
            var notifications = await (from notify in dbSet
                                       where notify.NotificationStatus == CoreData.Enums.NotificationStatus.UnNotified &&
                                             notify.BookId == bookId
                                       select notify)
                                       .ToListAsync();

            return notifications;
        }
    }
}
