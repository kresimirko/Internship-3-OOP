namespace Internship_3_OOP.Entities;

public abstract class EntityPerson(
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    Gender gender) : Entity
{
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public DateOnly DateOfBirth { get; private set; } = dateOfBirth;
    public Gender Gender { get; private set; } = gender;

    public static readonly Dictionary<Gender, string> GenderCroatianMap = new Dictionary<Gender, string>
    {
        { Gender.Male, "muško" },
        { Gender.Female, "žensko" },
        { Gender.Other, "drugo" },
        { Gender.PreferNotToSay, "ne želi se izjasniti" },
    };
}

public enum Gender
{
    Male,
    Female,
    Other,
    PreferNotToSay
}
