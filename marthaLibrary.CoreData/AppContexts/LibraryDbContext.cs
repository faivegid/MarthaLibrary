using marthaLibrary.CoreData.Base;
using marthaLibrary.CoreData.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace marthaLibrary.CoreData.AppContexts
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> BookReservations { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Notification> Notifcations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.DateUpdated = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        item.Entity.DateCreated = DateTime.UtcNow;
                        item.Entity.DateUpdated = DateTime.UtcNow;
                        item.Entity.IsDeleted = false;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
