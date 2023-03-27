using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.NotificationServices;
using Microsoft.Extensions.Logging;

namespace marthaLibrary.Services.JobServices
{
    public class ReservationMonitoringJob
    {
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReservationMonitoringJob> _logger;

        public ReservationMonitoringJob(
            INotificationService notificationService,
            IUnitOfWork unitOfWork,
            ILogger<ReservationMonitoringJob> logger)
        {
            _notificationService = notificationService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task CheckReservation()
        {
            // Retrieve the book from the repository
            var bookList = await _unitOfWork.Books.GetDueReservedBooks();

            foreach (var book in bookList)
            {
                var lastLog = await _unitOfWork.BookLogs.FindLastLog(book.Id);
                if (lastLog.TransactionType != CoreData.Enums.TransactionType.Reserve)
                    continue;

                if (lastLog.ReturnDate < DateTime.UtcNow)
                {
                    var notifcations = await _unitOfWork.Notification.GetUnNotifiedNotifcations(book.Id);
                    _notificationService.SendBulkNotifcation(notifcations);

                    book.Status = CoreData.Enums.BookStatus.Available;

                    _unitOfWork.Notification.UpdateRange(notifcations);
                    _unitOfWork.Books.Update(book);
                    _logger.LogWarning($"Notifcations send succesffuly bookId: {book.Id} number of notifications {notifcations.Count()}");
                }
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
