using marthaLibrary.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class BorrowBookRequest
    {
        [Required, EmailAddress]
        public string UserEmail { get; set; }

        [Required, Range(1, long.MaxValue, ErrorMessage = "The value must be greater than zero.")]
        public long BookId { get; set; }

        [Required]
        [CustomValidation(typeof(ValidateDate), $"{nameof(ValidateDate.DateGreaterThanToday)}")]
        public DateTime ReturnDate { get; set; }
    }
}
