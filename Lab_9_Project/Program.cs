#nullable enable

using System;

namespace Lab_9_Project
{
    // ==========================
    // Клас Product
    // ==========================
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; }

        public Product(
            string name,
            decimal price,
            int stock,
            string? description,
            string sku)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            SKU = sku;
        }
    }

    // ==========================
    // Record
    // ==========================
    public record ProductSnapshot(
        string Name,
        decimal Price,
        int Stock,
        string? Description
    );

    // ==========================
    // Звичайна struct
    // ==========================
    public struct PriceValue
    {
        public decimal Value { get; set; }

        public PriceValue(decimal value)
        {
            Value = value;
        }
    }

    // ==========================
    // Допоміжний клас
    // ==========================
    public static class ProductData
    {
        // Pattern Matching
        public static string GetProductCategory(Product product)
        {
            return product switch
            {
                { Price: >= 30000 } => "Преміум товар",

                { Price: >= 10000 } => "Середній ціновий сегмент",

                { Stock: 0 } => "Немає в наявності",

                _ => "Бюджетний товар"
            };
        }

        // Nullable Reference Types
        public static string GetDescription(Product product)
        {
            return product.Description is { Length: > 0 }
                ? product.Description
                : "Опис відсутній";
        }

        // Ranges
        public static string GetSkuPrefix(string sku)
        {
            if (sku.Length >= 4)
            {
                return sku.Substring(0, 4);
            }

            return sku;
        }

        public static ProductSnapshot CreateSnapshot(Product product)
        {
            return new ProductSnapshot(
                product.Name,
                product.Price,
                product.Stock,
                product.Description
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product(
                "Ноутбук ASUS",
                35000m,
                5,
                null,
                "SKU-12345-ABC"
            );

            // ==========================
            // Record
            // ==========================
            ProductSnapshot snapshot =
                ProductData.CreateSnapshot(product);

            Console.WriteLine("Початкове зведення:");
            Console.WriteLine(snapshot);

            ProductSnapshot updatedSnapshot =
                snapshot with { Price = 40000m };

            Console.WriteLine("\nПісля копіювання через with:");
            Console.WriteLine(updatedSnapshot);

            // ==========================
            // Struct
            // ==========================
            PriceValue priceValue =
                new PriceValue(product.Price);

            Console.WriteLine(
                $"\nЦіна через struct: {priceValue.Value}");

            // ==========================
            // Nullable
            // ==========================
            Console.WriteLine("\nОпис товару:");
            Console.WriteLine(
                ProductData.GetDescription(product));

            // ==========================
            // Pattern Matching
            // ==========================
            Console.WriteLine("\nКатегорія товару:");
            Console.WriteLine(
                ProductData.GetProductCategory(product));

            // ==========================
            // Range / Substring
            // ==========================
            Console.WriteLine("\nПрефікс SKU:");
            Console.WriteLine(
                ProductData.GetSkuPrefix(product.SKU));
        }
    }
}