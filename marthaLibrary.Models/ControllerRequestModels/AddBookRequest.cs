namespace marthaLibrary.Models.ControllerRequestModels
{
    public class AddBookRequest
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string FrontPagePicUrl { get; set; }
    }
}
