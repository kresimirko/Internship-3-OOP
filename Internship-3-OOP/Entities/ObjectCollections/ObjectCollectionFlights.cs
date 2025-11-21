namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionFlights(List<EntityFlight>? members = null)
    : ObjectCollection<EntityFlight>(members, "Nema letova.")
{
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja"]);
        table.AddRange(Members.Select(flight => (List<string>)
        [
            UiAssist.GetShortGuidString(flight.Guid),
            flight.Title,
            flight.Departure.ToString("G"),
            flight.Arrival.ToString("G"),
            flight.Distance.ToString() + " km",
            GetShortTimeSpan(flight.Arrival - flight.Departure)
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }

    public static string GetShortTimeSpan(TimeSpan timeSpan)
    {
        return new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds).ToString();
    }
    
    public override void Add(EntityFlight flight)
    {
        if (Members.Contains(flight)) return;

        if (Storage.Flights.Guid != Guid)
        {
            if (Storage.Flights.Contains(flight)) return;
            
            Storage.Flights.Add(flight);
            Storage.Flights.UpdateDateOfModification();
        }
        
        Members.Add(flight);
        UpdateDateOfModification();
    }
}
