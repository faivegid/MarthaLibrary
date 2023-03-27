namespace marthaLibrary.Services.EmailServices
{
    public interface IEmailService
    {
        void SendMailBookIsNowAvailable(string email , string bookName, long bookId);
    }
}
