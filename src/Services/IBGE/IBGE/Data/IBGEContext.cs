using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace IBGE.Data
{
    public class IBGEContext : ApplicationContext
    {
        public IBGEContext(DbContextOptions options) : base(options) { }

        public DbSet<Model.IBGE> IBGE { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IBGEContext).Assembly);
        }
    }
}
