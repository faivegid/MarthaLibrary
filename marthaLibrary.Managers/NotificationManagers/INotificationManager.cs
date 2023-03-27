using marthaLibrary.Models.ControllerRequestModels;

namespace marthaLibrary.Managers.NotificationManagers
{
    public interface INotificationManager
    {
        Task AddNewNotifcation(NotificationRequest request);
    }
}