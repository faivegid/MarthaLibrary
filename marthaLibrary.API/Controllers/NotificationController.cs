using marthaLibrary.API.Controllers.Base;
using marthaLibrary.Managers.NotificationManagers;
using marthaLibrary.Models.ControllerRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marthaLibrary.API.Controllers
{
    [Route("api/notify")]
    [ApiController]
    [Authorize]
    public class NotificationController : LibraryBaseController
    {
        private readonly INotificationManager _notifyManager;

        public NotificationController(
            ILogger<NotificationController> logger,
            INotificationManager notifyManager) : base(logger)
        {
            _notifyManager = notifyManager;
        }

        /// <summary>
        /// Checks if controller is working fine
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("health"), AllowAnonymous]
        public override IActionResult HealthCheck()
        {
            return Done("Notifcaiton controller is healthy");
        }

        /// <summary>
        /// Creates a notifcation for a user to be notified if book is returned or if reservation time is over
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut, Route("create")]
        public async Task<IActionResult> CreateNotificaton(NotificationRequest request)
        {
            if (string.IsNullOrEmpty(request.UserEmail))
                request.UserEmail = Email;

            await _notifyManager.AddNewNotifcation(request);
            return Done("Notifcation added successfully");
        }
    }
}
