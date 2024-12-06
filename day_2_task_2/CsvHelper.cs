using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_2_task_2
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
                    if (values.Length != 3)                 //  Якщо недостатньо полів
                    {
                        throw new FormatException("Неправильний формат CSV.");
                    }

                    string name = values[0];                                //  Назва товару

                    if (!decimal.TryParse(values[1], out decimal price))    //  Ціна товару
                    {
                        throw new FormatException($"Ціна '{values[1]}' має неправильний формат.");
                    }

                    string category = values[2];                            //  Категорія товару

                    products.Add(new Product { Name = name, Price = price, Category = category });
                }
            }
            return products;
        }
    }
}
