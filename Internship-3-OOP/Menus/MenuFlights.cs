using Internship_3_OOP.Entities;
using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Menus;

public static class MenuFlights
{
    public static void ShowAllFlights()
    {
        UiAssist.ClearAndPrintAppHeader("Prikaz svih letova");
        
        Storage.Flights.PrintDataTable(true);
    }

    private static void AddFlight()
    {
        UiAssist.ClearAndPrintAppHeader("Dodavanje novog leta");
        
        var name = UiAssist.OneLinePrompt<string>("Naziv: ");
        var departure = UiAssist.OneLinePrompt<DateTime>("Vrijeme polaska: ");
        var departureLocation = UiAssist.OneLinePrompt<string>("Mjesto polaska: ");
        var arrival = UiAssist.OneLinePrompt<DateTime>("Vrijeme dolaska: ");
        var arrivalLocation = UiAssist.OneLinePrompt<string>("Mjesto dolaska: ");
        var distance = UiAssist.OneLinePromptIntInRange(19, 1001, "Udaljenost: ");

        if (Storage.Flights.Any(flight => name == flight.Name))
        {
            Console.WriteLine("Let s ovim imenom već postoji.");
            UiAssist.Halt();
            return;
        }
        
        Console.Write("Avion: [pritisnite Enter]");
        Console.ReadKey();
        var airplane = UiAssist.PromptMenu(
            Storage.Airplanes.Members.Select(airplane => airplane.Name).ToArray(), "Avion");
        
        Console.Write("Posada: [pritisnite Enter]");
        Console.ReadKey();
        var aircrew = UiAssist.PromptMenu(
            Storage.AircrewGroup.Members.Select(aircrew => aircrew.Name).ToArray(), "Posada");
        
        if (!UiAssist.PromptYesNoChoice("Dodavanje leta uspješno.", "Dodavanje leta otkazano.",
                $"Jeste li sigurni da želite dodati let \"{name}\"?"))
            return;

        Storage.Flights.Add(new EntityFlight(name, departure, departureLocation, arrival, arrivalLocation, distance));
            
        UiAssist.Halt();
    }
    
    private static void DeleteFlight()
    {
        var choice = UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ], "Brisanje aviona");

        EntityFlight[] selected;
        switch (choice)
        {
            case 1:
                Console.WriteLine("Molimo vas upišite puni ID. Evo svih letova:");
                Storage.Flights.PrintDataTable();
                
                var id = UiAssist.OneLinePrompt<string>("Upišite ID leta: ").ToLower();
                
                selected = (from flight in Storage.Flights where UiAssist.GetShortGuidString(flight.Guid) == id.ToLower() select flight).ToArray();
                
                if (selected.Length == 0)
                {
                    Console.WriteLine("Nema leta s ovim ID-om.");
                    UiAssist.Halt();
                    return;
                }
                
                if (!UiAssist.PromptYesNoChoice("Brisanje leta uspješno.", "Brisanje leta otkazano.",
                        $"Jeste li sigurni da želite izbrisati let \"{selected[0].Name}\"?"))
                    return;

                Storage.Flights.Remove(selected[0]);
                break;
            case 0:
                Console.WriteLine("Molimo vas upišite puni naziv. Evo svih aviona:");
                Storage.Flights.PrintDataTable();
                
                var name = UiAssist.OneLinePrompt<string>("Upišite ime aviona: ").ToLower();
                
                selected = (from flight in Storage.Flights where flight.Name.ToLower() == name.ToLower() select flight).ToArray();
                
                if (selected.Length == 0)
                {
                    Console.WriteLine("Nema aviona s ovim imenom.");
                    UiAssist.Halt();
                    return;
                }
                
                if (!UiAssist.PromptYesNoChoice("Brisanje leta uspješno.", "Brisanje leta otkazano.",
                        $"Jeste li sigurni da želite izbrisati let \"{selected[0].Name}\"?"))
                    return;

                Storage.Flights.Remove(selected[0]);
                break;
        }
        
        UiAssist.Halt();
    }

    private static void SearchFlights()
    {
        var searchResults =
            ObjectCollection<EntityFlight>.GetSearchResults(Storage.Flights,
                "Pretraživanje letova");
        var searchResultsCollection = new ObjectCollectionFlights(null, searchResults);
        
        Console.WriteLine();
        searchResultsCollection.PrintDataTable(true, true);
    }

    private static void EditFlight()
    {
        UiAssist.ClearAndPrintAppHeader("Uređivanje leta");
        
        UiAssist.Halt();
    }
    
    public static void Show()
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            UiAssist.PromptMappedMenu([
                KeyValuePair.Create("Prikaz svih letova", ShowAllFlights),
                KeyValuePair.Create("Dodavanje leta", AddFlight),
                KeyValuePair.Create("Pretraživanje letova", SearchFlights),
                KeyValuePair.Create("Uređivanje leta", EditFlight),
                KeyValuePair.Create("Brisanje leta", DeleteFlight),
                backToMainMenuKvp
            ]);
        }
    }    
}
