namespace ShopApp.Models;

public class ElectronicsProduct : Product
{
    public ElectronicsProduct(string name, decimal price)
        : base(name, price, "Electronics")
    {
    }

    public override decimal CalculatePrice()
    {
        return Price * 1.2m;
    }
}