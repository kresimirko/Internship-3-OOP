namespace Internship_3_OOP.Classes;

public class Aircrew(List<CrewMember>? crewMembers = null) : Collection<CrewMember>, ICollectionDataTableProvidable<Aircrew>
{
    public List<CrewMember> CrewMembers { get; private set; } = crewMembers ?? [];

    public void Add(string firstName, string lastName, DateTime dateOfBirth, string email,
        string password, Gender gender, Role role)
    {
        CrewMembers.Add(new CrewMember(firstName, lastName, dateOfBirth, email, password, gender, role));
    }
    
    public static string TurnDataTableIntoString(Aircrew aircrew)
    {
        var table = new List<List<string>> {};
        table.Add(["Ime", "Prezime", "Pozicija", "Spol", "Datum rođenja"]);
        table.AddRange(aircrew.CrewMembers.Select(crewMember => (List<string>)
        [
            crewMember.FirstName,
            crewMember.LastName,
            crewMember.Role.ToString(),
            crewMember.Gender.ToString(),
            crewMember.DateOfBirth.ToString("yyyy-MM-dd")
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
    
    public static void PrintDataTable(Aircrew aircrew)
    {
        TurnDataTableIntoString(aircrew);
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
