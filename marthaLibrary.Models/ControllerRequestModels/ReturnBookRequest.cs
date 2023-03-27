using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class ReturnBookRequest
    {
        [Required, EmailAddress]
        public string ReturninUserEmail { get; set; }

        [Required, Range(1, long.MaxValue, ErrorMessage = "The value must be greater than zero.")]
        public long BookId { get; set; }
    }
}
