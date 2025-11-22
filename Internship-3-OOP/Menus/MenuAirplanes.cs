using Internship_3_OOP.Entities;
using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Menus;

public static class MenuAirplanes
{
    private static void ShowAllAirplanes()
    {
        UiAssist.ClearAndPrintAppHeader("Prikaz svih aviona");
        
        Storage.Airplanes.PrintDataTable(true);
    }

    private static void AddNewAirplane()
    {
        UiAssist.ClearAndPrintAppHeader("Dodavanje novog aviona");
        
        var name = UiAssist.OneLinePrompt<string>("Naziv: ");

        if (Storage.Airplanes.Any(airplane => name == airplane.Name))
        {
            Console.WriteLine("Avion s ovim imenom već postoji.");
            UiAssist.Halt();
            return;
        }
        
        var manufacturingYear = UiAssist.OneLinePromptIntInRange(1999, 2026,"Godina proizvodnje: ");
        Console.Write("Kategorije: [pritisnite Enter]");
        Console.ReadKey();
        
        var options = EntityAirplane.FlightCategoryCroatianMap.Values.ToList();
        options.Add("Završi");
        var categoriesWithSeats = new Dictionary<FlightCategory, int>();
        var categoriesAreDone = false;
        while (!categoriesAreDone)
        {
            var choice = UiAssist.PromptMenu(options.ToArray(), "Kategorije");
            if (choice == 0)
            {
                categoriesAreDone = true;
                continue;
            }
            var pickedCategory = (FlightCategory)(choice - 1);
            if (categoriesWithSeats.ContainsKey(pickedCategory))
            {
                Console.WriteLine("Kategorija već dodana.");
                UiAssist.Halt();
                continue;
            }
            var seats = UiAssist.OneLinePromptIntInRange(-1, 51, "Broj sjedala u kategoriji: ");
            categoriesWithSeats.Add(pickedCategory, seats);
            Console.WriteLine("Kategorija dodana. Pritisnite Enter za dodavanje sljedeće ili završavanje.");
            Console.ReadKey();
        }
        
        if (!UiAssist.PromptYesNoChoice("Dodavanje aviona uspješno.", "Dodavanje aviona otkazano.",
                $"Jeste li sigurni da želite dodati avion \"{name}\"?"))
            return;

        Storage.Airplanes.Add(new EntityAirplane(name, manufacturingYear, categoriesWithSeats));
        
        UiAssist.Halt();
    }
    
    private static void SearchAirplanes()
    {
        if (Storage.Users.ActiveUser is null)
            throw new NullReferenceException("User is null (shouldn't be at this point)");

        var searchResults =
            ObjectCollection<EntityAirplane>.GetSearchResults(Storage.Airplanes,
                "Pretraživanje rezerviranih letova");
        var searchResultsCollection = new ObjectCollectionAirplanes(null, searchResults);
        
        Console.WriteLine();
        searchResultsCollection.PrintDataTable(true, true);
    }

    private static void DeleteAirplane()
    {
        var choice = UiAssist.PromptMenu([
            "Po ID-u",
            "Po nazivu"
        ], "Brisanje aviona");

        EntityAirplane[] selected;
        switch (choice)
        {
            case 1:
                Console.WriteLine("Molimo vas upišite puni ID. Evo svih aviona:");
                Storage.Airplanes.PrintDataTable();
                
                var id = UiAssist.OneLinePrompt<string>("Upišite ID aviona: ").ToLower();
                
                selected = (from airplane in Storage.Airplanes where UiAssist.GetShortGuidString(airplane.Guid) == id.ToLower() select airplane).ToArray();
                
                if (selected.Length == 0)
                {
                    Console.WriteLine("Nema aviona s ovim ID-om.");
                    UiAssist.Halt();
                    return;
                }
                
                if (!UiAssist.PromptYesNoChoice("Brisanje aviona uspješno.", "Brisanje aviona otkazano.",
                        $"Jeste li sigurni da želite izbrisati avion \"{selected[0].Name}\"?"))
                    return;

                Storage.Airplanes.Remove(selected[0]);
                break;
            case 0:
                Console.WriteLine("Molimo vas upišite puni naziv. Evo svih aviona:");
                Storage.Airplanes.PrintDataTable();
                
                var name = UiAssist.OneLinePrompt<string>("Upišite ime aviona: ").ToLower();
                
                selected = (from airplane in Storage.Airplanes where airplane.Name.ToLower() == name.ToLower() select airplane).ToArray();
                
                if (selected.Length == 0)
                {
                    Console.WriteLine("Nema aviona s ovim imenom.");
                    UiAssist.Halt();
                    return;
                }
                
                if (!UiAssist.PromptYesNoChoice("Brisanje aviona uspješno.", "Brisanje aviona otkazano.",
                        $"Jeste li sigurni da želite izbrisati avion \"{selected[0].Name}\"?"))
                    return;

                Storage.Airplanes.Remove(selected[0]);
                break;
        }
        
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
