using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.UserRepo
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<bool> CheckUserExist(string email);
        Task<bool> CheckUserExist(Guid userId);
        Task<AppUser> FinUserByEmail(string email);
    }
}