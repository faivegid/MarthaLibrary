using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class AddBookRequest
    {
        [Required, MinLength(5)]
        public string BookName { get; set; }

        [Required, MinLength(5)]
        public string AuthorName { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [Url]
        public string FrontPagePicUrl { get; set; }
    }
}
