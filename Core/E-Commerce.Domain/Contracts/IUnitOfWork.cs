using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>;

    }
}
