using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.CoreData.Enums;
using marthaLibrary.Repos.Generic;
using Microsoft.EntityFrameworkCore;

namespace marthaLibrary.Repos.BookTransactionRepo
{
    internal class BookTransactionRepository : GenericRepository<BookTransactionLog>, IBookTransactionRepository
    {
        public BookTransactionRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<BookTransactionLog> FindLastLog(long bookId)
        {
            var bookLog = await (from log in dbSet
                                 where log.BookId == bookId
                                 orderby log.DateCreated descending
                                 select log).FirstOrDefaultAsync();
            return bookLog;
        }
    }
}
