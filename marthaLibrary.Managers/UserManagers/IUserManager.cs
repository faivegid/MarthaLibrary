using marthaLibrary.Models.ControllerRequestModels;
using marthaLibrary.Models.DTOs;

namespace marthaLibrary.Managers.UserManagers
{
    public interface IUserManager
    {
        Task<(string token, UserDto userDto)> CreateNewUser(CreateUserRequest request);
        Task<UserInfoDto> GetUserInfo(Guid userId);
    }
}