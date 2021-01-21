using Sharedkernel.Dtos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sharedkernel.Dynamics
{
    public static class CollectionsExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> input, IReadOnlyCollection<SortCriteria> SortCriterion)
        {
            bool usePropertyExpression = typeof(T).IsPrimitive;

            return null;
        }



    }
}
