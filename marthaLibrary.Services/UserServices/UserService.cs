using Azure.Core;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Models.Base;
using marthaLibrary.Repos.UnitOfWorks;

namespace marthaLibrary.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.Users.FinUserByEmail(email);
            if (user == null)
                throw new LibraryException($"User with email: {email} was not found", System.Net.HttpStatusCode.BadRequest);

            return user;
        }

        public async Task<AppUser> GetUserInternal(Guid userId)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(userId);
            if (user == null)
                throw new LibraryException($"User not found", System.Net.HttpStatusCode.BadRequest);

            return user;
        }
    }
}
