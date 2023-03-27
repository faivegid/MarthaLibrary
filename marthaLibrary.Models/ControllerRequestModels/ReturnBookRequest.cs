namespace marthaLibrary.Models.ControllerRequestModels
{
    public class ReturnBookRequest
    {
        public string ReturninUserEmail { get; set; }
        public long BookId { get; set; }
    }
}
