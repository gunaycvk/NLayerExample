using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Contracts.Persistence
{
    public interface IProductRepositry : IGenericRepository<Product>
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count);
    }
}
