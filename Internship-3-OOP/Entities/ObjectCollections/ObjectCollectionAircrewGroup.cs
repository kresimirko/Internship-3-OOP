namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAircrewGroup(string? name = null, List<ObjectCollectionAircrew>? members = null)
    : ObjectCollection<ObjectCollectionAircrew>(name, members, "Nema posada.")
{
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["Naziv posade", "Lista članova"]);
        table.AddRange(Members.Select(aircrew => (List<string>)
        [
            aircrew.Name,
            string.Join(", ", (from member in aircrew select $"{member.FirstName} {member.LastName}").ToArray())
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
