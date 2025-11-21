namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAircrew(string name, List<EntityCrewMember>? members = null)
    : ObjectCollection<EntityCrewMember>(members)
{
    public string Name { get; private set; } = name;
    
    public void Add(string firstName, string lastName, DateOnly dateOfBirth, string email,
        string password, Gender gender, Role role)
    {
        Members.Add(new EntityCrewMember(firstName, lastName, dateOfBirth, email, password, gender, role));
    }
    
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["Ime", "Prezime", "Pozicija", "Spol", "Datum rođenja"]);
        table.AddRange(Members.Select(crewMember => (List<string>)
        [
            crewMember.FirstName,
            crewMember.LastName,
            crewMember.Role.ToString(),
            crewMember.Gender.ToString(),
            crewMember.DateOfBirth.ToString("yyyy-MM-dd")
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
