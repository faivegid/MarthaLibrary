using marthaLibrary.Models.ControllerRequestModels.AuthController;
using marthaLibrary.Models.DTOs;

namespace marthaLibrary.Managers.AuthManagers
{
    public interface IAuthManager
    {
        Task<(string token, UserDto userDto)> Login(LoginRequest request);
    }
}