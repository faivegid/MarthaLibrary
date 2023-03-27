using marthaLibrary.CoreData.Base;

namespace marthaLibrary.Repos.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void SoftDelete(T entity);
        Task<T> FindByIdAsync(object id);
        void Insert(T entity);
        void Update(T entity);
        void InsertRange(IEnumerable<T> entities);

        /// <summary>
        /// avoid using this unless its necessary as it remove the record from database
        /// </summary>
        /// <param name="entity"></param>
        void HardDelete(T entity);
        void UpdateRange(IEnumerable<T> entity);
    }
}
