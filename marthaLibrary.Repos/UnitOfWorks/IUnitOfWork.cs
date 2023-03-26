using marthaLibrary.Repos.BookRepo;
using marthaLibrary.Repos.BookReservationRepo;
using marthaLibrary.Repos.BorrowedBookRepo;
using marthaLibrary.Repos.NotificationRepo;
using marthaLibrary.Repos.UserRepo;

namespace marthaLibrary.Repos.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBookRepository Books { get; }
        IBookReservationRepository BookReservations { get; }
        IBorrowedBookRepository BorrowedBooks { get; }
        INotificationRepository Notification { get; }
    }
}
