using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Options;
using Microsoft.EntityFrameworkCore;

namespace Products.Persistence.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionStrings = 
                configuration.GetSection
                (ConnectionStringOption.Key).Get<ConnectionStringOption>();

                options.UseNpgsql(connectionStrings!.PostgresConnection,npgsqlOptionsAction =>
                {
                    npgsqlOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                    });

            });

            return services;

        }
    }
}
