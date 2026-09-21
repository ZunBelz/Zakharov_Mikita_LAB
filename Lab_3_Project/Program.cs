using ShopApp.Models;

List<Product> products = new()
{
    new ElectronicsProduct("Laptop", 35000),
    new FoodProduct("Bread", 40),
    new ClothingProduct("T-shirt", 600)
};

Console.WriteLine("Products:");

foreach (Product product in products)
{
    Console.WriteLine(
        $"{product.Name} | {product.Category} | Final price: {product.CalculatePrice()} UAH");
}