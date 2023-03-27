using Azure;
using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;
using Microsoft.EntityFrameworkCore;

namespace marthaLibrary.Repos.BookRepo
{
    internal class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckIfBookExist(string name, string author)
        {
            var bookExist = await dbSet.AsNoTracking().AnyAsync(x =>
                                    x.BookName == name && x.AuthorName == author);

            return bookExist;
        }

        public async Task<Book> GetBook(long bookId)
        {
            var dbBook = await (from book in dbSet
                                where book.Id == bookId &&
                                      book.IsDeleted == false
                                select book)
                                .FirstOrDefaultAsync();
            return dbBook;
        }

        public async Task<IEnumerable<Book>> SearchBook(string bookName, int page = 1)
        {
            page = page < 1 ? 1 : page;
            var books = await (from book in dbSet
                               where book.BookName.Contains(bookName) &&
                                     book.IsDeleted == false
                               select book)
                               .Skip(Math.Abs((page - 1) * 10)).Take(10).ToListAsync();

            return books;
        }

        public async Task<IEnumerable<Book>> GetBooks(int page)
        {
            page = page < 1 ? 1 : page;
            var books = await (from book in dbSet
                               where book.IsDeleted == false
                               select book)
                               .Skip(Math.Abs((page - 1) * 10)).Take(10).ToListAsync();

            return books;
        }

        public async Task<bool> DbHasBooks()
        {
            return await dbSet.AnyAsync();
        }
        
        public async Task<IEnumerable<Book>> GetDueReservedBooks()
        {
            var books = await (from book in dbSet
                               where book.Status == CoreData.Enums.BookStatus.Reserved
                               select book)
                               .ToListAsync();

            return books;
        }
    }
}
