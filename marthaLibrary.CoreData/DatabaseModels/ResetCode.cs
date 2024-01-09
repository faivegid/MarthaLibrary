using marthaLibrary.CoreData.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class ResetCode : BaseGuidEntity
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public bool IsVerified { get; set; } = false;

        public void Verified()
        {
            IsVerified = true;
        }
    }
}
