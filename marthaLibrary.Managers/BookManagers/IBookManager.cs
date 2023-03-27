using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Models.ControllerRequestModels;
using marthaLibrary.Models.DTOs;

namespace marthaLibrary.Managers.BookManagers
{
    public interface IBookManager
    {
        Task<Book> AddBook(AddBookRequest request);
        Task BorrowBook(BorrowBookRequest request);
        Task<BookDto> GetBookById(long bookId);
        Task<Book> GetBookByIdInternal(long bookId);
        Task<IEnumerable<BookDto>> GetBooks(int pageNumber);
        Task ReserveBook(Guid userId, ReserveBookRequest request);
        Task ReturnBorrowedBook(ReturnBookRequest request);
        Task<IEnumerable<BookDto>> SearchBook(string search, int page);
    }
}
