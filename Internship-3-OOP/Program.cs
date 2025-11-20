using Internship_3_OOP.Entities.ObjectCollections;
using Internship_3_OOP.Static;
using Internship_3_OOP.Static.Menus;

namespace Internship_3_OOP;

class Program
{
    private static void Main()
    {
        var running = true;

        var passengers = new ObjectCollectionPassengers();
        var flights = new ObjectCollectionFlights();
        var airplanes = new ObjectCollectionAirplanes();
        var aircrews = new ObjectCollectionAircrewGroup();
        
        while (running)
        {
            UiAssist.PromptMappedMenu([
                KeyValuePair.Create("Putnici", () => { MenuPassengers.Show(passengers); }),
                KeyValuePair.Create("Letovi", () => { MenuFlights.Show(flights); }),
                KeyValuePair.Create("Avioni", () => { MenuAirplanes.Show(airplanes); }),
                KeyValuePair.Create("Posada", () => { MenuAircrews.Show(aircrews); }),
                KeyValuePair.Create("Izlaz iz programa", () => { running = false; })
            ]);
        }
    }
}
