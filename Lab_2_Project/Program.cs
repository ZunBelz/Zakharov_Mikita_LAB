using ShopApp.Models;

try
{
    Product product1 = new Product(
        "Laptop",
        35000,
        "Electronics",
        10);

    Product product2 = new Product(
        "Mouse",
        800,
        "Accessories",
        20);

    Customer customer1 = new Customer("Ivan Petrenko");
    Customer customer2 = new Customer("Olena Kovalenko");

    Console.WriteLine("Products:");

    Console.WriteLine($"{product1.Name} | {product1.Price} UAH | {product1.Category} | Qty: {product1.Quantity}");
    Console.WriteLine($"{product2.Name} | {product2.Price} UAH | {product2.Category} | Qty: {product2.Quantity}");

    Console.WriteLine("\nCustomers:");

    Console.WriteLine(customer1.Name);
    Console.WriteLine(customer2.Name);

    Console.WriteLine("\nStock operations:");

    product1.AddProduct(5);

    Console.WriteLine($"After delivery: {product1.Quantity}");

    product1.RemoveProduct(8);

    Console.WriteLine($"After sale: {product1.Quantity}");

    product1.RemoveProduct(50);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}