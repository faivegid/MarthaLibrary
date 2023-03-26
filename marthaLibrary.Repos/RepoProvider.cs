using marthaLibrary.Repos.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace marthaLibrary.Repos
{
    public static class RepoProvider
    {
        /// <summary>
        /// Configure <see cref="IUnitOfWork"/> for dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void AddIUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
