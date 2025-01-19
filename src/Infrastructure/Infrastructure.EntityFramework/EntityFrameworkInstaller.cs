using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFramework
{
    public static class EntityFrameworkInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<CarMarketContext>(optionsBuilder
                => optionsBuilder
                    .UseLazyLoadingProxies() // lazy loading
                    .UseNpgsql(connectionString));
                    
                    return services;
        }
    }
}