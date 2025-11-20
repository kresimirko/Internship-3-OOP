using Internship_3_OOP.Entities;
using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Static.Menus;

public class MenuMain : IMenu<EntityGlobalStorage>
{
    public static void Show(EntityGlobalStorage storage)
    {
        var running = true;
        
        var backToMainMenuKvp = KeyValuePair.Create(
            "Povratak na prethodni izbornik", () => { running = false; });
        
        while (running)
        {
            var currentUser = storage.Users.GetActiveUser();

            if (currentUser is not null)
            {
                var menuSubtitle = $"Prijavljeni ste kao \"{currentUser.GetFullName()}\"";
                
                if (currentUser.Level != Level.Admin)
                {
                    UiAssist.PromptMappedMenu([
                        KeyValuePair.Create("Opcije za putnike", () => { MenuPassengers.Show(storage.Users); }),
                        KeyValuePair.Create("Odjava", UiAssist.Halt),
                        KeyValuePair.Create("Izlaz iz programa", () => { running = false; })
                    ], menuSubtitle);
                }
                else
                {
                    UiAssist.PromptMappedMenu([
                        KeyValuePair.Create("Korisnici (putnici)", () => { storage.Users.PrintDataTable(true); }),
                        KeyValuePair.Create("Letovi", () => { MenuFlights.Show(storage.Flights); }),
                        KeyValuePair.Create("Avioni", () => { MenuAirplanes.Show(storage.Airplanes); }),
                        KeyValuePair.Create("Posada", () => { MenuAircrews.Show(storage.AircrewGroup); }),
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