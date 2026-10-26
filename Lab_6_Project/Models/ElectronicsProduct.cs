namespace ShopApp.Models;

public class ElectronicsProduct : Product
{
    public ElectronicsProduct(
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