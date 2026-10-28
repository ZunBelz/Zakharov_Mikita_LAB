using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_8_Project
{
    // ==========================
    // Аргументи події
    // ==========================
    public class StockChangedEventArgs : EventArgs
    {
        public string ProductName { get; }
        public int NewQuantity { get; }

        public StockChangedEventArgs(string productName, int newQuantity)
        {
            ProductName = productName;
            NewQuantity = newQuantity;
        }
    }

    // ==========================
    // Клас Product
    // ==========================
    public class Product
    {
        private int stock;

        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public event EventHandler<StockChangedEventArgs>? StockChanged;

        public int Stock
        {
            get { return stock; }
        }

        public Product(string name, string category, decimal price, int stock)
        {
            Name = name;
            Category = category;
            Price = price;
            this.stock = stock;
        }

        public void UpdateStock(int newQuantity)
        {
            stock = newQuantity;

            StockChanged?.Invoke(this,
                new StockChangedEventArgs(Name, newQuantity));
        }
    }

    // ==========================
    // Клас Order
    // ==========================
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Order(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    // ==========================
    // Підписник на подію
    // ==========================
    public class WarehouseNotification
    {
        public void LowStockHandler(object? sender, StockChangedEventArgs e)
        {
            if (e.NewQuantity < 10)
            {
                Console.WriteLine(
                    $"УВАГА! Товар \"{e.ProductName}\" закінчується. Залишок: {e.NewQuantity}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // --------------------------
            // Каталог товарів
            // --------------------------
            List<Product> products = new List<Product>
            {
                new Product("Ноутбук", "Електроніка", 35000, 15),
                new Product("Смартфон", "Електроніка", 25000, 8),
                new Product("Мишка", "Аксесуари", 900, 30)
            };

            // =================================================
            // ПІДЗАДАЧА 1. Делегат для перевірки товарів
            // =================================================

            Predicate<Product> expensiveProducts =
                p => p.Price > 10000;

            List<Product> selectedProducts =
                products.Where(p => expensiveProducts(p)).ToList();

            Console.WriteLine("Товари дорожчі за 10000 грн:");

            foreach (var product in selectedProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} грн");
            }

            Console.WriteLine();

            // =================================================
            // ПІДЗАДАЧА 2. Подія зміни залишку
            // =================================================

            WarehouseNotification notification =
                new WarehouseNotification();

            foreach (var product in products)
            {
                product.StockChanged += notification.LowStockHandler;
            }

            Console.WriteLine("Зміна залишку товарів:");

            products[0].UpdateStock(5);
            products[1].UpdateStock(3);

            Console.WriteLine();

            // =================================================
            // ПІДЗАДАЧА 3. Func та лямбда-вираз
            // =================================================

            Order order1 = new Order(products[0], 2);
            Order order2 = new Order(products[2], 3);

            Func<Order, decimal> calculateOrderSum =
                order => order.Product.Price * order.Quantity;

            Console.WriteLine(
                $"Сума замовлення 1: {calculateOrderSum(order1)} грн");

            Console.WriteLine(
                $"Сума замовлення 2: {calculateOrderSum(order2)} грн");
        }
    }
}
