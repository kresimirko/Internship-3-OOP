namespace Internship_3_OOP.Entities;

public class EntityFlight(string title, DateTime departure, DateTime arrival, int distance) : Entity
{
    public string Title { get; private set; } = title;
    public DateTime Departure { get; private set; } = departure;
    public DateTime Arrival { get; private set; } = arrival;
    public int Distance { get; private set; } = distance;
}
