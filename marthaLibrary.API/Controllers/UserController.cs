using marthaLibrary.API.Controllers.Base;
using marthaLibrary.Managers.UserManagers;
using marthaLibrary.Models.ControllerRequestModels;
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

        /// <summary>
        /// Checks if controller is working fine
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("USer controller is healthy");
        }

        /// <summary>
        /// Add new user to the library
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut, Route("create"), AllowAnonymous]
        public async Task<IActionResult> CreateNewUser(CreateUserRequest request)
        {
            var (token, userDto) = await _userManager.CreateNewUser(request);

            Response.Headers.Add("access-token", token);
            return Done(userDto);
        }
    }
}
