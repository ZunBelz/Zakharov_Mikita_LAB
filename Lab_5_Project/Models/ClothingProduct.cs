namespace ShopApp.Models;

public class ClothingProduct : Product
{
    public ClothingProduct(string name, decimal price)
        : base(name, price, "Clothing")
    {
    }

    public override decimal CalculatePrice()
    {
        return Price * 1.1m;
    }
}