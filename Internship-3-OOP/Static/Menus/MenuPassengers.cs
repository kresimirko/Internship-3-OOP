using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Static.Menus;

public class MenuPassengers : IMenu<ObjectCollectionPassengers>
{
    private static void SignUpMenu()
    {
        UiAssist.Halt();
    }
    
    private static void SignInMenu()
    {
        UiAssist.Halt();
    }
    
    private static void ShowAllFlights()
    {
        UiAssist.Halt();
    }
    
    private static void PickFlight()
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
    
    private static void CancelFlight()
    {
        UiAssist.Halt();
    }
    
    public static void Show(ObjectCollectionPassengers passengers)
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            if (passengers.Members.Count == 0)
            {
                UiAssist.PromptMappedMenu([
                    KeyValuePair.Create("Registracija", SignUpMenu),
                    KeyValuePair.Create("Prijava", SignInMenu),
                    backToMainMenuKvp
                ]);
            }
            else
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
}
