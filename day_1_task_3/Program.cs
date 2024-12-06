using System;       
using System.IO;   

class InvalidOperationException : Exception                                 //  Визначення власного виключення  
{
    public InvalidOperationException(string message) : base(message) { }    //  Конструктор для власного виключення  
}

class Program
{
    static void Main()
    {
        //  Введення числа з обробкою виключень  
        try
        {
            Console.WriteLine("Введіть число:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ви ввели: {number}");
        }
        catch (FormatException ex)                  //  Обробка виключення форматування  
        {
            Console.WriteLine("Помилка: Ви повинні ввести дійсне число.");
            Console.WriteLine($"Деталі: {ex.Message}");
        }
        catch (Exception ex)                        //  Обробка інших несподіваних виключень  
        {
            Console.WriteLine("Сталася несподівана помилка.");
            Console.WriteLine($"Деталі: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Виконання програми завершено.");
        }

        //  Валідація віку  
        try
        {
            ValidateAge(-5);                        //  Спроба ввести негативний вік  
        }
        catch (ArgumentException ex)                //  Обробка помилки валідації  
        {
            Console.WriteLine($"Помилка валідації: {ex.Message}");
        }

        //  Доступ до масиву  
        try
        {
            int[] numbers = { 1, 2, 3 };
            Console.WriteLine(numbers[5]);          //  Вихід за межі масиву  
        }
        catch (IndexOutOfRangeException ex)         //  Обробка помилки виходу за межі  
        {
            Console.WriteLine("Помилка: Індекс виходить за межі масиву.");
        }
        catch (Exception ex)                        //  Обробка інших несподіваних виключень  
        {
            Console.WriteLine("Сталася несподівана помилка.");
        }

        //  Зчитування з файлу  
        StreamReader reader = null;                 //  Ініціалізація StreamReader  
        try
        {
            reader = new StreamReader("file.txt");  //  Спроба відкрити файл  
            Console.WriteLine(reader.ReadToEnd());  //  Читання вмісту файлу  
        }
        catch (FileNotFoundException ex)            //  Обробка помилки ненайденого файлу  
        {
            Console.WriteLine("Помилка: Файл не знайдено.");
        }
        finally
        {
            if (reader != null)
            {
                reader.Dispose();                   //  Закриття StreamReader  
                Console.WriteLine("StreamReader було закрито.");
            }
        }

        //  Обробка власного виключення  
        try
        {
            PerformOperation(false);                //  Спроба виконати операцію  
        }
        catch (InvalidOperationException ex)        //  Обробка власного виключення  
        {
            Console.WriteLine($"Власне виключення: {ex.Message}");
        }
    }

    //  Метод для валідації віку  
    static void ValidateAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Вік не може бути від'ємним.");     //  Генерація виключення при недійсному віці  
        }
        Console.WriteLine($"Дійсний вік: {age}");                           //  Вивід дійсного віку  
    }

    //  Метод для виконання операції з перевіркою  
    static void PerformOperation(bool isValid)
    {
        if (!isValid)
        {
            throw new InvalidOperationException("Операція є недійсною.");   //  Генерація власного виключення  
        }
        Console.WriteLine("Операцію виконано успішно.");                    //  Вивід про успішне виконання  
    }
}