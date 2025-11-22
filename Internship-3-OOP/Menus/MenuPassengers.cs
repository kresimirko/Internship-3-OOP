using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Menus;

public static class MenuPassengers
{
    private static void ShowAllFlights()
    {
        UiAssist.ClearAndPrintAppHeader("Prikaz svih rezerviranih letova");

        var activeUser = Storage.Users.ActiveUser;
        
        if (activeUser is null) return;
        if (!activeUser.Flights.Any())
        {
            Console.WriteLine("Nemate dodanih letova.\n");
            UiAssist.Halt();
            return;
        }

        activeUser.Flights.PrintDataTable(true);
    }
    
    private static void PickFlight()
    {
        UiAssist.ClearAndPrintAppHeader("Odabir leta");

        if (Storage.Users.ActiveUser is null)
            throw new NullReferenceException("User is null (shouldn't be at this point)");

        if (!Storage.Flights.Any())
        {
            Console.WriteLine("Nema dostupnih letova.\n");
            UiAssist.Halt();
            return;
        }
            
        var temporaryFlightCollection = new ObjectCollectionFlights();
        foreach (var flight in Storage.Flights)
        {
            if (!Storage.Users.ActiveUser.Flights.Contains(flight))
                temporaryFlightCollection.Add(flight);
        }

        if (!temporaryFlightCollection.Any())
        {
            Console.WriteLine("Nema dostupnih letova.\n");
            UiAssist.Halt();
            return;
        }

        Console.WriteLine("Dostupni letovi:\n");
        temporaryFlightCollection.PrintDataTable();
        Console.WriteLine();

        var choice = UiAssist.OneLinePromptIntInRange(-1, temporaryFlightCollection.Count(),
            "Odaberite broj leta koji želite rezervirati: ");

        if (!UiAssist.PromptYesNoChoice("Rezerviranje leta uspješno.", "Rezerviranje leta otkazano.",
                $"Jeste li sigurni da želite dodati let \"{temporaryFlightCollection.Members[choice].Title}\" (odabir {choice})?"))
            return;

        Storage.Users.ActiveUser.Flights.Add(temporaryFlightCollection.Members[choice]);
        
        UiAssist.ClearAndPrintAppHeader("Odabir leta");
        Console.WriteLine("Vaši trenutačni letovi:\n");
        Storage.Users.ActiveUser.Flights.PrintDataTable(true);
    }
    
    private static void SearchFlights()
    {
        var choice = UiAssist.PromptMenu([
            "Po kratkom ID-u",
            "Po nazivu"
        ], "Pretraživanje letova");
        
        if (Storage.Users.ActiveUser is null)
            throw new NullReferenceException("User is null (shouldn't be at this point)");

        Console.WriteLine();
        var query = UiAssist.OneLinePrompt<string>("Pretraga: ");

        var searchResults = (from flight in Storage.Users.ActiveUser.Flights
            where (choice == 1 ? UiAssist.GetShortGuidString(flight.Guid) : flight.Title).Contains(query)
            select flight).ToArray();
        var searchResultsCollection = new ObjectCollectionFlights();
        searchResultsCollection.Members.AddRange(searchResults);
            
        Console.WriteLine();
        searchResultsCollection.PrintDataTable(true);
    }
    
    private static void CancelFlight()
    {
        UiAssist.ClearAndPrintAppHeader("Otkazivanje leta\n\nMožete otkazati samo letove koji nisu u sljedeća 24 sata.");
        
        if (Storage.Users.ActiveUser is null)
            throw new NullReferenceException("User is null (shouldn't be at this point)");
        
        var cancellableFlights = (from flight in Storage.Users.ActiveUser.Flights
            where (flight.Departure - DateTime.Now).TotalHours > 24
            select flight).ToArray();

        if (cancellableFlights.Length == 0)
        {
            Console.WriteLine("Nema letova koji mogu biti otkazani.\n");
            UiAssist.Halt();
            return;
        }
        
        var cancellableFlightsCollection = new ObjectCollectionFlights();
        cancellableFlightsCollection.Members.AddRange(cancellableFlights);
        
        Console.WriteLine("Letovi koji mogu biti otkazani:\n");
        cancellableFlightsCollection.PrintDataTable();
        Console.WriteLine();
        
        var choice = UiAssist.OneLinePromptIntInRange(-1, cancellableFlights.Length,
            "Odaberite broj leta koji želite otkazati: ");

        if (!UiAssist.PromptYesNoChoice("Otkazivanje leta uspješno.", "Otkazivanje leta otkazano.",
                $"Jeste li sigurni da želite otkazati let \"{cancellableFlights[choice].Title}\" (odabir {choice})?"))
            return;

        Storage.Users.ActiveUser.Flights.Remove(cancellableFlights[choice]);
        
        UiAssist.ClearAndPrintAppHeader("Otkazivanje leta");
        Console.WriteLine("Vaši trenutačni letovi:\n");
        Storage.Users.ActiveUser.Flights.PrintDataTable(true);
    }
    
    public static void Show()
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            UiAssist.PromptMappedMenu([
                KeyValuePair.Create("Prikaz svih letova", MenuFlights.ShowAllFlights),
                KeyValuePair.Create("Prikaz svih rezerviranih letova", ShowAllFlights),
                KeyValuePair.Create("Rezerviranje novog leta", PickFlight),
                KeyValuePair.Create("Pretraživanje rezerviranih letova", SearchFlights),
                KeyValuePair.Create("Otkazivanje leta", CancelFlight),
                backToMainMenuKvp
            ]);
        }
    }
}
