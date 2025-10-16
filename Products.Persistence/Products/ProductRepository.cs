using Microsoft.EntityFrameworkCore;
using Products.Application.Contracts.Persistence;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistence.Products
{
    internal class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepositry
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count)
        {
           return Context.Products.OrderByDescending(x=> x.Price).Take(count).ToListAsync();
        }
    }
}
