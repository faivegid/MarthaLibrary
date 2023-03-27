namespace marthaLibrary.Models.ControllerRequestModels
{
    public class BorrowBookRequest
    {
        public string UserEmail { get; set; }
        public long BookId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
