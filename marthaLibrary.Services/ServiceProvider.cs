using Hangfire;
using Hangfire.PostgreSql;
using marthaLibrary.Services.EmailServices;
using marthaLibrary.Services.JobServices;
using marthaLibrary.Services.NotificationServices;
using marthaLibrary.Services.TokenServices;
using marthaLibrary.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<INotificationService, NotificationService>();

        }
        
        public static void AddLibraryJobs(this IServiceCollection services, IConfiguration config)
        {
            services.AddHangfire(configuration => configuration.UsePostgreSqlStorage(config.GetConnectionString("HangfireConnection")));
            services.AddHangfireServer();
            services.AddTransient<BookReturnNotificationJob>();
        }
    }
}
