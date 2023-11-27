using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;


namespace Repository.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void DbConfig<TContext>(this IServiceCollection services, string connectionString) where TContext : ApplicationContext
        {
            services.AddDbContext<TContext>(options => options.UseMySQL(connectionString));
        }
    }
}
