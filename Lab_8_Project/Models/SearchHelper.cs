using System;
using System.Collections.Generic;

namespace ShopApp.Models
{
    public static class SearchHelper
    {
        public static IEnumerable<T> Find<T>(
            IEnumerable<T> items,
            Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
