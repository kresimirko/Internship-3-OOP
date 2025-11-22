using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Entities;

public class EntityFlight(
    string name,
    DateTime departure,
    string departureLocation,
    DateTime arrival,
    string arrivalLocation,
    int distance,
    EntityAirplane airplane,
    ObjectCollectionAircrew aircrew) : Entity(name)
{
    public DateTime Departure { get; set; } = departure;
    public string DepartureLocation { get; } = departureLocation;
    public DateTime Arrival { get; set; } = arrival;
    public string ArrivalLocation { get; } = arrivalLocation;
    public int Distance { get; } = distance;
    public EntityAirplane Airplane { get; } = airplane;
    public ObjectCollectionAircrew Aircrew { get; set; } = aircrew;
}
