namespace ShopApp.Models;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    protected Product(
        int id,
        string name,
        decimal price,
        string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public abstract void DisplayInfo();
}