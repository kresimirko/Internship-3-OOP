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
        UiAssist.ClearAndPrintAppHeader("Dodavanje leta");
        
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

    private static void DeleteFlight()
    {
        UiAssist.ClearAndPrintAppHeader("Brisanje leta");
        
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
