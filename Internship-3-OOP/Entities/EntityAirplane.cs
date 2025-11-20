namespace Internship_3_OOP.Entities;

public class EntityAirplane(
    string title,
    int manufactureYear,
    Dictionary<FlightCategory, int> flightCategoriesAndSeats,
    List<Guid>? flights = null) : Entity
{
    public string Title { get; private set; } = title;
    public int ManufactureYear { get; private set; } = manufactureYear;
    public Dictionary<FlightCategory, int> FlightCategoriesAndSeats { get; } = flightCategoriesAndSeats;
    public List<Guid> Flights { get; } = flights ?? [];
}

public enum FlightCategory
{
    Standard,
    Business,
    Vip
}
