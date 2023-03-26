using marthaLibrary.CoreData.Base;
using marthaLibrary.CoreData.Enums;

namespace marthaLibrary.CoreData.DatabaseModels
{
    public class AppUser : BaseGuidEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
