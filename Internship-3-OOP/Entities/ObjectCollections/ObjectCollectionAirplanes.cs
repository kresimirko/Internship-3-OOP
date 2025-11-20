using Internship_3_OOP.Static;

namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAirplanes(List<EntityAirplane>? airplaneList = null) : ObjectCollection<EntityAirplane>
{
    public void Add(string title, int manufactureYear,
        Dictionary<FlightCategory, int> flightCategoriesAndSeats, List<Guid>? flights = null)
    {
        Members.Add(new EntityAirplane(title, manufactureYear, flightCategoriesAndSeats, flights));
    }
    
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["ID", "Naziv", "Godina proizvodnje", "Broj letova", "Kategorije"]);
        table.AddRange(Members.Select(airplane => (List<string>)
        [
            airplane.Id.ToString(),
            airplane.Title,
            airplane.ManufactureYear.ToString(),
            airplane.Flights.Count.ToString(),
            "placeholder"
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
