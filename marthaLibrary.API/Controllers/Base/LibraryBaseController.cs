using marthaLibrary.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace marthaLibrary.API.Controllers.Base
{
    public abstract class LibraryBaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        /// <summary>
        /// Gets the current logged in userId from the claims NameIdentifier
        /// </summary>
        public Guid UserId { get => GetUseerId(); }

        /// <summary>
        /// get the current loggedin user email claims
        /// </summary>
        public string Email { get => GetEmail(); }

        /// <summary>
        /// gets the current logged in user namee claims
        /// </summary>
        public string Name { get => GetName(); }


        public LibraryBaseController(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// health check for the controller to determine its working fine
        /// </summary>
        /// <returns></returns>
        public abstract IActionResult HealthCheck();

        protected IActionResult Done<T>(ApiResponse<T> response)
        {
            return StatusCode((int)response.StatusCode, response);
        }

        protected IActionResult Done()
        {
            return NoContent();
        }

        protected IActionResult Done<TData>(TData data, string message = null)
        {
            var response = ApiResponse.Success(data, message);
            return Done(response);
        }

        protected IActionResult Failure(
            string message = "An error occured processing your request",
            HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            var response = ApiResponse.Error(message, status);
            return Done(response);
        }

        protected IActionResult Failure(LibraryException ax)
        {
            var response = ApiResponse.Error(ax.ErrorDictionary, ax.Message, ax.ErrorStatus);
            return Done(response);
        }

        #region Private Methods
        /// <summary>
        /// used to get the current logged in user from the authorization header
        /// </summary>
        /// <returns></returns>
        private Guid GetUseerId()
        {
            var jwt = GetJwtToken();
            var userId = jwt.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
                throw new LibraryException("unable to verify user", HttpStatusCode.Unauthorized);

            return Guid.Parse(userId);
        }

        /// <summary>
        /// Gets the jwt token from the header
        /// </summary>
        /// <returns></returns>
        private JwtSecurityToken GetJwtToken()
        {
            var token = Request.Headers[HeaderNames.Authorization];
            var handler = new JwtSecurityTokenHandler();
            var stringToken = token.ToString().Split(' ')[1];
            var jwt = handler.ReadJwtToken(stringToken);

            return jwt;
        }

        /// <summary>
        /// get the current loggedin user email claim
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AzaException"></exception>
        private string GetEmail()
        {
            var jwt = GetJwtToken();
            var email = jwt.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;

            if (string.IsNullOrEmpty(email))
                throw new LibraryException("unable to verify user", HttpStatusCode.Unauthorized);

            return email;
        }

        private string GetName()
        {
            var jwt = GetJwtToken();
            var email = jwt.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;

            if (string.IsNullOrEmpty(email))
                throw new LibraryException("unable to verify user", HttpStatusCode.Unauthorized);

            return email;
        }
        #endregion
    }
}
