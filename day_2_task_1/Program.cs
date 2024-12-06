﻿using day_2_task_1;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();       //  Список товарів
        bool isRunning = true;                              //  Прапорець роботи програми

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
                        isRunning = false;
                        Console.WriteLine("Програма завершена.");
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
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
        Console.WriteLine("5. Вихід з програми\n");
    }
}