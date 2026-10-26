using System.Linq;
using ShopApp.Models;

var repository = new Repository<Product>();

var tshirt = new ClothingProduct(1, "Футболка", 500, "Одяг");
var laptop = new ElectronicsProduct(2, "Ноутбук", 35000, "Електроніка");
var apple = new FoodProduct(3, "Яблуко", 25, "Продукти");

repository.Add(tshirt);
repository.Add(laptop);
repository.Add(apple);

var products = repository.GetAll();

Console.WriteLine("=== Фільтрація та сортування ===");

var filteredProducts = products
    .Where(p => p.Price > 1000)
    .OrderBy(p => p.Price);

foreach (var product in filteredProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price} грн");
}

Console.WriteLine("\n=== Проєкція каталогу ===");

var catalogProjection = products
    .Select(p => new
    {
        p.Name,
        p.Price,
        p.Category
    });

foreach (var item in catalogProjection)
{
    Console.WriteLine(
        $"{item.Name} | {item.Price} грн | {item.Category}");
}

Console.WriteLine("\n=== Групування за категоріями ===");

var groupedProducts = products
    .GroupBy(p => p.Category)
    .Select(g => new
    {
        Category = g.Key,
        Count = g.Count(),
        AveragePrice = g.Average(p => p.Price)
    });

foreach (var group in groupedProducts)
{
    Console.WriteLine($"\nКатегорія: {group.Category}");
    Console.WriteLine($"Кількість товарів: {group.Count}");
    Console.WriteLine($"Середня ціна: {group.AveragePrice:F2}");
}

Console.WriteLine("\n=== Демонстрація ToList() ===");

var materializedProducts = products
    .Where(p => p.Price > 100)
    .ToList();

Console.WriteLine(
    $"Знайдено товарів: {materializedProducts.Count}");
