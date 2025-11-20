namespace Internship_3_OOP.Entities;

public class EntityCrewMember(
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string email,
    string password,
    Gender gender,
    Role role)
    : EntityPerson(firstName, lastName, dateOfBirth, email, password, gender)
{
    public Role Role { get; private set; }
}

public enum Role
{
    Pilot,
    Copilot,
    FlightAttendant
}
