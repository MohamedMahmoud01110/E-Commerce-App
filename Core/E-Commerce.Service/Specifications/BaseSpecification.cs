using E_Commerce.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Specifications
{
    internal abstract class BaseSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        public ICollection<Expression<Func<TEntity, object>>> Includes { get; private set; } = [];
        protected void AddInclude(Expression<Func<TEntity, object>> expression)
        {
            Includes.Add(expression);
        }


    }
}
