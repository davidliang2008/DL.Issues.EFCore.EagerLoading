using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.EFCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("AppDbConnection");
            string assemblyName = typeof(AppDbContext).Namespace;

            services.AddDbContext<AppDbContext>(options =>
                options
                    .UseSqlServer(dbConnectionString, optionsBuilder => optionsBuilder.MigrationsAssembly(assemblyName)
                )
            );
        }
    }
}
