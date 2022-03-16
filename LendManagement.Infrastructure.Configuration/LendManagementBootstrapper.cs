using LendManagement.Application;
using LendManagement.Application.Contract.Lend;
using LendManagement.Domain.LendAgg;
using LendManagement.Infrastructure.EFCore;
using LendManagement.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LendManagement.Configuration
{
    public class LendManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ILendApplication, LendApplication>();
            services.AddTransient<ILendRepository, LendRepository>();
            services.AddDbContext<LendContext>(x => x.UseSqlServer(connectionString));
        }
    }
}