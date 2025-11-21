namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionUsers(List<EntityUser>? members = null) : ObjectCollection<EntityUser>(members)
{
    public Guid ActiveUser { get; private set; } = Guid.Empty;
    
    public void Add(string firstName, string lastName, DateOnly dateOfBirth, string email,
        string password, Gender gender, Level level)
    {
        Members.Add(new EntityUser(firstName, lastName, dateOfBirth, email, password, gender, level));
    }

    public void SignIn(string email, string password)
    {
        UiAssist.Halt();
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
            user.Email,
            user.Gender.ToString()
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
