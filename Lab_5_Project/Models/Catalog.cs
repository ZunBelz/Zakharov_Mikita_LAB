namespace ShopApp.Models;

public class Catalog<T>
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public List<T> GetAll()
    {
        return new List<T>(items);
    }

    public int Count => items.Count;
}