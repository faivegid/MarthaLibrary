using marthaLibrary.Repos.BookRepo;
using marthaLibrary.Repos.BookTransactionRepo;
using marthaLibrary.Repos.NotificationRepo;
using marthaLibrary.Repos.UserRepo;

namespace marthaLibrary.Repos.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBookRepository Books { get; }
        INotificationRepository Notification { get; }
        IBookTransactionRepository BookLogs { get; }

        Task SaveChangesAsync();
    }
}
