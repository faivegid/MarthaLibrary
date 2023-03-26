using AutoMapper;
using marthaLibrary.Managers.Base;
using marthaLibrary.Models.Base;
using marthaLibrary.Models.ControllerRequestModels.AuthController;
using marthaLibrary.Models.DTOs;
using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.StaticHelpers;
using marthaLibrary.Services.TokenServices;
using marthaLibrary.Services.UserServices;
using Microsoft.Extensions.Logging;

namespace marthaLibrary.Managers.AuthManagers
{
    internal class AuthManager : BaseManager, IAuthManager
    {
        private readonly ITokenService _tokenService;

        public AuthManager(
            ILogger<AuthManager> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ITokenService tokenService) : base(logger, unitOfWork, mapper)
        {
            _tokenService = tokenService;
        }

        public async Task<(string token, UserDto userDto)> Login(LoginRequest request)
        {
            var user = await _unitOfWork.Users.FinUserByEmail(request.Email);
            if (user == null) throw new LibraryException("Invalid user credential", System.Net.HttpStatusCode.BadRequest);

            var isPasswordCorrect = HashService.VerifyHash(request.Password, user.PasswordHash);
            if (!isPasswordCorrect) throw new LibraryException("Invalid user credential", System.Net.HttpStatusCode.BadRequest);

            var token = _tokenService.GenerateToken(user);
            var userDto = _mapper.Map<UserDto>(user);

            return (token, userDto);
        }
    }
}
