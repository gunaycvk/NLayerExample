using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Options;
using Microsoft.EntityFrameworkCore;
using Products.Application.Contracts.Persistence;
using Products.Persistence.Products;

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

            services.AddScoped<IProductRepositry, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
