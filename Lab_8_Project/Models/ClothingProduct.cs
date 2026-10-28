namespace ShopApp.Models;

public class ClothingProduct : Product
{
    public ClothingProduct(
        int id,
        string name,
        decimal price,
        string category)
        : base(id, name, price, category)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Name} - {Price}");
    }
}