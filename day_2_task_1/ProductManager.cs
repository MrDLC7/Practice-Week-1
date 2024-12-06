using System.Text;

namespace day_2_task_1
{
    internal static class ProductManager
    {   
        //  Додавання товару
        public static void AddProduct(List<Product> products)
        {
            // Налаштування кодування для вводу та виводу  
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine();
            Console.WriteLine(name);

            Console.Write("Введіть  ціну товару: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Ціна введена не правильно.");
                return;
            }

            Console.Write("Введіть категорію товару: ");
            string category = Console.ReadLine();

            products.Add(new Product {Name = name, Price = price, Category = category});
            Console.WriteLine("Товар успішно додано.");
        }

        //  Видалення товару
        public static void RemoveProduct(List<Product> products)
        {
            Console.Write("Введіть назву товару для видалення: ");
            string name = Console.ReadLine();

            var product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Товар видалено успішно.");
            }
            else
            {
                Console.WriteLine("Товар не знайдено");
            }
        }

        //  Пошук товару
        public static void SearchProduct(List<Product> products)
        {
            Console.Write("Введіть назву товару для пошуку: ");
            string name = Console.ReadLine();

            var product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.WriteLine($"Знайдений товар: {product.Name}, Ціна: {product.Price:C}, Категорія: {product.Category}");
            }
            else
            {
                Console.WriteLine("Товар не знайдено");
            }
        }

        //  Відображення товарів у вигляді таблиці
        public static void DisplayTable(List<Product> products)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"|{"Назва", -20}|{"Ціна", -16}|{"Категорія", -20}|");
            Console.WriteLine(new string('-', 60));

            foreach(var product in products)
            {
                Console.WriteLine($"|{product.Name, -20}|{product.Price, -16:C}|{product.Category, -20}|");
            }
            Console.WriteLine(new string('-', 60));
        }
    }
}
