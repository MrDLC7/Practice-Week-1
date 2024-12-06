using System;                           //  Підключення простору імен для базових типів даних  
using System.Collections.Generic;       //  Підключення простору імен для колекцій, таких як Dictionary  
using System.Linq;                      //  Підключення простору імен для LINQ (Integrated Query)  

class User
{
    public string Name { get; set; }    //  Властивість для зберігання імені користувача  
    public int Age { get; set; }        //  Властивість для зберігання віку користувача  
}

class Program
{
    static void Main()
    {
        //  Словник користувачів 
        Dictionary<int, User> users = new Dictionary<int, User>
        {
            {1, new User { Name = "Alice", Age = 36 } },  
            {2, new User { Name = "Bob", Age = 26 } },    
            {3, new User { Name = "Charlie", Age = 32} }   
        };

        //  Додавання нового користувача
        users[4] = new User { Name = "David", Age = 34 };  

        //  Знаходження користувачів старше 30 років за допомогою LINQ  
        var olderUsers = users.Values.Where(u => u.Age > 30).ToList();      //  Фільтрування користувачів за віком  

        //  Вивід списку всіх користувачів  
        Console.WriteLine("Користувачі");
        foreach (var user in users)                               
        {
            int userId = user.Key;                                          //  Отримання ID користувача  
            User u = user.Value;                                            //  Отримання інформації про користувача  
            Console.WriteLine($"ID: {userId}, {u.Name} - {u.Age} років");   //  Вивід даних про кожного користувача  
        }
        Console.WriteLine();

        //  Вивід списку користувачів старше 30 років  
        Console.WriteLine("Користувачі старше 30");
        foreach (var user in olderUsers)                                    //  Проходження по списку фільтрованих користувачів  
        {
            Console.WriteLine($"{user.Name} - {user.Age} років");           //  Вивід даних про старших користувачів  
        }
        Console.WriteLine();

        //  Список імен користувачів  
        List<string> userNames = users.Values.Select(u => u.Name).ToList(); //  Отримання списку імен з усіх користувачів  

        //  Вивід списку всіх імен користувачів  
        Console.WriteLine("Всі імена користувачів");
        Console.WriteLine(string.Join(", ", userNames));                    // Виведення імен через розділювач  
    }
}