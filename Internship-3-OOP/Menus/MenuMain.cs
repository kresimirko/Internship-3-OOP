using Internship_3_OOP.Entities;

namespace Internship_3_OOP.Menus;

public static class MenuMain
{
    private static void ShowAllUsers()
    {
        UiAssist.ClearAndPrintAppHeader("Korisnici (putnici)");
        
        Storage.Users.PrintDataTable(true);
    }
    
    public static void Show()
    {
        var running = true;
        
        var quitKvp = KeyValuePair.Create(
            "Izlaz iz programa", () => { running = false; });
        
        while (running)
        {
            var currentUser = Storage.Users.GetActiveUser();

            if (currentUser is not null)
            {
                var menuSubtitle = $"Prijavljeni ste kao \"{currentUser.GetFullName()}\"";
                
                if (currentUser.Level != UserLevel.Admin)
                {
                    UiAssist.PromptMappedMenu([
                        KeyValuePair.Create("Opcije za putnike", MenuPassengers.Show),
                        KeyValuePair.Create("Odjava", MenuUsers.SignOut),
                        quitKvp
                    ], menuSubtitle);
                }
                else
                {
                    UiAssist.PromptMappedMenu([
                        KeyValuePair.Create("Korisnici (putnici)", ShowAllUsers),
                        KeyValuePair.Create("Letovi", MenuFlights.Show),
                        KeyValuePair.Create("Avioni", MenuAirplanes.Show),
                        KeyValuePair.Create("Posada", MenuAircrews.Show),
                        KeyValuePair.Create("Odjava", MenuUsers.SignOut),
                        quitKvp
                    ], menuSubtitle);
                }
            }
            else
                running = MenuUsers.Startup();
        }
    }    
}