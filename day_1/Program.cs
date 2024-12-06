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
        Console.WriteLine($"Трнспортний ззасіб: {Brand} {Model}, Рік випуску: {Year}");
    }

    //  Абстрактний метод
    public abstract void StartEngine();
}

