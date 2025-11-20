using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Static.Menus;

public class MenuAircrews : IMenu<ObjectCollectionAircrewGroup>
{
    public static void ShowAllAircrews(ObjectCollectionAircrewGroup aircrews)
    {
        aircrews.PrintDataTable();
        foreach (var aircrew in aircrews)
            aircrew.PrintDataTable();
        
        UiAssist.Halt();
    }

    public static void CreateNewAircrew(ObjectCollectionAircrewGroup aircrews)
    {
        UiAssist.Halt();
    }

    public static void AddNewCrewMember(ObjectCollectionAircrewGroup aircrews)
    {
        UiAssist.Halt();
    }
    
    public static void Show(ObjectCollectionAircrewGroup aircrews)
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            UiAssist.PromptMappedMenu([
                KeyValuePair.Create("Prikaz svih posada", () => { ShowAllAircrews(aircrews); }),
                KeyValuePair.Create("Kreiranje nove posade", () => { CreateNewAircrew(aircrews); }),
                KeyValuePair.Create("Dodavanje osobe", () => { AddNewCrewMember(aircrews); }),
                backToMainMenuKvp
            ]);
        }
    }
}
