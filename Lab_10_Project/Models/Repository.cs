using System.Collections.Generic;

namespace ShopApp.Models
{
    public class Repository<T>
    {
        private readonly List<T> items = new();

        public void Add(T item)
        {
            items.Add(item);
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public IReadOnlyList<T> GetAll()
        {
            return items;
        }

        public int Count => items.Count;
    }
}