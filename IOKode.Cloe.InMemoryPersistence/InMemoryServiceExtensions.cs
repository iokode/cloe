using IOKode.Cloe.Application;
using Microsoft.Extensions.DependencyInjection;

namespace IOKode.Cloe.InMemoryPersistence
{
    public static class InMemoryServiceExtensions
    {
        public static void AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();
            services.AddTransient<IQueryService, InMemoryQueryService>();
        }
    }
}