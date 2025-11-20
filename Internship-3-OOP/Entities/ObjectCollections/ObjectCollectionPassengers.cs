using Internship_3_OOP.Static;

namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionPassengers(List<EntityPassenger>? passengerList = null) : ObjectCollection<EntityPassenger>
{
    public void Add(string firstName, string lastName, DateTime dateOfBirth, string email,
        string password, Gender gender)
    {
        Members.Add(new EntityPassenger(firstName, lastName, dateOfBirth, email, password, gender));
    }

    public void SignIn(string email, string password)
    {
        UiAssist.Halt();
    }
    
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["Ime", "Prezime", "Datum rođenja", "Email", "Spol"]);
        table.AddRange(Members.Select(passenger => (List<string>)
        [
            passenger.FirstName,
            passenger.LastName,
            passenger.DateOfBirth.ToString("yyyy-MM-dd"),
            passenger.Email,
            passenger.Gender.ToString()
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
