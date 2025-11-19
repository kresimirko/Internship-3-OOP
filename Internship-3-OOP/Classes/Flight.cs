namespace Internship_3_OOP.Classes;

public class Flight(string title, DateTime departure, DateTime arrival, int distance, DateTime length) : Entity
{
    public string Title { get; private set; } = title;
    public DateTime Departure { get; private set; } = departure;
    public DateTime Arrival { get; private set; } = arrival;
    public int Distance { get; private set; } = distance;
    public DateTime Length { get; private set; } = length;
}
