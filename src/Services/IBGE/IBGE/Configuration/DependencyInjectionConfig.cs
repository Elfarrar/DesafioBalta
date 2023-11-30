using IBGE.Data;
using IBGE.Repository;

namespace IBGE.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBGEContext>();
            services.AddScoped<IIBGERepository, IBGERepository>();
        }
    }
}
