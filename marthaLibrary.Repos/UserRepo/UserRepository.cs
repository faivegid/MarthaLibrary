using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;
using Microsoft.EntityFrameworkCore;

namespace marthaLibrary.Repos.UserRepo
{
    internal class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckUserExist(string email)
        {
            var userExist = await dbSet.AsNoTracking()
                .AnyAsync(u => u.Email == email);
            return userExist;
        }

        public async Task<AppUser> FinUserByEmail(string email)
        {
            var appUser = await (from user in dbSet
                                 where user.Email == email &&
                                       user.IsDeleted == false
                                 select user)
                                .FirstOrDefaultAsync();

            return appUser;
        }
    }
}
