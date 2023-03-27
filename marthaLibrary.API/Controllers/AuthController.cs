using marthaLibrary.API.Controllers.Base;
using marthaLibrary.Managers.AuthManagers;
using marthaLibrary.Models.ControllerRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marthaLibrary.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : LibraryBaseController
    {
        private readonly IAuthManager _authManager;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthManager authManager) : base(logger)
        {
            _authManager = authManager;
        }

        /// <summary>
        /// Checks if controller is working fine
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("Auth contoller is healthy");
        }

        /// <summary>
        /// Login a particualr user if crednetial are correct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var (token, userDto) = await _authManager.Login(request);

            Response.Headers.Add("access-token", token);
            return Done(userDto);
        }
    }
}
