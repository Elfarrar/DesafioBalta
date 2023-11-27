using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Repository.Context.Mapping
{
    public class EntityAuditMapping : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreateUser).IsRequired();
            builder.Property(e => e.CreateDate).IsRequired();
            builder.Property(e => e.Type).IsRequired();
            builder.Property(e => e.State).HasColumnType("nvarchar(max)");

            builder.ToTable("Audits");
        }
    }
}
