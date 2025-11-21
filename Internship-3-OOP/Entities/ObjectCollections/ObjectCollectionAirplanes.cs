namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAirplanes(List<EntityAirplane>? members = null)
    : ObjectCollection<EntityAirplane>(members, "Nema aviona.")
{
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["ID", "Naziv", "Godina proizvodnje", "Broj letova", "Kategorije"]);
        table.AddRange(Members.Select(airplane => (List<string>)
        [
            UiAssist.GetShortGuidString(airplane.Guid),
            airplane.Title,
            airplane.ManufactureYear.ToString(),
            airplane.Flights.Count.ToString(),
            string.Join(", ", (from category in airplane.FlightCategoriesAndSeats
                select $"{category.Key.ToString()} ({category.Value})").ToArray())
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
