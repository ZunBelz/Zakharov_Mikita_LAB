using ShopApp.Models;

Product product1 = new Product
{
    Name = "Laptop",
    Price = 35000,
    Category = "Electronics"
};

Product product2 = new Product
{
    Name = "Mouse",
    Price = 800,
    Category = "accessories"
};

Customer customer1 = new Customer
{
    Name = "Ivan Petrenko"
};

Customer customer2 = new Customer
{
    Name = "Olena Kovalenko"
};

Console.WriteLine("Products:");
Console.WriteLine($"{product1.Name}, {product1.Price} UAH, {product1.Category}");
Console.WriteLine($"{product2.Name}, {product2.Price} UAH, {product2.Category}");

Console.WriteLine("\nCustomers:");
Console.WriteLine(customer1.Name);
Console.WriteLine(customer2.Name);