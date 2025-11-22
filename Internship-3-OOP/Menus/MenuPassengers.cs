using Internship_3_OOP.Entities;
using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Menus;

public static class MenuPassengers
{
    private static void ShowAllFlights()
    {
        UiAssist.ClearAndPrintAppHeader("Prikaz svih letova");

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

        if (Storage.Users.ActiveUser is null) return;

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

        Console.WriteLine("Dostupni letovi:");
        temporaryFlightCollection.PrintDataTable();
        Console.WriteLine();

        var choice = UiAssist.OneLinePromptIntInRange(-1, temporaryFlightCollection.Count(),
            "Odaberite let koji želite rezervirati: ");

        if (!UiAssist.PromptYesNoChoice("Rezerviranje leta uspješno.", "Rezerviranje leta otkazano.",
                $"Jeste li sigurni da želite dodati let \"{temporaryFlightCollection.Members[choice].Title}\" (odabir {choice})?"))
            return;

        Storage.Users.ActiveUser.Flights.Add(temporaryFlightCollection.Members[choice]);
        
        UiAssist.ClearAndPrintAppHeader("Odabir leta");
        Console.WriteLine("Vaši trenutačni letovi:");
        Storage.Users.ActiveUser.Flights.PrintDataTable(true);
    }
    
    private static void SearchFlights()
    {
        UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ], "Pretraživanje letova");
        UiAssist.Halt();
    }
    
    private static void CancelFlight()
    {
        UiAssist.ClearAndPrintAppHeader("Otkazivanje leta");
        
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
                KeyValuePair.Create("Odabir leta", PickFlight),
                KeyValuePair.Create("Pretraživanje letova", SearchFlights),
                KeyValuePair.Create("Otkazivanje leta", CancelFlight),
                backToMainMenuKvp
            ]);
        }
    }
}
