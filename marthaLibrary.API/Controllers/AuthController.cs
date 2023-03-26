using marthaLibrary.API.Controllers.Base;
using marthaLibrary.Managers.AuthManagers;
using marthaLibrary.Models.ControllerRequestModels.AuthController;
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

        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("Auth contoller is healthy");
        }

        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var (token, userDto) = await _authManager.Login(request);

            Response.Headers.Add("access-token", token);
            return Done(userDto);
        }
    }
}
