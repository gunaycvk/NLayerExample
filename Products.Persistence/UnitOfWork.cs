using Products.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistence
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
