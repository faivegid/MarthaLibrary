using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.Repos.BookRepo;
using marthaLibrary.Repos.BookTransactionRepo;
using marthaLibrary.Repos.NotificationRepo;
using marthaLibrary.Repos.ResetCodeRepo;
using marthaLibrary.Repos.UserRepo;

namespace marthaLibrary.Repos.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _db;
        private IUserRepository _users;
        private IBookRepository _books;
        private INotificationRepository _notifcations;
        private IBookTransactionRepository _bookLogs;
        private IResetCodeRepository _resetCodes;

        public UnitOfWork(LibraryDbContext context)
        {
            _db = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_db);
        public IBookRepository Books => _books ??= new BookRepository(_db);
        public INotificationRepository Notification => _notifcations ??=  new NotificationRepository(_db);
        public IBookTransactionRepository BookLogs => _bookLogs ??=  new BookTransactionRepository(_db);
        public IResetCodeRepository ResetCodes => _resetCodes ??=  new ResetCodeRepository(_db);

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
