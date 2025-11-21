using System.Net.Mail;
using Internship_3_OOP.Entities;

namespace Internship_3_OOP.Menus;

public static class MenuUsers
{
    private static void SignIn()
    {
        UiAssist.ClearAndPrintAppHeader("Prijava");
        
        var email = UiAssist.OneLinePrompt<MailAddress>("Email: ");
        var password = UiAssist.OneLinePrompt<string>("Lozinka: ");
        
        Console.WriteLine("\nStatus: {0}\n", Storage.Users.SignIn(email, password));
        UiAssist.Halt();
    }
    
    private static void SignUp()
    {
        UiAssist.ClearAndPrintAppHeader("Registracija");
        
        var firstName = UiAssist.OneLinePrompt<string>("Ime: ");
        var lastName = UiAssist.OneLinePrompt<string>("Prezime: ");
        var email = UiAssist.OneLinePrompt<MailAddress>("Email: ");
        var password = UiAssist.OneLinePrompt<string>("Lozinka: ");
        var dateOfBirth = UiAssist.OneLinePrompt<DateOnly>("Datum rođenja (YYYY-MM-DD): ");
        Console.Write("Spol: [pritisnite Enter]");
        Console.ReadKey();
        var gender = UiAssist.PromptMenu(EntityPerson.GenderCroatianMap.Values.ToArray(), "Spol");
        
        var actionResult = Storage.Users.SignUp(firstName, lastName, dateOfBirth, email, password, (Gender)gender, true);
        
        Console.WriteLine("\nStatus: {0}\n", actionResult);
        UiAssist.Halt();
    }
    
    public static void SignOut()
    {
        UiAssist.PromptMappedYesNoChoiceAndReport(
            Storage.Users.SignOut,
            "Da",
            () => {},
            "Ne",
            "[!] Jeste li sigurni da se želite odjaviti? [!]");
    }
    
    public static bool Startup()
    {
        var running = true;
        UiAssist.PromptMappedMenu([
            KeyValuePair.Create("Prijava", SignIn),
            KeyValuePair.Create("Registracija", SignUp),
            KeyValuePair.Create("Izlaz iz programa", () => { running = false; })
        ], "Niste prijavljeni. Prijavite se kako biste pristupili značajkama aplikacije.");
        return running;
    }
}
