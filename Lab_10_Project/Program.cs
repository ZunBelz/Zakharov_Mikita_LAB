using System;

namespace Lab_10_Project
{
    // Власний виняток
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string productName)
            : base($"Недостатня кількість товару \"{productName}\" на складі.")
        {
        }
    }

    // Клас товару
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва товару не може бути порожньою.");

            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price),
                    "Ціна повинна бути більшою за 0.");

            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock),
                    "Кількість товару не може бути від'ємною.");

            Name = name;
            Price = price;
            Stock = stock;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity),
                    "Кількість повинна бути більшою за 0.");

            if (quantity > Stock)
                throw new InsufficientStockException(Name);

            Stock -= quantity;
        }
    }

    // Клас замовлення
    public class Order
    {
        public Product Product { get; }
        public int Quantity { get; }

        public Order(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity),
                    "Кількість товару повинна бути більшою за 0.");

            Product = product;
            Quantity = quantity;
        }
    }

    // Сервіс замовлень
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            order.Product.ReduceStock(order.Quantity);

            Console.WriteLine(
                $"Замовлення оформлено: {order.Product.Name}, кількість: {order.Quantity}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product laptop = new Product(
                "Ноутбук ASUS",
                35000m,
                5);

            OrderService service = new OrderService();

            // Коректне замовлення
            try
            {
                Order order = new Order(laptop, 2);
                service.PlaceOrder(order);

                Console.WriteLine($"Залишок на складі: {laptop.Stock}");
            }
            catch (InsufficientStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка введення: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Перша операція завершена.");
            }

            Console.WriteLine();

            // Недостатня кількість товару
            try
            {
                Order order = new Order(laptop, 10);
                service.PlaceOrder(order);
            }
            catch (InsufficientStockException ex)
            {
                Console.WriteLine($"Помилка складу: {ex.Message}");
                Console.WriteLine($"Залишок після помилки: {laptop.Stock}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка введення: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Друга операція завершена.");
            }

            Console.WriteLine();

            // Некоректна кількість
            try
            {
                Order invalidOrder = new Order(laptop, -3);
                service.PlaceOrder(invalidOrder);
            }
            catch (InsufficientStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка введення: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Третя операція завершена.");
            }
        }
    }
}