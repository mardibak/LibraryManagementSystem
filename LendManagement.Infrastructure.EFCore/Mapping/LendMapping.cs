using LendManagement.Domain.LendAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LendManagement.Infrastructure.EFCore.Mappings
{
    public class LendMapping : IEntityTypeConfiguration<Lend>
    {
        public void Configure(EntityTypeBuilder<Lend> builder)
        {
            builder.ToTable("Lend");
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Operations, modelBuilder =>
              {
                  modelBuilder.HasKey(x => x.Id);
                  modelBuilder.ToTable("LendOperations");
                  modelBuilder.Property(x => x.Description).HasMaxLength(1000);

                  modelBuilder.WithOwner(x => x.Lend).HasForeignKey(x => x.LendId);
              });
        }
    }
}
