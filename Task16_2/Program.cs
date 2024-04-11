using System.IO;
using System.Text.Json;

namespace Task16_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxProduct = products[0];
            foreach (Product p in products) 
            {
                if (p.Price > maxProduct.Price)
                {
                    maxProduct = p;
                }
            }
            Console.WriteLine($"самый дорогой товар {maxProduct.Name} цена {maxProduct.Price}");
        }
    }
}