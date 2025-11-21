using System.Net.Mail;

namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionUsers(List<EntityUser>? members = null) : ObjectCollection<EntityUser>(members)
{
    public Guid ActiveUser { get; private set; } = Guid.Empty;
    
    public void Add(string firstName, string lastName, DateOnly dateOfBirth, MailAddress email,
        string password, Gender gender, UserLevel level)
    {
        Members.Add(new EntityUser(firstName, lastName, dateOfBirth, email, password, gender, level));
    }

    public string SignIn(MailAddress email, string password)
    {
        foreach (var user in Members.Where(user => user.Email.Address == email.Address && user.Password == password))
        {
            ActiveUser = user.Guid;
            return "Uspješno";
        }

        return "Neispravan email ili lozinka";
    }

    public string SignUp(string firstName, string lastName, DateOnly dateOfBirth, MailAddress email,
        string password, Gender gender, bool willBeLoggedInInstantly = false)
    {
        if ((from user in Members where user.Email.Address == email.Address select user).Any())
            return "Korisnik već postoji";

        try
        {
            var newUser = new EntityUser(firstName, lastName, dateOfBirth, email, password, gender, UserLevel.Passenger);
            Add(newUser);
            if (willBeLoggedInInstantly) ActiveUser = newUser.Guid;
            
            return "Uspješno";
        }
        catch
        {
            return "Nepoznata greška";
        }
    }

    public void SignOut()
    {
        ActiveUser = Guid.Empty;
    }

    public void DEBUG_SetFirstUserInUserListToSignedInIfThereAreAny()
    {
        if (Members.Count != 0) ActiveUser = Members.First().Guid;
    }

    public EntityUser? GetActiveUser()
    {
        return (from user in Members where user.Guid == ActiveUser select user).FirstOrDefault();
    }
    
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["Ime", "Prezime", "Datum rođenja", "Email", "Spol"]);
        table.AddRange(Members.Select(user => (List<string>)
        [
            user.FirstName,
            user.LastName,
            user.DateOfBirth.ToString("yyyy-MM-dd"),
            user.Email.Address,
            user.Gender.ToString()
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
