namespace ShopApp.Models;

public class Shop
{
    public string Name { get; set; }

    private readonly List<Product> products = new();

    public Shop(string name)
    {
        Name = name;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void DisplayProducts()
    {
        foreach (Product product in products)
        {
            Console.WriteLine(
                $"{product.Name} | {product.Category} | {product.CalculatePrice()} UAH");
        }
    }
}