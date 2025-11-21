using System.Net.Mail;

namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionUsers(List<EntityUser>? members = null) : ObjectCollection<EntityUser>(members)
{
    public Guid ActiveUser { get; private set; } = Guid.Empty;
    
    public string SignIn(MailAddress email, string password)
    {
        if (ActiveUser != Guid.Empty)
            return "Neuspješno, netko je već prijavljen";
        
        foreach (var user in Members.Where(user => user.Email.Address == email.Address && user.Password == password))
        {
            ActiveUser = user.Guid;
            return "Uspješno";
        }

        return "Neispravan email ili lozinka";
    }
    
    public string SignIn(EntityUser user)
    {
        if (ActiveUser != Guid.Empty)
            return "Neuspješno, netko je već prijavljen";
        
        if (Members.All(storedUser => storedUser.Guid != user.Guid))
            return "Neuspješno, korisnik ne postoji";
        
        ActiveUser = user.Guid;
        return "Uspješno";
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
            user.DateOfBirth.ToString("d"),
            user.Email.Address,
            EntityPerson.GenderCroatianMap[user.Gender]
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
