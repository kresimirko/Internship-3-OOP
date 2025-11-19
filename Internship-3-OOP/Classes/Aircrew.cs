namespace Internship_3_OOP.Classes;

public class Aircrew(List<CrewMember>? crewMembers = null) : Entity
{
    public List<CrewMember> CrewMembers { get; private set; } = crewMembers ?? [];

    public void AddMember(CrewMember crewMember)
    {
        CrewMembers.Add(crewMember);
    }

    public void AddMember(string firstName, string lastName, DateTime dateOfBirth, string email,
        string password, Gender gender, Role role)
    {
        CrewMembers.Add(new CrewMember(firstName, lastName, dateOfBirth, email, password, gender, role));
    }

    public void RemoveMember(CrewMember crewMember)
    {
        CrewMembers.Remove(crewMember);
    }

    public void RemoveMember(Guid id)
    {
        CrewMembers.RemoveAll(x => x.Id == id);
    }
}
