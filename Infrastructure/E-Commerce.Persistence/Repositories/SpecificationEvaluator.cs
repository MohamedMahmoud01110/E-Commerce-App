using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    internal static class SpecificationEvaluator
    {

        public static IQueryable<TEntity> ApplySpecification<TEntity>(this IQueryable<TEntity> InputQuery, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var query = InputQuery;

            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);

            foreach (var include in specification.Includes)
                query.Include(include);



            //query = specification.Includes.Aggregate(query, (query, include)
            //    => query.Include(include));



            //order
            //filteration
            //pagination

            return query;
        }
    }
}
