using day_2_task_2;
class Program
{
    static void Main()
    {
        string filepath = "product.csv";        //  Шлях до файлу

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
            List<Product> products = CsvHelper.ReadCsv(filepath);

            //  Відображення даних у вигляді таблиці
            CsvManager.DisplayTable(products);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}