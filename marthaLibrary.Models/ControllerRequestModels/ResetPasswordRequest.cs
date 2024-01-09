using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class ResetPasswordRequest
    {
        [Required]
        public string NewPassword { get; set; }
    }
}
