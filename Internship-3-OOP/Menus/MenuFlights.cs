namespace Internship_3_OOP.Menus;

public class MenuFlights
{
    private static void ShowAllFlights()
    {
        Storage.Flights.PrintDataTable(true);
    }

    private static void AddFlight()
    {
        UiAssist.Halt();
    }

    private static void SearchFlights()
    {
        UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ]);
        UiAssist.Halt();
    }

    private static void EditFlight()
    {
        UiAssist.Halt();
    }

    private static void DeleteFlight()
    {
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
