using AutoMapper;
using Hangfire;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.CoreData.Enums;
using marthaLibrary.Managers.Base;
using marthaLibrary.Models.Base;
using marthaLibrary.Models.ControllerRequestModels;
using marthaLibrary.Models.DTOs;
using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.JobServices;
using marthaLibrary.Services.UserServices;
using Microsoft.Extensions.Logging;
using System.Net;

namespace marthaLibrary.Managers.BookManagers
{
    internal class BookManager : BaseManager, IBookManager
    {
        private readonly IUserService _userService;

        public BookManager(
            ILogger<BookManager> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserService userService) : base(logger, unitOfWork, mapper)
        {
            _userService = userService;
        }

        public async Task<Book> AddBook(AddBookRequest request)
        {
            var bookExist = await _unitOfWork.Books.CheckIfBookExist(request.BookName, request.AuthorName);
            if (bookExist) throw new LibraryException("Book already exist", HttpStatusCode.BadRequest);

            var book = new Book
            {
                BookName = request.BookName,
                AuthorName = request.AuthorName,
                Description = request.Description,
                FrontPagePicUrl = request.FrontPagePicUrl,
                Status = BookStatus.Available
            };

            _unitOfWork.Books.Insert(book);
            await _unitOfWork.SaveChangesAsync();
            return book;
        }

        public async Task ReserveBook(Guid userId, ReserveBookRequest request)
        {
            var user = await _userService.GetUserInternal(userId);
            var book = await GetBookByIdInternal(request.BookId);

            if (book.Status == BookStatus.Reserved)
                throw new LibraryException($"Book has been {book.Status}", HttpStatusCode.BadRequest);

            if (book.Status == BookStatus.Borrowed)
            {
                var booKLog = await _unitOfWork.BookLogs.FindLastLog(book.Id);
                throw new LibraryException($"Book has been {book.Status} and would be available on {booKLog.ReturnDate.ToString("ddd-MMM-yyyy")}", HttpStatusCode.BadRequest);
            }

            var bookActivityLog = new BookTransactionLog
            {
                BookId = request.BookId,
                UserEmail = user.Email,
                ReturnDate = DateTime.UtcNow.AddHours(24),
                BookName = book.BookName,
                TransactionType = TransactionType.Reserve
            };

            book.Status = BookStatus.Reserved;

            _unitOfWork.Books.Update(book);
            _unitOfWork.BookLogs.Insert(bookActivityLog);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task BorrowBook(BorrowBookRequest request)
        {
            var book = await GetBookByIdInternal(request.BookId);
            var lastLog = await _unitOfWork.BookLogs.FindLastLog(book.Id);

            if ((book.Status == BookStatus.Reserved &&
                !string.Equals(request.UserEmail, lastLog.UserEmail, StringComparison.OrdinalIgnoreCase)) ||
                book.Status == BookStatus.Borrowed)
            {
                var message = book.Status == BookStatus.Reserved
                    ? $"Book has been {book.Status}"
                    : $"Book has already been borrowed and will be available on {lastLog.ReturnDate:d-MMM-yyyy}";
                throw new LibraryException(message, HttpStatusCode.BadRequest);
            }

            book.Status = BookStatus.Borrowed;
            var bookActivityLog = new BookTransactionLog
            {
                BookId = request.BookId,
                UserEmail = request.UserEmail,
                ReturnDate = request.ReturnDate,
                BookName = book.BookName,
                TransactionType = TransactionType.Borrow
            };

            _unitOfWork.Books.Update(book);
            _unitOfWork.BookLogs.Insert(bookActivityLog);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ReturnBorrowedBook(ReturnBookRequest request)
        {
            var book = await GetBookByIdInternal(request.BookId);
            if (book.Status != BookStatus.Borrowed)
                throw new LibraryException("Invalid request", HttpStatusCode.BadRequest);

            var bookActivityLog = new BookTransactionLog
            {
                BookId = request.BookId,
                UserEmail = request.ReturninUserEmail,
                ReturnDate = DateTime.UtcNow,
                BookName = book.BookName,
                TransactionType = TransactionType.Return
            };

            book.Status = BookStatus.Available;

            _unitOfWork.Books.Update(book);
            _unitOfWork.BookLogs.Insert(bookActivityLog);
            await _unitOfWork.SaveChangesAsync();

            BackgroundJob.Enqueue<BookReturnNotificationJob>(job => job.SendNotification(book.Id));
        }

        public async Task<Book> GetBookByIdInternal(long bookId)
        {
            var book = await _unitOfWork.Books.GetBook(bookId);

            if (book == null)
                throw new LibraryException("Book not found", HttpStatusCode.BadRequest);

            return book;
        }

        public async Task<BookDto> GetBookById(long bookId)
        {
            var book = await GetBookByIdInternal(bookId);
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public async Task<IEnumerable<BookDto>> GetBooks(int pageNumber)
        {
            var bookList = await _unitOfWork.Books.GetBooks(pageNumber);

            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(bookList);
            return bookDtos;
        }

        public async Task<IEnumerable<BookDto>> SearchBook(string search, int page)
        {
            if (string.IsNullOrEmpty(search))
                return Enumerable.Empty<BookDto>();

            var bookList = await _unitOfWork.Books.SearchBook(search, page);

            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(bookList);
            return bookDtos;
        }
    }
}
