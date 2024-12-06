using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_2_task_2
{
    internal static class CsvManager
    {
        //  Відображення товарів у вигляді таблиці
        public static void DisplayTable(List<Product> products)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"|{"Назва",-20}|{"Ціна",-16}|{"Категорія",-20}|");
            Console.WriteLine(new string('-', 60));

            foreach (var product in products)
            {
                Console.WriteLine($"|{product.Name,-20}|{product.Price,-16:C}|{product.Category,-20}|");
            }
            Console.WriteLine(new string('-', 60));
        }
    }
}
