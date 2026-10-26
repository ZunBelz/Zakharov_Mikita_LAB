using ShopApp.Models;

var repository = new Repository<Product>();

var tshirt = new ClothingProduct(
    1,
    "Футболка",
    500,
    "Одяг");

var laptop = new ElectronicsProduct(
    2,
    "Ноутбук",
    35000,
    "Електроніка");

var apple = new FoodProduct(
    3,
    "Яблуко",
    25,
    "Продукти");

repository.Add(tshirt);
repository.Add(laptop);
repository.Add(apple);

Console.WriteLine(
    $"Кількість товарів: {repository.Count}");

Catalog catalog = new();

catalog.AddProduct(tshirt);
catalog.AddProduct(laptop);
catalog.AddProduct(apple);

Console.WriteLine("\nЕлектроніка:");

foreach (var product in catalog.GetProductsByCategory("Електроніка"))
{
    Console.WriteLine(product.Name);
}

Console.WriteLine("\nПошук товарів дорожче 1000 грн:");

var result = SearchHelper.Find(
    repository.GetAll(),
    p => p.Price > 1000);

foreach (var product in result)
{
    Console.WriteLine(
        $"{product.Name} - {product.Price}");
}