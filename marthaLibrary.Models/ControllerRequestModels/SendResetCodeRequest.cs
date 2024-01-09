using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class SendResetCodeRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
