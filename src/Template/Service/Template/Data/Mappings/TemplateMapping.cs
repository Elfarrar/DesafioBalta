using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Template.Data.Mappings
{
    public class TemplateMapping : IEntityTypeConfiguration<Model.Template>
    {
        public void Configure(EntityTypeBuilder<Model.Template> builder)
        {
            builder.ToTable("Templates");
        }
    }
}
