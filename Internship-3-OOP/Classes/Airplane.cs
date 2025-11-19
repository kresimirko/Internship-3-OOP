namespace Internship_3_OOP.Classes;

public class Airplane(string title, string manufactureYear) : Entity
{
    public string Title { get; private set; } = title;
    public string ManufactureYear { get; private set; } = manufactureYear;
    public Flight[] Flights { get; private set; } = [];
    public FlightCategory[] Categories { get; private set; } = [];
}

public enum FlightCategory
{
    Standard,
    Business,
    Vip
}
