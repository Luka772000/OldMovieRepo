using LoggerService;
using Microsoft.Extensions.DependencyInjection;
using NlogInterface;
using ProjektFinal.Repository;

namespace ProjektFinal.Extensions
{
    public static class Extensions
    {
        // Extenzija za logiranje
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
