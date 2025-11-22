namespace Internship_3_OOP.Menus;

public static class MenuAircrews
{
    private static void ShowAllAircrews()
    {
        UiAssist.ClearAndPrintAppHeader("Prikaz svih posada");
        
        Storage.AircrewGroup.PrintDataTable();

        if (!Storage.AircrewGroup.Any()) return;
        foreach (var aircrew in Storage.AircrewGroup)
        {
            Console.WriteLine("\n{0}", aircrew.Name);
            aircrew.PrintDataTable(true);
        }
    }

    private static void CreateNewAircrew()
    {
        UiAssist.ClearAndPrintAppHeader("Kreiranje nove posade");
        
        UiAssist.Halt();
    }

    private static void AddNewCrewMember()
    {
        UiAssist.ClearAndPrintAppHeader("Dodavanje osobe");
        
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
