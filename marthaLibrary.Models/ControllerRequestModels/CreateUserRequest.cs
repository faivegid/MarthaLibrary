using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class CreateUserRequest
    {
        [Required, MinLength(5)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(5)]
        public string Password { get; set; }
    }
}
