using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.Repos.BookRepo;
using marthaLibrary.Repos.BookReservationRepo;
using marthaLibrary.Repos.BorrowedBookRepo;
using marthaLibrary.Repos.NotificationRepo;
using marthaLibrary.Repos.UserRepo;

namespace marthaLibrary.Repos.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _db;
        private IUserRepository _users;
        private IBookRepository _books;
        private IBookReservationRepository _bookReservations;
        private IBorrowedBookRepository _borrowedBooks;
        private INotificationRepository _notifcations;

        public UnitOfWork(LibraryDbContext context)
        {
            _db = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_db);
        public IBookRepository Books => _books ??= new BookRepository(_db);
        public IBookReservationRepository BookReservations => _bookReservations ??= new BookReservationRepository(_db);
        public IBorrowedBookRepository BorrowedBooks => _borrowedBooks ??= new BorrowedBookRepository(_db);
        public INotificationRepository Notification => _notifcations ??=  new NotificationRepository(_db);

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
