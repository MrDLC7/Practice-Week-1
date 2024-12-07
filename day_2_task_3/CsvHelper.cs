namespace day_2_task_3
{
    internal static class CsvHelper
    {
        //  Читання даних з файлу CSV
        public static List<Product> ReadCsv(string filepath)
        {
            List<Product> products = new List<Product>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                bool isFirstLine = true;

                while ((line = reader.ReadLine()) != null)
                {
                    //  Пропуск атрибутів
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    string[] values = line.Split(',');      //  Розділення рядків у точці коми

                    try
                    {
                        if (values.Length != 3) // Якщо недостатньо полів  
                        {
                            // Встановлення червоного кольору тексту  
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new FormatException("Неправильний формат CSV.");
                        }

                        string name = values[0]; // Назва товару  

                        if (!decimal.TryParse(values[1], out decimal price)) // Ціна товару  
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new FormatException($"Ціна '{values[1]}' має неправильний формат.");
                        }

                        string category = values[2]; // Категорія товару  

                        products.Add(new Product { Name = name, Price = price, Category = category });
                    }
                    catch (FormatException ex)
                    {
                        // Виведення повідомлення про помилку  
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        // Повернення початкового кольору після обробки помилки  
                        Console.ResetColor();
                    }
                }
            }
            return products;
        }

        //  Запис у файл CSV
        public static void WriteCsv(string filepath, List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine("Назва,Ціна,Категорія");
                foreach (Product product in products)
                {
                    writer.WriteLine($"{product.Name},{product.Price},{product.Category}");
                }
            }
        }
    }
}
