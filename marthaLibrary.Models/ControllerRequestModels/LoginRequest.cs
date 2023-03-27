using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
