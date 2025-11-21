namespace Internship_3_OOP.Menus;

public static class MenuAirplanes
{
    private static void ShowAllAirplanes()
    {
        Storage.Airplanes.PrintDataTable(true);
    }

    private static void AddNewAirplane()
    {
        UiAssist.Halt();
    }

    private static void SearchAirplanes()
    {
        UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ]);
        UiAssist.Halt();
    }

    private static void DeleteAirplane()
    {
        UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ]);
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
                KeyValuePair.Create("Prikaz svih aviona", ShowAllAirplanes),
                KeyValuePair.Create("Dodavanje novog aviona", AddNewAirplane),
                KeyValuePair.Create("Pretraživanje aviona", SearchAirplanes),
                KeyValuePair.Create("Brisanje aviona", DeleteAirplane),
                backToMainMenuKvp
            ]);
        }
    }
}
