namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAirplanes(string? name = null, List<EntityAirplane>? members = null)
    : ObjectCollection<EntityAirplane>(name, members, "Nema aviona.")
{
    public override string TurnDataTableIntoString(bool usesAltFormat = false)
    {
        var table = new List<List<string>> {};
        if (usesAltFormat)
            table.Add(["ID", "Naziv", "Godina proizvodnje", "Letovi", "Kategorije"]);
        else
            table.Add(["ID", "Naziv", "Godina proizvodnje", "Broj letova"]);

        foreach (var airplane in Members)
        {
            var toAdd = new List<string>();
            
            toAdd.AddRange([
                UiAssist.GetShortGuidString(airplane.Guid),
                airplane.Name,
                airplane.ManufactureYear.ToString()
            ]);

            if (usesAltFormat)
            {
                var flights = airplane.Flights.Select(flight => flight.Name);
                var flightsString = string.Join(", ", flights);
                if (flightsString.Length < 1) flightsString = "nema";
            
                var categories =
                    airplane.FlightCategoriesAndSeats.Select(category => $"{category.Key.ToString()} ({category.Value})");
                var categoriesString = string.Join(", ", categories);
                if (categoriesString.Length < 1) flightsString = "nema";
                
                toAdd.AddRange([flightsString, categoriesString]);
            }
            else
                toAdd.Add(airplane.Flights.Count.ToString());
            
            table.Add(toAdd);
        }
    
        return UiAssist.TurnTableIntoString(table);
    }
}
