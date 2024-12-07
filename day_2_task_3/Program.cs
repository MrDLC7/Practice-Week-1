using day_2_task_3;
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();       //  Список товарів
        string filepath = "products.csv";                   //  Шлях до CSV-файлу
        bool isRunning = true;                              //  Прапорець роботи програми

        try
        {
            // Перевірка, чи існує файл  
            if (!File.Exists(filepath))
            {
                // Якщо файл не існує, створюємо його  
                using (File.Create(filepath))
                {
                    // Файл створено 
                    using (StreamWriter writer = new StreamWriter(filepath))
                    {
                        writer.WriteLine("Назва,Ціна,Категорія");
                    }
                }
                Console.WriteLine($"Файл {filepath} було створено.");
            }
            //  Зчитування даних з файлу CSV
            products = CsvHelper.ReadCsv(filepath);
        }
        catch (Exception ex)
        {
            ConsoleUtility.TextColorRed($"Помилка зчитування CSV: {ex.Message}");
        }

        while (isRunning)
        {
            PrintMenu();

            Console.Write("Оберіть опцію: ");
            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        ProductManager.AddProduct(products);
                        break;
                    case "2":
                        ProductManager.RemoveProduct(products);
                        break;
                    case "3":
                        ProductManager.SearchProduct(products);
                        break;
                    case "4":
                        ProductManager.DisplayTable(products);
                        break;
                    case "5":
                        CsvHelper.WriteCsv(filepath, products);
                        Console.WriteLine("Дані успішно збережені у CSV.");
                        break;
                    case "6":
                        isRunning = false;
                        Console.WriteLine("Програма завершена.");
                        break;
                    default:
                        ConsoleUtility.TextColorRed("Неправильний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            catch (Exception ex)
            {
                ConsoleUtility.TextColorRed($"Помилка: {ex.Message}");
            }
            finally
            {
                if (!isRunning)
                    Console.WriteLine("Програма завершена без помилок");
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("\nМеню:");
        Console.WriteLine("1. Додати товар");
        Console.WriteLine("2. Видалити товар");
        Console.WriteLine("3. Пошук товару");
        Console.WriteLine("4. Вивести на екран всі товари");
        Console.WriteLine("5. Зберегти список у файл CSV"); 
        Console.WriteLine("6. Вихід з програми\n");
    }
}