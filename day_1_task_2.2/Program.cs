//  Dictionary<Tkey, TValue>;
using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

class Program
{
    static void Main()
    {
        //  Словник для зберігання імені користувача та його віку
        Dictionary<string, int> users = new Dictionary<string, int>
        {
            {"Alice", 32 },
            {"Bob", 45 },
            {"Charlie", 25 }
        };
        DisplayInfo("Словник", users);

        //  Додавання елементів
        users["David"] = 28;
        //  Оновлення елемента
        users["Alice"] = 31;

        DisplayInfo("Додавання і Оновлення", users);

        //  Видалення елемента
        users.Remove("Bob");

        DisplayInfo("Видалення", users);

        //  Фільтрація по умові
        var olderThan = users.Where(u => u.Value > 30).ToList();

        Console.WriteLine("Користувачі старше 30");
        foreach (var user in olderThan)
        {
            Console.WriteLine(user);
        }
    }

    static void DisplayInfo(string action, Dictionary<string, int> users)
    {
        Console.WriteLine(action);
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
    }
}