using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.NotificationServices;
using Microsoft.Extensions.Logging;

namespace marthaLibrary.Services.JobServices
{
    public class BookReturnNotificationJob
    {
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookReturnNotificationJob> _logger;

        public BookReturnNotificationJob(
            INotificationService notificationService,
            IUnitOfWork unitOfWork,
            ILogger<BookReturnNotificationJob> logger)
        {
            _notificationService = notificationService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task SendNotification(long bookId)
        {
            // Retrieve the book from the repository
            var book = await _unitOfWork.Books.FindByIdAsync(bookId);

            if(book == null)
            {
                _logger.LogWarning($"Book for notifcation not found bookId: {bookId}");
                return;
            }

            var notifcations = await _unitOfWork.Notification.GetUnNotifiedNotifcations(bookId);
            _notificationService.SendBulkNotifcation(notifcations);

            _unitOfWork.Notification.UpdateRange(notifcations);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogWarning($"Notifcations send succesffuly bookId: {bookId} number of notifications {notifcations.Count()}");
        }
    }
}
