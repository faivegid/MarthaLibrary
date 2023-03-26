using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.BookRepo;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.BookReservationRepo
{

    internal class BookReservationRepository : GenericRepository<BookReservation>, IBookReservationRepository
    {
        public BookReservationRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
