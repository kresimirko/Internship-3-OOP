namespace Internship_3_OOP.Entities;

public class EntityAirplane(
    string name,
    int manufactureYear,
    Dictionary<FlightCategory, int> flightCategoriesAndSeats,
    List<EntityFlight>? flights = null) : Entity(name)
{
    public int ManufactureYear { get; private set; } = manufactureYear;
    public Dictionary<FlightCategory, int> FlightCategoriesAndSeats { get; } = flightCategoriesAndSeats;
    public List<EntityFlight> Flights { get; } = flights ?? [];
    
    public static readonly Dictionary<FlightCategory, string> FlightCategoryCroatianMap = new Dictionary<FlightCategory, string>
    {
        { FlightCategory.Standard, "standardna" },
        { FlightCategory.Business, "poslovna" },
        { FlightCategory.Vip, "VIP" },
    };
}

public enum FlightCategory
{
    Standard,
    Business,
    Vip
}
