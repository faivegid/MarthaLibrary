using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.Base;
using Microsoft.EntityFrameworkCore;

namespace marthaLibrary.Repos.Generic
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly LibraryDbContext context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(LibraryDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public async Task<T> FindByIdAsync(object id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity;
        }

        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            dbSet.Update(entity);
        }

        public void HardDelete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        
        public void UpdateRange(IEnumerable<T> entity)
        {
            dbSet.UpdateRange(entity);
        }
    }
}
