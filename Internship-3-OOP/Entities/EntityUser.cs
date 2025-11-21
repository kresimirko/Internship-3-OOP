using System.Net.Mail;

namespace Internship_3_OOP.Entities;

public class EntityUser(
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    MailAddress email,
    string password,
    Gender gender,
    UserLevel level,
    List<EntityFlight>? flights = null)
    : EntityPerson(firstName, lastName, dateOfBirth, gender)
{
    public MailAddress Email { get; } = email;
    public string Password { get; } = password;
    public UserLevel Level { get; } = level;
    public List<EntityFlight> FlightList { get; } = flights ?? [];
    
    public static readonly Dictionary<UserLevel, string> UserLevelCroatianMap = new Dictionary<UserLevel, string>
    {
        { UserLevel.Admin, "admin" },
        { UserLevel.Passenger, "putnik" },
    };
    
    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}

public enum UserLevel
{
    Admin,
    Passenger
}
