namespace Internship_3_OOP.Entities;

public class EntityFlight(
    string name,
    DateTime departure,
    string departureLocation,
    DateTime arrival,
    string arrivalLocation,
    int distance) : Entity(name)
{
    public DateTime Departure { get; private set; } = departure;
    public string DepartureLocation { get; } = departureLocation;
    public DateTime Arrival { get; private set; } = arrival;
    public string ArrivalLocation { get; } = arrivalLocation;
    public int Distance { get; private set; } = distance;
}
