using marthaLibrary.API.Controllers.Base;
using marthaLibrary.CoreData.Enums;
using marthaLibrary.Managers.UserManagers;
using marthaLibrary.Models.ControllerRequestModels.UserController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marthaLibrary.API.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [Authorize]
    public class UserController : LibraryBaseController
    {
        private readonly IUserManager _userManager;

        public UserController(
            ILogger<UserController> logger, 
            IUserManager userManager) : base(logger)
        {
            _userManager = userManager;
        }

        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("USer controller is healthy");
        }

        [HttpPut, Route("create"), AllowAnonymous]
        public async Task<IActionResult> CreateNewUser(CreateUserRequest request)
        {
            var (token, userDto) = await _userManager.CreateNewUser(request);

            Response.Headers.Add("access-token", token);
            return Done(userDto);
        }

        [HttpPost, Route("change-password")]
        public async Task<IActionResult> ChangePassword()
        {
            return Done();
        }

        [HttpPost, Route("edit")]
        public async Task<IActionResult> EditUserName()
        {
            return Done();
        }

        [HttpPost, Route("get-user-info"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userInfoDto = await _userManager.GetUserInfo(UserId);
            return Done(userInfoDto);
        }
    }
}
