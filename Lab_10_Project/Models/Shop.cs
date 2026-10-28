using System.Collections.Generic;

namespace ShopApp.Models
{
    public class Shop
    {
        private readonly List<Product> cart = new();

        public void AddToCart(Product product)
        {
            cart.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            cart.Remove(product);
        }

        public List<Product> GetCart()
        {
            return cart;
        }
    }
}