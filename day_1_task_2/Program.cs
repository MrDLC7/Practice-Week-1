//  List<T>
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //  Створення списку
        List<int> numbers = new List<int> { 13, 20, 31 };

        DisplayInfo("Список", numbers);

        //  Додавання елемента
        numbers.Add(40);
        numbers.AddRange(new[] { 60, 75, 80 });

        DisplayInfo("Додавання", numbers);

        //  Вставка елемента
        numbers.Insert(2, 45);

        DisplayInfo("Вставка", numbers);

        //  Видалення елемента
        numbers.Remove(70);
        numbers.RemoveAt(2);

        DisplayInfo("Видалення", numbers);

        //  Перевірка наявності елемента
        bool contains = numbers.Contains(45);

        if (contains)
            DisplayInfo("Елемент 45 в наявності", numbers);

        //  Сортування списку
        numbers.Sort((x, y) => y.CompareTo(x));

        DisplayInfo("Сортування за спаданням", numbers);

        //  Фільтрація за умовою
        var evenNumbers = numbers.FindAll(n => n % 2 != 0);

        DisplayInfo("Відфільтрований список", evenNumbers);
    }

    //  Перегляд списку
    static void DisplayInfo(string action, List<int> numbers)
    {
        Console.WriteLine(action);
        foreach (int number in numbers)
        {
            Console.Write(number.ToString() + '\t');
        }
        Console.WriteLine();
    }
}