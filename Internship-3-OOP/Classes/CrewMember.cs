namespace Internship_3_OOP.Classes;

public class CrewMember(
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string email,
    string password,
    Gender gender,
    Role role)
    : Person(firstName, lastName, dateOfBirth, email, password, gender)
{
    public Role Role { get; private set; }
}
