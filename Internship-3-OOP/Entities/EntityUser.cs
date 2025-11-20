namespace Internship_3_OOP.Entities;

public class EntityUser(
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    string email,
    string password,
    Gender gender,
    Level level,
    List<EntityFlight>? flights = null)
    : EntityPerson(firstName, lastName, dateOfBirth, gender)
{
    public string Email { get; } = email;
    public string Password { get; } = password;
    public Level Level { get; } = level;
    public List<EntityFlight> FlightList { get; } = flights ?? [];

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}

public enum Level
{
    Admin,
    Passenger
}
