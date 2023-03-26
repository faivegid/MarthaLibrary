using marthaLibrary.API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marthaLibrary.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : LibraryBaseController
    {
        public AuthController(
            ILogger<AuthController> logger) : base(logger)
        {
        }

        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("Auth contoller is healthy");
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login()
        {
            return Done();
        }
    }
}
