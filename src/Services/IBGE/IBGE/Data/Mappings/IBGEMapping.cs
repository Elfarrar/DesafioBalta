using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGE.Data.Mappings
{
    public class IBGEMapping : IEntityTypeConfiguration<Model.IBGE>
    {
        public void Configure(EntityTypeBuilder<Model.IBGE> builder)
        {
            builder.ToTable("IBGEs");
        }
    }
}
