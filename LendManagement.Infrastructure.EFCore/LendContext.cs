using LendManagement.Domain.LendAgg;
using LendManagement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LendManagement.Infrastructure.EFCore
{
    public class LendContext : DbContext
    {
        public DbSet<Lend> Lending { get; set; }
        public LendContext(DbContextOptions<LendContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(LendMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}