namespace ShopApp.Models;

public static class SearchHelper
{
    public static List<T> Find<T>(
        IEnumerable<T> items,
        Func<T, bool> predicate)
    {
        return items.Where(predicate).ToList();
    }

    public static void DisplayProducts<T>(
        IEnumerable<T> items)
        where T : Product
    {
        foreach (T item in items)
        {
            Console.WriteLine(
                $"{item.Name} | {item.Category} | {item.CalculatePrice()} UAH");
        }
    }
}