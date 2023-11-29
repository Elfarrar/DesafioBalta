using Identity.Data;
using Identity.Helpers;
using Identity.Helpers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAutenticationHelper, AutenticationHelper>();

        }
    }
}
