using marthaLibrary.API.Controllers.Base;
using marthaLibrary.Managers.BookManagers;
using marthaLibrary.Models.ControllerRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marthaLibrary.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize]
    public class BookController : LibraryBaseController
    {
        private readonly IBookManager _bookManager;
        public BookController(
            ILogger<BookController> logger,
            IBookManager bookManager) : base(logger)
        {
            _bookManager = bookManager;
        }

        /// <summary>
        /// Checks if the controller is working fine
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("Book Controller is healthy");
        }

        /// <summary>
        /// Add new book to library db collection only admin can add books
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut, Route(""), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewBook([FromBody] AddBookRequest request)
        {
            var book = await _bookManager.AddBook(request);
            return Done(book);
        }

        /// <summary>
        /// Gets a book by id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet, Route("{bookId}")]
        public async Task<IActionResult> GetBookById([FromRoute] long bookId)
        {
            var bookDto = await _bookManager.GetBookById(bookId);
            return Done(bookDto);
        }

        /// <summary>
        /// Gets books from the database this is a paginated endpoint
        /// </summary>
        /// <param name="page"> query parameter to pe passed if its not set defaults to 1</param>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<IActionResult> GetBooks([FromQuery] int page)
        {
            var bookList = await _bookManager.GetBooks(page);
            return Done(bookList);
        }

        /// <summary>
        /// Returns a list of books that contains the search text in its name
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet, Route("search/{searchText}")]
        public async Task<IActionResult> SearchBook([FromRoute]string searchText, [FromQuery]int page)
        {
            var marchedBooks = await _bookManager.SearchBook(searchText,page);
            return Done(marchedBooks);
        }

        /// <summary>
        /// Reserves a book for a user only a registered user can perform this action
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("reserve"), Authorize(Roles = "User")]
        public async Task<IActionResult> ReserveBooks([FromBody] ReserveBookRequest request)
        {
            await _bookManager.ReserveBook(UserId, request);
            return Done("Book reserved successfully");
        }

        /// <summary>
        /// Borrows a book from library only an admin can perform this action
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("borrow"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBookRequest request)
        {
            await _bookManager.BorrowBook(request);
            return Done("Book has borrowed successfully");
        }

        /// <summary>
        /// Registers a book as available only an admin can perform this action
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("borrow/return"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookRequest request)
        {
            await _bookManager.ReturnBorrowedBook(request);
            return Done("Book is now available to be reserved and borrowed");
        }
    }
}
