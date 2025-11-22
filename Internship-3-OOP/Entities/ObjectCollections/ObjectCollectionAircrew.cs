namespace Internship_3_OOP.Entities.ObjectCollections;

public class ObjectCollectionAircrew(string? name = null, List<EntityCrewMember>? members = null)
    : ObjectCollection<EntityCrewMember>(name, members, "Nema članova posade.")
{
    public override string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["Ime", "Prezime", "Pozicija", "Spol", "Datum rođenja"]);
        table.AddRange(Members.Select(crewMember => (List<string>)
        [
            crewMember.FirstName,
            crewMember.LastName,
            EntityCrewMember.AircrewRolesCroatianMap[crewMember.Role],
            EntityPerson.GenderCroatianMap[crewMember.Gender],
            crewMember.DateOfBirth.ToString("d")
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }
}
