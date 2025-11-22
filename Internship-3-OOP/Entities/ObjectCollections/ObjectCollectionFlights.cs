namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionFlights(List<EntityFlight>? members = null)
    : ObjectCollection<EntityFlight>(members, "Nema letova.")
{
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["#", "Kratki ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja"]);
        table.AddRange(Members.Select((flight, i) => (List<string>)
        [
            i.ToString(),
            UiAssist.GetShortGuidString(flight.Guid),
            flight.Title,
            flight.Departure.ToString("G"),
            flight.Arrival.ToString("G"),
            flight.Distance.ToString() + " km",
            UiAssist.GetShortTimeSpan(flight.Arrival - flight.Departure)
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
    
    public override bool Add(EntityFlight flight)
    {
        if (Members.Contains(flight)) return false;
        
        Members.Add(flight);
        UpdateDateOfModification();
        return true;
    }
}
