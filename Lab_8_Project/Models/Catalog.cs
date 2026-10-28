using System.Collections.Generic;

namespace ShopApp.Models
{
    public class Catalog
    {
        private readonly Dictionary<int, Product> products = new();

        public void AddProduct(Product product)
        {
            products[product.Id] = product;
        }

        public bool RemoveProduct(int id)
        {
            return products.Remove(id);
        }

        public Product? GetProduct(int id)
        {
            products.TryGetValue(id, out Product? product);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products.Values;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            foreach (var product in products.Values)
            {
                if (product.Category.Equals(
                    category,
                    System.StringComparison.OrdinalIgnoreCase))
                {
                    yield return product;
                }
            }
        }
    }
}