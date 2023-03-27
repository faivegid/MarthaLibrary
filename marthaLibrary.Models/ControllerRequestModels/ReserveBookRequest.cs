using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.Models.ControllerRequestModels
{
    public class ReserveBookRequest
    {
        [Required, Range(1, long.MaxValue)]
        public long BookId { get; set; }
    }
}
