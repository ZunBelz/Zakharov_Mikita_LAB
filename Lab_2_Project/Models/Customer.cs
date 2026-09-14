namespace ShopApp.Models;

public class Customer
{
    private string name = "";
    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ім'я покупця не може бути порожнім.");
            name = value;
        }
    }

    public Customer(string name)
    {
        Name = name;
    }
}