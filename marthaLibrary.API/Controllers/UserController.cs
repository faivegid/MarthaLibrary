using marthaLibrary.API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marthaLibrary.API.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [Authorize]
    public class UserController : LibraryBaseController
    {
        public UserController(
            ILogger<UserController> logger) : base(logger)
        {
        }

        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("USer controller is healthy");
        }

        [HttpPut, Route("create")]
        public async Task<IActionResult> CreateNewUser()
        {
            return Done();
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

        [HttpPost, Route("get-user-info")]
        public async Task<IActionResult> GetUserInfo()
        {
            return Done();
        }
    }
}
