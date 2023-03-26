using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.NotificationRepo
{
    internal class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
