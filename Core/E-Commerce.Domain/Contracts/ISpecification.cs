
using System.Linq.Expressions;

namespace E_Commerce.Persistence.Repositories
{
    public interface ISpecification<TEntity> where TEntity : class
    {

        ICollection<Expression<Func<TEntity, object>>> Includes { get; }
    }
}