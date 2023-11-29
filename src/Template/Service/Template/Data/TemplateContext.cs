using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Template.Data
{
    public class TemplateContext : ApplicationContext
    {
        public TemplateContext(DbContextOptions options) : base(options) { }

        public DbSet<Model.Template> Template { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemplateContext).Assembly);
        }
    }
}
