using ShopApp.Models;

ElectronicsProduct laptop =
    new ElectronicsProduct("Laptop", 35000);

FoodProduct bread =
    new FoodProduct("Bread", 40);

ClothingProduct tshirt =
    new ClothingProduct("T-Shirt", 600);

Shop shop = new Shop("My Shop");

shop.AddProduct(laptop);
shop.AddProduct(bread);
shop.AddProduct(tshirt);

Console.WriteLine("SHOP PRODUCTS:");
shop.DisplayProducts();

Console.WriteLine("\nINTERFACE POLYMORPHISM:");

List<IOrderable> orderables = new()
{
    laptop,
    bread,
    tshirt
};

foreach (IOrderable item in orderables)
{
    Console.WriteLine(
        $"Final price: {item.CalculatePrice()} UAH");
}