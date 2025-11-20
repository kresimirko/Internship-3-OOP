using Internship_3_OOP.Static;

namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionFlights(List<EntityFlight>? flightList = null) : ObjectCollection<EntityFlight>
{
    public void Add(string title, DateTime departure, DateTime arrival, int distance)
    {
        Members.Add(new EntityFlight(title, departure, arrival, distance));
    }
    
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja"]);
        table.AddRange(Members.Select(flight => (List<string>)
        [
            flight.Id.ToString(),
            flight.Title,
            flight.Departure.ToString("yyyy-MM-dd"),
            flight.Arrival.ToString("yyyy-MM-dd"),
            flight.Distance.ToString(),
            (flight.Arrival - flight.Departure).TotalMinutes.ToString("N2")
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
