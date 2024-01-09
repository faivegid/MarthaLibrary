using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.EmailServices;
using Microsoft.Extensions.Logging;

namespace marthaLibrary.Services.NotificationServices
{
    internal class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly IEmailService _emailService;

        public NotificationService(
            ILogger<NotificationService> logger,
            IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public void SendBulkNotifcation(IEnumerable<Notification> notifications)
        {
            foreach (var notify in notifications)
            {
                try
                {
                    _emailService.SendMailBookIsNowAvailable(notify.UserEmail, notify.BookName, notify.BookId);
                    notify.NotificationStatus = CoreData.Enums.NotificationStatus.Notified;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to send notifcation for {notify.UserEmail}");
                }                
            }
        }

        public void SendResetCode(string email, string code)
        {
        }

        public void SendSingleNotifcation(Notification notify)
        {
            _emailService.SendMailBookIsNowAvailable(notify.UserEmail, notify.BookName, notify.BookId);
            notify.NotificationStatus = CoreData.Enums.NotificationStatus.Notified;
        }
    }
}
