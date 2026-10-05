using ShopApp.Models;

Catalog<Product> catalog = new();

catalog.Add(new ElectronicsProduct("Laptop", 35000));
catalog.Add(new FoodProduct("Bread", 40));
catalog.Add(new ClothingProduct("T-Shirt", 600));

Console.WriteLine($"Products in catalog: {catalog.Count}");

Console.WriteLine("\nAll products:");

SearchHelper.DisplayProducts(
    catalog.GetAll());

Console.WriteLine("\nProducts more expensive than 500 UAH:");

List<Product> result =
    SearchHelper.Find(
        catalog.GetAll(),
        product => product.Price > 500);

SearchHelper.DisplayProducts(result);