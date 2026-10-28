namespace ShopApp.Models;

public class FoodProduct : Product
{
    public FoodProduct(
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