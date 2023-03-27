using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.BookTransactionRepo
{
    public interface IBookTransactionRepository : IGenericRepository<BookTransactionLog>
    {
        Task<BookTransactionLog> FindLastLog(long bookId);
    }
}