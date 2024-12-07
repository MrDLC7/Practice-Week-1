using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_2_task_3
{
    internal static class ConsoleUtility
    {
        //  Відображення  помилок червоним кольором
        public static void TextColorRed(string input)
        {
            // Встановлюємо червоний колір тексту  
            Console.ForegroundColor = ConsoleColor.Red;

            // Виводимо текст у червоному кольорі  
            Console.WriteLine(input);

            // Повертаємо початковий колір  
            Console.ResetColor();
        }
    }
}
