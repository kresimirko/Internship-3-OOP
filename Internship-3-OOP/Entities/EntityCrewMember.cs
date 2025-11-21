namespace Internship_3_OOP.Entities;

public class EntityCrewMember(
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    string email,
    string password,
    Gender gender,
    AircrewRole role)
    : EntityPerson(firstName, lastName, dateOfBirth, gender)
{
    public AircrewRole Role { get; private set; }
    
    public static readonly Dictionary<AircrewRole, string> AircrewRolesCroatianMap = new Dictionary<AircrewRole, string>
    {
        { AircrewRole.Pilot, "pilot" },
        { AircrewRole.Copilot, "kopilot" },
        { AircrewRole.FlightAttendant, "stujard(esa)" },
    };
}

public enum AircrewRole
{
    Pilot,
    Copilot,
    FlightAttendant
}
