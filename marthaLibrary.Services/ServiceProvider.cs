using marthaLibrary.Services.TokenServices;
using marthaLibrary.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marthaLibrary.Services
{
    public static class ServiceProvider
    {
        /// <summary>
        /// provides an implementation for adding all the services dependency injections
        /// </summary>
        /// <param name="services"></param>
        public static void AddLibraryServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
