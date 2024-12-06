//  Базовий клас із властивостями та методами
public abstract class Vehicle
{
    //  Автоматисні властивості
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    //  Конструктор
    protected Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    //  Віртуальний метод
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Трнспортний ззасіб: {Brand} {Model}\nРік випуску: {Year}");
    }

    //  Абстрактний метод
    public abstract void StartEngine();
}

//  Успадкування та поліморфізм
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    public Car(string brand, string model, int year, int numberOfDoors)
        : base(brand, model, year)
    {
        NumberOfDoors = numberOfDoors;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();         //  Метод базового класу
        Console.WriteLine($"Автомобіль: {NumberOfDoors} дверей");
    }

    public override void StartEngine()
    {
        Console.WriteLine("Двигун автомобіля запущено!");
    }
}

public class Motocycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public Motocycle(string brand, string model, int year, bool hasSidecar)
        : base(brand, model, year)
    {
        HasSidecar = hasSidecar;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Мотоцикл: {(HasSidecar ? "з коляскою" : "без коляски")}");
    }

    public override void StartEngine()
    {
        Console.WriteLine("Двигун мотоцикла запустився");
    }
}

//  Інкапсуляція через приватні поля та властивості
public class Truck : Vehicle
{
    private int _loadCapacity;

    public int LoadCapacity
    {
        get => _loadCapacity;
        set
        {
            if (value < 0)
                throw new ArgumentException("Вантажопідйомність не може бути від'ємною");
            _loadCapacity = value;
        }
    }

    public Truck(string brand, string model, int year, int loadCapacity)
        : base(brand, model, year)
    {
        LoadCapacity = loadCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Вантажівка: Вантажопідйомність {LoadCapacity} кг");
    }

    public override void StartEngine()
    {
        Console.WriteLine("Двигун вантажівки запустився");
    }
}

//  Демонстрація роботи з об'єктами
class Program
{
    static void Main(string[]args)
    {
        //  Створення об'єктів
        Vehicle car = new Car("Toyota", "Camry", 2021, 4);
        Vehicle motocycle = new Motocycle("Harley-Davidson", "Street 750", 2020, false);
        Vehicle truck = new Truck("Volvo", "FH16", 2019, 20000);

        //  Поліморфізм: виклик методів через базовиий клас
        Vehicle[] vehicles = { car, motocycle, truck };
        
        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayInfo();          //  Виведення на екран
            vehicle.StartEngine();          //  Запустити мотор
            Console.WriteLine();
        }

        //  Демонстрація обробки виключень
        try
        {
            var invalidTruck = new Truck("Ford", "F-150", 2023, -500);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }
    }
}