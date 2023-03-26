using marthaLibrary.Config.AutoMapper;
using marthaLibrary.Config.Middlewares;
using marthaLibrary.CoreData.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace marthaLibrary.Config
{
    public static class ConfigProvider
    {
        public static void ConfigureLibrarySecurity(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<ApiKeyMiddleware>();

            services.AddLibraryAuthentication(config);
            services.AddLibraryAuthorisation();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfig();
        }

        /// <summary>
        /// Adds configuration for authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddLibraryAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        /// <summary>
        /// Adds configuration for authorisation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddLibraryAuthorisation(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRole.Admin.ToString(), policy => policy.RequireRole(UserRole.Admin.ToString()));
                options.AddPolicy(UserRole.User.ToString(), policy => policy.RequireRole(UserRole.User.ToString()));
            });
        }
    }
}
