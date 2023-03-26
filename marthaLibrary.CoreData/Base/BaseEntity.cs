using System.ComponentModel.DataAnnotations;

namespace marthaLibrary.CoreData.Base
{
    public abstract class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }

    public abstract class BaseEntity<T> : BaseEntity
    {
        [Key]
        public T Id { get; set; }
    }
}
