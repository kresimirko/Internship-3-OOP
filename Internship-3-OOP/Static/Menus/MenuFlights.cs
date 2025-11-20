using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Static.Menus;

public class MenuFlights : IMenu<ObjectCollectionFlights>
{
    private static void ShowAllFlights(ObjectCollectionFlights flights)
    {
        flights.PrintDataTable(true);
    }

    private static void AddFlight(ObjectCollectionFlights flights)
    {
        UiAssist.Halt();
    }

    private static void SearchFlights(ObjectCollectionFlights flights)
    {
        UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ]);
        UiAssist.Halt();
    }

    private static void EditFlight(ObjectCollectionFlights flights)
    {
        UiAssist.Halt();
    }

    private static void DeleteFlight(ObjectCollectionFlights flights)
    {
        UiAssist.Halt();
    }
    
    public static void Show(ObjectCollectionFlights flights)
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            UiAssist.PromptMappedMenu([
                KeyValuePair.Create("Prikaz svih letova", () => { ShowAllFlights(flights); }),
                KeyValuePair.Create("Dodavanje leta", () => { AddFlight(flights); }),
                KeyValuePair.Create("Pretraživanje letova", () => { SearchFlights(flights); }),
                KeyValuePair.Create("Uređivanje leta", () => { EditFlight(flights); }),
                KeyValuePair.Create("Brisanje leta", () => { DeleteFlight(flights); }),
                backToMainMenuKvp
            ]);
        }
    }    
}
