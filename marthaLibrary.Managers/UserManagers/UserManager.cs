using AutoMapper;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Managers.Base;
using marthaLibrary.Models.Base;
using marthaLibrary.Models.ControllerRequestModels;
using marthaLibrary.Models.DTOs;
using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.StaticHelpers;
using marthaLibrary.Services.TokenServices;
using marthaLibrary.Services.UserServices;
using Microsoft.Extensions.Logging;

namespace marthaLibrary.Managers.UserManagers
{
    internal class UserManager : BaseManager, IUserManager
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public UserManager(
            ILogger<UserManager> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ITokenService tokenService,
            IUserService userService) : base(logger, unitOfWork, mapper)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<(string token, UserDto userDto)> CreateNewUser(CreateUserRequest request)
        {
            var doesUseExist = await _unitOfWork.Users.CheckUserExist(request.Email);

            if (doesUseExist)
                throw new LibraryException("User already exist", System.Net.HttpStatusCode.BadRequest);

            var user = new AppUser()
            {
                Email = request.Email,
                Name = request.FullName,
                PasswordHash = HashService.HashText(request.Password),
                Role = CoreData.Enums.UserRole.User
            };

            _unitOfWork.Users.Insert(user);
            await _unitOfWork.SaveChangesAsync();

            var token = _tokenService.GenerateToken(user);
            var userDto = _mapper.Map<UserDto>(user);
            return (token, userDto);
        }

        public async Task<UserInfoDto> GetUserInfo(Guid userId)
        {
            var user = await _userService.GetUserInternal(userId);

            var infoDto = _mapper.Map<UserInfoDto>(user);
            return infoDto;
        }

        public async Task<UserInfoDto> GetUserInfo(string email)
        {
            var user = await _userService.GetUserByEmail(email);

            var infoDto = _mapper.Map<UserInfoDto>(user);
            return infoDto;
        }
    }
}
