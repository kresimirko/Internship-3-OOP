namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAircrewGroup(string? name = null, List<ObjectCollectionAircrew>? members = null)
    : ObjectCollection<ObjectCollectionAircrew>(name, members, "Nema posada.")
{
    public override string TurnDataTableIntoString(bool usesAltFormat = false)
    {
        var table = new List<List<string>> {};
        table.Add(["Naziv posade", "Lista članova"]);

        foreach (var aircrew in Members)
        {
            var membersString = string.Join(", ",
                (from member in aircrew select $"{member.FirstName} {member.LastName}").ToArray());
            if (membersString.Length < 1) membersString = "nema";
            
            table.Add([
                aircrew.Name,
                membersString
            ]);
        }
    
        return UiAssist.TurnTableIntoString(table);
    }
}
