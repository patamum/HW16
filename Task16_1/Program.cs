using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.IO;
using System.Text.Unicode;

namespace Task16_1
{
    internal class Program
    {
        public static JavaScriptEncoder Encoder { get; private set; }
        public static bool WriteIndented { get; private set; }

        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену");
                double price = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product() { Id = id, Name = name, Price = price };
            }

            JsonSerializerOptions options = new JsonSerializerOptions();
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);
                WriteIndented = true;
            }
            string jsonString = JsonSerializer.Serialize(products, options);
            
            using (StreamWriter sw = new StreamWriter("../../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
            
        }
    }
}