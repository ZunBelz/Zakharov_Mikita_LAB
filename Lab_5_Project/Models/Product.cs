namespace ShopApp.Models;

public class Product : IOrderable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public Product(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public virtual decimal CalculatePrice()
    {
        return Price;
    }
}