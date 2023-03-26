using marthaLibrary.CoreData.DatabaseModels;

namespace marthaLibrary.Services.UserServices
{
    public interface IUserService
    {
        Task<AppUser> GetUserByEmail(string email);
        Task<AppUser> GetUserInternal(Guid userId);
    }
}