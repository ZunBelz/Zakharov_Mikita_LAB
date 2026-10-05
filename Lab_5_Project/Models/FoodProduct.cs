namespace ShopApp.Models;

public class FoodProduct : Product
{
    public FoodProduct(string name, decimal price)
        : base(name, price, "Food")
    {
    }

    public override decimal CalculatePrice()
    {
        return Price * 1.05m;
    }
}