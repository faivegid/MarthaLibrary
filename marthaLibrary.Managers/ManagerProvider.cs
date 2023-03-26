using marthaLibrary.Managers.AuthManagers;
using marthaLibrary.Managers.UserManagers;
using Microsoft.Extensions.DependencyInjection;

namespace marthaLibrary.Managers
{
    public static class ManagerProvider
    {
        /// <summary>
        /// Add managers dependency injections
        /// </summary>
        /// <param name="services"></param>
        public static void AddLibraryManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
