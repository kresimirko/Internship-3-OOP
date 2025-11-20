using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Static.Menus;

public class MenuAirplanes : IMenu<ObjectCollectionAirplanes>
{
    private static void ShowAllAirplanes(ObjectCollectionAirplanes airplanes)
    {
        airplanes.PrintDataTable();
        UiAssist.Halt();
    }

    private static void AddNewAirplane(ObjectCollectionAirplanes airplanes)
    {
        UiAssist.Halt();
    }

    private static void SearchAirplanes(ObjectCollectionAirplanes airplanes)
    {
        UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ]);
        UiAssist.Halt();
    }

    private static void DeleteAirplane(ObjectCollectionAirplanes airplanes)
    {
        UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ]);
        UiAssist.Halt();
    }
    
    public static void Show(ObjectCollectionAirplanes airplanes)
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            UiAssist.PromptMappedMenu([
                KeyValuePair.Create("Prikaz svih aviona", () => { ShowAllAirplanes(airplanes); }),
                KeyValuePair.Create("Dodavanje novog aviona", () => { AddNewAirplane(airplanes); }),
                KeyValuePair.Create("Pretraživanje aviona", () => { SearchAirplanes(airplanes); }),
                KeyValuePair.Create("Brisanje aviona", () => { DeleteAirplane(airplanes); }),
                backToMainMenuKvp
            ]);
        }
    }
}
