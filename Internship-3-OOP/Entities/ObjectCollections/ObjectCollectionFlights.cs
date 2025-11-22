namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionFlights(string? name = null, List<EntityFlight>? members = null)
    : ObjectCollection<EntityFlight>(name, members, "Nema letova.")
{
    public override string TurnDataTableIntoString(bool usesAltFormat = false)
    {
        var table = new List<List<string>> {};
        if (!usesAltFormat)
        {
            table.Add(["#", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja"]);
            table.AddRange(Members.Select((flight, i) => (List<string>)
            [
                i.ToString(),
                UiAssist.GetShortGuidString(flight.Guid),
                flight.Name,
                flight.Departure.ToString("G"),
                flight.Arrival.ToString("G"),
                flight.Distance.ToString() + " km",
                UiAssist.GetShortTimeSpan(flight.Arrival - flight.Departure)
            ]));
        }
        else
        {
            table.Add(["#", "ID", "Naziv", "Datum polaska", "Mjesto polaska", "Datum dolaska", "Mjesto dolaska", "Udaljenost", "Vrijeme putovanja"]);
            table.AddRange(Members.Select((flight, i) => (List<string>)
            [
                i.ToString(),
                UiAssist.GetShortGuidString(flight.Guid),
                flight.Name,
                flight.Departure.ToString("G"),
                flight.DepartureLocation,
                flight.Arrival.ToString("G"),
                flight.ArrivalLocation,
                flight.Distance.ToString() + " km",
                UiAssist.GetShortTimeSpan(flight.Arrival - flight.Departure)
            ]));
        }
    
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
