using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IProductService, ProductService>();


            return services;
        }
    }
}
