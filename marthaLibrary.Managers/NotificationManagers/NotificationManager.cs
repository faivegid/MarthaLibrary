using AutoMapper;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Managers.Base;
using marthaLibrary.Models.Base;
using marthaLibrary.Models.ControllerRequestModels;
using marthaLibrary.Repos.UnitOfWorks;
using marthaLibrary.Services.NotificationServices;
using Microsoft.Extensions.Logging;
using System.Net;

namespace marthaLibrary.Managers.NotificationManagers
{
    internal class NotificationManager : BaseManager, INotificationManager
    {
        private readonly INotificationService _notifyService;

        public NotificationManager(
            ILogger<NotificationManager> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            INotificationService notifyService) : base(logger, unitOfWork, mapper)
        {
            _notifyService = notifyService;
        }

        public async Task AddNewNotifcation(NotificationRequest request)
        {
            var book = await _unitOfWork.Books.FindByIdAsync(request.BookId);
            if(book == null) throw new LibraryException("Book not found", HttpStatusCode.NotFound);

            if (book.Status == CoreData.Enums.BookStatus.Available)
                throw new LibraryException("Cannot add notifcation for an available book", HttpStatusCode.BadRequest);

            var notify = new Notification
            {
                BookId= book.Id,
                UserEmail= request.UserEmail,
                BookName = book.BookName,
                NotificationStatus = CoreData.Enums.NotificationStatus.UnNotified
            };

            _unitOfWork.Notification.Insert(notify);
            await _unitOfWork.SaveChangesAsync();
        }


    }
}
