using Internship_3_OOP.Entities;

namespace Internship_3_OOP.Static.Menus;

public static class MenuMain
{
    public static void Show()
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            var currentUser = Storage.Users.GetActiveUser();

            if (currentUser is not null)
            {
                var menuSubtitle = $"Prijavljeni ste kao \"{currentUser.GetFullName()}\"";
                
                if (currentUser.Level != Level.Admin)
                {
                    UiAssist.PromptMappedMenu([
                        KeyValuePair.Create("Opcije za putnike", MenuPassengers.Show),
                        KeyValuePair.Create("Odjava", UiAssist.Halt),
                        KeyValuePair.Create("Izlaz iz programa", () => { running = false; })
                    ], menuSubtitle);
                }
                else
                {
                    UiAssist.PromptMappedMenu([
                        KeyValuePair.Create("Korisnici (putnici)", () => { Storage.Users.PrintDataTable(true); }),
                        KeyValuePair.Create("Letovi", MenuFlights.Show),
                        KeyValuePair.Create("Avioni", MenuAirplanes.Show),
                        KeyValuePair.Create("Posada", MenuAircrews.Show),
                        KeyValuePair.Create("Odjava", UiAssist.Halt),
                        KeyValuePair.Create("Izlaz iz programa", () => { running = false; })
                    ], menuSubtitle);
                }
            }
            else
            {
                UiAssist.PromptMappedMenu([
                    KeyValuePair.Create("Prijava", UiAssist.Halt),
                    KeyValuePair.Create("Registracija", UiAssist.Halt),
                    KeyValuePair.Create("Izlaz iz programa", () => { running = false; })
                ], "Niste prijavljeni. Prijavite se kako biste pristupili značajkama aplikacije.");
            }
        }
    }    
}