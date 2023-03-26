using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.BorrowedBookRepo
{
    internal class BorrowedBookRepository : GenericRepository<BorrowedBook>, IBorrowedBookRepository
    {
        public BorrowedBookRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
