using System.Net.Mail;

namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionUsers(string? name = null, List<EntityUser>? members = null)
    : ObjectCollection<EntityUser>(name, members, "Nema korisnika.")
{
    public EntityUser? ActiveUser { get; private set; }
    
    public string SignIn(MailAddress email, string password)
    {
        if (ActiveUser is not null)
            return "Neuspješno, netko je već prijavljen";
        
        foreach (var user in Members.Where(user => user.Email.Address == email.Address && user.Password == password))
        {
            ActiveUser = user;
            UpdateDateOfModification();
            return "Uspješno";
        }
        
        return "Neispravan email ili lozinka";
    }
    
    public string SignIn(EntityUser user)
    {
        if (ActiveUser is not null)
            return "Neuspješno, netko je već prijavljen";
        
        if (Members.All(storedUser => storedUser.Guid != user.Guid))
            return "Neuspješno, korisnik ne postoji";
        
        ActiveUser = user;
        UpdateDateOfModification();
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
            if (willBeLoggedInInstantly) SignIn(newUser);
            
            UpdateDateOfModification();
            return "Uspješno";
        }
        catch
        {
            return "Nepoznata greška";
        }
    }

    public void SignOut()
    {
        UpdateDateOfModification();
        ActiveUser = null;
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
