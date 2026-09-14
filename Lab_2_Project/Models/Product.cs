namespace ShopApp.Models;

public class Product
{
    private string name = "";
    private string category = "";
    private decimal price;
    private int quantity;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва товару не може бути порожньою.");
            name = value;
        }
    }

    public string Category
    {
        get => category;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Категорія не може бути порожньою.");
            category = value;
        }
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Ціна не може бути від'ємною.");
            price = value;
        }
    }

    public int Quantity
    {
        get => quantity;
        private set
        {
            if (value < 0)
                throw new ArgumentException("Кількість не може бути від'ємною.");
            quantity = value;
        }
    }

    public Product(string name, decimal price, string category, int quantity)
    {
        Name = name;
        Price = price;
        Category = category;
        Quantity = quantity;
    }

    public void AddProduct(int amount)
    {
        if (amount > 0)
            Quantity += amount;
    }

    public void RemoveProduct(int amount)
    {
        if (amount <= 0)
            return;

        if (amount > Quantity)
        {
            Console.WriteLine("Недостатня кількість товару на складі.");
            return;
        }

        Quantity -= amount;
    }
}