using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.UserRepo
{
    internal class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
