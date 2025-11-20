using Internship_3_OOP.Static;

namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAircrewGroup(List<ObjectCollectionAircrew>? aircrewList = null)
    : ObjectCollection<ObjectCollectionAircrew>
{
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["Naziv posade", "Lista članova"]);
        table.AddRange(Members.Select(aircrew => (List<string>)
        [
            aircrew.Name,
            "---"
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
