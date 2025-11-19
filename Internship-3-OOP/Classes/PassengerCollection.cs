namespace Internship_3_OOP.Classes;

public class PassengerCollection(List<Passenger>? passengers = null)
    : Entity, ICollectionDataTableProvidable<PassengerCollection>
{
    public List<Passenger> Passengers { get; private set; } = passengers ?? [];

    public void Add(string firstName, string lastName, DateTime dateOfBirth, string email,
        string password, Gender gender)
    {
        Passengers.Add(new Passenger(firstName, lastName, dateOfBirth, email, password, gender));
    }
    
    public static string TurnDataTableIntoString(PassengerCollection passengerCollection)
    {
        var table = new List<List<string>> {};
        table.Add(["Ime", "Prezime", "Datum rođenja", "Email", "Spol"]);
        
        table.AddRange(passengerCollection.Passengers.Select(passenger => (List<string>)
        [
            passenger.FirstName,
            passenger.LastName,
            passenger.DateOfBirth.ToString("yyyy-MM-dd"),
            passenger.Email,
            passenger.Gender.ToString()
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
    
    public static void PrintDataTable(PassengerCollection passengerCollection)
    {
        TurnDataTableIntoString(passengerCollection);
    }
    
    public string TurnDataTableOfSelfIntoString()
    {
        return TurnDataTableIntoString(this);
    }
    
    public void PrintDataTableOfSelf()
    {
        Console.WriteLine(TurnDataTableOfSelfIntoString());
    }
}
