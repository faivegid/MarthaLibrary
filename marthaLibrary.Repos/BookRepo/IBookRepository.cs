using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.BookRepo
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<bool> CheckIfBookExist(string name, string author);
        Task<bool> DbHasBooks();
        Task<Book> GetBook(long bookId);
        Task<IEnumerable<Book>> GetBooks(int page = 1);
        Task<IEnumerable<Book>> GetDueReservedBooks();
        Task<IEnumerable<Book>> SearchBook(string bookName, int page = 1);
    }
}