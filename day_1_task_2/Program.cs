//  List<T>;
using System;                             
using System.Collections.Generic;           

class Program
{
    static void Main()
    {
        //  Створення списку цілих чисел  
        List<int> numbers = new List<int> { 13, 20, 31 };
  
        DisplayInfo("Список", numbers);

        //  Додавання одиночного елемента до списку  
        numbers.Add(40);

        //  Додавання кількох елементів до списку  
        numbers.AddRange(new[] { 60, 75, 80 });

        DisplayInfo("Додавання", numbers);

        //  Вставка елемента на позицію 2 (третій елемент)  
        numbers.Insert(2, 45);

        DisplayInfo("Вставка", numbers);

        //  Видалення елемента по значенню (75)  
        numbers.Remove(75);

        //  Видалення елемента за індексом (2, що тепер являє собою 45)  
        numbers.RemoveAt(2);

        DisplayInfo("Видалення", numbers);

        //  Перевірка наявності елемента (45) у списку  
        bool contains = numbers.Contains(45);
  
        if (contains)
            DisplayInfo("Елемент 45 в наявності", numbers);

        //  Сортування списку у зворотному порядку (спаданням)  
        numbers.Sort((x, y) => y.CompareTo(x));

        DisplayInfo("Сортування за спаданням", numbers);

        //  Фільтрація непарних чисел з списку  
        var evenNumbers = numbers.FindAll(n => n % 2 != 0);
 
        DisplayInfo("Відфільтрований список", evenNumbers);
    }

    //  Метод для перегляду списку  
    static void DisplayInfo(string action, List<int> numbers)
    {
        //  Вивід заголовка для дії  
        Console.WriteLine(action);
        foreach (int number in numbers)
        {
            Console.Write(number.ToString() + '\t'); 
        }
        Console.WriteLine();  
    }
}