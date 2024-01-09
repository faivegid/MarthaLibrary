using AutoMapper;
using Azure.Core;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Managers.Base;
using marthaLibrary.Models.Base;
using marthaLibrary.Models.ControllerRequestModels;
using marthaLibrary.Models.DTOs;
using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.NotificationServices;
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
        private readonly INotificationService _notificationService;

        public UserManager(
            ILogger<UserManager> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ITokenService tokenService,
            IUserService userService,
            INotificationService notificationService) : base(logger, unitOfWork, mapper)
        {
            _tokenService = tokenService;
            _userService = userService;
            _notificationService = notificationService;
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

        public async Task<Guid> SendResetCode(string email)
        {
            var user = await _unitOfWork.Users.FinUserByEmail(email);
            if (user == null) throw new LibraryException($"No user found with email {email}", System.Net.HttpStatusCode.NotFound);

            var resetCode = new ResetCode
            {
                Code = CodeGenerator.GenerateRandomNumericString(),
                UserId = user.Id,
            };

            _unitOfWork.ResetCodes.Insert(resetCode);
            await _unitOfWork.SaveChangesAsync();
            _notificationService.SendResetCode(user.Email, resetCode.Code);

            return resetCode.Id;
        }

        public async Task<string> VerifyResetCode(VerifyResetCodeRequest request)
        {
            var user = await _unitOfWork.Users.FinUserByEmail(request.Email);
            if (user == null) throw new LibraryException($"No user found with email {request.Email}", System.Net.HttpStatusCode.NotFound);

            var resetCode = await _unitOfWork.ResetCodes.FindByIdAsync(request.CodeId);
            if (resetCode == null) throw new LibraryException("Invalid code request", System.Net.HttpStatusCode.Forbidden);

            if (resetCode.IsVerified) throw new LibraryException("request cannot be processed", System.Net.HttpStatusCode.Forbidden);

            var isCodeCorrect = HashService.VerifyHash(request.Code, resetCode.Code);
            if (!isCodeCorrect) throw new LibraryException("In-correct code", System.Net.HttpStatusCode.BadRequest);

            var token = _tokenService.GenerateToken(resetCode, user);
            resetCode.Verified();
            _unitOfWork.ResetCodes.Update(resetCode);
            await _unitOfWork.SaveChangesAsync();

            return token;
        }


        public async Task ResetPassword(Guid userId, Guid codeId, string newPassword)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(userId);
            if (user == null) throw new LibraryException($"No user found", System.Net.HttpStatusCode.NotFound);

            var resetCode = await _unitOfWork.ResetCodes.FindByIdAsync(codeId);
            if (resetCode == null) throw new LibraryException("Invalid code request", System.Net.HttpStatusCode.Forbidden);

            user.SetNewPassword(HashService.HashText(newPassword));

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
