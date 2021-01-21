using Sharedkernel.Guards;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sharedkernel.Dtos
{
    public struct SortCriteria
    {
        private static readonly ImmutableDictionary<string, SortOrder> SortOrderDic = new Dictionary<string, SortOrder>
        {
            {"ASC", SortOrder.Ascending },
            {"DESC", SortOrder.Descending},
            {"Ascending", SortOrder.Ascending},
            {"Descending", SortOrder.Descending}
        }.ToImmutableDictionary();
        public SortCriteria(string property, SortOrder sortOder)
        {
            Property = string.IsNullOrWhiteSpace(property) ? null : property;
            SortOrder = sortOder;
        }

        public SortCriteria(string property, string sortOrder)
        {
            Guard.AgainstEmptyString(property, "Property");
            Guard.AgainstEmptyString(sortOrder, "Sort order");

            var sortDic = SortOrderDic.FirstOrDefault(x => x.Key.Equals(sortOrder, StringComparison.OrdinalIgnoreCase));

            Guard.AgainstNull(sortDic, "Invalid sort order string");

            Property = property;
            SortOrder = sortDic.Value;
        }

        public string Property { get; set; }
        public SortOrder SortOrder { get; set; }
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }
}
