using Internship_3_OOP.Entities;
using Internship_3_OOP.Entities.ObjectCollections;

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
            aircrew.PrintDataTable();
        }

        Console.WriteLine();
        UiAssist.Halt();
    }

    private static void CreateNewAircrew()
    {
        UiAssist.ClearAndPrintAppHeader("Kreiranje nove posade");
        
        var name = UiAssist.OneLinePrompt<string>("Ime: ");

        if (Storage.AircrewGroup.Any(aircrew => name == aircrew.Name))
        {
            Console.WriteLine("Posada s ovim imenom već postoji.");
            UiAssist.Halt();
            return;
        }

        var availableCrewMembers = Storage.AllCrewMembers.Where(member => !member.IsInAnAircrew).ToArray();
        if (availableCrewMembers.Length == 0)
        {
            Console.WriteLine("Nema dostupnih osoba.");
            UiAssist.Halt();
            return;
        }
        var availablePilots = availableCrewMembers.Where(member => member.Role == AircrewRole.Pilot).ToArray();
        if (availablePilots.Length == 0)
        {
            Console.WriteLine("Nema dostupnih pilota.");
            UiAssist.Halt();
            return;
        }
        var availableCopilots = availableCrewMembers.Where(member => member.Role == AircrewRole.Copilot).ToArray();
        if (availableCopilots.Length == 0)
        {
            Console.WriteLine("Nema dostupnih kopilota.");
            UiAssist.Halt();
            return;
        }
        var availableFlightAttendants = availableCrewMembers.Where(member => member.Role == AircrewRole.FlightAttendant).ToArray();
        if (availableFlightAttendants.Length < 2)
        {
            Console.WriteLine("Nema dostupnih stjuarda/esa ili ih je manje od 2.");
            UiAssist.Halt();
            return;
        }
        
        Console.Write("\nBiranje pilota, kopilota i stjuarda/esa [pritisnite Enter]");
        Console.ReadKey();
        
        var pilot = availablePilots[UiAssist.PromptMenu(
            availablePilots.Select(pilot => pilot.Name).ToArray(), "Dostupni piloti", true) - 1];
        
        var copilot = availableCopilots[UiAssist.PromptMenu(
            availableCopilots.Select(copilot => copilot.Name).ToArray(), "Dostupni kopiloti", true) - 1];
        
        var flightAttendant1 = availableFlightAttendants[UiAssist.PromptMenu(
            availableFlightAttendants.Select(flightAttendant1 => $"{flightAttendant1.FirstName} {flightAttendant1.LastName}").ToArray(), "Dostupni stjuardi/ese #1", true) - 1];
        
        var availableSecondFlightAttendants = availableFlightAttendants.Where(member => member != flightAttendant1).ToArray();
        
        var flightAttendant2 = availableSecondFlightAttendants[UiAssist.PromptMenu(
            availableSecondFlightAttendants.Select(flightAttendant2 => $"{flightAttendant2.FirstName} {flightAttendant2.LastName}").ToArray(), "Dostupni stjuardi/ese #2", true) - 1];
        
        if (!UiAssist.PromptYesNoChoice("Dodavanje posade...", "Dodavanje posade otkazano.",
                $"Jeste li sigurni da želite dodati posadu \"{name}\"?"))
            return;

        pilot.IsInAnAircrew = true;
        copilot.IsInAnAircrew = true;
        flightAttendant1.IsInAnAircrew = true;
        flightAttendant2.IsInAnAircrew = true;
        
        Storage.AircrewGroup.Add(new ObjectCollectionAircrew(name, [
            pilot,
            copilot,
            flightAttendant1,
            flightAttendant2
        ]));
        Console.WriteLine("Dodavanje posade uspješno.\n");
        UiAssist.Halt();
    }

    private static void AddNewCrewMember()
    {
        UiAssist.ClearAndPrintAppHeader("Dodavanje osobe");
        
        var firstName = UiAssist.OneLinePrompt<string>("Ime: ");
        var lastName = UiAssist.OneLinePrompt<string>("Prezime: ");
        var dateOfBirth = UiAssist.OneLinePrompt<DateOnly>("Datum rođenja (YYYY-MM-DD): ");
        
        Console.Write("Spol i pozicija: [pritisnite Enter]");
        Console.ReadKey();
        var genderPrompt = UiAssist.PromptMenu(EntityPerson.GenderCroatianMap.Values.ToArray(), "Spol", true) - 1;
        var gender = (Gender)genderPrompt;
        
        var rolePrompt = UiAssist.PromptMenu(EntityCrewMember.AircrewRolesCroatianMap.Values.ToArray(), "Pozicija", true) - 1;
        var role = (AircrewRole)rolePrompt;
        
        if (!UiAssist.PromptYesNoChoice("Dodavanje posade...", "Dodavanje posade otkazano.",
                $"Jeste li sigurni da želite dodati osobu \"{firstName} {lastName}\"?"))
            return;

        Storage.AllCrewMembers.Add(new EntityCrewMember(firstName, lastName, dateOfBirth, gender, role));
        
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
