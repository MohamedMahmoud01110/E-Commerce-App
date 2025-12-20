
using System.Linq.Expressions;

namespace E_Commerce.Persistence.Repositories
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        ICollection<Expression<Func<TEntity, object>>> Includes { get; }
    }
}