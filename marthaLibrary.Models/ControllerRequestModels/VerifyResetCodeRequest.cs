using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class VerifyResetCodeRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Code { get; set; }

        [Required(ErrorMessage = "Invalid code")]
        public Guid CodeId { get; set; }
    }
}
