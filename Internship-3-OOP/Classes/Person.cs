namespace Internship_3_OOP.Classes;

public abstract class Person(
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string email,
    string password,
    Gender gender) : Entity
{
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public DateTime DateOfBirth { get; private set; } = dateOfBirth;
    private string Email { get; set; } = email;
    private string Password { get; set; } = password;
    public Gender Gender { get; private set; } = gender;
}

public enum Gender
{
    Male,
    Female,
    Other
}
