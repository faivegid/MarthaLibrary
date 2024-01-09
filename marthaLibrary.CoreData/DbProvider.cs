using marthaLibrary.CoreData.AppContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace marthaLibrary.CoreData
{
    public static class DbProvider
    {
        /// <summary>
        /// Configures the Db connection string
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddDbConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<LibraryDbContext>(options =>
                 options.UseNpgsql(config.GetConnectionString("LibraryDb")));
        }
    }
}
