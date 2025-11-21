namespace Internship_3_OOP.Static.Menus;

public static class MenuAircrews
{
    private static void ShowAllAircrews()
    {
        Storage.AircrewGroup.PrintDataTable();
        foreach (var aircrew in Storage.AircrewGroup)
            aircrew.PrintDataTable();
        
        UiAssist.Halt();
    }

    private static void CreateNewAircrew()
    {
        UiAssist.Halt();
    }

    private static void AddNewCrewMember()
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
                KeyValuePair.Create("Prikaz svih posada", ShowAllAircrews),
                KeyValuePair.Create("Kreiranje nove posade", CreateNewAircrew),
                KeyValuePair.Create("Dodavanje osobe", AddNewCrewMember),
                backToMainMenuKvp
            ]);
        }
    }
}
