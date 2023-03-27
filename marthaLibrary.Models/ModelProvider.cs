using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Models.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace marthaLibrary.Models
{
    public static class ModelProvider
    {
        /// <summary>
        /// Adds model mapping from appsetting
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddMappingToModelsFromAppSettings(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(opt => config.GetSection(nameof(JwtSetting)).Get<JwtSetting>());
        }
    }
}
