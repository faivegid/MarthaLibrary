using marthaLibrary.CoreData.Base;
using marthaLibrary.CoreData.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace marthaLibrary.CoreData.AppContexts
{
    public class LibraryDbContext : DbContext
    {
        private readonly List<Book> seedData;
        private readonly AppUser admin;

        public LibraryDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            seedData = config.GetSection("BookList").Get<List<Book>>();
            admin = config.GetSection("Admin").Get<AppUser>();
            Database.Migrate();
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookTransactionLog> BookLogs { get; set; }
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Seed data
        //    modelBuilder.Entity<Book>().HasData(seedData);
        //    modelBuilder.Entity<AppUser>().HasData(admin);

        //}
    }
}
